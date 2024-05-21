using LayoutValidator.CustomRuleTemplate;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegrasLV
{
    //Transação de Cartões - Valor Líquido
    //O campo Valor Líquido deve ter seu valor correspondente ao campo Valor Bruto - Desconto.
    //Considerando as casas decimais, caso o 1 dígito seja maior ou igual à 5, arredondar o valor final para cima.
    public class R008_ValorLiquidoCartao : ICustomRule
    {
        public CustomRuleReturn PerformCustomRule(CustomRuleParameter lineValues)
        {
			try
			{
                var valorBruto = double.Parse(lineValues.FieldValue["VALOR BRUTO"].ToString());
                var desconto = double.Parse(lineValues.FieldValue["DESCONTO"].ToString());
                var valorLiquido = double.Parse(lineValues.FieldValue["VALOR LIQUIDO"].ToString());
                var resultado = valorBruto - desconto;

                if ((resultado - Math.Floor(resultado)) >= 0.5)
                {
                    // Arredonda para cima
                    resultado = Math.Ceiling(resultado);
                }

                
                if (valorLiquido == resultado)
                {
                    return new CustomRuleReturn(true, "");
                }
                return new CustomRuleReturn(false, $"Valor liquido: {valorLiquido}, não corresponde com resultado: {resultado}");
            }
			catch (Exception ex)
			{

				return new CustomRuleReturn(false, $"Erro ao executar o teste, Ex.{ex.Message}");
			}
        }
    }
}
