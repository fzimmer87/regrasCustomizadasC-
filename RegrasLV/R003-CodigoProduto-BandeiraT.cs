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
                int codigoProduto = int.Parse(lineValues.FieldValue["CÓDIGO DO PRODUTO"].ToString().Trim());
                string codigoBandeira = lineValues.FieldValue["CÓDIGO DA BANDEIRA"].ToString().Trim();

                switch (codigoBandeira)
                {
                    case "000": // Elo

                        if (codigoProduto >= 0 && codigoProduto <= 100)
                        {
                            return new CustomRuleReturn(true, "");

                        }
                        else
                        {
                            return new CustomRuleReturn(false, $"Para Elo, o código do produto deve estar entre 0 e 100.");
                        }
                        break;

                    case "001": // Mastercard
                        if (codigoProduto >= 100 && codigoProduto <= 499)
                        {
                            return new CustomRuleReturn(true, "");

                        }
                        else
                        {
                            return new CustomRuleReturn(false, $"Para Mastercard, o código do produto deve estar entre 100 e 499.");
                        }
                        break;

                    case "002": // Visa

                        if (codigoProduto >= 500 && codigoProduto <= 599)
                        {
                            return new CustomRuleReturn(true, "");

                        }
                        else
                        {
                            return new CustomRuleReturn(false, $"Para Visa, o código do produto deve estar entre 500 e 599.");
                        }
                        break;

                    case "003": // Amex
                        if (codigoProduto >= 600 && codigoProduto <= 610)
                        {
                            return new CustomRuleReturn(true, "");
                        }
                        
                        {
                            return new CustomRuleReturn(false, $"Para Amex, o código do produto deve estar entre 600 e 610.");
                        }
                        break;

                    case "004": // Diners
                        if (codigoProduto >= 620 && codigoProduto <= 650)
                        {
                            return new CustomRuleReturn(true, "");
                        }
                        else
                        {
                            return new CustomRuleReturn(false, $"Para Diners, o código do produto deve estar entre 620 e 650.");
                        }
                        break;


                    default:
                        return new CustomRuleReturn(false, $"Bandeira desconhecida: {codigoBandeira}"); break;

                }

            }
            catch (Exception ex)
            {
                return new CustomRuleReturn(false, $"Erro ao executar a regra: {ex.Message}");
            }

        }
    }
}

