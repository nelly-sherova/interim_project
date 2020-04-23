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
            string otvet = " ";
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
                string sqlExpression = $"INSERT INTO Answer ([otvet]) VALUES ( '{otvet}')";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                int number = command.ExecuteNonQuery();
                Console.WriteLine("Добавлено объектов: {0}", number);
                }

            }
            
           
            

        }
    }
}
