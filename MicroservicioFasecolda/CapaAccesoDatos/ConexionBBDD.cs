using CapaNegocio;
using Microsoft.Data.SqlClient;

namespace CapaAccesoDatos
{
    public class ConexionBBDD : FuenteDatos
    {
        private readonly SqlConnection conexion;

        public ConexionBBDD()
        {
            conexion = new SqlConnection(@"TrustServerCertificate=true;Password=sa!;Persist Security Info=True;User ID=sa;Initial Catalog=MS_Fasecolda;Data Source=LENOVOSW\SQLEXPRESS");
        }

        public List<AccidenteDTO> ConsultarAccidentesPorPlaca(string placa)
        {
            conexion.Open();
            string query = "SELECT * FROM accidentes WHERE placa = @Placa";
            SqlCommand command = new SqlCommand(query, conexion);
            command.Parameters.AddWithValue("@Placa", placa);

            SqlDataReader reader = command.ExecuteReader();
            List<AccidenteDTO> accidentes = new List<AccidenteDTO>();

            while (reader.Read())
            {
                accidentes.Add(new AccidenteDTO
                {
                    IdAccidente = reader.GetInt32(0),
                    Placa = reader.GetString(1).Trim(),
                    Fecha = reader.GetDateTime(2),
                    Severidad = reader.GetString(3)
                });
            }

            conexion.Close();
            return accidentes;
        }
    }
}