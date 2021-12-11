using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace UIServiceCenter.Model
{
    public class Admission_for_repair
    {
        [Key]
        public int num_admission { get; set; }

        [Required]
        public DateTime date_limit { get; set; }

        [Required]
        public bool quarantee { get; set; }

        [Required]
        public DateTime date_admission { get; set; }

        [Required, MaxLength(50), DefaultValue("Service Center")]
        public string name_org { get; set; }

        [Required, MaxLength(10), DefaultValue("7384056285")]
        public string inn_org { get; set; }

        [Required]
        public string addres_org { get; set; }

        [Required, MaxLength(11), DefaultValue("89993456789")]
        public string tel_org { get; set; }

        [Required, MaxLength(255), DefaultValue("ServiceCenter@gmail.com")]
        public string mail_org { get; set; }

        public Customer_device id_cust_dev { get; set; }

        public List<Work_order> work_Order { get; set; }
    }
}
