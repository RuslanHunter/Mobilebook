using Microsoft.Identity.Client;
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
using System.Windows.Shapes;
using Mobilebook.Mvvm.ViewModel;

namespace Mobilebook
{
    /// <summary>
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class Auth : Window
    {
        public Auth()
        {
            InitializeComponent();
        }

        static public int CurrentUser { get; set; }


        private void Authin_Click(object sender, RoutedEventArgs e)
        {
            if (Loginbox.Text == "" || Passwordbox.Password == "")
            {
                CustomMessageBox cs = new CustomMessageBox();
                cs.TXT.Text = "Есть пустые поля❤";
                cs.Show();
            }
            else
            {
                using (MobilebookdbContext context = new MobilebookdbContext())
                {
                    User auth = null;

                    auth = context.Users.Where(user => user.Login == Loginbox.Text && user.Password == Passwordbox.Password).FirstOrDefault();
                    if (auth != null)
                    {
                        MainWindow mw = new MainWindow();
                        mw.Show();
                        this.Close();

                        CurrentUser = auth.IdUser;

                    }
                    else
                    {
                        CustomMessageBox cs = new CustomMessageBox(); 
                        cs.Show();
                    }
                }
            }
        }

        private void OpenReg_Click(object sender, RoutedEventArgs e)
        {
            Registration reg = new Registration();
            reg.Show();
            this.Close();
        }
    }
}
