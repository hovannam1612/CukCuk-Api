$(function () {
    new CustomerJS();
})

class CustomerJS extends BaseJS {
    constructor() {
        super();
    }

    setApiRouter() {
        this.getApiRouter = "/api/v1/customers";
    }

    /**--------------------------------------
     * Load comboBox nhóm khách hàng
     * CreatedBy: HVNAM (12/1/2021)
     * */
    loadComboBoxCustomerGroup() {
        var select = $('select#cbCustomerGroupName').empty();
        // Lấy dữ liệu nhóm khách hàng
        $.ajax({
            url: this.host + "/api/customergroups",
            method: 'GET',
        }).done(function (res) {
            if (res) {
                $.each(res, function (index, obj) {
                    var option = $(`<option value="${obj.CustomerGroupId}">${obj.CustomerGroupName}</option>`);
                    select.append(option);
                })
            }
        }).fail(function (res) {

        })
    }
}