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
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindowCompany.flag)//добавление
            {
                var company = new Company()
                {
                    Name = Name.Text,
                    Adres = Adres.Text,
                    Number_Phone = Number.Text,
                };
                company.Insert();
                Close();
            }
            if (!MainWindowCompany.flag)//изменение
            {
                MainWindowCompany.company.Update();
                MainWindowCompany.company.Clear();
                Close();
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
    }
}
