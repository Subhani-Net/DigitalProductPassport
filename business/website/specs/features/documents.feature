# Application shell — separate from the CBAM engine BDDs in product/tests/.
@app @ui @ignore @stub
Feature: Document upload and management
  As an exporter
  I want to upload and track my source documents
  So that the engine has the evidence it needs

  Background:
    Given a signed-in exporter owner
    And an active installation

  Scenario: Request an upload for a PDF
    When the user requests an upload for "electricity-bill.pdf" of type "UTILITY_BILL"
    Then a document record is created with status "UPLOADED"
    And a short-lived upload URL is returned
    And the storage key is scoped to the installation

  Scenario Outline: Reject a disallowed file type
    When the user requests an upload for a file of type "<mimeType>"
    Then the request is rejected with "validation_error"

    Examples:
      | mimeType         |
      | application/zip  |
      | application/x-msdownload |
      | text/html        |

  Scenario: Reject a file over the size limit
    When the user requests an upload for a 26 MB file
    Then the request is rejected with "validation_error"

  Scenario: Complete an upload and start processing
    Given an upload intent for a valid PDF
    When the user completes the upload
    Then the document status becomes "PROCESSING"
    And a malware scan is queued

  Scenario: A clean scan marks the document ready for audit
    Given a document in "PROCESSING"
    When the malware scan returns "CLEAN"
    Then the document status becomes "READY_FOR_AUDIT"

  Scenario: An infected file is quarantined
    Given a document in "PROCESSING"
    When the malware scan returns "INFECTED"
    Then the document status becomes "QUARANTINED"
    And the file is never served to the user

  Scenario: List documents with pagination
    Given 30 documents in the installation
    When the user lists documents with page size 20
    Then 20 items are returned with a total of 30

  Scenario: Soft-delete a document
    Given a document uploaded by the user
    When the user deletes it
    Then the document is marked deleted
    And an audit event is written

  Scenario: An expired upload URL must be re-requested
    Given an upload intent that has expired
    When the user tries to upload to it
    Then the upload is rejected
    And the user can request a new intent

  Scenario: A member cannot delete another member's document
    Given a document uploaded by the owner
    When an exporter member tries to delete it
    Then the request is rejected with "forbidden"
