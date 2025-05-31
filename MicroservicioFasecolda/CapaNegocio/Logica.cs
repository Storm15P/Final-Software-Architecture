using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class Logica
    {
        private readonly FuenteDatos repositorio;

        public Logica(FuenteDatos repositorio)
        {
            this.repositorio = repositorio;
        }

        public AccidenteResponseDTO ObtenerConteoAccidentes(string placa)
        {
            var accidentes = repositorio.ConsultarAccidentesPorPlaca(placa);
            var response = new AccidenteResponseDTO();

            foreach (var accidente in accidentes)
            {
                switch (accidente.Severidad)
                {
                    case "s": response.SoloLatas++; break;
                    case "h": response.Heridos++; break;
                    case "m": response.Muertos++; break;
                }
            }

            return response;
        }
    }
}