$(document).ready(function () {
    bindEvents();

}
    function userDetailsOnLoginBtnClick(userName, password) {
        //console.log(employeeId)
        return $.ajax({
            url: 'https://localhost:44383/api/internal/users/' + userName + password,
            type: 'GET',
            contentType: "application/json; charset=utf-8"
        });
    }
