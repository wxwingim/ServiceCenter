namespace Domain2
{
    public class EmployeeD : PersonD
    {
        string position;

        public string Position { get { return position; } set { position = value; } }

        public EmployeeD(string lastName, string firstName, string middleName, string phone, string email, string position) : base(lastName, firstName, middleName, phone, email)
        {
            this.position = position;
        }

        public EmployeeD(string lastName, string firstName, string phone, string email, string position) : base(lastName, firstName, phone, email)
        {
            this.position = position;
        }

        public override bool CheckInput()
        {
            if (position == "")
            {
                return false;
            }
            else return base.CheckInput();
        }
    }
}
