using LayoutValidator.CustomRuleTemplate;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegrasLV;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegrasLVTests
{
    [TestClass]
    public class R005_DataVencimentoEDataProcessamento
    {
        [TestMethod]
        public void DatasComValoresCorretos()
        {
            R005_DataVencimentoDataProcessamento regras = new R005_DataVencimentoDataProcessamento();
            CustomRuleParameter param = new CustomRuleParameter();
            param.FieldValue = new Dictionary<string, string>();
            param.FieldValue.Add("Data de Vencimento", "20/06/2024");
            param.FieldValue.Add("Data do Processamento", "20/05/2024");
            Assert.IsTrue(regras.PerformCustomRule(param).TestResult);
        }
    }
}
