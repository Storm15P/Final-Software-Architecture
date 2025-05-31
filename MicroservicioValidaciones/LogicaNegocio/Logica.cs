namespace LogicaNegocio
{
    public class Logica
    {
        private readonly IFuenteDatosFasecolda fuenteFasecolda;
        private readonly IFuenteDatosLocal fuenteLocal;

        public Logica(IFuenteDatosFasecolda fuenteFasecolda, IFuenteDatosLocal fuenteLocal)
        {
            this.fuenteFasecolda = fuenteFasecolda;
            this.fuenteLocal = fuenteLocal;
        }

        public bool RealizarCotizacion(string placa, string ccCliente)
        {
            
            var accidentes = fuenteFasecolda.ObtenerAccidentes(placa);

            
            int puntos = accidentes.SoloLatas * 100 
                       + accidentes.Heridos * 200 
                       + accidentes.Muertos * 300;

            
            bool aprobado = puntos < 400;

            
            var cotizacion = new CotizacionDTO
            {
                Placa = placa,
                CcCliente = ccCliente,
                Resultado = aprobado ? 'a' : 'r'
            };

            fuenteLocal.GuardarCotizacion(cotizacion);

            return aprobado;
        }
    }
}