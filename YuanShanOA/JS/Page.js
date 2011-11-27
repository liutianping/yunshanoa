

$(document).ready(function () {

    $('.level1').hover(
                function () {
                    $(this).css({ "background-image": "url(/image/menu-1.jpg)" });
                    //$(this).addClass('menuhover');
                },
                function () {
                    $(this).css({ "background-image": "url(/image/menu.jpg)" });
                    //$(this).removeClass('menuhover');
                });

    $(' .level2').hide();
    $('.level1').click(function () {
        $(".level2").not($(this).next()).slideUp('500');
        $(this).next().slideToggle('500');
    });

    $('.level2 ul a').hover(function () {
        $(this).parent().css({ "background-image": "url(../image/a-1.jpg)" });
    },
          function () {
              $(this).parent().css({ "background-image": "url(../image/a.jpg)" });
          });

    $(' .btnCar').click(function () {
        $(' .btnCar').addClass(' btnCar');
        //$(this).addClass('btnCarClick');
        $(this).css({ "color": "Black" });
    });

 

});