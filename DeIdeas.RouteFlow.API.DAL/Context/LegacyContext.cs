using Microsoft.EntityFrameworkCore;
using DeIdeas.RouteFlow.API.DAL.Models.Legacy;
using DeIdeas.RouteFlow.API.DAL.Models.Routing;

namespace DeIdeas.RouteFlow.API.DAL.Context
{
    public class LegacyContext : DbContext
    {
        public LegacyContext(DbContextOptions<LegacyContext> opts) : base(opts) { }

        // Tablas legacy (solo lectura en API)
        public DbSet<OCRD> OCRD { get; set; } = default!;
        public DbSet<OINV> OINV { get; set; } = default!;
        public DbSet<OINV_OCRD_Snapshot> OINV_OCRD_Snapshot { get; set; } = default!;

        // Routing tables (legacy schema)
        public DbSet<Ruta> Rutas { get; set; } = default!;
        public DbSet<DetRuta> DetRutas { get; set; } = default!;

        // Vistas legacy (solo lectura)
        public DbSet<SAP_V_PendingPass> SAP_V_PendingPass { get; set; } = default!;
        public DbSet<SAP_V_PendingPayment> SAP_V_PendingPayment { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Mapeo de tablas
            modelBuilder.Entity<OCRD>().ToTable("OCRD", "dbo").HasKey(x => x.CardCode);
            modelBuilder.Entity<OINV>().ToTable("OINV", "dbo").HasKey(x => x.DocEntry);
            modelBuilder.Entity<OINV_OCRD_Snapshot>().ToTable("OINV_OCRD_Snapshot", "dbo")
                .HasKey(x => x.No_Documento);

            // Mapping for routing tables
            modelBuilder.Entity<Ruta>().ToTable("Rutas", "dbo");
            modelBuilder.Entity<Ruta>().HasKey(r => r.RutaID);
            modelBuilder.Entity<Ruta>().Property(r => r.TipoRuta).HasMaxLength(20).IsRequired();
            modelBuilder.Entity<Ruta>().Property(r => r.FechaRuta).HasColumnType("date").IsRequired();
            modelBuilder.Entity<Ruta>().Property(r => r.Estado).HasMaxLength(30).IsRequired();
            modelBuilder.Entity<Ruta>().Property(r => r.Usuario).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<Ruta>().Property(r => r.UsuarioAsignado).HasMaxLength(100).IsRequired(false);
            modelBuilder.Entity<Ruta>().Property(r => r.Fecha).HasColumnType("datetime").IsRequired();

            modelBuilder.Entity<DetRuta>().ToTable("DetRutas", "dbo");
            modelBuilder.Entity<DetRuta>().HasKey(d => d.DetRutaID);
            modelBuilder.Entity<DetRuta>().Property(d => d.Usuario).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<DetRuta>().Property(d => d.Fecha).HasColumnType("datetime").IsRequired();
            modelBuilder.Entity<DetRuta>()
                .HasOne<Ruta>()
                .WithMany()
                .HasForeignKey(d => d.RutaID)
                .OnDelete(DeleteBehavior.NoAction);

            // Mapeo de vistas (sin llave)
            modelBuilder.Entity<SAP_V_PendingPass>().HasNoKey().ToView("SAP_V_PendingPass", "dbo");
            modelBuilder.Entity<SAP_V_PendingPayment>().HasNoKey().ToView("SAP_V_PendingPayment", "dbo");
        }
    }
}
