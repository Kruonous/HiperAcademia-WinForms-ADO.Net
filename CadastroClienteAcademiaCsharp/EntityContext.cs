namespace CadastroClienteAcademiaCsharp
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using CadastroClienteAcademiaCsharp.Domain;

    public partial class EntityContext : DbContext
    {
        public EntityContext()
            : base("name=EntityContext")
        {
        }

        public virtual DbSet<Cidade> Cidade { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cidade>()
                .HasMany(e => e.Cliente)
                .WithRequired(e => e.Cidade)
                .WillCascadeOnDelete(false);
        }
    }
}
