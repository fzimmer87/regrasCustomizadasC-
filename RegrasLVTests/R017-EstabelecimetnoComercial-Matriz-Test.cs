using LayoutValidator.CustomRuleTemplate;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegrasLV;
using System.Collections.Generic;

namespace RegrasLVTests
{
    [TestClass]
    public class R017_EstabelecimetnoComercial_Matriz_Test
    {
        [TestMethod]
        public void valorEstabelecimentoMatrizCorreto()
        {
            R017_EstabelecimentoComercial_Matriz regra = new R017_EstabelecimentoComercial_Matriz();
            CustomRuleParameter param = new CustomRuleParameter();

            var privateSession = new Dictionary<string, object>();
            var publicSession = new Dictionary<string, object>();

            #region Transações de Cartão
            param.FieldValue = new Dictionary<string, string>();
            param.FieldValue.Add("Estabelecimento Comercial", "000666");
            param.FieldValue.Add("Número da Matriz", "0006660022");

            regra.PerformCustomCode(param, privateSession, publicSession, 0, 0, "Transações de Cartão");
            #endregion

            #region Transações de Cartão
            param.FieldValue = new Dictionary<string, string>();
            param.FieldValue.Add("Estabelecimento Comercial", "000777");
            param.FieldValue.Add("Número da Matriz", "0006660022");

            Assert.IsTrue(regra.PerformCustomCode(param, privateSession, publicSession, 0, 0, "Transações de Cartão").TestResult);
            #endregion
        }
        [TestMethod]
        public void valorEstabelecimentoRepetido()
        {
            R017_EstabelecimentoComercial_Matriz regra = new R017_EstabelecimentoComercial_Matriz();
            CustomRuleParameter param = new CustomRuleParameter();

            var privateSession = new Dictionary<string, object>();
            var publicSession = new Dictionary<string, object>();

            #region Transações de Cartão
            param.FieldValue = new Dictionary<string, string>();
            param.FieldValue.Add("Estabelecimento Comercial", "000666");
            param.FieldValue.Add("Número da Matriz", "0006660022");

            regra.PerformCustomCode(param, privateSession, publicSession, 0, 0, "Transações de Cartão");
            #endregion

            #region Transações de Cartão
            param.FieldValue = new Dictionary<string, string>();
            param.FieldValue.Add("Estabelecimento Comercial", "000666");
            param.FieldValue.Add("Número da Matriz", "00066600221");

            Assert.IsFalse(regra.PerformCustomCode(param, privateSession, publicSession, 0, 0, "Transações de Cartão").TestResult);
            #endregion
        }
        [TestMethod]
        public void valoresEstabelecimentoDiferentesParaUmaMesmaMatriz()
        {
            R017_EstabelecimentoComercial_Matriz regra = new R017_EstabelecimentoComercial_Matriz();
            CustomRuleParameter param = new CustomRuleParameter();

            var privateSession = new Dictionary<string, object>();
            var publicSession = new Dictionary<string, object>();

            #region Transações de Cartão
            param.FieldValue = new Dictionary<string, string>();
            param.FieldValue.Add("Estabelecimento Comercial", "000666");
            param.FieldValue.Add("Número da Matriz", "0006660022");

            regra.PerformCustomCode(param, privateSession, publicSession, 0, 0, "Transações de Cartão");
            #endregion

            #region Transações de Cartão
            param.FieldValue = new Dictionary<string, string>();
            param.FieldValue.Add("Estabelecimento Comercial", "000888");
            param.FieldValue.Add("Número da Matriz", "0006660022");

            Assert.IsTrue(regra.PerformCustomCode(param, privateSession, publicSession, 0, 0, "Transações de Cartão").TestResult);
            #endregion

            #region Transações de Cartão
            param.FieldValue = new Dictionary<string, string>();
            param.FieldValue.Add("Estabelecimento Comercial", "000777");
            param.FieldValue.Add("Número da Matriz", "0006660022");

            Assert.IsTrue(regra.PerformCustomCode(param, privateSession, publicSession, 0, 0, "Transações de Cartão").TestResult);
            #endregion

            #region Transações de Cartão
            param.FieldValue = new Dictionary<string, string>();
            param.FieldValue.Add("Estabelecimento Comercial", "000999");
            param.FieldValue.Add("Número da Matriz", "0008880022");

            Assert.IsTrue(regra.PerformCustomCode(param, privateSession, publicSession, 0, 0, "Transações de Cartão").TestResult);
            #endregion
        }
    }
}
