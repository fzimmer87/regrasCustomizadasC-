using LayoutValidator.CustomRuleTemplate;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegrasLV;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegrasLVTests
{
    [TestClass]
    public class R014_TipoDeTransacaoHeaderTests
    {
        [TestMethod]
        public void TipodeTransacaoComValorUnico()
        {
            R014_TipoDeTransacaoHeader regra = new R014_TipoDeTransacaoHeader();
            CustomRuleParameter param = new CustomRuleParameter();

            var privateSession = new Dictionary<string, object>();
            var publicSession = new Dictionary<string, object>();

            #region Header
            param.FieldValue = new Dictionary<string, string>();
            param.FieldValue.Add("Tipo de Transação", "123");
            Assert.IsTrue(regra.PerformCustomCode(param, privateSession, publicSession,0,0,"Header").TestResult);
            #endregion

            #region Header
            param.FieldValue = new Dictionary<string, string>();
            param.FieldValue.Add("Tipo de Transação", "1234");
            Assert.IsTrue(regra.PerformCustomCode(param, privateSession, publicSession, 0, 0, "Header").TestResult);
            #endregion

        }
        [TestMethod]
        public void TipodeTransacaoComValorRepetido()
        {
            R014_TipoDeTransacaoHeader regra = new R014_TipoDeTransacaoHeader();
            CustomRuleParameter param = new CustomRuleParameter();

            var privateSession = new Dictionary<string, object>();
            var publicSession = new Dictionary<string, object>();

            #region Header
            param.FieldValue = new Dictionary<string, string>();
            param.FieldValue.Add("Tipo de Transação", "123");
            Assert.IsTrue(regra.PerformCustomCode(param, privateSession, publicSession, 0, 0, "Header").TestResult);
            #endregion

            #region Header
            param.FieldValue = new Dictionary<string, string>();
            param.FieldValue.Add("Tipo de Transação", "123");
            Assert.IsFalse(regra.PerformCustomCode(param, privateSession, publicSession, 0, 0, "Header").TestResult);
            #endregion

        }
    }
}
