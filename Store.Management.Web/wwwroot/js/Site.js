$(document).ready(function () {
    if ($("body").hasClass("dark") == false) {
        $("body").addClass("dark");
        $(".change").text("DISABLED");
        $(".navbar-label").css('color', 'white');
    }
});

$(".change").on("click", () => {
    if ($("body").hasClass("dark") == true) {
        $("body").removeClass("dark");
        $(".change").text("ENABLED");
        $(".navbar-label").css('color', 'black');
    } else {
        $("body").addClass("dark");
        $(".change").text("DISABLED");
        $(".navbar-label").css('color', 'white');
    }
});