$(function () {
    //Định dạng tiền khi nhập
    $('.salary-format').keyup(function () {
        $(this).val(formatAmount($(this).val()));
    });
});

/**---------------------------------------------------
 * Định dạng dữ liệu ngày tháng năm thành ngày/tháng/năm
 * @param {any} date ngày cần định dạng
 * CreatedBy: HNNam (28/12/2020) 
 */
function formatDate(date) {
    var date = new Date(date);
    if (Number.isNaN(date.getTime())) {
        return "";
    } else {
        var day = date.getDate(),
            month = date.getMonth() + 1,
            year = date.getFullYear();
        day = day < 10 ? '0' + day : day;
        month = month < 10 ? '0' + month : month;
        return day + "/" + month + "/" + year;
    }
}

/**-------------------------------------------------
 * Hàm định dạng hiện thị tiền tệ
 * @param {Number} money số tiền
 * CreatedBy: HNNam (11/11/2020)
 */
function formatMoney(money) {
    var num;
    if (money == null) {
        num = "";
    } else {
        num = money.toFixed(0).replace(/(\d)(?=(\d\d\d)+(?!\d))/g, "$1.");
    }
    return num;
}

/**----------------------------------------------
 *  Định dạng hiện thị giới tính
 * @param {any} gender giới tính (0: Nữ; 1: Nam; 2: Khác)
 * CreatedBy: HVNAM (12/12/2020)
 */
function formatGender(gender) {
    var genderName = "";
    if (gender == 0)
        genderName = "Nữ";
    if (gender == 1)
        genderName = "Nam";
    if (gender == 2)
        genderName = "Không xác định";
    return genderName;
}

/**------------------------------------------------
 * Định dạng trạng thái công việc
 * @param {int} workStatus trạng thái công việc (0: đã nghỉ việc; 1: đang làm việc)
 * CreatedBy: HVNAM (21/1/2021)
 */
function formatWorkSatus(workStatus) {
    workStatusName = "";
    if (workStatus == 0)
        workStatusName = "Đã nghỉ việc";
    if (workStatus == 1)
        workStatusName = "Đang làm việc";
    if (workStatus == 2)
        workStatusName = "Đang thử việc";
    if (workStatus == 3)
        workStatusName = "Đã nghỉ hưu";
    return workStatusName;
}

/**-------------------------------
 * Thông báo trạng thái
 * @param {any} msg Tên lỗi
 * @param {any} alert Trạng thái lỗi
 * CreatedBy: HVNAM (23/1/2021)
 */
function showMessage(msg, alert) {
    var classAlert = $('.alert-messages').find('.alert');
    var classIcon = $('.alert').find('.icon');
    //Thành công
    if (alert == "success") {
        classAlert.removeClass("alert-warning");
        classAlert.removeClass("alert-danger");
        classIcon.removeClass("fa-exclamation-triangle");
        classIcon.removeClass("fa-exclamation-circle");
        classAlert.addClass("alert-success");
        classIcon.addClass("fa-check-circle");
    }//Cảnh báo
    else if (alert == "warning") {
        classAlert.removeClass("alert-success");
        classAlert.removeClass("alert-danger");
        classAlert.addClass("alert-warning");
        classIcon.removeClass("fa-check-circle");
        classIcon.removeClass("fa-exclamation-circle");
        classIcon.addClass("fa-exclamation-triangle");
    }//Messeges Lỗi
    else if (alert == "danger") {
        classAlert.removeClass("alert-warning");
        classAlert.removeClass("alert-success");
        classIcon.removeClass("fa-check-circle");
        classIcon.removeClass("fa-exclamation-triangle");
        classAlert.addClass("alert-danger");
        classIcon.addClass("fa-exclamation-circle");
    }
    var text = $(".alert-messages").find('.alert-text');
    text.empty();
    text.append(msg);
    $(".alert-messages").show();
    $(".alert-messages").animate({ top: '600px' });
    $(".alert-messages").fadeOut(5000);
}

/**----------------------------------------
 * Định dạng tiền không có số thập phân
 * @param {any} salary số tiền
 * CreatedBy: HVNAM (24/1/2021)
 */
function formatAmountNoDecimals(salary) {
    var rgx = /(\d+)(\d{3})/;
    while (rgx.test(salary)) {
        salary = salary.replace(rgx, '$1' + '.' + '$2');
    }
    return salary;
}

/**-----------------------------------
 * Định dạng tiền khi nhập sau khi lấy được số dấu "." ngăn cách
 * @param {any} salary số tiền
 * CreatedBy: HVNAM (24/1/2021)
 */
function formatAmount(salary) {
    salary = salary.replace(/[^0-9]/g, '');
    salary = salary.replace(/\./g, ',');
    // format the amount
    x = salary.split(',');
    x1 = x[0];
    x2 = x.length > 1 ? ',' + x[1] : '';
    return formatAmountNoDecimals(x1) + x2;
}
