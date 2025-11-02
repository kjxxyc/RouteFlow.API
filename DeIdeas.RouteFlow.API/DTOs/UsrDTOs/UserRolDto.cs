using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace DeIdeas.RouteFlow.API.DTOs.UsrDTOs
{
    public class ReadUserRolDto
    {
        public string User { get; set; } = null!;
        public string Rol { get; set; } = null!;
        public int Status { get; set; }
        public string Date { get; set; } = null!;
    }

    public class CreateUserRolDto
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(50, ErrorMessage = "El campo {0} puede tener hasta {1} caracteres")]
        [DisplayName("Usuario")]
        public string User { get; set; } = null!;

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(50, ErrorMessage = "El campo {0} puede tener hasta {1} caracteres")]
        [DisplayName("Rol")]
        public string Rol { get; set; } = null!;
    }

    public class ModifyUserRolDto
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [DisplayName("Usuario")]
        public string User { get; set; } = null!;

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [DisplayName("Rol")]
        public string Rol { get; set; } = null!;
    }

    public class ChangeStatusUserRolDto
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [DisplayName("Usuario")]
        public string User { get; set; } = null!;

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [DisplayName("Rol")]
        public string Rol { get; set; } = null!;

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [DisplayName("Estado")]
        public int Status { get; set; }
    }
}
