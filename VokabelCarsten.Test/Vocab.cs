using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VocabelCarsten.Test
{
    [TestClass]
    public class VocabTest
    {
        [TestMethod]
        public void returnSide1Checks()
        {
            //initialize
            VokabelCarsten.Vocab testVocab = new VokabelCarsten.Vocab("Hallo", "Hello", 0);
            //alter name
            Assert.AreEqual("Hallo", testVocab.getSide1(), "The value wasn't returned correctly");

        }

        [TestMethod]
        public void returnSide2Checks()
        {
            //initialize
            VokabelCarsten.Vocab testVocab = new VokabelCarsten.Vocab("Hallo", "Hello", 0);
            //alter name
            Assert.AreEqual("Hello", testVocab.getSide2(), "The value wasn't returned correctly");

        }

        [TestMethod]
        public void changeTranslation()
        {
            //initialize
            VokabelCarsten.Vocab testVocab = new VokabelCarsten.Vocab("Hallo", "Hello", 0);            
            //alter side1
            testVocab.EditVocab("Tschüss", "Hello", 0);
            //check results
            Assert.AreEqual("Tschüss", testVocab.getSide1(), "The value wasn't changed correctly");
            Assert.AreEqual("Hello", testVocab.getSide2(), "The value was changed even if it wasn't supposed to be chanegd.");

            //alter side2
            testVocab.EditVocab("Tschüss", "Bye", 0);
            //Check Results
            Assert.AreEqual("Tschüss", testVocab.getSide1(), "The value was changed even if it wasn't supposed to be chanegd.");
            Assert.AreEqual("Bye", testVocab.getSide2(), "The value wasn't changed correctly");

            //alter both sides
            testVocab.EditVocab("Hallo", "Hello", 0);
            //Check Results
            Assert.AreEqual("Hallo", testVocab.getSide1(), "The value wasn't changed correctly");
            Assert.AreEqual("Hello", testVocab.getSide2(), "The value wasn't changed correctly");

        }
    }
}