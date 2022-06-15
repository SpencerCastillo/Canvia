using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRUEBAEntity
{
    public class BE_MAE_ITEM :BE_TAB_AUDITORIA
    {
        public int inIdItem { set; get; }


        public string  vcDescripcionItem { set; get; }

        public decimal dePrecio { set; get; }

        public int  inStockMinimo { set; get; }

        public int inRowCount { set; get; }

        public Int64 inRowIndex { set; get; }

    }
}
