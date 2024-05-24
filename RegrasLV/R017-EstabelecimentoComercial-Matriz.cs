using LayoutValidator.CustomRuleTemplate;
using System;
using System.Collections.Generic;

namespace RegrasLV
{
    //O campo Estabelecimento Comercial deve ter seu valor associado a uma única matriz em todo o lote. Uma matriz pode ser associada a múltiplos estabelecimentos comerciais
    // Transações de Cartão-->Campos:
    // Estabelecimento Comercial e Número da Matriz
    //Regra não deixa ter numeros de matrizes repetidas associadas a estabelecimento comercial
    public class R017_EstabelecimentoComercial_Matriz : ICustomCode
    {
        public CustomCodeReturn PerformCustomCode(CustomRuleParameter lineValues, Dictionary<string, object> publicSession, Dictionary<string, object> privateSession, int lineNumber, int lineCount, string layoutName)
        {

            // Estabelecimento Comercial (EC) => Como se fosse um número de telefone, só pode estar vinculado a um CPF (Matriz) em todo o arquivo;
            // Número da Matriz => Como se fosse um CPF, pode possuir vários números (ECs) associados a ela.
            try
            {
                if (layoutName.ToUpper() == "TRANSAÇÕES DE CARTÃO")
                {
                    string estabComercial = lineValues.FieldValue["ESTABELECIMENTO COMERCIAL"].ToString();
                    string numMatriz = lineValues.FieldValue["NÚMERO DA MATRIZ"].ToString();

                    // Verifica se o número da matriz já está associado a algum estabelecimento comercial (EC)
                    if (privateSession.ContainsValue(numMatriz))
                    {
                        // Verifica se o estabelecimento comercial (EC) já está associado à matriz
                        if (privateSession.ContainsValue(estabComercial))
                        {
                            return new CustomCodeReturn(false, $"O estabelecimento comercial {estabComercial} já está associado a uma matriz.");
                        }
                        else
                        {
                            return new CustomCodeReturn(true, "");
                        }
                    }
                    else
                    {
                        // Adiciona o número da matriz e o estabelecimento comercial (EC) associado a ela
                        privateSession.Add(estabComercial, numMatriz);
                    }
                }

                return new CustomCodeReturn(true, "");
            }
            catch (Exception ex)
            {
                return new CustomCodeReturn(false, $"Erro na compilação da regra: {ex.Message}");
            }

        }
    }
}

