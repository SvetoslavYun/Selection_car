using System;
using System.Windows;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.Windows.Controls;
using System.Configuration;
using Selection_car.Areas;
using Microsoft.Office.Interop.Excel;
using Window = Microsoft.Office.Interop.Excel.Window;
using System.Windows.Input;
using System.IO;
using System.Diagnostics;

namespace Selection_car
{
    public partial class MainWindowOrder : Microsoft.Office.Interop.Excel.Window
    {
        public static bool flag;//добавить/изменить
        ObservableCollection<OrderCar> OrderCars;
        ObservableCollection<OrderVive> OrderVives;
        public static int _id;
        public static decimal milage;
        public static String Variable;
        public static String are;
        public static OrderCar orderCar;
        public static OrderVive orderVive;
        public static String CompanyName;
        public static String CarNumber;
        public static int _companyId;
        public static int _companyId2;
        public static int _carId;
        public static string datatime;
        public static String name;
        public static String Companyname;
        public static String Drivername;
        public static String name2;
        public static string day;
        public static string month;
        public static string year;
        public static string day2;
        public static string month2;
        public static string year2;
        public static string Radio;
        public static string Radio2;
        public static string radioVive = "1";
        public static string radioVive2 ;
        public MainWindowOrder()
        {           
            OrderCars = new ObservableCollection<OrderCar>();
            InitializeComponent();
            RadioVive();
            Day.Items.Add("01");
            Day.Items.Add("02");
            Day.Items.Add("03");
            Day.Items.Add("04");
            Day.Items.Add("05");
            Day.Items.Add("06");
            Day.Items.Add("07");
            Day.Items.Add("08");
            Day.Items.Add("09");
            Day.Items.Add("10");
            Day.Items.Add("11");
            Day.Items.Add("12");
            Day.Items.Add("13");
            Day.Items.Add("14");
            Day.Items.Add("15");
            Day.Items.Add("16");
            Day.Items.Add("17");
            Day.Items.Add("18");
            Day.Items.Add("19");
            Day.Items.Add("20");
            Day.Items.Add("21");
            Day.Items.Add("22");
            Day.Items.Add("23");
            Day.Items.Add("24");
            Day.Items.Add("25");
            Day.Items.Add("26");
            Day.Items.Add("27");
            Day.Items.Add("28");
            Day.Items.Add("29");
            Day.Items.Add("30");
            Day.Items.Add("31");

            Day2.Items.Add("01");
            Day2.Items.Add("02");
            Day2.Items.Add("03");
            Day2.Items.Add("04");
            Day2.Items.Add("05");
            Day2.Items.Add("06");
            Day2.Items.Add("07");
            Day2.Items.Add("08");
            Day2.Items.Add("09");
            Day2.Items.Add("10");
            Day2.Items.Add("11");
            Day2.Items.Add("12");
            Day2.Items.Add("13");
            Day2.Items.Add("14");
            Day2.Items.Add("15");
            Day2.Items.Add("16");
            Day2.Items.Add("17");
            Day2.Items.Add("18");
            Day2.Items.Add("19");
            Day2.Items.Add("20");
            Day2.Items.Add("21");
            Day2.Items.Add("22");
            Day2.Items.Add("23");
            Day2.Items.Add("24");
            Day2.Items.Add("25");
            Day2.Items.Add("26");
            Day2.Items.Add("27");
            Day2.Items.Add("28");
            Day2.Items.Add("29");
            Day2.Items.Add("30");
            Day2.Items.Add("31");

            Month.Items.Add("Январь");
            Month.Items.Add("Февраль");
            Month.Items.Add("Март");
            Month.Items.Add("Апрель");
            Month.Items.Add("Май");
            Month.Items.Add("Июнь");
            Month.Items.Add("Июль");
            Month.Items.Add("Август");
            Month.Items.Add("Сентябрь");
            Month.Items.Add("Октябрь");
            Month.Items.Add("Ноябрь");
            Month.Items.Add("Декабрь");

            Month2.Items.Add("Январь");
            Month2.Items.Add("Февраль");
            Month2.Items.Add("Март");
            Month2.Items.Add("Апрель");
            Month2.Items.Add("Май");
            Month2.Items.Add("Июнь");
            Month2.Items.Add("Июль");
            Month2.Items.Add("Август");
            Month2.Items.Add("Сентябрь");
            Month2.Items.Add("Октябрь");
            Month2.Items.Add("Ноябрь");
            Month2.Items.Add("Декабрь");
            lBox.DataContext = OrderCars;
            FillDataVive();
            Fill();


            var connString = ConfigurationManager.ConnectionStrings["DemoConnection"].ConnectionString;
            string sqlExpression = "Select * from Companys ORDER BY Name ASC";
            using (SQLiteConnection connection = new SQLiteConnection(connString))
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(sqlExpression, connection);
                SQLiteDataReader reader = command.ExecuteReader();


                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        textBox2.Items.Add(reader.GetValue(1).ToString());
                        
                    }                   
                }
            }


        }

        public void Fill()//заполнить список
        {
            
            var connString2 = ConfigurationManager.ConnectionStrings["DemoConnection"].ConnectionString;
            string sqlExpression2 = "Select * from Companys Where Name NOT in (Select Name from OrderVives) ORDER BY Name ASC";
            using (SQLiteConnection connection = new SQLiteConnection(connString2))
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(sqlExpression2, connection);
                SQLiteDataReader reader = command.ExecuteReader();
                try
                {
                    textBox2_Copy.Items.Clear();
                }
                catch
                {
                }

                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        textBox2_Copy.Items.Add(reader.GetValue(1).ToString());
                    }
                }
            }

            var connString = ConfigurationManager.ConnectionStrings["DemoConnection"].ConnectionString;
            string sqlExpression = "SELECT * FROM Companys ORDER BY Name ASC";
            using (SQLiteConnection connection = new SQLiteConnection(connString))
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(sqlExpression, connection);
                SQLiteDataReader reader = command.ExecuteReader();


                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        Name.Items.Add(reader.GetValue(1).ToString());
                    }
                }
                connection.Close();
            }

            var connString3 = ConfigurationManager.ConnectionStrings["DemoConnection"].ConnectionString;
            string sqlExpression3 = "SELECT * FROM Drivers ORDER BY Driver ASC";
            using (SQLiteConnection connection = new SQLiteConnection(connString3))
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(sqlExpression3, connection);
                SQLiteDataReader reader = command.ExecuteReader();


                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        Driver.Items.Add(reader.GetValue(3).ToString());
                    }
                }
                connection.Close();
            }       
    }

        public void FillData18()//заполнить список
        {
            OrderCars = new ObservableCollection<OrderCar>();
            InitializeComponent();
            lBox2.DataContext = OrderCars;
            OrderCars.Clear();
            foreach (var item in OrderCar.GetAllOrder2())
            {
                OrderCars.Add(item);
            }
        }
        public void FillData17()//заполнить список
        {
            OrderCars = new ObservableCollection<OrderCar>();
            InitializeComponent();
            lBox.DataContext = OrderCars;
            OrderCars.Clear();
            foreach (var item in OrderCar.GetAllOrder4())
            {
                OrderCars.Add(item);
            }
        }

        public void FillData12()//заполнить список
        {
            OrderCars = new ObservableCollection<OrderCar>();
            InitializeComponent();
            lBox.DataContext = OrderCars;
            OrderCars.Clear();
            foreach (var item in OrderCar.GetAllOrder_8())
            {
                OrderCars.Add(item);
            }
        }
        public void FillData()//заполнить список
        {
            OrderCars = new ObservableCollection<OrderCar>();
            InitializeComponent();
            lBox.DataContext = OrderCars;
            OrderCars.Clear();
            foreach (var item in OrderCar.GetAllOrder())
            {
                OrderCars.Add(item);
            }
        }

        public void FillDataVive()//заполнить список
        {
            OrderVives = new ObservableCollection<OrderVive>();
            InitializeComponent();
            lBox2_Copy.DataContext = OrderVives;
            OrderVives.Clear();
            foreach (var item in OrderVive.GetAllVive())
            {
                OrderVives.Add(item);
            }
        }

        public void FillDataVive2()//заполнить список
        {
            OrderVives = new ObservableCollection<OrderVive>();
            InitializeComponent();
            lBox3_Copy.DataContext = OrderVives;
            OrderVives.Clear();
            foreach (var item in OrderVive.GetAl())
            {
                OrderVives.Add(item);
            }
        }

        public void FillDataVive3()//заполнить список
        {
            OrderVives = new ObservableCollection<OrderVive>();
            InitializeComponent();
            lBox3_Copy.DataContext = OrderVives;
            OrderVives.Clear();
            foreach (var item in OrderVive.GetAl2())
            {
                OrderVives.Add(item);
            }
        }
        public void FillData16()//заполнить список
        {
            OrderCars = new ObservableCollection<OrderCar>();
            InitializeComponent();
            lBox6.DataContext = OrderCars;

            OrderCars.Clear();
            foreach (var item in OrderCar.GetAllOrder_13())
            {
                OrderCars.Add(item);
            }
        }

        public void FillData15()//заполнить список
        {
            OrderCars = new ObservableCollection<OrderCar>();
            InitializeComponent();
            lBox5.DataContext = OrderCars;

            OrderCars.Clear();
            foreach (var item in OrderCar.GetAllOrder_12())
            {
                OrderCars.Add(item);
            }
        }

        public void FillData14()//заполнить список
        {
            OrderCars = new ObservableCollection<OrderCar>();
            InitializeComponent();
            lBox4.DataContext = OrderCars;

            OrderCars.Clear();
            foreach (var item in OrderCar.GetAllOrder_11())
            {
                OrderCars.Add(item);
            }
        }
        public void FillData13()//заполнить список
        {
            OrderCars = new ObservableCollection<OrderCar>();
            InitializeComponent();
            lBox3.DataContext = OrderCars;

            OrderCars.Clear();
            foreach (var item in OrderCar.GetAllOrder_10())
            {
                OrderCars.Add(item);
            }
        }
        public void FillData11()//заполнить список
        {
            OrderCars = new ObservableCollection<OrderCar>();
            InitializeComponent();
            lBox3.DataContext = OrderCars;

            OrderCars.Clear();
            foreach (var item in OrderCar.GetAllOrder_7())
            {
                OrderCars.Add(item);
            }
        }

        public void FillData10()//заполнить список
        {
            OrderCars = new ObservableCollection<OrderCar>();
            InitializeComponent();
            lBox4.DataContext = OrderCars;

            OrderCars.Clear();
            foreach (var item in OrderCar.GetAllOrder_6())
            {
                OrderCars.Add(item);
            }
        }
        public void FillData9()//заполнить список
        {
            OrderCars = new ObservableCollection<OrderCar>();
            InitializeComponent();
            lBox5.DataContext = OrderCars;

            OrderCars.Clear();
            foreach (var item in OrderCar.GetAllOrder_5())
            {
                OrderCars.Add(item);
            }
        }

        public void FillData8()//заполнить список
        {
            OrderCars = new ObservableCollection<OrderCar>();
            InitializeComponent();
            lBox6.DataContext = OrderCars;

            OrderCars.Clear();
            foreach (var item in OrderCar.GetAllOrder_4())
            {
                OrderCars.Add(item);
            }
        }

        public void FillData7()//заполнить список
        {
            OrderCars = new ObservableCollection<OrderCar>();
            InitializeComponent();
            lBox6.DataContext = OrderCars;

            OrderCars.Clear();
            foreach (var item in OrderCar.GetAllOrder_3())
            {
                OrderCars.Add(item);
            }
        }

        public void FillData6()//заполнить список
        {
            OrderCars = new ObservableCollection<OrderCar>();
            InitializeComponent();
            lBox5.DataContext = OrderCars;

            OrderCars.Clear();
            foreach (var item in OrderCar.GetAllOrder_2())
            {
                OrderCars.Add(item);
            }
        }

        public void FillData5()//заполнить список
        {
            OrderCars = new ObservableCollection<OrderCar>();
            InitializeComponent();
            lBox4.DataContext = OrderCars;

            OrderCars.Clear();
            foreach (var item in OrderCar.GetAllOrder_1())
            {
                OrderCars.Add(item);
            }
        }
        public void FillData4()//заполнить список
        {
            OrderCars = new ObservableCollection<OrderCar>();
            InitializeComponent();
            lBox3.DataContext = OrderCars;

            OrderCars.Clear();
            foreach (var item in OrderCar.GetAllOrder0())
            {
                OrderCars.Add(item);
            }
        }
        public void FillData3()//заполнить список
        {
            OrderCars = new ObservableCollection<OrderCar>();
            InitializeComponent();
            lBox2.DataContext = OrderCars;

            OrderCars.Clear();
            foreach (var item in OrderCar.GetAllOrder1())
            {
                OrderCars.Add(item);
            }
        }

        public void FillData2()//заполнить список
        {
            OrderCars = new ObservableCollection<OrderCar>();
            InitializeComponent();
            lBox.DataContext = OrderCars;
            OrderCars.Clear();
            foreach (var item in OrderCar.GetAllOrder3())
            {
                OrderCars.Add(item);
            }
        }

        public void FillData_Search()//заполнить список
        {
            OrderCars.Clear();
            foreach (var item in OrderCar.Order_Search())
            {
                OrderCars.Add(item);
            }
        }

        public void Datta()//заполнить список
        {
            datatime = Data.Text;
        }

        public void FillData_Search2()//заполнить список
        {
            OrderCars.Clear();
            foreach (var item in OrderCar.Order_Search2())
            {
                OrderCars.Add(item);
            }
        }
        private void btnFill_Click()
        {

            if (Data.Text == "") MessageBox.Show("Выберите дату");
            if (Data.Text != "")
            {
                datatime = Data.Text;
                FillData7();
                FillData6();
                FillData5();
                FillData4();
                FillData3();
                FillData();
                to_NotAreas();
                to_NotCompany();
                to_Driver();
                to_Driver2();
            }           

        }

        private void btnFill_Click(object sender, RoutedEventArgs e)
        {
            Radio = "8";
            btnFill_Click();
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            if (Name_Password.Admin == "Администратор")
            {
                try
            {
                if ((OrderCar)lBox.SelectedItem == null) throw new Exception("Не выбрана строка, произведите выбор");
                var id = ((OrderCar)lBox.SelectedItem).OrderCar_Id;
                _id= ((OrderCar)lBox.SelectedItem).Company_Id;
                OrderCar.Delete(id);
                if (Radio == "1")
                {
                    FillData12();
                    FillData13();
                    FillData14();
                    FillData15();
                    FillData16();
                    FillData18();
                }
                if (Radio == "0")
                {
                    
                    FillData7();
                    FillData6();
                    FillData5();
                    FillData4();
                    FillData3();
                    FillData17();
                    to_Driver();
                    to_Driver2();
                    to_NotCompany();
                    to_NotAreas();
                }
                if (Radio == "8")
                {
                    FillData7();
                    FillData6();
                    FillData5();
                    FillData4();
                    FillData3();
                    FillData();
                    to_NotAreas();
                    to_NotCompany();
                    to_Driver();
                    to_Driver2();
                }
                
                    if (Radio == "2")
                    {
                        cb_Selected3();                      
                        FillData2();
                        FillData8();
                        FillData9();
                        FillData10();
                        FillData11();
                    }
            }
            catch (Exception h)
            {
                MessageBox.Show(h.Message);
                }
            }
            else
            {
                MessageBox.Show("Права доступа ограничены ");
            }
        }

        private void btnFill_ClickCompani(object sender, RoutedEventArgs e)
        {
            MainWindowCompany mainWindowCompany = new MainWindowCompany();
            mainWindowCompany.ShowDialog(); //ждет закрытия окна
            to_NotCompany();
            to_Driver();
            to_Driver2();
        }

        private void btnFill_ClickCar(object sender, RoutedEventArgs e)
        {
            MainWindowCar mainWindowCar = new MainWindowCar();
            mainWindowCar.ShowDialog(); //ждет закрытия окна  
            to_Driver();
            to_Driver2();
            to_NotCompany();
        }

        private void btnFill_ClickAreas(object sender, RoutedEventArgs e)
        {
            AreasWindow areasWindow = new AreasWindow();
            areasWindow.ShowDialog(); //ждет закрытия окна  
            to_Driver();
            to_Driver2();
            to_NotCompany();
        }

        private void btnFill_ClickCalculator(object sender, RoutedEventArgs e)
        {
            CalculatorWindow calculatorWindow = new CalculatorWindow();
            calculatorWindow.ShowDialog(); //ждет закрытия окна  
            to_Driver();
            to_Driver2();
            to_NotCompany();
        }

        private void btnFill_Driver(object sender, RoutedEventArgs e)
        {
            MainWindowDriver mainWindowDriver = new MainWindowDriver();
            mainWindowDriver.ShowDialog(); //ждет закрытия окна  
            to_Driver();
            to_Driver2();
            to_NotCompany();
        }

        private void toID_Click(object sender, RoutedEventArgs e)
        {
            To_Order to_Order = new To_Order();
            to_Order.Owner = this;
            to_Order.ShowDialog();//ждет закрытия окна              
            FillData_Search();
            try
            {

                MainWindowOrder._id = 0;
                MainWindowOrder.name = "";
                MainWindowOrder.orderCar.Clear();
            }
            catch
            {
            }
        }

        private void dGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = e.Row.GetIndex() + 1;
        }

        private void dGrid_LoadingRow2(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = e.Row.GetIndex() + 1;
        }

        private void dGrid_LoadingRow3(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = e.Row.GetIndex() + 1;
        }
        private void to_Add(object sender, RoutedEventArgs e)
        {
            if (Name_Password.Admin == "Администратор")
            {
                Radio = "2";
            var order = OrderCar.GetOrder(MainWindowOrder._companyId, MainWindowOrder.datatime);
            if (order == null)
            {
                if (Are.Text == "") Are.Text = "Минск";
                    if (Data.Text == "") MessageBox.Show("Выберите дату");
                if (Data.Text != "")
                {
                    if (textBox4.Text == "") MessageBox.Show("Выберите водителя");
                    else
                    {
                        if (textBox.Text == "")
                        {

                            {
                                cb_Selected4();
                                cb_Selected();
                                var orderCar = new OrderCar()
                                {
                                    Car_Id = _carId,
                                    Data = Convert.ToDateTime(Data.Text),
                                    Data2 = Data.Text,
                                    Company_Id = _companyId2,
                                    Are = Are.Text,
                                    Driver = textBox4.Text,
                                    Mileage= milage
                                };
                                orderCar.Insert();
                                datatime = Data.Text;
                                btnFill_Click();
                                FillData();
                                FillData2();
                                to_NotAreas();
                                try
                                {
                                    Are.Items.Clear();
                                }
                                catch
                                {
                                }
                                to_NotAreas();

                            }
                        }
      
                        if (textBox.Text != "")
                        {
                            cb_Selected4();
                            cb_Selected2();
                            var orderCar2 = new OrderCar()
                            {
                                Car_Id = _companyId,
                                Data = Convert.ToDateTime(Data.Text),
                                Data2 = Data.Text,
                                Company_Id = _companyId2,
                                Are = Are.Text,
                                Driver = textBox4.Text,
                            };
                            orderCar2.Insert();
                            datatime = Data.Text;
                            btnFill_Click();
                            FillData();
                            FillData2();
                            to_NotAreas();

                            try
                            {
                                Are.Items.Clear();
                            }
                            catch
                            {
                            }
                            to_NotAreas();
                        }
                    }
                    }
                }
                else
                {
                    MessageBox.Show("Права доступа ограничены ");
                }
            }
            else
            {
                MessageBox.Show("Права доступа ограничены ");
            }
            to_NotCompany();
            _companyId = 0;
        }

        private void to_Add2(object sender, RoutedEventArgs e)
        {
            if (textBox2_Copy.Text == "") MessageBox.Show("Выберите организацию ");
            else
            {
                if (textBox1_Copy.Text == "") MessageBox.Show("Введите количество машин");
                else
                {
                    OrderVives = new ObservableCollection<OrderVive>();
                    InitializeComponent();
                    lBox2_Copy.DataContext = OrderVives;
                    int val;
                    bool result = Int32.TryParse(textBox1_Copy.Text, out val);
                    if (result == true)
                    {
                        var orderVive = new OrderVive();

                        {
                            orderVive.RadioVive = "1";
                            orderVive.Name = textBox2_Copy.Text;
                            orderVive.CountCars = Convert.ToInt32(textBox1_Copy.Text);
                        };
                        orderVive.Insert();
                        radioVive2 = "2";
                        FillDataVive();
                        FillDataVive2();
                        Fill();
                    }
                    else MessageBox.Show("Не верный формат ввода: ");
                    FillDataVive();
                    try
                    {
                        textBox1_Copy.Clear();
                    }
                    catch
                    {
                    }
                }
            }
        }

        private void btnEdit_Click2(object sender, RoutedEventArgs e)
        {
            if (Name_Password.Admin == "Администратор")
            {
                try
            {
                if ((OrderCar)lBox.SelectedItem == null) throw new Exception("Не выбрана строка, произведите выбор");
                _id = ((OrderCar)lBox.SelectedItem).OrderCar_Id;
                orderCar = (OrderCar)lBox.SelectedItem;
                BD_Order bd_Order = new BD_Order();
                bd_Order.Owner = this;//первичное окно назначаем главным
                bd_Order.ShowDialog();//ждет закрытия окна
                if (Radio2 == "1") orderCar.Update();
                if (Radio2 == "2") orderCar.Update2();
                if (Radio2 == "3") orderCar.Update3();
                if (Radio == "1")
                {
                    FillData12();
                    FillData13();
                    FillData14();
                    FillData15();
                    FillData16();
                    FillData18();
                }
                if (Radio == "0")
                {
   
                        FillData2();
                        FillData();
                    FillData7();
                    FillData6();
                    FillData5();
                    FillData4();
                    FillData3();
                    FillData17();
                    to_Driver();
                    to_Driver2();
                    to_NotCompany();
                    to_NotAreas();
                }
                if (Radio == "8")
                {
                    FillData7();
                    FillData6();
                    FillData5();
                    FillData4();
                    FillData3();
                    FillData();
                    to_NotAreas();
                    to_NotCompany();
                    to_Driver();
                    to_Driver2();
                }
                
                    if (Radio == "2")
                    {
                        cb_Selected3();
                        to_Driver();
                        to_Driver2();
                        FillData2();
                        FillData8();
                        FillData9();
                        FillData10();
                        FillData11();
                    }                
            }
            catch (Exception h)
            {
                MessageBox.Show(h.Message);
            }
            }
            else
            {
                MessageBox.Show("Права доступа ограничены ");
            }
        }
     

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
                try
                {
                    var id = ((OrderVive)lBox2_Copy.SelectedItem).OrderVive_Id;                   
                    {
                        orderVive = (OrderVive)lBox2_Copy.SelectedItem;
                        orderVive.Update();
                        FillDataVive();
                        FillDataVive2();
                }
                }
                catch (Exception )
                {
                    MessageBox.Show("Не выбрана строка, произведите выбор");
                }
        }
        private void to_Edit(object sender, RoutedEventArgs e)
        {
            to_Edit();

        }

        private void to_Edit()
        {
            Radio = "2";
            cb_Selected3();
            to_Driver();
            to_Driver2();
            FillData2();
            FillData8();
            FillData9();
            FillData10();
            FillData11();

        }
        public void to_Driver() /*Выводим в текст бокс список вадителей, двойной запрос*/
        {           
            {
                CompanyName = textBox2.Text;
                try
                {
                    textBox.Items.Clear();
                }
                catch
                {
                }
                var connString = ConfigurationManager.ConnectionStrings["DemoConnection"].ConnectionString;
                string sqlExpression = "Select DISTINCT C.* from Cars AS C  JOIN Companys AS Co ON Co.Company_Id = C.Company_Id  WHERE Co.Name ='" + CompanyName + "' And C.Car_Id not in ( Select Car_Id from OrderCars)";       
                using (SQLiteConnection connection = new SQLiteConnection(connString))
                {
                    connection.Open();
                    SQLiteCommand command = new SQLiteCommand(sqlExpression, connection);
                    SQLiteDataReader reader = command.ExecuteReader();
                    if (reader.HasRows) // если есть данные
                    {
                        while (reader.Read()) // построчно считываем данные
                        {
                            textBox.Items.Add(reader.GetValue(4).ToString());
                        }
                    }
                }
                string sqlExpression2 = "Select DISTINCT C.* from Cars AS C  JOIN Companys AS Co ON Co.Company_Id = C.Company_Id JOIN OrderCars AS O ON O.Car_Id = C.Car_Id  WHERE Co.Name ='" + CompanyName + "' AND C.Car_Id not in ( Select Car_Id from OrderCars WHERE Data2 ='" + MainWindowOrder.datatime + "')";
                using (SQLiteConnection connection = new SQLiteConnection(connString))
                {
                    connection.Open();
                    SQLiteCommand command = new SQLiteCommand(sqlExpression2, connection);
                    SQLiteDataReader reader = command.ExecuteReader();
                    if (reader.HasRows) // если есть данные
                    {
                        while (reader.Read()) // построчно считываем данные
                        {
                            textBox.Items.Add(reader.GetValue(4).ToString());
                        }
                    }
                }
            }
            
        }

        public void to_Driver2() /*Выводим в текст бокс список вадителей, двойной запрос*/
        {
            {
                CompanyName = textBox2.Text;
                try
                {
                    textBox4.Items.Clear();
                }
                catch
                {
                }
                var connString = ConfigurationManager.ConnectionStrings["DemoConnection"].ConnectionString;
                string sqlExpression = "Select DISTINCT D.* from Drivers AS D JOIN Companys AS Co ON Co.Company_Id = D.Company_Id  WHERE Co.Name ='" + CompanyName + "' And D.Driver not in ( Select Driver from OrderCars)ORDER BY Driver ASC ";
                using (SQLiteConnection connection = new SQLiteConnection(connString))
                {
                    connection.Open();
                    SQLiteCommand command = new SQLiteCommand(sqlExpression, connection);
                    SQLiteDataReader reader = command.ExecuteReader();
                    if (reader.HasRows) // если есть данные
                    {
                        while (reader.Read()) // построчно считываем данные
                        {
                            textBox4.Items.Add(reader.GetValue(3).ToString());
                        }
                    }
                }
                try
                {
                    textBox4.Items.Clear();
                }
                catch
                {
                }
                string sqlExpression2 = "Select DISTINCT D.* from Drivers AS D JOIN Companys AS Co ON Co.Company_Id = D.Company_Id  WHERE Co.Name ='" + CompanyName + "' AND D.Driver not in ( Select Driver from OrderCars WHERE Data2 ='" + MainWindowOrder.datatime + "')ORDER BY Driver ASC";
                using (SQLiteConnection connection = new SQLiteConnection(connString))
                {
                    connection.Open();
                    SQLiteCommand command = new SQLiteCommand(sqlExpression2, connection);
                    SQLiteDataReader reader = command.ExecuteReader();
                    if (reader.HasRows) // если есть данные
                    {
                        while (reader.Read()) // построчно считываем данные
                        {
                            textBox4.Items.Add(reader.GetValue(3).ToString());
                        }
                    }
                }
            }

        }
        public void to_NotAreas() /*Невыбранные маршруты*/
        {
            try
            {
                Are.Items.Clear();
            }
            catch
            {
            }
            var connString = ConfigurationManager.ConnectionStrings["DemoConnection"].ConnectionString;
            string sqlExpression = "Select * From Areas ";
            using (SQLiteConnection connection = new SQLiteConnection(connString))
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(sqlExpression, connection);
                SQLiteDataReader reader = command.ExecuteReader();
                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        Are.Items.Add(reader.GetValue(1).ToString());
                    }
                }
            }           
        }
        public void to_NotCompany() /*Невыбранные организации*/
        {
            try
            {
                textBox3.Items.Clear();
            }
            catch
            {
            }
            var connString = ConfigurationManager.ConnectionStrings["DemoConnection"].ConnectionString;
            string sqlExpression = "Select DISTINCT Co.* from Companys  AS Co  JOIN OrderCars AS O ON O.Company_Id = Co.Company_Id WHERE Co.Company_Id not in ( Select Company_Id from OrderCars WHERE Data2 ='" + datatime + "')ORDER BY Name ASC";
            using (SQLiteConnection connection = new SQLiteConnection(connString))
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(sqlExpression, connection);
                SQLiteDataReader reader = command.ExecuteReader();
                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        textBox3.Items.Add(reader.GetValue(1).ToString());
                    }
                }
            }
            string sqlExpression2 = "Select * from Companys WHERE Company_Id not in ( Select Company_Id from OrderCars )ORDER BY Name ASC";
            using (SQLiteConnection connection = new SQLiteConnection(connString))
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(sqlExpression2, connection);
                SQLiteDataReader reader = command.ExecuteReader();
                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        textBox3.Items.Add(reader.GetValue(1).ToString());
                    }
                }
            }
            to_Driver();
            to_Driver2();
        }

        public void to_NotComDriver()  /*Водители из не выбронных компаний */   
            {
                CompanyName = textBox3.Text;
                to_NotCompany();
                try
                {
                    textBox.Items.Clear();
                }
                catch
                {
                }
                var connString = ConfigurationManager.ConnectionStrings["DemoConnection"].ConnectionString;
                string sqlExpression = "Select DISTINCT C.* from Cars AS C  JOIN Companys AS Co ON Co.Company_Id = C.Company_Id  WHERE Co.Name ='" + CompanyName + "'";
                using (SQLiteConnection connection = new SQLiteConnection(connString))
                {
                    connection.Open();
                SQLiteCommand command = new SQLiteCommand(sqlExpression, connection);
                SQLiteDataReader reader = command.ExecuteReader();
                    if (reader.HasRows) // если есть данные
                    {
                        while (reader.Read()) // построчно считываем данные
                        {
                            textBox.Items.Add(reader.GetValue(4).ToString());
                        }
                    }
                }
            }
        
        private void bth_MainWindow(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show(); //ждет закрытия окна         
            this.Close();
        }

        private void cb_Selected4()
        {
            are = Are.Text;
            var connString = ConfigurationManager.ConnectionStrings["DemoConnection"].ConnectionString;
            string sqlExpression = "SELECT * FROM Areas";
            using (SQLiteConnection connection = new SQLiteConnection(connString))
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(sqlExpression, connection);
                SQLiteDataReader reader = command.ExecuteReader();
                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        if (reader.GetValue(1).ToString() == are)
                        {
                            milage = Convert.ToInt32(reader.GetValue(3).ToString());
                        }

                    }
                }
            }
        }
        private void cb_Selected3()
        {
            CompanyName = textBox2.Text;
            var connString = ConfigurationManager.ConnectionStrings["DemoConnection"].ConnectionString;
            string sqlExpression = "SELECT * FROM Companys WHERE Name='" + CompanyName + "'  ";
            using (SQLiteConnection connection = new SQLiteConnection(connString))
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(sqlExpression, connection);
                SQLiteDataReader reader = command.ExecuteReader();
                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                       
                            if (reader.GetValue(1).ToString() == CompanyName)
                            {
                                _companyId2 = Convert.ToInt32(reader.GetValue(0).ToString());
                            }
                        
                    }
                }
            }
        }
        private void cb_Selected2()
        {
            CompanyName = textBox.Text;          
            var connString = ConfigurationManager.ConnectionStrings["DemoConnection"].ConnectionString;
            string sqlExpression = "SELECT * FROM Cars";
            using (SQLiteConnection connection = new SQLiteConnection(connString))
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(sqlExpression, connection);
                SQLiteDataReader reader = command.ExecuteReader();
                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        if (reader.GetValue(4).ToString() == CompanyName)
                        {
                            _companyId = Convert.ToInt32(reader.GetValue(0).ToString());
                        }
                        {
                            if (reader.GetValue(4).ToString() == CompanyName)
                            {
                                _companyId2 = Convert.ToInt32(reader.GetValue(1).ToString());
                            }
                        }
                    }
                }
            }
        }

        private void cb_Selected()
        {
            Drivername = textBox4.Text;    
            var connString = ConfigurationManager.ConnectionStrings["DemoConnection"].ConnectionString;
            string sqlExpression = "SELECT * FROM Drivers";
            using (SQLiteConnection connection = new SQLiteConnection(connString))
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(sqlExpression, connection);
                SQLiteDataReader reader = command.ExecuteReader();
                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        if (reader.GetValue(3).ToString() == Drivername)
                        {
                            _carId = Convert.ToInt32(reader.GetValue(2).ToString());
                        }
                       
                    }
                }
            }
        }
        private void to_Search(object sender, RoutedEventArgs e)
        {
           
            if (Data.Text == "") MessageBox.Show("Выберите дату");
            if (Data.Text != "")
            {
                if (textBox1.Text == "") MessageBox.Show("Введите данные");
                if (textBox1.Text != "")
                {
                    //datatime = Data.Text;
                    //bool result = int.TryParse(textBox1.Text, out MainWindowOrder._id);
                    //if (result == true);
                    //else MainWindowOrder.name = textBox1.Text;
                    FillData_Search2();
                    try
                    {

                        MainWindowOrder._id = 0;
                        MainWindowOrder.name = "";
                        MainWindowOrder.orderCar.Clear();
                    }
                    catch
                    {
                    }

                    try
                    {
                        if (textBox1.Text == null) ;
                        textBox1.Text = "";
                        MainWindowOrder.orderCar.Clear();
                    }
                    catch
                    {
                    }                  
                }
            }
        }

        private void to_Edit3(object sender, RoutedEventArgs e)
        {
            Radio = "2";
            if (textBox3.Text != "")
            {
                textBox2.Text = textBox3.Text;
                to_Driver();
                to_Driver2();
                to_NotComDriver();
                to_Edit();
            }
            else
                textBox2.Text = textBox2.Text;
        }

        private void btnDelet(object sender, RoutedEventArgs e)
        {
            try
            {
                if ((OrderVive)lBox2_Copy.SelectedItem == null) throw new Exception("Не выбрана строка, произведите выбор");
                var id = ((OrderVive)lBox2_Copy.SelectedItem).OrderVive_Id;
                OrderVive.Delete(id);
                Fill();
                FillDataVive();
                FillDataVive2();

            }
            catch 
            {
                radioVive2="1";
            }            
        }

        private void btnDelet2(object sender, RoutedEventArgs e)
        {
            if (radioVive2 != "1")
            {
                OrderVive.Delete2();
                Fill();
                FillDataVive();
                FillDataVive3();
            }
            if (radioVive2 == "1") { MessageBox.Show("Данные удолены");}
        }
      
        private void comboBox_Name_DropDownOpened(object sender, EventArgs e)
        {
            if (Name.Items.Contains(Name.Text) == false)
            {
                Name.Items.Add(Name.Text);
            }
        }

        private void comboBox_Driver_DropDownOpened(object sender, EventArgs e)
        {
            if (Driver.Items.Contains(Driver.Text) == false)
            {
                Driver.Items.Add(Driver.Text);
            }
        }

        private void to_Delet(object sender, RoutedEventArgs e)
        {
            try
            {
                if (textBox1.Text == null) ;
                textBox1.Text = "";
                MainWindowOrder.orderCar.Clear();
            }
            catch
            {
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Radio = "1";
            if (Month.Text == "Январь") Month.Text = "01";
            if (Month.Text == "Февраль") Month.Text = "02";
            if (Month.Text == "Март") Month.Text = "03";
            if (Month.Text == "Апрель") Month.Text = "04";
            if (Month.Text == "Май") Month.Text = "05";
            if (Month.Text == "Июнь") Month.Text = "06";
            if (Month.Text == "Июль") Month.Text = "07";
            if (Month.Text == "Август") Month.Text = "08";
            if (Month.Text == "Сентябрь") Month.Text = "09";
            if (Month.Text == "Октябрь") Month.Text = "10";
            if (Month.Text == "Ноябрь") Month.Text = "11";
            if (Month.Text == "Декабрь") Month.Text = "12";

            if (Month2.Text == "Январь") Month2.Text = "01";
            if (Month2.Text == "Февраль") Month2.Text = "02";
            if (Month2.Text == "Март") Month2.Text = "03";
            if (Month2.Text == "Апрель") Month2.Text = "04";
            if (Month2.Text == "Май") Month2.Text = "05";
            if (Month2.Text == "Июнь") Month2.Text = "06";
            if (Month2.Text == "Июль") Month2.Text = "07";
            if (Month2.Text == "Август") Month2.Text = "08";
            if (Month2.Text == "Сентябрь") Month2.Text = "09";
            if (Month2.Text == "Октябрь") Month2.Text = "10";
            if (Month2.Text == "Ноябрь") Month2.Text = "11";
            if (Month2.Text == "Декабрь") Month2.Text = "12";
            {
                day = Day.Text;
                month = Month.Text;
                year = Year.Text;
                day2 = Day2.Text;
                month2 = Month2.Text;
                year2 = Year2.Text;
                MainWindowOrder.name = Name.Text;
                MainWindowOrder.name2 = Driver.Text;
            };
            if (Name.Text == "") MainWindowOrder.Companyname = "";
            if (Name.Text != "") MainWindowOrder.Companyname = "AND Co.Name='" + MainWindowOrder.name + "'";
            if (Driver.Text == "") MainWindowOrder.Drivername = "";
            if (Driver.Text != "") MainWindowOrder.Drivername = "AND O.Driver='" + MainWindowOrder.name2 + "'";
            FillData12();
            FillData13();
            FillData14();
            FillData15();
            FillData16();
            FillData18();

        }


        private void RadioVive()
        {
            var order = OrderVive.GetVive(radioVive);
            if (order == null) FillDataVive3();
            if (order != null) FillDataVive2();
        }
        //private void button_Click7(object sender, RoutedEventArgs e)//метод экспорта
        //{
        //    lBox.SelectAllCells();
        //    lBox.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
        //    ApplicationCommands.Copy.Execute(null, lBox);

        //    lBox.UnselectAllCells();
        //    String result = (string)Clipboard.GetData(DataFormats.CommaSeparatedValue);
        //    String res = (string)Clipboard.GetData(DataFormats.Text);
        //    try
        //    {
        //        System.IO.StreamWriter sw = new StreamWriter("export.csv");
        //        sw.WriteLine(result);
        //        sw.Close();
        //        Process.Start("export.csv");
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}
        private void button_Click7(object sender, RoutedEventArgs e)//метод экспорта
        {
            lBox.SelectAllCells();
            lBox.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
            ApplicationCommands.Copy.Execute(null, lBox);

            lBox.UnselectAllCells();
            String result = (string)Clipboard.GetData(DataFormats.CommaSeparatedValue);
            String res = (string)Clipboard.GetData(DataFormats.Text);
            try
            {
                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Visible = true;
                Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
                Worksheet sheet1 = (Worksheet)workbook.Sheets[1];                
                for (int j = 0; j < lBox.Columns.Count; j++)
                {
                    Range myRange = (Range)sheet1.Cells[1, j + 1];
                    sheet1.Cells[1, j + 1].Font.Bold = true;
                    sheet1.Columns[j + 1].ColumnWidth = 25;
                    myRange.Value2 = lBox.Columns[j].Header;
                }
                for (int i = 0; i < lBox.Columns.Count; i++)
                {
                    for (int j = 0; j < lBox.Items.Count; j++)
                    {
                        TextBlock b = lBox.Columns[i].GetCellContent(lBox.Items[j]) as TextBlock;
                        Range myRange = (Range)sheet1.Cells[j + 2, i + 1];
                        myRange.Value2 = b.Text;

                    }
                }
            }
            catch (Exception )
            {
                MessageBox.Show("Данные сохранены в документ Excel " );
            }
            this.WindowState = WindowState.Minimized;
        }

        dynamic Microsoft.Office.Interop.Excel.Window.Activate()
        {
            throw new NotImplementedException();
        }

        public dynamic ActivateNext()
        {
            throw new NotImplementedException();
        }

        public dynamic ActivatePrevious()
        {
            throw new NotImplementedException();
        }

        public bool Close(object SaveChanges, object Filename, object RouteWorkbook)
        {
            throw new NotImplementedException();
        }

        public dynamic LargeScroll(object Down, object Up, object ToRight, object ToLeft)
        {
            throw new NotImplementedException();
        }

        public Microsoft.Office.Interop.Excel.Window NewWindow()
        {
            throw new NotImplementedException();
        }

        public dynamic _PrintOut(object From, object To, object Copies, object Preview, object ActivePrinter, object PrintToFile, object Collate, object PrToFileName)
        {
            throw new NotImplementedException();
        }

        public dynamic PrintPreview(object EnableChanges)
        {
            throw new NotImplementedException();
        }

        public dynamic ScrollWorkbookTabs(object Sheets, object Position)
        {
            throw new NotImplementedException();
        }

        public dynamic SmallScroll(object Down, object Up, object ToRight, object ToLeft)
        {
            throw new NotImplementedException();
        }

        public int PointsToScreenPixelsX(int Points)
        {
            throw new NotImplementedException();
        }

        public int PointsToScreenPixelsY(int Points)
        {
            throw new NotImplementedException();
        }

        public dynamic RangeFromPoint(int x, int y)
        {
            throw new NotImplementedException();
        }

        public void ScrollIntoView(int Left, int Top, int Width, int Height, object Start)
        {
            throw new NotImplementedException();
        }

        public dynamic PrintOut(object From, object To, object Copies, object Preview, object ActivePrinter, object PrintToFile, object Collate, object PrToFileName)
        {
            throw new NotImplementedException();
        }

        public Microsoft.Office.Interop.Excel.Application Application => throw new NotImplementedException();

        public XlCreator Creator => throw new NotImplementedException();

        dynamic Microsoft.Office.Interop.Excel.Window.Parent => throw new NotImplementedException();

        public Range ActiveCell => throw new NotImplementedException();

        public Chart ActiveChart => throw new NotImplementedException();

        public Pane ActivePane => throw new NotImplementedException();

        public dynamic ActiveSheet => throw new NotImplementedException();

        public dynamic Caption { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool DisplayFormulas { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool DisplayGridlines { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool DisplayHeadings { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool DisplayHorizontalScrollBar { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool DisplayOutline { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool _DisplayRightToLeft { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool DisplayVerticalScrollBar { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool DisplayWorkbookTabs { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool DisplayZeros { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool EnableResize { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool FreezePanes { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int GridlineColor { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public XlColorIndex GridlineColorIndex { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int Index => throw new NotImplementedException();

        public string OnWindow { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Panes Panes => throw new NotImplementedException();

        public Range RangeSelection => throw new NotImplementedException();

        public int ScrollColumn { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int ScrollRow { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Sheets SelectedSheets => throw new NotImplementedException();

        public dynamic Selection => throw new NotImplementedException();

        public bool Split { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int SplitColumn { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double SplitHorizontal { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int SplitRow { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double SplitVertical { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double TabRatio { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public XlWindowType Type => throw new NotImplementedException();

        public double UsableHeight => throw new NotImplementedException();

        public double UsableWidth => throw new NotImplementedException();

        public bool Visible { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Range VisibleRange => throw new NotImplementedException();

        public int WindowNumber => throw new NotImplementedException();

        XlWindowState Microsoft.Office.Interop.Excel.Window.WindowState { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public dynamic Zoom { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public XlWindowView View { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool DisplayRightToLeft { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public SheetViews SheetViews => throw new NotImplementedException();

        public dynamic ActiveSheetView => throw new NotImplementedException();

        public bool DisplayRuler { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool AutoFilterDateGrouping { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool DisplayWhitespace { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int Hwnd => throw new NotImplementedException();
    }
}





