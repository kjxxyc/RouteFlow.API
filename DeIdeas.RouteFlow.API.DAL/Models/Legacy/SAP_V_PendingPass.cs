using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DeIdeas.RouteFlow.API.DAL.Models.Legacy
{
    [Table("SAP_V_PendingPass", Schema = "dbo")]
    public class SAP_V_PendingPass
    {
        // Match the DB view types
        public int No_Documento { get; set; }
        [Column(TypeName = "date")]
        public DateTime Fecha_documento { get; set; }
        [Column(TypeName = "date")]
        public DateTime Fecha_vencimiento { get; set; }
        [StringLength(15)]
        public string Id_SN { get; set; } = null!;
        [StringLength(100)]
        public string Nombre_SN { get; set; } = null!;
        [StringLength(200)]
        public string? Direccion_SN { get; set; }
        [Column(TypeName = "numeric(19,2)")]
        public decimal Total_Documento { get; set; }
        [Column(TypeName = "numeric(19,2)")]
        public decimal Total_Pagado { get; set; }
        [StringLength(30)]
        public string? U_contrasenia { get; set; }
        [Column(TypeName = "date")]
        public DateTime? U_fecha_contrasenia { get; set; }
        [StringLength(50)]
        public string? U_forma_pago { get; set; }
        public char? Todos_Dias { get; set; }
        public char? Lunes { get; set; }
        public char? Martes { get; set; }
        public char? Miercoles { get; set; }
        public char? Jueves { get; set; }
        public char? Viernes { get; set; }
        public char? Ruta1 { get; set; }
        public char? Ruta2 { get; set; }
        public char? Ruta3 { get; set; }
        public char? Ruta4 { get; set; }
        // NoRuta in DB is int nullable
        public int? NoRuta { get; set; }
    }
}