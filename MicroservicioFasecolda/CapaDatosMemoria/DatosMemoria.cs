using CapaNegocio;

namespace CapaDatosMemoria
{
    public class DatosMemoria : FuenteDatos
    {
        private readonly List<AccidenteDTO> accidentes;

        public DatosMemoria()
        {
            accidentes = new List<AccidenteDTO>
            {
                new AccidenteDTO(1, "ABC123", new DateTime(2023, 1, 15), "s"),
                new AccidenteDTO(2, "ABC123", new DateTime(2023, 3, 20), "m"),
                new AccidenteDTO(3, "XYZ789", new DateTime(2023, 5, 10), "h"),
                new AccidenteDTO(4, "XYZ789", new DateTime(2023, 7, 5), "s")
            };
        }

        public List<AccidenteDTO> ConsultarAccidentesPorPlaca(string placa)
        {
            return accidentes.FindAll(a => a.Placa == placa);
        }
    }
}