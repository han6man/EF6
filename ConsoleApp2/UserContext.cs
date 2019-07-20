using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class UserContext : DbContext
    {
        public UserContext() :
            base("Database")
        { }

        public DbSet<User> Users { get; set; }
    }
}
