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

        [TestMethod]
        public void getLevelTest()
        {
            //initialize
            VokabelCarsten.Vocab testVocab1 = new VokabelCarsten.Vocab("Hallo", "Hello", 0);
            Assert.AreEqual(0, testVocab1.GetLevel(), "Test Vocab was initalized properly");
            testVocab1.increaseLevel();
            VokabelCarsten.Vocab testVocab2 = new VokabelCarsten.Vocab("Hallo", "Hello", 0);
            //alter name
            Assert.AreEqual(1, testVocab1.GetLevel(), "Level wasn't returned Properly");
            Assert.AreEqual(0, testVocab2.GetLevel(), "Test Vocab was initalized properly");

        }

        [TestMethod]
        public void increaseLevelTest()
        {
            VokabelCarsten.Vocab testVocab1 = new VokabelCarsten.Vocab("Hallo", "Hello", 0);
            Assert.AreEqual(0, testVocab1.GetLevel(), "Test Vocab was initalized properly");
            testVocab1.increaseLevel();
            Assert.AreEqual(1, testVocab1.GetLevel(), "Level wasn't increased Properly");
            testVocab1.increaseLevel();
            testVocab1.increaseLevel();
            testVocab1.increaseLevel();
            testVocab1.increaseLevel();
            testVocab1.increaseLevel();
            Assert.AreEqual(6, testVocab1.GetLevel(), "Level wasn't increased Properly");
            testVocab1.increaseLevel();
            Assert.AreEqual(6, testVocab1.GetLevel(), "Level wasn't increased Properly");
        }

        [TestMethod]
        public void decreaseLevelTest()
        {
            VokabelCarsten.Vocab testVocab1 = new VokabelCarsten.Vocab("Hallo", "Hello", 0);
            Assert.AreEqual(0, testVocab1.GetLevel(), "Test Vocab was initalized properly");
            testVocab1.decreaseLevel();
            Assert.AreEqual(0, testVocab1.GetLevel(), "Level wasn't increased Properly");
            testVocab1.increaseLevel();
            testVocab1.increaseLevel();
            testVocab1.increaseLevel();
            Assert.AreEqual(3, testVocab1.GetLevel(), "Level wasn't increased Properly");
            testVocab1.decreaseLevel();
            Assert.AreEqual(2, testVocab1.GetLevel(), "Level wasn't increased Properly");
            
        }
    }
}