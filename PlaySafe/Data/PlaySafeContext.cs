using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PlaySafe.Models;

namespace PlaySafe.Data
{
    public class PlaySafeContext : DbContext
    {
        public PlaySafeContext (DbContextOptions<PlaySafeContext> options)
            : base(options)
        {
        }

        public DbSet<PlaySafe.Models.Matches> Matches { get; set; } = default!;
        public DbSet<PlaySafe.Models.User_Match> UserMatch { get; set; }

        public DbSet<PlaySafe.Models.User> User { get; set; }

    }
}
