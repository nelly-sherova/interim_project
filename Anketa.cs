using System;
using System.Data;
using System.Data.SqlClient;

namespace Project_1
{
    class Anketa
    {
        Points ball = new Points();
        const string connectionString = @"Data source=NILUFARSHEROVA; Initial catalog=ProjectAlifDB; Integrated Security = True";
        public void Anketaa()
        {
            int age, sempol;
            string sempoll=" ", firstName, lastName, middleName;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Добро пожаловать в поле регистрации для оформления кредита!! :)");
            Console.ForegroundColor = ConsoleColor.White;
            string AdminKey = "ad0010", key;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Выберете: \n1--> Я админ, 2--> Я пользователь ");
            int index = Convert.ToInt32(Console.ReadLine());
            switch (index)
            {
              case 1: 
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Введите пароль для подключения к системе: ");
                key = Console.ReadLine();
                if (AdminKey==key)
                {
                    bool AdminWorking = true;
                    while (AdminWorking)
                    {
                        Console.WriteLine("Выберете действие: \n1--> Заполнение анкеты клиента, \n2-->Просмотр истории заявок анкеты, \n 3--> Выход");
                        int indexAdmin = Convert.ToInt32(Console.ReadLine());
                        switch (indexAdmin)
                        {
                            case 1:
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("Имя: ");
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
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("Возраст: ");
                                Console.ForegroundColor = ConsoleColor.White;
                                age = Convert.ToInt32(Console.ReadLine());
                                if (age >= 26 && age <= 35) ball.Point = ball.Point + 1;
                                if (age >=36 && age <=62) ball.Point = ball.Point + 2;
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("Семейное положение: \n1->Холост \n2->Семьянин, \n3->В разводе\n4->Вдовец/Вдова");
                                Console.ForegroundColor = ConsoleColor.White;
                                sempol = Convert.ToInt32(Console.ReadLine());
                                if (sempol == 1 )
                                {
                                    sempoll = "Холост";
                                    ball.Point = ball.Point + 1;
                                }
                                if (sempol == 2)
                                {
                                   sempoll = "Семьянин";
                                   ball.Point = ball.Point + 2;
                                }
                                if (sempol == 3)
                                {
                                   sempoll = "В разводе";
                                   ball.Point = ball.Point + 1;  
                                }
                                if (sempol == 4)
                                {
                                   sempoll = "Вдовец/Вдова";
                                   ball.Point = ball.Point + 2;
                                }
                                Console.ForegroundColor = ConsoleColor.White;
                                string sqlExpression1 = $"INSERT INTO Anketa ([firstName],[lastName], [middleName], [age], [sempoll]) VALUES ( '{firstName}', '{lastName}', '{middleName}', '{age}', '{sempoll}')";
                                using (SqlConnection connection = new SqlConnection(connectionString))
                                {
                                    connection.Open();
                                    SqlCommand command = new SqlCommand(sqlExpression1, connection);
                                    int number = command.ExecuteNonQuery();
                                    Console.WriteLine("Добавлено объектов: {0}", number);
                                }
                                break; 
                                case 2:

                                  Console.WriteLine("История анкетирований: ");
                                  Console.ForegroundColor = ConsoleColor.White;
                                  string sqlExpression2 = "SELECT * FROM Anketa";
                                  using (SqlConnection connection1 = new SqlConnection(connectionString))
                                  {
                                      connection1.Open();
                                      SqlCommand command1 = new SqlCommand(sqlExpression2, connection1);
                                      SqlDataReader reader  = command1.ExecuteReader();
                                      while (reader.Read()) Console.WriteLine($"ID: {reader.GetValue(0)}, Имя:{reader.GetValue(1)} | Фамилия: {reader.GetValue(2)} | Отчество: {reader.GetValue(3)} | Возраст: {reader.GetValue(4)} | Семейное положение:  {reader.GetValue(5)}");
                                  }
                                break;
                              case 3:
                                AdminWorking = false;
                              break;
                              default : 
                                AdminWorking = false;
                              break;
                        }
                    
                    }
                }
                else
                    {
                        Console.WriteLine("Неправильный пароль!");
                    }
              break;
              case 2:
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Имя: ");
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
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Возраст: ");
                Console.ForegroundColor = ConsoleColor.White;
                age = Convert.ToInt32(Console.ReadLine());
                if (age >= 26 && age <= 35) ball.Point = ball.Point + 1;
                if (age >=36 && age <=62) ball.Point = ball.Point + 2;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Семейное положение: \n1->Холост \n2->Семьянин, \n3->В разводе\n4->Вдовец/Вдова");
                Console.ForegroundColor = ConsoleColor.White;
                sempol = Convert.ToInt32(Console.ReadLine());
                if (sempol == 1 )
                {
                    sempoll = "Холост";
                    ball.Point = ball.Point + 1;
                }
                if (sempol == 2)
                {
                    sempoll = "Семьянин";
                    ball.Point = ball.Point + 2;
                }
                if (sempol == 3)
                {
                    sempoll = "В разводе";
                    ball.Point = ball.Point + 1;  
                }
                if (sempol == 4)
                {
                    sempoll = "Вдовец/Вдова";
                    ball.Point = ball.Point + 2;
                }
                Console.ForegroundColor = ConsoleColor.White;
                string sqlExpression = $"INSERT INTO Anketa ([firstName],[lastName], [middleName], [age], [sempoll]) VALUES ( '{firstName}', '{lastName}', '{middleName}', '{age}', '{sempoll}')";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    int number = command.ExecuteNonQuery();
                    Console.WriteLine("Добавлено объектов: {0}", number);
                }
                break; 
            }
        }
    }
}