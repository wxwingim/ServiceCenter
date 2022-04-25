// See https://aka.ms/new-console-template for more information
using ConsoleApp1;
using Npgsql;
using System.Data;

Console.WriteLine("Hello, World!");

//DeviceType deviceType = new DeviceType { NameType = "Смартфоны" };
//DataWorker.AddDeviceType(deviceType);

//Service service = new Service { Name = "Замена матрицы", Price = 890.00M, Quarantee = 30, IdDeviceType = 1 };
//Service service2 = new Service { Name = "Ремонт и замена жесткого диска", Price = 490.00M, Quarantee = 60, IdDeviceType = 1 };
//Service service3 = new Service { Name = "Замена процессора", Price = 1290.00M, Quarantee = 30, IdDeviceType = 1 };
//Service service4 = new Service { Name = "Ремонт блока питания", Price = 390.00M, Quarantee = 30, IdDeviceType = 1 };
//Service service5 = new Service { Name = "Ремонт системы охлаждения", Price = 1790.00M, Quarantee = 90, IdDeviceType = 1 };
//DataWorker.AddService(service);
//DataWorker.AddService(service2);
//DataWorker.AddService(service3);
//DataWorker.AddService(service4);
//DataWorker.AddService(service5);

//List<Service> services = DataWorker.GetAllServices();
//foreach (Service service in services)
//{
//    Console.WriteLine(service);
//}

//Purchase purchase = new Purchase { Name = "Дисплей Alcatel OT-5022D (Pop Star 3G) в сборе с тачскрином черный", IdPartType = 1, PurchasePrice = 1200.00M, Quarantee = 30, RetailPrice = 1300.00M, Amount = 1 };
//Purchase purchase1 = new Purchase { Name = "Дисплей Asus FE380CG (Fonepad 8)", IdPartType = 1, PurchasePrice = 400.00M, Quarantee = 30, RetailPrice = 440.00M, Amount = 2 };
//Purchase purchase2 = new Purchase { Name = "Дисплей Xiaomi Redmi 9 в сборе с тачскрином черный", IdPartType = 1, PurchasePrice = 2300.00M, Quarantee = 60, RetailPrice = 2500.00M, Amount = 1 };
//Purchase purchase3 = new Purchase { Name = "Тачскрин 7.0 FPC - 70C2 - V03(184 * 104 mm)(Irbis TG - 72, Supra M722G) черный", IdPartType = 2, PurchasePrice = 650.00M, Quarantee = 30, RetailPrice = 700.00M, Amount = 1 };
//Purchase purchase4 = new Purchase { Name = "Тачскрин 7.0 RJ916 / Y7Y007(86V)(186 * 111 mm)(Digma, Explay) черный", IdPartType = 2, PurchasePrice = 200.00M, Quarantee = 0, RetailPrice = 250.00M, Amount = 1 };
//Purchase purchase5 = new Purchase { Name = "Шлейф Huawei Y8p/Honor 30i межплатный", IdPartType = 3, PurchasePrice = 150.00M, Quarantee = 30, RetailPrice = 170.00M, Amount = 4 };
//Purchase purchase6 = new Purchase { Name = "Шлейф Samsung A505F (A50) плата системный разъем/разъем гарнитуры/микрофон", IdPartType = 3, PurchasePrice = 350.00M, Quarantee = 15, RetailPrice = 390.00M, Amount = 14 };
//Purchase purchase7 = new Purchase { Name = "Шлейф Samsung S8300", IdPartType = 3, PurchasePrice = 80.00M, Quarantee = 30, RetailPrice = 90.00M, Amount = 5 };
//Purchase purchase8 = new Purchase { Name = "Шлейф Samsung S8300 Оригинал", IdPartType = 3, PurchasePrice = 450.00M, Quarantee = 30, RetailPrice = 500.00M, Amount = 3 };
//Purchase purchase9 = new Purchase { Name = "Подложка клавиатуры Nokia 7210 C", IdPartType = 5, PurchasePrice = 50.00M, Quarantee = 10, RetailPrice = 55.00M, Amount = 1 };

//DataWorker.AddPurchase(purchase);
//DataWorker.AddPurchase(purchase1);
//DataWorker.AddPurchase(purchase2);
//DataWorker.AddPurchase(purchase3);
//DataWorker.AddPurchase(purchase4);
//DataWorker.AddPurchase(purchase5);
//DataWorker.AddPurchase(purchase6);
//DataWorker.AddPurchase(purchase7);
//DataWorker.AddPurchase(purchase8);
//DataWorker.AddPurchase(purchase9);

//DataWorker.AddPartType("Дисплеи для сотовых");
//DataWorker.AddPartType("Тачскрины");
//DataWorker.AddPartType("Шлейфа для сотовых");
//DataWorker.AddPartType("Корпусные детали");
//DataWorker.AddPartType("Подложки, толкатели, кнопки");

//Service newService = services[0];
//newService.Price = 990.00M;
//DataWorker.EditService(newService);

//List<Service> services2 = DataWorker.GetAllServices();
//foreach (Service service in services2)
//{
//    Console.WriteLine(service);
//}

//DataTable purchases = DataWorker.GetAllPurchases();
//foreach (DataColumn column in purchases.Columns)
//    Console.Write("\t{0}", column.ColumnName);
//Console.WriteLine();

//foreach (DataRow row in purchases.Rows)
//{
//    var cells = row.ItemArray;
//    foreach (object cell in cells)
//        Console.Write("\t{0}", cell);
//    Console.WriteLine();
//}

Purchase purchase = new Purchase { Id = 2, Name = "Дисплей Alcatel OT-5022D (Pop Star 3G) в сборе с тачскрином черный", IdPartType = 1, PurchasePrice = 1200.00M, Quarantee = 60, RetailPrice = 1250.00M, Amount = 1 };
DataWorker.UpdatePurchase(purchase);