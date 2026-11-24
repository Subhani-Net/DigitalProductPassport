#!/usr/bin/env node
/**
 * Single-source website build.
 *
 * The pages under business/website keep PLACEHOLDER literals. This script stamps
 * them with the values in site.config.json and writes the result to dist/.
 * Change a value once in site.config.json, rebuild, and every page updates.
 *
 * Usage:
 *   node business/website/build.mjs
 *
 * No dependencies. Node 18+ (uses the built-in fs/promises API).
 */
import { promises as fs } from "node:fs";
import path from "node:path";
import { fileURLToPath } from "node:url";

const SRC = path.dirname(fileURLToPath(import.meta.url));
const DIST = path.join(SRC, "dist");
const CONFIG_PATH = path.join(SRC, "site.config.json");

// The literals that live in the source pages. These are the "template" values.
const PLACEHOLDERS = {
  email: "hello@veriflow.example",
  phoneHref: "+440000000000",
  phone: "+44 (0) 0000 000 000",
  domain: "veriflow.example",
  brand: "Veriflow",
  address: "London, United Kingdom"
};

// Never copy these into dist (SWA handles api/ separately; the rest are internal).
const SKIP_TOP_LEVEL = new Set([
  "dist",
  "api",
  "specs",
  "node_modules",
  ".git",
  "build.mjs",
  "site.config.json",
  "README.md",
  "TODO.md"
]);

const TEXT_EXT = new Set([
  ".html", ".htm", ".js", ".mjs", ".css", ".svg",
  ".txt", ".xml", ".json", ".webmanifest"
]);

const config = JSON.parse(await fs.readFile(CONFIG_PATH, "utf8"));

function stamp(text) {
  const S = "\u0000";
  let out = text;
  // Protect the more specific values first so later replacements can't corrupt them.
  out = out.split(PLACEHOLDERS.email).join(`${S}EMAIL${S}`);
  out = out.split(PLACEHOLDERS.phoneHref).join(`${S}PHONEHREF${S}`);
  out = out.split(PLACEHOLDERS.phone).join(`${S}PHONE${S}`);
  // Then the general swaps.
  out = out.split(PLACEHOLDERS.domain).join(config.domain);
  out = out.split(PLACEHOLDERS.brand).join(config.brand);
  out = out.split(PLACEHOLDERS.address).join(config.address);
  // Restore protected values to their configured form.
  out = out.split(`${S}EMAIL${S}`).join(config.email);
  out = out.split(`${S}PHONEHREF${S}`).join(config.phoneHref);
  out = out.split(`${S}PHONE${S}`).join(config.phone);
  return out;
}

let files = 0;

async function copyTree(dir, rel = "") {
  const entries = await fs.readdir(dir, { withFileTypes: true });
  for (const entry of entries) {
    if (rel === "" && SKIP_TOP_LEVEL.has(entry.name)) continue;
    const from = path.join(dir, entry.name);
    const relPath = path.join(rel, entry.name);
    const to = path.join(DIST, relPath);

    if (entry.isDirectory()) {
      await fs.mkdir(to, { recursive: true });
      await copyTree(from, relPath);
    } else if (entry.isFile()) {
      const ext = path.extname(entry.name).toLowerCase();
      if (TEXT_EXT.has(ext)) {
        await fs.writeFile(to, stamp(await fs.readFile(from, "utf8")), "utf8");
      } else {
        await fs.copyFile(from, to);
      }
      files++;
    }
  }
}

await fs.rm(DIST, { recursive: true, force: true });
await fs.mkdir(DIST, { recursive: true });
await copyTree(SRC);

console.log(
  `Stamped ${files} files into ${path.relative(process.cwd(), DIST)} ` +
  `(brand: ${config.brand}, domain: ${config.domain}, email: ${config.email})`
);
