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
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        GamesTableAdapter Games = new GamesTableAdapter();
        PlatformsTableAdapter Platforms = new PlatformsTableAdapter();
        DevelopersTableAdapter Developers = new DevelopersTableAdapter();
        public Window1()
        {
            InitializeComponent();
            MyDataGrid.ItemsSource = Games.GetData();
            ColumnBox2.ItemsSource = Developers.GetData();
            ColumnBox2.DisplayMemberPath = "Studio_Name";
            ColumnBox3.ItemsSource = Platforms.GetData();
            ColumnBox3.DisplayMemberPath = "Platform_Name";
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
            Games.InsertGames(ColumnBox1.Text, (int)(ColumnBox2.SelectedItem as DataRowView).Row[0], (int)(ColumnBox3.SelectedItem as DataRowView).Row[0]);
            MyDataGrid.ItemsSource = Games.GetData();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            object id = (MyDataGrid.SelectedItem as DataRowView).Row[0];
            Games.DeleteGames(Convert.ToInt32(id));
            MyDataGrid.ItemsSource = Games.GetData();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            object id = (MyDataGrid.SelectedItem as DataRowView).Row[0];
            Games.GamesUpdate(ColumnBox1.Text, (int)(ColumnBox2.SelectedItem as DataRowView).Row[0], (int)(ColumnBox3.SelectedItem as DataRowView).Row[0], Convert.ToInt32(id));
            MyDataGrid.ItemsSource = Games.GetData();
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
