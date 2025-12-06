using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace DeIdeas.RouteFlow.API.DTOs.UsrDTOs
{
    public class ReadControlRolDto
    {
        public int IdControl { get; set; }
        public string Rol { get; set; } = null!;
        public int Status { get; set; }
        public string Date { get; set; } = null!;
    }

    public class CreateControlRolDto
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [DisplayName("Control")]
        public int IdControl { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(50, ErrorMessage = "El campo {0} puede tener hasta {1} caracteres")]
        [DisplayName("Rol")]
        public string Rol { get; set; } = null!;
    }

    public class ModifyControlRolDto
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [DisplayName("Control")]
        public int IdControl { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(50, ErrorMessage = "El campo {0} puede tener hasta {1} caracteres")]
        [DisplayName("Rol")]
        public string Rol { get; set; } = null!;
    }

    public class ChangeStatusControlRolDto
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [DisplayName("Control")]
        public int IdControl { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(50, ErrorMessage = "El campo {0} puede tener hasta {1} caracteres")]
        [DisplayName("Rol")]
        public string Rol { get; set; } = null!;

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [DisplayName("Estado")]
        public int Status { get; set; }
    }
}