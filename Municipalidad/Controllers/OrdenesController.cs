using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Municipalidad.Abastecimiento.WebAPI.Dtos;
using Municipalidad.Abastecimiento.WebAPI.Models;

namespace Municipalidad.Abastecimiento.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenesController : ControllerBase
    {
        private readonly MunicipalidadLaredoContext context;
        private readonly IMapper mapper;

        public OrdenesController(MunicipalidadLaredoContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<List<GetOrdenDto>> Get([FromQuery] int? productoId, int? areaId, int? estadoId)
        {
            var ordenesQuery = context.Ordenes.Select(x => new GetOrdenDto
            {
                Id = x.Id,
                ProductoId = x.ProductoId,
                ProductoNombre = x.Producto.Nombre,
                AreaId = x.AreaSolicitanteId,
                AreaNombre = x.AreaSolicitante.Nombre,
                FechaCreacion = x.FechaCreacion,
                EstadoId = x.EstadoId,
                EstadoNombre = x.Estado.Nombre,
                EstadoColor = x.Estado.Color,
                FechaActualizacion = x.FechaModificacion,
                Observaciones = x.Observaciones
            });

            if(productoId.HasValue)
                ordenesQuery=ordenesQuery.Where(x=>x.ProductoId == productoId.Value);

            if (areaId.HasValue)
                ordenesQuery = ordenesQuery.Where(x => x.AreaId == areaId.Value);

            if (estadoId.HasValue)
                ordenesQuery = ordenesQuery.Where(x => x.EstadoId == estadoId.Value);

            return await ordenesQuery.ToListAsync();
        }
    }
}
