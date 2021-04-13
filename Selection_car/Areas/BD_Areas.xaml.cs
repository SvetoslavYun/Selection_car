using System.Windows;
using Selection_car.Areas;

namespace Selection_car
{

    public partial class BD_Areas : Window
    {
        public BD_Areas()
        {
            InitializeComponent();           
            grid.DataContext = AreasWindow.area;
            button_Click2();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            var user = Area.GetArea(Are.Text);
            if (user == null)
            {
                if (Are.Text == "") MessageBox.Show("Введите название маршрута");
                if (Are.Text != "")
                {
                    decimal val2;
                    bool result2 = decimal.TryParse(Distance.Text, out val2);
                    if (result2 == true)
                    {
                        decimal val;
                        bool result = decimal.TryParse(BelTol.Text, out val);
                        if (result == true)
                        {
                            var area = new Area()
                        {
                            Are = Are.Text,
                            Cities = Cities.Text,
                            Distance = val2,
                            Days = Days.Text,
                            BelTol = val
                        };
                        area.Insert();
                        Close();
                        }
                        else MessageBox.Show("Формат ввода Кол.во пунктов Белтола: 0");
                    }
                    else MessageBox.Show("Формат ввода поле Растояние Км: 0,00");
                }
                
            }
            else
            {
                MessageBox.Show("Такой Маршрут уже есть");
            }
        }

        private void button_Click2(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Are.Text == null) ;
                Are.Text = "";
                Cities.Text = "";
                Distance.Text = "";
                Days.Text = "";

                AreasWindow.area.Clear();
            }
            catch
            {
            }
        }

        private void button_Click2()
        {
            try
            {
                if (Are.Text == null) ;
                Are.Text = "";
                Cities.Text = "";
                Distance.Text = "";
                Days.Text = "";

                AreasWindow.area.Clear();
            }
            catch
            {
            }
        }
    }
}
