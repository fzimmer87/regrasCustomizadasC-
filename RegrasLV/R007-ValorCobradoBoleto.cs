using LayoutValidator.CustomRuleTemplate;
using System;

namespace RegrasLV
{
    //O campo Valor Cobrado deve ser preenchido caso os campos Descontos/Abatimentos e Juros/Multa tenham seus valores diferentes de branco
    // Valor cobrado = Valor do documento - Descontos/Abatimento + Juros/Multa
    public class R007_ValorCobradoBoleto : ICustomRule
    {
        public CustomRuleReturn PerformCustomRule(CustomRuleParameter lineValues)
        {

            try
            {
                // IsNullOrWhiteSpace -> se não estiver em branco

                if (!string.IsNullOrWhiteSpace(lineValues.FieldValue["DESCONTOS/ABATIMENTOS"].ToString()) &&
                !string.IsNullOrWhiteSpace(lineValues.FieldValue["JUROS/MULTA"].ToString()) &&
                !string.IsNullOrWhiteSpace(lineValues.FieldValue["VALOR DO DOCUMENTO"].ToString()))
                {
                    if (string.IsNullOrWhiteSpace(lineValues.FieldValue["VALOR COBRADO"].ToString()))
                    {
                        return new CustomRuleReturn(false, "Valor cobrado precisa estar preenchido");
                    }
                    var valorDocumento = double.Parse(lineValues.FieldValue["VALOR DO DOCUMENTO"].ToString());
                    var valorJurosMulta = double.Parse(lineValues.FieldValue["JUROS/MULTA"].ToString());
                    var valorDescontosAbatimentos = double.Parse(lineValues.FieldValue["DESCONTOS/ABATIMENTOS"].ToString());
                    var valorCobrado = double.Parse(lineValues.FieldValue["VALOR COBRADO"].ToString());
                    var resultado = valorDocumento - valorDescontosAbatimentos + valorJurosMulta;


                    if (valorCobrado == resultado)
                    {
                        return new CustomRuleReturn(true, "");
                    }


                }
                return new CustomRuleReturn(false, $"Valor cobrado não está correto");
            }
            catch (Exception ex)
            {

                return new CustomRuleReturn(false, $"Erro ao executar o teste, Ex.{ex.Message}");
            }
        }
    }
}
