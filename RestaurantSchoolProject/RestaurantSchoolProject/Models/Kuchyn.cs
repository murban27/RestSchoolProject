using System;
using System.Collections.Generic;

namespace RestaurantSchoolProject.Models
{
    public partial class Kuchyn
    {
        public int InternalId { get; set; }
        public int? StatusId { get; set; }
        public int? DenZakObjednavkaDetailInternalId1 { get; set; }

        public DenZakObjednavkaDetail DenZakObjednavkaDetailInternalId1Navigation { get; set; }
        public StatusZpravy Status { get; set; }
    }
}
