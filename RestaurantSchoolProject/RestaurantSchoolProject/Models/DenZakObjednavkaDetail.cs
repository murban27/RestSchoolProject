using System;
using System.Collections.Generic;

namespace RestaurantSchoolProject.Models
{
    public partial class DenZakObjednavkaDetail
    {
        public DenZakObjednavkaDetail()
        {
            Kuchyn = new HashSet<Kuchyn>();
        }

        public long Id { get; set; }
        public int? StatusId { get; set; }
        public decimal Cena { get; set; }
        public int InternalId { get; set; }
        public bool? FoodItem { get; set; }
        public long PolozkaId { get; set; }

        public DenZakObjednavka IdNavigation { get; set; }
        public Polozka Polozka { get; set; }
        public StatusZpravy Status { get; set; }
        public ICollection<Kuchyn> Kuchyn { get; set; }
    }
}
