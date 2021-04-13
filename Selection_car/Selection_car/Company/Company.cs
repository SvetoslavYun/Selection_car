using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows;

namespace Selection_car
{
    public class Company
    {
        public int Company_Id { get; set; } 
        public String Name { get; set; }
        public String Adres { get; set; }
        public String Number_Phone { get; set; }
        public static object Items { get; internal set; }

        static SqlConnection connection;

        public Company()
        {
            // Получение строки подключения из файла конфигурации
            var connString = ConfigurationManager.ConnectionStrings["DemoConnection"].ConnectionString;
            // Создание объекта подключения
            connection = new SqlConnection(connString);
        }

        static Company()
        {
            // Получение строки подключения из файла конфигурации
            var connString = ConfigurationManager.ConnectionStrings["DemoConnection"].ConnectionString;
            // Создание объекта подключения
            connection = new SqlConnection(connString);
        }

        public override string ToString()
        {
            return String.Format($"id={Company_Id};      Организация: {Name};      Адрес: {Adres};      Телефон: {Number_Phone}");
        }

        public static IEnumerable<Company> GetAllCompany()
        {
            var commandString = "SELECT * FROM Companys";
            SqlCommand getAllCommand = new SqlCommand(commandString, connection);
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
                    var company = new Company
                    {
                        Company_Id = company_Id,
                        Name = name,
                         Adres = adres,
                         Number_Phone = number_Phone
                    };
                    yield return company;
                }
            };
            connection.Close();
        }

        public static IEnumerable<Company> Company_Search()
        {
            var commandString = "SELECT * FROM Companys Where(Company_Id=" + MainWindowCompany._id + " or Name = N'" + MainWindowCompany.name + "')";
            SqlCommand getAllCommand = new SqlCommand(commandString, connection);
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
                    var company = new Company
                    {
                        Company_Id = company_Id,
                        Name = name,
                        Adres = adres,
                        Number_Phone = number_Phone
                    };
                    yield return company;
                }
            };
            connection.Close();
        }

        public void Insert()
        {
            var commandString = "INSERT INTO Companys (Name, Adres, Number_Phone)" + "VALUES (@name, @adres, @number_Phone)";
            SqlCommand insertCommand = new SqlCommand(commandString, connection);
            insertCommand.Parameters.AddRange(new SqlParameter[]
                {
                       new SqlParameter("name", Name),
                       new SqlParameter("adres", Adres),
                       new SqlParameter("number_Phone", Number_Phone),
                });

            connection.Open();
            insertCommand.ExecuteNonQuery();
            connection.Close();
        }




        public void Update()
        {
            var commandString = "UPDATE Companys SET Name = @name, Adres = @adres, Number_Phone=@number_Phone  WHERE(Company_Id = @id)";
            SqlCommand updateCommand = new SqlCommand(commandString, connection);
            updateCommand.Parameters.AddRange(new SqlParameter[] {
                       new SqlParameter("name", Name),
                       new SqlParameter("adres", Adres),
                       new SqlParameter("number_Phone", Number_Phone),
                       new SqlParameter("Id",Company_Id ),
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
                SqlCommand deleteCommand = new SqlCommand(commandString, connection);
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
        }

       
    }
}



