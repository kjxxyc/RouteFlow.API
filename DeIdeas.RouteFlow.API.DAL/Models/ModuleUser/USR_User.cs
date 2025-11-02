using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeIdeas.RouteFlow.API.DAL.Models.ModuleUser
{
    [Table("USR_User", Schema = "ONE")]
    [Index(nameof(AdObjectId), IsUnique = true)]
    public partial class USR_User
    {
        [Key]
        [Required]
        [StringLength(50)]
        public string User { get; set; } = null!;     

        [Required]
        [StringLength(100)]
        public string Pass { get; set; } = null!;      

        public int Status { get; set; }               

        [Column(TypeName = "datetime")]
        public DateTime Date { get; set; }             

        [Column(TypeName = "datetime")]
        public DateTime LastLogin { get; set; }       

        public int IdTypeUser { get; set; }            

        [ForeignKey(nameof(IdTypeUser))]
        public virtual USR_TypeUser TypeUser { get; set; } = null!;

        [Required]
        [Column("ADObjectId")]
        [StringLength(50)]
        public string AdObjectId { get; set; } = null!;
    }
}
