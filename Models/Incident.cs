using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace bArt_Test_task.Models
{
    public class Incident
    {
        [Key]
        public string IncidentName { get; set; }

        public string IncidentDescription { get; set; }

        public List<Account> Accounts { get; set; }
    }
}
