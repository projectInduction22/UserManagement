$(document).ready(function () {
    $('.loginbtn').click(function () {
        if ($('input#userName').val() === "1" && $('input#password').val() === "1") {
            document.location.href = "https://localhost:44384/api/internal/users/" + userName + "/" + password;
        } else {
            alert('Incorrect Account Details');
        }
    });
});