using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeIdeas.RouteFlow.API.DAL.Models.ModuleUser
{
    [Table("USR_UserRol", Schema = "ONE")]
    public partial class USR_UserRol
    {
        [Required]
        [StringLength(50)]
        public string User { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string Rol { get; set; } = null!;

        public int Status { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime Date { get; set; }

        [ForeignKey(nameof(User))]
        public virtual USR_User UserNavigation { get; set; } = null!;

        [ForeignKey(nameof(Rol))]
        public virtual USR_Rol RolNavigation { get; set; } = null!;
    }

}
