using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using DataBase;

namespace UIServiceCenter.Model
{
    public static class DataWorker // static
    {

        //ApplicationContext context = new ApplicationContext();


        // создать сотрудника
        public static string CreateEmployee(string lname, string fname, string mname, string phone, string mail, string position)
        {
            string result = "";

            using (ApplicationContext db = new ApplicationContext())
            {
                Employee employee = new Employee {lastWork = lname, firstWork = fname, middleWork = mname, phoneWork = phone, mailWork = mail, position = position };
                db.Employees.Add(employee);
                db.SaveChanges();
            }

            return result;
        }


        // редактировать сотрудника


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
        public static string CreateCustomer(string lname, string fname, string mname, string phone, string mail)
        {
            string result = "";

            using (ApplicationContext db = new ApplicationContext())
            {
                Customer customer = new Customer { lastCustom = lname, firstCustom = fname, middleCustom = mname, telCustom = phone, mailCustom = mail };
                db.Customers.Add(customer);
                db.SaveChanges();
            }

            return result;
        }


        // редактировать клиента


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
        public static List<OrderModelList> GetAllOrders()
        {
            List<OrderModelList> result = new List<OrderModelList>();
            List<Work_order> work_Orders = GetAllOrdersSmall();
            foreach(Work_order order in work_Orders)
            {
                result.Add(new OrderModelList(order));
            }
            return result;
        }

        public static List<Work_order> GetAllOrdersSmall()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Work_Orders.ToList();
                return result;
            }
        }

        // получить AdmissionForRepair по id
        public static Admission_for_repair GetAdmission_For_Repair(int id)
        {
            using(ApplicationContext db = new ApplicationContext())
            {
                Admission_for_repair admission = db.Admission_For_Repairs.FirstOrDefault(p => p.num_admission == id);
                return admission;
            }
        }

        // получить CustomerDevice по id
        public static Customer_device GetCustomer_device(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Customer_device customerDevice = db.Customer_Devices.FirstOrDefault(p => p.idCustDev == id);
                return customerDevice;
            }
        }

        // получить Device_model по id
        public static Device_model GetDevice_model(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Device_model deviceModel = db.Device_models.FirstOrDefault(p => p.keyModel == id);
                return deviceModel;
            }
        }

        // получить все Device_type
        public static List<Device_type> GetAllDeviceTypes()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Device_types.ToList();
                return result;
            }
        }

        // создать поступление в ремонт
        public static string CreateAdmissionForRepair(string lname, string fname, string mname, string phone, string mail)
        {
            string result = "";

            //using (ApplicationContext db = new ApplicationContext())
            //{
            //    Customer customer = new Customer { lastCustom = lname, firstCustom = fname, middleCustom = mname, telCustom = phone, mailCustom = mail };
            //    db.Customers.Add(customer);
            //    db.SaveChanges();
            //}

            return result;
        }

        // создать заказ
        public static string CreateOrder(string lname, string fname, string mname, string phone, string mail)
        {
            string result = "";

            //using (ApplicationContext db = new ApplicationContext())
            //{
            //    Customer customer = new Customer { lastCustom = lname, firstCustom = fname, middleCustom = mname, telCustom = phone, mailCustom = mail };
            //    db.Customers.Add(customer);
            //    db.SaveChanges();
            //}

            return result;
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
