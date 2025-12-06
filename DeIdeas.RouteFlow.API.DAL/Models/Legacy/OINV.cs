using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeIdeas.RouteFlow.API.DAL.Models.Legacy
{
    [Table("OINV", Schema = "dbo")]
    public class OINV
    {
        [Key]
        public int DocEntry { get; set; }

        public int DocNum { get; set; }

        [Column(TypeName = "date")]
        public DateTime DocDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime DocDueDate { get; set; }

        [StringLength(15)]
        public string CardCode { get; set; } = null!;

        [StringLength(100)]
        public string CardName { get; set; } = null!;

        [StringLength(200)]
        public string? Address { get; set; }

        [Column(TypeName = "numeric(19,2)")]
        public decimal DocTotal { get; set; }

        [Column(TypeName = "numeric(19,2)")]
        public decimal PaidSum { get; set; }

        [StringLength(30)]
        public string? U_contrasenia { get; set; }

        [Column(TypeName = "date")]
        public DateTime? U_fecha_contrasenia { get; set; }

        [StringLength(50)]
        public string? U_forma_pago { get; set; }

        [StringLength(1)]
        public string? CANCELED { get; set; }

        [StringLength(1)]
        public string? DocStatus { get; set; }
    }
}