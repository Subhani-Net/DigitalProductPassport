<#
.SYNOPSIS
  Lock/Unlock local-only sensitive docs: keep plaintext on disk, track only ciphertext.

.DESCRIPTION
  Plaintext stays local (gitignored); an encrypted "<file>.enc" is what gets committed to the
  repository. Uses OpenSSL AES-256-CBC + PBKDF2 with a passphrase read from the local, never-
  committed key file ".dpp-key" at the repo root.

  Usage:
    powershell -File tools/crypt-docs.ps1 -Lock      # plaintext -> .enc  (do this after edits, then commit the .enc)
    powershell -File tools/crypt-docs.ps1 -Unlock    # .enc -> plaintext

  Default file: business/investor/investment-plan.md  (override with -File)
#>
param(
  [switch]$Lock,
  [switch]$Unlock,
  [string]$File = "business/investor/investment-plan.md"
)

$repoRoot = Split-Path $PSScriptRoot -Parent
$keyFile  = Join-Path $repoRoot ".dpp-key"
$plain    = Join-Path $repoRoot $File
$enc      = "$plain.enc"

$openssl = (Get-Command openssl -ErrorAction SilentlyContinue).Source
if (-not $openssl) { $openssl = "C:\Program Files\Git\usr\bin\openssl.exe" }
if (-not (Test-Path $openssl)) { throw "openssl not found (looked on PATH and in Git for Windows)." }
if (-not (Test-Path $keyFile))  { throw "Key file not found: $keyFile  (create a random passphrase in it: openssl rand -base64 48)." }

if ($Lock) {
  if (-not (Test-Path $plain)) { throw "Plaintext not found: $plain" }
  & $openssl enc -aes-256-cbc -pbkdf2 -salt -in $plain -out $enc -pass "file:$keyFile"
  if ($LASTEXITCODE -ne 0) { throw "Encryption failed." }
  Write-Host "Locked:  $File  ->  $File.enc  (commit the .enc)"
}
elseif ($Unlock) {
  if (-not (Test-Path $enc)) { throw "Encrypted not found: $enc" }
  & $openssl enc -d -aes-256-cbc -pbkdf2 -in $enc -out $plain -pass "file:$keyFile"
  if ($LASTEXITCODE -ne 0) { throw "Decryption failed (wrong key?)." }
  Write-Host "Unlocked: $File.enc  ->  $File"
}
else {
  Write-Host "Specify -Lock or -Unlock. Default file: $File"
}
