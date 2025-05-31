using CapaDatosFasecolda;
using CapaDatosTransferencias;
using LogicaNegocio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CapaPresentacionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValidacionesController : ControllerBase
    {
        private readonly Logica logica = new Logica(
            new ConexionAPI(),
            new ConexionBBDD()
        );

        [HttpGet]
        public IActionResult Get(string placa, string ccCliente)
        {
            bool resultado = logica.RealizarCotizacion(placa, ccCliente);
            return Ok(new { cotizacion = resultado });
        }
    }

    public class SolicitudCotizacion
    {
        public string Placa { get; set; }
        public string CcCliente { get; set; }
    }
}