using EvPT_Tactics.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvPT_Tactics.Data
{
    public class EvPTContext : DbContext
    {
        public EvPTContext (DbContextOptions<EvPTContext> options)
    : base(options)
        {
        }

        public DbSet<Tactic> Movie { get; set; }
    }
}
