using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Pizzeria.Models
{
    public partial class ModelDbContext : DbContext
    {
        public ModelDbContext()
            : base("name=ModelDbContext")
        {
        }

        public virtual DbSet<Amministrazione> Amministrazione { get; set; }
        public virtual DbSet<Bibita> Bibita { get; set; }
        public virtual DbSet<Clienti> Clienti { get; set; }
        public virtual DbSet<Ordine> Ordine { get; set; }
        public virtual DbSet<Pizza> Pizza { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bibita>()
                .Property(e => e.Prezzo)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Bibita>()
                .HasMany(e => e.Ordine)
                .WithOptional(e => e.Bibita)
                .HasForeignKey(e => e.FK_IdBibita);

            modelBuilder.Entity<Clienti>()
                .HasMany(e => e.Ordine)
                .WithRequired(e => e.Clienti)
                .HasForeignKey(e => e.FK_IdCliente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ordine>()
                .Property(e => e.Totale)
                .HasPrecision(4, 2);

            modelBuilder.Entity<Pizza>()
                .Property(e => e.Prezzo)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Pizza>()
                .HasMany(e => e.Ordine)
                .WithRequired(e => e.Pizza)
                .HasForeignKey(e => e.FK_IdPizza)
                .WillCascadeOnDelete(false);
        }
    }
}
