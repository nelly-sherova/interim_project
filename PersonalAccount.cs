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
      Console.ForegroundColor = ConsoleColor.Green;
      Console.WriteLine("Вход в личный кабинет: ");
      Console.Write("Введите свой логин: ");
      string login  =Console.ReadLine();
      string  sqlExpressionn = $"Select * from Registration where Registration.numbetOfTel = {login}";
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
    }
    
  }
}

