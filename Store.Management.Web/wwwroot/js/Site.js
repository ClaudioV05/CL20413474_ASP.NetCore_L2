$(document).ready(function () {
    if ($("body").hasClass("dark") == false) {
        $("body").addClass("dark");
        $(".change").text("DISABLED");
        $(".navbar-label").css('color', 'white');
        $("#idSpanStoreManagement").css('color', 'white');
        $(".modal-content").css('background-color', 'black');
    }
});

$(".change").on("click", () => {
    if ($("body").hasClass("dark") == true) {
        $("body").removeClass("dark");
        $(".change").text("ENABLED");
        $(".navbar-label").css('color', 'black');
        $("#idSpanStoreManagement").css('color', 'black');
        $(".modal-content").css('background-color', 'white');
    } else {
        $("body").addClass("dark");
        $(".change").text("DISABLED");
        $(".navbar-label").css('color', 'white');
        $("#idSpanStoreManagement").css('color', 'white');
        $(".modal-content").css('background-color', 'black');
    }
});