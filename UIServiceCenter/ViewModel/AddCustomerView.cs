using System;
using System.ComponentModel;
using UIServiceCenter.Model;

namespace UIServiceCenter.ViewModel
{
    public class AddCustomerView : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private string _lastName;
        private string _firstName;
        private string? _middleName;
        private string _phone;
        private string _email;

        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (_lastName != value)
                {
                    _lastName = value;
                    NotifyPropertyChanged("LastName");
                }
            }
        }
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (_firstName != value)
                {
                    _firstName = value;
                    NotifyPropertyChanged("FirstName");
                }
            }
        }
        public string MiddleName
        {
            get { return _middleName; }
            set
            {
                if (_middleName != value)
                {
                    _middleName = value;
                    NotifyPropertyChanged("MiddleName");
                }
            }
        }
        public string Phone
        {
            get { return _phone; }
            set
            {
                if (_phone != value)
                {
                    _phone = value;
                    NotifyPropertyChanged("Phone");
                }
            }
        }
        public string Email
        {
            get { return _email; }
            set
            {
                if (_email != value)
                {
                    _email = value;
                    NotifyPropertyChanged("Email");
                }
            }
        }


        //private RelayCommand addNewCustomer;

        //public RelayCommand AddNewCustomer
        //{
        //    get
        //    {
        //        return addNewCustomer = addNewCustomer ??
        //          new RelayCommand(CreateNewCustomer);
        //    }
        //}

        public void CreateNewCustomer()
        {
            DataWorker.CreateCustomer(_lastName, _firstName, _middleName, _phone, _email);
        }
    }
}
