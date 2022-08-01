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

        [HttpGet("{id:int}")]
        public async Task<ActionResult<GetProductoDto>> GetById(int id)
        {
            var entity = await context.Productos.FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null) return NotFound();

            return mapper.Map<GetProductoDto>(entity);
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

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromForm] ProductoCreacionDto productoCreacionDto)
        {
            var entity = await context.Productos.FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null) return NotFound();

            entity = mapper.Map(productoCreacionDto, entity);

            if (productoCreacionDto.Photo != null)
            {
                entity.Photo = await almacenadorArchivos.EditarArchivo(contenedor, productoCreacionDto.Photo, entity.Photo);
            }

            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var entity = await context.Productos.FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null) return NotFound();

            context.Remove(entity);
            await context.SaveChangesAsync();

            await almacenadorArchivos.BorrarArchivo(entity.Photo, contenedor);

            return NoContent();
        }
    }
}
