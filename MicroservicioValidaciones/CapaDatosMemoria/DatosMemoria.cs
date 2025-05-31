using LogicaNegocio;

namespace CapaDatosMemoria
{
    public class DatosFasecoldaMemoria : IFuenteDatosFasecolda
    {
        public AccidenteResponseDTO ObtenerAccidentes(string placa)
        {
            
            return placa switch
            {
                "ABC123" => new AccidenteResponseDTO { SoloLatas = 2, Heridos = 1, Muertos = 0 },
                "XYZ789" => new AccidenteResponseDTO { SoloLatas = 0, Heridos = 0, Muertos = 3 },
                "TEST00" => new AccidenteResponseDTO { SoloLatas = 3, Heridos = 0, Muertos = 0 },
                "ERROR" => null,  
                _ => new AccidenteResponseDTO() 
            };
        }
    }

    public class DatosLocalMemoria : IFuenteDatosLocal
    {
        public List<CotizacionDTO> Cotizaciones { get; } = new List<CotizacionDTO>();

        public bool GuardarCotizacion(CotizacionDTO cotizacion)
        {
            Cotizaciones.Add(cotizacion);
            return true;
        }
    }
}