using DataBase;
using UIServiceCenter.Model;

namespace UIServiceCenter.ViewModel
{
    public class CustomerProfileViewModel
    {
        private Customer oldCustomer;
        private Customer newCustomer;

        public Customer OldCustomer
        {
            get { return oldCustomer; }
            set { oldCustomer = value; }
        }
        public Customer NewCustomer
        {
            get { return newCustomer; }
            set { newCustomer = value; }
        }

        public void EditCustomer()
        {
            DataWorker.EditCustomer(oldCustomer, newCustomer.lastCustom, newCustomer.firstCustom, newCustomer.middleCustom, newCustomer.telCustom, newCustomer.mailCustom);
        }

    }
}
