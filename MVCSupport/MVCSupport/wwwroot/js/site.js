

$(document).ready(function () {

    LoadData();


});

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
        service: $('#service').val()
    };
    $.ajax({
        url: "/Supporter/create",
        data: $(myModal).serialize(),
        type: "POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result) {
            

            document.getElementById('name').value = '';
            document.getElementById('firstSurname').value = '';
            document.getElementById('secondSurname').value = '';
            document.getElementById('email').value = '';
            document.getElementById('password').value = '';
            document.getElementById('listAdmin').value = '';
            document.getElementById('listService').value = '';
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
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
