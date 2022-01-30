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
        public string EMail { get; set; }

        public string Name { get; set; }

        public string Last_Name { get; set; }

        public string AccountId { get; set; }

        public Account Account { get; set; }
    }
}
