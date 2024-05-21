using LayoutValidator.CustomRuleTemplate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RegrasLV
{
    //O campo Número do Terminal deve ser composto apenas por zeros caso o campo Geração tenha o valor "TP1"
    public class R013_NumeroDoTerminal_Cartoes : ICustomRule
    {
        public CustomRuleReturn PerformCustomRule(CustomRuleParameter lineValues)
        {
            try
            {
                var numTerminal = lineValues.FieldValue["NÚMERO DO TERMINAL"].ToString();
                var geracao = lineValues.FieldValue["GERAÇÃO"].ToString();

                if (geracao == "TP1")
                {
                    if (!numTerminal.All(c => c == '0'))
                    {
                        return new CustomRuleReturn(false, "O campo Número do Terminal deve ser composto apenas por zeros quando o campo Geração tiver o valor 'TP1'.");
                    }
                    else 
                    {
                        
                        if (numTerminal.All(c => c != '0'))
                        {
                            return new CustomRuleReturn(false, "O campo Número do Terminal deve ser diferente de zeros quando o campo Geração tiver um valor diferente de 'TP1'.");
                        }
                    }
                }
                return new CustomRuleReturn(true, "");
            }
            catch (Exception ex)
            {

                return new CustomRuleReturn(false,$"Erro ao executar o código: {ex.Message}");
            }
        }
    }
}
