using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RestaurantSchoolProject.Models
{
    public partial class RestaurantContext : DbContext
    {
        public RestaurantContext()
        {
        }

        public RestaurantContext(DbContextOptions<RestaurantContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DenZakObjednavka> DenZakObjednavka { get; set; }
        public virtual DbSet<Dodavatel> Dodavatel { get; set; }
        public virtual DbSet<Kuchyn> Kuchyn { get; set; }
        public virtual DbSet<Login> Login { get; set; }
        public virtual DbSet<ObjDodavatel> ObjDodavatel { get; set; }
        public virtual DbSet<Polozka> Polozka { get; set; }
        public virtual DbSet<Pozice> Pozice { get; set; }
        public virtual DbSet<Restaurant> Restaurant { get; set; }
        public virtual DbSet<StatusZpravy> StatusZpravy { get; set; }
        public virtual DbSet<Table> Table { get; set; }
        public virtual DbSet<Tax> Tax { get; set; }

        // Unable to generate entity type for table 'public.obj_detail'. Please see the warning messages.
        // Unable to generate entity type for table 'public.den_zak_objednavka_detail'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Server=195.181.218.103;Port=5432;Database=Restaurant;UserId=postgres;Password = Tesco12345;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DenZakObjednavka>(entity =>
            {
                entity.ToTable("den_zak_objednavka");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DatumObj)
                    .HasColumnName("datum_obj")
                    .HasColumnType("time without time zone");

                entity.Property(e => e.Eet)
                    .HasColumnName("eet")
                    .HasColumnType("character varying(40)");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.Property(e => e.TableId).HasColumnName("table_id");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.DenZakObjednavka)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("fk_reference_5");

                entity.HasOne(d => d.Table)
                    .WithMany(p => p.DenZakObjednavka)
                    .HasForeignKey(d => d.TableId)
                    .HasConstraintName("fk_obj_tab");
            });

            modelBuilder.Entity<Dodavatel>(entity =>
            {
                entity.ToTable("dodavatel");

                entity.Property(e => e.DodavatelId).HasColumnName("dodavatel_id");

                entity.Property(e => e.Adresa)
                    .HasColumnName("adresa")
                    .HasColumnType("character varying(40)");

                entity.Property(e => e.Nazev)
                    .HasColumnName("nazev")
                    .HasColumnType("character varying(40)");
            });

            modelBuilder.Entity<Kuchyn>(entity =>
            {
                entity.HasKey(e => e.IdObjPol1);

                entity.ToTable("kuchyn");

                entity.Property(e => e.IdObjPol1).HasColumnName("id_obj_pol_1");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Kuchyn)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("fk_reference_8");
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.ToTable("LOGIN");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Heslo)
                    .IsRequired()
                    .HasColumnName("heslo")
                    .HasColumnType("character varying(20)");

                entity.Property(e => e.Jmeno)
                    .IsRequired()
                    .HasColumnName("jmeno")
                    .HasColumnType("character varying(20)");

                entity.Property(e => e.Login1)
                    .IsRequired()
                    .HasColumnName("login")
                    .HasColumnType("character varying(10)");

                entity.Property(e => e.Nazev)
                    .HasColumnName("nazev")
                    .HasColumnType("character varying(40)");

                entity.Property(e => e.PoziceId).HasColumnName("pozice_id");

                entity.Property(e => e.Prijmeni)
                    .IsRequired()
                    .HasColumnName("prijmeni")
                    .HasColumnType("character varying(20)");

                entity.HasOne(d => d.NazevNavigation)
                    .WithMany(p => p.Login)
                    .HasForeignKey(d => d.Nazev)
                    .HasConstraintName("fk_reference_15");

                entity.HasOne(d => d.Pozice)
                    .WithMany(p => p.Login)
                    .HasForeignKey(d => d.PoziceId)
                    .HasConstraintName("fk_pozion_ref");
            });

            modelBuilder.Entity<ObjDodavatel>(entity =>
            {
                entity.HasKey(e => e.ObjId);

                entity.ToTable("obj_dodavatel");

                entity.Property(e => e.ObjId).HasColumnName("obj_id");

                entity.Property(e => e.DatumObjednani)
                    .HasColumnName("datum_objednani")
                    .HasColumnType("timestamp with time zone");

                entity.Property(e => e.DodavatelId).HasColumnName("dodavatel_id");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.HasOne(d => d.Dodavatel)
                    .WithMany(p => p.ObjDodavatel)
                    .HasForeignKey(d => d.DodavatelId)
                    .HasConstraintName("fk_reference_11");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.ObjDodavatel)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("fk_reference_10");
            });

            modelBuilder.Entity<Polozka>(entity =>
            {
                entity.ToTable("polozka");

                entity.Property(e => e.PolozkaId).HasColumnName("polozka_id");

                entity.Property(e => e.Cena)
                    .HasColumnName("cena")
                    .HasColumnType("numeric(5,1)");

                entity.Property(e => e.Dodavatel).HasColumnName("dodavatel");

                entity.Property(e => e.MernaHodnota)
                    .HasColumnName("merna_hodnota")
                    .HasColumnType("numeric(3,1)");

                entity.Property(e => e.NakupniCena)
                    .HasColumnName("nakupni_cena")
                    .HasColumnType("numeric(5,1)");

                entity.Property(e => e.Nazev)
                    .IsRequired()
                    .HasColumnName("nazev")
                    .HasColumnType("character varying(15)");

                entity.Property(e => e.TaxId).HasColumnName("tax_id");

                entity.Property(e => e.Zasoba)
                    .HasColumnName("zasoba")
                    .HasColumnType("numeric(5,1)");

                entity.HasOne(d => d.DodavatelNavigation)
                    .WithMany(p => p.Polozka)
                    .HasForeignKey(d => d.Dodavatel)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_reference_9");

                entity.HasOne(d => d.Tax)
                    .WithMany(p => p.Polozka)
                    .HasForeignKey(d => d.TaxId)
                    .HasConstraintName("fk_tax_ref_2");
            });

            modelBuilder.Entity<Pozice>(entity =>
            {
                entity.ToTable("pozice");

                entity.Property(e => e.PoziceId).HasColumnName("pozice_id");

                entity.Property(e => e.PopisPozice)
                    .HasColumnName("popis_pozice")
                    .HasColumnType("character varying(20)");
            });

            modelBuilder.Entity<Restaurant>(entity =>
            {
                entity.HasKey(e => e.Nazev);

                entity.ToTable("restaurant");

                entity.Property(e => e.Nazev)
                    .HasColumnName("nazev")
                    .HasColumnType("character varying(40)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Do)
                    .HasColumnName("DO")
                    .HasColumnType("time without time zone");

                entity.Property(e => e.Od)
                    .HasColumnName("od")
                    .HasColumnType("time with time zone");
            });

            modelBuilder.Entity<StatusZpravy>(entity =>
            {
                entity.ToTable("status_zpravy");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Popis).HasColumnName("popis");
            });

            modelBuilder.Entity<Table>(entity =>
            {
                entity.ToTable("TABLE");

                entity.Property(e => e.Id).HasColumnName("id");
            });

            modelBuilder.Entity<Tax>(entity =>
            {
                entity.ToTable("tax");

                entity.Property(e => e.TaxId).HasColumnName("tax_id");

                entity.Property(e => e.Hodnota).HasColumnName("hodnota");

                entity.Property(e => e.Popis)
                    .IsRequired()
                    .HasColumnName("popis")
                    .HasColumnType("character varying(10)");
            });

            modelBuilder.HasSequence("settings_seq");
        }
    }
}
