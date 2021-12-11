using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using UIServiceCenter.View;
using System.Windows;
using UIServiceCenter.Model;

namespace UIServiceCenter.ViewModel
{
    public class EmployeesViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        //Fields
        private IMainWindowsCodeBehind _MainCodeBehind;

        //ctor
        public EmployeesViewModel(IMainWindowsCodeBehind codeBehind)
        {
            if (codeBehind == null) throw new ArgumentNullException(nameof(codeBehind));

            _MainCodeBehind = codeBehind;
        }


        // command
        private RelayCommand2 addNewEmployeeWin;
        public RelayCommand2 AddNewEmployeeWin
        {
            get
            {
                return  new RelayCommand2(obj =>
                {
                    OpenAddNewEmployee();
                } 
                );
            }
        }

        /*
        private RelayCommand _addNewEmployeeWin;
        public RelayCommand AddNewEmployeeWin
        {
            get
            {
                return _addNewEmployeeWin = _addNewEmployeeWin ??
                  new RelayCommand(OnShowAddEmployee, CanShowAddEmployee);
            }
        }
        private bool CanShowAddEmployee()
        {
            return true;
        }
        private void OnShowAddEmployee()
        {
            OpenAddNewEmployee();
        }
        */



        // open window addEmployee
        private void OpenAddNewEmployee()
        {
            AddNewEmployeeWindow newEmployeeWindow = new AddNewEmployeeWindow();
            SetCenterPositionAndOpen(newEmployeeWindow);
        }


        private void SetCenterPositionAndOpen(Window window)
        {
            window.Owner = Application.Current.MainWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.ShowDialog();
        }
    }
}
