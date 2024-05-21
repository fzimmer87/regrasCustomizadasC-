using LayoutValidator.CustomRuleTemplate;
using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Text;

namespace RegrasLV
{
    //O campo Número Identificador Lote deve ser único em todo o arquivo
    //ID lote-->Header
    public class R010_NumeroIdentificadorDeLote : ICustomCode
    {
        public CustomCodeReturn PerformCustomCode(CustomRuleParameter lineValues, Dictionary<string, object> publicSession, Dictionary<string, object> privateSession, int lineNumber, int lineCount, string layoutName)
        {
            try
            {
                if (layoutName.ToUpper() == "HEADER")
                {
                    var idLote = lineValues.FieldValue["NÚMERO IDENTIFICADOR LOTE"].ToString(); //pego o valor da linha "Número Identificador Lote"

                    if (!privateSession.ContainsKey(idLote)) //se a lista não contiver o numero que peguei da linha "Número Identificador Lote"
                    {
                        privateSession.Add(idLote, ""); // adicione o valor (123456-é valor de idLote)
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
