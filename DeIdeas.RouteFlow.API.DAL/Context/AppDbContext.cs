using DeIdeas.RouteFlow.API.DAL.Models.ModuleUser;
using Microsoft.EntityFrameworkCore;

namespace DeIdeas.RouteFlow.API.DAL.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opts) : base(opts) { }

        #region MODULE USER

        public DbSet<USR_User> USR_User { get; set; }
        public DbSet<USR_TypeUser> USR_TypeUser { get; set; }
        public DbSet<USR_DetTypeUser> USR_DetTypeUser { get; set; }
        public DbSet<USR_Config> USR_Config { get; set; }
        public DbSet<USR_Rol> USR_Rol { get; set; }
        public DbSet<USR_Control> USR_Control { get; set; }
        public DbSet<USR_UserRol> USR_UserRol { get; set; }
        public DbSet<USR_ControlRol> USR_ControlRol { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Clave compuesta para la tabla de unión Usuario-Rol
            modelBuilder.Entity<USR_UserRol>()
                .HasKey(x => new { x.User, x.Rol });

            // Clave compuesta para Control-Rol (IdControl + Rol)
            modelBuilder.Entity<USR_ControlRol>()
                .HasKey(x => new { x.IdControl, x.Rol });

            // Clave compuesta para Detalle Tipo de Usuario (User + IdTypeUser)
            modelBuilder.Entity<USR_DetTypeUser>()
                .HasKey(dt => new { dt.User, dt.IdTypeUser });

            // Relaciones de USR_DetTypeUser sin cascada
            modelBuilder.Entity<USR_DetTypeUser>()
                .HasOne(dt => dt.UserNavigation)
                .WithMany()
                .HasForeignKey(dt => dt.User)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<USR_DetTypeUser>()
                .HasOne(dt => dt.TypeUser)
                .WithMany()
                .HasForeignKey(dt => dt.IdTypeUser)
                .OnDelete(DeleteBehavior.NoAction);

            // Evitar cascada en otras relaciones
            modelBuilder.Entity<USR_User>()
                .HasOne(u => u.TypeUser)
                .WithMany()
                .HasForeignKey(u => u.IdTypeUser)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<USR_UserRol>()
                .HasOne<USR_User>()
                .WithMany()
                .HasForeignKey(ur => ur.User)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<USR_UserRol>()
                .HasOne<USR_Rol>()
                .WithMany()
                .HasForeignKey(ur => ur.Rol)
                .OnDelete(DeleteBehavior.NoAction);

            // Relaciones explícitas de USR_ControlRol para evitar columnas sombra
            modelBuilder.Entity<USR_ControlRol>()
                .HasOne(cr => cr.Control)
                .WithMany()
                .HasForeignKey(cr => cr.IdControl)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<USR_ControlRol>()
                .HasOne(cr => cr.RolNavigation)
                .WithMany()
                .HasForeignKey(cr => cr.Rol)
                .OnDelete(DeleteBehavior.NoAction);

            base.OnModelCreating(modelBuilder);
        }
    }
}
