using LayoutValidator.CustomRuleTemplate;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegrasLV;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegrasLVTests
{
    [TestClass]
    public class R009_QuantidadeRegistroLoteTest
    {
        [TestMethod]
        public void QuantidadeRegistroLoteCorreto()
        {
            R009_QuantidadeRegistrosLote regra = new R009_QuantidadeRegistrosLote();
            CustomRuleParameter param = new CustomRuleParameter();

            var publicSession = new Dictionary<string, object>();
            var privateSession = new Dictionary<string, object>();

            #region Header
            param.FieldValue = new Dictionary<string, string>();
            param.FieldValue.Add("Quantidade Registro Lote", "500");

            regra.PerformCustomCode(param, privateSession, publicSession, 0, 0, "HEADER");

            regra.PerformCustomCode(param, privateSession, publicSession, 0, 0, "HEADER");
            #endregion

            #region Trailer
            param.FieldValue = new Dictionary<string, string>();
            param.FieldValue.Add("Quantidade de registros", "1000");
            Assert.IsTrue(regra.PerformCustomCode(param, privateSession, publicSession, 0, 0, "TRAILER").TestResult);
            #endregion
        }
        [TestMethod]
        public void QuantidadeValorIncorreto()
        {
            R009_QuantidadeRegistrosLote regra = new R009_QuantidadeRegistrosLote();
            CustomRuleParameter param = new CustomRuleParameter();

            var privateSession = new Dictionary<string, object>();
            var publicSession = new Dictionary<string, object>();

            #region Header
            param.FieldValue = new Dictionary<string, string>();
            param.FieldValue.Add("Quantidade Registro Lote", "500");

            regra.PerformCustomCode(param, privateSession, publicSession, 0, 0, "HEADER");
            regra.PerformCustomCode(param, privateSession, publicSession, 0, 0, "HEADER");
            #endregion

            #region Trailer
            param.FieldValue = new Dictionary<string, string>();
            param.FieldValue.Add("Quantidade de registros", "200");
            Assert.IsFalse(regra.PerformCustomCode(param, privateSession, publicSession, 0, 0, "TRAILER").TestResult);
            #endregion
        }
    }
}

