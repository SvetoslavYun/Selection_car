using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace Selection_car
{

    public partial class BD_Form : Window
    {
        int _companyId;
        public BD_Form()
        {
            InitializeComponent();
            grid.DataContext = MainWindowCar.car;

            var connString = ConfigurationManager.ConnectionStrings["DemoConnection"].ConnectionString;
            string sqlExpression = "SELECT * FROM Companys";
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();


                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        Company.Items.Add(reader.GetValue(1).ToString());                       
                    }
                }
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

            {             
                    decimal val;
                    bool result = decimal.TryParse(Rate.Text, out val);
                if (_companyId == 0) MessageBox.Show("Выберите организацию ");
                if (_companyId > 0)
                if (result == true)
                {
                  
                     {
                            var car = new Car()
                            {
                                Company_Id = _companyId,                       
                                Driver = Driver.Text,
                                Brand = Brand.Text,
                                Number = Number.Text,
                                Rate = val
                            };                       
                             car.Insert();
                            Close();
                         
                     }
                }

                else MessageBox.Show("Формат ввода поле ТАРИФ: 00,00");
              
            }
        }

        private void button_Click2(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Company.Text == null) ;
                Company.Text = "";
                Driver.Text = "";
                Brand.Text = "";
                Number.Text = "";
                Rate.Text = "";
                MainWindowCar.car.Clear();
            }
            catch
            {
            }
        }

        private void cb_Selected(object sender, RoutedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            string tit = comboBox.SelectedItem.ToString();
            var connString = ConfigurationManager.ConnectionStrings["DemoConnection"].ConnectionString;
            string sqlExpression = "SELECT * FROM Companys";
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        if (reader.GetValue(1).ToString() == tit)
                        {
                            _companyId = Convert.ToInt32(reader.GetValue(0).ToString());
                        }                        
                    }
                }
            }           
        }

    }
}
