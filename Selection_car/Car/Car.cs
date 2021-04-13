using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
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
        public String Type { get; set; }
        public decimal Rate { get; set; }
        public decimal Rate1 { get; set; }
        public decimal Rate2 { get; set; }
        public decimal Rate3 { get; set; }
        public decimal Rate4 { get; set; }
        public decimal Rate5 { get; set; }
        public decimal Trays { get; set; }
        public decimal Containers { get; set; }
        public String Fired { get; set; }
        public decimal PriceFuel { get; set; }
        public decimal СonFuel { get; set; }
        public decimal Depreciation { get; set; }
        public decimal Beltol { get; set; }

        static SQLiteConnection connection;
        public Car()
        {
            // Получение строки подключения из файла конфигурации
            var connString = ConfigurationManager.ConnectionStrings["DemoConnection"].ConnectionString;
            // Создание объекта подключения
            connection = new SQLiteConnection(connString);
        }

        static Car()
        {
            // Получение строки подключения из файла конфигурации
            var connString = ConfigurationManager.ConnectionStrings["DemoConnection"].ConnectionString;
            // Создание объекта подключения
            connection = new SQLiteConnection(connString);
        }

        public static IEnumerable<Car> GetAllCar()
        {
            var commandString = "Select C.Car_Id, C.Company_Id, C.Driver, C.Brand, C.Number, C.Type, C.Trays, C.Containers, C.Fired, Co.Name, Co.Rate, Co.Rate1, Co.Rate2, Co.Rate3, Co.Rate4, Co.Rate5, C.PriceFuel, C.СonFuel, C.Depreciation, C.Beltol from Cars AS C JOIN Companys AS Co ON Co.Company_Id = C.Company_Id ORDER BY Co.Name ASC";
            SQLiteCommand getAllCommand = new SQLiteCommand(commandString, connection);
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
                    var type = reader.GetString(5);
                    var trays = reader.GetDecimal(6);
                    var containers = reader.GetDecimal(7);
                    var fired = reader.GetString(8);
                    var name = reader.GetString(9);
                    var rate = reader.GetDecimal(10);
                    var rate1 = reader.GetDecimal(11);
                    var rate2 = reader.GetDecimal(12);
                    var rate3 = reader.GetDecimal(13);
                    var rate4 = reader.GetDecimal(14);
                    var rate5 = reader.GetDecimal(15);
                    var priceFuel = reader.GetDecimal(16);
                    var conFuel = reader.GetDecimal(17);
                    var depreciation = reader.GetDecimal(18);
                    var beltol = reader.GetDecimal(19);
                    var car = new Car
                    {
                        Car_Id = car_id,
                        Company_Id = company_Id,
                        Name=name,
                        Driver = driver,
                        Brand = brand,
                        Number = number,
                        Type = type,
                        Trays=trays,
                        Containers=containers,
                        Fired=fired,
                        Rate = rate,
                        Rate1=rate1,
                        Rate2 = rate2,
                        Rate3 = rate3,
                        Rate4 = rate4,
                        Rate5 = rate5,
                        PriceFuel = priceFuel,
                        СonFuel = conFuel,
                        Depreciation = depreciation,
                        Beltol = beltol
                    };
                    yield return car;
                }
            };
            connection.Close();
        }

        public static IEnumerable<Car> GetAllCar2()
        {
            var commandString = "Select C.Car_Id, C.Company_Id, C.Driver, C.Brand, C.Number, C.Type, C.Trays, C.Containers, C.Fired, Co.Name, Co.Rate, Co.Rate1, Co.Rate2, Co.Rate3, Co.Rate4, Co.Rate5, C.PriceFuel, C.СonFuel, C.Depreciation, C.Beltol from Cars AS C JOIN Companys AS Co ON Co.Company_Id = C.Company_Id WHERE (Co.Company_Id = " + MainWindowCar._companyId + ") ";
            SQLiteCommand getAllCommand = new SQLiteCommand(commandString, connection);
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
                    var type = reader.GetString(5);
                    var trays = reader.GetDecimal(6);
                    var containers = reader.GetDecimal(7);
                    var fired = reader.GetString(8);
                    var name = reader.GetString(9);
                    var rate = reader.GetDecimal(10);
                    var rate1 = reader.GetDecimal(11);
                    var rate2 = reader.GetDecimal(12);
                    var rate3 = reader.GetDecimal(13);
                    var rate4 = reader.GetDecimal(14);
                    var rate5 = reader.GetDecimal(15);
                    var priceFuel = reader.GetDecimal(16);
                    var conFuel = reader.GetDecimal(17);
                    var depreciation = reader.GetDecimal(18);
                    var beltol = reader.GetDecimal(19);
                    var car = new Car
                    {
                        Car_Id = car_id,
                        Company_Id = company_Id,
                        Name = name,
                        Driver = driver,
                        Brand = brand,
                        Number = number,
                        Type = type,
                        Trays = trays,
                        Containers = containers,
                        Fired = fired,
                        Rate = rate,
                        Rate1 = rate1,
                        Rate2 = rate2,
                        Rate3 = rate3,
                        Rate4 = rate4,
                        Rate5 = rate5,
                        PriceFuel = priceFuel,
                        СonFuel = conFuel,
                        Depreciation = depreciation,
                        Beltol = beltol
                    };
                    yield return car;
                }
            };
            connection.Close();
        }

        public static IEnumerable<Car> Car_Search()
        {
            var commandString = "Select C.Car_Id, C.Company_Id, C.Driver, C.Brand, C.Number, C.Type, C.Trays, C.Containers, C.Fired, Co.Name, Co.Rate, Co.Rate1, Co.Rate2, Co.Rate3, Co.Rate4, Co.Rate5, C.PriceFuel, C.СonFuel, C.Depreciation, C.Beltol from Cars AS C JOIN Companys AS Co ON Co.Company_Id = C.Company_Id Where ( Co.Name = '" + MainWindowCar.name + "' or C.Number = '" + MainWindowCar.name + "' or C.Type = '" + MainWindowCar.name + "')";
            SQLiteCommand getAllCommand = new SQLiteCommand(commandString, connection);
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
                    var type = reader.GetString(5);
                    var trays = reader.GetDecimal(6);
                    var containers = reader.GetDecimal(7);
                    var fired = reader.GetString(8);
                    var name = reader.GetString(9);
                    var rate = reader.GetDecimal(10);
                    var rate1 = reader.GetDecimal(11);
                    var rate2 = reader.GetDecimal(12);
                    var rate3 = reader.GetDecimal(13);
                    var rate4 = reader.GetDecimal(14);
                    var rate5 = reader.GetDecimal(15);
                    var priceFuel = reader.GetDecimal(16);
                    var conFuel = reader.GetDecimal(17);
                    var depreciation = reader.GetDecimal(18);
                    var beltol = reader.GetDecimal(19);
                    var car = new Car
                    {
                        Car_Id = car_id,
                        Company_Id = company_Id,
                        Name = name,
                        Driver = driver,
                        Brand = brand,
                        Number = number,
                        Type = type,
                        Trays = trays,
                        Containers = containers,
                        Fired = fired,
                        Rate = rate,
                        Rate1 = rate1,
                        Rate2 = rate2,
                        Rate3 = rate3,
                        Rate4 = rate4,
                        Rate5 = rate5,
                        PriceFuel = priceFuel,
                        СonFuel = conFuel,
                        Depreciation = depreciation,
                        Beltol = beltol
                    };
                    yield return car;
                }
            };
            connection.Close();
        }
        public void Insert()
        {
            var commandString = "INSERT INTO Cars (Company_Id, Driver, Brand, Number, Type, Trays, Containers, Fired, PriceFuel, СonFuel, Depreciation, Beltol)" + "VALUES (@company_Id, @driver, @brand, @number, @type, @trays, @containers, @fired, @priceFuel, @conFuel, @depreciation, @beltol)";
            SQLiteCommand insertCommand = new SQLiteCommand(commandString, connection);
            insertCommand.Parameters.AddRange(new SQLiteParameter[]
                {
                       new SQLiteParameter("company_Id", Company_Id),
                       new SQLiteParameter("driver", Driver),
                       new SQLiteParameter("brand", Brand),
                       new SQLiteParameter("number", Number),
                       new SQLiteParameter("type", Type),
                       new SQLiteParameter("trays", Trays),
                       new SQLiteParameter("containers", Containers),
                       new SQLiteParameter("fired", Fired),
                       new SQLiteParameter("priceFuel", PriceFuel),
                       new SQLiteParameter("conFuel", СonFuel),
                       new SQLiteParameter("depreciation", Depreciation),
                       new SQLiteParameter("beltol", Beltol),
                });

            connection.Open();
            insertCommand.ExecuteNonQuery();
            connection.Close();
        }
       
        public void Update()
        {
            var commandString = "UPDATE Cars SET  Driver = @driver, Brand = @brand, Number = @number, Type = @type, Trays=@trays, Containers=@containers, PriceFuel=@priceFuel, СonFuel=@conFuel, Depreciation=@depreciation, Beltol=@beltol  WHERE(Car_Id = @id)";
            SQLiteCommand updateCommand = new SQLiteCommand(commandString, connection);
            updateCommand.Parameters.AddRange(new SQLiteParameter[] {
                       
                       new SQLiteParameter("driver", Driver),
                       new SQLiteParameter("brand", Brand),
                       new SQLiteParameter("number", Number),
                       new SQLiteParameter("type", Type),
                       new SQLiteParameter("Id",Car_Id ),
                       new SQLiteParameter("trays", Trays),
                       new SQLiteParameter("containers",Containers),
                       new SQLiteParameter("priceFuel", PriceFuel),
                       new SQLiteParameter("conFuel", СonFuel),
                       new SQLiteParameter("depreciation", Depreciation),
                       new SQLiteParameter("beltol", Beltol),
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
                SQLiteCommand deleteCommand = new SQLiteCommand(commandString, connection);
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
            this.Type = "";
            this.Trays = 0;
            this.Containers = 0;
            this.PriceFuel = 0;
            this.СonFuel = 0;
            this.Depreciation = 0;
            this.Beltol = 0;
        }

        public static Car GetCar(String number)
        {
            foreach (var car in GetAllCar())
            {
                if (car.Number == number)
                    return car;
            }
            return null;
        }
    }
}



