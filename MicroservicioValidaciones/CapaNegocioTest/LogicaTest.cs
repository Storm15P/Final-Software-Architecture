using CapaDatosMemoria;
using LogicaNegocio;

namespace CapaNegocioTest
{
    [TestClass]
    public class LogicaTest
    {
        private readonly DatosFasecoldaMemoria fuenteFasecolda = new();
        private readonly DatosLocalMemoria fuenteLocal = new();
        private Logica logica;

        [TestInitialize]
        public void Setup()
        {
            logica = new Logica(fuenteFasecolda, fuenteLocal);
        }

        [TestMethod]
        public void CotizacionAprobadaPuntosBajoLimite()
        {
            // TEST00: 3*100 = 300 puntos (<400)
            bool resultado = logica.RealizarCotizacion("TEST00", "123456");

            Assert.IsTrue(resultado);
            Assert.AreEqual('a', fuenteLocal.Cotizaciones[0].Resultado);
        }

        [TestMethod]
        public void CotizacionRechazadaPuntosSobreLimite()
        {
            // XYZ789: 3*300 = 900 puntos (>400)
            bool resultado = logica.RealizarCotizacion("XYZ789", "987654");

            Assert.IsFalse(resultado);
            Assert.AreEqual('r', fuenteLocal.Cotizaciones[0].Resultado);
        }

        [TestMethod]
        public void CotizacionLimiteExactoRechazada()
        {
            // ABC123: 2*100 + 1*200 = 400 puntos (límite exacto)
            bool resultado = logica.RealizarCotizacion("ABC123", "111111");

            Assert.IsFalse(resultado);
            Assert.AreEqual('r', fuenteLocal.Cotizaciones[0].Resultado);
        }

        [TestMethod]
        public void CotizacionPlacaDesconocidaAprobada()
        {
            bool resultado = logica.RealizarCotizacion("DESCON", "000000");

            Assert.IsTrue(resultado);
            Assert.AreEqual('a', fuenteLocal.Cotizaciones[0].Resultado);
        }
    }
}