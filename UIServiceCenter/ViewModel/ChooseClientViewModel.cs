using DataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using UIServiceCenter.Model;

namespace UIServiceCenter.ViewModel
{
    public class ChooseClientViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        /// Все клиенты
        /// </summary>
        private List<Customer> allCustomers = DataWorker.GetAllCustomers();

        public List<Customer> AllCustomers
        {
            get { return allCustomers; }
            set
            {
                allCustomers = value;
                NotifyPropertyChanged("AllCustomers");
            }
        }


    }
}
