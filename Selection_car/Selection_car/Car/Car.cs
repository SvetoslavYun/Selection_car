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
    public class Car
    {
        public int Car_Id { get; set; }
        public int Company_Id { get; set; }
        public String Name { get; set; }
        public int Nams { get; set; }
        public String Driver { get; set; }
        public String Brand { get; set; }
        public String Number { get; set; }
        public decimal Rate { get; set; }

        static SqlConnection connection;

        public Car()
        {
            // Получение строки подключения из файла конфигурации
            var connString = ConfigurationManager.ConnectionStrings["DemoConnection"].ConnectionString;
            // Создание объекта подключения
            connection = new SqlConnection(connString);
        }

        static Car()
        {
            // Получение строки подключения из файла конфигурации
            var connString = ConfigurationManager.ConnectionStrings["DemoConnection"].ConnectionString;
            // Создание объекта подключения
            connection = new SqlConnection(connString);
        }

        public override string ToString()
        {
            return String.Format($"id={Car_Id};     Организация.Id: {Company_Id};     Организация: {Name};          Водитель: {Driver};      Марка: {Brand};      Номер: {Number};      Тариф за км: {Rate}");
        }

        public static IEnumerable<Car> GetAllCar()
        {
            var commandString = "Select C.Car_Id, C.Company_Id, C.Driver, C.Brand, C.Number, C.Rate, Co.Name from Cars AS C JOIN Companys AS Co ON Co.Company_Id = C.Company_Id ";            
            SqlCommand getAllCommand = new SqlCommand(commandString, connection);
            connection.Open();
            var reader = getAllCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var car_id = reader.GetInt32(0);
                    var company_Id = reader.GetInt32(1);
                    var driver = reader.GetString(2);
                    var brand = reader.GetString(3);
                    var number = reader.GetString(4);
                    var rate = reader.GetDecimal(5);
                    var name = reader.GetString(6);
                    var car = new Car
                    {
                        Car_Id = car_id,
                        Company_Id = company_Id,
                        Name=name,
                        Driver = driver,
                        Brand = brand,
                        Number = number,
                        Rate = rate,
                    };
                    yield return car;
                }
            };
            connection.Close();
        }

        public static IEnumerable<Car> Car_Search()
        {
            var commandString = "Select C.Car_Id, C.Company_Id, C.Driver, C.Brand, C.Number, C.Rate, Co.Name from Cars AS C JOIN Companys AS Co ON Co.Company_Id = C.Company_Id Where (C.Car_Id=" + MainWindowCar._id + " or Co.Name = N'" + MainWindowCar.name + "' or C.Driver = N'" + MainWindowCar.name + "' or C.Brand = N'" + MainWindowCar.name + "' or C.Number = N'" + MainWindowCar.name + "')";
            SqlCommand getAllCommand = new SqlCommand(commandString, connection);
            connection.Open();
            var reader = getAllCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var car_id = reader.GetInt32(0);
                    var company_Id = reader.GetInt32(1);
                    var driver = reader.GetString(2);
                    var brand = reader.GetString(3);
                    var number = reader.GetString(4);
                    var rate = reader.GetDecimal(5);
                    var name = reader.GetString(6);
                    var car = new Car
                    {
                        Car_Id = car_id,
                        Company_Id = company_Id,
                        Name = name,
                        Driver = driver,
                        Brand = brand,
                        Number = number,
                        Rate = rate,
                    };
                    yield return car;
                }
            };
            connection.Close();
        }
        public void Insert()
        {
            var commandString = "INSERT INTO Cars (Company_Id, Driver, Brand, Number, Rate)" + "VALUES (@company_Id, @driver, @brand, @number, @rate)";
            SqlCommand insertCommand = new SqlCommand(commandString, connection);
            insertCommand.Parameters.AddRange(new SqlParameter[]
                {
                       new SqlParameter("company_Id", Company_Id),
                         new SqlParameter("driver", Driver),
                       new SqlParameter("brand", Brand),
                       new SqlParameter("number", Number),
                       new SqlParameter("rate", Rate),
                });

            connection.Open();
            insertCommand.ExecuteNonQuery();
            connection.Close();
        }
       
        public void Update()
        {
            var commandString = "UPDATE Cars SET Company_Id = @company_Id, Driver = @driver, Brand = @brand, Number = @number, Rate = @rate WHERE(Car_Id = @id)";
            SqlCommand updateCommand = new SqlCommand(commandString, connection);
            updateCommand.Parameters.AddRange(new SqlParameter[] {
                       new SqlParameter("company_Id",MainWindowCar._companyId),
                       new SqlParameter("driver", Driver),
                       new SqlParameter("brand", Brand),
                       new SqlParameter("number", Number),
                       new SqlParameter("rate", Rate),
                       new SqlParameter("Id",Car_Id ),
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
                var commandString = "DELETE FROM Cars WHERE(Car_id = @id)";
                SqlCommand deleteCommand = new SqlCommand(commandString, connection);
                deleteCommand.Parameters.AddWithValue("id", id);
                connection.Open();
                deleteCommand.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void Clear()
        {
            this.Company_Id = 0;

            this.Driver = "";
            this.Brand = "";
            this.Number = "";
            this.Rate = 0;
        }
    }
}



