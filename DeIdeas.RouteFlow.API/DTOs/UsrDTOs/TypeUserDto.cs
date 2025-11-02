using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DeIdeas.RouteFlow.API.DTOs.UsrDTOs
{
    public class ReadTypeUserDto
    {
        public int IdTypeUser { get; set; }
        public string Description { get; set; } = null!;
        public int Status { get; set; }
        public string Date { get; set; } = null!;
    }

    public class CreateTypeUserDto
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(50, ErrorMessage = "El campo {0} puede tener hasta {1} caracteres")]
        [DisplayName("Cargo")]
        public string Description { get; set; } = null!;
    }

    public class ModifyTypeUserDto
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [DisplayName("ID de Tipo de Usuario")]
        public int IdTypeUser { get; set; }

        [MaxLength(50, ErrorMessage = "El campo {0} puede tener hasta {1} caracteres")]
        [DisplayName("Cargo")]
        public string? Description { get; set; }
    }

    public class ChangeStatusTypeUserDto
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [DisplayName("ID de Tipo de Usuario")]
        public int IdTypeUser { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [DisplayName("Estado")]
        public int Status { get; set; }
    }
}

