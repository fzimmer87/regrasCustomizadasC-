using LayoutValidator.CustomRuleTemplate;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegrasLV;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegrasLVTests
{
    [TestClass]
    public class R015_DataVencimentoLoteTest
    {
        [TestMethod]
        public void DataVencimentoCorreto()
        {
            R015_DataVencimentoLote regra = new R015_DataVencimentoLote();
            CustomRuleParameter param = new CustomRuleParameter();

            var privateSession = new Dictionary<string, object>();
            var publicSession = new Dictionary<string, object>();

            #region Boleto Bancário
            param.FieldValue = new Dictionary<string, string>();
            param.FieldValue.Add("Vencimento do Lote", "03/24");

            regra.PerformCustomCode(param, privateSession, publicSession, 0, 0, "Trailer");
            #endregion

            #region Trailer
            param.FieldValue = new Dictionary<string, string>();
            param.FieldValue.Add("Data do Documento", "20/02/2024");
            param.FieldValue.Add("Data do Processamento", "19/02/2024");

            Assert.IsTrue(regra.PerformCustomCode(param, privateSession, publicSession, 0, 0, "Boleto Bancário").TestResult);
            #endregion
        }
        [TestMethod]
        public void DataVencimentoIncorreto()
        {
            R015_DataVencimentoLote regra = new R015_DataVencimentoLote();
            CustomRuleParameter param = new CustomRuleParameter();

            var privateSession = new Dictionary<string, object>();
            var publicSession = new Dictionary<string, object>();

            #region Boleto Bancário
            param.FieldValue = new Dictionary<string, string>();
            param.FieldValue.Add("Vencimento do Lote", "01/24");

            regra.PerformCustomCode(param, privateSession, publicSession, 0, 0, "Trailer");
            #endregion

            #region Trailer
            param.FieldValue = new Dictionary<string, string>();
            param.FieldValue.Add("Data do Documento", "20/02/2024");
            param.FieldValue.Add("Data do Processamento", "19/02/2024");

            Assert.IsFalse(regra.PerformCustomCode(param, privateSession, publicSession, 0, 0, "Boleto Bancário").TestResult);
            #endregion
        }
    }
}
