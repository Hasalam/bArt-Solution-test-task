using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace bArt_Test_task.Models
{
    public class Account
    {
        [Key]
        public string Name { get; set; }

        public string Password { get; set; }

        public List<Contact> Contacts { get; set; }

        public string IncidentId { get; set; }

        public Incident Incident { get; set; }
    }
}
