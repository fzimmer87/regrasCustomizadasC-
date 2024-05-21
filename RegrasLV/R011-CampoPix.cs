using LayoutValidator.CustomRuleTemplate;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegrasLV
{
    //O campo ID PIX deve ser único em todo o lote
    public class R011_CampoPix : ICustomCode
    {
        public CustomCodeReturn PerformCustomCode(CustomRuleParameter lineValues, Dictionary<string, object> publicSession, Dictionary<string, object> privateSession, int lineNumber, int lineCount, string layoutName)
        {
			try
			{
                if (layoutName.ToUpper() == "TRANSAÇÕES PIX")
                {
                    var idLPix = lineValues.FieldValue["ID PIX"].ToString(); //pego o valor da linha "Número Identificador Lote"

                    if (!privateSession.ContainsKey(idLPix)) //se a lista não contiver o numero que peguei da linha "Número Identificador Lote"
                    {
                        privateSession.Add(idLPix, ""); // adicione o valor (123456-é valor de idLote)
                        return new CustomCodeReturn(true, "");
                    }
                }
                return new CustomCodeReturn(false, " O número do Identificador deve ser único no lote ");



            }
			catch (Exception ex )
			{

                return new CustomCodeReturn(false, $"Erro ao validar o arquivo{ex.Message}");
            }
        }
    }
}
