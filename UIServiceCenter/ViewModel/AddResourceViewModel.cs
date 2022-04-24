using DataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using UIServiceCenter.Model;

namespace UIServiceCenter.ViewModel
{
    public class AddResourceViewModel : INotifyPropertyChanged
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
        /// Все услуги
        /// </summary>
        private List<Service> allServices = DataWorker.GetAllServicesPlus();

        public List<Service> AllServices
        {
            get { return allServices; }
            set
            {
                allServices = value;
                NotifyPropertyChanged("AllServices");
            }
        }

        /// <summary>
        /// Все сотрудники
        /// </summary>
        private List<Employee> allEmployee = DataWorker.GetAllEmployees();

        public List<Employee> AllEmployee
        {
            get { return allEmployee; }
            set
            {
                allEmployee = value;
                NotifyPropertyChanged("AllEmployee");
            }
        }

        /// <summary>
        /// Все запчасти
        /// </summary>
        private List<StorageModel> allSpareParts = DataWorker.GetStorage();

        public List<StorageModel> AllSpareParts
        {
            get { return allSpareParts; }
            set
            {
                allSpareParts = value;
                NotifyPropertyChanged("AllSpareParts");
            }
        }

        /// <summary>
        /// Все типы
        /// </summary>
        private List<TypeSparePart> allTypes = DataWorker.GetAllTypeSP();

        public List<TypeSparePart> AllTypes
        {
            get { return allTypes; }
            set
            {
                allTypes = value;
                NotifyPropertyChanged("AllTypes");
            }
        }

    }
}
