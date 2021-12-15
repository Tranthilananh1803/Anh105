using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Anh105.Models;
namespace Anh105.Data{
    public class AnhDBContext : DbContext
    {
        public AnhDBContext (DbContextOptions<AnhDBContext> options)
            : base(options)
        {
        }

        public DbSet<Anh105.Models.PersonsAnh> PersonsAnh { get; set; }

        public DbSet<Anh105.Models.TA105> TA105 { get; set; }
    }
}
