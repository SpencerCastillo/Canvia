using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRHHMethods
{
    public class LeerReader
    {
        public static T getCampoReader<T>(SqlDataReader dr, string nombreCampo, T porDefecto)
        {
            return (T)(dr.IsDBNull(dr.GetOrdinal(nombreCampo)) ? porDefecto : dr[nombreCampo]);
        }

        public static T getCampoReader<T>(Task<SqlDataReader> dr, string nombreCampo, T porDefecto)
        {
            return (T)(dr.Result.IsDBNull(dr.Result.GetOrdinal(nombreCampo)) ? porDefecto : dr.Result[nombreCampo]);
        }
        
    }
}
