using LayoutValidator.CustomRuleTemplate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace RegrasLV
{
    //O campo Data da Transação não deve ser menor que o campo Data do Pagamento
    //Se a Data da Transação for maior que o campo Data do pagamento, então teste passou
    public class R002_DataTransacaoDataPagamento : ICustomRule
    {
        public CustomRuleReturn PerformCustomRule(CustomRuleParameter lineValues)
        {
            try
            {
                if (!DateTime.TryParseExact(lineValues.FieldValue["DATA DA TRANSAÇÃO"].ToString(), "ddMMyyyy", null, System.Globalization.DateTimeStyles.None, out DateTime dataTransacao))
                    return new CustomRuleReturn(false,"Erro ao compilar a data da transação");

                if (!DateTime.TryParseExact(lineValues.FieldValue["DATA DO PAGAMENTO"].ToString(), "ddMMyyyy", null, System.Globalization.DateTimeStyles.None, out DateTime dataPagamento))
                    return new CustomRuleReturn(false, "Erro ao compilar a data de pagamento");

                if (dataTransacao >= dataPagamento)
                {
                    return new CustomRuleReturn(true, "");
                }

                return new CustomRuleReturn(false, $"Data da transação({dataTransacao}), é menor que a data de pagamento ({dataPagamento})");
            }
            catch (Exception ex)
            {
                return new CustomRuleReturn(false, $"Erro ao executar a regra.Ex:{ex.Message}");

            }
        }
    }
}
