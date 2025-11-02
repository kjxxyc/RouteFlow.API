using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeIdeas.RouteFlow.API.DAL.Models.ModuleUser
{
    [Table("USR_Control", Schema = "ONE")]
    public partial class USR_Control
    {
        [Key]
        public int IdControl { get; set; }

        public int IdMaestro { get; set; }

        [Required]
        [StringLength(50)]
        public string Code { get; set; } = null!;

        [Required]
        [StringLength(200)]
        public string Description { get; set; } = null!;

        public int Status { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime Date { get; set; }

        [Required]
        [StringLength(50)]
        public string User { get; set; } = null!;

        // Navegación al usuario que creó/actualizó
        [ForeignKey(nameof(User))]
        public virtual USR_User UserNavigation { get; set; } = null!;
    }
}
