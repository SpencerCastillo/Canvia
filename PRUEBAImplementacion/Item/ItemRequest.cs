using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRUEBAEntity;
namespace PRUEBAImplementacion.Item
{
    public class ItemRequest
    {
        public BE_MAE_ITEM  Item { get; set; }

    }

    public class ItemResponse
    {
        public BE_MAE_ITEM Item { get; set; }
        public List<BE_MAE_ITEM> Items { get; set; }
        public int Total { get; set; }
        public string vcMensaje { get; set; }
        public string vcStatus { get; set; }
        public int inCodigoRespuesta { get; set; }
        public int inIdGenerado { get; set; }
    }

    public class FilterItem
    {
        public string vcDescripcionItem { set; get; }
        public int pageIndex { set; get; }

        public int pageSize { set; get; }

        public int inCodUsuario_Aud { get; set; }

        public bool biNoEliminadoLogicoBD { set; get; }
    }
}
