document.addEventListener('DOMContentLoaded', function() {
    const hamburger = document.querySelector('.hamburger');
    const navLinks = document.querySelector('.nav-links');
    const menuBackdrop = document.createElement('div');
    menuBackdrop.classList.add('menu-backdrop');
    document.body.appendChild(menuBackdrop);

    // Función para abrir el menú
    hamburger.addEventListener('click', function() {
        navLinks.classList.toggle('show');
        menuBackdrop.classList.toggle('show');
        document.body.classList.toggle('menu-open');
    });

    // Función para cerrar el menú cuando se hace clic en el backdrop
    menuBackdrop.addEventListener('click', function() {
        navLinks.classList.remove('show');
        menuBackdrop.classList.remove('show');
        document.body.classList.remove('menu-open');
    });
});
