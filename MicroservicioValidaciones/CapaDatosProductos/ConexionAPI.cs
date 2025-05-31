using System.Net;
using System.Text.Json.Serialization;
using LogicaNegocio;
using Newtonsoft.Json;

namespace CapaDatosFasecolda
{
    public class ConexionAPI : IFuenteDatosFasecolda
    {
        public AccidenteResponseDTO ObtenerAccidentes(string placa)
        {
            string url = $"http://localhost:5041/api/Fasecolda/{placa}";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            try
            {
                using WebResponse response = request.GetResponse();
                using Stream stream = response.GetResponseStream();
                using StreamReader reader = new StreamReader(stream);
                string respuesta = reader.ReadToEnd();

                
                return JsonConvert.DeserializeObject<AccidenteResponseDTO>(respuesta);
            }
            catch
            {
                return new AccidenteResponseDTO(); 
            }
        }
    }
}