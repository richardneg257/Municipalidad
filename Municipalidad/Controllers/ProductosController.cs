using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Municipalidad.Abastecimiento.WebAPI.Dtos;
using Municipalidad.Abastecimiento.WebAPI.Helpers;
using Municipalidad.Abastecimiento.WebAPI.Models;

namespace Municipalidad.Abastecimiento.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly MunicipalidadLaredoContext context;
        private readonly IMapper mapper;
        private readonly IAlmacenadorArchivos almacenadorArchivos;
        private readonly string contenedor = "productos";

        public ProductosController(MunicipalidadLaredoContext context, IMapper mapper, IAlmacenadorArchivos almacenadorArchivos)
        {
            this.context = context;
            this.mapper = mapper;
            this.almacenadorArchivos = almacenadorArchivos;
        }

        [HttpGet]
        public async Task<List<GetProductoDto>> Get()
        {
            return mapper.Map<List<GetProductoDto>>(await context.Productos.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromForm] ProductoCreacionDto productoCreacionDto)
        {
            var productoEntity = mapper.Map<Producto>(productoCreacionDto);
            if (productoCreacionDto.Photo != null)
            {
                productoEntity.Photo = await almacenadorArchivos.GuardarArchivo(contenedor, productoCreacionDto.Photo);
            }
            context.Add(productoEntity);
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
