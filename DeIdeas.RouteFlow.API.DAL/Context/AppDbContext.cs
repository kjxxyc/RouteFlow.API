using DeIdeas.RouteFlow.API.DAL.Models.ModuleUser;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            base.OnModelCreating(modelBuilder);
        }
    }
}
