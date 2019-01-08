using System;
using System.Collections.Generic;

namespace RestaurantSchoolProject.Models
{
    public partial class Tax
    {
        public Tax()
        {
            Polozka = new HashSet<Polozka>();
        }

        public int TaxId { get; set; }
        public string Popis { get; set; }
        public int Hodnota { get; set; }

        public ICollection<Polozka> Polozka { get; set; }
    }
}
