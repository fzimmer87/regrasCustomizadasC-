using LayoutValidator.CustomRuleTemplate;
using System;
using System.Collections.Generic;

namespace RegrasLV
{
    //O campo Quantidade de Registros deve ter seu valor igual ao do campo Quantidade de Registros Lote
    //Quantidade de registros lote => Header
    //Quantidade de registros => Trailer
    public class R009_QuantidadeRegistrosLote : ICustomCode
    {
        public CustomCodeReturn PerformCustomCode(CustomRuleParameter lineValues, Dictionary<string, object> publicSession, Dictionary<string, object> privateSession, int lineNumber, int lineCount, string layoutName)
        {
            try
            {

                if (!privateSession.ContainsKey("Quantidade Registro Lote"))
                    privateSession.Add("Quantidade Registro Lote", 0);

                if (layoutName.ToUpper() == "HEADER")
                {
                    var quantidadeRegistro = double.Parse(lineValues.FieldValue["QUANTIDADE REGISTRO LOTE"].ToString());
                    var totalRegistroHeader = double.Parse(privateSession["QUANTIDADE REGISTRO LOTE"].ToString());

                    privateSession["Quantidade Registro Lote"] = quantidadeRegistro + totalRegistroHeader;
                }
                if (layoutName.ToUpper() == "TRAILER")
                {
                    var quantidadeRegistro = double.Parse(lineValues.FieldValue["QUANTIDADE DE REGISTROS"].ToString());
                    var totalRegistroSomatoria = double.Parse(privateSession["Quantidade Registro Lote"].ToString());
                    if (quantidadeRegistro != totalRegistroSomatoria)
                    {
                        return new CustomCodeReturn(false, $"Valor de Quantidade Registro Lote do layout Header: {quantidadeRegistro} não corresponde com Quantidade de Registros do layout Trailer: {totalRegistroSomatoria}");

                    }

                }
                return new CustomCodeReturn(true, "");

            }
            catch (Exception ex)
            {

                return new CustomCodeReturn(false, $"Erro ao validar o arquivo{ex.Message}");
            }
        }
    }
}
