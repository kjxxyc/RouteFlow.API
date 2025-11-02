using Microsoft.EntityFrameworkCore;

namespace DeIdeas.RouteFlow.API.DAL.Context
{
    public class LegacyContext : DbContext
    {
        public LegacyContext(DbContextOptions<LegacyContext> opts) : base(opts) { }

        //public DbSet<CXC_V_RepFileDropSBFRE> ts { get; set; } // Cambia T por el tipo de entidad que necesites
        /*
        public DbSet<DetConcFilePlatform> DetConcFilePlatform { get; set; }
        public DbSet<DetDropsTransactionSBF> DetDropsTransactionSBF { get; set; }
        */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<CXC_V_RepFileDropSBFRE>().ToView("CXC_V_RepFileDropSBFRE", "dbo").HasKey(x => x.IdConc);

            //modelBuilder.Entity<CXC_V_RepFileDropSBFRE>().ToTable("ts", "dbo").HasKey(x => x.Id); // Cambia T por el tipo de entidad que necesites
            /*
            modelBuilder.Entity<DetConcFilePlatform>().ToTable("DetConcFilePlatform", "dbo").HasKey(x => x.IdConc && x = x.IdPlatform && x.Id);

            modelBuilder.Entity<DetDropsTransactionSBF>().ToTable("DetDropsTransactionSBF", "dbo").HasKey(y => y.IdConc);
            */
        }
    }
}
