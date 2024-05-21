using LayoutValidator.CustomRuleTemplate;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegrasLV;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegrasLVTests
{
    [TestClass]
    public class R010_NumeroIdentificadorLoteTest
    {
        [TestMethod]
        public void IdentificadorCorreto()
        {
            R010_NumeroIdentificadorDeLote regra = new R010_NumeroIdentificadorDeLote();
            CustomRuleParameter param = new CustomRuleParameter();

            var publicSession = new Dictionary<string, object>();
            var privateSession = new Dictionary<string, object>();

            #region Header
            param.FieldValue = new Dictionary<string, string>();
            param.FieldValue.Add("Número Identificador Lote", "123456");

            Assert.IsTrue(regra.PerformCustomCode(param, privateSession, publicSession, 0, 0, "Header").TestResult);
            #endregion
            #region Header
            param.FieldValue = new Dictionary<string, string>();
            param.FieldValue.Add("Número Identificador Lote", "1234567");

            Assert.IsTrue(regra.PerformCustomCode(param, privateSession, publicSession, 0, 0, "Header").TestResult);
            #endregion

        }
        [TestMethod]
        public void IdentificadorIncorreto()
        {
            R010_NumeroIdentificadorDeLote regra = new R010_NumeroIdentificadorDeLote();
            CustomRuleParameter param = new CustomRuleParameter();

            var publicSession = new Dictionary<string, object>();
            var privateSession = new Dictionary<string, object>();

            #region Header
            param.FieldValue = new Dictionary<string, string>();
            param.FieldValue.Add("Número Identificador Lote", "123456");

            Assert.IsTrue(regra.PerformCustomCode(param, privateSession, publicSession, 0, 0, "Header").TestResult);
            #endregion
            #region Header
            param.FieldValue = new Dictionary<string, string>();
            param.FieldValue.Add("Número Identificador Lote", "123456");

            Assert.IsFalse(regra.PerformCustomCode(param, privateSession, publicSession, 0, 0, "Header").TestResult);
            #endregion
        }
    }
}
