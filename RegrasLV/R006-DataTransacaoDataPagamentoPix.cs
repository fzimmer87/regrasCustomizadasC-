using LayoutValidator.CustomRuleTemplate;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegrasLV
{
    public class R006_DataTransacaoDataPagamentoPix : ICustomRule
    {
        //O campo Data do Pagamento não deve ter seu valor menor que o valor do campo Data da Transação
        public CustomRuleReturn PerformCustomRule(CustomRuleParameter lineValues)
        {
			try
			{
				if (!DateTime.TryParseExact(lineValues.FieldValue["DATA DO PAGAMENTO"].ToString(), "ddMMyyyy", null, System.Globalization.DateTimeStyles.None, out DateTime dataPagamento)) 
					return new CustomRuleReturn(false, "Valor campo Data de Pagamento não segue formato correto");
                if (!DateTime.TryParseExact(lineValues.FieldValue["DATA DA TRANSAÇÃO"].ToString(), "ddMMyyyy", null, System.Globalization.DateTimeStyles.None, out DateTime dataTransacao))
                    return new CustomRuleReturn(false, "Valor campo Data da Transação não segue formato correto");
                if (dataPagamento >= dataTransacao)
                {
                    return new CustomRuleReturn(true, "");
                }
                return new CustomRuleReturn(false, "Data de Pagamento é menor que valor do campo Data de Transação");
            }
			catch (Exception ex)
			{

				return new CustomRuleReturn(false, $"Erro ao executar a regra.Ex:{ex.Message}");
			}
        }
    }
}
