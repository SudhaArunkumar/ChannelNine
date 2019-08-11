using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ChannelNineMedia.Models
{
    public class PersonContext:DbContext
    {
        public DbSet<Person> person { get; set; }
    }
}