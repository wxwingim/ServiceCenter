using DataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using UIServiceCenter.Model;

namespace UIServiceCenter.ViewModel
{
    public class OrderProfileViewModel : INotifyPropertyChanged
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

        /// <summary>
        /// Все типы ремонта
        /// </summary>
        private List<StatusRepair> allStatusRepair = DataWorker.GetAllStatusRepair();
        public List<StatusRepair> AllStatusRepair
        {
            get { return allStatusRepair; }
            set
            {
                allStatusRepair = value;
                NotifyPropertyChanged("AllStatusRepair");
            }
        }

        private OrderModel order;
        private string customerName;
        private string customerPhone;
        private DeviceType typeDevice;
        private string model;
        private string defect;
        private string equipment;
        private string mechanicalDamage;
        private StatusRepair statusRepair;
        private bool statusDelivery;

        public OrderProfileViewModel() { }

        public OrderProfileViewModel(OrderModel order)
        {
            this.order = order;
            customerName = DataWorker.GetCustomerById(order.idCustom).lastCustom + " " + DataWorker.GetCustomerById(order.idCustom).firstCustom + " " + DataWorker.GetCustomerById(order.idCustom).middleCustom;
            customerPhone = DataWorker.GetCustomerById(order.idCustom).telCustom;
            typeDevice = DataWorker.GetDevice_type(DataWorker.GetCustomer_device(DataWorker.GetAdmission_For_Repair(DataWorker.GetWorkOrderById(order.numOrder).num_admission).idCustDev).typeId);
            model = order.nameModel;
            defect = order.defect;
            equipment = DataWorker.GetCustomer_device(DataWorker.GetAdmission_For_Repair(DataWorker.GetWorkOrderById(order.numOrder).num_admission).idCustDev).equipment;
            mechanicalDamage = DataWorker.GetCustomer_device(DataWorker.GetAdmission_For_Repair(DataWorker.GetWorkOrderById(order.numOrder).num_admission).idCustDev).mechanicalDamage;
            statusRepair = DataWorker.GetStatusRepair(order.statusRepair);
        }

        public bool StatusDelivery { get { return statusDelivery;  } set { statusDelivery = value; } }
        public string CustomerName { get { return customerName; } set { customerName = value; } }
        public string CustomerPhone { get { return customerPhone; } set { customerPhone = value; } }
        public DeviceType TypeDevice { get { return typeDevice; } set { typeDevice = value; } }
        public string Model { get { return model; } set { model = value; } }
        public string Defect { get { return defect; } set { defect = value; } }
        public string Equipment { get { return equipment; } set { equipment = value; } }
        public string MechanicalDamage { get { return mechanicalDamage; } set { mechanicalDamage = value; } }
        public StatusRepair StatusRepair { get { return statusRepair; } set { statusRepair = value; } }

        public void EditOrder()
        {
            DataWorker.EditOrder(order.numOrder, typeDevice.typeId, model, defect, equipment, mechanicalDamage, statusRepair.StatusId, order.statusPaymnt, statusDelivery);
        }
    }
}
