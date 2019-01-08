using System;
using System.Collections.Generic;

namespace RestaurantSchoolProject.Models
{
    public partial class Polozka
    {
        public long PolozkaId { get; set; }
        public string Nazev { get; set; }
        public decimal Zasoba { get; set; }
        public decimal Cena { get; set; }
        public int TaxId { get; set; }
        public int? Dodavatel { get; set; }
        public decimal? NakupniCena { get; set; }
        public decimal MernaHodnota { get; set; }

        public Dodavatel DodavatelNavigation { get; set; }
        public Tax Tax { get; set; }
    }
}
