$(document).ready(function () {
    let submit = $("#submitBtn");

    submit.click(function (e) {
        e.preventDefault();

        let email = $("#subscribies input[name='email']");
        let success = $("#subscribies .alert-success");
        let warning = $("#subscribies .alert-warning");
        success.css("display", "none");
        warning.css("display", "none");

        $.ajax({
            url: "Home/Subscribe",
            type: "get",
            dataType: "json",
            data: {
                email: email.val()
            },
            success: function (response) {
                if (response.status == true) {
                    success.css("display", "block");
                    success.text(response.message);
                } else {
                    warning.css("display", "block");
                    warning.text(response.message);
                }
            },
            error: function (error) {
                console.log(error);
            },
            complete: function () {
                email.val("");
            }

        });
    });
});
