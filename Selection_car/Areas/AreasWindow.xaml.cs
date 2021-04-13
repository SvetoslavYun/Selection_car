using System;
using System.Windows;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.Windows.Controls;
using System.Configuration;
using Microsoft.Office.Interop.Excel;
using System.Windows.Input;

namespace Selection_car.Areas
{
    public partial class AreasWindow : Microsoft.Office.Interop.Excel.Window
    {
        public static bool flag;//добавить/изменить
        ObservableCollection<Area> Areas;
        public static int _id;
        public static int _companyId;
        public static String Variable;
        public static String name;
        public static String driver;
        public static Area area;

        public AreasWindow()
        {
            Areas = new ObservableCollection<Area>();
            InitializeComponent();
            lBox.DataContext = Areas;
            FillData();

            var connString = ConfigurationManager.ConnectionStrings["DemoConnection"].ConnectionString;
            string sqlExpression = "Select * from Areas ORDER BY Are ASC";
            using (SQLiteConnection connection = new SQLiteConnection(connString))
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(sqlExpression, connection);
                SQLiteDataReader reader = command.ExecuteReader();


                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        textBox.Items.Add(reader.GetValue(1).ToString());

                    }
                }
            }
        }

        public void FillData()//заполнить список
        {
            Areas.Clear();
            foreach (var item in Area.GetAllArea())
            {
                Areas.Add(item);
            }
        }

        public void FillData_Search()//заполнить список
        {
            Areas.Clear();
            foreach (var item in Area.Area_Search())
            {
                Areas.Add(item);
            }
        }

        private void btnFill_Click(object sender, RoutedEventArgs e)
        {
            FillData();
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            if (Name_Password.Admin == "Администратор")
            {
                try
            {
                if ((Area)lBox.SelectedItem == null) throw new Exception("Не выбрана строка, произведите выбор");
                var id = ((Area)lBox.SelectedItem).Areas_Id;
                Area.Delete(id);
                FillData();
            }
            catch (Exception h)
            {
                MessageBox.Show(h.Message);
            }
            }
            else
            {
                MessageBox.Show("Права доступа ограничены ");
            }

        }

        private void btnAdd__Click(object sender, RoutedEventArgs e)
        {
            if (Name_Password.Admin == "Администратор")
            {
                BD_Areas bd_Areas = new BD_Areas();
            bd_Areas.Owner = this;//первичное окно назначаем главным
            bd_Areas.ShowDialog();//ждет закрытия окна
            FillData();
            }
            else
            {
                MessageBox.Show("Права доступа ограничены ");
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (Name_Password.Admin == "Администратор")
            {
                {
                try
                {
                    var id = ((Area)lBox.SelectedItem).Areas_Id;
                    {
                        area = (Area)lBox.SelectedItem;
                        area.Update();
                        FillData();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Не выбрана строка, произведите выбор");
                }
                }
            }
            else
            {
                MessageBox.Show("Права доступа ограничены ");
            }
        }

        private void dGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = e.Row.GetIndex() + 1;
        }

        private void to_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.Text == "") MessageBox.Show("Введите данные");
            if (textBox.Text != "")
            {

                bool result = int.TryParse(textBox.Text, out AreasWindow._id);
                if (result == true) ;
                else AreasWindow.name = textBox.Text;
                FillData_Search();
                try
                {

                    AreasWindow._id = 0;
                    AreasWindow.name = "";
                    AreasWindow.area.Clear();
                }
                catch
                {
                }

                try
                {
                    if (textBox.Text == null) ;
                    textBox.Text = "";
                    AreasWindow.area.Clear();
                }
                catch
                {
                }
            }

        }

        private void to_Delet(object sender, RoutedEventArgs e)
        {
            try
            {
                if (textBox.Text == null) ;
                textBox.Text = "";
                AreasWindow.area.Clear();
            }
            catch
            {
            }
        }

        private void comboBox_Driver_DropDownOpened(object sender, EventArgs e)
        {
            if (textBox.Items.Contains(textBox.Text) == false)
            {
                textBox.Items.Add(textBox.Text);
            }
        }
        private void bth_MainWindow(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show(); //ждет закрытия окна         
            this.Close();
        }

        private void button_Click7(object sender, RoutedEventArgs e)
        {
            lBox.SelectAllCells();
            lBox.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
            ApplicationCommands.Copy.Execute(null, lBox);
            try
            {
                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Visible = true;
                Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
                Worksheet sheet1 = (Worksheet)workbook.Sheets[1];

                for (int j = 0; j < lBox.Columns.Count; j++)
                {
                    Range myRange = (Range)sheet1.Cells[1, j + 1];
                    sheet1.Cells[1, j + 1].Font.Bold = true;
                    sheet1.Columns[j + 1].ColumnWidth = 35;
                    myRange.Value2 = lBox.Columns[j].Header;
                }
                for (int i = 0; i < lBox.Columns.Count; i++)
                {
                    for (int j = 0; j < lBox.Items.Count; j++)
                    {
                        TextBlock b = lBox.Columns[i].GetCellContent(lBox.Items[j]) as TextBlock;
                        Range myRange = (Range)sheet1.Cells[j + 2, i + 1];
                        myRange.Value2 = b.Text;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Данные сохранены в документ Excel ");
            }
            this.WindowState = WindowState.Minimized;
        }

        dynamic Microsoft.Office.Interop.Excel.Window.Activate()
        {
            throw new NotImplementedException();
        }

        public dynamic ActivateNext()
        {
            throw new NotImplementedException();
        }

        public dynamic ActivatePrevious()
        {
            throw new NotImplementedException();
        }

        public bool Close(object SaveChanges, object Filename, object RouteWorkbook)
        {
            throw new NotImplementedException();
        }

        public dynamic LargeScroll(object Down, object Up, object ToRight, object ToLeft)
        {
            throw new NotImplementedException();
        }

        public Microsoft.Office.Interop.Excel.Window NewWindow()
        {
            throw new NotImplementedException();
        }

        public dynamic _PrintOut(object From, object To, object Copies, object Preview, object ActivePrinter, object PrintToFile, object Collate, object PrToFileName)
        {
            throw new NotImplementedException();
        }

        public dynamic PrintPreview(object EnableChanges)
        {
            throw new NotImplementedException();
        }

        public dynamic ScrollWorkbookTabs(object Sheets, object Position)
        {
            throw new NotImplementedException();
        }

        public dynamic SmallScroll(object Down, object Up, object ToRight, object ToLeft)
        {
            throw new NotImplementedException();
        }

        public int PointsToScreenPixelsX(int Points)
        {
            throw new NotImplementedException();
        }

        public int PointsToScreenPixelsY(int Points)
        {
            throw new NotImplementedException();
        }

        public dynamic RangeFromPoint(int x, int y)
        {
            throw new NotImplementedException();
        }

        public void ScrollIntoView(int Left, int Top, int Width, int Height, object Start)
        {
            throw new NotImplementedException();
        }

        public dynamic PrintOut(object From, object To, object Copies, object Preview, object ActivePrinter, object PrintToFile, object Collate, object PrToFileName)
        {
            throw new NotImplementedException();
        }

        public Microsoft.Office.Interop.Excel.Application Application => throw new NotImplementedException();

        public XlCreator Creator => throw new NotImplementedException();

        dynamic Microsoft.Office.Interop.Excel.Window.Parent => throw new NotImplementedException();

        public Range ActiveCell => throw new NotImplementedException();

        public Chart ActiveChart => throw new NotImplementedException();

        public Pane ActivePane => throw new NotImplementedException();

        public dynamic ActiveSheet => throw new NotImplementedException();

        public dynamic Caption { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool DisplayFormulas { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool DisplayGridlines { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool DisplayHeadings { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool DisplayHorizontalScrollBar { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool DisplayOutline { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool _DisplayRightToLeft { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool DisplayVerticalScrollBar { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool DisplayWorkbookTabs { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool DisplayZeros { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool EnableResize { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool FreezePanes { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int GridlineColor { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public XlColorIndex GridlineColorIndex { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int Index => throw new NotImplementedException();

        public string OnWindow { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Panes Panes => throw new NotImplementedException();

        public Range RangeSelection => throw new NotImplementedException();

        public int ScrollColumn { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int ScrollRow { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Sheets SelectedSheets => throw new NotImplementedException();

        public dynamic Selection => throw new NotImplementedException();

        public bool Split { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int SplitColumn { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double SplitHorizontal { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int SplitRow { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double SplitVertical { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double TabRatio { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public XlWindowType Type => throw new NotImplementedException();

        public double UsableHeight => throw new NotImplementedException();

        public double UsableWidth => throw new NotImplementedException();

        public bool Visible { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Range VisibleRange => throw new NotImplementedException();

        public int WindowNumber => throw new NotImplementedException();

        XlWindowState Microsoft.Office.Interop.Excel.Window.WindowState { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public dynamic Zoom { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public XlWindowView View { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool DisplayRightToLeft { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public SheetViews SheetViews => throw new NotImplementedException();

        public dynamic ActiveSheetView => throw new NotImplementedException();

        public bool DisplayRuler { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool AutoFilterDateGrouping { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool DisplayWhitespace { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int Hwnd => throw new NotImplementedException();
    }
}




