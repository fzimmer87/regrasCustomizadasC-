using LayoutValidator.CustomRuleTemplate;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegrasLV
{
    public class R016_QuantidadeDeRegistrosXPTO : ICustomCode
    {
        //O campo Quantidade de Registros Lote deve ser correspondente a quantidade de transações presentes no lote (excluindo trailer)
		// Só existe um campo no arquivo inteiro de Quantidade -> Header
        public CustomCodeReturn PerformCustomCode(CustomRuleParameter lineValues, Dictionary<string, object> publicSession, Dictionary<string, object> privateSession, int lineNumber, int lineCount, string layoutName)
        {
			try
			{
				if (!privateSession.ContainsKey("Quantidade Registros Lote"))
					privateSession.Add("Quantidade Registros Lote", 0);
						
						
				if(layoutName.ToUpper() == "HEADER")
				{
					var qtdRegistroLote = double.Parse(lineValues.FieldValue["QUANTIDADE REGISTROS LOTE"].ToString());
					privateSession["Quantidade Registros Lote"]= qtdRegistroLote;
				}
				if (layoutName.ToUpper() == "TRAILER")
				{
					var qtdRegistroTrailer = double.Parse(lineValues.FieldValue["QUANTIDADE DE REGISTROS"].ToString());
					var qtdRegistroLoteHeader = double.Parse(privateSession["Quantidade Registros Lote"].ToString());

					if(qtdRegistroTrailer != qtdRegistroLoteHeader)
					{
						return new CustomCodeReturn(false, $"Valores Quantidade Registro Lote ({qtdRegistroTrailer}) e Quantidade Registro({qtdRegistroLoteHeader}) não são iguais");
					}
				}
				return new CustomCodeReturn(true,"");
			}
			catch (Exception ex)
			{

				return new CustomCodeReturn(false,$"Erro ao executar o código: {ex.Message}");
			};
        }
    }
}
