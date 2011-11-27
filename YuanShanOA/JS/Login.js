

$(document).ready(function () {
    $('.main').hide();
    $('.btn').hover(function () {
        $(this).addClass('btnhover');
    },
            function () {
                $(this).removeClass('btnhover');
            });


    $('.r').hover(function () {
        $(this).addClass('rhover');
    },
            function () {
                $(this).removeClass('rhover');
            });

    $('.r').click(function () {
        $(this).siblings('.r').removeClass('rclick').end().addClass('rclick');
        $('.main').slideDown('slow');
        var role = $(this).attr('id');
        switch (role) {
            case 'r1':
                $('.currentrole').html('局长');
                $('#hfdRoleID').val("1");
                break;
            case 'r2':
                $('.currentrole').html('副局长');
                $('#hfdRoleID').val("2");
                break;
            case 'r3':
                $('.currentrole').html('办公人员');
                $('#hfdRoleID').val("3");
                break;
            case 'r4':
                $('.currentrole').html('教职人员');
                $('#hfdRoleID').val("4");
                break;
            case 'r5':
                $('.currentrole').html('管理员');
                $('#hfdRoleID').val("5");
                break;
        }
    });




});