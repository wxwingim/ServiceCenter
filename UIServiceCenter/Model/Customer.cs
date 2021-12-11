﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace UIServiceCenter.Model
{
    public class Customer
    {
        [Key]
        public int idCustom { get; set; }

        [Required]
        [MaxLength(20)]
        public string lastCustom { get; set; }

        [Required]
        [MaxLength(20)]
        public string firstCustom { get; set; }

        [MaxLength(20)]
        public string? middleCustom { get; set; }

        [MaxLength(255)]
        public string? mailCustom { get; set; }

        [Required]
        [MaxLength(11)]
        public string telCustom { get; set; }

        public List<Customer_device> devices { get; set; }
    }
}
