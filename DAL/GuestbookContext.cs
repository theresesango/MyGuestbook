using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class GuestbookContext : DbContext
    {
        public DbSet<Guestbook> Guestbooks { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
