// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var Load = () => {
    $.get("/api/values", function (data) {
        var html = "";
        for (var item in data) {
	        html += "<tr><td>" + data[item].user.name + "</td>";
            html += "<td>" + data[item].user.email + "</td>";
            html += "<td>" + data[item].user.gender + "</td></tr >";
        }
        $(".result").html(html);
    });
}