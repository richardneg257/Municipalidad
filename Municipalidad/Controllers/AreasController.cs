using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Municipalidad.Abastecimiento.WebAPI.Dtos;
using Municipalidad.Abastecimiento.WebAPI.Models;

namespace Municipalidad.Abastecimiento.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreasController : ControllerBase
    {
        private readonly MunicipalidadLaredoContext context;
        private readonly IMapper mapper;

        public AreasController(MunicipalidadLaredoContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<List<GetAreaDto>> Get()
        {
            return mapper.Map<List<GetAreaDto>>(await context.Areas.ToListAsync());
        }
    }
}
