using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testt
{
    public class MenuMethods
    {
        public static void CheckAccount(string login)
        {
            using (ProductsDB db = new ProductsDB())
            {
                User user = db.User.FirstOrDefault(x => x.Login.Contains(login));
                Console.WriteLine($"{user.Account}");

            }
        }

        public static void TopUpAnAccount(string login)
        {
            Console.Write("Введите сумму: ");
            int sum = Convert.ToInt32(Console.ReadLine());
            using (ProductsDB db = new ProductsDB())
            {
                User user = db.User.FirstOrDefault(x => x.Login.Contains(login));
                user.Account += sum;
                db.SaveChanges();
                Console.WriteLine($"{user.Account}");
            }
        }

        public static void ProductsList()
        {
            using (ProductsDB db = new ProductsDB())
            {
                var data = db.Products.Select(x => new
                {
                    Id = x.ProductId,
                    Name = x.ProductName,
                    Price = x.ProductPrice
                });
                foreach (var item in data)
                {
                    Console.WriteLine($"Id: {item.Id}");
                    Console.WriteLine($"Брэнд: {item.Name}");
                    Console.WriteLine($"Цена: {item.Price} \n");
                }
            }
        }

        public static void BuyProducts(int id, string login)
        {
            using(ProductsDB db = new ProductsDB())
            {
                Order order = new Order();
                User user = db.User.FirstOrDefault(u => u.Login.Contains(login));
                Products product = db.Products.FirstOrDefault(x => x.ProductId == id);
                
                if(user.Account >= product.ProductPrice)
                {
                    user.Account -= product.ProductPrice;
                    db.Add(order);
                    order.UserProducts = product.ProductName;
                    db.Order.Find(order.Count++);
                    order.Date = DateTime.UtcNow;
                    db.SaveChanges();
                    Console.WriteLine("\t Вы успешно купили товар!");
                }
                else
                {
                    Console.WriteLine("У вас не достаточно средств!");
                }
            }
        }

    }
}
