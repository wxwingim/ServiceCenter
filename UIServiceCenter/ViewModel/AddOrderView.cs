using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase;
using UIServiceCenter.Model;

namespace UIServiceCenter.ViewModel
{
    public class AddOrderView : INotifyPropertyChanged
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
        /// Все сотрудники
        /// </summary>
        private List<Device_type> allDevices = DataWorker.GetAllDeviceTypes();

        public List<Device_type> AllDevices
        {
            get { return allDevices; }
            set
            {
                allDevices = value;
                NotifyPropertyChanged("AllDevices");
            }
        }

        //public void CreateNewAdmissionForRepair()
        //{

        //}

        //public void CreateNewOrder()
        //{

        //}
    }
}
