using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRUEBAData.Item;
using PRUEBAImplementacion;
using PRUEBAImplementacion.Item;
namespace PRUEBABussines.Item
{
    public class BL_Item
    {
        public ItemResponse CreateUpdateItem(ItemRequest request)
        {
            return new DA_Item().CreateUpdateItem(request);
        }

        public ItemResponse AnularItem(ItemRequest request)
        {
            return new DA_Item().AnularItem(request);
        }

        public ItemResponse ListarItem(FilterItem filter)
        {
            return new DA_Item().ListarItem(filter);
        }

        public ItemResponse ObtenerItem(int inIdItem, int inCodUsuario_Aud)
        {
            return new DA_Item().ObtenerItem(inIdItem, inCodUsuario_Aud);
        }

        public ItemResponse ListarTodosItem(int inCodUsuario_Aud)
        {
            return new DA_Item().ListarTodosItems(inCodUsuario_Aud);
        }

        public ItemResponse EliminarItem(int inIdItem, int inCodUsuario_Aud)
        {
            return new DA_Item().EliminarItem(inIdItem, inCodUsuario_Aud);
        }
    }
}
