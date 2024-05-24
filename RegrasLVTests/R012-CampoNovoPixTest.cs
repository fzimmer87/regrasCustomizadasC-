using LayoutValidator.CustomRuleTemplate;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegrasLV;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegrasLVTests
{
    [TestClass]
    public class R012_CampoNovoPixTest
    {
        [TestMethod]
        public void CampoPixIgual0()
        {
            R012_CampoNovoPix regra = new R012_CampoNovoPix();
            CustomRuleParameter param = new CustomRuleParameter();

            param.FieldValue = new Dictionary<string, string>();
            param.FieldValue.Add("Novo ID PIX", "00000");
            param.FieldValue.Add("Reprocessamento", "N");
            Assert.IsTrue(regra.PerformCustomRule(param).TestResult);
        }
        [TestMethod]
        public void CampoPixDiferenteDe0()
        {
            R012_CampoNovoPix regra = new R012_CampoNovoPix();
            CustomRuleParameter param = new CustomRuleParameter();

            param.FieldValue = new Dictionary<string, string>();
            param.FieldValue.Add("Novo ID PIX", "00001");
            param.FieldValue.Add("Reprocessamento", "N");
            Assert.IsFalse(regra.PerformCustomRule(param).TestResult);
        }
        [TestMethod]
        public void CampoPixDiferenteDe0ReprocessamentoDiferenteDeN()
        {
            R012_CampoNovoPix regra = new R012_CampoNovoPix();
            CustomRuleParameter param = new CustomRuleParameter();

            param.FieldValue = new Dictionary<string, string>();
            param.FieldValue.Add("NOVO ID PIX", "00001");
            param.FieldValue.Add("REPROCESSAMENTO", "S");
            Assert.IsTrue(regra.PerformCustomRule(param).TestResult);
        }
        [TestMethod]
        public void CampoPixIguala0ReprocessamentoDiferenteDeN()
        {
            R012_CampoNovoPix regra = new R012_CampoNovoPix();
            CustomRuleParameter param = new CustomRuleParameter();

            param.FieldValue = new Dictionary<string, string>();
            param.FieldValue.Add("NOVO ID PIX", "00000");
            param.FieldValue.Add("REPROCESSAMENTO", "S");
            Assert.IsFalse(regra.PerformCustomRule(param).TestResult);
        }
    }
}
