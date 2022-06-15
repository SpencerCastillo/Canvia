using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using PRUEBABussines.Item;
using PRUEBAEntity;
using PRUEBAImplementacion.Item;
namespace PRUEBAService.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ItemController : ApiController
    {
        [HttpGet]
        public ItemResponse ObtenerItemPorId(int inIdItem, int inCodUsuario_Aud)
        {
            var respuesta = new BL_Item().ObtenerItem(inIdItem, inCodUsuario_Aud);
            return respuesta;
        }

        [HttpPost]
        public ItemResponse ListarItem(FilterItem filter)
        {
            var respuesta = new BL_Item().ListarItem(filter);
            return respuesta;
        }

        [HttpPost]
        public ItemResponse CreateUpdate(ItemRequest item)
        {
            var respuesta = new BL_Item().CreateUpdateItem(item);
            return respuesta;
        }

        [HttpPut]
        public ItemResponse AnularItem(ItemRequest request)
        {
            var respuesta = new BL_Item().AnularItem(request);
            return respuesta;
        }

        [HttpGet]
        public ItemResponse ListosTodosItem(int inCodUsuario_Aud)
        {
            var respuesta = new BL_Item().ListarTodosItem(inCodUsuario_Aud);
            return respuesta;
        }

        [HttpDelete]
        public ItemResponse EliminarItem(int inIdItem, int inCodUsuario_Aud)
        {
            var respuesta = new BL_Item().EliminarItem(inIdItem, inCodUsuario_Aud);
            return respuesta;
        }

    }
}
