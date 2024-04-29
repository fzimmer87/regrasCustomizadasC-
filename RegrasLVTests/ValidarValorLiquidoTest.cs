using LayoutValidator.CustomRuleTemplate;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegrasLV;
using System.Collections.Generic;


namespace RegrasLVTests
{
    [TestClass]
    public class ValidarValorLiquidoTest
    {
        [TestMethod]
        public void ValorLiquidoIncorreto()
        {
            ValidarValorLiquido regra = new ValidarValorLiquido();
            CustomRuleParameter param = new CustomRuleParameter();

            param.FieldValue = new Dictionary<string, string>();
            param.FieldValue.Add("Valor_Bruto", "1000");
            param.FieldValue.Add("Valor_Liquido", "100");
            param.FieldValue.Add("Valor_Taxa", "1500");
            
            Assert.IsFalse(regra.PerformCustomRule(param).TestResult);

        }
    }
}
