using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Npgsql;
using System.Data;

namespace ConsoleApp1
{
    public static class DataWorker
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public static void AddDeviceType(DeviceType deviceType)
        {
            using (work100022Context db = new work100022Context())
            {
                db.DeviceTypes.Add(deviceType);
                db.SaveChanges();
            }
        }

        public static void AddService(Service service)
        {
            using (work100022Context db = new work100022Context())
            {
                db.Services.Add(service);
                db.SaveChanges();
            }
        }

        public static List<Service> GetAllServices()
        {
            using (work100022Context db = new work100022Context())
            {
                List<Service> services = db.Services.ToList();
                return services;
            }
        }

        public static void EditService(Service newService)
        {
            using (work100022Context db = new work100022Context())
            {
                Service service = db.Services.FirstOrDefault(d => d.Id == newService.Id);
                if (service != null)
                {
                    service.Name = newService.Name;
                    service.Price = newService.Price;
                    service.Quarantee = newService.Quarantee;
                    service.IdDeviceType = newService.IdDeviceType;

                    db.SaveChanges();
                }
            }
        }

        public static void AddPartType(string partType)
        {
            string strSQL = "INSERT INTO part_types (name_type) VALUES (@name_type)";
            using (NpgsqlConnection oCon = new NpgsqlConnection(connectionString))
            {
                try
                {
                    oCon.Open();
                    NpgsqlCommand command = new NpgsqlCommand(strSQL, oCon);
                    command.Parameters.Add("@name_type", NpgsqlTypes.NpgsqlDbType.Varchar).Value = partType;

                    command.ExecuteNonQuery();
                }
                catch(NpgsqlException e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    oCon.Close();
                } 
            }
        }

        public static void AddPurchase(Purchase purchase)
        {
            string strSQl = "INSERT INTO purchases (name, purchase_price, retail_price, quarantee, id_part_type, amount) " +
                "VALUES (@name, @purchase_price, @retail_price, @quarantee, @id_part_type, @amount)";
            using (NpgsqlConnection oCon = new NpgsqlConnection(connectionString))
            {
                try
                {
                    oCon.Open();
                    NpgsqlCommand command = new NpgsqlCommand(strSQl, oCon);

                    command.Parameters.Add("@name", NpgsqlTypes.NpgsqlDbType.Varchar).Value = purchase.Name;
                    command.Parameters.Add("@purchase_price", NpgsqlTypes.NpgsqlDbType.Numeric).Value = purchase.PurchasePrice;
                    command.Parameters.Add("@retail_price", NpgsqlTypes.NpgsqlDbType.Numeric).Value = purchase.RetailPrice;
                    command.Parameters.Add("@quarantee", NpgsqlTypes.NpgsqlDbType.Integer).Value = purchase.Quarantee;
                    command.Parameters.Add("@id_part_type", NpgsqlTypes.NpgsqlDbType.Integer).Value = purchase.IdPartType;
                    command.Parameters.Add("@amount", NpgsqlTypes.NpgsqlDbType.Integer).Value = purchase.Amount;

                    command.ExecuteNonQuery();
                }
                catch (NpgsqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    oCon.Close();
                }
                
            }
        }

        public static void UpdatePurchase(Purchase newPurchase)
        {
            string strSQL = "UPDATE purchases SET name = @name, purchase_price = @purchase_price, retail_price = @retail_price, quarantee = @quarantee, amount = @amount, id_part_type = @id_part_type WHERE id = @id";
            using(NpgsqlConnection oCon = new NpgsqlConnection(connectionString))
            {
                try
                {
                    oCon.Open();
                    NpgsqlCommand command = new NpgsqlCommand(strSQL, oCon);

                    command.Parameters.Add("@name", NpgsqlTypes.NpgsqlDbType.Varchar).Value = newPurchase.Name;
                    command.Parameters.Add("@purchase_price", NpgsqlTypes.NpgsqlDbType.Numeric).Value = newPurchase.PurchasePrice;
                    command.Parameters.Add("@retail_price", NpgsqlTypes.NpgsqlDbType.Numeric).Value = newPurchase.RetailPrice;
                    command.Parameters.Add("@quarantee", NpgsqlTypes.NpgsqlDbType.Integer).Value = newPurchase.Quarantee;
                    command.Parameters.Add("@id_part_type", NpgsqlTypes.NpgsqlDbType.Integer).Value = newPurchase.IdPartType;
                    command.Parameters.Add("@amount", NpgsqlTypes.NpgsqlDbType.Integer).Value = newPurchase.Amount;
                    command.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Integer).Value = newPurchase.Id;

                    command.ExecuteNonQuery();
                }
                catch(NpgsqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    oCon.Close();
                }
            }
        }

        public static DataTable GetAllPurchases()
        {
            string strSQL = "SELECT id, name, purchase_price, retail_price, quarantee, id_part_type, amount, date_purchase FROM purchases";
            DataTable purchases = new DataTable();
            using (NpgsqlConnection oCon = new NpgsqlConnection(connectionString))
            {
                try
                {
                    oCon.Open();
                    NpgsqlCommand command = new NpgsqlCommand(strSQL, oCon);
                    NpgsqlDataReader result = command.ExecuteReader();
                    purchases = result.GetSchemaTable();
                    result.Close();
                }
                catch (NpgsqlException ex)
                {
                    Console.Write(ex.Message);
                }
                finally { oCon.Close(); }
                    return purchases;
            }
        }
    }
}
