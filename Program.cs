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
            int bol=0;
            bool working = true;
            string otvet = " ", firstName, lastName, middleName;
            
            while (working)
            {
                Registration polz = new Registration();
                polz.Reg(); 
                Anketa an = new Anketa();
                an.Anketaa();
                AplicationForCredit a = new AplicationForCredit();
                a.Application();
                bol = polz.bal + an.bal + a.bal;
                if (bol>11)
                {
                    Console.Write("Поздравляю, ваш кредит одобрен");
                    otvet = "Одобрено!";
                }
                else
                {
                    Console.Write("Отказано!");
                    otvet = "Отказано!";
                }
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
                string sqlExpression = $"INSERT INTO Answer ([otvet], [firstName], [lastName], [middleName]) VALUES ( '{otvet}', '{firstName}', '{lastName}', '{middleName}')";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                int number = command.ExecuteNonQuery();
                Console.WriteLine("Добавлено объектов: {0}", number);
                }

            }
 
            PersonalAccount a1 = new PersonalAccount();
            a1.PAccount();
        }
    }
}
