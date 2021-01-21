$(function () {
    new EmployeeJS();
})

/**--------------------------------------
 * Class quản lý các sự kiện cho trang Employee
 * CreatedBy: HVNAM (21/1/2021)
 * */
class EmployeeJS extends BaseJS {
    constructor() {
        super();
    }

    /**
     * Gán địa chỉ router nhân viên
     * */
    setApiRouter() {
        this.getApiRouter = "/api/v1/employees";
    }
}

