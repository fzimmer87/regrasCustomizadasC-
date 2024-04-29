using LayoutValidator.CustomRuleTemplate;
using System;

namespace RegrasLV { 
	//Validar Valor Liquido,valor da Taxa e valor Bruto
	// Verificar se o valor presente no campo "Valor Liquido" corresponde ao resultado do cálculo 
	// Valor Líquido = Valor Bruto - Valor da taxa

	// ICustomRule => ICustomRule
	// ICustomCode => ICustomCode
    public class ValidarValorLiquido : ICustomRule
    {
        public CustomRuleReturn PerformCustomRule(CustomRuleParameter lineValues)
        {
			try
			{
			var valorBruto = double.Parse(lineValues.FieldValue["Valor_Bruto"].ToString());
            var valorLiqudo = double.Parse(lineValues.FieldValue["Valor_Liquido"].ToString());
            var valorTaxa = double.Parse(lineValues.FieldValue["Valor_Taxa"].ToString());

			var resultado = valorBruto - valorTaxa;
			if (valorLiqudo == resultado) 
			{
				return new CustomRuleReturn(true, "Valor correto");
			}
			else
			{
				return new CustomRuleReturn(false, $"Valor do campo Liquido não é igual o cálculo do resultado. Valor esperado: {valorLiqudo}. Valor encontrado: {resultado}");	
			}
        }
			catch (Exception ex)
			{

				return new CustomRuleReturn(false, $"Erro ao executar a regra customizada. Ex. {ex.Message}");
			}
        }
    }
}
