using CapaAccesoDatos;
using CapaNegocio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CapaPresentacionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FasecoldaController : ControllerBase
    {
        private readonly Logica logica = new Logica(new ConexionBBDD());

        [HttpGet("{placa}")]
        public AccidenteResponseDTO Get(string placa)
        {
            return logica.ObtenerConteoAccidentes(placa);
        }
    }
}
