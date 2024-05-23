using LayoutValidator.CustomRuleTemplate;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegrasLV;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegrasLVTests
{
    [TestClass]
    public class R016_QuantidadeDeRegistrosXPTOTest
    {
        [TestMethod]
        public void QuantidadeDeRegistrosIguais()
        {
            R016_QuantidadeDeRegistrosXPTO regra = new R016_QuantidadeDeRegistrosXPTO();
            CustomRuleParameter param = new CustomRuleParameter();

            var privateSession = new Dictionary<string, object>();
            var publicSession = new Dictionary<string, object>();

            #region Header
            param.FieldValue = new Dictionary<string, string>();
            param.FieldValue.Add("QUANTIDADE REGISTROS LOTE", "000");

            regra.PerformCustomCode(param, privateSession, publicSession, 0, 0, "Header");
            #endregion

            #region Trailer
            param.FieldValue = new Dictionary<string, string>();
            param.FieldValue.Add("QUANTIDADE DE REGISTROS", "000");

            Assert.IsTrue(regra.PerformCustomCode(param, privateSession, publicSession, 0, 0, "Trailer").TestResult);
            #endregion
        }
        [TestMethod]
        public void QuantidadeDeRegistrosDiferentes()
        {
            R016_QuantidadeDeRegistrosXPTO regra = new R016_QuantidadeDeRegistrosXPTO();
            CustomRuleParameter param = new CustomRuleParameter();

            var privateSession = new Dictionary<string, object>();
            var publicSession = new Dictionary<string, object>();

            #region Header
            param.FieldValue = new Dictionary<string, string>();
            param.FieldValue.Add("Quantidade Registros Lote", "150");

            regra.PerformCustomCode(param, privateSession, publicSession, 0, 0, "Header");
            #endregion

            #region Trailer
            param.FieldValue = new Dictionary<string, string>();
            param.FieldValue.Add("Quantidade de Registros", "120");

            Assert.IsFalse(regra.PerformCustomCode(param, privateSession, publicSession, 0, 0, "Trailer").TestResult);
            #endregion
        }
      }
    }
