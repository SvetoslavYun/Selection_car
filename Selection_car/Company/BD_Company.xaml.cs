using System;
using System.Windows;

namespace Selection_car
{

    public partial class BD_Company : Window
    {
        public BD_Company()
        {
            InitializeComponent();
            grid.DataContext = MainWindowCompany.company;
            button_Click2();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            var user = Company.GetCompany(Name.Text);
            if (user == null)
            {
                if (Name.Text == "") MessageBox.Show("Введите название организации");
                if (Name.Text != "")
                {
                    var company = new Company()
                    {
                        Name = Name.Text,
                        Adres = Adres.Text,
                        Number_Phone = Number.Text,
                        Rate = 0,
                        Rate1 = 0,
                        Rate2 = 0,
                        Rate3 = 0,
                        Rate4 = 0,
                        Rate5 = 0,
                        Rate6 = 180,
                        Rate7=0,
                        Terminate = ""
                    };
                    company.Insert();
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Такая организация уже есть");
            }

        }

        private void button_Click2(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Name.Text == null) ;
                Name.Text = "";
                Adres.Text = "";
                Number.Text = "";
               
                MainWindowCompany.company.Clear();
            }
            catch
            {
            }
        }

        private void button_Click2()
        {
            try
            {
                if (Name.Text == null) ;
                Name.Text = "";
                Adres.Text = "";
                Number.Text = "";

                MainWindowCompany.company.Clear();
            }
            catch
            {
            }
        }
    }
}
