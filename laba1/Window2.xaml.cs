using laba1.dartbaseDataSetTableAdapters;
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
using System.Windows.Shapes;

namespace laba1
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        PlatformsTableAdapter Platforms = new PlatformsTableAdapter();
        GamesTableAdapter Games = new GamesTableAdapter();
        public Window2()
        {
            InitializeComponent();
            MyDataGrid.ItemsSource = Platforms.GetData();
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
            Platforms.InsertPlatforms(ColumnBox2.Text);
            MyDataGrid.ItemsSource = Platforms.GetData();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            object id = (MyDataGrid.SelectedItem as DataRowView).Row[0];
            Platforms.DeletePlatforms(Convert.ToInt32(id));
            MyDataGrid.ItemsSource = Platforms.GetData();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            object id = (MyDataGrid.SelectedItem as DataRowView).Row[0];
            Platforms.PlatformsUpdate(ColumnBox2.Text, Convert.ToInt32(id));
            MyDataGrid.ItemsSource = Platforms.GetData();
        }

        private void MyDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MyDataGrid.SelectedItem != null)
            {
                var id = MyDataGrid.SelectedItem as DataRowView;
                ColumnBox2.Text = id.Row[1] as string;
            }
        }
    }
}
