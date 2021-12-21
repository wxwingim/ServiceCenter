using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using UIServiceCenter.Model;
using DataBase;

namespace UIServiceCenter.ViewModel
{
    public class CustomersViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private IMainWindowsCodeBehind _MainCodeBehind;

        public CustomersViewModel(IMainWindowsCodeBehind codeBehind)
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
