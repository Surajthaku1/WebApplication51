using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication51.Models
{
    public class ApplicationDbcontext:DbContext
    {
        public DbSet<category> Categories { get; set; }
        public DbSet<products> products { get; set; }
    }
}