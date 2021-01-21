$(function () {
    new EmployeeJS();
})

class EmployeeJS extends BaseJS {
    constructor() {
        super();
    }

    setApiRouter() {
        this.getApiRouter = "/api/v1/employees";
    }

    loadComboBoxPositionName() {
        var select = $('#cbPositionName').empty();
        // Lấy dữ liệu nhóm khách hàng
        $.ajax({
            url: this.host + "/api/v1/positions",
            method: 'GET',
        }).done(function (res) {
            if (res) {
                $.each(res, function (index, obj) {
                    var option = $(`<option value="${obj.PositionId}">${obj.PositionName}</option>`);
                    select.append(option);
                })
            }
        }).fail(function (res) {

        })
    }
}

