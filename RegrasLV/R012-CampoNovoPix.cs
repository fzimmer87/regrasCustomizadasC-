using LayoutValidator.CustomRuleTemplate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RegrasLV
{
    //O campo Novo ID PIX deve ser composto apenas por zeros caso o campo Reprocessamento tenha seu valor igual a "N". O oposto também deve ser verificado.
    public class R012_CampoNovoPix : ICustomRule
    {
        public CustomRuleReturn PerformCustomRule(CustomRuleParameter lineValues)
        {
            try
            {
                var novoIdPix = lineValues.FieldValue["NOVO ID PIX"].ToString();
                var reprocessamento = lineValues.FieldValue["REPROCESSAMENTO"].ToString();

                // Verifica se o campo Reprocessamento é igual a "N"
                if (reprocessamento == "N")
                {
                    // Verifica se o campo Novo ID PIX não é composto apenas por zeros
                    if (!novoIdPix.All(c => c == '0'))
                    {
                        return new CustomRuleReturn(false, "O campo Novo ID PIX deve ser composto apenas por zeros quando o campo Reprocessamento tiver o valor 'N'.");
                    }
                }
                else // Se o campo Reprocessamento não for "N"
                {
                    // Verifica se o campo Novo ID PIX é composto apenas por zeros
                    if (novoIdPix.All(c => c != '0'))
                    {
                        return new CustomRuleReturn(true, "");
                    }
                    if (novoIdPix.All(c => c == '0'))
                    {
                        return new CustomRuleReturn(false, "Valor deve ser diferente de 0");
                    }
                }
                // Retorna verdadeiro se todas as condições forem atendidas
                return new CustomRuleReturn(true, "");
            }
            catch (Exception ex)
            {

               return new CustomRuleReturn(false, $"Erro ao executar a regra.Ex:{ex.Message}"); 
			}
        }
    }
}
