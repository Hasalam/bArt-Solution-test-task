using bArt_Test_task.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bArt_Test_task.Data
{
    public class ApplicationDBcontext : DbContext
    {
        public ApplicationDBcontext(DbContextOptions<ApplicationDBcontext> options) : base(options)
        {

        }
        public DbSet<Account> Account { get; set; }

        public DbSet<Contact> Contact { get; set; }

        public DbSet<Incident> Incident { get; set; }
    }
}
