using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using laba1.dartbaseDataSetTableAdapters;

namespace laba1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DevelopersTableAdapter Developers = new DevelopersTableAdapter();
        public MainWindow()
        {
            InitializeComponent();
            MyDataGrid.ItemsSource = Developers.GetData();
        }

        private void DevelopersButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow DevelopersDS = new MainWindow();
            DevelopersDS.Show();
            Close();
        }

        private void GamesButton_Click(object sender, RoutedEventArgs e)
        {
            Window1 GamesDS = new Window1();
            GamesDS.Show();
            Close();
        }

        private void PlatformsButton_Click(object sender, RoutedEventArgs e)
        {
            Window2 PlatformsDS = new Window2();
            PlatformsDS.Show();
            Close();
        }

        private void InsertButton_Click(object sender, RoutedEventArgs e)
        {
            Developers.InsertDevelopers(ColumnBox1.Text, Convert.ToInt32(ColumnBox2.Text), ColumnBox3.Text);
            MyDataGrid.ItemsSource = Developers.GetData();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            object id = (MyDataGrid.SelectedItem as DataRowView).Row[0];
            Developers.DeleteDevelopers(Convert.ToInt32(id));
            MyDataGrid.ItemsSource = Developers.GetData();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            object id = (MyDataGrid.SelectedItem as DataRowView).Row[0];
            Developers.DevelopersUpdate(ColumnBox1.Text, Convert.ToInt32(ColumnBox2.Text), ColumnBox3.Text, Convert.ToInt32(id));
            MyDataGrid.ItemsSource = Developers.GetData();
        }

        private void MyDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MyDataGrid.SelectedItem != null)
            {
                var id = MyDataGrid.SelectedItem as DataRowView;
                ColumnBox1.Text = id.Row[1] as string;
                ColumnBox2.Text = Convert.ToInt32(id.Row[2]).ToString();
                ColumnBox3.Text = id.Row[3] as string;
            }
        }
    }
}
