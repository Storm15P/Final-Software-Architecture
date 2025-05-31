using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public interface IFuenteDatosFasecolda
    {
        AccidenteResponseDTO ObtenerAccidentes(string placa);
    }

    public interface IFuenteDatosLocal
    {
        bool GuardarCotizacion(CotizacionDTO cotizacion);
    }
}