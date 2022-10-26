using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class ResultContext:DbContext
    {
        public ResultContext() : base("DefaultConnection")
        {

        }
        public DbSet<Result> Results { get; set; }
    }
}
