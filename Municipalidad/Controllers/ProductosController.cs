using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Municipalidad.Abastecimiento.WebAPI.Dtos;
using Municipalidad.Abastecimiento.WebAPI.Models;

namespace Municipalidad.Abastecimiento.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly MunicipalidadLaredoContext context;
        private readonly IMapper mapper;

        public ProductosController(MunicipalidadLaredoContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<List<GetProductoDto>> Get()
        {
            return mapper.Map<List<GetProductoDto>>(await context.Productos.ToListAsync());
        }
    }
}
