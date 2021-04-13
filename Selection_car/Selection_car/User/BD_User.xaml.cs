using System;
using System.Windows;

namespace Selection_car
{

    public partial class BD_User : Window
    {
        public BD_User()
        {
            InitializeComponent();
            grid.DataContext = MainWindowUser.user;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindowUser.flag)//добавление
            {
                var user = new User()
                {
                    Name = Name.Text,
                    Password = Password.Text,
                };
                user.Insert();
                Close();
            }
            if (!MainWindowUser.flag)//изменение
            {
                MainWindowUser.user.Update();
                MainWindowUser.user.Clear();
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
                MainWindowUser.user.Clear();
            }
            catch
            {
            }
        }
    }
}
