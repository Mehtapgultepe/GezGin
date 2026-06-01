// Navbar scroll effect
window.addEventListener('scroll', function () {
    const nav = document.getElementById('mainNav');
    if (nav) {
        if (window.scrollY > 60) {
            nav.classList.add('scrolled');
        } else {
            nav.classList.remove('scrolled');
        }
    }
});

// Form validation
document.addEventListener('DOMContentLoaded', function () {
    const forms = document.querySelectorAll('.needs-validation');
    forms.forEach(function (form) {
        form.addEventListener('submit', function (event) {
            if (!form.checkValidity()) {
                event.preventDefault();
                event.stopPropagation();
            }
            form.classList.add('was-validated');
        });
    });

    // Smooth scroll for anchor links
    document.querySelectorAll('a[href^="#"]').forEach(anchor => {
        anchor.addEventListener('click', function (e) {
            const target = document.querySelector(this.getAttribute('href'));
            if (target) {
                e.preventDefault();
                target.scrollIntoView({ behavior: 'smooth', block: 'start' });
            }
        });
    });
});

// Kişi sayısına göre fiyat hesaplama (Booking sayfasında)
function updatePrice() {
    const select = document.getElementById('tourSelect');
    const personInput = document.getElementById('personCount');
    const priceDisplay = document.getElementById('dynamicPrice');

    if (!select || !personInput || !priceDisplay) return;

    const selectedOption = select.options[select.selectedIndex];
    const price = parseFloat(selectedOption.getAttribute('data-price')) || 0;
    const persons = parseInt(personInput.value) || 1;
    const total = price * persons;

    priceDisplay.textContent = total.toLocaleString('tr-TR') + ' €';

    const perPerson = document.getElementById('pricePerPerson');
    if (perPerson) perPerson.textContent = price.toLocaleString('tr-TR') + ' €';
}
