using System;
using UsersAndAwardsEntities;
using UsersAndAwardsLogic;

namespace UsersAndAwardsConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            var awardsLogic = new AwardsLogic(); 
            var usersLogic = new UsersLogic();
            var b = true;
            while (b)
            {
                Console.WriteLine(
                    "Выберете одно из следующий действий:\n1. Добавить пользователя\n2. Просмотреть всех пользователей\n3." +
                    " Удалить пользователя\n4. Добавить новый тип наград\n5. Просмотреть все награды\n6." +
                    " Просмотреть награды у всех пользователей\n7. Просмотреть пользователей и все их награды\n8. " +
                    "Добавить награду пользователю");
                Console.Write("\nВаш выбор: ");
                var ch = Console.ReadLine();

                switch (ch)
                {
                    case "1":
                    {
                        Console.WriteLine("Введите ФИО, дату рождения и возраст.");
                        Console.Write("ФИО: ");
                        var name = Console.ReadLine();
                        Console.Write("Дата рождения: ");
                        var date = DateTime.Parse(Console.ReadLine());
                        Console.Write("Возраст: ");
                        int.TryParse(Console.ReadLine(), out var age);
                        var user = new User(name, date, age);
                        var str = usersLogic.AddUser(user);
                        Console.WriteLine(str);
                        Console.WriteLine();
                        break;
                    }

                    case "2":
                    {
                        var listUsers = usersLogic.GetUsers();
                        foreach (var us in listUsers)
                        {
                            Console.WriteLine(us);
                        }
                        Console.WriteLine();
                        break;
                    }

                    case "3":
                    {
                        Console.WriteLine("Введите ID пользователя, которого нужно удалить");
                        var listUsers = usersLogic.GetUsers();
                        foreach (var us in listUsers)
                        {
                            Console.WriteLine(us);
                        }
                        Console.Write("ID: ");
                        int.TryParse(Console.ReadLine(), out var usId);
                        var str = usersLogic.DeleteUser(usId);
                        Console.WriteLine(str);
                        Console.WriteLine();
                        break;
                    }

                    case "4":
                    {
                        Console.WriteLine("Введите тип награды.");
                        Console.Write("Название: ");
                        var title = Console.ReadLine();
                        var award = new Award(title);
                        var str = awardsLogic.AddAward(award);
                        Console.WriteLine(str);
                        Console.WriteLine();
                        break;
                    }

                    case "5":
                    {
                        foreach (var award in awardsLogic.GetAwards())
                        {
                            Console.WriteLine(award);
                        }
                        Console.WriteLine();
                        break;
                    }

                    case "6":
                    {
                        var awards = awardsLogic.GetAwards();
                        foreach (var aw in awards)
                        {
                            Console.WriteLine($"Пользователи у которых имеется {aw.Title}: ");
                            foreach (var us in aw.Users)
                            {
                                Console.WriteLine($"  {us.Name}");
                            }
                        }
                        Console.WriteLine();
                        break;
                    }

                    case "7":
                    {
                        var users = usersLogic.GetUsers();
                        foreach (var us in users)
                        {
                            Console.WriteLine($"Награды, имеющиеся у пользователя: {us.Name}");
                            foreach (var aw in us.Awards)
                            {
                                Console.WriteLine($"  {aw.Title}");
                            }
                        }
                        Console.WriteLine();
                        break;
                    }

                    case "8":
                    {
                        Console.WriteLine("Введите ID пользователя и ID награды.");
                        Console.Write("ID пользователя: ");
                        int.TryParse(Console.ReadLine(), out var idUs);
                        Console.Write("ID награды: ");
                        int.TryParse(Console.ReadLine(), out var idAw);
                        var str = usersLogic.AddAwardForUser(idUs, idAw);
                        Console.WriteLine(str);
                        Console.WriteLine();
                        break;
                    }

                    case "9":
                    {
                        b = false;
                        break;
                    }
                    
                    default:
                    {
                        Console.WriteLine("Неверно выбрано действие. Выберите одно из действий в диапазоне от 1 до 8.");
                        break;
                    }
                }
            }
        }
    }
}