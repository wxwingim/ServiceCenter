using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public partial class Work
    {
        public int Id { get; set; }
        public int IdOrder { get; set; }
        public int IdEmployee { get; set; }
        public int IdService { get; set; }

        public virtual Employe IdEmployeeNavigation { get; set; } = null!;
        public virtual Order IdOrderNavigation { get; set; } = null!;
        public virtual Service IdServiceNavigation { get; set; } = null!;
    }
}
