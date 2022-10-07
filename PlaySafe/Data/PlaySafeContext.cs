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
    
        protected override void OnModelCreating(ModelBuilder modelBuilder) { 
        
        
        }


        public DbSet<PlaySafe.Models.Match_History> Match_History { get; set; }
        public DbSet<PlaySafe.Models.User> User { get; set; }
        public DbSet<PlaySafe.Models.User_type> User_type { get; set; }
        public DbSet<PlaySafe.Models.NFC> NFC { get; set; }
        public DbSet<PlaySafe.Models.Specials> Specials { get; set; }
        public DbSet<PlaySafe.Models.Comments> Comments { get; set; }
        public DbSet<PlaySafe.Models.player> Player { get; set; }
        public DbSet<PlaySafe.Models.Usertype_pages> Usertype_pages { get; set; }
        public DbSet<PlaySafe.Models.Entry> Entry { get; set; }
    }
}
