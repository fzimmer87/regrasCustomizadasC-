using LayoutValidator.CustomRuleTemplate;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegrasLV;
using System.Collections.Generic;


namespace RegrasLVTests
{
    [TestClass]
    public class R004_ValorLiquido_Tests
    {
        R004_ValorLiquido regra = new R004_ValorLiquido();
        CustomRuleParameter param = new CustomRuleParameter(); 

        [TestMethod]
        public void ValorLiquidoCorreto()
        {
            param.FieldValue = new Dictionary<string, string>();
            param.FieldValue.Add("Valor_Bruto", "1000");
            param.FieldValue.Add("Desconto", "200");
            param.FieldValue.Add("Valor_Liquido","800");
            Assert.IsTrue(regra.PerformCustomRule(param).TestResult);
        }
        [TestMethod]
        public void ValorLiquidoErrado()
        {
            param.FieldValue = new Dictionary<string, string>();
            param.FieldValue.Add("Valor_Bruto", "1000");
            param.FieldValue.Add("Desconto", "200");
            param.FieldValue.Add("Valor_Liquido", "801");
            Assert.IsFalse(regra.PerformCustomRule(param).TestResult);
        }
    }
}
