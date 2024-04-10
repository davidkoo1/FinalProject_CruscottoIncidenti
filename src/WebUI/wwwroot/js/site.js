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


function deleteUser(id) {
    // This function appears correct; it dynamically sets the view for deleting a user
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
    //                $('#demoGrid').DataTable().ajax.reload();
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
    debugger;
    $.ajax({
        url: '../User/DeleteConfirmed/' + userId,//"@Url.Action("Delete", "User", new {id = 0})",
        cache: false,
        type: 'POST',
        contentType: "application/json; charset=utf-8",
        //data: JSON.stringify(userId),
        success: function (response) {
            if (response.success) {
                //$('#demoGrid').DataTable().ajax.reload();
                toastr.success("Success", "Delete");
                $('#actions').hide();
                $('#demoGrid').DataTable().ajax.reload(null, false); // Перезагрузите таблицу без сброса пагинации
            } else {
                toastr.alert("SuccessError", "Delete" + response.message);
            }
        },
        error: function () {
            toastr.alert("Global error");
        }
    });
}

