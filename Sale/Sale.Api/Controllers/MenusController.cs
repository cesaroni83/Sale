using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sale.Api.Servicios;
using Sale.Shared.Modelo.DTO;

namespace Sale.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenusController : ControllerBase
    {
        private readonly IMenus _menu;
        private readonly IMapper _mapper;
        public MenusController(IMenus menu, IMapper mapper)
        {
            _menu = menu;
            _mapper = mapper;
        }

        /*--------------------------------- Insert ---------------------------------*/

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(MenuDTO))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateMenu([FromBody] MenuDTO RegistroDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (RegistroDTO == null)
            {
                return BadRequest(ModelState);
            }
            var createReg = await _menu.CreateMenu(RegistroDTO);
            return Ok(createReg);
        }

        /*----------------------------------- Delete ------------------------------*/


        [HttpPut("{id_menu:int}", Name = "UpdateMenu")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MenuDTO))]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdatePais(int id_menu, [FromBody] MenuDTO RegistroDTO)
        {
            if (id_menu != RegistroDTO.Id_menu) return BadRequest("Id no coincide");

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
                var Updated = await _menu.UpdateMenu(RegistroDTO);

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


        [HttpGet("default/{Default_name}", Name = "MenuDefault")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> PaisDefault(string Default_name)
        {
            var lista = await _menu.GetListMenuActivo(Default_name);
            return Ok(lista);
        }

        [HttpGet("name/{id_menu:int}", Name = "MenuName")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<string>> MenuName(int id_menu)
        {
            try
            {
                var nombre = await _menu.GetMenuName(id_menu);
                return Ok(nombre);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("Combo", Name = "MenuCombo")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> MenuCombo(string Estado)
        {
            var lista = await _menu.GetMenuCombo(Estado);
            return Ok(lista);
        }

        [HttpDelete("{id_menu:int}", Name = "CancelMenu")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CancelMenu(int id_menu)
        {
            var Registro = await _menu.DeleteMenuLogica(id_menu);
            return Ok(Registro);
        }
    }
}
