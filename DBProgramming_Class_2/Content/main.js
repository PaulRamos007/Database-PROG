function search() {
    var searchTerm = document.getElementById('txtSearch').value;

    window.location.href = "/Customer/CustomersList/?searchTerm=" + searchTerm;
}