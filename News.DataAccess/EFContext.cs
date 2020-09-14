using Microsoft.EntityFrameworkCore;
using News.DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace News.DataAccess
{
    public class EFContext : DbContext
    {
        public EFContext(DbContextOptions<EFContext> options) : base(options) { }
        public DbSet<tblNews> News { get; set; }
    }
}
