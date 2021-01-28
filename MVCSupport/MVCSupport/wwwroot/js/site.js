// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$(document).ready(function () {

    LoadData();
});


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
    var res = validate();
    if (res == false) {
        return false;
    }
    var supporter = {
        id: $('#Id').val(),
        name: $('#Name').val(),
        firstSurname: $('#FirstSurname').val(),
        secondSurname: $('#SecondSurname').val(),
        email: $('#Email').val(),
        password: $('#Password').val(),
        role: $('#Role').val(),
        idSupervisor: $('#IdSupervisor').val()
    };
    $.ajax({
        url: "/Supporter/Post",
        data: JSON.stringify(supporter),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            $('#myModal').modal('hide');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//Function for getting the Data Based upon Employee ID  
function getbyID(id) {
    $('#Id').css('border-color', 'lightgrey');
    $('#Name').css('border-color', 'lightgrey');
    $('#FirstSurname').css('border-color', 'lightgrey');
    $('#SecondSurname').css('border-color', 'lightgrey');
    $('#Email').css('border-color', 'lightgrey');
    $('#Password').css('border-color', 'lightgrey');
    $('#Role').css('border-color', 'lightgrey');
    $('#IdSupervisor').css('border-color', 'lightgrey');
    $.ajax({
        url: "/Supporter/Exist/" + id,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#Id').val(result.id);
            $('#Name').val(result.name);
            $('#FirstSurname').val(result.firstSurname);
            $('#SecondSurname').val(result.secondSurname);
            $('#Email').val(result.email);
            $('#Password').val(result.password);
            $('#Role').val(result.role);
            $('#IdSupervisor').val(result.idSupervisor);

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
        id: $('#Id').val(),
        name: $('#Name').val(),
        firstSurname: $('#FirstSurname').val(),
        secondSurname: $('#SecondSurname').val(),
        email: $('#Email').val(),
        password: $('#Password').val(),
        role: $('#Role').val(),
        idSupervisor: $('#IdSupervisor').val()
    };
    $.ajax({
        url: "/Supporter/Update",
        data: JSON.stringify(empObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            $('#myModal').modal('hide');
            $('#EmployeeID').val("");
            $('#Name').val("");
            $('#Age').val("");
            $('#State').val("");
            $('#Country').val("");
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//function for deleting employee's record  
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
