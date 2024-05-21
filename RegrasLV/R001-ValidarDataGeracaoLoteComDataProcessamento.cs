using LayoutValidator.CustomRuleTemplate;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegrasLV
{
    //O campo Data Geração do Lote deve ser igual ao campo Data Processamento Lote
    //Criar variável Geração do lote e Data Processamento do lote
    //Se for igual geração do lote e processamento -> teste passou
    public class ValidarDataGeracaoLoteComDataProcessamento : ICustomRule
    {
        public CustomRuleReturn PerformCustomRule(CustomRuleParameter lineValues)
        {
            try
            {
                if (!DateTime.TryParseExact(lineValues.FieldValue["DATA GERAÇÃO LOTE"].ToString(), "ddMMyyyy", null, System.Globalization.DateTimeStyles.None, out DateTime geracaoDoLote))
                    return new CustomRuleReturn(false, $"Valor campo data geração não segue formato correto");
               if (!DateTime.TryParseExact(lineValues.FieldValue["DATA PROCESSAMENTO LOTE"].ToString(), "ddMMyyyy", null, System.Globalization.DateTimeStyles.None, out DateTime dataProcessamento))
                    return new CustomRuleReturn(false, $"Valor campo data processamento não segue formato correto");

                if (geracaoDoLote == dataProcessamento)
                {
                    return new CustomRuleReturn(true, "");
                }

                return new CustomRuleReturn(false, $"Data geração de lote {geracaoDoLote}, não corresponde com data de processamento de lote {dataProcessamento}");
            }
            catch (Exception ex)
            {
                return new CustomRuleReturn(false, $"Erro ao executar a regra.Ex:{ex.Message}");
                
            }
        }
    }
}
