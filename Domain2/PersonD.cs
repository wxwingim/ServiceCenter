using System;

namespace Domain2
{
    public class PersonD
    {
        string lastName;
        string firstName;
        string middleName;
        string phone;
        string email;

        public string LastName { get { return lastName; } set { lastName = value; } }
        public string FirstName { get { return firstName; } set { firstName = value; } }
        public string MiddleName { get { return middleName; } set { middleName = value; } }
        public string Phone { get { return phone; } set { phone = value; } }
        public string Email { get { return email; } set { email = value; } }

        public PersonD(string lastName, string firstName, string middleName, string phone, string email)
        {
            this.lastName = lastName;
            this.firstName = firstName;
            this.middleName = middleName;
            this.phone = phone;
            this.email = email;
        }

        public PersonD(string lastName, string firstName, string phone, string email)
        {
            this.lastName = lastName;
            this.firstName = firstName;
            this.phone = phone;
            this.email = email;
        }

        public virtual bool CheckInput()
        {
            bool result = true;

            if (firstName == "" || lastName == "") result = false;

            if (IsNumberContains(firstName) || IsNumberContains(lastName) || IsNumberContains(middleName) || !IsPhoneFormat(phone)) result = false;

            return result;
        }

        private bool IsNumberContains(string input)
        {
            bool result = false;
            foreach (char c in input)
            {
                if (Char.IsNumber(c))
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        private bool IsPhoneFormat(string input)
        {
            bool result = true;
            foreach (char c in input)
            {
                if (!Char.IsNumber(c))
                {
                    result = false;
                    break;
                }
            }
            return result;
        }
    }
}
