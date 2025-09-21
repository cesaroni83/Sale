using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sale.Api.Servicios;
using Sale.Shared.Modelo.DTO;

namespace Sale.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CiudadesController : ControllerBase
    {
        private readonly ICiudades _ciudad;
        private readonly IMapper _mapper;
        public CiudadesController(ICiudades ciudad, IMapper mapper)
        {
            _ciudad = ciudad;
            _mapper = mapper;
        }

        /*--------------------------------- Insert ---------------------------------*/

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(CiudadDTO))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateCiudad([FromBody] CiudadDTO RegistroDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (RegistroDTO == null)
            {
                return BadRequest(ModelState);
            }
            var createReg = await _ciudad.CreateCiudad(RegistroDTO);
            return Ok(createReg);
        }

        /*----------------------------------- Delete ------------------------------*/


        [HttpPut("{id_ciudad:int}", Name = "UpdateCiudad")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CiudadDTO))]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdatePais(int id_ciudad, [FromBody] CiudadDTO RegistroDTO)
        {
            if (id_ciudad != RegistroDTO.Id_ciudad) return BadRequest("Id no coincide");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (RegistroDTO == null)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var Updated = await _ciudad.UpdateCiudad(RegistroDTO);

                if (!Updated)
                    return NotFound("No se encontró el registro a actualizar");

                return Ok(RegistroDTO);
            }
            catch (Exception ex)
            {
                // Puedes loggear el error aquí
                return StatusCode(500, $"Ocurrió un error al actualizar: {ex.Message}");
            }
        }


        [HttpGet("default/{Default_name}", Name = "CiudadDefault")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> PaisDefault(string Default_name)
        {
            var lista = await _ciudad.GetListCiudadActivo(Default_name);
            return Ok(lista);
        }

        [HttpGet("name/{id_ciudad:int}", Name = "CiudadName")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<string>> CiudadName(int id_ciudad)
        {
            try
            {
                var nombre = await _ciudad.GetCiudadName(id_ciudad);
                return Ok(nombre);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("Combo", Name = "CiudadCombo")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> CiudadCombo(string Estado)
        {
            var lista = await _ciudad.GetCiudadCombo(Estado);
            return Ok(lista);
        }

        [HttpDelete("{id_ciudad:int}", Name = "CancelCiudad")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CancelCiudad(int id_ciudad)
        {
            var Registro = await _ciudad.DeleteCiudadLogica(id_ciudad);
            return Ok(Registro);
        }
    }
}
