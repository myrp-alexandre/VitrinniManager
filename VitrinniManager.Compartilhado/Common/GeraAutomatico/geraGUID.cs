using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VitrinniManager.Compartilhado.Common.GeraAutomatico
{
    public class geraGUID
    {
        public static Guid NewGuid()
        {
            return Guid.NewGuid();
        }
    }
}
