using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prooviulesanne.Models.Domain.ViewModels
{
    public class CitizenViewModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public int IdentificationNumber { get; set; }
        [Required]
        public PaymentType PaymentType { get; set; }
        [Required]
        [StringLength(1500)]
        public string Details { get; set; }
    }
}
