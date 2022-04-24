using DataBase;
using Domain2;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UIServiceCenter.Model
{
    public static class DataWorker
    {
        // создать сотрудника
        public static string CreateEmployee(string lname, string fname, string mname, string phone, string mail, string position)
        {
            string result = "";

            using (ApplicationContext db = new ApplicationContext())
            {
                Employee employee = new Employee { lastWork = lname, firstWork = fname, middleWork = mname, phoneWork = phone, mailWork = mail, position = position };
                db.Employees.Add(employee);
                db.SaveChanges();
            }

            return result;
        }

        // получить всех сотрудников
        public static List<Employee> GetAllEmployees()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Employees.ToList();
                return result;
            }
        }

        // создать клиента
        public static void CreateCustomer(string lname, string fname, string mname, string phone, string mail)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Customer customer = new Customer { lastCustom = lname, firstCustom = fname, middleCustom = mname, telCustom = phone, mailCustom = mail };
                db.Customers.Add(customer);
                db.SaveChanges();
            }
        }


        // редактировать клиента
        public static void EditCustomer(Customer oldCustomer, string newLastName, string newFirstName, string newMiddleName, string newPhone, string newEmail)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Customer customer = db.Customers.FirstOrDefault(d => d.idCustom == oldCustomer.idCustom);
                customer.lastCustom = newLastName;
                customer.firstCustom = newFirstName;
                customer.middleCustom = newMiddleName;
                customer.telCustom = newPhone;
                customer.mailCustom = newEmail;
                db.SaveChanges();
            }
        }

        public static void EditOrder(WorkOrder order)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                WorkOrder oldOrder = db.Work_Orders.First(d => d.numOrder == order.numOrder);
                oldOrder.statusPaymnt = order.statusPaymnt;
                oldOrder.StatusId = order.StatusId;
                oldOrder.dateDelivery = order.dateDelivery;
                oldOrder.statusDelivery = order.statusDelivery;
                db.SaveChanges();
            }
        }

        // редактировать заказ
        public static void EditOrder(int numOrder, int IdType, string Model, string Defect, string Equipment, string MechanicalDamage, int statusRepair, bool statusPayment, bool statusDelivery)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                WorkOrder oldWorkOrder = db.Work_Orders.First(d => d.numOrder == numOrder);
                AdmissionForRepair oldAdmission = db.Admission_For_Repairs.First(d => d.num_admission == oldWorkOrder.num_admission);
                CustomerDevice oldCustomerDevice = db.Customer_Devices.First(d => d.idCustDev == oldAdmission.idCustDev);
                StatusRepair oldStatusRepair = db.StatusRepairs.First(d => d.StatusId == oldWorkOrder.StatusId);
                DeviceType oldDeviceType = db.Device_types.First(d => d.typeId == oldCustomerDevice.typeId);

                oldCustomerDevice.typeId = IdType;
                oldCustomerDevice.model = Model;
                oldCustomerDevice.defect = Defect;
                oldCustomerDevice.equipment = Equipment;
                oldCustomerDevice.mechanicalDamage = MechanicalDamage;
                oldWorkOrder.StatusId = statusRepair;
                oldWorkOrder.statusPaymnt = statusPayment;
                oldWorkOrder.statusDelivery = statusDelivery;

                db.SaveChanges();
            }
        }


        // получить всех клиентов
        public static List<Customer> GetAllCustomers()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Customers.ToList();
                return result;
            }
        }

        // получить все заказы
        public static List<OrderModel> GetAllOrders()
        {
            List<OrderModel> result = new List<OrderModel>();
            List<WorkOrder> work_Orders = GetAllOrdersSmall();
            foreach (WorkOrder order in work_Orders)
            {
                result.Add(new OrderModel(order));
            }
            return result;
        }

        public static List<WorkOrder> GetAllOrdersSmall()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Work_Orders.ToList();
                return result;
            }
        }

        // получить все запчасти
        public static List<StorageModel> GetStorage()
        {
            List<StorageModel> result = new List<StorageModel>();
            List<Purchase> purchases = GetAllPurchase();
            foreach (Purchase purchase in purchases)
            {
                result.Add(new StorageModel(purchase));
            }
            return result;
        }

        public static List<StorageModel> GetStorage(List<Purchase> purchases)
        {
            List<StorageModel> result = new List<StorageModel>();
            foreach (Purchase purchase in purchases)
            {
                result.Add(new StorageModel(purchase));
            }
            return result;
        }

        // получить все запчасти определенного типа
        public static List<StorageModel> GetStorage(TypeSparePart type)
        {
            List<StorageModel> allSpareParts = GetStorage();
            List<StorageModel> result = new List<StorageModel>();
            foreach (StorageModel sparePart in allSpareParts)
            {
                if (sparePart.typeSparePart == type.name)
                {
                    result.Add(sparePart);
                }
            }
            return result;
        }

        // получить все поставки
        public static List<Purchase> GetAllPurchase()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Purchases.ToList();
                return result;
            }
        }

        // все запчасти
        public static List<SparePart> GetAllSpareParts()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.SpareParts.ToList();
                return result;
            }
        }

        // получить поставку по id
        public static Purchase GetPurchaseById(int idSpare)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Purchases.First(d => d.idSpare == idSpare);
                return result;
            }
        }

        // получить SparePart
        public static SparePart GetSparePartById(int idSpare)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.SpareParts.First(d => d.idSpare == idSpare);
                return result;
            }
        }

        // получить TypeSparePart
        public static TypeSparePart GetTypeSparePartById(int IdTypeSP)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.TypeSpareParts.First(d => d.IdTypeSP == IdTypeSP);
                return result;
            }
        }

        // получить все заказы одного клиента
        public static List<OrderModel> GetAllOrdersByIdCustomer(int id)
        {
            List<OrderModel> result = new List<OrderModel>();
            List<WorkOrder> work_Orders = GetAllOrdersSmall();
            foreach (WorkOrder order in work_Orders)
            {
                if (GetCustomer_device(GetAdmission_For_Repair(order.num_admission).idCustDev).idCustom == id)
                {
                    result.Add(new OrderModel(order));
                }
            }
            return result;
        }

        public static List<OrderModel> GetAllOrdersByStatusRepair(int idStatus)
        {
            List<OrderModel> result = new List<OrderModel>();
            List<WorkOrder> workOrders = GetAllOrdersSmall();
            foreach (WorkOrder order in workOrders)
            {
                if (order.StatusId == idStatus)
                {
                    result.Add(new OrderModel(order));
                }
            }
            return result;
        }

        // получить AdmissionForRepair по id
        public static AdmissionForRepair GetAdmission_For_Repair(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                AdmissionForRepair admission = db.Admission_For_Repairs.FirstOrDefault(p => p.num_admission == id);
                return admission;
            }
        }

        // получить CustomerDevice по id
        public static CustomerDevice GetCustomer_device(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                CustomerDevice customerDevice = db.Customer_Devices.FirstOrDefault(p => p.idCustDev == id);
                return customerDevice;
            }
        }

        // получить Device_type по id
        public static DeviceType GetDevice_type(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                DeviceType devicType = db.Device_types.FirstOrDefault(p => p.typeId == id);
                return devicType;
            }
        }

        // получить Customer по id
        public static Customer GetCustomerById(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Customer customer = db.Customers.First(p => p.idCustom == id);
                return customer;
            }
        }

        // получить idCustom по телефону
        public static int GetCustomerId(string phone)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Customer customer = db.Customers.FirstOrDefault(p => p.telCustom == phone);
                return customer.idCustom;
            }
        }

        // получить typeId по type
        public static int GetTypeId(string type)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                DeviceType deviceType = db.Device_types.FirstOrDefault(p => p.nameType == type);
                return deviceType.typeId;
            }
        }

        // получить WorkOrder по id
        public static WorkOrder GetWorkOrderById(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                WorkOrder workOrder = db.Work_Orders.First(p => p.numOrder == id);
                return workOrder;
            }
        }

        // получить последний созданный IdCustDev
        public static int GetLastIdCustDev()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                List<CustomerDevice> customerDevices = db.Customer_Devices.ToList();
                return customerDevices.Last().idCustDev;
            }
        }

        // получить последний созданный num_admission
        public static int GetLastNumAdmission()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                List<AdmissionForRepair> admissions = db.Admission_For_Repairs.ToList();
                return admissions.Last().num_admission;
            }
        }

        // получить все Device_type
        public static List<DeviceType> GetAllDeviceTypes()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Device_types.ToList();
                return result;
            }
        }

        // создать устройство клиента
        public static void CreateCustomerDevice(string Model, string PhoneCustom, string Type, string Defect, string Equipment, string MechanicalDamage)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                CustomerDevice customerDevice = new CustomerDevice
                {
                    defect = Defect,
                    model = Model,
                    equipment = Equipment,
                    mechanicalDamage = MechanicalDamage,
                    idCustom = GetCustomerId(PhoneCustom),
                    typeId = GetTypeId(Type)
                };
                db.Customer_Devices.Add(customerDevice);
                db.SaveChanges();
            }
        }

        // создать поступление детали
        public static void CreateSparePart(PurchaseModel sparePart)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                SparePart spareP = new SparePart
                {
                    nameSpare = sparePart.nameSpare,
                    priceSpare = sparePart.price,
                    IdTypeSP = sparePart.type.IdTypeSP
                };
                db.SpareParts.Add(spareP);
                db.SaveChanges();
            }
        }

        public static SparePart GetLastSparePart()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                List<SparePart> spareParts = db.SpareParts.ToList();
                return spareParts.Last();
            }
        }

        public static List<StorageModel> ConsumptionToStoragModel(List<ConsumptionD> consumptions)
        {
            List<StorageModel> result = new List<StorageModel>();
            foreach (ConsumptionD consumption in consumptions)
            {
                result.Add(new StorageModel(consumption.Consumption));
            }
            return result;
        }

        public static List<WorkRepairModel> ServiceToWorkRepairModel(List<ServiceD> services)
        {
            List<WorkRepairModel> result = new List<WorkRepairModel>();
            foreach (ServiceD sv in services)
            {
                result.Add(new WorkRepairModel(sv.Service, sv.Employee));
            }
            return result;
        }

        // получить услугу по id
        public static Service GetServiseById(int idService)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Services.First(x => x.keyService == idService);
                return result;
            }
        }

        // получить сотрудника по id
        public static Employee GetEmployeeById(int idWork)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Employees.First(x => x.idWork == idWork);
                return result;
            }
        }

        // создать расход
        public static void CreateConsumption(int amount, int idSpare, int numOrder)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Consumption consumption = new Consumption
                {
                    amount = amount,
                    idSpare = idSpare,
                    numOrder = numOrder
                };

                Purchase oldPurchase = db.Purchases.First(x => x.idSpare == idSpare);
                oldPurchase.amount -= amount;
                db.Cunsumptions.Add(consumption);
                db.SaveChanges();

            }
        }

        // получить поставку по запчасти
        public static Purchase GetPurchaseBySpare(int idSpare)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Purchases.First(x => x.idSpare == idSpare);
                return result;
            }
        }

        // создать работу по ремонту
        public static void CreateWorkRepair(int nOrder, int kService, int idW)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                WorkRepair workRepair = new WorkRepair
                {
                    dateReady = DateTime.Now,
                    numOrder = nOrder,
                    keyService = kService,
                    idWork = idW
                };
                db.Work_Repairs.Add(workRepair);
                db.SaveChanges();
            }
        }

        public static List<ResourceD> GetResourceDByNumOrder(int numOrder)
        {
            List<Consumption> consumptions = GetConsumptionByNumOrder(numOrder);
            List<WorkRepair> workRepairs = GetWorkRepairsByNumOrder(numOrder);
            List<ResourceD> result = new List<ResourceD>();
            foreach (Consumption consumption in consumptions)
            {
                result.Add(new ConsumptionD(GetSparePartById(consumption.idSpare), consumption.amount, consumption));
            }
            foreach (WorkRepair workRepair in workRepairs)
            {
                result.Add(new ServiceD(GetServiseById(workRepair.keyService), GetEmployeeById(workRepair.idWork), workRepair));
            }
            return result;
        }

        // получить услуги определеного заказа
        public static List<WorkRepair> GetWorkRepairsByNumOrder(int numOrder)
        {
            var result = GetAllWorkRepairs().Where(x => x.numOrder == numOrder).ToList();
            return result;
        }

        // получить storageModel определенного заказа
        public static List<StorageModel> GetStorageModelsByNumOrder(int numOrder)
        {
            List<StorageModel> result = new List<StorageModel>();
            List<Consumption> consumptions = GetConsumptionByNumOrder(numOrder);
            foreach (Consumption consumption in consumptions)
            {
                result.Add(new StorageModel(consumption));
            }
            return result;
        }

        // получить WorkRepairModel определенного заказа
        public static List<WorkRepairModel> GetWorkRepairModelsByNumOrder(int numOrder)
        {
            List<WorkRepairModel> result = new List<WorkRepairModel>();
            List<WorkRepair> workRepairs = GetWorkRepairsByNumOrder(numOrder);
            foreach (WorkRepair workRepair in workRepairs)
            {
                result.Add(new WorkRepairModel(workRepair));
            }
            return result;
        }

        // получить все работы по ремонту 
        public static List<WorkRepair> GetAllWorkRepairs()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Work_Repairs.ToList();
                return result;
            }
        }

        // получить расходы запчастей определенного заказа
        public static List<Consumption> GetConsumptionByNumOrder(int numOrder)
        {
            var result = GetAllConsumptions().Where(x => x.numOrder == numOrder).ToList();
            return result;
        }

        public static Consumption GetConsumptionByNumOrderSparePart(int numOrder, int keySpare)
        {
            var list = GetConsumptionByNumOrder(numOrder);
            Consumption result = (Consumption)list.Where(x => x.idSpare == keySpare);
            return result;
        }

        // получит все расходы
        public static List<Consumption> GetAllConsumptions()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Cunsumptions.ToList();
                return result;
            }
        }

        public static void CreatePurchase(PurchaseModel storageModel)
        {
            CreateSparePart(storageModel);
            using (ApplicationContext db = new ApplicationContext())
            {
                Purchase purchase = new Purchase
                {
                    amount = storageModel.amount,
                    idSpare = GetLastSparePart().idSpare,
                    datePurchase = DateTime.Now
                };
                db.Purchases.Add(purchase);
                db.SaveChanges();
            }
        }

        // создать поступление в ремонт
        public static void CreateAdmissionForRepair(bool Quarantee, DateTime DateAdmission, DateTime DateLimit)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                AdmissionForRepair admission_For_Repair = new AdmissionForRepair
                {
                    idCustDev = GetLastIdCustDev(),
                    quarantee = Quarantee,
                    date_admission = DateAdmission,
                    date_limit = DateLimit
                };
                db.Admission_For_Repairs.Add(admission_For_Repair);
                db.SaveChanges();
            }
        }

        // создать заказ
        public static void CreateWorkOrder(string customerPhone, DateTime dateAdmission, DateTime dateLimit, bool quarantee, string typeDevice, string model, string defect, string equipment, string mechanicalDamage)
        {
            CreateCustomerDevice(model, customerPhone, typeDevice, defect, equipment, mechanicalDamage);
            CreateAdmissionForRepair(quarantee, dateAdmission, dateLimit);
            using (ApplicationContext db = new ApplicationContext())
            {
                WorkOrder work_order = new WorkOrder
                {
                    num_admission = GetLastNumAdmission(),
                    statusDelivery = false,
                    statusPaymnt = false,
                    StatusId = GetStatusRepair("Принят в ремонт").StatusId,
                };
                db.Work_Orders.Add(work_order);
                db.SaveChanges();
            }
        }

        // получить все типы запчастей
        public static List<TypeSparePart> GetAllTypeSP()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.TypeSpareParts.ToList();
                return result;
            }
        }

        public static List<TypeSparePart> GetAllTypeSPWithAll()
        {
            List<TypeSparePart> result = new List<TypeSparePart>();
            result.Add(new TypeSparePart { IdTypeSP = -1, name = "Все" });
            result.AddRange(GetAllTypeSP());
            return result;
        }

        public static List<StatusRepair> GetStatusRepairsWithAll()
        {
            List<StatusRepair> result = new List<StatusRepair>();
            result.Add(new StatusRepair { StatusId = -1, StatusName = "Все" });
            result.AddRange(GetAllStatusRepair());
            return result;
        }

        // получить все услуги
        public static List<Service> GetAllServices()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Services.ToList();
                return result;
            }
        }

        public static List<Service> GetAllServicesPlus()
        {
            List<Service> result = GetAllServices();
            foreach (var service in result)
            {
                service.priceService /= 100;
            }
            return result;
        }

        // получить все StatusRepair
        public static List<StatusRepair> GetAllStatusRepair()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.StatusRepairs.ToList();
                return result;
            }
        }

        // получить StatusRepair по name
        public static StatusRepair GetStatusRepair(string statusName)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                StatusRepair status = db.StatusRepairs.First(p => p.StatusName == statusName);
                return status;
            }
        }

        // получить StatusRepair по id
        public static StatusRepair GetStatusRepair(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                StatusRepair status = db.StatusRepairs.First(p => p.StatusId == id);
                return status;
            }
        }

        // получить клиента по номеру телефона
        public static Customer GetCustomerByPhone(string phone)
        {
            Customer customer = new Customer();
            List<Customer> customers = GetAllCustomers();
            foreach (Customer custom in customers)
            {
                if (custom.telCustom == phone)
                {
                    customer = custom;
                }
            }
            return customer;
        }
    }
}
