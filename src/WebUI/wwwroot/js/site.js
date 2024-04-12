// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function drawPatrialView(url, divId) {
    $.ajax({
        url: url,
        cache: false,
        type: "GET",
        dataType: "html",
        statusCode: {
            302: function (data) {
                window.location.href = '/Account/Logout/';
            },
        },
        success: function (result, e) {
            $('#' + divId).html(result);

        },
    });
}

function openModal(parameters) {
    const id = parameters.data;
    const url = parameters.url;
    const modal = $('#modal');

    if (id == undefined || url == undefined) {
        alert('Упсс...')
        return;
    }

    $.ajax(
        {
            type: 'GET',
            url: url,
            data: { Id: id },
            success: function (response) {
                $('.modal-dialog');
                modal.find(".modal-content").html(response);
                modal.modal('show')
            },
            failure: function () {
                modal.modal('hide')
            },
            error: function (response) {
                alert(response.responseText)
            }
        });
};

//UserDataTableButton
function initializeUserDataTable() {
    var table = $('#UserDatatable').DataTable({
        "processing": true,
        "serverSide": true,
        ajax: {
            "url": "/User/LoadDatatable",
            "type": "POST",
            "dataType": "json"
        },
        "columns": [
            { "data": "id", "title": "Id", "name": "id", "visible": false },
            { "data": "userName", "title": "userName", "name": "userName" },
            { "data": "email", "title": "email", "name": "email" },
            { "data": "isEnabled", "title": "isEnabled", "name": "isEnabled" }
        ]
    });

    return table;
}

function setupRowClickEvents(table) {
    $('#UserDatatable tbody').on('click', 'tr', function () {
        var rowData = table.row(this).data();
        if ($(this).hasClass('selected')) {
            $(this).removeClass('selected');
            $('#actions').hide();
        } else {
            table.$('tr.selected').removeClass('selected');
            $(this).addClass('selected');
            $('#actions').show();
            updateButtonLinks(rowData.id);
        }
    });
}


function updateButtonLinks(id) {
    // Fix: Properly concatenate the id into the URL for the 'drawPatrialView' function calls
    $('#editLink').attr('onclick', `drawPatrialView('/User/GetUpsert/'+${id}, 'xlModalBody')`);
    // Removed the commented-out code for clarity and cleanliness
    $('#detailsLink').attr('onclick', `drawPatrialView('/User/Details/'+${id}, 'lgModalBody')`);
    // Fix: Correctly close the deleteUser function call with the right parenthesis
    $('#deleteLink').attr('onclick', `deleteUser(${id})`);
    // Removed the commented-out code as it seems you've moved away from using href for deletion
}

function deleteUser(id) {
    drawPatrialView('/User/Delete/' + id, 'lgModalBody');
    //$('#deleteCurrent').on('submit', function (e) {
    //    e.preventDefault();
    //    e.stopPropagation();
    //    $.ajax({
    //        url: '/User/Delete/' + userId,
    //        type: 'POST',
    //        success: function (response) {
    //            if (response.success) {
    //                // Перезагрузка данных таблицы и закрытие модального окна
    //                $('#UserDatatable').DataTable().ajax.reload();
    //                //$('.modal').modal('hide'); // Предполагается, что вы используете Bootstrap для модальных окон
    //            } else {
    //                alert("Ошибка: " + response.message);
    //            }
    //        },
    //        error: function () {
    //            alert("Произошла ошибка при удалении.");
    //        }
    //    });
    //});



}

function deleteCurrentItem(userId) {
    toastr.options = {
        "closeButton": true,
        "debug": false,
        "newestOnTop": true,
        "progressBar": true,
        "positionClass": "toast-top-right",
        "preventDuplicates": false,
        "onclick": null,
        "showDuration": "300",
        "hideDuration": "1000",
        "timeOut": "5000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    };
    //debugger;
    $.ajax({
        url: '../User/DeleteConfirmed/' + userId,//"@Url.Action("Delete", "User", new {id = 0})",
        cache: false,
        type: 'POST',
        contentType: "application/json; charset=utf-8",
        //data: JSON.stringify(userId),
        success: function (response) {
            if (response.success) {
                //$('#UserDatatable').DataTable().ajax.reload();
                toastr.success("Success", "Delete");
                $('#actions').hide();
                $('#UserDatatable').DataTable().ajax.reload(null, false); // Перезагрузите таблицу без сброса пагинации
            } else {
                toastr.alert("SuccessError", "Delete" + response.message);
            }
        },
        error: function () {
            toastr.alert("Global error");
        }
    });
}


$(document).on('submit', '#SaveUserForm', function (e) {
    toastr.options = {
        "closeButton": true,
        "debug": false,
        "newestOnTop": true,
        "progressBar": true,
        "positionClass": "toast-top-right",
        "preventDuplicates": false,
        "onclick": null,
        "showDuration": "300",
        "hideDuration": "1000",
        "timeOut": "5000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    };
    e.preventDefault();

    //ForToastrEditOrCreate
    var CurrentIdUser = $('#UserId').val();
    var $form = $(this);

    $.ajax({
        type: $form.attr('method'),
        url: $form.attr('action'),
        data: $form.serialize(),
        success: function (response) {
            if (response.success) {

                //window.location.href = '../User/Index';

                $('#xlModal').modal('hide');
                $('#UserDatatable').DataTable().ajax.reload(null, false);
                if (CurrentIdUser === '0') {
                    toastr.success("Success", "Created");
                }
                else {
                    toastr.info("Success", "Edited");
                }

                //location.reload();
            } else {

                $('.modal-body').html(response);
                $('.selectpicker').selectpicker();
            }
        },
        error: function (xhr, status, error) {
            alert("Произошла ошибка: " + error);
        }
    });
});