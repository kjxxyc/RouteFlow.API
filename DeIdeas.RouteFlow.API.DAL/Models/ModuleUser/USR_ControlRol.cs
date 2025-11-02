using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeIdeas.RouteFlow.API.DAL.Models.ModuleUser
{
    [Table("USR_ControlRol", Schema = "ONE")]
    public partial class USR_ControlRol
    {
        public int IdControl { get; set; }

        [Required]
        [StringLength(50)]
        public string Rol { get; set; } = null!;

        public int Status { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime Date { get; set; }

        // Navegación a USR_Control
        [ForeignKey(nameof(IdControl))]
        public virtual USR_Control Control { get; set; } = null!;

        // Navegación a USR_Rol
        [ForeignKey(nameof(Rol))]
        public virtual USR_Rol RolNavigation { get; set; } = null!;
    }
}
