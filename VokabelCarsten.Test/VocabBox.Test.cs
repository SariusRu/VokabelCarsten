using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VocabelCarsten.Test
{
    [TestClass]
    public class VocabBoxTest
    {

        [TestMethod]
        public void getNameChecks()
        {
            //initialize
            VokabelCarsten.VocabBox testVocabBox = new VokabelCarsten.VocabBox("TestBox", "Deutsch", "Englisch", "path");
            //get name
            Assert.AreEqual("TestBox", testVocabBox.getName(), "The value wasn't returned correctly");

        }

        [TestMethod]
        public void getAnzVokChecks()
        {
            //initialize
            VokabelCarsten.VocabBox testVocabBox = new VokabelCarsten.VocabBox("TestBox", "Deutsch", "Englisch", "[TestMethod]path");

            Assert.AreEqual(0, testVocabBox.getAnzVok(), "The first value wasn't returned correctly");

            testVocabBox.addVokabel("Hallo", "Hello");
            //alter Anz
            Assert.AreEqual(1, testVocabBox.getAnzVok(), "The second value wasn't returned correctly");

        }

        [TestMethod]
        public void getSetFilePathChecks()
        {
            //initialize
            VokabelCarsten.VocabBox testVocabBox = new VokabelCarsten.VocabBox("TestBox", "Deutsch", "Englisch", "c://test/file/path");
            //get Filepath
            Assert.AreEqual("c://test/file/path", testVocabBox.getFilePath(), "The first value wasn't returned correctly");

            testVocabBox.setFilePath("c://test/file/path2");
            //set Filepath
            Assert.AreEqual("c://test/file/path2", testVocabBox.getFilePath(), "The second value wasn't returned correctly");

        }



    }
}
