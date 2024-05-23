using LayoutValidator.CustomRuleTemplate;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegrasLV
{
    public class ValidarValorLiquidoStateful : ICustomCode
    {
        public CustomCodeReturn PerformCustomCode(CustomRuleParameter lineValues, Dictionary<string, object> publicSession, Dictionary<string, object> privateSession, int lineNumber, int lineCount, string layoutName)
        {
            try
            {
                if (!privateSession.ContainsKey("TOTAL_VLRLIQUIDO"))
                    privateSession.Add("TOTAL_VLRLIQUIDO", 0);

                if (layoutName.ToUpper() == "DETALHES")
                {
                    var vlrLiquido = double.Parse(lineValues.FieldValue["VALOR LIQUIDO"].ToString()); //pega o valor da linha
                    var totalVlrLiquido = double.Parse(privateSession["TOTAL_VLRLIQUIDO"].ToString());
                    

                    privateSession["TOTAL_VLRLIQUIDO"] = totalVlrLiquido + vlrLiquido;

                }
                if (layoutName.ToUpper() == "TRAILER")
                {
                    var totalVlrLiquido = double.Parse(lineValues.FieldValue["TOTAL VALOR LIQUIDO"].ToString());
                    var totalLiquidoSomatoria = double.Parse(privateSession["TOTAL_VLRLIQUIDO"].ToString());

                    if(totalVlrLiquido != totalLiquidoSomatoria)
                    {
                        return new CustomCodeReturn(false, $"O valor do campo Total Valor Liquido difere do resultado da somatória. Esperado: {totalVlrLiquido}, Encontrado: {totalLiquidoSomatoria}");
                    }
                   
                }
                return new CustomCodeReturn(true, "");
            }
            catch (Exception ex )
            {

                return new CustomCodeReturn(false, $"Erro ao executar o teste, Ex.{ex.Message}");
            }
        }
    }
}
    
       
			

