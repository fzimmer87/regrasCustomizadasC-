﻿using LayoutValidator.CustomRuleTemplate;
using System;


namespace RegrasLV
{
    //O campo Valor Líquido deve ter seu valor correspondente ao campo Valor Bruto - Desconto
    // Verificar se o valor presente no campo "Valor Liquido" corresponde ao resultado do cálculo 
    // Valor Líquido = Valor Bruto - Valor da taxa
    public class R004_ValorLiquido : ICustomRule
    {
        public CustomRuleReturn PerformCustomRule(CustomRuleParameter lineValues)
        {
			try
			{
                var valorBruto = double.Parse(lineValues.FieldValue["Valor_Bruto"].ToString());
                var desconto = double.Parse(lineValues.FieldValue["Desconto"].ToString());
                var valorLiqudo = double.Parse(lineValues.FieldValue["Valor_Liquido"].ToString());
                

                var resultado = valorBruto - desconto;
                if (valorLiqudo == resultado)
                {
                    return new CustomRuleReturn(true, "Valor correto");
                }
                 
                    return new CustomRuleReturn(false, $"Valor do campo Liquido não é igual o cálculo do resultado. Valor esperado: {valorLiqudo}. Valor encontrado: {resultado}");
         
            }
            catch (Exception ex)
            {

                return new CustomRuleReturn(false, $"Erro ao executar a regra customizada. Ex. {ex.Message}");
            }
        }
    }
}

