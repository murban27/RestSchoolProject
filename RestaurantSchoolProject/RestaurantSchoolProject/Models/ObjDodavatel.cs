using System;
using System.Collections.Generic;

namespace RestaurantSchoolProject.Models
{
    public partial class ObjDodavatel
    {
        public int ObjId { get; set; }
        public DateTime? DatumObjednani { get; set; }
        public int? StatusId { get; set; }
        public int? DodavatelId { get; set; }

        public Dodavatel Dodavatel { get; set; }
        public StatusZpravy Status { get; set; }
    }
}
