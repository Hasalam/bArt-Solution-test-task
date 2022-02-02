using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace bArt_Test_task.Models
{
    public class Incident
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string IncidentName { get; set; }
        [Required]
        public string IncidentDescription { get; set; }

        public List<Account> Accounts { get; set; }
    }
}
