using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary;
using Microsoft.EntityFrameworkCore;

namespace DrRecordsREST.Models
{
    public class RecordsContext : DbContext
    {
        public RecordsContext(DbContextOptions<RecordsContext> options)
            : base(options)
        {
        }

        public DbSet<Record> list { get; set; }
    }
}
