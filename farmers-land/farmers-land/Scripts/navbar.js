$(document).ready(function () {
    $(".nav-item").hover(
        function () { $(this).addClass("active") },
        function () { $(this).removeClass("active") }
    );
});