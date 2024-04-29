using LayoutValidator.CustomRuleTemplate;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.ConstrainedExecution;
using System.Text;

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
                if (layoutName.ToUpper() == "Header")
                {
                    var qtdRegistroLote = double.Parse(privateSession["Quantidade de registros lote"].ToString());
                }
                if (layoutName.ToUpper() == "Trailer")
                {
                    var qtdRegistro = double.Parse(privateSession["Quantidade de registros"].ToString());
                }
                
			}
			catch (Exception ex)
			{

				return new CustomCodeReturn(false,$"Erro ao validar o arquivo{ex.Message}");
			}
        }
    }
}
