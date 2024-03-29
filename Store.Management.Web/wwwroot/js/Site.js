$(document).ready(function () {
    if ($("body").hasClass("dark") == false) {
        $("body").addClass("dark");
        $(".change").text("OFF");
    }
});

$(".change").on("click", () => {
    if ($("body").hasClass("dark")) {
        $("body").removeClass("dark");
        $(".change").text("ON");
    } else {
        $("body").addClass("dark");
        $(".change").text("OFF");
    }
});