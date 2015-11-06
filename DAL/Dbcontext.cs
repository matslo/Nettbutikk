using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Collections.Generic;
using Nettbutikken.Model;

namespace Nettbutikken.DAL
{

    public class dbBruker
   {
      public int Id { get; set; }
      public string Brukernavn { get; set; }
      public string Email { get; set; }
      public byte[] Passord { get; set; }
    }
    public class Ordre
    {
        public int OrdreId { get; set; }
        public System.DateTime OrdreDato { get; set; }
        public string Brukernavn { get; set; }
        public string Fornavn { get; set; }
        public string Etternavn { get; set; }
        public string Adresse { get; set; }
        public string By { get; set; }
        public string Postnr { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public decimal Total { get; set; }
        public List<OrdreDetaljer> OrdreDetaljer { get; set; }
    }
    public class OrdreDetaljer
    {
        public int OrdreDetaljerId { get; set; }
        public int OrdreId { get; set; }
        public int VareId { get; set; }
        public int Antall { get; set; }
        public decimal Enhetspris { get; set; }

        public virtual Vare Vare { get; set; }
        public virtual Ordre Ordre { get; set; }
    }
    public class Vare
    {
        public int VareId { get; set; }
        public string Varenavn { get; set; }
        public decimal Pris { get; set; }
        public string Varebilde { get; set; }
        public virtual List<OrdreDetaljer> OrderDetails { get; set; }
    }
    public class Dbcontext : DbContext
    {
        public Dbcontext()
            : base("name=Nettbutikk")
        {
            Database.CreateIfNotExists();
        }
        public DbSet<Vare> Varer { get; set; }
        public DbSet<Ordre> Ordrer { get; set; }
        public DbSet<OrdreDetaljer> OrdreDetaljers { get; set; }
        public DbSet<dbBruker> dbBrukere { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
