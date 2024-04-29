using LayoutValidator.CustomRuleTemplate;
using System;
using System.Collections.Generic;
using System.Text;

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

                if (!string.IsNullOrWhiteSpace(lineValues.FieldValue["Descontos/Abatimentos"].ToString()) &&
                !string.IsNullOrWhiteSpace(lineValues.FieldValue["Juros/Multa"].ToString()) &&
                !string.IsNullOrWhiteSpace(lineValues.FieldValue["Valor do Documento"].ToString()))
                {
                    if (string.IsNullOrWhiteSpace(lineValues.FieldValue["Valor cobrado"].ToString()))
                    {
                        return new CustomRuleReturn(false, "Valor cobrado precisa estar preenchido");
                    }
                    var valorDocumento = double.Parse(lineValues.FieldValue["Valor do Documento"].ToString());
                    var valorJurosMulta = double.Parse(lineValues.FieldValue["Juros/Multa"].ToString());
                    var valorDescontosAbatimentos = double.Parse(lineValues.FieldValue["Descontos/Abatimentos"].ToString());
                    var valorCobrado = double.Parse(lineValues.FieldValue["Valor cobrado"].ToString());
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
