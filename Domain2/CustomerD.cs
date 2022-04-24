namespace Domain2
{
    public class CustomerD : PersonD
    {
        //List<DeviceD> devices;
        //public List<DeviceD> Devices { get { return devices; } set { devices = value; } }

        public CustomerD(string lastName, string firstName, string middleName, string phone, string email) : base(lastName, firstName, middleName, phone, email)
        {
        }
    }
}
