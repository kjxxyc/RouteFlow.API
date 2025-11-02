using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeIdeas.RouteFlow.API.DAL.Models.ModuleUser
{
    [Table("USR_Rol", Schema = "ONE")]
    public partial class USR_Rol
    {
        [Key]
        [StringLength(50)]
        public string Rol { get; set; } = null!;

        [Required]
        [StringLength(200)]
        public string Description { get; set; } = null!;

        public int Status { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime Date { get; set; }

        [Required]
        [StringLength(50)]
        public string User { get; set; } = null!;
    }
}
