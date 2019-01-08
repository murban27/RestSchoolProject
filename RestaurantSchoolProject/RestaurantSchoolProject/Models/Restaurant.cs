using System;
using System.Collections.Generic;

namespace RestaurantSchoolProject.Models
{
    public partial class Restaurant
    {
        public Restaurant()
        {
            Login = new HashSet<Login>();
        }

        public string Nazev { get; set; }
        public DateTimeOffset? Od { get; set; }
        public TimeSpan? Do { get; set; }

        public ICollection<Login> Login { get; set; }
    }
}
