using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public partial class Employe
    {
        public Employe()
        {
            Works = new HashSet<Work>();
        }

        public int Id { get; set; }
        public string Position { get; set; } = null!;

        public virtual User IdNavigation { get; set; } = null!;
        public virtual ICollection<Work> Works { get; set; }
    }
}
