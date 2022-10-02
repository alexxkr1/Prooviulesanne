using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prooviulesanne.Models.Domain
{
    public class Enterprise
    {
        public int Id { get; set; }
        [Required]
        public string EnterpriseName { get; set; }
        [Required]
        public int BusinessIdentificationNumber { get; set; }
        [Required]
        public int AttendanceNumber { get; set; }
        [Required]
        public PaymentType PaymentType { get; set; }
        [Required]
        [StringLength(5000)]
        public string Details { get; set; }
        public int? EventId { get; set; }
    }


}

