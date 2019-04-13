// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function formatDate(date) {
    var day = new Date(date).getDay();
    var month = new Date(date).getDate();
    return (day.toString().length === 1 ? "0" : "") + day + "/" + (month.toString().length === 1 ? "0" : "")+ month + "/" + new Date(date).getFullYear();
}

var Load = () => {
    $.get("/api/values", function (data) {
        var html = "";
        for (var item in data) {
            html += "<tr><td>" + data[item].user.name + "</td>";
            html += "<td>" + data[item].user.emailId + "</td>";
            html += "<td>" + data[item].user.gender.value + "</td>";
            html += "<td>" + formatDate(data[item].dateRegistered) + "</td>";
            html += "<td>" + data[item].registrationDay.map(a => a.eventDay.label) + "</td>";
            html += "<td>" + data[item].additionalRequest + "</td></tr>";
        }
        $(".result").html(html);
        setTimeout(function () { $(".loader").hide(); }, 500);
    }).fail(function () {
        alert("Sorry! Something went wrong");
    });
}