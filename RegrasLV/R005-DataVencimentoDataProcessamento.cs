using LayoutValidator.CustomRuleTemplate;
using System;


namespace RegrasLV
{
    //O campo Data do Vencimento não deve ser menor que o valor do campo Data do Processamento
    public class R005_DataVencimentoDataProcessamento : ICustomRule
    {
        public CustomRuleReturn PerformCustomRule(CustomRuleParameter lineValues)
        {
            try
            {
                if (!DateTime.TryParseExact(lineValues.FieldValue["DATA DE VENCIMENTO"].ToString(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime dataVencimento))
                    return new CustomRuleReturn(false, "Erro ao compilar a data de vencimento");
                if (!DateTime.TryParseExact(lineValues.FieldValue["DATA DO PROCESSAMENTO"].ToString(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime dataProcessamento))
                    return new CustomRuleReturn(false, "Erro ao compilar a data de processamento");
                if (dataVencimento >= dataProcessamento)
                {
                    return new CustomRuleReturn(true, "");
                }
                return new CustomRuleReturn(false, $"Data da transação({dataVencimento}), é menor que a data de pagamento ({dataProcessamento})");
            }
            catch (Exception ex)
            {
                return new CustomRuleReturn(false, $"Erro ao executar a regra.Ex:{ex.Message} ");
               
            }
            
        }
    }
}
