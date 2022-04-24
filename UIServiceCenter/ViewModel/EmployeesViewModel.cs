using DataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using UIServiceCenter.Model;

namespace UIServiceCenter.ViewModel
{
    public class EmployeesViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private IMainWindowsCodeBehind _MainCodeBehind;

        public EmployeesViewModel(IMainWindowsCodeBehind codeBehind)
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



        //Commands

        /// <summary>
        /// Все сотрудники
        /// </summary>
        private List<Employee> allEmployees = DataWorker.GetAllEmployees();

        public List<Employee> AllEmployees
        {
            get { return allEmployees; }
            set
            {
                allEmployees = value;
                NotifyPropertyChanged("AllEmployees");
            }
        }
    }
}
