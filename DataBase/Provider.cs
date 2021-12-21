using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataBase
{
    public class Provider
    {
        [Key]
        public int idProv { get; set; }

        [Required, StringLength(10)]
        public string innProv { get; set; }

        [Required]
        public string addresProv { get; set; }

        [Required, StringLength(11)]
        public string phoneProv { get; set; }

        [Required, StringLength(255)]
        public string emailProv { get; set; }

        public List<PurchaseInvoice> purchaseIns { get; set; }
    }
}
