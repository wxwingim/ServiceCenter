using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIServiceCenter.View;

namespace UIServiceCenter.ViewModel
{
    public class MenuViewModel
    {

        //ctor
        public MenuViewModel()
        {

        }

        public IMainWindowsCodeBehind CodeBehind { get; set; }


        /// <summary>
        /// Переход к Orders
        /// </summary>
        private RelayCommand _LoadOrdersUCCommand;
        public RelayCommand LoadOrdersUCCommand
        {
            get
            {
                return _LoadOrdersUCCommand = _LoadOrdersUCCommand ??
                  new RelayCommand(OnLoadOrdersUC, CanLoadOrdersUC);
            }
        }
        private bool CanLoadOrdersUC()
        {
            return true;
        }
        private void OnLoadOrdersUC()
        {
            CodeBehind.LoadView(ViewType.Orders);
        }


        /// <summary>
        /// Переход ко Customers
        /// </summary>
        private RelayCommand _LoadCustomersUCCommand;
        public RelayCommand LoadCustomersUCCommand
        {
            get
            {
                return _LoadCustomersUCCommand = _LoadCustomersUCCommand ??
                  new RelayCommand(OnLoadCustomersUC, CanLoadCustomersUC);
            }
        }
        private bool CanLoadCustomersUC()
        {
            return true;
        }
        private void OnLoadCustomersUC()
        {
            CodeBehind.LoadView(ViewType.Customers);
        }


        /// <summary>
        /// Переход к Employees
        /// </summary>
        private RelayCommand _LoadEmployeesUCCommand;
        public RelayCommand LoadEmployeesUCCommand
        {
            get
            {
                return _LoadEmployeesUCCommand = _LoadEmployeesUCCommand ??
                  new RelayCommand(OnLoadEmployeesUC, CanLoadEmployeesUC);
            }
        }
        private bool CanLoadEmployeesUC()
        {
            return true;
        }
        private void OnLoadEmployeesUC()
        {
            CodeBehind.LoadView(ViewType.Employees);
        }

        /// <summary>
        /// Переход к Storage
        /// </summary>
        private RelayCommand _LoadStorageUCCommand;
        public RelayCommand LoadStorageUCCommand
        {
            get
            {
                return _LoadStorageUCCommand = _LoadStorageUCCommand ??
                  new RelayCommand(OnLoadStorageUC, CanLoadStorageUC);
            }
        }
        private bool CanLoadStorageUC()
        {
            return true;
        }
        private void OnLoadStorageUC()
        {
            CodeBehind.LoadView(ViewType.Storage);
        }

        /// <summary>
        /// Переход к Jobs
        /// </summary>
        private RelayCommand _LoadJobsUCCommand;
        public RelayCommand LoadJobsUCCommand
        {
            get
            {
                return _LoadJobsUCCommand = _LoadJobsUCCommand ??
                  new RelayCommand(OnLoadJobsUC, CanLoadJobsUC);
            }
        }
        private bool CanLoadJobsUC()
        {
            return true;
        }
        private void OnLoadJobsUC()
        {
            CodeBehind.LoadView(ViewType.Jobs);
        }
    }

}
