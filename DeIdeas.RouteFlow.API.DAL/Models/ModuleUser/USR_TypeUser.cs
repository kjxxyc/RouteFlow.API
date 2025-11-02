using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeIdeas.RouteFlow.API.DAL.Models.ModuleUser
{
    [Table("USR_TypeUser", Schema = "ONE")]
    public partial class USR_TypeUser
    {
        [Key]
        public int IdTypeUser { get; set; }

        [Required]
        [StringLength(50)]
        public string Description { get; set; } = null!;

        public int Status { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime Date { get; set; }

        // Relación con usuarios (USR_User.TypeUser <-> USR_TypeUser.Users)
        [InverseProperty(nameof(USR_User.TypeUser))]
        public virtual ICollection<USR_User> Users { get; set; } = [];//= new List<USR_User>();
    }
}
