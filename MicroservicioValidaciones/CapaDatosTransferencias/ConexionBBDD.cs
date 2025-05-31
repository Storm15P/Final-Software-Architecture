using LogicaNegocio;
using Microsoft.Data.SqlClient;

namespace CapaDatosTransferencias
{
    public class ConexionBBDD : IFuenteDatosLocal
    {
        private readonly SqlConnection conexion;

        public ConexionBBDD()
        {
            conexion = new SqlConnection(@"TrustServerCertificate=true;Password=sa!;Persist Security Info=True;User ID=sa;Initial Catalog=MS_Validaciones;Data Source=LENOVOSW\SQLEXPRESS");
        }

        public bool GuardarCotizacion(CotizacionDTO cotizacion)
        {
            conexion.Open();
            string insert = "INSERT INTO cotizacion (placa, ccCliente, resultado) VALUES (@Placa, @CcCliente, @Resultado)";
            SqlCommand command = new SqlCommand(insert, conexion);
            command.Parameters.AddWithValue("@Placa", cotizacion.Placa);
            command.Parameters.AddWithValue("@CcCliente", cotizacion.CcCliente);
            command.Parameters.AddWithValue("@Resultado", cotizacion.Resultado);
            int rows = command.ExecuteNonQuery();
            conexion.Close();
            return rows > 0;
        }
    }
}