using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeIdeas.RouteFlow.API.DAL.Models.Legacy
{
    [Table("OCRD", Schema = "dbo")]
    public class OCRD
    {
        [Key]
        [StringLength(15)]
        public string CardCode { get; set; } = null!;

        [StringLength(100)]
        public string CardName { get; set; } = null!;

        [StringLength(200)]
        public string? Address { get; set; }

        // Grupos de consulta (flags char(1))
        [StringLength(1)] 
        public string? QryGroup25 { get; set; }

        [StringLength(1)] 
        public string? QryGroup26 { get; set; }

        [StringLength(1)] 
        public string? QryGroup27 { get; set; }

        [StringLength(1)] 
        public string? QryGroup28 { get; set; }

        [StringLength(1)] 
        public string? QryGroup29 { get; set; }

        [StringLength(1)] 
        public string? QryGroup30 { get; set; }

        [StringLength(1)] 
        public string? QryGroup32 { get; set; }

        [StringLength(1)] 
        public string? QryGroup33 { get; set; }

        [StringLength(1)] 
        public string? QryGroup34 { get; set; }

        [StringLength(1)] 
        public string? QryGroup35 { get; set; }
    }
}