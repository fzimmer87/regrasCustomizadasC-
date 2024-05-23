using LayoutValidator.CustomRuleTemplate;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegrasLV
{
    //O campo Tipo de Transação deve ser coerente com todas as transações presentes no lote; ter uma unica transação no lote
    public class R014_TipoDeTransacaoHeader : ICustomCode
    {
        public CustomCodeReturn PerformCustomCode(CustomRuleParameter lineValues, Dictionary<string, object> publicSession, Dictionary<string, object> privateSession, int lineNumber, int lineCount, string layoutName)
        {
            try
            {
                if (layoutName.ToUpper() == "HEADER")
                {
                    var tipoTransacao = lineValues.FieldValue["TIPO DE TRANSAÇÃO"].ToString(); //pego o valor da linha "Tipo de Transação"

                    if (!privateSession.ContainsKey(tipoTransacao)) //se a lista não contiver o numero que peguei da linha "Tipo de Transação"
                    {
                        privateSession.Add(tipoTransacao, ""); // adicione o valor do campo
                        return new CustomCodeReturn(true, "");
                    }
                }
                return new CustomCodeReturn(false, " O número do Identificador já existe ");
            }
            catch (Exception ex)
            {
                return new CustomCodeReturn(false, $"Erro ao validar o arquivo{ex.Message}");
            }
            
        }
    }
}
