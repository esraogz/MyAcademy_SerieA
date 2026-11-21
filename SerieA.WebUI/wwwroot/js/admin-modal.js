// Admin modal yardımcıları: açılan her modal temiz olsun, hata mesajları kapanınca/açılınca kalmasın.

// Modal içindeki tüm doğrulama ve API hata mesajlarını temizler.
function clearModalErrors(modal) {
    // Input altı alan mesajları
    modal.querySelectorAll('.field-validation-error, .field-validation-valid').forEach(function (el) {
        el.textContent = '';
    });
    // Modal üstündeki genel hata kutusu (iş kuralı hataları)
    modal.querySelectorAll('.validation-summary-errors, .form-alert').forEach(function (el) {
        el.remove();
    });
}

// Kullanıcı bir modalı açtığında temiz göstermek için (isteğe bağlı formu da sıfırlar).
function openCleanModal(modal, resetForm) {
    clearModalErrors(modal);
    if (resetForm) {
        var form = modal.querySelector('form');
        if (form) form.reset();
    }
    modal.showModal();
}

// Her modal kapandığında (X, Vazgeç veya ESC) hata mesajlarını temizle.
document.addEventListener('DOMContentLoaded', function () {
    document.querySelectorAll('dialog.modal-a').forEach(function (modal) {
        modal.addEventListener('close', function () {
            clearModalErrors(modal);
        });
    });
});
