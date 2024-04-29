using LayoutValidator.CustomRuleTemplate;
using System;


namespace RegrasLV
{
    //O campo Código do Produto deve ter seu valor coerente com o valor do campo Código da Bandeira
    public class R003_CodigoProdutoBandeira : ICustomRule
    {
        public CustomRuleReturn PerformCustomRule(CustomRuleParameter lineValues)
        {
            try
            {
                var codigoProduto = double.Parse(lineValues.FieldValue["Código do Produto"].ToString());
                var codigoBandeira = double.Parse(lineValues.FieldValue["Código da Bandeira"].ToString());
                if (codigoBandeira == codigoProduto)
                {
                    return new CustomRuleReturn(true, "");
                }
                else
                {
                    return new CustomRuleReturn(false, "Valores não correspondem");
                }
            }
            catch (Exception ex)
            {
                return new CustomRuleReturn(false, $"Erro ao executar a regra customizada. Ex. {ex.Message}");

            }
           
        }
    }
}

