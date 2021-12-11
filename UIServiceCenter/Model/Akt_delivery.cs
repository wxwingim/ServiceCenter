using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace UIServiceCenter.Model
{
    public class Akt_delivery
    {
        [Key]
        public int numDeliveri { get; set; }

        public DateTime? dateDelivery { get; set; }

        public List<Work_order> workOrders { get; set; }
    }
}
