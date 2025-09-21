using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sale.Api.Servicios;
using Sale.Shared.Modelo.DTO;

namespace Sale.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        private readonly IPersonas _persona;
        private readonly IMapper _mapper;
        public PersonasController(IPersonas persona, IMapper mapper)
        {
            _persona = persona;
            _mapper = mapper;
        }

        /*--------------------------------- Insert ---------------------------------*/

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(PersonaDTO))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreatePersona([FromBody] PersonaDTO RegistroDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (RegistroDTO == null)
            {
                return BadRequest(ModelState);
            }
            var createReg = await _persona.CreatePersona(RegistroDTO);
            return Ok(createReg);
        }

        /*----------------------------------- Delete ------------------------------*/


        [HttpPut("{id_persona:int}", Name = "UpdatePersona")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PersonaDTO))]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdatePais(int id_persona, [FromBody] PersonaDTO RegistroDTO)
        {
            if (id_persona != RegistroDTO.Id_persona) return BadRequest("Id no coincide");

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
                var Updated = await _persona.UpdatePersona(RegistroDTO);

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


        [HttpGet("default/{Default_name}", Name = "PersonaDefault")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> PaisDefault(string Default_name)
        {
            var lista = await _persona.GetListPersonaActivo(Default_name);
            return Ok(lista);
        }

        [HttpGet("name/{id_persona:int}", Name = "PersonaName")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<string>> PersonaName(int id_persona)
        {
            try
            {
                var nombre = await _persona.GetPersonaName(id_persona);
                return Ok(nombre);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("Combo", Name = "PersonaCombo")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> PersonaCombo(string Estado)
        {
            var lista = await _persona.GetPersonaCombo(Estado);
            return Ok(lista);
        }

        [HttpDelete("{id_persona:int}", Name = "CancelPersona")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CancelPersona(int id_persona)
        {
            var Registro = await _persona.DeletePersonaLogica(id_persona);
            return Ok(Registro);
        }
    }
}
