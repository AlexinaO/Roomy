using Microsoft.EntityFrameworkCore;
using Roomy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roomy.Data
{
    public class RoomyDbContext : DbContext
    {
        public RoomyDbContext(DbContextOptions<RoomyDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<Room> Rooms { get; set; }
    }
}
