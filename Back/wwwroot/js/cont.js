document.getElementById("frm").addEventListener('submit', function (e) {
    var errors = [];


    if (errors.length) {
        e.preventDefault(); // The browser will not make the HTTP POST request
        return;
    }
    $('#wrong-valid').show();
    setTimeout(function () {

        $('#wrong-valid').hide();
    }, 5000);
});