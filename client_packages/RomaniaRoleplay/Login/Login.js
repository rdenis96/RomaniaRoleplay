$(document).ready(function (e) {
    $("#loginForm").submit(function (event) {
        var loginModel = {
            Username: $('#loginUsername').val(),
            Password: $('#loginPassword').val()
        }
        var loginModelJson = JSON.stringify(loginModel);
        event.preventDefault();
        mp.trigger('loginInformationToServer', loginModelJson);
    });
});