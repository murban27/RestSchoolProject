using System;
using System.Collections.Generic;

namespace RestaurantSchoolProject.Models
{
    public partial class StatusZpravy
    {
        public StatusZpravy()
        {
            DenZakObjednavka = new HashSet<DenZakObjednavka>();
            Kuchyn = new HashSet<Kuchyn>();
            ObjDodavatel = new HashSet<ObjDodavatel>();
        }

        public int Id { get; set; }
        public int? Popis { get; set; }

        public ICollection<DenZakObjednavka> DenZakObjednavka { get; set; }
        public ICollection<Kuchyn> Kuchyn { get; set; }
        public ICollection<ObjDodavatel> ObjDodavatel { get; set; }
    }
}
