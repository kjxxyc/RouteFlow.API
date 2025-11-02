using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace DeIdeas.RouteFlow.API.DTOs.UsrDTOs
{
    public class ReadRolDto
    {
        public string Rol { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int Status { get; set; }
        public string Date { get; set; } = null!;
        public string User { get; set; } = null!;
    }

    public class CreateRolDto
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(50, ErrorMessage = "El campo {0} puede tener hasta {1} caracteres")]
        [DisplayName("Rol")]
        public string Rol { get; set; } = null!;

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(200, ErrorMessage = "El campo {0} puede tener hasta {1} caracteres")]
        [DisplayName("Descripción")]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [DisplayName("Usuario")]
        public string User { get; set; } = null!;
    }

    public class ModifyRolDto
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [DisplayName("Rol")]
        public string Rol { get; set; } = null!;

        [MaxLength(200, ErrorMessage = "El campo {0} puede tener hasta {1} caracteres")]
        [DisplayName("Descripción")]
        public string? Description { get; set; }

        [DisplayName("Usuario")]
        public string? User { get; set; }
    }

    public class ChangeStatusRolDto
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [DisplayName("Rol")]
        public string Rol { get; set; } = null!;

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [DisplayName("Estado")]
        public int Status { get; set; }
    }

}