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
    public class Driverr
    {
        public int Driver_Id { get; set; }
        public int Company_Id { get; set; }
        public int Car_Id { get; set; }
        public String Driver { get; set; }
        public String Name { get; set; }
        public String Number { get; set; }
        public String Phone { get; set; }
        public String Adres { get; set; }
        public String Fired { get; set; }

        static SQLiteConnection connection;

        public Driverr()
        {
            // Получение строки подключения из файла конфигурации
            var connString = ConfigurationManager.ConnectionStrings["DemoConnection"].ConnectionString;
            // Создание объекта подключения
            connection = new SQLiteConnection(connString);
        }

        static Driverr()
        {
            // Получение строки подключения из файла конфигурации
            var connString = ConfigurationManager.ConnectionStrings["DemoConnection"].ConnectionString;
            // Создание объекта подключения
            connection = new SQLiteConnection(connString);
        }

        public static IEnumerable<Driverr> GetAllDriver()
        {                                                                                               
            var commandString = "SELECT D.Driver_Id, D.Company_Id, D.Car_Id, D.Driver, D.Phone, D.Adres, Co.Name, C.Number FROM Drivers AS D Join Companys AS Co ON Co.Company_Id = D.Company_Id Join Cars AS C ON C.Car_Id = D.Car_Id";
            SQLiteCommand getAllCommand = new SQLiteCommand(commandString, connection);
            connection.Open();
            var reader = getAllCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var driver_Id = reader.GetInt32(0);
                    var company_Id = reader.GetInt32(1);
                    var car_Id = reader.GetInt32(2);
                    var driver = reader.GetString(3);
                    var phone = reader.GetString(4);
                    var adres = reader.GetString(5);
                    var name = reader.GetString(6);
                    var number = reader.GetString(7);
                    var driverr = new Driverr
                    {
                        Driver_Id = driver_Id,
                        Company_Id = company_Id,
                        Car_Id=car_Id,
                        Name=name,
                        Driver=driver,
                        Phone = phone,
                        Adres = adres,
                        Number=number
                    };
                    yield return driverr;
                }
            };
            connection.Close();
        }

        public static IEnumerable<Driverr> GetAllDriver2()
        {
            var commandString = "SELECT D.Driver_Id, D.Company_Id, D.Car_Id, D.Driver, D.Phone, D.Adres, Co.Name, C.Number FROM Drivers AS D Join Companys AS Co ON Co.Company_Id = D.Company_Id Join Cars AS C ON C.Car_Id = D.Car_Id Where C.Number= '" + MainWindowDriver.name + "' ";
            SQLiteCommand getAllCommand = new SQLiteCommand(commandString, connection);
            connection.Open();
            var reader = getAllCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var driver_Id = reader.GetInt32(0);
                    var company_Id = reader.GetInt32(1);
                    var car_Id = reader.GetInt32(2);
                    var driver = reader.GetString(3);
                    var phone = reader.GetString(4);
                    var adres = reader.GetString(5);
                    var name = reader.GetString(6);
                    var number = reader.GetString(7);
                    var driverr = new Driverr
                    {
                        Driver_Id = driver_Id,
                        Company_Id = company_Id,
                        Car_Id = car_Id,
                        Name = name,
                        Driver = driver,
                        Phone = phone,
                        Adres = adres,
                        Number = number
                    };
                    yield return driverr;
                }
            };
            connection.Close();
        }

        public static IEnumerable<Driverr> GetAllDriver3()
        {
            var commandString = "SELECT D.Driver_Id, D.Company_Id, D.Car_Id, D.Driver, D.Phone, D.Adres, Co.Name, C.Number FROM Drivers AS D Join Companys AS Co ON Co.Company_Id = D.Company_Id Join Cars AS C ON C.Car_Id = D.Car_Id Where D.Driver= '" + MainWindowDriver.name + "'";
            SQLiteCommand getAllCommand = new SQLiteCommand(commandString, connection);
            connection.Open();
            var reader = getAllCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var driver_Id = reader.GetInt32(0);
                    var company_Id = reader.GetInt32(1);
                    var car_Id = reader.GetInt32(2);
                    var driver = reader.GetString(3);
                    var phone = reader.GetString(4);
                    var adres = reader.GetString(5);
                    var name = reader.GetString(6);
                    var number = reader.GetString(7);
                    var driverr = new Driverr
                    {
                        Driver_Id = driver_Id,
                        Company_Id = company_Id,
                        Car_Id = car_Id,
                        Name = name,
                        Driver = driver,
                        Phone = phone,
                        Adres = adres,
                        Number = number
                    };
                    yield return driverr;
                }
            };
            connection.Close();
        }

        public static IEnumerable<Driverr> GetAllDriver4()
        {
            var commandString = "SELECT D.Driver_Id, D.Company_Id, D.Car_Id, D.Driver, D.Phone, D.Adres, Co.Name, C.Number FROM Drivers AS D Join Companys AS Co ON Co.Company_Id = D.Company_Id Join Cars AS C ON C.Car_Id = D.Car_Id Where Co.Name= '" + MainWindowDriver.name + "' ";
            SQLiteCommand getAllCommand = new SQLiteCommand(commandString, connection);
            connection.Open();
            var reader = getAllCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var driver_Id = reader.GetInt32(0);
                    var company_Id = reader.GetInt32(1);
                    var car_Id = reader.GetInt32(2);
                    var driver = reader.GetString(3);
                    var phone = reader.GetString(4);
                    var adres = reader.GetString(5);
                    var name = reader.GetString(6);
                    var number = reader.GetString(7);
                    var driverr = new Driverr
                    {
                        Driver_Id = driver_Id,
                        Company_Id = company_Id,
                        Car_Id = car_Id,
                        Name = name,
                        Driver = driver,
                        Phone = phone,
                        Adres = adres,
                        Number = number
                    };
                    yield return driverr;
                }
            };
            connection.Close();
        }

        public static IEnumerable<Driverr> GetAllDriver5()
        {
            var commandString = "SELECT D.Driver_Id, D.Company_Id, D.Car_Id, D.Driver, D.Phone, D.Adres, Co.Name, C.Number FROM Drivers AS D Join Companys AS Co ON Co.Company_Id = D.Company_Id Join Cars AS C ON C.Car_Id = D.Car_Id Where D.Driver_Id= '" + MainWindowDriver._driverId + "'";
            SQLiteCommand getAllCommand = new SQLiteCommand(commandString, connection);
            connection.Open();
            var reader = getAllCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var driver_Id = reader.GetInt32(0);
                    var company_Id = reader.GetInt32(1);
                    var car_Id = reader.GetInt32(2);
                    var driver = reader.GetString(3);
                    var phone = reader.GetString(4);
                    var adres = reader.GetString(5);
                    var name = reader.GetString(6);
                    var number = reader.GetString(7);
                    var driverr = new Driverr
                    {
                        Driver_Id = driver_Id,
                        Company_Id = company_Id,
                        Car_Id = car_Id,
                        Name = name,
                        Driver = driver,
                        Phone = phone,
                        Adres = adres,
                        Number = number
                    };
                    yield return driverr;
                }
            };
            connection.Close();
        }

        public static IEnumerable<Driverr> GetAllDriver6()
        {
            var commandString = "SELECT D.Driver_Id, D.Company_Id, D.Car_Id, D.Driver, D.Phone, D.Adres, Co.Name, C.Number FROM Drivers AS D Join Companys AS Co ON Co.Company_Id = D.Company_Id Join Cars AS C ON C.Car_Id = D.Car_Id Where Co.Company_Id= '" + MainWindowDriver._companyId + "'";
            SQLiteCommand getAllCommand = new SQLiteCommand(commandString, connection);
            connection.Open();
            var reader = getAllCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var driver_Id = reader.GetInt32(0);
                    var company_Id = reader.GetInt32(1);
                    var car_Id = reader.GetInt32(2);
                    var driver = reader.GetString(3);
                    var phone = reader.GetString(4);
                    var adres = reader.GetString(5);
                    var name = reader.GetString(6);
                    var number = reader.GetString(7);
                    var driverr = new Driverr
                    {
                        Driver_Id = driver_Id,
                        Company_Id = company_Id,
                        Car_Id = car_Id,
                        Name = name,
                        Driver = driver,
                        Phone = phone,
                        Adres = adres,
                        Number = number
                    };
                    yield return driverr;
                }
            };
            connection.Close();
        }
        public void Insert()
        {
            var commandString = "INSERT INTO Drivers (Company_Id, Car_Id, Driver, Phone, Adres, Fired)" + "VALUES (@company_Id, @car_Id, @driver, @phone, @adres, @fired)";
            SQLiteCommand insertCommand = new SQLiteCommand(commandString, connection);
            insertCommand.Parameters.AddRange(new SQLiteParameter[]
                {
                       new SQLiteParameter("company_Id", Company_Id),
                       new SQLiteParameter("car_Id", Car_Id),
                       new SQLiteParameter("driver", Driver),
                       new SQLiteParameter("phone", Phone),
                       new SQLiteParameter("adres", Adres),
                       new SQLiteParameter("fired", Fired)
                });

            connection.Open();
            insertCommand.ExecuteNonQuery();
            connection.Close();
        }


      

        public void Update()
        {
            var commandString = "UPDATE Drivers SET Company_Id=@company_Id, Car_Id=@car_Id, Driver = @driver, Phone = @phone, Adres = @adres WHERE(Driver_Id = @id)";
            SQLiteCommand updateCommand = new SQLiteCommand(commandString, connection);
            updateCommand.Parameters.AddRange(new SQLiteParameter[] {
                       new SQLiteParameter("company_Id", Company_Id),
                       new SQLiteParameter("car_Id", Car_Id),
                       new SQLiteParameter("driver", Driver),
                       new SQLiteParameter("phone", Phone),
                       new SQLiteParameter("adres", Adres),
                       new SQLiteParameter("Id",Driver_Id )
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
                var commandString = "DELETE FROM Drivers WHERE(Driver_Id = @id)";
                SQLiteCommand deleteCommand = new SQLiteCommand(commandString, connection);
                deleteCommand.Parameters.AddWithValue("id", id);
                connection.Open();
                deleteCommand.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void Clear()
        {
            this.Driver = "";
            this.Phone= "";
            this.Adres = "";
        }

        public static Driverr GetDriver(String name)
        {
            foreach (var driver in GetAllDriver())
            {
                if (driver.Driver == name)
                    return driver;
            }
            return null;
        }
    }
}



