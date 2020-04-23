using System;
using System.Data;
using System.Data.SqlClient;

namespace Project_1
{
    class AplicationForCredit
    {
        public int bal;
        Points ball = new Points();
        const string connectionString = @"Data source=NILUFARSHEROVA; Initial catalog=ProjectAlifDB; Integrated Security = True";
        public void Application()
        {
            double sumOfCredit, dohod, x ;
            string firstName, lastName, middleName, creditHistoryClose = " ", prosrochkastring = " ", selstring = " "; 
            int creditHistoryCl, prosrochkaint, selint;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Добро пожаловать в поле заявки для оформления кредита!! :)");
            string AdminKey = "ad0010", key;
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
                        Console.WriteLine("Выберете действие: \n1--> Добавление заявки клиента, \n2-->Просмотр истории заявок, \n 3--> Выход");
                        int indexAdmin = Convert.ToInt32(Console.ReadLine());
                        switch (indexAdmin)
                        {
                            case 1:
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
                                Console.Write("Сумма кредита: ");
                                Console.ForegroundColor = ConsoleColor.White;
                                sumOfCredit = Convert.ToDouble(Console.ReadLine());
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("Доход: ");
                                Console.ForegroundColor = ConsoleColor.White;
                                dohod = Convert.ToDouble(Console.ReadLine());
                                x = 100*dohod/sumOfCredit;
                                if (x < 80) ball.Point = ball.Point+4;
                                if (x >= 80 && x<150) ball.Point = ball.Point+3;
                                if (x >= 150 && x<250) ball.Point = ball.Point+2;
                                if (x >= 250) ball.Point = ball.Point+1;
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("Кредитная история (закрытые кредиты)");
                                Console.Write("1->более трех закрытых кредитов: \n2-> 1-2 Закрытых кредита: \n3-> Нет кредитной истории");
                                Console.ForegroundColor = ConsoleColor.White;
                                creditHistoryCl = Convert.ToInt32(Console.ReadLine());
                                if (creditHistoryCl == 1) 
                                {
                                  ball.Point = ball.Point+2;
                                  creditHistoryClose = "более трех закрытых кредитов";
                                }
                                if (creditHistoryCl == 2) 
                                {
                                  ball.Point = ball.Point+1;
                                  creditHistoryClose = "1-2 Закрытых кредита";
                                }
                                if (creditHistoryCl == 3) 
                                {
                                  ball.Point = ball.Point-1;
                                  creditHistoryClose = "Нет кредитной истории";
                                }
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("Просрочка в кредитной истории: \n1-> Свыше 7 раз, \n2-> 5-7 раз, \n3->4 раза, 4-> до трех раз");
                                Console.ForegroundColor = ConsoleColor.White;
                                prosrochkaint =  Convert.ToInt32(Console.ReadLine());
                                if (prosrochkaint == 3)
                                {
                                  ball.Point = ball.Point - 3;
                                  prosrochkastring = "Свыше 7 раз";
                                }
                                if (prosrochkaint == 2)
                                {
                                  ball.Point = ball.Point - 2;
                                  prosrochkastring  = "5-7 раз";
                                }
                                if (prosrochkaint == 3)
                                {
                                  ball.Point = ball.Point -1;
                                  prosrochkastring = "4 раза";
                                }
                                if (prosrochkaint == 4) prosrochkastring = "до трех раз";
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("Цель кредита: \n1-->Бытовая техника, \n2-->Ремонт, \n3-->Телефон, \n4-->Прочее");
                                Console.ForegroundColor = ConsoleColor.White;
                                selint = Convert.ToInt32(Console.ReadLine());
                                if (selint == 1)
                                {
                                  ball.Point = ball.Point + 2;
                                  selstring = "Бытовая техника";
                                }
                                if (selint == 2)
                                {
                                  ball.Point = ball.Point + 1;
                                  selstring = "Ремонт";
                                }
                                if (selint == 3) selstring = "Телефон";
                                if (selint == 4) 
                                {
                                  ball.Point = ball.Point - 1;
                                  selstring = "Прочее";
                                }
                                Console.ForegroundColor = ConsoleColor.White;
                                string sqlExpression3 = $"INSERT INTO AplicationForCredit ([firstName],[lastName], [middleName], [sumOfCredit], [dohod], [Credithistory], [CredithistoryPast], [cel]) VALUES ( '{firstName}', '{lastName}', '{middleName}', '2{sumOfCredit}', '{dohod}', '{creditHistoryClose}', '{prosrochkastring}', '{selstring}')";
                                using (SqlConnection connection = new SqlConnection(connectionString))
                                {
                                    connection.Open();
                                    SqlCommand command = new SqlCommand(sqlExpression3, connection);
                                    int number = command.ExecuteNonQuery();
                                    Console.WriteLine("Добавлено объектов: {0}", number);
                                }
                            break;
                            case 2:
                                  Console.WriteLine("История заявок: ");
                                  Console.ForegroundColor = ConsoleColor.White;
                                  string sqlExpression2 = "SELECT * FROM AplicationForCredit";
                                  using (SqlConnection connection1 = new SqlConnection(connectionString))
                                  {
                                      connection1.Open();
                                      SqlCommand command1 = new SqlCommand(sqlExpression2, connection1);
                                      SqlDataReader reader  = command1.ExecuteReader();
                                      while (reader.Read()) Console.WriteLine($"ID: {reader.GetValue(0)}, Имя:{reader.GetValue(1)} | Фамилия: {reader.GetValue(2)} | Отчество: {reader.GetValue(3)} | Сумма кредита: {reader.GetValue(4)} | Доход:  {reader.GetValue(5)}| Кредитная история (закрытые кредиты): {reader.GetValue(6)} | Просрочка в кредитной истории {reader.GetValue(7)} | Цель кредита: {reader.GetValue(8)} ");
                                  }
                                break;
                              case 3:
                                 AdminWorking = false;
                                break;
                              default: 
                                  AdminWorking = false;
                                break;
                              
                        }
                    }
                }
              
              else Console.WriteLine("Неправильный пароль!!");break;
              case 2: 
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
              Console.Write("Сумма кредита: ");
              Console.ForegroundColor = ConsoleColor.White;
              sumOfCredit = Convert.ToDouble(Console.ReadLine());
              Console.ForegroundColor = ConsoleColor.Yellow;
              Console.Write("Доход: ");
              Console.ForegroundColor = ConsoleColor.White;
              dohod = Convert.ToDouble(Console.ReadLine());
              x = 100*dohod/sumOfCredit;
              if (x < 80) ball.Point = ball.Point+4;
              if (x >= 80 && x<150) ball.Point = ball.Point+3;
              if (x >= 150 && x<250) ball.Point = ball.Point+2;
              if (x >= 250) ball.Point = ball.Point+1;
              Console.ForegroundColor = ConsoleColor.Yellow;
              Console.WriteLine("Кредитная история (закрытые кредиты)");
              Console.Write("1->более трех закрытых кредитов: \n2-> 1-2 Закрытых кредита: \n3-> Нет кредитной истории");
              Console.ForegroundColor = ConsoleColor.White;
              creditHistoryCl = Convert.ToInt32(Console.ReadLine());
              if (creditHistoryCl == 1) 
              {
                  ball.Point = ball.Point+2;
                  creditHistoryClose = "более трех закрытых кредитов";
              }
              if (creditHistoryCl == 2) 
              {
                  ball.Point = ball.Point+1;
                  creditHistoryClose = "1-2 Закрытых кредита";
              }
              if (creditHistoryCl == 3) 
              {
                  ball.Point = ball.Point-1;
                  creditHistoryClose = "Нет кредитной истории";
              }
              Console.ForegroundColor = ConsoleColor.Yellow;
              Console.Write("Просрочка в кредитной истории: \n1-> Свыше 7 раз, \n2-> 5-7 раз, \n3->4 раза, 4-> до трех раз");
              Console.ForegroundColor = ConsoleColor.White;
              prosrochkaint =  Convert.ToInt32(Console.ReadLine());
              if (prosrochkaint == 3)
              {
                  ball.Point = ball.Point - 3;
                  prosrochkastring = "Свыше 7 раз";
              }
              if (prosrochkaint == 2)
              {
                  ball.Point = ball.Point - 2;
                  prosrochkastring  = "5-7 раз";
              }
              if (prosrochkaint == 3)
              {
                  ball.Point = ball.Point -1;
                  prosrochkastring = "4 раза";
              }
              if (prosrochkaint == 4) prosrochkastring = "до трех раз";
              Console.ForegroundColor = ConsoleColor.Yellow;
              Console.Write("Цель кредита: \n1-->Бытовая техника, \n2-->Ремонт, \n3-->Телефон, \n4-->Прочее");
              Console.ForegroundColor = ConsoleColor.White;
              selint = Convert.ToInt32(Console.ReadLine());
              if (selint == 1)
              {
                  ball.Point = ball.Point + 2;
                  selstring = "Бытовая техника";
              }
              if (selint == 2)
              {
                  ball.Point = ball.Point + 1;
                  selstring = "Ремонт";
              }
              if (selint == 3) selstring = "Телефон";
              if (selint == 4) 
              {
                  ball.Point = ball.Point - 1;
                  selstring = "Прочее";
              }
              Console.ForegroundColor = ConsoleColor.White;
              string sqlExpression1 = $"INSERT INTO AplicationForCredit ([firstName],[lastName], [middleName], [sumOfCredit], [dohod], [Credithistory], [CredithistoryPast], [cel]) VALUES ( '{firstName}', '{lastName}', '{middleName}', '{sumOfCredit}', '{dohod}', '{creditHistoryClose}', '{prosrochkastring}', '{selstring}')";
              using (SqlConnection connection = new SqlConnection(connectionString))
              {
                  connection.Open();
                  SqlCommand command = new SqlCommand(sqlExpression1, connection);
                  int number = command.ExecuteNonQuery();
                  Console.WriteLine("Добавлено объектов: {0}", number);
              }
              break;
          }
          bal = ball.Point;
        }
    }
}