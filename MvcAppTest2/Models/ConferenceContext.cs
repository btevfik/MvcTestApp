using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Configuration;

namespace MvcAppTest2.Models
{
    public class ConferenceContext : DbContext
    {
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Speaker> Speakers { get; set; }

        public DbSet<Comment> Comments { get; set; }
    }
}