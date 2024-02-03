// Event Listener : "show.bs.modal"
const actionModal = document.getElementById('actionModal');
actionModal.addEventListener('show.bs.modal', event => {
    //! Modal'ı tetikleyen button'u al
    const button = event.relatedTarget;

    //! Modal'ın butonunu güncelle
    const approveButton = actionModal.querySelector('#approveButton');
    approveButton.removeChild(approveButton.firstChild);
    var cloneButton = button.cloneNode(true);
    cloneButton.setAttribute("id", "approveButton")
    cloneButton.removeAttribute("data-bs-target");
    cloneButton.removeAttribute("data-bs-toggle");
    if (!cloneButton.hasAttribute("href")) {
        cloneButton.type = "post";
    }
    approveButton.replaceWith(cloneButton);
});