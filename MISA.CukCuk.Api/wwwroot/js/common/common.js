/**---------------------------------------------------
 * Format dữ liệu ngày tháng năm thành ngày/tháng/năm
 * @param {any} date tham số có kiểu dữ liệu bất kỳ
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

/**
 *  Định dạng hiện thị giới tính
 * @param {any} gender giới tính (0: Nữ; 1: Nam; 2: Khác)
 * CreatedBy: HVNAM (12/12/2020)
 */
function formatGender(gender) {
    var genderName = "";
    if (gender == 2)
        genderName = "Không xác định";
    if (gender == 0)
        genderName = "Nữ";
    if (gender == 1)
        genderName = "Nam";
    return genderName;
}

/**
 * Định dạng trạng thái công việc
 * @param {int} workStatus trạng thái công việc (0: đã nghỉ việc; 1: đang làm việc)
 * CreatedBy: HVNAM (21/1/2021)
 */
function formatWorkSatus(workStatus) {
    workStatusName = "";
    if (workStatus == 0)
        workStatusName = "Đã nghỉ việc";
    else if (workStatus == 1)
        workStatusName = "Đang làm việc";
    return workStatusName;
}

/**
 * Load combobox tên chức vụ công việc
 * CreatedBy: HVNAM (21/1/2021)
 * */
function loadComboBoxPositionName() {
    var select = $('#cbPositionName').empty();
    // Lấy dữ liệu nhóm khách hàng
    $.ajax({
        url: "/api/v1/positions",
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

/**
 * Load combobox tên phòng ban
 * CreatedBy: HVNAM (21/1/2021)
 * */
function loadComboBoxDepartmentName() {
    var select = $('#cbDepartmentName').empty();
    // Lấy dữ liệu nhóm khách hàng
    $.ajax({
        url: "/api/v1/departments",
        method: 'GET',
    }).done(function (res) {
        if (res) {
            $.each(res, function (index, obj) {
                var option = $(`<option value="${obj.DepartmentId}">${obj.DepartmentName}</option>`);
                select.append(option);
            })
        }
    }).fail(function (res) {

    })
}