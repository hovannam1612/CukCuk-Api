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
}