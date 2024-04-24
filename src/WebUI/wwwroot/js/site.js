
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
                toastr.success("Success", "Import");
                $('#fileUpload').val('');
                $('#IncidentDatatable').DataTable().ajax.reload(null, false);
            } else {
                toastr.error("Error", data.message);
            }
        }
    });
}



//IncidentData
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

function initializeIncidentDataTable() {
    var table = $('#IncidentDatatable').DataTable({
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
            {
                "data": "openDate",
                "title": "Open Date",
                "name": "openDate",
                "render": function (data, type, row) {
                    return data ? new Date(data).toLocaleDateString() : ''; // Форматирование даты
                }
            },
            {
                "data": "closeDate",
                "title": "Close Date",
                "name": "closeDate",
                "render": function (data, type, row) {
                    return data ? new Date(data).toLocaleDateString() : ''; // Форматирование даты
                }
            },
            { "data": "type", "title": "Type", "name": "type" },
            { "data": "urgency", "title": "Urgency", "name": "urgency" }
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
                toastr.success("Success", "Delete");
                $('#actions').hide();
                $('#IncidentDatatable').DataTable().ajax.reload(null, false);
            } else {
                toastr.alert("SuccessError", "Delete" + response.message);
            }
        },
        error: function () {
            toastr.alert("Global error");
        }
    });
}


//UserData
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
                toastr.error("Success", "Delete");
                $('#actions').hide();
                $('#UserDatatable').DataTable().ajax.reload(null, false); 
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

