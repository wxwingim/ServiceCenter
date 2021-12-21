using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Media;
using UIServiceCenter.Model;
using UIServiceCenter.View;

namespace UIServiceCenter.ViewModel
{
    public class AddEmployeeView : INotifyPropertyChanged
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
        private string _position;

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

        public string Position
        {
            get { return _position; }
            set
            {
                if (_position != value)
                {
                    _position = value;
                    NotifyPropertyChanged("Position");
                }
            }
        }

        //private RelayCommand addNewEmployee;

        //public RelayCommand AddNewEmployee
        //{
        //    get
        //    {
        //        return addNewEmployee = addNewEmployee ??
        //          new RelayCommand(CreateNewEmployee);
        //    }
        //}

        public void CreateNewEmployee()
        {
            DataWorker.CreateEmployee(LastName, FirstName, MiddleName, Phone, Email, Position);
        }
    }
}
