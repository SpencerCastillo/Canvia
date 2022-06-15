using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRUEBAEntity
{
    public class BE_MAE_CLIENTE : BE_TAB_AUDITORIA
    {

        public int inIdCliente { set; get; }

        public string  chTipoPersona { set; get; }

        public string vcNumeroDocumento { set; get; }

        public string nvApellidoPaterno { set; get; }

        public string nvApellidoMaterno { set; get; }

        public string nvNombres { set; get; }

        public string vcRazonSocial { set; get; }

        public string vcEmail { set; get; }

        public string vcDireccion { set; get; }

        public string chSexo { set; get; }

        public int inRowCount { set; get; }

        public Int64 inRowIndex { set; get; }

    }
}
