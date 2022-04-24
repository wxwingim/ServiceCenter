using DataBase;

namespace Domain2
{
    public class ServiceD : ResourceD
    {
        string name;
        int price;
        Employee employee;
        Service service;
        WorkRepair workRepair;

        public Service Service { get { return service; } }
        public Employee Employee { get { return employee; } }
        public WorkRepair WorkRepair { get { return workRepair; } }

        public ServiceD(Service service, Employee employee, WorkRepair workRepair)
        {
            this.service = service;
            this.employee = employee;
            this.workRepair = workRepair;
            price = service.priceService;
            name = service.nameService;
        }

        public int Price()
        {
            return service.priceService;
        }

    }
}
