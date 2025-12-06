using DeIdeas.RouteFlow.API.DAL.Interfaces;
using DeIdeas.RouteFlow.API.DAL.Models.Legacy;
using DeIdeas.RouteFlow.API.DAL.Models.Routing;
using DeIdeas.RouteFlow.API.DTOs.Legacy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DeIdeas.RouteFlow.API.Controllers.Legacy
{
    [Route("api/legacy/[controller]")]
    [ApiController]
    public class RoutesController : ControllerBase
    {
        private readonly IUnitOfWork _unit;
        public RoutesController(IUnitOfWork unit) { _unit = unit; }

        // Lista de rutas desde la vista
        [HttpGet("FactPending")]
        public async Task<IActionResult> GetAll()
        {
            var list = await _unit.PendingPass.GetAllAsync();
            return Ok(list);
        }

        // Inserta snapshot (solo crea el snapshot)
        [HttpPost("snapshot")]
        public async Task<IActionResult> CreateSnapshot([FromBody] OINV_OCRD_Snapshot payload, CancellationToken ct)
        {
            if (payload == null) return BadRequest();

            payload.FechaInsert = DateTime.UtcNow;
            payload.EstadoRegistro = string.IsNullOrEmpty(payload.EstadoRegistro) ? "Activo" : payload.EstadoRegistro;
            payload.UsuarioRegistro = string.IsNullOrEmpty(payload.UsuarioRegistro) ? "system" : payload.UsuarioRegistro;

            var existing = await _unit.Snapshot.GetByDocumentoAsync(payload.No_Documento, ct);
            if (existing != null)
            {
                return Conflict(new { message = $"Snapshot con No_Documento {payload.No_Documento} ya existe." });
            }

            await _unit.Snapshot.InsertAsync(payload, ct);

            return Created($"api/legacy/routes/snapshot/{payload.No_Documento}", payload);
        }

        // Crear ruta y agregar detalle con lista de No_Documento
        [HttpPost("route")]
        public async Task<IActionResult> CreateRoute([FromBody] CreateRouteDto dto, CancellationToken ct)
        {
            if (dto == null) return BadRequest();
            if (dto.NoDocumentos == null || dto.NoDocumentos.Count == 0) return BadRequest(new { message = "Se requiere al menos un No_Documento." });

            var ruta = new Ruta
            {
                TipoRuta = string.IsNullOrWhiteSpace(dto.TipoRuta) ? "Manual" : dto.TipoRuta,
                FechaRuta = dto.FechaRuta.Date,
                Estado = string.IsNullOrWhiteSpace(dto.Estado) ? "Programada" : dto.Estado,
                Usuario = string.IsNullOrWhiteSpace(dto.Usuario) ? "system" : dto.Usuario,
                UsuarioAsignado = string.IsNullOrWhiteSpace(dto.UsuarioAsignado) ? null : dto.UsuarioAsignado,
                Fecha = DateTime.UtcNow
            };

            await _unit.Ruta.InsertAsync(ruta, ct);

            var createdDetails = new List<object>();

            foreach (var noDoc in dto.NoDocumentos)
            {
                var exists = await _unit.Ruta.DetRutaExistsAsync(noDoc, ct);
                if (exists) continue;

                var det = new DetRuta
                {
                    RutaID = ruta.RutaID,
                    No_Documento = noDoc,
                    Usuario = ruta.Usuario,
                    Fecha = DateTime.UtcNow
                };

                await _unit.Ruta.InsertDetRutaAsync(det, ct);
                createdDetails.Add(new { det.DetRutaID, det.RutaID, det.No_Documento });
            }

            return Ok(new { message = "Ruta creada", rutaId = ruta.RutaID, details = createdDetails });
        }

        // Actualiza forma de pago y total pagado
        [HttpPatch("snapshot/{noDocumento:int}")]
        public async Task<IActionResult> UpdateSnapshotPayment(int noDocumento, [FromBody] UpdateSnapshotPaymentDto dto, CancellationToken ct)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var entity = await _unit.Snapshot.GetByDocumentoAsync(noDocumento, ct);
            if (entity == null) return NotFound();

            if (!string.IsNullOrWhiteSpace(dto.FormaPago))
            {
                entity.U_forma_pago = dto.FormaPago?.Trim();
            }

            var nuevoTotalPagado = entity.Total_Pagado + dto.MontoPago;
            if (nuevoTotalPagado > entity.Total_Documento)
            {
                nuevoTotalPagado = entity.Total_Documento;
            }
            entity.Total_Pagado = nuevoTotalPagado;

            if (!string.IsNullOrWhiteSpace(dto.Usuario))
            {
                entity.UsuarioRegistro = dto.Usuario!.Trim();
            }

            if (entity.Total_Pagado >= entity.Total_Documento)
            {
                entity.EstadoRegistro = "Pagado";
            }

            entity.FechaInsert = DateTime.UtcNow;

            try
            {
                await _unit.Snapshot.UpdateAsync(entity, ct);
            }
            catch (DbUpdateConcurrencyException)
            {
                return Conflict(new { message = "Conflicto de concurrencia al actualizar el snapshot (No_Documento)." });
            }

            return Ok(entity);
        }

        // Actualiza contraseña y fecha de vencimiento del snapshot
        [HttpPatch("snapshot/password/{noDocumento:int}")]
        public async Task<IActionResult> UpdateSnapshotPassword(int noDocumento, [FromBody] UpdateSnapshotPasswordDto dto, CancellationToken ct)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var entity = await _unit.Snapshot.GetByDocumentoAsync(noDocumento, ct);
            if (entity == null) return NotFound();

            entity.U_contrasenia = dto.Password.Trim();
            entity.U_fecha_contrasenia = dto.ExpirationDate.Date;

            if (!string.IsNullOrWhiteSpace(dto.Usuario))
            {
                entity.UsuarioRegistro = dto.Usuario!.Trim();
            }

            entity.FechaInsert = DateTime.UtcNow;

            try
            {
                await _unit.Snapshot.UpdatePasswordAsync(entity, ct);
            }
            catch (DbUpdateConcurrencyException)
            {
                return Conflict(new { message = "Conflicto de concurrencia al actualizar la contraseña del snapshot (No_Documento)." });
            }

            return Ok(entity);
        }
    }
}
