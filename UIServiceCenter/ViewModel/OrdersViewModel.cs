using DataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using UIServiceCenter.Model;


namespace UIServiceCenter.ViewModel
{
    public class OrdersViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private IMainWindowsCodeBehind _MainCodeBehind;

        public OrdersViewModel(IMainWindowsCodeBehind codeBehind)
        {
            if (codeBehind == null) throw new ArgumentNullException(nameof(codeBehind));

            _MainCodeBehind = codeBehind;
        }
        private void NotifyPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        /// Все заказы
        /// </summary>
        private List<OrderModel> allOrders = DataWorker.GetAllOrders();

        public List<OrderModel> AllOrders
        {
            get { return allOrders; }
            set
            {
                allOrders = value;
                NotifyPropertyChanged("AllOrders");
            }
        }

        /// <summary>
        /// Все статусы ремонта
        /// </summary>
        private List<StatusRepair> allStatusesRepair = DataWorker.GetStatusRepairsWithAll();

        public List<StatusRepair> AllStatusesRepair
        {
            get { return allStatusesRepair; }
            set
            {
                allStatusesRepair = value;
                NotifyPropertyChanged("AllStatusesRepair");
            }
        }
    }

}
