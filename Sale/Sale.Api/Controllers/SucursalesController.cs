using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sale.Api.Servicios;
using Sale.Shared.Modelo.DTO;

namespace Sale.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SucursalesController : ControllerBase
    {
        private readonly ISucursales _sucursal;
        private readonly IMapper _mapper;
        public SucursalesController(ISucursales sucursal, IMapper mapper)
        {
            _sucursal = sucursal;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(SucursalDTO))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateSucursal([FromBody] SucursalDTO RegistroDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (RegistroDTO == null)
            {
                return BadRequest(ModelState);
            }
            var createReg = await _sucursal.CreateSucursal(RegistroDTO);
            return Ok(createReg);
        }

        /*----------------------------------- Delete ------------------------------*/


        [HttpPut("{id_sucursal:int}", Name = "UpdateSucursal")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SucursalDTO))]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdatePais(int id_sucursal, [FromBody] SucursalDTO RegistroDTO)
        {
            if (id_sucursal != RegistroDTO.Id_sucursal) return BadRequest("Id no coincide");

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
                var Updated = await _sucursal.UpdateSucursal(RegistroDTO);

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


        [HttpGet("default/{Default_name}", Name = "SucursalDefault")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> PaisDefault(string Default_name)
        {
            var lista = await _sucursal.GetListSucursalActivo(Default_name);
            return Ok(lista);
        }

        [HttpGet("name/{id_sucursal:int}", Name = "SucursalName")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<string>> SucursalName(int id_sucursal)
        {
            try
            {
                var nombre = await _sucursal.GetSucursalName(id_sucursal);
                return Ok(nombre);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("Combo", Name = "SucursalCombo")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> SucursalCombo(string Estado)
        {
            var lista = await _sucursal.GetSucursalCombo(Estado);
            return Ok(lista);
        }

        [HttpDelete("{id_sucursal:int}", Name = "CancelSucursal")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CancelSucursal(int id_sucursal)
        {
            var Registro = await _sucursal.DeleteSucursalLogica(id_sucursal);
            return Ok(Registro);
        }
    }
}
