using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace DeIdeas.RouteFlow.API.DTOs.UsrDTOs
{
    public class ReadUserDto
    {
        public string User { get; set; } = null!;
        public int Status { get; set; }
        public string Date { get; set; } = null!;
        public string LastLogin { get; set; } = null!;
        public int IdTypeUser { get; set; }
    }

    public class CreateUserDto
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(50, ErrorMessage = "El campo {0} puede tener hasta {1} caracteres")]
        [DisplayName("Usuario")]
        public string User { get; set; } = null!;

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(100, ErrorMessage = "El campo {0} puede tener hasta {1} caracteres")]
        [DisplayName("Contraseña")]
        public string Pass { get; set; } = null!;

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [DisplayName("Tipo de Usuario")]
        public int IdTypeUser { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(100, ErrorMessage = "El campo {0} puede tener hasta {1} caracteres")]
        [DisplayName("AD Object ID")]
        public string? AdObjectId { get; set; }
    }

    public class ModifyUserDto
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(50, ErrorMessage = "El campo {0} puede tener hasta {1} caracteres")]
        [DisplayName("Usuario")]
        public string User { get; set; } = null!;

        [MaxLength(100, ErrorMessage = "El campo {0} puede tener hasta {1} caracteres")]
        [DisplayName("Contraseña")]
        public string? Pass { get; set; }
    }

    public class ChangeStatusUserDto
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(50, ErrorMessage = "El campo {0} puede tener hasta {1} caracteres")]
        [DisplayName("Usuario")]
        public string User { get; set; } = null!;

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [DisplayName("Estado")]
        public int Status { get; set; }
    }
}
