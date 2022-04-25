using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public partial class Visit
    {
        public int Id { get; set; }
        public int IdOrder { get; set; }
        public DateOnly DateVisit { get; set; }
        public TimeOnly TimeVisit { get; set; }

        public virtual Order IdOrderNavigation { get; set; } = null!;
    }
}
