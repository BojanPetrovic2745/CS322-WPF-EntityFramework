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
using System.Windows.Shapes;

namespace CS322_WPF_EntityFramework_BojanPetrovic2745
{
    /// <summary>
    /// Interaction logic for UpdatePage.xaml
    /// </summary>
    public partial class UpdatePage : Window
    {
        wpfCrudEntities _db = new wpfCrudEntities();
        int Id;

        public UpdatePage(int memberId)
        {
            InitializeComponent();
            Id = memberId;
        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            member updateMember = (from m in _db.members
                                   where m.Id == Id
                                   select m).Single();
            updateMember.name = tbName.Text;
            updateMember.gender = cbGender.Text;
            _db.SaveChanges();
            MainWindow.dataGrid.ItemsSource = _db.members.ToList();
            this.Hide();
        }
    }
}
