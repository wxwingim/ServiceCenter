using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIServiceCenter.Model.Data;
using System.Linq;

namespace UIServiceCenter.Model
{
    public static class DataWorker
    {
        // создать сотрудника
        public static void CreateEmployee(string LName, string FName, string MName, string phone, string mail, string Position)
        {
            string result = "";

            using(ApplicationContext db = new ApplicationContext())
            {
                Employee employee = new Employee { lastWork = LName, firstWork = FName, middleWork = MName, phoneWork = phone, mailWork = mail, position = Position };
                db.Employees.Add(employee);
                db.SaveChanges();
            }
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
    }
}
