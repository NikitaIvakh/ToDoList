function model() {
    const model = {
        name: $('input#Name').val(),
        model: $('input#Model').val(),
        price: $('input#Price').val(),
        description: $('input#Description').val()
    }
    return model;
};

$('#saveBtn').on('click', function () {
    $.ajax({
        url: '@Url.Action("Save")',
        type: 'POST',
        data: model(),
    })
});

var modal = $('#modal');

$(".btn-close").click(function () {
    modal.modal('hide');
});

function openModal(id) {
    $.ajax({
        type: 'GET',
        url: '/Car/GetCar',
        data: { "id": id },
        success: function (response) {
            modal.find(".modal-body").html(response);
            modal.modal('show')
        },
        failure: function () {
            modal.modal('hide')
        },
        error: function (response) {
            alert(response.responseText);
        }
    });
};

const hideCardElement = $('#hideCardsId');
const showCardElement = $('#showCardsId');
const cardElement = $('.card');

const interval = 2000;

hideCardElement.click(function () {
    hideCardElement.hide(interval);
    showCardElement.show(interval);
    cardElement.hide(interval);
});

showCardElement.click(function () {
    hideCardElement.show(interval);
    showCardElement.hide(interval);
    cardElement.show(interval);
});