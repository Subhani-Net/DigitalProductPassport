/* Small progressive enhancements for the static site. */
(function () {
  "use strict";

  // Close the mobile menu after a navigation click.
  document.querySelectorAll(".site-nav a").forEach(function (link) {
    link.addEventListener("click", function () {
      var toggle = document.getElementById("nav-toggle");
      if (toggle) toggle.checked = false;
    });
  });

  // Current year in the footer.
  var year = document.getElementById("year");
  if (year) year.textContent = String(new Date().getFullYear());

  // Contact form -> Azure Static Web Apps managed function (POST /api/contact).
  var form = document.getElementById("contact-form");
  if (form) {
    form.addEventListener("submit", function (event) {
      event.preventDefault();

      var status = document.getElementById("form-status");
      var button = form.querySelector('button[type="submit"]');
      var data = Object.fromEntries(new FormData(form).entries());

      // Honeypot: let the server accept-and-drop, but avoid a round-trip.
      if (data.website) return;

      if (status) {
        status.textContent = "";
        status.className = "form-status";
      }
      if (button) {
        button.disabled = true;
        button.dataset.label = button.textContent;
        button.textContent = "Sending…";
      }

      fetch("/api/contact", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(data),
        credentials: "same-origin"
      })
        .then(function (response) {
          if (!response.ok) throw new Error("Request failed: " + response.status);
          form.reset();
          if (status) {
            status.textContent = "Thanks — we have your note and will reply within one business day.";
            status.className = "form-status ok";
          }
        })
        .catch(function () {
          if (status) {
            status.textContent =
              "Sorry — the form is not available right now. Please email hello@veriflow.example.";
            status.className = "form-status err";
          }
        })
        .finally(function () {
          if (button) {
            button.disabled = false;
            button.textContent = button.dataset.label || "Send enquiry";
          }
        });
    });
  }
  // Sample-dossier gate -> Azure Function (POST /api/sample-dossier).
  var sampleForm = document.getElementById("sample-form");
  if (sampleForm) {
    sampleForm.addEventListener("submit", function (event) {
      event.preventDefault();

      var status = document.getElementById("sample-status");
      var download = document.getElementById("sample-download");
      var button = sampleForm.querySelector('button[type="submit"]');
      var data = Object.fromEntries(new FormData(sampleForm).entries());
      var emailOk = /^[^\s@]+@[^\s@]+\.[^\s@]{2,}$/.test(String(data.email || "").trim());

      if (data.website) return;

      if (!emailOk) {
        if (status) {
          status.textContent = "Please enter a valid email address.";
          status.className = "form-status err";
        }
        return;
      }
      if (data.consent !== "on" && data.consent !== "true") {
        if (status) {
          status.textContent = "Please agree to the privacy notice to continue.";
          status.className = "form-status err";
        }
        return;
      }

      if (status) {
        status.textContent = "";
        status.className = "form-status";
      }
      if (button) {
        button.disabled = true;
        button.dataset.label = button.textContent;
        button.textContent = "Checking…";
      }

      fetch("/api/sample-dossier", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(data),
        credentials: "same-origin"
      })
        .then(function (response) {
          if (!response.ok) throw new Error("Request failed: " + response.status);
          return response.json();
        })
        .then(function (payload) {
          if (download && payload && payload.downloadUrl) {
            download.href = payload.downloadUrl;
            download.classList.remove("hide");
          }
          if (status) {
            status.textContent = "Thanks — your sample is ready. Use the download button below.";
            status.className = "form-status ok";
          }
        })
        .catch(function () {
          if (status) {
            status.textContent =
              "Sorry — we could not validate that request right now. Please email hello@veriflow.example.";
            status.className = "form-status err";
          }
        })
        .finally(function () {
          if (button) {
            button.disabled = false;
            button.textContent = button.dataset.label || "Send me the sample";
          }
        });
    });
  }
})();
