$(function () {
    $("form[name='loginForm']").validate({
        rules: {
            loginInput: {
                required: true,
                minlength: 3,
            },
            passwordInput: {
                required: true,
                minlength: 3,
            },
            submitHandler: function (form) {
                form.submit();
            }
        },

        messages: {
            loginInput: {
                required: "Login is required",
            },
            passwordInput: {
                required: "Password is required",
            },
        },
    });
});

$(function () {
    $.validator.addMethod("correctLogin", function (value, element) {
        let regCheck = /^[A-Za-z]([A-Za-z0-9]{1,})([A-Za-z0-9])$/;
        return value == '' || regCheck.test(value) == true;
    }, "Inapropriate input (start with latin letter and use only latin letters or numbers)");

    $.validator.addMethod("correctPassword", function (value, element) {
        let regCheck = /^([A-Za-z0-9]{1,})([A-Za-z0-9])$/;
        return value == '' || regCheck.test(value) == true;
    }, "Inapropriate input (use only symbols or numbers)");

    $.validator.addMethod("correctName", function (value, element) {
        let regCheck = /^[A-Za-z]([A-Za-z]{1,})([A-Za-z])$/;
        return value == '' || regCheck.test(value) == true;
    }, "Inapropriate input (use only latin letters)");
    $("form[name='registerForm']").validate({
        rules: {
            userLogin: {
                required: true,
                minlength: 3,
                maxlength: 50,
                correctLogin: true
            },
            userPassword: {
                required: true,
                minlength: 3,
                maxlength: 50,
                correctPassword: true
            },
            userRepPassword: {
                required: true,
                minlength: 3,
                maxlength: 50,
                equalTo: "#inputPassword",
                correctPassword: true
            },

            userFirstName: {
                requierd: false,
                minlength: 3,
                maxlength: 50,
                correctName: true
            },
            userLastName: {
                requierd: false,
                minlength: 3,
                maxlength: 50,
                correctName: true
            },
            userDateOfBirth: {
                requierd: false,
            },
            userImage: {
                requierd: false,
            },
            secretPassword: {
                requierd: false,
            },

            submitHandler: function (form) {
                form.submit();
            }
        },

        messages: {
            userLogin: {
                required: "Login is required",
            },
            userPassword: {
                required: "Password is required",
            },
            userRepPassword: {
                required: "Repeat password input",
                equalTo: "Password mismatch",
            },
        },
    });
});