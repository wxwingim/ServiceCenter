using DataBase;
using Domain2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using UIServiceCenter.Model;

namespace UIServiceCenter.ViewModel
{
    public class AddOrderViewModel : INotifyPropertyChanged
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
        /// Все типы устройств
        /// </summary>
        private List<DeviceType> allDevices = DataWorker.GetAllDeviceTypes();

        public List<DeviceType> AllDevices
        {
            get { return allDevices; }
            set
            {
                allDevices = value;
                NotifyPropertyChanged("AllDevices");
            }
        }


        private AdmissionD admission;
        public AdmissionD Admission { get { return admission; } }

        public AddOrderViewModel(AdmissionD admission)
        {
            this.admission = admission;
        }
        public AddOrderViewModel() { }

        public void CreateNewOrder()
        {
            DataWorker.CreateWorkOrder(
                admission.Customer.Phone,
                DateTime.Now,
                admission.DateLimit,
                admission.Quarantee,
                admission.Device.Type,
                admission.Device.Model,
                admission.Device.Defect,
                admission.Device.Equipment,
                admission.Device.MechanicalDamage);
        }
    }
}
