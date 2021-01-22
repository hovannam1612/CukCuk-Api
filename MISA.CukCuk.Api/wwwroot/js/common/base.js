/**
 * Class cha dùng chung
 * CreatedBy: HVNAM (21/1/2021)
 * */
class BaseJS {
    constructor() {
        this.host = "";
        this.getApiRouter = null;
        this.setApiRouter();
        this.loadData();
        this.initEvent();
    }

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
                me.FormMode = "Add";
                //Hiện thị dialog
                $('.m-dialog').css("display", "block");
                $('input[type="text"], input[type="email"]').val(null);
                $('.checked').prop('checked', true);
                $('.m-dialog input')[0].focus();
                $('input').removeClass('border-red');
                // Load dữ liệu cho combobox
                me.loadComboBox();
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
                    if (this.tagName == "SELECT") {
                        propertyName = $(this).attr('fieldValue');
                        entity[propertyName] = value;
                    }
                    entity[propertyName] = value;
                    
                })

                // Phân biệt phương thức thêm và sửa
                var method = "POST";
                var url = me.getApiRouter;
                if (me.FormMode == "Edit") {
                    method = "PUT";
                    url = me.getApiRouter + `/${me.recordId}`;
                    entity.EmployeeId = me.recordId;
                }

                // Gọi service tương ứng thực hiện lưu dữ liệu
                $.ajax({
                    url: url,
                    method: method,
                    data: JSON.stringify(entity),
                    contentType: 'application/json',
                }).done(function (res) {
                    var inputNotValids = $('input[validate="false"]');
                    if (inputNotValids && inputNotValids.length > 0) {
                        // Focus vào input đang bị trống hoặc sai dữ liệu
                        inputNotValids[0].focus();
                        var msg = JSON.parse(res.responseText);
                        alert(msg.Data);
                    }
                    else {
                        if (method == "POST")
                            alert("Thêm thành công");
                        alert("Sửa thành công");
                    }
                    //ẩn form và load lại dữ liệu
                    $('.m-dialog').css("display", "none");
                    me.loadData();
                }).fail(function (res) {
                    var msg = JSON.parse(res.responseText);
                    alert(msg.Data);

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
            me.FormMode = 'Edit';
            $('input').removeClass('border-red');

            // load dữ liệu cho các combobox
            me.loadComboBox();

            //Bind dữ liệu từ table lên dialog
            // Lấy khóa chính của bản ghi
            var recordId = $(this).data('recordId');
            me.recordId = recordId;
            // Gọi service lấy thông tin chi tiết qua Id
            $.ajax({
                url: me.host + me.getApiRouter + `/${recordId}`,
                method: "GET",
                async: true
            }).done(function (res) {
                // Binding dữ liệu lên form chi tiết
                // Lấy tất cả các control nhập liệu
                var inputs = $('input[fieldName], select[fieldName]');
                $.each(inputs, function (index, input) {
                    var propertyName = $(this).attr('fieldName');
                    var value = res[propertyName];

                    // Đối với dropdowlist (select option):
                    if (this.tagName == "SELECT") {
                        var propValueName = $(this).attr('fieldValue');
                        value = res[propValueName];
                    }
                    // Đối với các input là radio:
                    if ($(this).attr('type') == "radio") {
                        var inputValue = this.value;

                        if (value == inputValue) {
                            this.checked = true;
                        } else {
                            this.checked = false;
                        }
                    }
                    // Đối với các input là date:
                    if ($(this).attr('type') == "date") {
                        var date = new Date(value);
                        var day = date.getDate();
                        var month = date.getMonth() + 1;
                        var year = date.getFullYear();
                        day = day < 10 ? '0' + day : day;
                        month = month < 10 ? '0' + month : month;
                        value = year + "-" + month + "-" + day;
                    }
                    $(this).val(value);
                })
            }).fail(function (res) {

            })

            $('.m-dialog').css("display", "block");
        })
        /*
                $("input[type=date]").on("change", function () {
                    this.setAttribute(
                        "data-date",
                        moment(this.value, "YYYY-MM-DD").format(this.getAttribute("data-date-format"))
                    )
                }).trigger("change")*/

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

        /**-------------------------------
         * Xóa một bản ghi
         * CreatedBy: HVNAM (21/1/2021)
         **/
        $('#btnDelete').click(function () {
            var entityId = me.recordId;
            var url = me.getApiRouter + `/${entityId}`;
            $.ajax({
                url: url,
                method: "DELETE",
                contentType: 'application/json'
            }).done(function (res) {
                //Đưa ra thông báo
                if (res) {
                    alert("Xóa thành công");
                    alert(res);
                }
                //Ẩn dialog và load lại dữ liệu table
                $('.m-dialog').css("display", "none");
                me.loadData();
            }).fail(function (res) {
                alert("xóa thất bại");
            })
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
            $('.loading').show();
            $.ajax({
                url: me.host + me.getApiRouter,
                method: "GET",
            }).done(function (res) {

                //Lấy thông tin từ các cột dữ liệu
                $.each(res, function (index, obj) {
                    var tr = $(`<tr></tr>`);
                    //Gán id bản ghi khi click
                    $(tr).data('recordId', obj.EmployeeId);
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
                $('.loading').hide();
            }).fail(function (res) {
                $('.loading').hide();
            })
        } catch (e) {
            console.log(e);
        }
    }

    /**-----------------------------------------
     * Load dữ liệu các combobox
     * CreatedBy: HVNAM (21/1/2021)
     * */
    loadComboBox() {
        var selects = $('select[fieldName]');
        selects.empty();
        $.each(selects, function (index, select) {
            //Lấy dữ liệu combobox
            var api = $(select).attr('api');
            var fieldName = $(select).attr('fieldName');
            var fieldValue = $(select).attr('fieldValue');
            $('.loading').show();
            //Gọi api get dữ liệu từ service
            $.ajax({
                url: api,
                method: "GET",
                async: true
            }).done(function (res) {
                if (res) {
                    $.each(res, function (index, obj) {
                        var option = $(`<option value="${obj[fieldValue]}">${obj[fieldName]}</option>`);
                        $(select).append(option);
                    })
                }
                $('.loading').hide();
            }).fail(function () {
                $('.loading').hide();
            })
        })
    }
}
