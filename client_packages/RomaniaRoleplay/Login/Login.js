$(document).ready(function (e) {
    $("#submitLogin").click(function (event) {
        var loginModel = {
            Username: $('#loginUsername').val(),
            Password: $('#loginPassword').val()
        }
        var loginModelJson = JSON.stringify(loginModel);
        event.preventDefault();
        mp.trigger('loginInformationToServer', loginModelJson);
    });

    $("#myVideo").prop("autoplay", true);
    $("#myVideo").get(0).load();
});