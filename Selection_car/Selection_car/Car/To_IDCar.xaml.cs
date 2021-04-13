
using System.Windows;

namespace Selection_car
{
    /// <summary>
    /// Логика взаимодействия для To_ID.xaml
    /// </summary>
    public partial class To_ID : Window
    {
        public To_ID()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            bool result = int.TryParse(textBox.Text, out MainWindowCar._id);
            if (result == true) Close();
            else MessageBox.Show("Введите корректное значение ID");
        }
    }
}
