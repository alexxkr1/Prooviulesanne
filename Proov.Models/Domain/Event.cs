using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prooviulesanne.Models.Domain
{
    public class Event
    {
        public int Id { get; set; }
        [Required]
        public string EventName { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public string StartingPlace { get; set; }
        [Required]
        [StringLength(1000)]
        public string Details { get; set; }

        public ICollection<Citizen>? Citizens { get; set; }
        public ICollection<Enterprise>? Enterprises { get; set; }
    }

    public enum PaymentType
    {
        Sularaha,
        Pangaülekanne
    }
}
