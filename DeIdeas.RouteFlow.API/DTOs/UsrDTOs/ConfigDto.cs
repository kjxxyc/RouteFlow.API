using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace DeIdeas.RouteFlow.API.DTOs.UsrDTOs
{

    public class ReadConfigDto
    {
        public int Id { get; set; }
        public string Description { get; set; } = null!;
        public int Status { get; set; }
        public string Date { get; set; } = null!;
        public string IdUser { get; set; } = null!;
    }

    public class CreateConfigDto
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(200, ErrorMessage = "El campo {0} puede tener hasta {1} caracteres")]
        [DisplayName("Descripción")]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(50)]
        [DisplayName("Usuario")]
        public string IdUser { get; set; } = null!;
    }

    public class ModifyConfigDto
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [DisplayName("ID Configuración")]
        public int Id { get; set; }

        [MaxLength(200, ErrorMessage = "El campo {0} puede tener hasta {1} caracteres")]
        [DisplayName("Descripción")]
        public string? Description { get; set; }

        [MaxLength(50)]
        [DisplayName("Usuario")]
        public string? IdUser { get; set; }
    }

    public class ChangeStatusConfigDto
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [DisplayName("ID Configuración")]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [DisplayName("Estado")]
        public int Status { get; set; }
    }

}
