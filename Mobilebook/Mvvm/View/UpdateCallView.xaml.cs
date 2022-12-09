using Mobilebook.Mvvm.Model;
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

namespace Mobilebook.Mvvm.View
{
    /// <summary>
    /// Логика взаимодействия для UpdateCall.xaml
    /// </summary>
    public partial class UpdateCall : Window
    {
        public UpdateCall()
        {
            InitializeComponent();
        }

        private void CloseUpdate_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Updatecall_Click(object sender, RoutedEventArgs e)
        {
            CallsView callsView = new CallsView();

            using(MobilebookdbContext context = new MobilebookdbContext())
            {
                Call selectedCall = callsView.zvonkigrid.SelectedItem as Call;

                Call updatecall = context.Calls.Find(selectedCall);

                updatecall.PhoneAbonent = Abonentbox.Text;
                updatecall.Date = Timebox.Text;
                context.SaveChanges();
            }
            this.Close();
        }
    }
}
