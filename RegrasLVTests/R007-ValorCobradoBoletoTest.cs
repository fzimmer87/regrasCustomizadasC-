using LayoutValidator.CustomRuleTemplate;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegrasLV;
using System.Collections.Generic;

namespace RegrasLVTests
{
    [TestClass]
    public class R007_ValorCobradoBoletoTest
    {
        [TestMethod]
        public void ValidarValorCobradoCorretoJurosDesconto()
        {
            R007_ValorCobradoBoleto regra = new R007_ValorCobradoBoleto();
            CustomRuleParameter param = new CustomRuleParameter();
            param.FieldValue = new Dictionary<string, string>();
            param.FieldValue.Add("Valor do Documento", "1000");
            param.FieldValue.Add("Descontos/Abatimentos", "50");
            param.FieldValue.Add("Juros/Multa", "120");
            param.FieldValue.Add("Valor cobrado", "1070");
            Assert.IsTrue(regra.PerformCustomRule(param).TestResult);
        }
        [TestMethod]
        public void ValorBoletoComDesconto()
        {
            R007_ValorCobradoBoleto regra = new R007_ValorCobradoBoleto();
            CustomRuleParameter param = new CustomRuleParameter();
            param.FieldValue = new Dictionary<string, string>();
            param.FieldValue.Add("Valor do Documento", "1000");
            param.FieldValue.Add("Descontos/Abatimentos", "50");
            param.FieldValue.Add("Juros/Multa", "0");
            param.FieldValue.Add("Valor cobrado", "950");
            Assert.IsTrue(regra.PerformCustomRule(param).TestResult);
        }
        [TestMethod]
        public void ValorBoletoComJuros()
        {
            R007_ValorCobradoBoleto regra = new R007_ValorCobradoBoleto();
            CustomRuleParameter param = new CustomRuleParameter();
            param.FieldValue = new Dictionary<string, string>();
            param.FieldValue.Add("Valor do Documento", "1000");
            param.FieldValue.Add("Descontos/Abatimentos", "0");
            param.FieldValue.Add("Juros/Multa", "50");
            param.FieldValue.Add("Valor cobrado", "1050");
            Assert.IsTrue(regra.PerformCustomRule(param).TestResult);
        }
        [TestMethod]
        public void ValorBoletoSemJurosDesconto()
        {
            R007_ValorCobradoBoleto regra = new R007_ValorCobradoBoleto();
            CustomRuleParameter param = new CustomRuleParameter();
            param.FieldValue = new Dictionary<string, string>();
            param.FieldValue.Add("Valor do Documento", "1000");
            param.FieldValue.Add("Descontos/Abatimentos", "0");
            param.FieldValue.Add("Juros/Multa", "0");
            param.FieldValue.Add("Valor cobrado", "1000");
            Assert.IsTrue(regra.PerformCustomRule(param).TestResult);
        }
    }
}



