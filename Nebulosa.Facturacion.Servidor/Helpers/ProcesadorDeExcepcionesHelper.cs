using Microsoft.Data.SqlClient;
using Nebulosa.Facturacion.Compartida.DTO;

namespace Nebulosa.Facturacion.Servidor.Helpers
{
    public class ProcesadorDeExcepcionesHelper<T>
    {
        public static RespuestaAPI<T> ProceseLaExcepcion(Exception exception)
        {
            string mensaje = "";

            if (exception.GetBaseException().GetType() == typeof(SqlException))
            {
                if (exception.InnerException != null)
                {
                    mensaje = ProceseSQLException((SqlException)exception.InnerException);
                }
                else
                {
                    mensaje = "Lo sentimos algo ha  salido mal";
                }
            }

            return new RespuestaAPI<T>(true, mensaje);
        }

        private static string ProceseSQLException(SqlException sqlException)
        {
            int codigoDeError = sqlException.Number;

            switch (codigoDeError)
            {
                case 2601:  // elemento duplicado
                    return "Este elemento ya existe";
                default:
                    return "Lo sentimos algo ha  salido mal";
            }
        }
    }
}
