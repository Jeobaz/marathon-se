setTitle = (title) => { document.title = title; };

$("svg").find("g#seven").click(function () {
    $("#number").text("Checkpoint 7");
    $('.card').fadeIn();
});

$('.close').on('click', function () {
    $(this).closest('.card').fadeOut();
})