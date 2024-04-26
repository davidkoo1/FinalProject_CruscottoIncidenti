function togglePasswordVisibility() {
    var password = document.getElementById("password");
    var checkbox = document.getElementById("showPassword");
    password.type = checkbox.checked ? 'text' : 'password';
}

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


function importFile() {
    var form = $('#importForm')[0];
    var formData = new FormData(form);
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
        url: '../Incident/Import',
        type: 'POST',
        data: formData,
        processData: false, 
        contentType: false, 
        cache: false,
        success: function (data) {
            if (data.statusCode === 200) {
                toastr.success(localizations.success);
                $('#fileUpload').val('');
                $('#IncidentDatatable').DataTable().ajax.reload(null, false);
            } else {
                toastr.error(localizations.error, data.message);
            }
        }
    });
}


function SetAmbit() {
    var selectedOriginId = $('#OriginId').val();

    $.ajax({
        url: '/Incident/GetAmbits', // Подставьте URL вашего метода
        type: 'POST',
        data: { originId: selectedOriginId },
        success: function (response) {
            // Очистите текущие опции в Ambit select
            $('#AmbitId').empty();
            $('#IncidentTypeId').empty();

            // Добавляем новые опции, полученные от сервера
            $.each(response, function (index, item) {
                $('#AmbitId').append($('<option>', {
                    value: item.value,
                    text: item.text
                }));
            });

            // Обновите selectpicker, если вы используете Bootstrap Select
            $('.selectpicker').selectpicker('refresh');
        },
        error: function (error) {
            console.error('Error:', error);
        }
    });
}

function SetIncidentType() {
    var selectedAmbitId = $('#AmbitId').val();

    $.ajax({
        url: '/Incident/GetIncidentTypes', // Подставьте URL вашего метода
        type: 'POST',
        data: { ambitId: selectedAmbitId },
        success: function (response) {
            // Очистите текущие опции в Ambit select
            $('#IncidentTypeId').empty();

            // Добавляем новые опции, полученные от сервера
            $.each(response, function (index, item) {
                $('#IncidentTypeId').append($('<option>', {
                    value: item.value,
                    text: item.text
                }));
            });

            // Обновите selectpicker, если вы используете Bootstrap Select
            $('.selectpicker').selectpicker('refresh');
        },
        error: function (error) {
            console.error('Error:', error);
        }
    });
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


//IncidentData
function initializeIncidentDataTable() {
    $('#actions').hide();
    var table = $('#IncidentDatatable').DataTable({
        "processing": true,
        "serverSide": true,
        language: {
            processing: localizations.processing,
            search: localizations.search,
            lengthMenu: localizations.lengthMenu,
            info: localizations.info,
            infoEmpty: localizations.infoEmpty,
            /*infoFiltered: localizations.infoFiltered,*/
            infoPostFix: "",
            loadingRecords: localizations.loadingRecords,
            zeroRecords: localizations.zeroRecords,
            emptyTable: localizations.emptyTable,
            paginate: {
                first: localizations.first,
                previous: localizations.previous,
                next: localizations.next,
                last: localizations.last
            }
        },
        "ajax": {
            "url": "/Incident/LoadDatatable",
            "type": "POST",
            "dataType": "json",
            "beforeSend": function () {
                $('#actions').hide(); // Скрывать actions перед AJAX запросом
            }
        },
        "columns": [
            { "data": "id", "title": "id", "name": "id", "visible": false },
            { "data": "requestNr", "title": localizations.requestNr, "name": "requestNr" },
            { "data": "subsystem", "title": localizations.subsystem, "name": "subsystem" },
            {
                "data": "openDate",
                "title": localizations.openDate,
                "name": "openDate",
                "render": function (data, type, row) {
                    return data ? new Date(data).toLocaleDateString() : ''; 
                }
            },
            {
                "data": "closeDate",
                "title": localizations.closeDate,
                "name": "closeDate",
                "render": function (data, type, row) {
                    return data ? new Date(data).toLocaleDateString() : ''; 
                }
            },
            { "data": "type", "title": localizations.type, "name": "type" },
            { "data": "urgency", "title": localizations.urgency, "name": "urgency" }
        ],
        "columnDefs": [
            { "width": "10%", "targets": [0, 1, 2, 5, 6] },
            { "width": "15%", "targets": [3, 4] }
        ],
        "scrollX": true
    });

    return table;
}

function updateButtonIncidentLinks(id) {
    var url = `../Incident/Upsert/${id}`;
    $('#editLink').attr('onclick', `window.location.href = '${url}'`);
    $('#detailsLink').attr('onclick', `drawPatrialView('/Incident/Details/'+${id}, 'xlModalBody')`);
    $('#deleteLink').attr('onclick', `drawPatrialView('/Incident/Delete/'+${id}, 'lgModalBody')`);
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
        url: '../Incident/DeleteConfirmed/' + IncidentId,
        cache: false,
        type: 'POST',
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            if (response.success) {
                toastr.success(localizations.success, localizations.delete);
                $('#actions').hide();
                $('#IncidentDatatable').DataTable().ajax.reload(null, false);
            } else {
                toastr.alert(localizations.error, "Delete" + response.message);
            }
        },
        error: function () {
            toastr.alert(localizations.error);
        }
    });
}


//UserData
function initializeUserDataTable() {
    var table = $('#UserDatatable').DataTable({
        "processing": true,
        "serverSide": true,
        "scrollX": true,
        language: {
            processing: localizations.processing,
            search: localizations.search,
            lengthMenu: localizations.lengthMenu,
            info: localizations.info,
            infoEmpty: localizations.infoEmpty,
            /*infoFiltered: localizations.infoFiltered,*/
            infoPostFix: "",
            loadingRecords: localizations.loadingRecords,
            zeroRecords: localizations.zeroRecords,
            emptyTable: localizations.emptyTable,
            paginate: {
                first: localizations.first,
                previous: localizations.previous,
                next: localizations.next,
                last: localizations.last
            }
        },
        ajax: {
            "url": "/User/LoadDatatable",
            "type": "POST",
            "dataType": "json",
            "beforeSend": function () {
                $('#actions').hide(); // Скрывать actions перед AJAX запросом
            }
        },
        "columns": [
            { "data": "id", "title": "Id", "name": "id", "visible": false },
            { "data": "userName", "title": localizations.userName, "name": "userName" },
            { "data": "email", "title": localizations.email, "name": "email" },
            { "data": "isEnabled", "title": localizations.isEnabled, "name": "isEnabled" }
        ]
    });

    return table;
}

function updateButtonUserLinks(id) {
    $('#editLink').attr('onclick', `drawPatrialView('/User/GetUpsert/'+${id}, 'xlModalBody')`);
    $('#detailsLink').attr('onclick', `drawPatrialView('/User/Details/'+${id}, 'lgModalBody')`);
    $('#deleteLink').attr('onclick', `deleteUser(${id})`);
}

function deleteUser(id) {
    drawPatrialView('/User/Delete/' + id, 'lgModalBody');
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
        url: '../User/DeleteConfirmed/' + userId,
        cache: false,
        type: 'POST',
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            if (response.success) {
                toastr.success(localizations.success, localizations.delete);
                $('#actions').hide();
                $('#UserDatatable').DataTable().ajax.reload(null, false); 
            } else {
                toastr.alert(localizations.error, "Delete" + response.message);
            }
        },
        error: function () {
            toastr.alert(localizations.error);
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
                    toastr.success(localizations.success, "Created");
                }
                else {
                    toastr.info(localizations.success, "Edited");
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

