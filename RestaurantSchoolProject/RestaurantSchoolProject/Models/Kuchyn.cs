using System;
using System.Collections.Generic;

namespace RestaurantSchoolProject.Models
{
    public partial class Kuchyn
    {
        public int IdObjPol1 { get; set; }
        public int? StatusId { get; set; }

        public StatusZpravy Status { get; set; }
    }
}
