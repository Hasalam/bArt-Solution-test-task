using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace bArt_Test_task.Models
{
    public class Account
    {
        [Key]
        [Required(ErrorMessage = "Enter name!")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Enter password!")]
        [PasswordPropertyText(true)]
        [Remote(action: "CheckPassword", controller:"Login",ErrorMessage ="Wrong account name or password!", AdditionalFields =nameof(Name))]
        public string Password { get; set; }

        public List<Contact> Contacts { get; set; }
#nullable enable
        public string? IncidentId { get; set; }
#nullable disable
        public Incident Incident { get; set; }
    }
}
