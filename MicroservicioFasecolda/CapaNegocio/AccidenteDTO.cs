namespace CapaNegocio
{
    public class AccidenteDTO
    {
        public int IdAccidente { get; set; }
        public string Placa { get; set; }
        public DateTime Fecha { get; set; }
        public string Severidad { get; set; }  // 's', 'h', 'm'

        public AccidenteDTO() { }

        public AccidenteDTO(int id, string placa, DateTime fecha, string severidad)
        {
            IdAccidente = id;
            Placa = placa;
            Fecha = fecha;
            Severidad = severidad;
        }
    }

    public class AccidenteResponseDTO
    {
        public int SoloLatas { get; set; }
        public int Heridos { get; set; }
        public int Muertos { get; set; }
    }
}