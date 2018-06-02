using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VitrinniManager.Compartilhado.Common.Replace
{
    class StringReplace
    {
        public static string Replace(string campo)
        {
            return campo.Replace(".", "")
                        .Replace("-", "")
                        .Replace("(", "")
                        .Replace(")", "")
                        .Replace("_", "")
                        .Replace(" ", "");
        }
    }
}
