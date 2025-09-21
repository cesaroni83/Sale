using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sale.Api.SolidWorks;
using SolidWorks.Interop.sldworks;

namespace Sale.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolidWorksController : ControllerBase
    {
        private readonly ISolidWorksFile _swService;
        
        public SolidWorksController(ISolidWorksFile swService)
        {
            _swService = swService;
            
        }

        [HttpPost("open-assembly")]
        public IActionResult OpenFileSolidworks( string path,int tipo)
        {
            ModelDoc2 model ;
            model = _swService.OpenAppFile(path,1);
            if (model != null)
                return Ok("Ensamblaje abierto correctamente.");
            return BadRequest("Error al abrir el ensamblaje.");
        }
    }
}
