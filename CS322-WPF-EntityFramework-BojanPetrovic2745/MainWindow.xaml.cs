using System;
using System.Collections.Generic;
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

namespace CS322_WPF_EntityFramework_BojanPetrovic2745
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        wpfCrudEntities _db = new wpfCrudEntities();
        public static DataGrid dataGrid;
        public MainWindow()
        {
            InitializeComponent();
            Load();
        }

        private void Load()
        {
            myDataGrid.ItemsSource = _db.members.ToList();
            dataGrid = myDataGrid;
        }

        private void insertBtn_Click(object sender, RoutedEventArgs e)
        {
            InsertPage Ipage = new InsertPage();
            Ipage.ShowDialog();
        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
           int id = (myDataGrid.SelectedItem as member).Id;
           UpdatePage Upage = new UpdatePage(id);
           Upage.ShowDialog();
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            int Id = (myDataGrid.SelectedItem as member).Id;
            var deleteMember = _db.members.Where(m => m.Id == Id).Single();
            _db.members.Remove(deleteMember);
            _db.SaveChanges();
            myDataGrid.ItemsSource = _db.members.ToList();
        }
    }
}
