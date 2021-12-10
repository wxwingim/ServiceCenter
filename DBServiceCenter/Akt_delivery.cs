using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DBServiceCenter
{
    public class Akt_delivery
    {
        [Key]
        public int num_deliveri { get; set; }

        public DateTime? date_delivery { get; set; }

        public List<Work_order> work_orders { get; set; }
    }
}
