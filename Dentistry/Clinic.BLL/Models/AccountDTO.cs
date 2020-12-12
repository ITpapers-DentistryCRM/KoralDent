using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.BLL.Models
{
    public class AccountDTO
    {
        public int AccountId { get; set; }

        [Required]
        [StringLength(50)]
        public string AccountLogin { get; set; }

        [Required]
        [StringLength(50)]
        public string AccountPassword { get; set; }

    }
}
