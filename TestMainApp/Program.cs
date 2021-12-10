using System;
using Domain2;

namespace TestMainApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            Console.WriteLine("Тест ресурсов: ");

            Resource service1 = new Resource().CreateResource("Service", "Service1", 1000);
            WorkItem item1 = new WorkItem(service1, 1);

            Console.WriteLine(item1.DisplayItemWork());
            */

            ConsoleColor color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkGreen; // выводим список команд зеленым цветом
            Console.WriteLine("1. Создать сотрудника \t 2. Создать клиента  \t 3. Заказ");
            Console.WriteLine("4. Поставка \t 5. Оплатить заказ \t 6. Взять работу");
            Console.WriteLine("Введите номер пункта:");
            Console.ForegroundColor = color;

            try
            {
                int command = Convert.ToInt32(Console.ReadLine());

                switch (command)
                {
                    case 1:
                        //OpenAccount(bank);
                        break;
                    case 2:
                        //Withdraw(bank);
                        break;
                    case 3:
                        //Put(bank);
                        break;
                    case 4:
                        //CloseAccount(bank);
                        break;
                    case 5:
                        break;
                }
                //bank.CalculatePercentage();
            }
            catch (Exception ex)
            {
                // выводим сообщение об ошибке красным цветом
                color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ForegroundColor = color;
            }
        }
    }
}
