using Microsoft.Extensions.Configuration;
using PRUEBABussines.Cliente;
using PRUEBAEntity;
using PRUEBAImplementacion.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Cors;
using System.Web.Http;
namespace PRUEBAService.Controllers
{

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ClienteController : ApiController
    {
        //public readonly IConfiguration Configuration;


    
        [HttpGet]
        public ClienteResponse ObtenerClientePorId(int inIdCliente, int inCodUsuario_Aud)
        {
            var respuesta = new BL_Cliente().ObtenerCliente(inIdCliente, inCodUsuario_Aud);
            return respuesta;
        }

        [HttpPost]
        public ClienteResponse ListarCliente(FilterCliente filter)
        {
            var respuesta = new BL_Cliente().ListarCliente(filter);
            return respuesta;
        }

        [HttpPost]
        public ClienteResponse CreateUpdate(ClienteRequest cliente)
        {
            var respuesta = new BL_Cliente().CreateUpdateCliente(cliente);
            return respuesta;
        }

        [HttpPut]
        public ClienteResponse AnularCliente(ClienteRequest request)
        {
            var respuesta = new BL_Cliente().AnularCliente(request);
            return respuesta;
        }

        [HttpGet]
        public ClienteResponse ListosTodosClientes( int inCodUsuario_Aud)
        {
            var respuesta = new BL_Cliente().ListarTodosClientes( inCodUsuario_Aud);
            return respuesta;
        }

        [HttpDelete]
        public ClienteResponse EliminarCliente(int inIdCliente,int inCodUsuario_Aud)
        {
            var respuesta = new BL_Cliente().EliminarCliente(inIdCliente, inCodUsuario_Aud);
            return respuesta;
        }

    }
}
