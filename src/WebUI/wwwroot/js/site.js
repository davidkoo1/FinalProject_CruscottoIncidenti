// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function drawPatrialView(url, divId, callback) {
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
            if (callback) callback();

        },
    });
}


function initializeIncidentDataTable() {
    var table = $('#IncidentDatatable').DataTable({
        "dom": 't',
        "processing": true,
        "serverSide": true,
        "ajax": {
            "url": "/Incident/LoadDatatable",
            "type": "POST",
            "dataType": "json"
        },
        "columns": [
            { "data": "id", "title": "id", "name": "id", "visible": false },
            { "data": "requestNr", "title": "Request Number", "name": "requestNr" },
            { "data": "subsystem", "title": "Subsystem", "name": "subsystem" },
            { "data": "openDate", "title": "Open Date", "name": "openDate" },
            { "data": "closeDate", "title": "Close Date", "name": "closeDate" },
            { "data": "type", "title": "Type", "name": "type" },
            { "data": "urgency", "title": "Urgency", "name": "urgency" }
        ],
        "columnDefs": [
            { "width": "10%", "targets": [0, 1, 2, 5, 6] }, // Установка ширины столбцов в процентах
            { "width": "15%", "targets": [3, 4] } // Установка ширины для столбцов с датами
        ],
        "scrollX": true // Включение горизонтальной прокрутки
    });

    return table;
}


//UserDataTableButton
function initializeUserDataTable() {
    var table = $('#UserDatatable').DataTable({
        "processing": true,
        "serverSide": true,
        "scrollX": true,
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
            updateButtonUserLinks(rowData.id);
            checkTableDataAndToggleActions(table);
        }
    });
    $('#IncidentDatatable tbody').on('click', 'tr', function () {
        var rowData = table.row(this).data();
        if ($(this).hasClass('selected')) {
            $(this).removeClass('selected');
            $('#actions').hide();
        } else {
            table.$('tr.selected').removeClass('selected');
            $(this).addClass('selected');
            updateButtonIncidentLinks(rowData.id);
            checkTableDataAndToggleActions(table);
        }
    });
}

function checkTableDataAndToggleActions(table) {
    if (table.rows().count() === 0) {
        $('#actions').hide();
    } else {
        $('#actions').show();
    }
}



function updateButtonUserLinks(id) {
    // Fix: Properly concatenate the id into the URL for the 'drawPatrialView' function calls
    $('#editLink').attr('onclick', `drawPatrialView('/User/GetUpsert/'+${id}, 'xlModalBody')`);
    // Removed the commented-out code for clarity and cleanliness
    $('#detailsLink').attr('onclick', `drawPatrialView('/User/Details/'+${id}, 'lgModalBody')`);
    // Fix: Correctly close the deleteUser function call with the right parenthesis
    $('#deleteLink').attr('onclick', `deleteUser(${id})`);
    // Removed the commented-out code as it seems you've moved away from using href for deletion
}
function updateButtonIncidentLinks(id) {
    var url = `../Incident/Upsert/${id}`;

    // Устанавливаем ссылку в атрибуте onclick
    $('#editLink').attr('onclick', `window.location.href = '${url}'`);

    // Removed the commented-out code for clarity and cleanliness
    $('#detailsLink').attr('onclick', `drawPatrialView('/Incident/Details/'+${id}, 'xlModalBody')`);
    // Fix: Correctly close the deleteUser function call with the right parenthesis
    $('#deleteLink').attr('onclick', `drawPatrialView('/Incident/Delete/'+${id}, 'lgModalBody')`);
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
    $.ajax({
        url: '../User/DeleteConfirmed/' + userId,//"@Url.Action("Delete", "User", new {id = 0})",
        cache: false,
        type: 'POST',
        contentType: "application/json; charset=utf-8",
        //data: JSON.stringify(userId),
        success: function (response) {
            if (response.success) {
                //$('#UserDatatable').DataTable().ajax.reload();
                toastr.error("Success", "Delete");
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
function deleteCurrentIncident(IncidentId) {
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
    $.ajax({
        url: '../Incident/DeleteConfirmed/' + IncidentId,//"@Url.Action("Delete", "User", new {id = 0})",
        cache: false,
        type: 'POST',
        contentType: "application/json; charset=utf-8",
        //data: JSON.stringify(userId),
        success: function (response) {
            if (response.success) {
                //$('#UserDatatable').DataTable().ajax.reload();
                toastr.success("Success", "Delete");
                $('#actions').hide();
                $('#IncidentDatatable').DataTable().ajax.reload(null, false); // Перезагрузите таблицу без сброса пагинации
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
                $('#actions').hide();
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

