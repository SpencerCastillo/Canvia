using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRUEBAEntity
{
    public class BE_TAB_AUDITORIA
    {
        public bool biNoEliminadoLogicoBD { set; get; }
        public int inCodUsuario_Aud { get; set; }
        public string vcNomSistemaOperacion_Aud { get; set; }
        public string vcModuloSistema_Aud { get; set; }
        public string vcNomTerminalRegistro_Aud { get; set; }
        public string vcIPTerminalRegistro_Aud { get; set; }

       
    }
}
