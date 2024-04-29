using LayoutValidator.CustomRuleTemplate;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegrasLV;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegrasLVTests
{
    [TestClass]
    public class R003_CodigoProdutoBandeiraTests
    {
        [TestMethod]
        public void ValoresCorrespondentes()
        {
            R003_CodigoProdutoBandeira regra = new R003_CodigoProdutoBandeira();
            CustomRuleParameter param = new CustomRuleParameter();
            param.FieldValue = new Dictionary<string, string>();
            param.FieldValue.Add("Código do Produto", "001");
            param.FieldValue.Add("Código da Bandeira", "001");
            Assert.IsTrue(regra.PerformCustomRule(param).TestResult);

        }
        [TestMethod]
        public void ValoresNaoCorrespondentes()
        {
            R003_CodigoProdutoBandeira regra = new R003_CodigoProdutoBandeira();
            CustomRuleParameter param = new CustomRuleParameter();
            param.FieldValue = new Dictionary<string, string>();
            param.FieldValue.Add("Código do Produto", "002");
            param.FieldValue.Add("Código da Bandeira", "001");
            Assert.IsFalse(regra.PerformCustomRule(param).TestResult);

        }
        [TestMethod]
        public void ValoresComCaracteres()
        {
            R003_CodigoProdutoBandeira regra = new R003_CodigoProdutoBandeira();
            CustomRuleParameter param = new CustomRuleParameter();
            param.FieldValue = new Dictionary<string, string>();
            param.FieldValue.Add("Código do Produto", "00A");
            param.FieldValue.Add("Código da Bandeira", "00A");
            Assert.IsFalse(regra.PerformCustomRule(param).TestResult);

        }
    }
}
