using System;
using System.Collections.Generic;

namespace RestaurantSchoolProject.Models
{
    public partial class Dodavatel
    {
        public Dodavatel()
        {
            ObjDodavatel = new HashSet<ObjDodavatel>();
            Polozka = new HashSet<Polozka>();
        }

        public int DodavatelId { get; set; }
        public string Nazev { get; set; }
        public string Adresa { get; set; }

        public ICollection<ObjDodavatel> ObjDodavatel { get; set; }
        public ICollection<Polozka> Polozka { get; set; }
    }
}
