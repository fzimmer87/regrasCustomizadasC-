using LayoutValidator.CustomRuleTemplate;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegrasLV;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegrasLVTests
{
    [TestClass]
    public class R011_CampoPixTest
    {
        [TestMethod]
        public void IdUnicoCorreto()
        {
            R011_CampoPix regra = new R011_CampoPix();
            CustomRuleParameter param = new CustomRuleParameter();

            var privateSession = new Dictionary<string, object>();
            var publicSession = new Dictionary<string, object>();

            #region Pix
            param.FieldValue = new Dictionary<string, string>();
            param.FieldValue.Add("ID PIX", "147");

            Assert.IsTrue(regra.PerformCustomCode(param, privateSession, publicSession,0,0, "Transações PIX").TestResult);
            #endregion

            #region Pix
            param.FieldValue = new Dictionary<string, string>();
            param.FieldValue.Add("ID PIX", "148");

            Assert.IsTrue(regra.PerformCustomCode(param, privateSession, publicSession, 0, 0, "Transações PIX").TestResult);
            #endregion
        }
        [TestMethod]
        public void IdUnicoInCorreto()
        {
            R011_CampoPix regra = new R011_CampoPix();
            CustomRuleParameter param = new CustomRuleParameter();

            var privateSession = new Dictionary<string, object>();
            var publicSession = new Dictionary<string, object>();

            #region Pix
            param.FieldValue = new Dictionary<string, string>();
            param.FieldValue.Add("ID PIX", "147");

            Assert.IsTrue(regra.PerformCustomCode(param, privateSession, publicSession, 0, 0, "Transações PIX").TestResult);
            #endregion

            #region Pix
            param.FieldValue = new Dictionary<string, string>();
            param.FieldValue.Add("ID PIX", "147");

            Assert.IsFalse(regra.PerformCustomCode(param, privateSession, publicSession, 0, 0, "Transações PIX").TestResult);
            #endregion
        }
    }
}
