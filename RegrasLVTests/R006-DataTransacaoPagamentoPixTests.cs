using LayoutValidator.CustomRuleTemplate;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegrasLV;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegrasLVTests
{
    [TestClass]
    public class R006_DataTransacaoPagamentoPixTests
    {
        [TestMethod]
        public void ValidacaoDataCorreta()
        {
            R006_DataTransacaoDataPagamentoPix regra = new R006_DataTransacaoDataPagamentoPix();
            CustomRuleParameter param = new CustomRuleParameter();
            param.FieldValue = new Dictionary<string, string>();
            param.FieldValue.Add("Data do Pagamento", "02022023");
            param.FieldValue.Add("Data da Transação", "01022023");
            Assert.IsTrue(regra.PerformCustomRule(param).TestResult);
        }
        [TestMethod]
        public void ValidacaoDataIncorreta()
        {
            R006_DataTransacaoDataPagamentoPix regra = new R006_DataTransacaoDataPagamentoPix();
            CustomRuleParameter param = new CustomRuleParameter();
            param.FieldValue = new Dictionary<string, string>();
            param.FieldValue.Add("Data do Pagamento", "01022023");
            param.FieldValue.Add("Data da Transação", "02022023");
            Assert.IsFalse(regra.PerformCustomRule(param).TestResult);
        }
    }
}
