$(document).ready(function () {
    $('#createRole,#roleManager,#deleteRole').hide();
    $('#btnCreatRole').click(function () {
        $('#createRole').show();
        $('#roleManager,#deleteRole').hide();
    });

    $('#btnDeleteRole').click(function () {
        $('#deleteRole').show();
        $('#roleManager,#createRole').hide();
        getAllRoleForDelete();
    });

    $('#btnRoleManager').click(function () {
        $('#roleManager').show();
        $('#createRole,#deleteRole').hide();
        showRole();
    });
});

function addRole() {
    var rName = $('#txtRoleName').val();

    $.get(
            "../AJAX/ssss.ashx?time=" + Date(),
            { roleName: rName },
            function (text) {
                $('#addRole').text(text);
            }
            );
}
function showRole() {
    var text = $('#selectAllUser').attr('id');
    if (text = "") {
        $('#btnConfirmDelete').hide();
    }
    $.get(
            "../AJAX/GetAllUser.ashx?time=" + Date(),
            function (html) {
                $('#showRole').html(html);
            }
            );
}

function getRoleByUser(name) {

    $.get(
            "../AJAX/AddUserToRole.ashx?time=" + Date(),
            { userName: name },
            function (html) {

                $('#getUName').html(html);
            }
            );
    $('#selectedName').text(name);
}

function getRoleName(roleName) {
    var userName = $('#selectedName').text();
    $.get(
            "../AJAX/RoleManagereByUserName.ashx?time=" + Date(),
            { roleName: roleName, userName: userName },
            function (html) {
                $('#message').text(html);

            }
            );
}


function getAllRoleForDelete() {
    $.get(
            "../AJAX/GetAllRoleForDelete.ashx?time=" + Date(),
            function (html) {
                $('#delete').html(html);
            }
            );
}

function deleteRoleName(roleName) {

    $('#tempRole').text($('#tempRole').text() + '|' + roleName);
}

function deleteRole() {

    $.get(
            "../AJAX/DeleteRole.ashx?time=" + Date(),
            { roleNameList: $('#tempRole').text() },
            function (html) {

                $('#delete').html(html);
            }
            );
}