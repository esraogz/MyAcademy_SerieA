// Yalnızca şablon önizlemesi için. cshtml'e taşırken gerekmez:
// modal yardımcıları zaten wwwroot/js/admin-modal.js içinde.

// Mobil menü
document.querySelectorAll('[data-sidebar-toggle]').forEach(function (btn) {
    btn.addEventListener('click', function () {
        var open = document.body.classList.toggle('sidebar-open');
        btn.setAttribute('aria-expanded', open);
    });
});

// Modal aç/kapat: data-open="#id" açar, data-close kapatır
document.querySelectorAll('[data-open]').forEach(function (el) {
    el.addEventListener('click', function () {
        var modal = document.querySelector(el.dataset.open);
        if (!modal) return;
        var form = modal.querySelector('form');
        // Düzenle butonundaki data-fill-* değerlerini form alanlarına doldur
        Object.keys(el.dataset).forEach(function (k) {
            if (k.indexOf('fill') !== 0) return;
            var name = k.slice(4);
            var field = modal.querySelector('[name="' + name + '" i]') || modal.querySelector('[data-fill="' + name + '" i]');
            if (!field) return;
            if (field.tagName === 'INPUT' || field.tagName === 'SELECT') field.value = el.dataset[k];
            else field.textContent = el.dataset[k];
        });
        modal.showModal();
    });
});
document.querySelectorAll('[data-close]').forEach(function (el) {
    el.addEventListener('click', function () { el.closest('dialog').close(); });
});
document.querySelectorAll('form[data-demo]').forEach(function (f) {
    f.addEventListener('submit', function (e) { e.preventDefault(); f.closest('dialog').close(); });
});
