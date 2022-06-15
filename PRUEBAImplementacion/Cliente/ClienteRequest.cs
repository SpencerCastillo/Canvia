using PRUEBAEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRUEBAImplementacion.Cliente
{
    public class ClienteRequest
    {
        public  BE_MAE_CLIENTE Cliente { get; set; }
    }

    public class ClienteResponse
    {
        public BE_MAE_CLIENTE Cliente { get; set; }
        public List<BE_MAE_CLIENTE> Clientes { get; set; }
        public int Total { get; set; }
        public string vcMensaje { get; set; }
        public string vcStatus { get; set; }
        public int inCodigoRespuesta { get; set; }
        public int inIdGenerado { get; set; }
    }

    public class FilterCliente
    {
        public string vcNumeroDocumento { set; get; }

        public string nvNombres { set; get; }
        public string vcEstado { set; get; }

        public int pageIndex { set; get; }

        public int pageSize { set; get; }

        public int inCodUsuario_Aud { get; set; }

        public bool biNoEliminadoLogicoBD { set; get; }
    }
    
}
