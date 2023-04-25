$('#myModal').on('shown.bs.modal', function () {
    $('#myInput').trigger('focus')
})


$(function () {
    var save = '@TempData["save"]'
    if (save != null)
        alertify.success(save);
})

$(document).ready(function () {
    $("ul.navbar-nav > li > a").click(function (e) {
        $("ul.navbar-nav > li > a").removeClass("active");
        $(this).addClass("active");
    });
});


