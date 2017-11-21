using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContactListSwagger;
using System.Collections.Generic;

namespace UnitTestContactListSwagger
{
    [TestClass]
    public class UnitTestController
    {
        [TestMethod]
        public void DeleteSomebody()
        {
            int id = 2;
            ContactController cc = new ContactController();
            cc.Delete(id);
            Assert.AreEqual(2, cc.getItems().Count);
        }

        [TestMethod]
        public void FindChuck()
        {
            string name = "Chuck";
            ContactController cc = new ContactController();
            Assert.IsNotNull(cc.Findbyname(name));
        }
    }
}
