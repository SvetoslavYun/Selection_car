using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.Windows;

namespace Selection_car
{
    public class Calculator
    {
        public int OrderCar_Id { get; set; }
        public String Data { get; set; }
        public String Data2 { get; set; }
        public String Are { get; set; }
        public int Car_Id { get; set; }
        public String AreName { get; set; }
        public int Company_Id { get; set; }
        public int CountCars { get; set; }
        public String Name { get; set; }
        public String Namee { get; set; }
        public String Driver { get; set; }
        public String Brand { get; set; }
        public String Number { get; set; }
        public String Type { get; set; }
        public decimal Shops { get; set; }
        public decimal Tonnage { get; set; }
        public decimal Mileage { get; set; }
        public decimal Earned { get; set; }
        public decimal Expenses { get; set; }
        public decimal Profit { get; set; }
        public decimal Freight { get; set; }
        public decimal Profitability { get; set; }
        public String Terminate { get; set; }
        public  decimal Rate { get; set; }

        static SQLiteConnection connection;

        public Calculator()
        {
            // Получение строки подключения из файла конфигурации
            var connString = ConfigurationManager.ConnectionStrings["DemoConnection"].ConnectionString;
            // Создание объекта подключения
            connection = new SQLiteConnection(connString);
        }

        static Calculator()
        {
            // Получение строки подключения из файла конфигурации
            var connString = ConfigurationManager.ConnectionStrings["DemoConnection"].ConnectionString;
            // Создание объекта подключения
            connection = new SQLiteConnection(connString);
        }

        public override string ToString()
        {
            return String.Format($"{Shops}");
        }

        public static IEnumerable<Calculator> GetAllOrder_2()
        {
            var commandString = "Select  O.Driver, " + CalculatorWindow.type + "(rtrim(rtrim(round(O.Shops, 2), '0'), '.')), " + CalculatorWindow.type + "(rtrim(rtrim(round(O.Tonnage, 2), '0'), '.')), " + CalculatorWindow.type + "(rtrim(rtrim(round(O.Mileage, 2), '0'), '.')), " + CalculatorWindow.type + "(rtrim(rtrim(round(O.Freight, 2), '0'), '.')), " + CalculatorWindow.type + "(rtrim(rtrim(round(O.Earned, 2), '0'), '.')), " + CalculatorWindow.type + "(rtrim(rtrim(round(O.Expenses, 2), '0'), '.')), " + CalculatorWindow.type + "(rtrim(rtrim(round(O.Profit, 2), '0'), '.')), avg(rtrim(rtrim(round(O.Profitability, 2), '0'), '.')) from OrderCars AS O JOIN Cars AS C ON C.Car_Id = O.Car_Id JOIN Companys AS Co ON Co.Company_Id = O.Company_Id WHERE " + CalculatorWindow.RadioВuten + " " + CalculatorWindow.type2 + "";
            SQLiteCommand getAllCommand = new SQLiteCommand(commandString, connection);
            connection.Open();
            var reader = getAllCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var name = reader.GetString(0);
                    var shops = reader.GetDecimal(1);
                    var tonnage = reader.GetDecimal(2);
                    var mileage = reader.GetDecimal(3);
                    var freight = reader.GetDecimal(4);
                    var earned = reader.GetDecimal(5);
                    var expenses = reader.GetDecimal(6);
                    var profit = reader.GetDecimal(7);
                    var profitability = reader.GetDecimal(8);
                    var calculator = new Calculator
                    {
                        Name=name,
                        Shops = shops,
                        Tonnage = tonnage,
                        Mileage = mileage,
                        Freight = freight,
                        Earned = earned,
                        Expenses = expenses,
                        Profit = profit,
                        Profitability = profitability
                    };
                    yield return calculator;
                }
            };
            connection.Close();
        }
        public static IEnumerable<Calculator> GetAllOrder_1()
        {
            var commandString = "Select " + CalculatorWindow.type + "(rtrim(rtrim(round(O.Shops, 2), '0'), '.')), " + CalculatorWindow.type + "(rtrim(rtrim(round(O.Tonnage, 2), '0'), '.')), " + CalculatorWindow.type + "(rtrim(rtrim(round(O.Mileage, 2), '0'), '.')), " + CalculatorWindow.type + "(rtrim(rtrim(round(O.Freight, 2), '0'), '.')), " + CalculatorWindow.type + "(rtrim(rtrim(round(O.Earned, 2), '0'), '.')), " + CalculatorWindow.type + "(rtrim(rtrim(round(O.Expenses, 2), '0'), '.')), " + CalculatorWindow.type + "(rtrim(rtrim(round(O.Profit, 2), '0'), '.')), avg(rtrim(rtrim(round(O.Profitability, 2), '0'), '.')) from OrderCars AS O JOIN Cars AS C ON C.Car_Id = O.Car_Id JOIN Companys AS Co ON Co.Company_Id = O.Company_Id WHERE " + CalculatorWindow.RadioВuten + " " + CalculatorWindow.type2 + "";
            SQLiteCommand getAllCommand = new SQLiteCommand(commandString, connection);
            connection.Open();
            var reader = getAllCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var shops = reader.GetDecimal(0);
                    var tonnage = reader.GetDecimal(1);
                    var mileage = reader.GetDecimal(2);
                    var freight = reader.GetDecimal(3);
                    var earned = reader.GetDecimal(4);
                    var expenses = reader.GetDecimal(5);
                    var profit = reader.GetDecimal(6);
                    var profitability = reader.GetDecimal(7);
                    var calculator = new Calculator
                    {
                        Shops = shops,
                        Tonnage=tonnage,
                        Mileage=mileage,
                        Freight=freight,
                        Earned=earned,
                        Expenses=expenses,
                        Profit=profit,
                        Profitability=profitability
                    };
                    yield return calculator;
                }
            };
            connection.Close();
        }
 
        public static IEnumerable<Calculator> GetAllOrder()
        {
            var commandString = "Select O.OrderCar_Id, O.Data2, O.Are, C.Car_Id, C.Company_Id, O.Driver, C.Brand, C.Number, C.Type, Co.Name, O.Shops, O.Tonnage, O.Mileage, rtrim(rtrim(round(O.Earned, 2), '0'), '.'), rtrim(rtrim(round(O.Expenses, 1), '0'), '.'), rtrim(rtrim(round(O.Profit, 2), '0'), '.'), O.Freight, rtrim(rtrim(round(O.Profitability, 2), '0'), '.') from OrderCars AS O JOIN Cars AS C ON C.Car_Id = O.Car_Id JOIN Companys AS Co ON Co.Company_Id = C.Company_Id WHERE O.Data2='" + CalculatorWindow.datatime + "' AND (Co.Name ='" + CalculatorWindow.CompanyName + "' " + CalculatorWindow.type2 + ")";
            SQLiteCommand getAllCommand = new SQLiteCommand(commandString, connection);
            connection.Open();
            var reader = getAllCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var orderCar_Id = reader.GetInt32(0);
                    var data2 = reader.GetString(1);
                    var are = reader.GetString(2);
                    var car_id = reader.GetInt32(3);
                    var company_Id = reader.GetInt32(4);
                    var driver = reader.GetString(5);
                    var brand = reader.GetString(6);
                    var number = reader.GetString(7);
                    var type = reader.GetString(8);
                    var name = reader.GetString(9);
                    var shops = reader.GetDecimal(10);
                    var tonnage = reader.GetDecimal(11);
                    var mileage = reader.GetDecimal(12);
                    var earned = reader.GetDecimal(13);
                    var expenses = reader.GetDecimal(14);
                    var profit = reader.GetDecimal(15);
                    var freight = reader.GetDecimal(16);
                    var profitability = reader.GetDecimal(17);
                    var calculator = new Calculator
                    {
                        OrderCar_Id = orderCar_Id,
                        Data2 = data2,
                        Are = are,
                        Car_Id = car_id,
                        Company_Id = company_Id,
                        Name = name,
                        Driver = driver,
                        Brand = brand,
                        Number = number,
                        Type = type,
                        Shops = shops,
                        Tonnage = tonnage,
                        Mileage = mileage,
                        Earned = earned,
                        Expenses = expenses,
                        Profit = profit,
                        Freight = freight,
                        Profitability = profitability
                    };
                    yield return calculator;
                }
            };
            connection.Close();
        }     
       
        public static IEnumerable<Calculator> GetAllOrder3()
        {
            var commandString = "Select O.OrderCar_Id, O.Data, O.Data2, O.Are, C.Car_Id, C.Company_Id, O.Driver, C.Brand, C.Number, C.Type, Co.Name, Co.Terminate, O.Shops, O.Tonnage, O.Mileage, rtrim(rtrim(round(O.Earned, 2), '0'), '.'), rtrim(rtrim(round(O.Expenses, 2), '0'), '.'), rtrim(rtrim(round(O.Profit, 2), '0'), '.'), O.Freight, rtrim(rtrim(round(O.Profitability, 2), '0'), '.') from OrderCars AS O JOIN Cars AS C ON C.Car_Id = O.Car_Id JOIN Companys AS Co ON Co.Company_Id = C.Company_Id WHERE O.Data  BETWEEN " + CalculatorWindow.datatime2 +" ORDER BY O.Data ASC";
            SQLiteCommand getAllCommand = new SQLiteCommand(commandString, connection);
            connection.Open();
            var reader = getAllCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var orderCar_Id = reader.GetInt32(0);
                    var data = reader.GetString(1);
                    var data2 = reader.GetString(2);
                    var are = reader.GetString(3);
                    var car_id = reader.GetInt32(4);
                    var company_Id = reader.GetInt32(5);
                    var driver = reader.GetString(6);
                    var brand = reader.GetString(7);
                    var number = reader.GetString(8);
                    var type = reader.GetString(9);
                    var name = reader.GetString(10);
                    var terminate = reader.GetString(11);
                    var shops = reader.GetDecimal(12);
                    var tonnage = reader.GetDecimal(13);
                    var mileage = reader.GetDecimal(14);
                    var earned = reader.GetDecimal(15);
                    var expenses = reader.GetDecimal(16);
                    var profit = reader.GetDecimal(17);
                    var freight = reader.GetDecimal(18);
                    var profitability = reader.GetDecimal(19);
                    var calculator = new Calculator
                    {
                        OrderCar_Id = orderCar_Id,
                        Data=data,
                        Data2 = data2,
                        Are = are,
                        Car_Id = car_id,
                        Company_Id = company_Id,
                        Name = name,
                        Terminate = terminate,
                        Driver = driver,
                        Brand = brand,
                        Number = number,
                        Type = type,
                        Shops = shops,
                        Tonnage = tonnage,
                        Mileage = mileage,
                        Earned = earned,
                        Expenses = expenses,
                        Profit = profit,
                        Freight = freight,
                        Profitability = profitability
                    };
                    yield return calculator;
                }
            };
            connection.Close();
        }

        public static IEnumerable<Calculator> GetAllOrder4()
        {
            var commandString = "Select O.OrderCar_Id, O.Data2, O.Are, C.Car_Id, C.Company_Id, O.Driver, C.Brand, C.Number, C.Type, Co.Name, O.Shops, O.Tonnage, O.Mileage, rtrim(rtrim(round(O.Earned, 2), '0'), '.'), rtrim(rtrim(round(O.Expenses, 2), '0'), '.'), rtrim(rtrim(round(O.Profit, 2), '0'), '.'), O.Freight, rtrim(rtrim(round(O.Profitability, 2), '0'), '.') from OrderCars AS O JOIN Cars AS C ON C.Car_Id = O.Car_Id JOIN Companys AS Co ON Co.Company_Id = C.Company_Id WHERE Co.Name='Never3876'";
            SQLiteCommand getAllCommand = new SQLiteCommand(commandString, connection);
            connection.Open();
            var reader = getAllCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var orderCar_Id = reader.GetInt32(0);
                    var data2 = reader.GetString(1);
                    var are = reader.GetString(2);
                    var car_id = reader.GetInt32(3);
                    var company_Id = reader.GetInt32(4);
                    var driver = reader.GetString(5);
                    var brand = reader.GetString(6);
                    var number = reader.GetString(7);
                    var type = reader.GetString(8);
                    var name = reader.GetString(9);
                    var shops = reader.GetDecimal(10);
                    var tonnage = reader.GetDecimal(11);
                    var mileage = reader.GetDecimal(12);
                    var earned = reader.GetDecimal(13);
                    var expenses = reader.GetDecimal(14);
                    var profit = reader.GetDecimal(15);
                    var freight = reader.GetDecimal(16);
                    var profitability = reader.GetDecimal(17);
                    var calculator = new Calculator
                    {
                        OrderCar_Id = orderCar_Id,
                        Data2 = data2,
                        Are = are,
                        Car_Id = car_id,
                        Company_Id = company_Id,
                        Name = name,
                        Driver = driver,
                        Brand = brand,
                        Number = number,
                        Type = type,
                        Shops = shops,
                        Tonnage = tonnage,
                        Mileage = mileage,
                        Earned = earned,
                        Expenses = expenses,
                        Profit = profit,
                        Freight = freight,
                        Profitability = profitability
                    };
                    yield return calculator;
                }
            };
            connection.Close();
        }

        public static IEnumerable<Calculator> GetAllOrder5()
        {
            var commandString = "Select Co.Name, " + CalculatorWindow.type + "(rtrim(rtrim(round(O.Shops, 2), '0'), '.')), " + CalculatorWindow.type + "(rtrim(rtrim(round(O.Tonnage, 2), '0'), '.')), " + CalculatorWindow.type + "(rtrim(rtrim(round(O.Mileage, 2), '0'), '.')), " + CalculatorWindow.type + "(rtrim(rtrim(round(O.Freight, 2), '0'), '.')), " + CalculatorWindow.type + "(rtrim(rtrim(round(O.Earned, 2), '0'), '.')), " + CalculatorWindow.type + "(rtrim(rtrim(round(O.Expenses, 2), '0'), '.')), " + CalculatorWindow.type + "(rtrim(rtrim(round(O.Profit, 2), '0'), '.')), avg(rtrim(rtrim(round(O.Profitability, 2), '0'), '.')),rtrim(rtrim(round(((rtrim(rtrim(round(Rate, 2), '0'), '.') + 95.1)/ Co.Rate6)*" + CalculatorWindow.type + "(O.Earned)/100, 2), '0'), '.')   from OrderCars AS O JOIN Cars AS C ON C.Car_Id = O.Car_Id JOIN Companys AS Co ON Co.Company_Id = C.Company_Id WHERE O.Data2='" + CalculatorWindow.datatime + "' AND (Co.Name ='" + CalculatorWindow.CompanyName + "' " + CalculatorWindow.type2 + ")";
            SQLiteCommand getAllCommand = new SQLiteCommand(commandString, connection);
            connection.Open();
            var reader = getAllCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                   
                    var name = reader.GetString(0);
                    var shops = reader.GetDecimal(1);
                    var tonnage = reader.GetDecimal(2);
                    var mileage = reader.GetDecimal(3);
                    var freight = reader.GetDecimal(4);
                    var earned = reader.GetDecimal(5);
                    var expenses = reader.GetDecimal(6);
                    var profit = reader.GetDecimal(7);
                    var profitability = reader.GetDecimal(8);
                    var rate = reader.GetDecimal(9);
                    var calculator = new Calculator
                    {                                            
                        Name = name,                 
                        Shops = shops,
                        Tonnage = tonnage,
                        Mileage = mileage,
                        Earned = earned,
                        Expenses = expenses,
                        Profit = profit,
                        Freight = freight,
                        Rate=rate,
                        Profitability = profitability
                    };
                    yield return calculator;
                }
            };
            connection.Close();
        }

        public static IEnumerable<Calculator> GetAllOrder6()
        {
            var commandString = "Select   Co.Name, " + CalculatorWindow.type + "(rtrim(rtrim(round(O.Shops, 2), '0'), '.')), " + CalculatorWindow.type + "(rtrim(rtrim(round(O.Tonnage, 2), '0'), '.')), " + CalculatorWindow.type + "(rtrim(rtrim(round(O.Mileage, 2), '0'), '.')), " + CalculatorWindow.type + "(rtrim(rtrim(round(O.Freight, 2), '0'), '.')), " + CalculatorWindow.type + "(rtrim(rtrim(round(O.Earned, 2), '0'), '.')), " + CalculatorWindow.type + "(rtrim(rtrim(round(O.Expenses, 2), '0'), '.')), " + CalculatorWindow.type + "(rtrim(rtrim(round(O.Profit, 2), '0'), '.')), avg(rtrim(rtrim(round(O.Profitability, 2), '0'), '.')),rtrim(rtrim(round(((rtrim(rtrim(round(Rate, 2), '0'), '.') + 95.1)/ Co.Rate6)*" + CalculatorWindow.type + "(O.Earned)/100, 2), '0'), '.')   from OrderCars AS O JOIN Cars AS C ON C.Car_Id = O.Car_Id JOIN Companys AS Co ON Co.Company_Id = C.Company_Id WHERE O.Data  BETWEEN " + CalculatorWindow.datatime2 + " GROUP BY Co.Name";
            SQLiteCommand getAllCommand = new SQLiteCommand(commandString, connection);
            connection.Open();
            var reader = getAllCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    var name = reader.GetString(0);
                    var shops = reader.GetDecimal(1);
                    var tonnage = reader.GetDecimal(2);
                    var mileage = reader.GetDecimal(3);
                    var freight = reader.GetDecimal(4);
                    var earned = reader.GetDecimal(5);
                    var expenses = reader.GetDecimal(6);
                    var profit = reader.GetDecimal(7);
                    var profitability = reader.GetDecimal(8);
                    var rate = reader.GetDecimal(9);
                    var calculator = new Calculator
                    {
                        Name = name,
                        Shops = shops,
                        Tonnage = tonnage,
                        Mileage = mileage,
                        Earned = earned,
                        Expenses = expenses,
                        Profit = profit,
                        Freight = freight,
                        Rate=rate,
                        Profitability = profitability
                    };
                    yield return calculator;
                }
            };
            connection.Close();
        }

        public static IEnumerable<Calculator> GetAllOrder7()
        {
            var commandString = "Select Co.Name, O.Driver, " + CalculatorWindow.type + "(rtrim(rtrim(round(O.Shops, 2), '0'), '.')), " + CalculatorWindow.type + "(rtrim(rtrim(round(O.Tonnage, 2), '0'), '.')), " + CalculatorWindow.type + "(rtrim(rtrim(round(O.Mileage, 2), '0'), '.')), " + CalculatorWindow.type + "(rtrim(rtrim(round(O.Freight, 2), '0'), '.')), " + CalculatorWindow.type + "(rtrim(rtrim(round(O.Earned, 2), '0'), '.')), " + CalculatorWindow.type + "(rtrim(rtrim(round(O.Expenses, 2), '0'), '.')), " + CalculatorWindow.type + "(rtrim(rtrim(round(O.Profit, 2), '0'), '.')), avg(rtrim(rtrim(round(O.Profitability, 2), '0'), '.')),rtrim(rtrim(round(((rtrim(rtrim(round(Rate, 2), '0'), '.') + 95.1)/ Co.Rate6)*(" + CalculatorWindow.type + "(O.Earned)/100), 2), '0'), '.')   from OrderCars AS O JOIN Cars AS C ON C.Car_Id = O.Car_Id JOIN Companys AS Co ON Co.Company_Id = C.Company_Id WHERE O.Data  BETWEEN " + CalculatorWindow.datatime2 + " GROUP BY O.Driver";
            SQLiteCommand getAllCommand = new SQLiteCommand(commandString, connection);
            connection.Open();
            var reader = getAllCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    var name = reader.GetString(0);
                    var driver = reader.GetString(1);
                    var shops = reader.GetDecimal(2);
                    var tonnage = reader.GetDecimal(3);
                    var mileage = reader.GetDecimal(4);
                    var freight = reader.GetDecimal(5);
                    var earned = reader.GetDecimal(6);
                    var expenses = reader.GetDecimal(7);
                    var profit = reader.GetDecimal(8);
                    var profitability = reader.GetDecimal(9);
                    var rate = reader.GetDecimal(10);
                    var calculator = new Calculator
                    {
                        Name = name,
                        Shops = shops,
                        Tonnage = tonnage,
                        Mileage = mileage,
                        Earned = earned,
                        Expenses = expenses,
                        Profit = profit,
                        Freight = freight,
                        Driver = driver,
                        Rate=rate,
                        Profitability = profitability
                    };
                    yield return calculator;
                }
            };
            connection.Close();
        }
        public void Update()
        {
            var commandString = "UPDATE OrderCars SET  Shops = @shops, Tonnage=@tonnage, Mileage = @mileage, Earned = (@shops) * (SELECT Rate2 from Companys where Name ='" + CalculatorWindow.CompanyName + "'), Expenses=(Mileage*(SELECT PriceFuel*(СonFuel/100) from Cars where Car_Id=@id2))+((SELECT Depreciation from Cars where Car_Id=@id2)*Mileage), Profit=Earned - Expenses, Freight = @freight, Profitability =100-(Earned/(@freight+0.001)) * 100 WHERE(OrderCar_Id = @id)";
            SQLiteCommand updateCommand = new SQLiteCommand(commandString, connection);
            updateCommand.Parameters.AddRange(new SQLiteParameter[] {
                       new SQLiteParameter("shops", Shops),
                       new SQLiteParameter("tonnage", Tonnage),
                       new SQLiteParameter("mileage", Mileage),
                       new SQLiteParameter("earned", Earned),
                       new SQLiteParameter("expenses", Expenses),
                       new SQLiteParameter("profit", Profit),
                       new SQLiteParameter("Id",OrderCar_Id ),
                       new SQLiteParameter("Id2",Car_Id ),
                       new SQLiteParameter("profitability", Profitability),
                       new SQLiteParameter("freight",Freight ),
                });
            connection.Open();
            updateCommand.ExecuteNonQuery();
            connection.Close();
        } 
       

        public void Update2()
        {
            cb_Selected();
            var commandString = "UPDATE OrderCars SET  Shops = @shops, Tonnage=@tonnage, Mileage = @mileage, Earned = @mileage * (SELECT Rate3 from Companys where Name ='" + CalculatorWindow.CompanyName + "'), Expenses=(Mileage*(SELECT PriceFuel*(СonFuel/100) from Cars where Car_Id=@id2))+(((SELECT Depreciation from Cars where Car_Id=@id2)*Mileage)+((SELECT Beltol from Cars where Car_Id=@id2)*(SELECT BelTol from Areas where Are=@are))), Profit=Earned - Expenses, Freight = @freight, Profitability =100-(Earned/(@freight+0.001)) * 100  WHERE(OrderCar_Id = @id)";
            SQLiteCommand updateCommand = new SQLiteCommand(commandString, connection);
            updateCommand.Parameters.AddRange(new SQLiteParameter[] {
                       new SQLiteParameter("shops", Shops),
                       new SQLiteParameter("tonnage", Tonnage),
                       new SQLiteParameter("mileage", Mileage),
                       new SQLiteParameter("earned", Earned),
                       new SQLiteParameter("expenses", Expenses),
                       new SQLiteParameter("profit", Profit),
                       new SQLiteParameter("Id",OrderCar_Id ),
                       new SQLiteParameter("Id2",Car_Id ),
                       new SQLiteParameter("profitability", Profitability),
                       new SQLiteParameter("freight",Freight ),
                       new SQLiteParameter("are",AreName ),
                });
            connection.Open();
            updateCommand.ExecuteNonQuery();
            connection.Close();
        }

        public void Update3()
        {
            var commandString = "UPDATE OrderCars SET  Shops = @shops, Tonnage=@tonnage, Mileage = @mileage, Earned = ((SELECT Rate from Companys where Name ='" + CalculatorWindow.CompanyName + "') * (Shops))+(((SELECT Rate1 from Companys where Name ='" + CalculatorWindow.CompanyName + "')/1000)*Tonnage), Expenses=(Mileage*(SELECT PriceFuel*(СonFuel/100) from Cars where Car_Id=@id2))+((SELECT Depreciation from Cars where Car_Id=@id2)*Mileage), Profit=Earned - Expenses, Freight = @freight, Profitability =100-(Earned/(@freight+0.001)) * 100  WHERE(OrderCar_Id = @id)";
            SQLiteCommand updateCommand = new SQLiteCommand(commandString, connection);
            updateCommand.Parameters.AddRange(new SQLiteParameter[] {
                       new SQLiteParameter("shops", Shops),
                       new SQLiteParameter("tonnage", Tonnage),
                       new SQLiteParameter("mileage", Mileage),
                       new SQLiteParameter("earned", Earned),
                       new SQLiteParameter("expenses", Expenses),
                       new SQLiteParameter("profit", Profit),
                       new SQLiteParameter("Id",OrderCar_Id ),
                       new SQLiteParameter("Id2",Car_Id ),
                       new SQLiteParameter("profitability", Profitability),
                       new SQLiteParameter("freight",Freight ),
                });
            connection.Open();
            updateCommand.ExecuteNonQuery();
            connection.Close();
        }

        public void Update4()
        {
            cb_Selected();
            var commandString = "UPDATE OrderCars SET  Shops = @shops, Tonnage=@tonnage, Mileage = @mileage, Earned = (((@shops) * (SELECT Rate2 from Companys where Name ='" + CalculatorWindow.CompanyName + "')))*(SELECT Rate4 from Companys where Name ='" + CalculatorWindow.CompanyName + "'), Expenses=(Mileage*(SELECT PriceFuel*(СonFuel/100) from Cars where Car_Id=@id2))+(((SELECT Depreciation from Cars where Car_Id=@id2)*Mileage)+((SELECT Beltol from Cars where Car_Id=@id2)*(SELECT BelTol from Areas where Are=@are))), Profit=Earned - Expenses, Freight = @freight, Profitability =100-(Earned/(@freight+0.001)) * 100 WHERE(OrderCar_Id = @id)";
            SQLiteCommand updateCommand = new SQLiteCommand(commandString, connection);
            updateCommand.Parameters.AddRange(new SQLiteParameter[] {
                       new SQLiteParameter("shops", Shops),
                       new SQLiteParameter("tonnage", Tonnage),
                       new SQLiteParameter("mileage", Mileage),
                       new SQLiteParameter("earned", Earned),
                       new SQLiteParameter("expenses", Expenses),
                       new SQLiteParameter("profit", Profit),
                       new SQLiteParameter("Id",OrderCar_Id ),
                       new SQLiteParameter("Id2",Car_Id ),
                       new SQLiteParameter("profitability", Profitability),
                       new SQLiteParameter("freight",Freight ),
                       new SQLiteParameter("are",AreName ),
                });
            connection.Open();
            updateCommand.ExecuteNonQuery();
            connection.Close();
        }

        public void Update5()
        {                                                                                                     
            cb_Selected();
            var commandString = "UPDATE OrderCars SET  Shops = @shops, Tonnage=@tonnage, Mileage = @mileage, Earned = (((SELECT Rate from Companys where Name ='" + CalculatorWindow.CompanyName + "') * (Shops))+(((SELECT Rate1 from Companys where Name ='" + CalculatorWindow.CompanyName + "')/1000)*Tonnage))*(SELECT Rate4 from Companys where Name ='" + CalculatorWindow.CompanyName + "'), Expenses=(Mileage*(SELECT PriceFuel*(СonFuel/100) from Cars where Car_Id=@id2))+(((SELECT Depreciation from Cars where Car_Id=@id2)*Mileage)+((SELECT Beltol from Cars where Car_Id=@id2)*(SELECT BelTol from Areas where Are=@are))), Profit=Earned - Expenses, Freight = @freight, Profitability =100-(Earned/(@freight+0.001)) * 100  WHERE(OrderCar_Id = @id)";
            SQLiteCommand updateCommand = new SQLiteCommand(commandString, connection);
            updateCommand.Parameters.AddRange(new SQLiteParameter[] {
                       new SQLiteParameter("shops", Shops),
                       new SQLiteParameter("tonnage", Tonnage),
                       new SQLiteParameter("mileage", Mileage),
                       new SQLiteParameter("earned", Earned),
                       new SQLiteParameter("expenses", Expenses),
                       new SQLiteParameter("profit", Profit),
                       new SQLiteParameter("Id",OrderCar_Id ),
                       new SQLiteParameter("Id2",Car_Id ),
                       new SQLiteParameter("profitability", Profitability),
                       new SQLiteParameter("freight",Freight ),
                       new SQLiteParameter("are",AreName ),
                });
            connection.Open();
            updateCommand.ExecuteNonQuery();
            connection.Close();
        }

        public void Update6()
        {
            cb_Selected();
            var commandString = "UPDATE OrderCars SET  Shops = @shops, Tonnage=@tonnage, Mileage = @mileage, Earned = @mileage * (SELECT Rate5 from Companys where Name ='" + CalculatorWindow.CompanyName + "'), Expenses=(Mileage*(SELECT PriceFuel*(СonFuel/100) from Cars where Car_Id=@id2))+(((SELECT Depreciation from Cars where Car_Id=@id2)*Mileage)+((SELECT Beltol from Cars where Car_Id=@id2)*(SELECT BelTol from Areas where Are=@are))), Profit=Earned - Expenses, Freight = @freight, Profitability =100-(Earned/(@freight+0.001)) * 100  WHERE(OrderCar_Id = @id)";
            SQLiteCommand updateCommand = new SQLiteCommand(commandString, connection);
            updateCommand.Parameters.AddRange(new SQLiteParameter[] {
                       new SQLiteParameter("shops", Shops),
                       new SQLiteParameter("tonnage", Tonnage),
                       new SQLiteParameter("mileage", Mileage),
                       new SQLiteParameter("earned", Earned),
                       new SQLiteParameter("expenses", Expenses),
                       new SQLiteParameter("profit", Profit),
                       new SQLiteParameter("Id",OrderCar_Id ),
                       new SQLiteParameter("Id2",Car_Id ),
                       new SQLiteParameter("profitability", Profitability),
                       new SQLiteParameter("freight",Freight ),
                       new SQLiteParameter("are",AreName ),
                });
            connection.Open();
            updateCommand.ExecuteNonQuery();
            connection.Close();
        }

        public void Update7()
        {
            var commandString = "UPDATE OrderCars SET  Shops = @shops, Tonnage=@tonnage, Mileage = @mileage, Earned = (@shops) * (SELECT Rate2 from Companys where Company_Id = @co_Id), Expenses=(Mileage*(SELECT PriceFuel*(СonFuel/100) from Cars where Car_Id=@id2))+((SELECT Depreciation from Cars where Car_Id=@id2)*Mileage), Profit=Earned - Expenses, Freight = @freight, Profitability =100-(Earned/(@freight+0.001)) * 100 WHERE(OrderCar_Id = @id)";
            SQLiteCommand updateCommand = new SQLiteCommand(commandString, connection);
            updateCommand.Parameters.AddRange(new SQLiteParameter[] {
                       new SQLiteParameter("shops", Shops),
                       new SQLiteParameter("tonnage", Tonnage),
                       new SQLiteParameter("mileage", Mileage),
                       new SQLiteParameter("earned", Earned),
                       new SQLiteParameter("expenses", Expenses),
                       new SQLiteParameter("profit", Profit),
                       new SQLiteParameter("Id",OrderCar_Id ),
                       new SQLiteParameter("Id2",Car_Id ),
                       new SQLiteParameter("profitability", Profitability),
                       new SQLiteParameter("freight",Freight ),
                       new SQLiteParameter("co_Id",Company_Id ),
                });
            connection.Open();
            updateCommand.ExecuteNonQuery();
            connection.Close();
        }


        public void Update8()
        {
            cb_Selected();
            var commandString = "UPDATE OrderCars SET  Shops = @shops, Tonnage=@tonnage, Mileage = @mileage, Earned = @mileage * (SELECT Rate3 from Companys where Company_Id = @co_Id), Expenses=(Mileage*(SELECT PriceFuel*(СonFuel/100) from Cars where Car_Id=@id2))+(((SELECT Depreciation from Cars where Car_Id=@id2)*Mileage)+((SELECT Beltol from Cars where Car_Id=@id2)*(SELECT BelTol from Areas where Are=@are))), Profit=Earned - Expenses, Freight = @freight, Profitability =100-(Earned/(@freight+0.001)) * 100  WHERE(OrderCar_Id = @id)";
            SQLiteCommand updateCommand = new SQLiteCommand(commandString, connection);
            updateCommand.Parameters.AddRange(new SQLiteParameter[] {
                       new SQLiteParameter("shops", Shops),
                       new SQLiteParameter("tonnage", Tonnage),
                       new SQLiteParameter("mileage", Mileage),
                       new SQLiteParameter("earned", Earned),
                       new SQLiteParameter("expenses", Expenses),
                       new SQLiteParameter("profit", Profit),
                       new SQLiteParameter("Id",OrderCar_Id ),
                       new SQLiteParameter("Id2",Car_Id ),
                       new SQLiteParameter("profitability", Profitability),
                       new SQLiteParameter("freight",Freight ),
                       new SQLiteParameter("co_Id",Company_Id ),
                       new SQLiteParameter("are",AreName ),
                });
            connection.Open();
            updateCommand.ExecuteNonQuery();
            connection.Close();
        }

        public void Update9()
        {
            var commandString = "UPDATE OrderCars SET  Shops = @shops, Tonnage=@tonnage, Mileage = @mileage, Earned = ((SELECT Rate from Companys where Company_Id = @co_Id) * (Shops))+(((SELECT Rate1 from Companys where Company_Id = @co_Id)/1000)*Tonnage), Expenses=(Mileage*(SELECT PriceFuel*(СonFuel/100) from Cars where Car_Id=@id2))+((SELECT Depreciation from Cars where Car_Id=@id2)*Mileage), Profit=Earned - Expenses, Freight = @freight, Profitability =100-(Earned/(@freight+0.001)) * 100  WHERE(OrderCar_Id = @id)";
            SQLiteCommand updateCommand = new SQLiteCommand(commandString, connection);
            updateCommand.Parameters.AddRange(new SQLiteParameter[] {
                       new SQLiteParameter("shops", Shops),
                       new SQLiteParameter("tonnage", Tonnage),
                       new SQLiteParameter("mileage", Mileage),
                       new SQLiteParameter("earned", Earned),
                       new SQLiteParameter("expenses", Expenses),
                       new SQLiteParameter("profit", Profit),
                       new SQLiteParameter("Id",OrderCar_Id ),
                       new SQLiteParameter("Id2",Car_Id ),
                       new SQLiteParameter("profitability", Profitability),
                       new SQLiteParameter("freight",Freight ),
                       new SQLiteParameter("co_Id",Company_Id ),
                });
            connection.Open();
            updateCommand.ExecuteNonQuery();
            connection.Close();
        }

        public void Update10()
        {
            cb_Selected();
            var commandString = "UPDATE OrderCars SET  Shops = @shops, Tonnage=@tonnage, Mileage = @mileage, Earned = (((@shops) * (SELECT Rate2 from Companys where Company_Id = @co_Id)))*(SELECT Rate4 from Companys where Company_Id = @co_Id), Expenses=(Mileage*(SELECT PriceFuel*(СonFuel/100) from Cars where Car_Id=@id2))+(((SELECT Depreciation from Cars where Car_Id=@id2)*Mileage)+((SELECT Beltol from Cars where Car_Id=@id2)*(SELECT BelTol from Areas where Are=@are))), Profit=Earned - Expenses, Freight = @freight, Profitability =100-(Earned/(@freight+0.001)) * 100 WHERE(OrderCar_Id = @id)";
            SQLiteCommand updateCommand = new SQLiteCommand(commandString, connection);
            updateCommand.Parameters.AddRange(new SQLiteParameter[] {
                       new SQLiteParameter("shops", Shops),
                       new SQLiteParameter("tonnage", Tonnage),
                       new SQLiteParameter("mileage", Mileage),
                       new SQLiteParameter("earned", Earned),
                       new SQLiteParameter("expenses", Expenses),
                       new SQLiteParameter("profit", Profit),
                       new SQLiteParameter("Id",OrderCar_Id ),
                       new SQLiteParameter("Id2",Car_Id ),
                       new SQLiteParameter("profitability", Profitability),
                       new SQLiteParameter("freight",Freight ),
                       new SQLiteParameter("co_Id",Company_Id ),
                       new SQLiteParameter("are",AreName ),
                });
            connection.Open();
            updateCommand.ExecuteNonQuery();
            connection.Close();
        }

        public void Update11()
        {
            cb_Selected();
            var commandString = "UPDATE OrderCars SET  Shops = @shops, Tonnage=@tonnage, Mileage = @mileage, Earned = (((SELECT Rate from Companys where Company_Id = @co_Id) * (Shops))+(((SELECT Rate1 from Companys where Company_Id = @co_Id)/1000)*Tonnage))*(SELECT Rate4 from Companys where Company_Id = @co_Id), Expenses=(Mileage*(SELECT PriceFuel*(СonFuel/100) from Cars where Car_Id=@id2))+(((SELECT Depreciation from Cars where Car_Id=@id2)*Mileage)+((SELECT Beltol from Cars where Car_Id=@id2)*(SELECT BelTol from Areas where Are=@are))), Profit=Earned - Expenses, Freight = @freight, Profitability =100-(Earned/(@freight+0.001)) * 100  WHERE(OrderCar_Id = @id)";
            SQLiteCommand updateCommand = new SQLiteCommand(commandString, connection);
            updateCommand.Parameters.AddRange(new SQLiteParameter[] {
                       new SQLiteParameter("shops", Shops),
                       new SQLiteParameter("tonnage", Tonnage),
                       new SQLiteParameter("mileage", Mileage),
                       new SQLiteParameter("earned", Earned),
                       new SQLiteParameter("expenses", Expenses),
                       new SQLiteParameter("profit", Profit),
                       new SQLiteParameter("Id",OrderCar_Id ),
                       new SQLiteParameter("Id2",Car_Id ),
                       new SQLiteParameter("profitability", Profitability),
                       new SQLiteParameter("freight",Freight ),
                       new SQLiteParameter("co_Id",Company_Id ),
                       new SQLiteParameter("are",AreName ),
                });
            connection.Open();
            updateCommand.ExecuteNonQuery();
            connection.Close();
        }

        public void Update12()
        {
            cb_Selected();
            var commandString = "UPDATE OrderCars SET  Shops = @shops, Tonnage=@tonnage, Mileage = @mileage, Earned = @mileage * (SELECT Rate5 from Companys where Company_Id = @co_Id), Expenses=(Mileage*(SELECT PriceFuel*(СonFuel/100) from Cars where Car_Id=@id2))+(((SELECT Depreciation from Cars where Car_Id=@id2)*Mileage)+((SELECT Beltol from Cars where Car_Id=@id2)*(SELECT BelTol from Areas where Are=@are))), Profit=Earned - Expenses, Freight = @freight, Profitability =100-(Earned/(@freight+0.001)) * 100  WHERE(OrderCar_Id = @id)";
            SQLiteCommand updateCommand = new SQLiteCommand(commandString, connection);
            updateCommand.Parameters.AddRange(new SQLiteParameter[] {
                       new SQLiteParameter("shops", Shops),
                       new SQLiteParameter("tonnage", Tonnage),
                       new SQLiteParameter("mileage", Mileage),
                       new SQLiteParameter("earned", Earned),
                       new SQLiteParameter("expenses", Expenses),
                       new SQLiteParameter("profit", Profit),
                       new SQLiteParameter("Id",OrderCar_Id ),
                       new SQLiteParameter("Id2",Car_Id ),
                       new SQLiteParameter("profitability", Profitability),
                       new SQLiteParameter("freight",Freight ),
                       new SQLiteParameter("co_Id",Company_Id ),
                       new SQLiteParameter("are",AreName ),
                });
            connection.Open();
            updateCommand.ExecuteNonQuery();
            connection.Close();
        }
        public void Clear()
        {
     
            this.Company_Id = 0;
           
        }
      
        public static Calculator GetCalculator(string data)
        {
            foreach (var car in GetAllOrder())
            {
                if (car.Data2 == data)
                    return car;
            }
            return null;
        }
           
        public static Calculator GetCalculator2(string hav)
        {
            foreach (var car in GetAllOrder3())
            {
                if (car.Terminate == hav)
                    return car;
            }
            return null;
        }

        private void cb_Selected()
        {            
            var connString = ConfigurationManager.ConnectionStrings["DemoConnection"].ConnectionString;
            string sqlExpression = "SELECT * FROM OrderCars WHERE OrderCar_Id =" + CalculatorWindow._id2 + "";
            using (SQLiteConnection connection = new SQLiteConnection(connString))
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(sqlExpression, connection);
                SQLiteDataReader reader = command.ExecuteReader();
                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                            AreName = (reader.GetValue(5).ToString());

                    }
                }
            }
        }
    }
}



