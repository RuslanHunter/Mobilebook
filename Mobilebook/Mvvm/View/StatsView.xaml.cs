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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Mobilebook.Mvvm.View
{
    /// <summary>
    /// Логика взаимодействия для Stats.xaml
    /// </summary>
    public partial class Stats : UserControl
    {
        public Stats()
        {
            InitializeComponent();

            using (MobilebookdbContext context = new MobilebookdbContext())
            {
                List<Call> calls = context.Calls.ToList();
                List<CallUser> callUsers = context.CallUsers.ToList();
                var leftjoinquery = from Call in calls
                                    join CallUser in callUsers
                on Call.IdCall equals CallUser.IdCall
                                    select new { Call.IdCall, CallUser.IdCallUser, CallUser.IdUser};
                leftjoinquery.ToList();
                var count = leftjoinquery.Where(c => c.IdUser == Auth.CurrentUser).Count();
                Countblock.Text = count.ToString();
            }

        }
    }
}
