"use strict";

/**
 * POST /api/contact
 * Captures a website enquiry into Azure Table Storage.
 * No email is sent at this stage (by design).
 *
 * Required app setting:
 *   STORAGE_CONNECTION_STRING  — Azure Storage connection string
 * Optional:
 *   CONTACT_TABLE_NAME         — defaults to "ContactSubmissions"
 */

const { TableClient } = require("@azure/data-tables");
const crypto = require("crypto");

const TABLE_NAME = process.env.CONTACT_TABLE_NAME || "ContactSubmissions";
const LIMITS = {
  name: 200,
  company: 200,
  role: 120,
  email: 254,
  country: 120,
  products: 500,
  markets: 500,
  message: 5000
};

function clean(value, max) {
  if (typeof value !== "string") return "";
  return value.trim().slice(0, max);
}

function isEmail(value) {
  return /^[^\s@]+@[^\s@]+\.[^\s@]{2,}$/.test(value);
}

let tableReady = false;

async function getTableClient() {
  const connectionString = process.env.STORAGE_CONNECTION_STRING;
  if (!connectionString) throw new Error("STORAGE_CONNECTION_STRING is not configured");

  const client = TableClient.fromConnectionString(connectionString, TABLE_NAME);

  if (!tableReady) {
    try {
      await client.createTable();
    } catch (err) {
      if (!err || err.statusCode !== 409) throw err; // 409 = already exists
    }
    tableReady = true;
  }
  return client;
}

module.exports = async function (context, req) {
  const headers = {
    "Content-Type": "application/json",
    "Cache-Control": "no-store"
  };

  if (req.method !== "POST") {
    context.res = { status: 405, headers, body: { ok: false, error: "method_not_allowed" } };
    return;
  }

  const body = req.body || {};

  // Honeypot: real users never fill this hidden field.
  if (clean(body.website, 200)) {
    context.res = { status: 200, headers, body: { ok: true } };
    return;
  }

  const record = {
    name: clean(body.name, LIMITS.name),
    company: clean(body.company, LIMITS.company),
    role: clean(body.role, LIMITS.role),
    email: clean(body.email, LIMITS.email),
    country: clean(body.country, LIMITS.country),
    products: clean(body.products, LIMITS.products),
    markets: clean(body.markets, LIMITS.markets),
    message: clean(body.message, LIMITS.message),
    consent:
      body.consent === true || body.consent === "true" || body.consent === "on"
  };

  if (!record.name || !record.company || !isEmail(record.email) || !record.consent) {
    context.res = { status: 400, headers, body: { ok: false, error: "invalid_input" } };
    return;
  }

  try {
    const client = await getTableClient();
    const submittedAt = new Date().toISOString();
    const rowKey = `${Date.now()}-${crypto.randomUUID()}`;

    await client.createEntity({
      partitionKey: "contact",
      rowKey,
      submittedAt,
      ...record
    });

    context.res = { status: 200, headers, body: { ok: true } };
  } catch (err) {
    context.log("contact submission failed", err);
    context.res = { status: 500, headers, body: { ok: false, error: "storage_error" } };
  }
};
