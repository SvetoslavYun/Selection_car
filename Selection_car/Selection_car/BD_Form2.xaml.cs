using System;
using System.Windows;

namespace Selection_car
{

    public partial class BD_User : Window
    {
        public BD_User()
        {
            InitializeComponent();
            grid.DataContext = MainWindow2.user;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow2.flag)//добавление
            {
                var user = new User()
                {
                    Name = Name.Text,
                    Password = Password.Text,
                };
                user.Insert();
                Close();
            }
            if (!MainWindow2.flag)//изменение
            {
                MainWindow2.user.Update();
                MainWindow2.user.Clear();
                Close();
            }
        }

        private void button_Click2(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Name.Text == null) ;
                Name.Text = "";
                Password.Text = "";
                MainWindow2.user.Clear();
            }
            catch
            {
            }
        }
    }
}
