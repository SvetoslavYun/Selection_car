﻿
using System.Windows;

namespace Selection_car
{
    /// <summary>
    /// Логика взаимодействия для To_ID.xaml
    /// </summary>
    public partial class To_NameId : Window
    {
        public To_NameId()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            bool result = int.TryParse(textBox.Text, out MainWindowUser._id);
            if (result == true) Close();
            else MainWindowUser.name = textBox.Text;
            Close();
        }
    }
}
