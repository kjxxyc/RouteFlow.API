using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeIdeas.RouteFlow.API.DAL.Models.Routing
{
    [Table("Rutas", Schema = "dbo")]
    public class Ruta
    {
        [Key]
        public int RutaID { get; set; }

        [StringLength(20)]
        public string TipoRuta { get; set; } = null!;

        [Column(TypeName = "date")]
        public DateTime FechaRuta { get; set; }

        [StringLength(30)]
        public string Estado { get; set; } = null!;

        [StringLength(100)]
        public string Usuario { get; set; } = null!;

        [StringLength(100)]
        public string? UsuarioAsignado { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime Fecha { get; set; }

        public virtual ICollection<DetRuta>? Detalles { get; set; }
    }
}