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
 * @param {any} gender
 * CreatedBy: HVNAM (12/12/2021)
 */
function formatGender(gender) {
    var genderName="";
    if (gender == 2)
        genderName = "Không xác định";
    if (gender == 0)
        genderName = "Nữ";
    if (gender == 1)
        genderName = "Nam";
    return genderName;
}