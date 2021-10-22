using System;
using System.Collections.Generic;
using System.Linq;

namespace Testt
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ProductsDB users = new ProductsDB())
            {
                User us = new User();
                Console.WriteLine("Для входа нажмите '1'");
                Console.WriteLine("Для регистрации нажмите '2'");
                int num = Convert.ToInt32(Console.ReadLine());
                if (num == 1)
                {
                    Console.Write("Введите свой логин: ");
                    string myLogin = Console.ReadLine();
                    var u = users.User.FirstOrDefault(x => x.Login.Contains(myLogin));
                    if (u == null)
                    {
                        Console.WriteLine("\tТакой пользователь не найден!");
                        Console.ReadLine();
                    }
                    Console.Write("Введите пароль: ");
                    string myPassword = Console.ReadLine();
                    string hashPassword = Password.GetHashString(myPassword);
                    if (u.Password == hashPassword)
                    {
                        Menu.ViewMenu(myLogin);
                    }
                    else
                    {
                        Console.WriteLine("Не верный пароль!");
                    }

                }
                else if (num == 2)
                {
                    Console.Write("Придумайте логин: ");
                    string newLogin = Console.ReadLine();
                    var u = users.User.FirstOrDefault(x => x.Login.Contains(newLogin));
                    if (u == null)
                    {
                        users.User.Add(us);
                        us.Login = newLogin;
                        string pa = Password.GetRandomPassword();
                        Console.WriteLine($"{newLogin } Ваш одноразовый пароль: {pa}");
                        Console.Write("Введите одноразовый пароль: ");
                        string xPassword = Console.ReadLine();
                        if (pa == xPassword)
                        {
                            Console.Write("Придумайте новый пароль: ");
                            xPassword = Console.ReadLine();
                            us.Password = Password.GetHashString(xPassword).ToString();
                            users.SaveChanges();
                            Menu.ViewMenu(newLogin);
                        }
                        else
                        {
                            Console.WriteLine("Пароль был введен неправильно!");
                            Console.ReadLine();
                        }
                    }
                    else if (u != null)
                    {
                        Console.WriteLine("\t Такой логин уже существует!");
                        Console.ReadLine();
                    }
                }


            }
        }
    }
}
