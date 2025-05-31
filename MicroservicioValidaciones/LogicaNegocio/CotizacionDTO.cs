using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class CotizacionDTO
    {
        public int IdCotizacion { get; set; }
        public string Placa { get; set; }
        public string CcCliente { get; set; }
        public char Resultado { get; set; }
    }
}

public class AccidenteResponseDTO
{
    public int SoloLatas { get; set; } = 0;
    public int Heridos { get; set; } = 0;
    public int Muertos { get; set; } = 0;
}