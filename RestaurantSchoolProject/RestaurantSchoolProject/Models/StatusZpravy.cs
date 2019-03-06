using System;
using System.Collections.Generic;

namespace RestaurantSchoolProject.Models
{
    public partial class StatusZpravy
    {
        public StatusZpravy()
        {
            DenZakObjednavka = new HashSet<DenZakObjednavka>();
            DenZakObjednavkaDetail = new HashSet<DenZakObjednavkaDetail>();
            Kuchyn = new HashSet<Kuchyn>();
            ObjDetail = new HashSet<ObjDetail>();
            ObjDodavatel = new HashSet<ObjDodavatel>();
        }

        public int Id { get; set; }
        public int? Popis { get; set; }

        public ICollection<DenZakObjednavka> DenZakObjednavka { get; set; }
        public ICollection<DenZakObjednavkaDetail> DenZakObjednavkaDetail { get; set; }
        public ICollection<Kuchyn> Kuchyn { get; set; }
        public ICollection<ObjDetail> ObjDetail { get; set; }
        public ICollection<ObjDodavatel> ObjDodavatel { get; set; }
    }
}
