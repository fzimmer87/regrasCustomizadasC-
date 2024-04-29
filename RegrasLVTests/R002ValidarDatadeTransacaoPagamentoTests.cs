using LayoutValidator.CustomRuleTemplate;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegrasLV;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegrasLVTests
{
    [TestClass]
    public class R002ValidarDatadeTransacaoPagamentoTests
    {
        [TestMethod]
        public void ValidarDataTransacaoEPagamentoCorretos()
        {
            R002_DataTransacaoDataPagamento regra = new R002_DataTransacaoDataPagamento();
            CustomRuleParameter param = new CustomRuleParameter();
            param.FieldValue = new Dictionary<string, string>();
            param.FieldValue.Add("Data da Transação", "20/02/2024");
            param.FieldValue.Add("Data do pagamento", "20/01/2024");
            Assert.IsTrue(regra.PerformCustomRule(param).TestResult);
        }
        
    }
}
