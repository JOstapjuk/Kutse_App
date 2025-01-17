using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Kutse_App.Models
{
    public class HolidayContext : DbContext
    {
        public DbSet<Holiday> Holidays { get; set; }
    }
}