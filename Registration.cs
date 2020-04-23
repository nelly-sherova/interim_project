using System;
//using System.Data;
//using System.Data.SqlClient;

namespace Project_1
{
    static class Registration
    {
        public static void Reg()
        {
          Console.ForegroundColor = ConsoleColor.Green;
          Console.WriteLine("Добро пожаловать в поле регистрации для оформления кредита!! :)");
          string AdminKey = "ad0010", key;
          string firstName, lastName, middleName, numbetOfTel, birthDay, birthMonth, birthYear, birthDate, pol, citizenship, dateOfIssue, dateOfExpiry, address, issuingAuthority, seriya;
          bool working = true;
          while (working)
          {
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
                            Console.WriteLine("Выберете действие: \n1--> Регистрация клиента, \n2-->Просмотр истории заявок");
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
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.Write("Гражданство: (tjk - Таджикистан)");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    citizenship = Console.ReadLine();
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
                                    break;

                                //default:
                            }
                            
                        }

                    }
                  break;
              }
          }
         












          /*string sqlExpression = $"INSERT INTO ___ ([FirstName],[LastName], [MiddleName]) VALUES ( '{firstName}', '{LN}', '{MN}' , '{Birthdate}')";
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();
                            SqlCommand command = new SqlCommand(sqlExpression, connection);
                            int number = command.ExecuteNonQuery();
                            Console.WriteLine("Добавлено объектов: {0}", number);
                            Console.Write("Select a command = ");
                            Console.WriteLine("Insert -> 1 \nSelect All -> 2 \nSelect by Id ->4 \nUpdate - > 5 \nDelete -> 3 \nExit ->0");
                            counter = Convert.ToInt32(Console.ReadLine());
                        }*/
        }
    }
}