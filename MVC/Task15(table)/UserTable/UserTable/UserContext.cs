using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using UserTable.Models;

namespace UserTable
{
    public class UserContext: DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}