using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Mobilebook.Mvvm.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    /// Логика взаимодействия для CallsViewModel.xaml
    /// </summary>
    public partial class CallsView : UserControl
    {

        public CallsView()
        {
            InitializeComponent();
            VivodDtg();
        }


        public void VivodDtg()
        {
            using (MobilebookdbContext context = new MobilebookdbContext())
            {
                List<Call> calls = context.Calls.ToList();
                List<CallUser> callUsers = context.CallUsers.ToList();

                var leftjoinquery = from Call in calls
                                    join CallUser in callUsers
                on Call.IdCall equals CallUser.IdCall
                                    select new { Call.IdCall, Call.PhoneAbonent, Call.Date, Call.Duration, CallUser.OutInt, CallUser.Cost };
                zvonkigrid.ItemsSource = leftjoinquery.ToList();
            }
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            AddCall adc = new AddCall();
            adc.Show();
        }


        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            using (MobilebookdbContext context = new MobilebookdbContext())
            {
                CallUser selectedCallUser = zvonkigrid.SelectedItem as CallUser;
                Call selectedUser = zvonkigrid.SelectedItem as Call;

                if (selectedCallUser != null && selectedUser != null)
                {
                    CallUser callUser = context.CallUsers.Find(selectedCallUser.IdCallUser);
                    context.CallUsers.Remove(selectedCallUser);
                    context.SaveChanges();
                    Call call = context.Calls.Find(selectedUser.IdCall);
                    context.Calls.Remove(selectedUser);
                    context.SaveChanges();
                }

            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            UpdateCall updateCall = new UpdateCall();
            updateCall.Show();
        }











        public class PagingCollectionView : CollectionView
        {
            private readonly IList _innerList;
            private readonly int _itemsPerPage;

            private int _currentPage = 1;

            public PagingCollectionView(IList innerList, int itemsPerPage)
                : base(innerList)
            {
                this._innerList = innerList;
                this._itemsPerPage = itemsPerPage;
            }

            public override int Count
            {
                get
                {
                    if (this._innerList.Count == 0) return 0;
                    if (this._currentPage < this.PageCount)
                    {
                        return this._itemsPerPage;
                    }
                    else
                    {
                        var itemsLeft = this._innerList.Count % this._itemsPerPage;
                        if (0 == itemsLeft)
                        {
                            return this._itemsPerPage;
                        }
                        else
                        {

                            return itemsLeft;
                        }
                    }
                }
            }

            public int CurrentPage
            {
                get { return this._currentPage; }
                set
                {
                    this._currentPage = value;
                    this.OnPropertyChanged(new PropertyChangedEventArgs("CurrentPage"));
                }
            }

            public int ItemsPerPage { get { return this._itemsPerPage; } }

            public int PageCount
            {
                get
                {
                    return (this._innerList.Count + this._itemsPerPage - 1)
                        / this._itemsPerPage;
                }
            }
        }
    }
}
