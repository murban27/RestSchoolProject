using System;
using System.Collections.Generic;

namespace RestaurantSchoolProject.Models
{
    public partial class Login
    {
        public int Id { get; set; }
        public string Jmeno { get; set; }
        public string Prijmeni { get; set; }
        public int PoziceId { get; set; }
        public string Login1 { get; set; }
        public string Heslo { get; set; }
        public string Nazev { get; set; }

        public Restaurant NazevNavigation { get; set; }
        public Pozice Pozice { get; set; }
    }
}
