using LayoutValidator.CustomRuleTemplate;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegrasLV;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegrasLVTests
{
    [TestClass]
    public class R013_NumeroDoTerminal_CartoesTest
    {
        [TestMethod]
        public void NumeroTerminalIgualAZero()
        {
            R013_NumeroDoTerminal_Cartoes regra = new R013_NumeroDoTerminal_Cartoes();
            CustomRuleParameter param= new CustomRuleParameter();
            param.FieldValue = new Dictionary<string, string>();
            param.FieldValue.Add("Número do Terminal", "000");
            param.FieldValue.Add("Geração", "TP1");
            Assert.IsTrue(regra.PerformCustomRule(param).TestResult);
        }
        [TestMethod]
        public void NumeroTerminalDiferenteZero()
        {
            R013_NumeroDoTerminal_Cartoes regra = new R013_NumeroDoTerminal_Cartoes();
            CustomRuleParameter param = new CustomRuleParameter();
            param.FieldValue = new Dictionary<string, string>();
            param.FieldValue.Add("Número do Terminal", "001");
            param.FieldValue.Add("Geração", "TP1");
            Assert.IsFalse(regra.PerformCustomRule(param).TestResult);
        }
    }
}
