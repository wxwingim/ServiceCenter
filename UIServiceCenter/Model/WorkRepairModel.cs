using DataBase;
using Domain2;

namespace UIServiceCenter.Model
{
    public class WorkRepairModel
    {
        public WorkRepairModel(Service service, Employee employee)
        {
            this.service = service;
            this.employee = employee;
            nameService = service.nameService;
            priceService = service.priceService;
            price = money.IntMoneyToString(priceService);
            nameEmployee = employee.lastWork + " " + employee.firstWork + " " + employee.middleWork;
            guarantee = service.guarantee;
        }

        public WorkRepairModel(WorkRepair workRepair)
        {
            this.service = DataWorker.GetServiseById(workRepair.keyService);
            this.employee = DataWorker.GetEmployeeById(workRepair.idWork);
            nameService = service.nameService;
            priceService = service.priceService;
            price = money.IntMoneyToString(priceService);
            nameEmployee = employee.lastWork + " " + employee.firstWork + " " + employee.middleWork;
            guarantee = service.guarantee;
        }

        private Money money = new Money();
        public Service service { get; set; }
        public Employee employee { get; set; }
        public string nameService { get; set; }
        public int priceService { get; set; }
        public string price { get; set; }
        public string nameEmployee { get; set; }
        public int guarantee { get; set; }
    }
}
