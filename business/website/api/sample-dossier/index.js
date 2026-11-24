"use strict";

/**
 * POST /api/sample-dossier
 * Validates an email request, records it, and returns the sample dossier URL.
 *
 * Required app setting:
 *   STORAGE_CONNECTION_STRING  — Azure Storage connection string
 * Optional:
 *   SAMPLE_TABLE_NAME          — defaults to "SampleDossierRequests"
 *   SAMPLE_DOSSIER_URL         — defaults to /assets/samples/rajkot-reference-dossier.pdf
 *
 * For hard gating, point SAMPLE_DOSSIER_URL at a short-lived Azure Blob SAS URL.
 */

const { TableClient } = require("@azure/data-tables");
const crypto = require("crypto");

const TABLE_NAME = process.env.SAMPLE_TABLE_NAME || "SampleDossierRequests";
const DEFAULT_URL = process.env.SAMPLE_DOSSIER_URL || "/assets/samples/rajkot-reference-dossier.pdf";

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
      if (!err || err.statusCode !== 409) throw err;
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

  // Honeypot
  if (clean(body.website, 200)) {
    context.res = { status: 200, headers, body: { ok: true, downloadUrl: DEFAULT_URL } };
    return;
  }

  const record = {
    email: clean(body.email, 254).toLowerCase(),
    name: clean(body.name, 200),
    company: clean(body.company, 200),
    consent: body.consent === true || body.consent === "true" || body.consent === "on"
  };

  if (!isEmail(record.email) || !record.consent) {
    context.res = { status: 400, headers, body: { ok: false, error: "invalid_input" } };
    return;
  }

  try {
    const client = await getTableClient();
    const submittedAt = new Date().toISOString();
    const rowKey = `${Date.now()}-${crypto.randomUUID()}`;
    await client.createEntity({
      partitionKey: "sample-dossier",
      rowKey,
      submittedAt,
      source: "website-sample",
      ...record
    });

    context.res = { status: 200, headers, body: { ok: true, downloadUrl: DEFAULT_URL } };
  } catch (err) {
    context.log("sample dossier request failed", err);
    context.res = { status: 503, headers, body: { ok: false, error: "capture_unavailable" } };
  }
};
