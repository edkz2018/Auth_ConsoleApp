using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testt
{
    public class Menu
    {
        static bool isShowWelcome = false;
        public static void ViewMenu(string l)
        {
            while (true)
            {
                
                if(isShowWelcome == false)
                {
                    Console.WriteLine($"\t Добро пожаловать в личный кабинет!");
                    isShowWelcome = true;
                }
                Console.WriteLine("1) Проверить счет");
                Console.WriteLine("2) Пополнить счет");
                Console.WriteLine("3) Список товаров");
                Console.Write("Выберите пункт: ");

                int number = Convert.ToInt32(Console.ReadLine());
                if (number == 1)
                {
                    MenuMethods.CheckAccount(l);
                }
                else if (number == 2)
                {
                    MenuMethods.TopUpAnAccount(l);
                }
                else if (number == 3)
                {
                    MenuMethods.ProductsList();
                    Console.Write("Выберите id товара чтобы сделать покупку: ");
                    int productId = Convert.ToInt32(Console.ReadLine());
                    MenuMethods.BuyProducts(productId, l);
                }
            }
        }
    }
}
