using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Kutse_App.Models
{
    public class HolidayDBInitializer: CreateDatabaseIfNotExists<HolidayContext>
    {
        protected override void Seed(HolidayContext db2)
        {
            base.Seed(db2);
        }
    }
}