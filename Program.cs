using System;
using System.Data;
using System.Data.SqlClient;

namespace Project_1
{
    class Program
    {
        const string connectionString = @"Data source=NILUFARSHEROVA; Initial catalog=ProjectAlifDB; Integrated Security = True";
        static void Main(string[] args)
        {
            int bol=0, index;
            string keyAdmin="ad0010", key;
            bool working1 = true, working2 = true;
            string otvet = " ", firstName, lastName, middleName;
            Console.WriteLine("1 -> Я админ\n 2 -> Я пользователь");
            index = Convert.ToInt32(Console.ReadLine());
            if (index == 1)
            {
                Console.Write("Введите пароль админа: ");
                key = Console.ReadLine();
                if (key == keyAdmin)
                {
                    while (working1)
                    {
                        Console.WriteLine("1 -> Регистрация клиента \n2->Просмторт истории заявок, \n3-> Выход");
                        int index1 = Convert.ToInt32(Console.ReadLine());
                        switch (index1)
                        {
                            case 1:
                                Registration polz = new Registration();
                                polz.Reg();
                                Anketa an = new Anketa();
                                an.Anketaa();
                                AplicationForCredit a = new AplicationForCredit();
                                a.Application();
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("Имя : ");
                                Console.ForegroundColor = ConsoleColor.White;
                                firstName = Console.ReadLine();
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("Фамилия: ");
                                Console.ForegroundColor = ConsoleColor.White;
                                lastName = Console.ReadLine();
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("Отчество: ");
                                Console.ForegroundColor = ConsoleColor.White;
                                middleName = Console.ReadLine();
                                bol = polz.bal + an.bal + a.bal;
                                if (bol>11)
                                {
                                    Console.WriteLine("Поздравляю, ваш кредит одобрен");
                                    otvet = "Одобрено!";
                                }
                                else
                                {
                                    Console.WriteLine("Отказано!");
                                    otvet = "Отказано!";
                                }
                                string sqlExpression = $"INSERT INTO Answer ([otvet], [firstName], [lastName], [middleName]) VALUES ( '{otvet}', '{firstName}', '{lastName}', '{middleName}')";
                                using (SqlConnection connection = new SqlConnection(connectionString))
                                {
                                    connection.Open();
                                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                                    int number = command.ExecuteNonQuery();
                                    Console.WriteLine("Добавлено объектов: {0}", number);
                                }
                                Console.WriteLine($"Балл : {bol}");
                            break;
                            case 2: 
                                ApplicationHistory his = new ApplicationHistory();
                                his.ApplicHistory();
                            break;
                            case 3: 
                                working1 = false;
                            break;
                            default : 
                                Console.WriteLine("Неправильная команда ");
                                working1 = false;
                            break;
                        }
                    }
                     
                }
            }
            else 
            {
                Console.WriteLine("Вход как пользователя: ");
                while (working2)
                {
                    Console.WriteLine("1 -> Регистрация \n2->Вход в личный кабинет, \n3-> Выход");
                    int index1 = Convert.ToInt32(Console.ReadLine());
                    switch (index1)
                    {
                        case 1:
                            Registration polz = new Registration();
                            polz.Reg();
                            Anketa an = new Anketa();
                            an.Anketaa();
                            AplicationForCredit a = new AplicationForCredit();
                            a.Application();
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("Имя : ");
                            Console.ForegroundColor = ConsoleColor.White;
                            firstName = Console.ReadLine();
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("Фамилия: ");
                            Console.ForegroundColor = ConsoleColor.White;
                            lastName = Console.ReadLine();
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("Отчество: ");
                            Console.ForegroundColor = ConsoleColor.White;
                            middleName = Console.ReadLine();
                            bol = polz.bal + an.bal + a.bal;
                            if (bol>11)
                            {
                                Console.WriteLine("Поздравляю, ваш кредит одобрен");
                                otvet = "Одобрено!";
                            }
                            else
                            {
                                Console.WriteLine("Отказано!");
                                otvet = "Отказано!";
                            }
                            string sqlExpression = $"INSERT INTO Answer ([otvet], [firstName], [lastName], [middleName]) VALUES ( '{otvet}', '{firstName}', '{lastName}', '{middleName}')";
                            using (SqlConnection connection = new SqlConnection(connectionString))
                            {
                                connection.Open();
                                SqlCommand command = new SqlCommand(sqlExpression, connection);
                                int number = command.ExecuteNonQuery();
                                Console.WriteLine("Добавлено объектов: {0}", number);
                            }
                            Console.WriteLine($"Балл : {bol}");
                            break;
                            case 2: 
                               PersonalAccount a1 = new PersonalAccount();
                               a1.PAccount();
                            break;
                            case 3: 
                                working2 = false;
                            break;
                            default : 
                                Console.WriteLine("Неправильная команда ");
                                working2 = false;
                            break;
                        }
                }
            }          
        }
    }
}
