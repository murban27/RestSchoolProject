using System;
using System.Collections.Generic;

namespace RestaurantSchoolProject.Models
{
    public partial class DenZakObjednavka
    {
        public long Id { get; set; }
        public TimeSpan DatumObj { get; set; }
        public int TableId { get; set; }
        public int? StatusId { get; set; }
        public string Eet { get; set; }

        public StatusZpravy Status { get; set; }
        public Table Table { get; set; }
    }
}
