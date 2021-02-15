// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$(document).ready(function () {

    LoadData();
    $('#myModal').modal();

    $('#myModal').bootstrapValidator({
        fields: {
            name: {
                validators: {
                    notEmpty: {
                        message: 'El nombre es obligatorio'
                    }
                }
            },
            edad: {
                validators: {
                    notEmpty: {
                        message: 'La edad es obligatoria'
                    },
                    integer: {
                        message: 'Debe introducir un valor entero'
                    }
                }
            },
            direccion: {
                validators: {
                    notEmpty: {
                        message: 'La dirección es obligatoria'
                    }
                }
            }
        }
    });
    /*$('#savedata').click(function () {
        var data = {
            "email": $("#email").val(),
            "password": $("#password").val()
        };
        $.ajax({
            url: "/Supporter/GetToAuthenticate",
            type: "POST",
            data: JSON.stringify(data),
            dataType: "json",
            contentType: "application/json",
            success: function (response) {
                if (response.Success) {
                    $.get("@Url.Action(Index, Supporter)",function (data) {
                        $('.container').html(data);
                    });
                }
                else
                    window.location.href = "@Url.Action(Index, Login)";
            },
            error: function () {
                console.log('Login Fail!!!');
            }
        });
    });
   $("#alertYes").hide();
    $("#alertNo").hide();
    $("#begin").submit(function (e){
        e.preventDefault();
        user = $.trim($("#email").val());
        pass = $.trim($("#pass").val());
        if (user.length > 0 && pass.length > 0) {
            $("#alertYes").fadeTo(2000, 500).slideUp(500, function () {
                $("#alertYes").slideUp(500);
            });
        } else {
            $("#alertNo").fadeTo(2000, 500).slideUp(500, function () {
                $("#alertNo").slideUp(500);
            });
 
    
    }
    
     });*/
    
})

function Alert() {
    $("#alertYes").hide();
    $("#alertNo").hide();
    $("#begin").submit(function (e) {
        e.preventDefault();
        user = $.trim($("#email").val());
        pass = $.trim($("#pass").val());
        if (user.length > 0 && pass.length > 0) {
            $("#alertYes").fadeTo(2000, 500).slideUp(500, function () {
                $("#alertYes").slideUp(500);
            });
        } else {
            $("#alertNo").fadeTo(2000, 500).slideUp(500, function () {
                $("#alertNo").slideUp(500);
            });


        }

    })
}

function LoadData() {
    $.ajax({
        
        url: "/Supporter/Get",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td>' + item.id + '</td>';
                html += '<td>' + item.name + '</td>';
                html += '<td>' + item.firstSurname + '</td>';
                html += '<td>' + item.secondSurname + '</td>';
                html += '<td>' + item.email + '</td>';
                html += '<td>' + item.password + '</td>';
                html += '<td>' + item.role + '</td>';
                html += '<td>' + item.idSupervisor + '</td>';
                html += '<td><a href="#" onclick="return GetById(' + item.id + ')">Edit</a> | <a href="#" onclick="Delete(' + item.id + ')">Delete</a></td>';
            });
            $('.tbody').html(html);

        },
        error: function (errorMessage) {
            alert(errorMessage.responseText);
        }
    })

}

function Add() {

    var supporter = {
      
        name: $('#name').val(),
        firstSurname: $('#firstSurname').val(),
        secondSurname: $('#secondSurname').val(),
        email: $('#email').val(),
        password: $('#password').val(),
        role: $('#role').val(),
        idSupervisor: $('#idSupervisor').val()
    };
    $.ajax({
        url: "/Supporter/Post",
        data: JSON.stringify(supporter),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            //loadData();
            $('#myModal').modal('hide');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

  
function getbyID(id) {
    $('#id').css('border-color', 'lightgrey');
    $('#name').css('border-color', 'lightgrey');
    $('#firstSurname').css('border-color', 'lightgrey');
    $('#secondSurname').css('border-color', 'lightgrey');
    $('#email').css('border-color', 'lightgrey');
    $('#password').css('border-color', 'lightgrey');
    $('#role').css('border-color', 'lightgrey');
    $('#idSupervisor').css('border-color', 'lightgrey');
    $.ajax({
        url: "/Supporter/Exist/" + id,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#id').val(result.id);
            $('#name').val(result.name);
            $('#firstSurname').val(result.firstSurname);
            $('#secondSurname').val(result.secondSurname);
            $('#email').val(result.email);
            $('#password').val(result.password);
            $('#role').val(result.role);
            $('#idSupervisor').val(result.idSupervisor);

            $('#myModal').modal('show');
            $('#btnUpdate').show();
            $('#btnAdd').hide();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}


function Update() {
    var res = validate();
    if (res == false) {
        return false;
    }
    var supporter = {
        id: $('#id').val(),
        name: $('#name').val(),
        firstSurname: $('#firstSurname').val(),
        secondSurname: $('#secondSurname').val(),
        email: $('#email').val(),
        password: $('#password').val(),
        role: $('#role').val(),
        idSupervisor: $('#idSupervisor').val()
    };
    $.ajax({
        url: "/Supporter/Update",
        data: JSON.stringify(empObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            $('#').modal('hide');
            $('#id').val("");
            $('#firstSurname').val("");
            $('#secondSurname').val("");
            $('#email').val("");
            $('#password').val("");
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}


function Delele(ID) {
    var ans = confirm("Are you sure you want to delete this Record?");
    if (ans) {
        $.ajax({
            url: "/Supporter/Delete/" + ID,
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {
                loadData();
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}  


$(function () {
    $('input, select').on('focus', function () {
        $(this).parent().find('.input-group-text').css('border-color', '#80bdff');
    });
    $('input, select').on('blur', function () {
        $(this).parent().find('.input-group-text').css('border-color', '#ced4da');
    });
});
