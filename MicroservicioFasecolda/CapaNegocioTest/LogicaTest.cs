using System.Collections.Concurrent;
using CapaDatosMemoria;
using CapaNegocio;

namespace CapaNegocioTest
{
    [TestClass]
    public class LogicaTest
    {
        private readonly Logica logica = new Logica(new DatosMemoria());

        [TestMethod]
        public void Conteo_PlacaABC123_Retorna1SoloLata1Muerto()
        {
            var response = logica.ObtenerConteoAccidentes("ABC123");
            Assert.AreEqual(1, response.SoloLatas);
            Assert.AreEqual(0, response.Heridos);
            Assert.AreEqual(1, response.Muertos);
        }

        [TestMethod]
        public void Conteo_PlacaXYZ789_Retorna1SoloLata1Herido()
        {
            var response = logica.ObtenerConteoAccidentes("XYZ789");
            Assert.AreEqual(1, response.SoloLatas);
            Assert.AreEqual(1, response.Heridos);
            Assert.AreEqual(0, response.Muertos);
        }

        [TestMethod]
        public void Conteo_PlacaInexistente_RetornaCeros()
        {
            var response = logica.ObtenerConteoAccidentes("INVALID");
            Assert.AreEqual(0, response.SoloLatas);
            Assert.AreEqual(0, response.Heridos);
            Assert.AreEqual(0, response.Muertos);
        }
    }
}