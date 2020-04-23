using System;
using System.Data;
using System.Data.SqlClient;

namespace Project_1
{
    class Registration
    {
        public int bal {get; set; }
        Points ball = new Points();
        const string connectionString = @"Data source=NILUFARSHEROVA; Initial catalog=ProjectAlifDB; Integrated Security = True";
        public void Reg()
        {
          Console.ForegroundColor = ConsoleColor.Green;
          Console.WriteLine("Добро пожаловать в поле регистрации для оформления кредита!! :)");
          string AdminKey = "ad0010", key;
          string firstName, lastName, middleName, numbetOfTel, birthDay, birthMonth, birthYear, birthDate, pol, citizenship, dateOfIssue, dateOfExpiry, address, issuingAuthority, seriya;
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
                        Console.WriteLine("Выберете действие: \n1--> Регистрация клиента, \n2-->Просмотр истории заявок на регистрацию, \n 3--> Выход");
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
                                Console.Write("Введите логин: (номер телефона): ");
                                Console.ForegroundColor = ConsoleColor.White;
                                numbetOfTel = Console.ReadLine();
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("День рождения: (dd)");
                                Console.ForegroundColor = ConsoleColor.White;
                                birthDay = Console.ReadLine();
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("Месяц рождения: (mm)");
                                Console.ForegroundColor = ConsoleColor.White;
                                birthMonth = Console.ReadLine();
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("Год рождения: (yyyy)");
                                Console.ForegroundColor = ConsoleColor.White;
                                birthYear = Console.ReadLine();
                                birthDate = birthDay+"."+birthMonth+"."+birthYear;
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("Пол: (жен, муж)");
                                Console.ForegroundColor = ConsoleColor.White;
                                pol = Console.ReadLine();
                                if (pol == "жен") ball.Point = ball.Point+2;
                                if (pol == "муж") ball.Point = ball.Point+1;
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("Гражданство: (tjk - Таджикистан)");
                                Console.ForegroundColor = ConsoleColor.White;
                                citizenship = Console.ReadLine();
                                if (citizenship == "tjk") ball.Point = ball.Point+1;
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("Дата выдачи паспорта: (dd.mm.yyyy)");
                                Console.ForegroundColor = ConsoleColor.White;
                                dateOfIssue = Console.ReadLine();
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("Дата истечения срока действия паспорта: (dd.mm.yyyy)");
                                Console.ForegroundColor = ConsoleColor.White;
                                dateOfExpiry = Console.ReadLine();
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("Адрес: ");
                                Console.ForegroundColor = ConsoleColor.White;
                                address = Console.ReadLine();
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("Орган, выдавший паспорт: ");
                                Console.ForegroundColor = ConsoleColor.White;
                                issuingAuthority = Console.ReadLine();
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("Серия паспорта: ");
                                Console.ForegroundColor = ConsoleColor.White;
                                seriya = Console.ReadLine();
                                string sqlExpression = $"INSERT INTO Registration ([FirstName],[LastName], [MiddleName], [numbetOfTel], [birthDate], [pol], [citizenship], [dateOfIssue], [dateOfExpiry], [address], [issuingAuthority], [seriya]) VALUES ( '{firstName}', '{lastName}', '{middleName}', '{numbetOfTel}', '{birthDate}','{pol}', '{citizenship}','{dateOfIssue}', '{dateOfExpiry}', '{address}', '{issuingAuthority}', '{seriya}')";
                                using (SqlConnection connection = new SqlConnection(connectionString))
                                {
                                    connection.Open();
                                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                                    int number = command.ExecuteNonQuery();
                                    Console.WriteLine("Добавлено объектов: {0}", number);
                                }
                                break;
                                case 2:
                                  Console.ForegroundColor = ConsoleColor.White;
                                  Console.WriteLine("История регистраций: ");
                                  string sqlExpression1 = "SELECT * FROM Registration";
                                  using (SqlConnection connection1 = new SqlConnection(connectionString))
                                  {
                                      connection1.Open();
                                      SqlCommand command1 = new SqlCommand(sqlExpression1, connection1);
                                      SqlDataReader reader  = command1.ExecuteReader();
                                      while (reader.Read()) Console.WriteLine($"ID: {reader.GetValue(0)}, Имя:{reader.GetValue(1)} | Фамилия:{reader.GetValue(2)} | Отчество:{reader.GetValue(3)} | Логин:{reader.GetValue(4)} | Дата рождения:{reader.GetValue(5)}| Пол: {reader.GetValue(6)} | Гражданство: {reader.GetValue(7)} | Дата выдачи паспорта: {reader.GetValue(8)} | Дата истечения срока действия паспорта: {reader.GetValue(9)} | Адрес: {reader.GetValue(10)} | Орган, выдавший паспорт {reader.GetValue(11)} | Серия паспорта: {reader.GetValue(12)}");
                                  }
                                break; 
                                case 3 :
                                    AdminWorking = false;
                                break;
                                default: 
                                    AdminWorking = false;
                                break;        
                        } 
                        }
                    }
                    else
                    {
                        Console.WriteLine("Неправильная пароль!");
                    }
                  break;
                  case 2 :
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
                     Console.Write("Введите логин: (номер телефона): ");
                     Console.ForegroundColor = ConsoleColor.White;
                     numbetOfTel = Console.ReadLine();
                     Console.ForegroundColor = ConsoleColor.Yellow;
                     Console.Write("День рождения: (dd)");
                     Console.ForegroundColor = ConsoleColor.White;
                     birthDay = Console.ReadLine();
                     Console.ForegroundColor = ConsoleColor.Yellow;
                     Console.Write("Месяц рождения: (mm)");
                     Console.ForegroundColor = ConsoleColor.White;
                     birthMonth = Console.ReadLine();
                     Console.ForegroundColor = ConsoleColor.Yellow;
                     Console.Write("Год рождения: (yyyy)");
                     Console.ForegroundColor = ConsoleColor.White;
                     birthYear = Console.ReadLine();
                     birthDate = birthDay+"."+birthMonth+"."+birthYear;
                     Console.ForegroundColor = ConsoleColor.Yellow;
                     Console.Write("Пол: (жен, муж)");
                     Console.ForegroundColor = ConsoleColor.White;
                     pol = Console.ReadLine();
                     if (pol == "жен") ball.Point = ball.Point+2;
                     if (pol == "муж") ball.Point = ball.Point+1;
                     Console.ForegroundColor = ConsoleColor.Yellow;
                     Console.Write("Гражданство: (tjk - Таджикистан)");
                     Console.ForegroundColor = ConsoleColor.White;
                     citizenship = Console.ReadLine();
                     if (citizenship == "tjk") ball.Point = ball.Point+1;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("Дата выдачи паспорта: (dd.mm.yyyy)");
                    Console.ForegroundColor = ConsoleColor.White;
                    dateOfIssue = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("Дата истечения срока действия паспорта: (dd.mm.yyyy)");
                    Console.ForegroundColor = ConsoleColor.White;
                    dateOfExpiry = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("Адрес: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    address = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("Орган, выдавший паспорт: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    issuingAuthority = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("Серия паспорта: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    seriya = Console.ReadLine();
                    string sqlExpression2 = $"INSERT INTO Registration ([FirstName],[LastName], [MiddleName], [numbetOfTel], [birthDate], [pol], [citizenship], [dateOfIssue], [dateOfExpiry], [address], [issuingAuthority], [seriya]) VALUES ( '{firstName}', '{lastName}', '{middleName}', '{numbetOfTel}', '{birthDate}','{pol}', '{citizenship}','{dateOfIssue}', '{dateOfExpiry}', '{address}', '{issuingAuthority}', '{seriya}')";
                    using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();
                            SqlCommand command = new SqlCommand(sqlExpression2, connection);
                            int number = command.ExecuteNonQuery();
                            Console.WriteLine("Добавлено объектов: {0}", number);
                        }
                    break;
          }
          bal = ball.Point;
        }
    }
}