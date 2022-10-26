using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class TectContext : DbContext
    {
        public TectContext() : base("DefaultConnection")
        {

        }
        public DbSet<Tect> Tects { get; set; }
    }
}
