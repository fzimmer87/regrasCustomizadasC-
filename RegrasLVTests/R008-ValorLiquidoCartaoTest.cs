using LayoutValidator.CustomRuleTemplate;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegrasLV;
using System.Collections.Generic;


namespace RegrasLVTests
{
    [TestClass]
    public class R008_ValorLiquidoCartaoTest
    {
        [TestMethod]
        public void ValorLiquidoCorreto()
        {
            R008_ValorLiquidoCartao regra = new R008_ValorLiquidoCartao();
            CustomRuleParameter param = new CustomRuleParameter();
            param.FieldValue = new Dictionary<string, string>();
            param.FieldValue.Add("Valor Bruto", "1500,60");
            param.FieldValue.Add("Desconto", "200");
            param.FieldValue.Add("Valor Liquido", "1301,00");
            Assert.IsTrue(regra.PerformCustomRule(param).TestResult);
        }
        [TestMethod]
        public void ValorLiquidoIncorreto()
        {
            R008_ValorLiquidoCartao regra = new R008_ValorLiquidoCartao();
            CustomRuleParameter param = new CustomRuleParameter();
            param.FieldValue = new Dictionary<string, string>();
            param.FieldValue.Add("Valor Bruto", "1500");
            param.FieldValue.Add("Desconto", "200");
            param.FieldValue.Add("Valor Liquido", "1000");
            Assert.IsFalse(regra.PerformCustomRule(param).TestResult);
        }
        [TestMethod]
        public void ValorLiquidoSemDesconto()
        {
            R008_ValorLiquidoCartao regra = new R008_ValorLiquidoCartao();
            CustomRuleParameter param = new CustomRuleParameter();
            param.FieldValue = new Dictionary<string, string>();
            param.FieldValue.Add("Valor Bruto", "1500,40");
            param.FieldValue.Add("Desconto", "0");
            param.FieldValue.Add("Valor Liquido", "1500,40");
            Assert.IsTrue(regra.PerformCustomRule(param).TestResult);

        }
        [TestMethod]
        public void ValorLiquidoNegativo()
        {
            R008_ValorLiquidoCartao regra = new R008_ValorLiquidoCartao();
            CustomRuleParameter param = new CustomRuleParameter();
            param.FieldValue = new Dictionary<string, string>();
            param.FieldValue.Add("Valor Bruto", "1500");
            param.FieldValue.Add("Desconto", "1700");
            param.FieldValue.Add("Valor Liquido", "-200");
            Assert.IsTrue(regra.PerformCustomRule(param).TestResult);
        }
    }
}
