using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sale.Api.Servicios;
using Sale.Shared.Modelo.DTO;

namespace Sale.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresasController : ControllerBase
    {
        private readonly IEmpresas  _empresa;
        private readonly IMapper _mapper;
        public EmpresasController(IEmpresas empresa, IMapper mapper)
        {
            _empresa = empresa;
            _mapper = mapper;
        }
        /*--------------------------------- Insert ---------------------------------*/

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(EmpresaDTO))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateEmpresa([FromBody] EmpresaDTO RegistroDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (RegistroDTO == null)
            {
                return BadRequest(ModelState);
            }
            var createReg = await _empresa.CreateEmpresa(RegistroDTO);
            return Ok(createReg);
        }

        /*----------------------------------- Delete ------------------------------*/


        [HttpPut("{id_empresa:int}", Name = "UpdateEmpresa")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EmpresaDTO))]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdatePais(int id_empresa, [FromBody] EmpresaDTO RegistroDTO)
        {
            if (id_empresa != RegistroDTO.Id_empresa) return BadRequest("Id no coincide");

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
                var Updated = await _empresa.UpdateEmpresa(RegistroDTO);

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


        [HttpGet("default/{Default_name}", Name = "EmpresaDefault")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> PaisDefault(string Default_name)
        {
            var lista = await _empresa.GetListEmpresaActivo(Default_name);
            return Ok(lista);
        }

        [HttpGet("name/{id_empresa:int}", Name = "EmpresaName")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<string>> EmpresaName(int id_empresa)
        {
            try
            {
                var nombre = await _empresa.GetEmpresaName(id_empresa);
                return Ok(nombre);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("Combo", Name = "EmpresaCombo")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> EmpresaCombo(string Estado)
        {
            var lista = await _empresa.GetEmpresaCombo(Estado);
            return Ok(lista);
        }

        [HttpDelete("{id_empresa:int}", Name = "CancelEmpresa")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CancelEmpresa(int id_empresa)
        {
            var Registro = await _empresa.DeleteEmpresaLogica(id_empresa);
            return Ok(Registro);
        }
    }
}
