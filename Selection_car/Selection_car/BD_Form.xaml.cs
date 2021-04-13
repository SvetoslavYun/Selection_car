using System;
using System.Windows;

namespace Selection_car
{

    public partial class BD_Form : Window
    {      
        public BD_Form()
        {           
            InitializeComponent();
            grid.DataContext = MainWindow.car;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

            {
                bool result = decimal.TryParse(Rate.Text, out MainWindow.b);
                if (result == true) Close();
                else MessageBox.Show("Ввод должен быть численный");
            }

            if (MainWindow.flag)   ///добавление
            {

                var car = new Car()
                {
                    Company = Company.Text,
                    Brand = Brand.Text,
                    Number = Number.Text,
                    Rate = MainWindow.b
                };

                car.Insert();
                Close();
            }

            if (!MainWindow.flag)    ///изменение
            {
                MainWindow.car.Update();
                Close();          
            }
        }
    }
}
