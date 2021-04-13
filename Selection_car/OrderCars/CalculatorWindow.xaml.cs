using System;
using System.Windows;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.Windows.Controls;
using System.Configuration;
using Selection_car.Areas;
using System.Windows.Media;
using Microsoft.Office.Interop.Excel;
using System.Windows.Input;

namespace Selection_car
{
    public partial class CalculatorWindow : Microsoft.Office.Interop.Excel.Window
    {
        public static bool flag;//добавить/изменить
        ObservableCollection<Calculator> Calculators;
        public static int _id;
        public static int _id2;
        public static String Variable;
        public static Calculator calculator;
        public static String CompanyName;
        public static decimal _companyId;
        public static int _companyId2;
        public static String datatime;
        public static String datatime2;
        public static String name;
        public static String type;
        public static String type2;
        public static String type3;
        public static decimal rate;
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
        public static string Radio3;
        public static string RadioВuten;
        public static string having="1";
        public static int Rate6;
        public CalculatorWindow()
        {
            Calculators = new ObservableCollection<Calculator>();
            InitializeComponent();
            cb_Selected();
            ViewType.Items.Add("Средние покозатели");
            ViewType.Items.Add("Сумма покозателей");
            ViewCalculator.Items.Add("Хлеб город");
            ViewCalculator.Items.Add("Кондитерка");
            ViewCalculator.Items.Add("Район хлеб с коэффицентом");
            ViewCalculator.Items.Add("Район кодитерка с коэффицентом");
            ViewCalculator.Items.Add("Дальнорейсовый");
            ViewCalculator.Items.Add("Сборный");
            ViewCalculator.Items.Add("Общий список");
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
            lBox.DataContext = Calculators;
          

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

            var connString2 = ConfigurationManager.ConnectionStrings["DemoConnection"].ConnectionString;
            string sqlExpression2 = "SELECT * FROM Companys ORDER BY Name ASC";
            using (SQLiteConnection connection = new SQLiteConnection(connString2))
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(sqlExpression2, connection);
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

        //private void dataGridLoadingRow(object sender, DataGridRowEventArgs e)
        //{
        //    Calculator rowContext = e.Row.DataContext as Calculator;

        //    if (rowContext != null)
        //    {
        //        if (rowContext.Earned > 0)
        //            e.Row.Background = new SolidColorBrush(Colors.Green);
        //    }
        //}

        public void FillData_3()//заполнить список
        {
            Calculators = new ObservableCollection<Calculator>();
            InitializeComponent();
            lBox2.DataContext = Calculators;
            Calculators.Clear();
            foreach (var item in Calculator.GetAllOrder7())
    
                {
                    Calculators.Add(item);
                }
     
        }

        public void FillData_2()//заполнить список
        {
            Calculators = new ObservableCollection<Calculator>();
            InitializeComponent();
            lBox2.DataContext = Calculators;
            Calculators.Clear();
            foreach (var item in Calculator.GetAllOrder6())

                {
                    Calculators.Add(item);
                }

        }

        public void FillData_1()//заполнить список
        {
            Calculators = new ObservableCollection<Calculator>();
            InitializeComponent();
            lBox2.DataContext = Calculators;
            Calculators.Clear();
            foreach (var item in Calculator.GetAllOrder5())
             
                {
                    Calculators.Add(item);
                }
          
        }
        public void FillData0()//заполнить список
        {
            Calculators = new ObservableCollection<Calculator>();
            InitializeComponent();
            lBox.DataContext = Calculators;
            Calculators.Clear();
            foreach (var item in Calculator.GetAllOrder3())
             
            {
                Calculators.Add(item);
            }
                
        }
        public void FillData()//заполнить список
        {
            Calculators = new ObservableCollection<Calculator>();
            InitializeComponent();
            lBox.DataContext = Calculators;
            Calculators.Clear();
            foreach (var item in Calculator.GetAllOrder())   
            {
                Calculators.Add(item);
            }
        }

        public void FillData3()//заполнить список
        {
            Calculators = new ObservableCollection<Calculator>();
            InitializeComponent();
            lBox_Copy.DataContext = Calculators;

            Calculators.Clear();
            foreach (var item in Calculator.GetAllOrder_1())
            {
                Calculators.Add(item);
            }
        }

        public void FillData4()//заполнить список
        {
            Calculators = new ObservableCollection<Calculator>();
            InitializeComponent();
            lBox.DataContext = Calculators;
            Calculators.Clear();
            foreach (var item in Calculator.GetAllOrder4())
            {
                Calculators.Add(item);
            }
        }

        private void to_Edit(object sender, RoutedEventArgs e)
        {
            Radio3 = "1";
               Radio = "0";       
                 datatime = Data.Text;
                CompanyName = textBox2.Text;
            if (Radio == "0") RadioВuten = "O.Data2='" + CalculatorWindow.datatime + "' and Co.Name='" + CalculatorWindow.CompanyName + "'";
            if (ViewType.Text == "Средние покозатели") type= "avg";
            if (ViewType.Text == "Сумма покозателей") type = "sum";
            if (ViewType.Text == "") type = "avg";                     
            
            if (ViewCalculator.Text == "Кондитерка") { type2 = "and C.Type='Кондитерская'and O.Are='Минск'"; type3 = "1"; }           
            if (ViewCalculator.Text == "Дальнорейсовый") { type2 = "and O.Are !='Минск' and C.Type!='Сборная' and C.Type!='Кондитерская' and O.Mileage >400"; type3 = "2"; }           
            if (ViewCalculator.Text == "Хлеб город") { type2 = "and C.Type='Хлебная' and O.Are='Минск'"; type3 = "3"; }         
            if (ViewCalculator.Text == "Район кодитерка с коэффицентом") { type2 = "and O.Are !='Минск' and C.Type='Кондитерская'"; type3 = "4"; }           
            if (ViewCalculator.Text == "Район хлеб с коэффицентом") { type2 = "and O.Mileage <400 and C.Type='Хлебная' and O.Are !='Минск'"; type3 = "5"; }         
            if (ViewCalculator.Text == "Сборный") { type2 = "and C.Type='Сборная'"; type3 = "6"; }
            if (ViewCalculator.Text == "Общий список") { type2 = ""; type3 = "999"; }
            {
                if (textBox2.Text == "") MessageBox.Show("Выберите организацию");
                if (Data.Text == "") MessageBox.Show("Выберите дату");
                if (ViewCalculator.Text == "") MessageBox.Show("Выберите калькулятор");
                else
                {
                    var orde6 = Calculator.GetCalculator(Data.Text);
                if (orde6 != null)
                {                                   
                    FillData();
                    FillData3();
                    FillData_1();
                    }
                else
                {
                        FillData4();
                        Radio = "999";
                    MessageBox.Show("Список данных пуст");
                }}
            }         
        }

        private void to_Edit()
        {
            Radio = "0";
            datatime = Data.Text;
            CompanyName = textBox2.Text;
            if (Radio == "0") RadioВuten = "O.Data2='" + CalculatorWindow.datatime + "' and Co.Name='" + CalculatorWindow.CompanyName + "'";
            if (ViewType.Text == "Средние покозатели") type = "avg";
            if (ViewType.Text == "Сумма покозателей") type = "sum";
            if (ViewType.Text == "") type = "avg";

            if (ViewCalculator.Text == "Кондитерка") { type2 = "and C.Type='Кондитерская'and O.Are='Минск'"; type3 = "1"; }
            if (ViewCalculator.Text == "Дальнорейсовый") { type2 = "and O.Are !='Минск' and C.Type!='Сборная' and C.Type!='Кондитерская' and O.Mileage >=400"; type3 = "2"; }
            if (ViewCalculator.Text == "Хлеб город") { type2 = "and C.Type='Хлебная' and O.Are='Минск'"; type3 = "3"; }
            if (ViewCalculator.Text == "Район кодитерка с коэффицентом") { type2 = "and O.Are !='Минск' and C.Type='Кондитерская'"; type3 = "4"; }
            if (ViewCalculator.Text == "Район хлеб с коэффицентом") { type2 = "and O.Mileage < 400 and C.Type='Хлебная' and O.Are !='Минск'"; type3 = "5"; }
            if (ViewCalculator.Text == "Сборный") { type2 = "and C.Type='Сборная'"; type3 = "6"; }
            if (ViewCalculator.Text == "Общий список") { type2 = ""; type3 = "999"; }
            {
                if (textBox2.Text == "") MessageBox.Show("Выберите организацию");
                if (Data.Text == "") MessageBox.Show("Выберите дату");
                if (ViewCalculator.Text == "") MessageBox.Show("Выберите калькулятор");
                else
                {
                    var orde6 = Calculator.GetCalculator(Data.Text);
                    if (orde6 != null)
                    {
                        FillData();
                        FillData3();
                        FillData_1();
                    }
                    else
                    {
                        FillData4();
                        Radio = "999";
                        MessageBox.Show("Список данных пуст");
                    }
                }
            }
        }

        private void btnFill_ClickCompani(object sender, RoutedEventArgs e)
        {
            MainWindowCompany mainWindowCompany = new MainWindowCompany();
            mainWindowCompany.ShowDialog(); //ждет закрытия окна
        }

        private void btnFill_ClickCar(object sender, RoutedEventArgs e)
        {
            MainWindowCar mainWindowCar = new MainWindowCar();
            mainWindowCar.ShowDialog(); //ждет закрытия окна  
     
        }

        private void btnFill_ClickAreas(object sender, RoutedEventArgs e)
        {
            AreasWindow areasWindow = new AreasWindow();
            areasWindow.ShowDialog(); //ждет закрытия окна  
 
        }

        private void btnFill_Driver(object sender, RoutedEventArgs e)
        {
            MainWindowDriver mainWindowDriver = new MainWindowDriver();
            mainWindowDriver.ShowDialog(); //ждет закрытия окна            
        }
        private void cb_Selected()
        {
            name = Name.Text;
            CompanyName = textBox2.Text;
            var connString = ConfigurationManager.ConnectionStrings["DemoConnection"].ConnectionString;
            string sqlExpression = "SELECT * FROM Companys";
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
                            Rate6 = Convert.ToInt32(reader.GetValue(11).ToString());
                        }
                        if (reader.GetValue(1).ToString() == name)
                        {
                            Rate6 = Convert.ToInt32(reader.GetValue(11).ToString());
                        }
                    }

                }
            }
        }

        private void dGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {           
            cb_Selected();
            Calculator rowContext = e.Row.DataContext as Calculator;

            if (rowContext != null)
            {              
                if (rowContext.Profit < Rate6)
                    e.Row.Background = new SolidColorBrush(Colors.Pink);
                if (rowContext.Profit == 0)
                    e.Row.Background = new SolidColorBrush(Colors.White);
                if (rowContext.Profit > Rate6)
                    e.Row.Background = new SolidColorBrush(Colors.LightGreen);
                if (rowContext.Profit < 0)
                    e.Row.Background = new SolidColorBrush(Colors.Red);
            }
            e.Row.Header = e.Row.GetIndex() + 1;
        } 
        

      
        private void btnEdit_Click2(object sender, RoutedEventArgs e)
        {
            if (Name_Password.Admin == "Администратор")
            {
                var result = MessageBox.Show("Вы уверены?", "Внести данные", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        if (Radio == "0")
                        {
                            _id2 = ((Calculator)lBox.SelectedItem).OrderCar_Id;
                            {
                                calculator = (Calculator)lBox.SelectedItem;
                                if (type3 == "1")
                                {

                                    calculator.Update();
                                    calculator.Update();
                                    calculator.Update();
                                    FillData();
                                    FillData3();
                                    FillData_1();
                                };
                                if (type3 == "2")
                                {
                                    calculator.Update2();
                                    calculator.Update2();
                                    calculator.Update2();
                                    to_Edit();

                                };
                                if (type3 == "3")
                                {
                                    calculator.Update3();
                                    calculator.Update3();
                                    calculator.Update3();
                                    FillData();
                                    FillData3();
                                    FillData_1();

                                };

                                if (type3 == "4")
                                {
                                    calculator.Update4();
                                    calculator.Update4();
                                    calculator.Update4();
                                    FillData();
                                    FillData3();
                                    FillData_1();

                                };

                                if (type3 == "5")
                                {
                                    calculator.Update5();
                                    calculator.Update5();
                                    calculator.Update5();
                                    to_Edit();

                                };

                                if (type3 == "6")
                                {
                                    calculator.Update6();
                                    calculator.Update6();
                                    calculator.Update6();
                                    FillData();
                                    FillData3();
                                    FillData_1();

                                };
                            }
                        }

                        if (Radio == "1")
                        {
                            _id2 = ((Calculator)lBox.SelectedItem).OrderCar_Id;
                            {
                                calculator = (Calculator)lBox.SelectedItem;
                                if (type3 == "7")
                                {
                                    calculator.Update7();
                                    calculator.Update7();
                                    calculator.Update7();
                                    FillData0();
                                    FillData3();
                                    if (Radio2 != "100") FillData_2();
                                    if (Radio2 == "100") FillData_3();
                                };
                                if (type3 == "8")
                                {
                                    calculator.Update8();
                                    calculator.Update8();
                                    calculator.Update8();
                                    FillData0();
                                    FillData3();
                                    if (Radio2 != "100") FillData_2();
                                    if (Radio2 == "100") FillData_3();

                                };
                                if (type3 == "9")
                                {
                                    calculator.Update9();
                                    calculator.Update9();
                                    calculator.Update9();
                                    FillData0();
                                    FillData3();
                                    if (Radio2 != "100") FillData_2();
                                    if (Radio2 == "100") FillData_3();

                                };

                                if (type3 == "10")
                                {
                                    calculator.Update10();
                                    calculator.Update10();
                                    calculator.Update10();
                                    FillData0();
                                    FillData3();
                                    if (Radio2 != "100") FillData_2();
                                    if (Radio2 == "100") FillData_3();

                                };

                                if (type3 == "11")
                                {
                                    calculator.Update11();
                                    calculator.Update11();
                                    calculator.Update11();
                                    butt2();

                                };

                                if (type3 == "12")
                                {
                                    calculator.Update12();
                                    calculator.Update12();
                                    calculator.Update12();
                                    FillData0();
                                    FillData3();
                                    if (Radio2 != "100") FillData_2();
                                    if (Radio2 == "100") FillData_3();

                                };
                            }
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Ошибка");
                    }
                }
            }
            else
            {
                MessageBox.Show("Права доступа ограничены ");
            }
            }

        private void btnFill_ClickOrder(object sender, RoutedEventArgs e)
        {
            MainWindowOrder mainWindowOrder = new MainWindowOrder();
            mainWindowOrder.ShowDialog(); //ждет закрытия окна 
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

        private void button_Click()
        {
            Radio = "1";
            if (Driver.Text != "") Radio2 = "100";
            if (Driver.Text == "") Radio2 = "200";
            if (ViewType.Text == "Средние покозатели") type = "avg";
            if (ViewType.Text == "Сумма покозателей") type = "sum";
            if (ViewType.Text == "") type = "avg";
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
                CalculatorWindow.name = Name.Text;
                CalculatorWindow.name2 = Driver.Text;
            };
            if (Name.Text == "") CalculatorWindow.Companyname = "";
            if (Name.Text != "") CalculatorWindow.Companyname = "AND Co.Name='" + CalculatorWindow.name + "'";
            if (Driver.Text == "") CalculatorWindow.Drivername = "";
            if (Driver.Text != "") CalculatorWindow.Drivername = "AND O.Driver='" + CalculatorWindow.name2 + "'";
            datatime2 = "'" + CalculatorWindow.year + "-" + CalculatorWindow.month + "-" + CalculatorWindow.day + "%' AND '" + CalculatorWindow.year2 + "-" + CalculatorWindow.month2 + "-" + CalculatorWindow.day2 + "%' " + CalculatorWindow.Companyname + " " + CalculatorWindow.Drivername + " " + CalculatorWindow.type2 + "";
            if (Radio == "1") RadioВuten = "O.Data  BETWEEN '" + CalculatorWindow.year + "-" + CalculatorWindow.month + "-" + CalculatorWindow.day + "%' AND '" + CalculatorWindow.year2 + "-" + CalculatorWindow.month2 + "-" + CalculatorWindow.day2 + "%' " + CalculatorWindow.Companyname + " " + CalculatorWindow.Drivername + "";

            if (ViewCalculator.Text == "Кондитерка") { type2 = "and C.Type='Кондитерская'and O.Are='Минск'"; type3 = "7"; }
            if (ViewCalculator.Text == "Дальнорейсовый") { type2 = "and O.Are !='Минск' and C.Type!='Сборная' and C.Type!='Кондитерская' and O.Mileage >400 "; type3 = "8"; }
            if (ViewCalculator.Text == "Хлеб город") { type2 = "and C.Type='Хлебная' and O.Are='Минск'"; type3 = "9"; }
            if (ViewCalculator.Text == "Район кодитерка с коэффицентом") { type2 = "and O.Are !='Минск' and C.Type='Кондитерская'"; type3 = "10"; }
            if (ViewCalculator.Text == "Район хлеб с коэффицентом") { type2 = "and O.Mileage <400 and C.Type='Хлебная' and O.Are !='Минск'"; type3 = "11"; }
            if (ViewCalculator.Text == "Сборный") { type2 = "and C.Type='Сборная'"; type3 = "12"; }
            if (ViewCalculator.Text == "Общий список") { type2 = ""; type3 = "999"; }
            var order = Calculator.GetCalculator2(having);
            if (order != null) 
            {
                FillData0();
                if (Radio2 != "100") FillData_2();
                if (Radio2 == "100") FillData_3();

            }  
            
        }

        private void button_Click2()
        {
            if (Radio == "1")
            {
                type3 = "";
                if (Driver.Text != "") Radio2 ="100" ;
                if (Driver.Text == "") Radio2 = "200";
                if (ViewType.Text == "Средние покозатели") type = "avg";
                if (ViewType.Text == "Сумма покозателей") type = "sum";
                if (ViewType.Text == "") type = "sum";
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
                    CalculatorWindow.name = Name.Text;
                    CalculatorWindow.name2 = Driver.Text;
                };
                if (Name.Text == "") CalculatorWindow.Companyname = "";
                if (Name.Text != "") CalculatorWindow.Companyname = "AND Co.Name='" + CalculatorWindow.name + "'";
                if (Driver.Text == "") CalculatorWindow.Drivername = "";
                if (Driver.Text != "") CalculatorWindow.Drivername = "AND O.Driver='" + CalculatorWindow.name2 + "'";
                datatime2 = "'" + CalculatorWindow.year + "-" + CalculatorWindow.month + "-" + CalculatorWindow.day + "%' AND '" + CalculatorWindow.year2 + "-" + CalculatorWindow.month2 + "-" + CalculatorWindow.day2 + "%' " + CalculatorWindow.Companyname + " " + CalculatorWindow.Drivername + " " + CalculatorWindow.type2 + "";
                type2 = "";                
                FillData0();
                FillData3();
                if (Radio2 != "100") FillData_2();
                if (Radio2 == "100") FillData_3();

            }
            if (Radio == "0")
            {
                if (ViewType.Text == "Средние покозатели") type = "avg";
                if (ViewType.Text == "Сумма покозателей") type = "sum";
                if (ViewType.Text == "") type = "avg";
                type3 = "";
                type2 = "";
                datatime = Data.Text;
                CompanyName = textBox2.Text;       
                FillData();
                FillData3();
                FillData_1();
            }
        }

        private void button_Click2(object sender, RoutedEventArgs e)
        {           
                button_Click2();
                button_Click2();            
        }
        private void butt()
        {
           
                var order = Calculator.GetCalculator2(having);
                if (order == null) ;
                else
                {
                    FillData3();
                if (Radio2 != "100") FillData_2();
                if (Radio2 == "100") FillData_3();
            }
            

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Radio3 = "1";
            cb_Selected();
            if (ViewCalculator.Text == "") MessageBox.Show("Выберите калькулятор");
            if (ViewCalculator.Text != "")
            {

                {
                    button_Click();
                    button_Click();
                    var order = Calculator.GetCalculator2(having);
                    if (order != null)
                    {

                        FillData3();
                        if (Radio2 != "100") FillData_2();
                        if (Radio2 == "100") FillData_3();
                    }
                    else
                    {
                        FillData4();
                        Radio = "999";
                        MessageBox.Show("Список данных пуст");
                    }
                }
            }
        }

        private void butt2()
        {
           
                {
                    button_Click();
                    button_Click();
                    var order = Calculator.GetCalculator2(having);
                    if (order != null)
                    {

                        butt();
                    }
                    else
                    {
                        FillData4();
                        Radio = "999";
                        MessageBox.Show("Список данных пуст");
                    }
                }
            
        }

        private void button_Click3(object sender, RoutedEventArgs e)
        {
            Radio3 = "2";
            cb_Selected();
            if (ViewType.Text == "Средние покозатели") type = "avg";
            if (ViewType.Text == "Сумма покозателей") type = "sum";
            if (ViewType.Text == "") type = "sum";
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
                CalculatorWindow.name = Name.Text;
                CalculatorWindow.name2 = Driver.Text;
            };
            if (ViewCalculator.Text == "Кондитерка") { type2 = "and C.Type='Кондитерская'and O.Are='Минск'"; }
            if (ViewCalculator.Text == "Дальнорейсовый") { type2 = "and O.Are !='Минск' and C.Type!='Сборная' and C.Type!='Кондитерская' and O.Mileage >=400";}
            if (ViewCalculator.Text == "Хлеб город") { type2 = "and C.Type='Хлебная' and O.Are='Минск'"; }
            if (ViewCalculator.Text == "Район кодитерка с коэффицентом") { type2 = "and O.Are !='Минск' and C.Type='Кондитерская'"; }
            if (ViewCalculator.Text == "Район хлеб с коэффицентом") { type2 = "and O.Mileage < 400 and C.Type='Хлебная' and O.Are !='Минск'";}
            if (ViewCalculator.Text == "Сборный") { type2 = "and C.Type='Сборная'";}
            if (ViewCalculator.Text == "Общий список") { type2 = ""; }
            if (Name.Text == "") CalculatorWindow.Companyname = "";
            if (Name.Text != "") CalculatorWindow.Companyname = "AND Co.Name='" + CalculatorWindow.name + "'";
            if (Driver.Text == "") CalculatorWindow.Drivername = "";
            if (Driver.Text != "") CalculatorWindow.Drivername = "AND O.Driver='" + CalculatorWindow.name2 + "'";
            datatime2 = "'" + CalculatorWindow.year + "-" + CalculatorWindow.month + "-" + CalculatorWindow.day + "%' AND '" + CalculatorWindow.year2 + "-" + CalculatorWindow.month2 + "-" + CalculatorWindow.day2 + "%' " + CalculatorWindow.Companyname + " " + CalculatorWindow.Drivername + " " + CalculatorWindow.type2 + "";           
            FillData_3();
        }

        private void button_Click7(object sender, RoutedEventArgs e)
        {
            if (Radio3 == "1")
            {
                lBox.SelectAllCells();
                lBox.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
                ApplicationCommands.Copy.Execute(null, lBox);
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
                        sheet1.Columns[j + 1].ColumnWidth = 20;
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
                catch (Exception ex)
                {
                    MessageBox.Show("Данные сохранены в документ Excel ");
                }
                this.WindowState = WindowState.Minimized;
            }
            if (Radio3 == "2")
            {
                lBox2.SelectAllCells();
                lBox2.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
                ApplicationCommands.Copy.Execute(null, lBox2);
                try
                {
                    Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                    excel.Visible = true;
                    Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
                    Worksheet sheet1 = (Worksheet)workbook.Sheets[1];

                    for (int j = 0; j < lBox2.Columns.Count; j++)
                    {
                        Range myRange = (Range)sheet1.Cells[1, j + 1];
                        sheet1.Cells[1, j + 1].Font.Bold = true;
                        sheet1.Columns[j + 1].ColumnWidth = 20;
                        myRange.Value2 = lBox2.Columns[j].Header;
                    }
                    for (int i = 0; i < lBox2.Columns.Count; i++)
                    {
                        for (int j = 0; j < lBox2.Items.Count; j++)
                        {
                            TextBlock b = lBox2.Columns[i].GetCellContent(lBox2.Items[j]) as TextBlock;
                            Range myRange = (Range)sheet1.Cells[j + 2, i + 1];
                            myRange.Value2 = b.Text;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Данные сохранены в документ Excel ");
                }
                this.WindowState = WindowState.Minimized;
            }
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




