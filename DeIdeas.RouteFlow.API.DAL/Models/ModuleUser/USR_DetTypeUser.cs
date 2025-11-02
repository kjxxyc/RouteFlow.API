using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeIdeas.RouteFlow.API.DAL.Models.ModuleUser
{
    [Table("USR_DetTypeUser", Schema = "ONE")]
    public partial class USR_DetTypeUser
    {
        public int IdTypeUser { get; set; }

        [Required]
        [StringLength(50)]
        public string User { get; set; } = null!;

        [ForeignKey(nameof(IdTypeUser))]
        public virtual USR_TypeUser TypeUser { get; set; } = null!;

        public int Status { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime Date { get; set; }

        // Navegación al usuario asociado al detalle (User -> USR_User.User)
        [ForeignKey(nameof(User))]
        public virtual USR_User UserNavigation { get; set; } = null!;
    }
}
