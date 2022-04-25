using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public partial class User
    {
        public User()
        {
            OrderRequests = new HashSet<OrderRequest>();
        }

        public int Id { get; set; }
        public string Phone { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string? MiddleName { get; set; }
        public string? Email { get; set; }

        public virtual Employe Employe { get; set; } = null!;
        public virtual ICollection<OrderRequest> OrderRequests { get; set; }
    }
}
