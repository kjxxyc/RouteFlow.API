using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace DeIdeas.RouteFlow.API.DTOs.UsrDTOs
{

    public class ReadControlDto
    {
        public int IdControl { get; set; }
        public int IdMaestro { get; set; }
        public string Code { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int Status { get; set; }
        public string Date { get; set; } = null!;
        public string User { get; set; } = null!;
    }

    public class CreateControlDto
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [DisplayName("Maestro")]
        public int IdMaestro { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(50, ErrorMessage = "El campo {0} puede tener hasta {1} caracteres")]
        [DisplayName("Código")]
        public string Code { get; set; } = null!;

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(200, ErrorMessage = "El campo {0} puede tener hasta {1} caracteres")]
        [DisplayName("Descripción")]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [DisplayName("Usuario")]
        public string User { get; set; } = null!;
    }

    public class ModifyControlDto
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [DisplayName("ID Control")]
        public int IdControl { get; set; }

        [DisplayName("Maestro")]
        public int? IdMaestro { get; set; }

        [MaxLength(50, ErrorMessage = "El campo {0} puede tener hasta {1} caracteres")]
        [DisplayName("Código")]
        public string? Code { get; set; }

        [MaxLength(200, ErrorMessage = "El campo {0} puede tener hasta {1} caracteres")]
        [DisplayName("Descripción")]
        public string? Description { get; set; }

        [DisplayName("Usuario")]
        public string? User { get; set; }
    }

    public class ChangeStatusControlDto
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [DisplayName("ID Control")]
        public int IdControl { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [DisplayName("Estado")]
        public int Status { get; set; }
    }

}
