using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeIdeas.RouteFlow.API.DAL.Models.Routing
{
    [Table("DetRutas", Schema = "dbo")]
    public class DetRuta
    {
        [Key]
        public int DetRutaID { get; set; }

        public int RutaID { get; set; }

        public int No_Documento { get; set; }

        [StringLength(100)]
        public string Usuario { get; set; } = null!;

        [Column(TypeName = "datetime")]
        public DateTime Fecha { get; set; }

        [ForeignKey(nameof(RutaID))]
        public virtual Ruta? Ruta { get; set; }
    }
}