using Microsoft.Extensions.Configuration;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRUEBAData.Cliente;
using PRUEBAImplementacion;
using PRUEBAImplementacion.Cliente;

namespace PRUEBABussines.Cliente
{
    public class BL_Cliente
    {
       

        public ClienteResponse CreateUpdateCliente(ClienteRequest request)
        {
            return new DA_Cliente().CreateUpdateCliente(request);
        }

        public ClienteResponse AnularCliente(ClienteRequest request)
        {
            return new DA_Cliente().AnularCliente(request);
        }

        public ClienteResponse ListarCliente(FilterCliente filter)
        {
            return new DA_Cliente().ListarCliente(filter);
        }

        public ClienteResponse ObtenerCliente(int inIdCliente, int inCodUsuario_Aud)
        {
            return new DA_Cliente().ObtenerCliente(inIdCliente, inCodUsuario_Aud);
        }

        public ClienteResponse ListarTodosClientes( int inCodUsuario_Aud)
        {
            return new DA_Cliente().ListarTodosClientes( inCodUsuario_Aud);
        }

        public ClienteResponse EliminarCliente(int inIdCliente, int inCodUsuario_Aud)
        {
            return new DA_Cliente().EliminarCliente( inIdCliente, inCodUsuario_Aud);
        }

    }
}
