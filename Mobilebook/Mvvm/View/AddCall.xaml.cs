using Mobilebook.Mvvm.Model;
using Mobilebook.Mvvm.ViewModel;
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
    /// Логика взаимодействия для AddCall.xaml
    /// </summary>
    public partial class AddCall : Window
    {
        public AddCall()
        {
            InitializeComponent();
        }

        private void CloseAdd_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Addcall_Click(object sender, RoutedEventArgs e)
        {
            Auth auth = new Auth();
            using (MobilebookdbContext context = new MobilebookdbContext())
            {
                var priceid = context.Prices.Where(p => p.TimeOfDay == Timeofdatbox.Text && p.City == Citybox.Text).FirstOrDefault();

                Call call = new Call()
                {
                    PhoneAbonent = Abonentbox.Text,
                    Date = Timebox.Text,
                    Duration = Convert.ToInt32(Durationbox.Text),
                    IdPrice = priceid.IdPrice,
                };
                context.Calls.Add(call);

                context.SaveChanges();

                CallUser callUser = new CallUser()
                {
                    IdCall = call.IdCall,
                    IdUser = Auth.CurrentUser,
                    OutInt = outinbox.Text,
                    Cost = priceid.Tariff * Convert.ToInt32(Durationbox.Text),
                };
                context.CallUsers.Add(callUser);

                context.SaveChanges();
            }
            CallsView clvs = new CallsView();
            clvs.VivodDtg();
            this.Close();
        }
    }
}
