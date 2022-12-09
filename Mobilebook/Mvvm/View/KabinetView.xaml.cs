using Mobilebook.Mvvm.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
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
    /// Логика взаимодействия для KabinetView.xaml
    /// </summary>
    public partial class KabinetView : UserControl
    {
        public KabinetView()
        {
            InitializeComponent();
            using (MobilebookdbContext context = new MobilebookdbContext())
            {
                User user = context.Users.Find(Auth.CurrentUser);
                Phoneblock.Text = user.Phone;
                Nameblock.Text = user.Name;
                Surnameblock.Text = user.Surname;
                Patronymicblock.Text = user.Patronymic;
            }
        }
    }
}
