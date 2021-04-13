using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SQLite;
using System.Windows;

namespace Selection_car
{
    public class Company
    {
        public int Company_Id { get; set; }
        public String Name { get; set; }
        public String Adres { get; set; }
        public int Car_Id { get; set; }
        public String Number_Phone { get; set; }
        public static object Items { get; internal set; }
        public decimal Rate { get; set; }
        public decimal Rate1 { get; set; }
        public decimal Rate2 { get; set; }
        public decimal Rate3 { get; set; }
        public decimal Rate4 { get; set; }
        public decimal Rate5 { get; set; }
        public decimal Rate6 { get; set; }
        public decimal Rate7 { get; set; }
        public String Terminate { get; set; }
        
        public static decimal ratte;

        static SQLiteConnection connection;

        public Company()
        {
            // Получение строки подключения из файла конфигурации
            var connString = ConfigurationManager.ConnectionStrings["DemoConnection"].ConnectionString;
            // Создание объекта подключения
            connection = new SQLiteConnection(connString);
        }

        static Company()
        {
            // Получение строки подключения из файла конфигурации
            var connString = ConfigurationManager.ConnectionStrings["DemoConnection"].ConnectionString;
            // Создание объекта подключения
            connection = new SQLiteConnection(connString);
        }      
        public static IEnumerable<Company> GetAllCompany2()
        {
            var commandString = "SELECT * from Companys";
            SQLiteCommand getAllCommand = new SQLiteCommand(commandString, connection);
            connection.Open();
            var reader = getAllCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var company_Id = reader.GetInt32(0);
                    var name = reader.GetString(1);
                    var adres = reader.GetString(2);
                    var number_Phone = reader.GetString(3);
                    var rate = reader.GetDecimal(4);
                    var rate1 = reader.GetDecimal(5);
                    var rate2 = reader.GetDecimal(6);
                    var rate3 = reader.GetDecimal(7);
                    var rate4 = reader.GetDecimal(8);
                    var rate5 = reader.GetDecimal(9);
                    var terminate = reader.GetString(10);
                    var rate6 = reader.GetDecimal(11);
                    var rate7 = reader.GetDecimal(12);

                    var company = new Company
                    {
                        Company_Id = company_Id,
                        Name = name,
                        Adres = adres,
                        Number_Phone = number_Phone,
                        Rate = rate,
                        Rate1=rate1,
                        Rate2 = rate2,
                        Rate3 = rate3,
                        Rate4 = rate4,
                        Rate5 = rate5,
                        Rate6=rate6,
                        Rate7=rate7,
                        Terminate = terminate
                    };
                    yield return company;
                }
            };
            connection.Close();
        }

        public static IEnumerable<Company> GetAllCompany()
        {
            var commandString = "SELECT Co.Company_Id, Co.Name, Co.Adres, Co.Number_Phone, Co.Rate, Co.Rate1, Co.Rate2, Co.Rate3, Co.Rate4, Co.Rate5, Co.Terminate, Co.Rate6,  Count(C.Car_Id), Co.Rate7 FROM Companys AS Co Join Cars AS C on C.Company_Id=Co.Company_Id GROUP BY Co.Company_Id, Co.Name, Co.Adres, Co.Number_Phone, Co.Rate, Co.Rate1, Co.Rate2, Co.Rate3, Co.Rate4, Co.Rate5, Co.Terminate, Co.Rate6, Co.Rate7";
            SQLiteCommand getAllCommand = new SQLiteCommand(commandString, connection);
            connection.Open();
            var reader = getAllCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var company_Id = reader.GetInt32(0);
                    var name = reader.GetString(1);
                    var adres = reader.GetString(2);
                    var number_Phone = reader.GetString(3);
                    var rate = reader.GetDecimal(4);
                    var rate1 = reader.GetDecimal(5);
                    var rate2 = reader.GetDecimal(6);
                    var rate3 = reader.GetDecimal(7);
                    var rate4 = reader.GetDecimal(8);
                    var rate5 = reader.GetDecimal(9);
                    var terminate = reader.GetString(10);
                    var rate6 = reader.GetDecimal(11);
                    var car_id = reader.GetInt32(12);
                    var rate7 = reader.GetDecimal(13);
                    var company = new Company
                    {
                        Company_Id = company_Id,
                        Name = name,
                        Adres = adres,
                        Number_Phone = number_Phone,
                        Rate = rate,
                        Rate1 = rate1,
                        Rate2 = rate2,
                        Rate3 = rate3,
                        Rate4 = rate4,
                        Rate5 = rate5,
                        Rate6 =rate6,
                        Rate7=rate7,
                        Terminate = terminate,
                        Car_Id = car_id
                    };
                    yield return company;
                }
            };
            connection.Close();
        }

        public static IEnumerable<Company> Company_Search()
        {
            var commandString = "SELECT * FROM Companys Where( Name ='" + MainWindowCompany.name + "')";
            SQLiteCommand getAllCommand = new SQLiteCommand(commandString, connection);
            connection.Open();
            var reader = getAllCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var company_Id = reader.GetInt32(0);
                    var name = reader.GetString(1);
                    var adres = reader.GetString(2);
                    var number_Phone = reader.GetString(3);
                    var rate = reader.GetDecimal(4);
                    var rate1 = reader.GetDecimal(5);
                    var rate2 = reader.GetDecimal(6);
                    var rate3 = reader.GetDecimal(7);
                    var rate4 = reader.GetDecimal(8);
                    var rate5 = reader.GetDecimal(9);
                    var rate6 = reader.GetDecimal(10);
                    var rate7 = reader.GetDecimal(11);
                    var company = new Company
                    {
                        Company_Id = company_Id,
                        Name = name,
                        Adres = adres,
                        Number_Phone = number_Phone,
                        Rate = rate,
                        Rate1 = rate1,
                        Rate2 = rate2,
                        Rate3 = rate3,
                        Rate4 = rate4,
                        Rate5 = rate5,
                        Rate6=rate6,
                        Rate7=rate7
                    };
                    yield return company;
                }
            };
            connection.Close();
        }

        public void Insert()
        {
            var commandString = "INSERT INTO Companys (Name, Adres, Number_Phone, Rate, Rate1, Rate2, Rate3, Rate4, Rate5, Terminate, Rate6, Rate7)" + "VALUES (@name, @adres, @number_Phone, @rate, @rate1, @rate2, @rate3, @rate4, @rate5, '1', @rate6, @rate7)";
            SQLiteCommand insertCommand = new SQLiteCommand(commandString, connection);
            insertCommand.Parameters.AddRange(new SQLiteParameter[]
                {
                       new SQLiteParameter("name", Name),
                       new SQLiteParameter("adres", Adres),
                       new SQLiteParameter("number_Phone", Number_Phone),
                       new SQLiteParameter("rate", Rate),
                       new SQLiteParameter("rate1", Rate1),
                       new SQLiteParameter("rate2", Rate2),
                       new SQLiteParameter("rate3", Rate3),
                        new SQLiteParameter("rate4", Rate4),
                         new SQLiteParameter("rate5", Rate5),
                         new SQLiteParameter("rate6", Rate6),
                         new SQLiteParameter("rate7", Rate7)
                });

            connection.Open();
            insertCommand.ExecuteNonQuery();
            connection.Close();
        }

        public void Updat() { if (Rate6 == 0) Rate6 = Rate6 + 1; }


        public void Update()
        {
            Updat();
            var commandString = "UPDATE Companys SET Name = @name, Adres = @adres, Number_Phone=@number_Phone, Rate=@rate, Rate1=@rate1, Rate2=@rate2, Rate3=@rate3, Rate4=@rate4, Rate5=@rate5, Rate6=@rate6 WHERE(Company_Id = @id)";
            SQLiteCommand updateCommand = new SQLiteCommand(commandString, connection);
            updateCommand.Parameters.AddRange(new SQLiteParameter[] {
                       new SQLiteParameter("name", Name),
                       new SQLiteParameter("adres", Adres),
                       new SQLiteParameter("number_Phone", Number_Phone),
                       new SQLiteParameter("rate", Rate),
                       new SQLiteParameter("rate1", Rate1),
                       new SQLiteParameter("rate2", Rate2),
                       new SQLiteParameter("rate3", Rate3),
                       new SQLiteParameter("rate4", Rate4),
                       new SQLiteParameter("rate5", Rate5),
                       new SQLiteParameter("rate6", Rate6),
                       new SQLiteParameter("id", Company_Id),
                });
            connection.Open();
            updateCommand.ExecuteNonQuery();
            connection.Close();
        }

        public static void Delete(int id)
        {
            var result = MessageBox.Show("Вы уверены?", "Удалить запись", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                var commandString = "DELETE FROM Companys WHERE(Company_Id = @id)";
                SQLiteCommand deleteCommand = new SQLiteCommand(commandString, connection);
                deleteCommand.Parameters.AddWithValue("id", id);
                connection.Open();
                deleteCommand.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void Clear()
        {
            this.Name = "";
            this.Adres = "";
            this.Number_Phone = "";
            this.Rate = 0;
            this.Rate1 = 0;
            this.Rate2 = 0;
            this.Rate3 = 0;
            this.Rate4 = 0;
            this.Rate5 = 0;
            this.Rate6 = 0;
            this.Rate7 = 0;
        }

        public static Company GetCompany(String name)
        {
            foreach (var company in GetAllCompany2())
            {
                if (company.Name == name)
                    return company;
            }
            return null;
        }
    }
}



