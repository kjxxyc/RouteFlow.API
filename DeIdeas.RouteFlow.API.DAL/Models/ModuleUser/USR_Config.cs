using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeIdeas.RouteFlow.API.DAL.Models.ModuleUser
{
    [Table("USR_Config", Schema = "ONE")]
    public partial class USR_Config
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Description { get; set; } = null!;

        public int Status { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime Date { get; set; }

        [Required]
        [StringLength(50)]
        public string IdUser { get; set; } = null!;

        [ForeignKey(nameof(IdUser))]
        public virtual USR_User User { get; set; } = null!;        
    }
}
