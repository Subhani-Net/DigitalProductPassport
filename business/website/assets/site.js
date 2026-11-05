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
})();
