using LayoutValidator.CustomRuleTemplate;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegrasLV;
using System.Collections.Generic;


namespace RegrasLVTests
{
    [TestClass]
    public class R001_ValidarDataGeracaoLoteComDataTests
    {
        [TestMethod]
        public void ValidarDataLoteEDataProcessamentoCorreto()
        {
            ValidarDataGeracaoLoteComDataProcessamento regra = new ValidarDataGeracaoLoteComDataProcessamento();
            CustomRuleParameter param = new CustomRuleParameter();
            param.FieldValue = new Dictionary<string, string>();
            param.FieldValue.Add("Data Geração Lote", "230810");
            param.FieldValue.Add("Data Processamento Lote", "230810");
            Assert.IsTrue(regra.PerformCustomRule(param).TestResult);
        }

        [TestMethod]
        public void ValidarDataLoteEDataProcessamentoErrada()
        {
            ValidarDataGeracaoLoteComDataProcessamento regra = new ValidarDataGeracaoLoteComDataProcessamento();
            CustomRuleParameter param = new CustomRuleParameter();
            param.FieldValue = new Dictionary<string, string>();
            param.FieldValue.Add("Data Geração Lote", "240810");
            param.FieldValue.Add("Data Processamento Lote", "240811");
            Assert.IsFalse(regra.PerformCustomRule(param).TestResult);
        }
        [TestMethod]
        public void ValidarDataLoteEDataProcessamentoAnoInvalido()
        {
            ValidarDataGeracaoLoteComDataProcessamento regra = new ValidarDataGeracaoLoteComDataProcessamento();
            CustomRuleParameter param = new CustomRuleParameter();
            param.FieldValue = new Dictionary<string, string>();
            param.FieldValue.Add("Data Geração Lote", "241340");
            param.FieldValue.Add("Data Processamento Lote", "241345");
            Assert.IsFalse(regra.PerformCustomRule(param).TestResult);
        }
    }
}
