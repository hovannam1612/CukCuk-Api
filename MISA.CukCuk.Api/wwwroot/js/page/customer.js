$(function () {
    new CustomerJS();
})
/**----------------------------------
 * Class quản lý các sự kiện cho trang Customer
 * CreatedBy: HVNAM (21/1/2021)
 * */
class CustomerJS extends BaseJS {
    constructor() {
        super();
    }

    /**
     * Gán địa chỉ router khách hàng
     * */
    setApiRouter() {
        this.getApiRouter = "/api/v1/customers";
    }
}