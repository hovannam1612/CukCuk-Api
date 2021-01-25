/**----------------------------------
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

    /**------------------------------
     * Gán api router của từng trang
     * CreatedBy: HVNAM (21/1/2021)
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

            //Ẩn btn Xóa
            $('#btnDelete').hide();
            $('#btnSave').addClass('e-margin-left-btn');
            me.FormMode = "Add";
            //Hiện thị dialog
            $('.m-dialog').css("display", "block");
            $('input[type="text"], input[type="email"]').val(null);
            $("input[type=date]").val("");
            $('.checked').prop('checked', true);
            $('.m-dialog input')[0].focus();
            $('input').removeClass('border-red');

            try {
                //Lấy mã nhân viên lớn nhất
                $.ajax({
                    url: me.getApiRouter + "/maxemployeecode",
                    method: "GET",
                    async: true
                }).done(function (res) {
                    if (res) {
                        $.each(res, function (index, obj) {
                            var maxCode = obj + 1;
                            var empMaxCode = "NV" + maxCode;
                            $('input[fieldName=EmployeeCode]').val(empMaxCode);
                        })
                    }
                }).fail(function () {
                })
                // Load dữ liệu cho combobox
                me.loadComboBox();
            } catch (e) {
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
                    // Trường hợp input là radio thì chỉ lấy value của input có attribute là checked
                    if ($(this).attr('type') == "radio") {
                        if (this.checked) {
                            entity[propertyName] = value;
                        }
                    }
                    // Với các select gán propertyName bằng fieldValue
                    if (this.tagName == "SELECT") {
                        propertyName = $(this).attr('fieldValue');
                        entity[propertyName] = value;
                    }
                    // Với input là lương thì loại bỏ dấu "."
                    if ($(this).attr('fieldName') == "Salary") {
                        value = value.replace(/\./g, "");
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
                    //convert dữ liệu json trả về
                    var msg = JSON.parse(JSON.stringify(res));
                    if (msg.Data > 0) {
                        var alert = "success";
                        // Đưa ra thông báo thành công
                        showMessage(msg.Messeger, alert);
                    }
                    //ẩn form và load lại dữ liệu
                    $('.m-dialog').css("display", "none");
                    me.loadData();
                }).fail(function (res) {
                    var alert = "danger";
                    var msg = JSON.parse(res.responseText);
                    //Nếu có lỗi xảy ra
                    if (msg.Data.length > 0)
                        showMessage(msg.Data[0], alert);
                    else {
                        showMessage(msg.Messeger, alert);
                    }
                    var inputNotValids = $('input[validate="false"]');
                    if (inputNotValids && inputNotValids.length > 0) {
                        inputNotValids[0].focus();
                    }

                })
            } catch (e) {

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
            //Show button Xóa
            $('#btnDelete').show();
            $('#btnSave').removeClass('e-margin-left-btn');
            $('input').removeClass('border-red');
            try {
                // load dữ liệu cho các combobox
                me.loadComboBox();

                // Lấy khóa chính của bản ghi
                var recordId = $(this).data('recordId');
                me.recordId = recordId;
                // Gọi service lấy thông tin chi tiết qua Id
                $.ajax({
                    url: me.host + me.getApiRouter + `/${recordId}`,
                    method: "GET",
                    async: true
                }).done(function (res) {
                    // Lấy tất cả các control nhập liệu và Binding dữ liệu
                    var inputs = $('input[fieldName], select[fieldName]');
                    $.each(inputs, function (index, input) {
                        var propertyName = $(this).attr('fieldName');
                        var value = res[propertyName];
                        // Đối với các input là radio:
                        if ($(this).attr('type') == "radio") {
                            var inputValue = this.value;
                            if (value == inputValue) {
                                this.checked = true;
                            } else {
                                this.checked = false;
                            }
                        }
                        //Đối với input là date:
                        if ($(this).attr('type') == "date") {
                            var date = new Date(value);
                            var day = date.getDate();
                            var month = date.getMonth() + 1;
                            var year = date.getFullYear();
                            day = day < 10 ? '0' + day : day;
                            month = month < 10 ? '0' + month : month;
                            value = year + "-" + month + "-" + day;
                        }
                        //Đối với input là lương
                        if ($(this).attr('fieldName') == "Salary") {
                            value = formatMoney(value);
                        }
                        // Đối với dropdowlist (select option):
                        if (this.tagName == "SELECT") {
                            var propValueName = $(this).attr('fieldValue');
                            value = res[propValueName];
                        }
                        $(this).val(value);
                    })

                }).fail(function (res) {

                })
            } catch (e) {

            }
            $('.m-dialog').css("display", "block");
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

        /**-------------------------------
         * Xóa một bản ghi
         * CreatedBy: HVNAM (21/1/2021)
         **/
        $('#btnDelete').click(function () {
            $('.m-popup').show();
        })

        /**-------------------------------------
         * Sự kiện Click button Xóa để xác nhận xóa
         * CreatedBy: HVNAM (24/1/2021)
         */
        $('#btnPopDelete').click(function () {
            var entityId = me.recordId;
            var url = me.getApiRouter + `/${entityId}`;
            try {
                $.ajax({
                    url: url,
                    method: "DELETE",
                    contentType: 'application/json'
                }).done(function (res) {
                    //Đưa ra thông báo
                    if (res) {
                        var alert = "success";
                        var msg = JSON.parse(JSON.stringify(res));
                        if (msg.Data > 0)
                            showMessage(msg.Messeger, alert);
                    }
                    //Ẩn dialog và load lại dữ liệu table
                    $('.m-dialog').css("display", "none");
                    $('.m-popup').hide();
                    me.loadData();
                }).fail(function (res) {
                    var alert = "danger";
                    var msg = JSON.parse(res.responseText);
                    showMessage(msg.Messeger, alert);
                })
            } catch (e) {

            }
        })

        /**-------------------------------------
         * Đóng Pop-up xác nhận xóa
         * CreatedBy: HVNAM(24/1/2021)
         */
        $('#btnPopClose,#btnPopCancel').click(function () {
            $('.m-popup').hide();
        })
    }

    /**---------------------------------
    * Load dữ liệu khách hàng
    * CreatedBy: HVNAM (28/12/2020)
    * */
    loadData() {
        var me = this;
        try {
            me.loadComboBox();
            $('.loading').show();
            var tbody = $('table tbody').empty();
            var ths = $(`table thead th`);
            $.ajax({
                url: me.getApiRouter,
                method: "GET",
            }).done(function (res) {

                //Lấy thông tin từ các cột dữ liệu
                $.each(res, function (index, obj) {
                    var tr = $(`<tr></tr>`);

                    //Lấy id bản ghi và truyền vào recordId
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
            //Gọi api get dữ liệu từ service
            $.ajax({
                url: api,
                method: "GET",
                async: false
            }).done(function (res) {
                if (res) {
                    $.each(res, function (index, obj) {
                        var option = $(`<option value="${obj[fieldValue]}">${obj[fieldName]}</option>`);
                        $(select).append(option);
                    })
                }
            }).fail(function () {
            })
        })
    }
}
