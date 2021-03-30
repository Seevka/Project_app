using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

//програма, яка буде вміти працювати з користувачами: вивести список, додати, видалити, оновити, зробитив користувача є дан
//і: ID, прізвище, ім‘я, мейл дані зберігаються в файлі в довільному форматі
namespace Project_app
{

    class Program
    {
        private static UserService userService = new UserService();

        public static void Main()
        {
            do
            {
                Console.WriteLine("What do u wanna to do?0 print data, 1 add data, 2 update data,3 delete data, 4 exit");
                var newAction = Convert.ToInt32(Console.ReadLine());
                switch ((Action)newAction)
                {
                    case Action.Read:
                        userService.PrintAll();
                        break;
                    case Action.Add:
                        userService.Add();
                        break;
                    case Action.Update:
                        userService.Update();
                        break;
                    case Action.Delete:
                        userService.Delete();
                        break;
                    case Action.Exit:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Try again, uknown operation!");
                        break;

                }
            } while (true);

        }
    }
}


