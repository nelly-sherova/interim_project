using System;
using System.Data;
using System.Data.SqlClient;

namespace Project_1
{
  class PersonalAccount
  {
    public void PAccount()
    {
      const string connectionString = @"Data source=NILUFARSHEROVA; Initial catalog=ProjectAlifDB; Integrated Security = True";
      string firstName, lastName, middleName;
      Console.ForegroundColor = ConsoleColor.Green;
      Console.WriteLine("Вход в личный кабинет: ");
      Console.ForegroundColor = ConsoleColor.Yellow;
      Console.Write("Введите свой логин: ");
      Console.ForegroundColor = ConsoleColor.White;
      string login  = Console.ReadLine();
      Console.ForegroundColor = ConsoleColor.Yellow;
      Console.Write("Имя: "); 
      Console.ForegroundColor = ConsoleColor.White;
      firstName = Console.ReadLine();
      Console.ForegroundColor = ConsoleColor.Yellow;
      Console.Write("Фамилия: ");
      Console.ForegroundColor = ConsoleColor.White;
      lastName = Console.ReadLine();
      Console.ForegroundColor = ConsoleColor.Yellow;
      Console.Write("Отчество : ");
      Console.ForegroundColor = ConsoleColor.White;
      middleName = Console.ReadLine();
      Console.ForegroundColor = ConsoleColor.Green;
      Console.WriteLine("Поле регистрации: ");
      Console.ForegroundColor = ConsoleColor.White;
      string  sqlExpressionn = $"Select * from Registration where Registration.numbetOfTel = '{login}'";
      using (SqlConnection connectionn = new SqlConnection(connectionString))
      {
          connectionn.Open();
          SqlCommand commandd = new SqlCommand(sqlExpressionn, connectionn);
          var reader1 = commandd.ExecuteReader();
          while (reader1.Read())
          {
               Console.WriteLine($"ID: {reader1.GetValue(0)}, Имя:{reader1.GetValue(1)} | Фамилия:{reader1.GetValue(2)} | Отчество:{reader1.GetValue(3)} | Логин:{reader1.GetValue(4)} | Дата рождения:{reader1.GetValue(5)}| Пол: {reader1.GetValue(6)} | Гражданство: {reader1.GetValue(7)} | Дата выдачи паспорта: {reader1.GetValue(8)} | Дата истечения срока действия паспорта: {reader1.GetValue(9)} | Адрес: {reader1.GetValue(10)} | Орган, выдавший паспорт {reader1.GetValue(11)} | Серия паспорта: {reader1.GetValue(12)}");
          }
      }
      Console.ForegroundColor = ConsoleColor.Green;
      Console.WriteLine("Поле анкеты: ");
      Console.ForegroundColor = ConsoleColor.White;
      string  sqlExpression = $"Select * from Anketa where Anketa.firstName = '{firstName}'";
      using (SqlConnection connection = new SqlConnection(connectionString))
      {
          connection.Open();
          SqlCommand command = new SqlCommand(sqlExpression, connection);
          var reader = command.ExecuteReader();
          while (reader.Read())
          {
              Console.WriteLine($"ID: {reader.GetValue(0)}, Имя:{reader.GetValue(1)} | Фамилия: {reader.GetValue(2)} | Отчество: {reader.GetValue(3)} | Возраст: {reader.GetValue(4)} | Семейное положение:  {reader.GetValue(5)}");
          }
      }
      Console.ForegroundColor = ConsoleColor.Green;
      Console.WriteLine("Поле заявок: ");
      Console.ForegroundColor = ConsoleColor.White;
      string  sqlExpression1 = $"Select * from AplicationForCredit where AplicationForCredit.middleName = '{middleName}'";
      using (SqlConnection connection1 = new SqlConnection(connectionString))
      {
          connection1.Open();
          SqlCommand command1 = new SqlCommand(sqlExpression1, connection1);
          var reader2 = command1.ExecuteReader();
          while (reader2.Read())
          {
              Console.WriteLine($"ID: {reader2.GetValue(0)}, Имя:{reader2.GetValue(1)} | Фамилия: {reader2.GetValue(2)} | Отчество: {reader2.GetValue(3)} | Сумма кредита: {reader2.GetValue(4)} | Доход:  {reader2.GetValue(5)}| Кредитная история (закрытые кредиты): {reader2.GetValue(6)} | Просрочка в кредитной истории {reader2.GetValue(7)} | Цель кредита: {reader2.GetValue(8)} ");
          }
      }
    }
    
  }
}

