using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace DeIdeas.RouteFlow.API.DTOs.Legacy
{
    public class CreateRouteDto
    {
        [MaxLength(20)]
        public string? TipoRuta { get; set; }

        [Required]
        public DateTime FechaRuta { get; set; }

        [MaxLength(30)]
        public string? Estado { get; set; }

        [MaxLength(100)]
        public string? Usuario { get; set; }

        [MaxLength(100)]
        public string? UsuarioAsignado { get; set; }

        [Required]
        public List<int> NoDocumentos { get; set; } = new List<int>();
    }
}
