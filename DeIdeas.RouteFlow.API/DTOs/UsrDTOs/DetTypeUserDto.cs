using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace DeIdeas.RouteFlow.API.DTOs.UsrDTOs
{

    public class ReadDetTypeUserDto
    {
        public int IdTypeUser { get; set; }
        public string User { get; set; } = null!;
    }

    public class CreateDetTypeUserDto
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [DisplayName("ID de Tipo de Usuario")]
        public int IdTypeUser { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(50, ErrorMessage = "El campo {0} puede tener hasta {1} caracteres")]
        [DisplayName("Usuario")]
        public string User { get; set; } = null!;
    }

    public class ModifyDetTypeUserDto
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [DisplayName("ID de Tipo de Usuario")]
        public int IdTypeUser { get; set; }

        [MaxLength(50, ErrorMessage = "El campo {0} puede tener hasta {1} caracteres")]
        [DisplayName("Usuario")]
        public string? User { get; set; }
    }

}
