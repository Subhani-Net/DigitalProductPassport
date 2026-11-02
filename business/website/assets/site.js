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
})();
