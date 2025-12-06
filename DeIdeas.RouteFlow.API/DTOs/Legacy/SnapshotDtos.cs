using System.ComponentModel.DataAnnotations;

namespace DeIdeas.RouteFlow.API.DTOs.Legacy
{
    public class UpdateSnapshotPaymentDto
    {
        [Required]
        [Range(typeof(decimal), "0.01", "79228162514264337593543950335", ErrorMessage = "El monto debe ser mayor que 0")]
        public decimal MontoPago { get; set; }

        [MaxLength(50)]
        public string? FormaPago { get; set; }

        [MaxLength(100)]
        public string? Usuario { get; set; }
    }

    public class UpdateSnapshotPasswordDto
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(30, ErrorMessage = "El campo {0} puede tener hasta {1} caracteres")]
        public string Password { get; set; } = null!;

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public DateTime ExpirationDate { get; set; }

        [MaxLength(100)]
        public string? Usuario { get; set; }
    }
}
