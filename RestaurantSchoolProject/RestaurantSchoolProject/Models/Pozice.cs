using System;
using System.Collections.Generic;

namespace RestaurantSchoolProject.Models
{
    public partial class Pozice
    {
        public Pozice()
        {
            Login = new HashSet<Login>();
        }

        public int PoziceId { get; set; }
        public string PopisPozice { get; set; }

        public ICollection<Login> Login { get; set; }
    }
}
