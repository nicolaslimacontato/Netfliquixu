(() => {
    'use strict';
    const forms = document.querySelectorAll('.needs-validation');
    Array.prototype.slice.call(forms).forEach((form) => {
        form.addEventListener('submit', (event) => {
            if (!form.checkValidity()) {
                event.preventDefault();
                event.stopPropagation();
            }
            form.classList.add('was-validated');
        }, false);
    });
})();

// Custom submit button handling
document.getElementById('submitBtn').addEventListener('click', function(event) {
    event.preventDefault();
    const form = document.querySelector('.needs-validation');
    if (form.checkValidity()) {
        alert('E-mail válido! Prosseguindo com a ação desejada.');
        // Continue with the desired action, e.g., form submission
    } else {
        form.classList.add('was-validated');
        event.stopPropagation();
    }
});