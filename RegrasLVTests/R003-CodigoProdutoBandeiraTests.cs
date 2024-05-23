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
        public void ValoresCorrespondentesBandeiraElo()
        {
            R003_CodigoProdutoBandeira regra = new R003_CodigoProdutoBandeira();
            CustomRuleParameter param = new CustomRuleParameter();
            param.FieldValue = new Dictionary<string, string>();
            param.FieldValue.Add("CÓDIGO DO PRODUTO", "001");
            param.FieldValue.Add("CÓDIGO DA BANDEIRA", "000");// Bandeira Elo 
            Assert.IsTrue(regra.PerformCustomRule(param).TestResult);

        }
        [TestMethod]
        public void ValoresCorrespondentesBandeiraMaster()
        {
            R003_CodigoProdutoBandeira regra = new R003_CodigoProdutoBandeira();
            CustomRuleParameter param = new CustomRuleParameter();
            param.FieldValue = new Dictionary<string, string>();
            param.FieldValue.Add("CÓDIGO DO PRODUTO", "100");
            param.FieldValue.Add("CÓDIGO DA BANDEIRA", "001");//Bandeira Mastercard
            Assert.IsTrue(regra.PerformCustomRule(param).TestResult);

        }
        [TestMethod]
        public void ValoresComCaracteresInexistentes()
        {
            R003_CodigoProdutoBandeira regra = new R003_CodigoProdutoBandeira();
            CustomRuleParameter param = new CustomRuleParameter();
            param.FieldValue = new Dictionary<string, string>();
            param.FieldValue.Add("CÓDIGO DO PRODUTO", "001");
            param.FieldValue.Add("CÓDIGO DA BANDEIRA", "00A");
            Assert.IsFalse(regra.PerformCustomRule(param).TestResult);

        }
        [TestMethod]
        public void ValoresCorrespondentesBandeiraVisa()
        {
            R003_CodigoProdutoBandeira regra = new R003_CodigoProdutoBandeira();
            CustomRuleParameter param = new CustomRuleParameter();
            param.FieldValue = new Dictionary<string, string>();
            param.FieldValue.Add("CÓDIGO DO PRODUTO", "500");
            param.FieldValue.Add("CÓDIGO DA BANDEIRA", "002"); //Visa
            Assert.IsTrue(regra.PerformCustomRule(param).TestResult);

        }
        [TestMethod]
        public void ValoresCorrespondentesBandeiraAmex()
        {
            R003_CodigoProdutoBandeira regra = new R003_CodigoProdutoBandeira();
            CustomRuleParameter param = new CustomRuleParameter();
            param.FieldValue = new Dictionary<string, string>();
            param.FieldValue.Add("CÓDIGO DO PRODUTO", "600");
            param.FieldValue.Add("CÓDIGO DA BANDEIRA", "003");// Bandeira Amex
            Assert.IsTrue(regra.PerformCustomRule(param).TestResult);

        }
    }
}
