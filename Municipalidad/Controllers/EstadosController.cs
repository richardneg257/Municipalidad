using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Municipalidad.Abastecimiento.WebAPI.Dtos;
using Municipalidad.Abastecimiento.WebAPI.Models;

namespace Municipalidad.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EstadosController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<EstadosController> _logger;
        private readonly MunicipalidadLaredoContext context;
        private readonly IMapper mapper;

        public EstadosController(ILogger<EstadosController> logger, MunicipalidadLaredoContext context, IMapper mapper)
        {
            _logger = logger;
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