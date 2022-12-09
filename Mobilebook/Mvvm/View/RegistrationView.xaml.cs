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

namespace Mobilebook
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            using (MobilebookdbContext context = new MobilebookdbContext())
            {
                User user = new User()
                {
                    Name = Namebox.Text,
                    Surname= Surnamebox.Text,
                    Patronymic=Patronymicbox.Text,
                    NaturalLegacyEntity = Licobox.Text,
                    Phone = Mobilebox.Text,
                    Login = Loginbox.Text,
                    Password= Passwordbox.Text,
                };
                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        private void CloseReg_Click(object sender, RoutedEventArgs e)
        {
            Auth auth = new Auth();
            auth.Show();
            this.Close();
        }
    }
}
