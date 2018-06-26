namespace VitrinniManager.Common.Replace
{
    public class StringReplace
    {
        public static string Replace(string campo)
        {
            string retorno = string.Empty;
            if (!string.IsNullOrEmpty(campo))
            {
                retorno = campo.Replace(".", "")
                       .Replace("-", "")
                       .Replace("(", "")
                       .Replace(")", "")
                       .Replace("_", "")
                       .Replace(" ", "");

            }
            return retorno;
        }
    }
}
