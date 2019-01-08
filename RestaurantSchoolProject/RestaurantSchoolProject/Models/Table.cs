using System;
using System.Collections.Generic;

namespace RestaurantSchoolProject.Models
{
    public partial class Table
    {
        public Table()
        {
            DenZakObjednavka = new HashSet<DenZakObjednavka>();
        }

        public int Id { get; set; }

        public ICollection<DenZakObjednavka> DenZakObjednavka { get; set; }
    }
}
