using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace bArt_Test_task.Models
{
    public class Contact
    {
        [Key]
        [EmailAddress(ErrorMessage ="Email form is incorrect")]
        public string EMail { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Last_Name { get; set; }

        public string AccountId { get; set; }

        public Account Account { get; set; }
    }
}
