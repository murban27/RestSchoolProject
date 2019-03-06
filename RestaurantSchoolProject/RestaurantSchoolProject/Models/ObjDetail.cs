using System;
using System.Collections.Generic;

namespace RestaurantSchoolProject.Models
{
    public partial class ObjDetail
    {
        public int? ObjId { get; set; }
        public long? PolozkaId { get; set; }
        public int? Id { get; set; }
        public decimal? Mnozstvi { get; set; }
        public int InternalId { get; set; }
        public decimal NakupniCena { get; set; }

        public StatusZpravy IdNavigation { get; set; }
        public ObjDodavatel Obj { get; set; }
        public Polozka Polozka { get; set; }
    }
}
