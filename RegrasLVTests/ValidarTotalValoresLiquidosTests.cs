using LayoutValidator.CustomRuleTemplate;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegrasLV;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace RegrasLVTests
{
    [TestClass]
    public class ValidarTotalValoresLiquidosTests
    {
        [TestMethod]
        public void ValidarValorTotalLiquido()
        {
            ValidarValorLiquidoStateful regra = new ValidarValorLiquidoStateful();
            CustomRuleParameter param = new CustomRuleParameter();

            var publicSession = new Dictionary<string, object>();
            var privateSession = new Dictionary<string, object>();

            #region Linha Detalhes
            param.FieldValue = new Dictionary<string, string>();
            param.FieldValue.Add("VALOR LIQUIDO", "500");

            regra.PerformCustomCode(param, publicSession, privateSession, 0, 0, "DETALHES");

            regra.PerformCustomCode(param, publicSession, privateSession, 0, 0, "DETALHES");

            regra.PerformCustomCode(param, publicSession, privateSession, 0, 0, "DETALHES");
            #endregion

            #region Linha Trailer
            param.FieldValue = new Dictionary<string, string>();
            param.FieldValue.Add("TOTAL VALOR LIQUIDO", "2000");

            Assert.IsFalse(regra.PerformCustomCode(param,publicSession, privateSession, 0, 0, "TRAILER").TestResult);
            #endregion
        }
        [TestMethod]
        public void ValorLiquidoCorreto()
        {
            ValidarValorLiquidoStateful regra = new ValidarValorLiquidoStateful();
            CustomRuleParameter param = new CustomRuleParameter();

            var publicSession = new Dictionary<string, object>();
            var privateSession = new Dictionary< string, object>();

            #region Linha Detalhes
            param.FieldValue = new Dictionary<string, string>();
            param.FieldValue.Add("VALOR LIQUIDO", "500");
            

            regra.PerformCustomCode(param, publicSession, privateSession, 0, 0, "DETALHES");

            regra.PerformCustomCode(param, publicSession, privateSession, 0, 0, "DETALHES");
            #endregion

            #region Trailer
            param.FieldValue = new Dictionary<string, string>();
            param.FieldValue.Add("TOTAL VALOR LIQUIDO", "1000");
            Assert.IsTrue(regra.PerformCustomCode(param, publicSession, privateSession, 0, 0, "TRAILER").TestResult);
            #endregion
        }
    }
}
