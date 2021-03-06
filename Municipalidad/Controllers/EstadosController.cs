using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Municipalidad.Abastecimiento.WebAPI.Dtos;
using Municipalidad.Abastecimiento.WebAPI.Models;

namespace Municipalidad.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadosController : ControllerBase
    {
        private readonly MunicipalidadLaredoContext context;
        private readonly IMapper mapper;

        public EstadosController(MunicipalidadLaredoContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<List<GetEstadoDto>> Get()
        {
            return mapper.Map<List<GetEstadoDto>>(await context.Estados.ToListAsync());
        }
    }
}