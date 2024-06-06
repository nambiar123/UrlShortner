using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace UrlShortner.Models
{
    public class UrlContext : DbContext
    {
        public UrlContext() : base("DBConnectionString")
        {
            //Disable initializer
            //Database.SetInitializer<SchoolDBContext>(null);
        }
        public DbSet<Url> Urls { get; set; }
    }
   
}