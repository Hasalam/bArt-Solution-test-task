using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace bArt_Test_task.Models
{
    public class AddingIncident
    {
        public Incident Incident { get; set; }
        [Required]
        [DisplayName("People, involved in (separated by \',\')")]
        public string Accounts { get; set; }
        public List<Contact> ContactsInvolved { get; set; }
        public List<Account> AccountsInvolved { get; set; }
    }
}
