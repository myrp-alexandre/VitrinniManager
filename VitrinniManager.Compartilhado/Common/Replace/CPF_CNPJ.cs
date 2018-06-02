namespace VitrinniManager.Common.Replace
{
    public class CPF_CNPJ
    {
        public static string Replace(string cpf_cnpj)
        {
            return cpf_cnpj.Replace(".","").Replace("-","").Replace("/","");
        }
    }
}
