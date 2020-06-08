$(document).ready(function (e) {
    $("#registerLink").click(function () {
        $(function () {
            $("#signIn").fadeOut("fast", function () {
                $("#signIn").css("display", "none");
                $("#register").fadeIn("fast", function () {
                    $("#register").css("display", "block");
                });
            });
        });
    });

    $("#signInLink").click(function () {
        $(function () {
            $("#register").fadeOut("fast", function () {
                $("#register").css("display", "none");
                $("#signIn").fadeIn("fast", function () {
                    $("#signIn").css("display", "block");
                });
            });
        });
    });

    $("#loginForm").submit(function (event) {
        var loginModel = {
            Username: $('#loginUsername').val(),
            Password: $('#loginPassword').val()
        }
        var loginModelJson = JSON.stringify(loginModel);
        event.preventDefault();
        mp.trigger('loginInformationToServer', loginModelJson);
    });

    $("#registerForm").submit(function (event) {
        var registerModel = {
            Username: $('#registerUsername').val(),
            Email: $('#registerEmail').val(),
            Password: $('#registerPassword').val()
        }
        var registerModeljson = JSON.stringify(registerModel);
        event.preventDefault();
        mp.trigger('registerInformationToServer', registerModeljson);
    });
});