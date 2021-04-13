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
            Type.Items.Add("Администратор");
            Type.Items.Add("Пользователь");
            button_Click2();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindowUser.flag)//добавление 
            {
                if (Name.Text == "") MessageBox.Show("Введите Имя пользователя");
                if (Name.Text != "")
                {
                    if (Password.Text == "") MessageBox.Show("Введите Пароль");
                    if (Password.Text != "")
                    {
                        if (Name_Password.RadioAdmin == "2")
                        {
                            if (Type.Text == "") MessageBox.Show("Выберите Права пользователя");
                            if (Type.Text != "")
                            {
                                var user = new User()
                                {
                                    Name = Name.Text,
                                    Password = Password.Text,
                                    Type = Type.Text,
                                };
                                user.Insert();
                                Close();
                            }
                        }
                            if (Name_Password.RadioAdmin == "1")
                            {
                                var user = new User()
                                {
                                    Name = Name.Text,
                                    Password = Password.Text,
                                    Type = "Администратор",
                                };
                                user.Insert();
                                Name_Password.Admin = "Администратор";
                            Close();
                            }
                        Name_Password.RadioAdmin = "2";
                    }
                } 
            }
            if (!MainWindowUser.flag)//изменение
            {
                if (Name.Text == "") MessageBox.Show("Введите Имя пользователя");
                if (Name.Text != "")
                {
                    if (Password.Text == "") MessageBox.Show("Введите Пароль");
                    if (Password.Text != "")
                    {
                        if (MainWindowUser._id != 1)
                        {
                            if (Type.Text == "") MessageBox.Show("Выберите Права пользователя");
                            if (Type.Text != "")
                            {                               
                                MainWindowUser.name2 = Type.Text;
                                MainWindowUser.user.Update();
                                MainWindowUser.user.Clear();
                                Close();
                            }
                        }
                        if (MainWindowUser._id == 1)
                        {
                            Name_Password.RadioAdmin = "1";
                           
                                MainWindowUser.name2 = "Администратор";
                                MainWindowUser.user.Update();
                                MainWindowUser.user.Clear();
                                Close();
                        }
                    }
                }
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

        private void button_Click2()
        {
            if (MainWindowUser.radioBD == "1")
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
}
