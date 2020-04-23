setTitle = (title) => { document.title = title; };

$("svg").find("g#seven").click(function () {
    $("#number").text("Checkpoint 7");
    $('.card').fadeIn();
});

$('.close').on('click', function () {
    $(this).closest('.card').fadeOut();
})

function FileSaveAs(filename, fileContent) {
    var link = document.createElement('a');
    link.download = filename;
    link.href = "data:text/plain;charset=utf-8," + encodeURIComponent(fileContent)
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
}