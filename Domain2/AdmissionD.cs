using System;

namespace Domain2
{
    public class AdmissionD
    {
        DeviceD device;
        PersonD customer;
        DateTime dateAdmission;
        DateTime dateLimit;
        bool quarantee;

        public DateTime DateLimit { get { return dateLimit; } set { dateLimit = value; } }
        public bool Quarantee { get { return quarantee; } set { quarantee = value; } }
        public DeviceD Device { get { return device; } set { device = value; } }
        public PersonD Customer { get { return customer; } set { customer = value; } }

        public AdmissionD(DeviceD device, PersonD customer, DateTime dateLimit, bool quarantee)
        {
            this.device = device;
            this.customer = customer;
            this.dateLimit = dateLimit;
            this.quarantee = quarantee;
        }
        public AdmissionD(DeviceD device, PersonD customer, DateTime dateAdmission, DateTime dateLimit, bool quarantee)
        {
            this.device = device;
            this.customer = customer;
            this.dateLimit = dateLimit;
            this.quarantee = quarantee;
            this.dateAdmission = dateAdmission;
        }

        public bool CheckInput()
        {
            bool result = false;
            if (device != null && customer != null) result = true;
            return result;
        }
    }
}
