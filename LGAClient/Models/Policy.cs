using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LGAClient.Models
{
    public class Policy
    {
        [Key]
        public int Id { get; set; }

        public string PolicyNumber { get; set; }
        
        public DateTime PolicyExpireDate { get; set; }

        public decimal PolicyAmount { get; set; }

        public bool Status { get; set; }

        //Another way of setting Max Length
        [MaxLength(255)]
        public string AdditionalInfo { get; set; }
    }
}
