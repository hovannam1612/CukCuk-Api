
class BaseJS {
    constructor() {
        this.host = "";
        this.getApiRouter = null;
        this.setApiRouter();
        this.loadData();
        this.initEvent();
    }

    /**---------------------------------
    * Gán Url api
    * CreatedBy: HVNam (28/12/2020)
    * */
    setApiRouter() {

    }

    /**------------------------------------
     * Khởi tạo các sự kiện 
     * CreatedBy: HNNam (31/12/2020)
     * */
    initEvent() {
        var me = this;
        /**-------------------------------------
         * Sự kiện khi nhấn button thêm mới
         * CreatedBy: HVNAM (31/12/2020)
         */
        $('#btnAdd').click(function () {
            try {
                //Hiện thị dialog
                $('.m-dialog').css("display", "block");
                $('input[type="text"], input[type="email"]').val(null);
                $('.checked').prop('checked', true);
                $('.m-dialog input')[0].focus();

                // Load dữ liệu cho combobox
                if (me.getApiRouter == "/api/v1/customers") {
                }
                if (me.getApiRouter == "/api/v1/employees") {
                    loadComboBoxPositionName();
                    loadComboBoxDepartmentName();
                }
            } catch (e) {
                console.log(e);
            }
        })

        /**---------------------------------------
         * Sự kiện click khi nhấn Close -> form sẽ ẩn đi
         * CreatedBy: HVNAM (31/12/2020)
         */
        $('#btnClose').click(function () {
            $('.m-dialog').css("display", "none");
        })

        /**------------------------------------------
        * Sự kiện click khi nhấn button nạp dữ liệu
        * CreatedBy: HVNAM (31/12/2020)
        */
        $('#btnRefresh').click(function () {
            me.loadData();
        })

        /**------------------------------------------
        * Thực hiện lưu dữ liệu khi nhấn button [Lưu] trên form chi tiết
        * CreatedBy: HVNAM (31/12/2020)
        */
        $('#btnSave').click(function () {
            try {
                // validate dữ liệu
                var inputValidates = $('.input-required, input[type="email"]');
                $.each(inputValidates, function (index, item) {
                    $(item).trigger('blur');
                })
                var inputNotValids = $('input[validate="false"]');
                if (inputNotValids && inputNotValids.length > 0) {
                    alert('Dữ liệu không hợp lệ vui lòng kiểm tra lại');
                    // Focus vào input đang bị trống hoặc sai dữ liệu
                    inputNotValids[0].focus();
                    return;
                }
                //Lấy tất cả các control nhập liệu
                var inputs = $('input[fieldName], select[fieldName]');
                var entity = {};
                $.each(inputs, function (index, input) {
                    var propertyName = $(this).attr('fieldName');
                    var value = $(this).val();
                    // Check với trường hợp input là radio thì chỉ lấy value của input có attribute là checked
                    if ($(this).attr('type') == "radio") {
                        if (this.checked) {
                            entity[propertyName] = value;
                        }
                    }
                    else
                        entity[propertyName] = value;
                })
                // Gọi service tương ứng thực hiện lưu dữ liệu
                $.ajax({
                    url: me.host + me.getApiRouter,
                    method: 'POST',
                    data: JSON.stringify(entity),
                    contentType: 'application/json',
                }).done(function (res) {
                    // Đưa ra thông báo - ẩn form - load lại dữ liệu
                    alert('Thêm thành công');
                    $('.m-dialog').css("display", "none");
                    me.loadData();
                }).fail(function (res) {
                })
            } catch (e) {
                console.log(e);
            }
        })

        /**---------------------------------------
        * Sự kiện click khi nhấn button [Hủy]
        * CreatedBy: HVNam (12/1/2021)
        * */
        $('#btnCancel').click(function () {
            $('.m-dialog').css("display", "none");
        })

        /**---------------------------------------
        * Hiện thị thông tin khi nhấn đúp chuột vào 1 bản ghi trên danh sách
        * CreatedBy: HVNam (12/1/2021)
        * */
        $('table tbody').on('dblclick', 'tr', function () {
            //Nếu đang thao tác với trang nào thì thực hiện load combobox tương ứng của trang đó
            if (me.getApiRouter == "/api/customers") {
                loadComboBoxCustomerGroup();
            }
            $('.m-dialog').css("display", "block");
            $('input[type="text"], input[type="email"]').val(null);
            $('.checked').prop('checked', true);
            $('.m-dialog input')[0].focus();
        })

        /**---------------------------------------
        * Validate bắt buộc nhập
        * CreatedBy: HVNam (29/12/2020)
        * */
        $('.input-required').blur(function () {
            var value = $(this).val();
            if (!value) {
                $(this).addClass('border-red');
                $(this).attr('title', 'Trường này không để trống');
                $(this).attr('validate', false);

            } else {
                $(this).removeClass('border-red');
                $(this).attr('validate', true);
            }

        })

        /**---------------------------------------
        * Validate nhập đúng định dạng email
        * CreatedBy: HVNam (29/12/2020)
        * */
        $('input[type="email"]').blur(function () {
            var value = $(this).val();
            var regex = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
            if (!regex.test(value)) {
                $(this).addClass('border-red')
                $(this).attr('title', 'Email không hợp lệ');
                $(this).attr('validate', false);
            } else {
                $(this).removeClass('border-red');
                $(this).attr('validate', true);
            }
        })
    }

    /**---------------------------------
    * Load dữ liệu khách hàng
    * CreatedBy: HVNAM (28/12/2020)
    * */
    loadData() {
        var me = this;
        try {
            var tbody = $('table tbody').empty();
            var ths = $(`table thead th`);
            $.ajax({
                url: me.host + me.getApiRouter,
                method: "GET",
            }).done(function (res) {
                //Lấy thông tin từ các cột dữ liệu
                $.each(res, function (index, obj) {
                    var tr = $(`<tr></tr>`);
                    //Lấy thông tin dữ liệu map với các thuộc tính fieldName
                    $.each(ths, function (index, th) {
                        var td = $(`<td></td>`);
                        var fieldName = $(th).attr('fieldName');
                        var value = obj[fieldName];
                        var formatType = $(th).attr('formatType');
                        switch (formatType) {
                            case "ddmmyyyy":
                                $(th).addClass("text-align-center");
                                td.addClass("text-align-center");
                                value = formatDate(value);
                                break;
                            case "Money":
                                $(th).addClass("text-align-right");
                                td.addClass("text-align-right");
                                value = formatMoney(value);
                                break;
                            case "Gender":
                                value = formatGender(value);
                                break;
                            case "WorkStatus":
                                value = formatWorkSatus(value);
                                break;
                            default:
                                break;
                        }
                        td.append(value);
                        tr.append(td);
                    })
                    $(tbody).append(tr);
                })

            }).fail(function (res) {

            })
        } catch (e) {
            console.log(e);
        }
    }
}
