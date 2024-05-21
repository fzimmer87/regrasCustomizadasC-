using LayoutValidator.CustomRuleTemplate;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegrasLV
{
    //O campo Data Vencimento Lote não deve ter seu valor menor que o dos campos Data de Geração Lote e Data Processamento Lote
    // Data Vencimento Lote -> Trailer
    //Geração Lote e Data do Processamento -> Boleto Bancário
    public class R015_DataVencimentoLote : ICustomCode
    {
        public CustomCodeReturn PerformCustomCode(CustomRuleParameter lineValues, Dictionary<string, object> publicSession, Dictionary<string, object> privateSession, int lineNumber, int lineCount, string layoutName)
        {
            try
            { if (!privateSession.ContainsKey("Vencimento do Lote"))
                    privateSession.Add("Vencimento do Lote", 0);

              if (!privateSession.ContainsKey("Data do Documento"))
                    privateSession.Add("Data do Documento", 0);

              if (!privateSession.ContainsKey("Data do Processamento"))
                    privateSession.Add("Data do Processamento", 0);
              


                if (layoutName.ToUpper() == "TRAILER")
                {
                    if (!DateTime.TryParseExact(lineValues.FieldValue["VENCIMENTO DO LOTE"].ToString(), "MM/yy", null, System.Globalization.DateTimeStyles.None, out DateTime dataVencimentoLote))
                        return new CustomCodeReturn(false, $"Valor do campo data não segue formato correto"); //peguei a linha
                    privateSession["Vencimento do Lote"] = dataVencimentoLote; //salvei o valor da linha no privateSession

                }
                if (layoutName.ToUpper() == "BOLETO BANCÁRIO")
                {
                    if (!DateTime.TryParseExact(lineValues.FieldValue["DATA DO DOCUMENTO"].ToString(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime dataDocumento))
                        return new CustomCodeReturn(false, $"Valor campo data não segue formato correto"); //Peguei a linha
                    privateSession["Data do Documento"] = dataDocumento; //salvei o valor da linha no privateSession

                    if (!DateTime.TryParseExact(lineValues.FieldValue["DATA DO PROCESSAMENTO"].ToString(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime dataProcessamento))
                        return new CustomCodeReturn(false, $"Valor campo data não segue formato correto");
                    privateSession["Data do Processamento"]= dataProcessamento; //salvei o valor da linha no privateSession
                }
                //Salvei o valor da privateSession nas seguintes variáveis
                var dataVencimentoLotevar = DateTime.Parse(privateSession["Vencimento do Lote"].ToString());
                var dataDocumentovar = DateTime.Parse(privateSession["Data do Documento"].ToString());
                var dataProcessamentovar = DateTime.Parse(privateSession["Data do Processamento"].ToString());

                if (dataVencimentoLotevar >= dataDocumentovar && dataVencimentoLotevar >= dataProcessamentovar)
                {
                    return new CustomCodeReturn(true, "");
                }
                return new CustomCodeReturn(false, "Data do Vencimento do Lote deve ser menor que Data do Documento e Menor que Data de Processamento");

            }
            catch (Exception ex)
            {

               return new CustomCodeReturn(false,$"Erro ao executar a regra: {ex.Message}");
            }
        }
    }
}
