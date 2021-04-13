using System;
using System.Windows;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Windows.Controls;
using System.Configuration;


namespace Selection_car
{
    public partial class MainWindowOrder : Window
    {
        public static bool flag;//добавить/изменить
        ObservableCollection<OrderCar> OrderCars;
        public static int _id;
        public static String Variable;
        public static OrderCar orderCar;
        public static String CompanyName;
        public static int _companyId;
        public static String datatime;
        public static String name;
        public MainWindowOrder()
        {
           
            OrderCars = new ObservableCollection<OrderCar>();
            InitializeComponent();
            lBox.DataContext = OrderCars;
            
            var connString = ConfigurationManager.ConnectionStrings["DemoConnection"].ConnectionString;
            var connString2 = ConfigurationManager.ConnectionStrings["DemoConnection"].ConnectionString;
            string sqlExpression2 = "Select * from Companys";
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression2, connection);
                SqlDataReader reader = command.ExecuteReader();


                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        textBox2.Items.Add(reader.GetValue(1).ToString());
                    }
                }
            }
        }

        public void FillData()//заполнить список
        {
            OrderCars.Clear();
            foreach (var item in OrderCar.GetAllOrder())
            {
                OrderCars.Add(item);
            }
        }

        public void FillData3()//заполнить список
        {
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

        public void FillData_Search2()//заполнить список
        {
            OrderCars.Clear();
            foreach (var item in OrderCar.Order_Search2())
            {
                OrderCars.Add(item);
            }
        }
        private void btnFill_Click(object sender, RoutedEventArgs e)
        {
            if (Data.Text == "") MessageBox.Show("Выберите дату");
            if (Data.Text != "")
            {
                datatime = Data.Text;
                FillData();
            }        
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if ((OrderCar)lBox.SelectedItem == null) throw new Exception("Не выбрана строка, произведите выбор");
                var id = ((OrderCar)lBox.SelectedItem).OrderCar_Id;
                OrderCar.Delete(id);
                FillData();
            }
            catch (Exception h)
            {
                MessageBox.Show(h.Message);
            }
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

        private void to_Add(object sender, RoutedEventArgs e)
        {
            var user = OrderCar.GetOrder(MainWindowOrder._companyId, MainWindowOrder.datatime);
            if (user == null)
            {

                if (Data.Text == "") MessageBox.Show("Выберите дату");
                if (Data.Text != "")
                {
                    if (_companyId == 0) MessageBox.Show("Выберите организацию и автомобиль");
                    if (_companyId > 0)
                    {
                        {
                            var orderCar = new OrderCar()
                            {
                                Car_Id = _companyId,
                                Data = Data.Text,
                            };
                            orderCar.Insert();
                            datatime = Data.Text;
                            FillData3();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Такой водитель уже есть");
            }
        }


        private void to_Edit(object sender, RoutedEventArgs e)
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
                string sqlExpression = "Select * from Cars AS C JOIN Companys AS Co ON Co.Company_Id = C.Company_Id WHERE Co.Name = N'" + CompanyName + "'";
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows) // если есть данные
                    {
                        while (reader.Read()) // построчно считываем данные
                        {
                            textBox.Items.Add(reader.GetValue(2).ToString());
                        }
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

        private void cb_Selected(object sender, RoutedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            string tit = comboBox.SelectedItem.ToString();
            var connString = ConfigurationManager.ConnectionStrings["DemoConnection"].ConnectionString;
            string sqlExpression = "SELECT * FROM Cars";
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        if (reader.GetValue(2).ToString() == tit)
                        {
                            _companyId = Convert.ToInt32(reader.GetValue(0).ToString());
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
                    datatime = Data.Text;
                    bool result = int.TryParse(textBox1.Text, out MainWindowOrder._id);
                    if (result == true);
                    else MainWindowOrder.name = textBox1.Text;
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
    }
}




