using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBase
{
    public class Akt_delivery
    {
        [Key]
        public int numDeliveri { get; set; }

        public DateTime? dateDelivery { get; set; }

        List<Work_order> work_orders { get; set; }
    }
}
