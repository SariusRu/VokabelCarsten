using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace VocabelCarsten.Test
{
    [TestClass]
    public class DataManagerTest : VokabelCarsten.DataManager
    {

        private VokabelCarsten.VocabBox testBox = new VokabelCarsten.VocabBox("Test", "Englisch", "Deutsch", "Test.xml");
        private VokabelCarsten.VocabBox testBox2 = new VokabelCarsten.VocabBox("Test2", "Englisch2", "Deutsch2", "Test2.xml");
        public DataManagerTest()
        {
            testBox.addVokabel("Hallo", "Hello");
            testBox.addVokabel("Tschüss", "Bye");
            testBox2.addVokabel("Hallo", "Hello");
            testBox2.addVokabel("Tschüss", "Bye");
        }


        [TestMethod]
        public void SerializeTestVocabBox()
        {
            string result = xmlSerializer(ref testBox);
            Assert.AreEqual("<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n<VocabBox xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\r\n  <id>0</id>\r\n  <name>Test</name>\r\n  <spalte1>Englisch</spalte1>\r\n  <spalte2>Deutsch</spalte2>\r\n  <Vokabeln>\r\n    <Vocab>\r\n      <Question>Hallo</Question>\r\n      <Answer>Hello</Answer>\r\n      <level>0</level>\r\n      <id>0</id>\r\n    </Vocab>\r\n    <Vocab>\r\n      <Question>Tschüss</Question>\r\n      <Answer>Bye</Answer>\r\n      <level>0</level>\r\n      <id>1</id>\r\n    </Vocab>\r\n  </Vokabeln>\r\n  <filePath>Test.xml</filePath>\r\n</VocabBox>", result);
        }

        [TestMethod]
        public void SerializeTestVocabBoxList()
        {
            List<VokabelCarsten.VocabBox> testList = new List<VokabelCarsten.VocabBox>();
            testList.Add(testBox);
            testList.Add(testBox2);
            string result = xmlSerializer(ref testList);
            Assert.AreEqual("<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n<ArrayOfVocabBox xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\r\n  <VocabBox>\r\n    <id>0</id>\r\n    <name>Test</name>\r\n    <spalte1>Englisch</spalte1>\r\n    <spalte2>Deutsch</spalte2>\r\n    <Vokabeln>\r\n      <Vocab>\r\n        <Question>Hallo</Question>\r\n        <Answer>Hello</Answer>\r\n        <level>0</level>\r\n        <id>0</id>\r\n      </Vocab>\r\n      <Vocab>\r\n        <Question>Tschüss</Question>\r\n        <Answer>Bye</Answer>\r\n        <level>0</level>\r\n        <id>1</id>\r\n      </Vocab>\r\n    </Vokabeln>\r\n    <filePath>Test.xml</filePath>\r\n  </VocabBox>\r\n  <VocabBox>\r\n    <id>0</id>\r\n    <name>Test2</name>\r\n    <spalte1>Englisch2</spalte1>\r\n    <spalte2>Deutsch2</spalte2>\r\n    <Vokabeln>\r\n      <Vocab>\r\n        <Question>Hallo</Question>\r\n        <Answer>Hello</Answer>\r\n        <level>0</level>\r\n        <id>0</id>\r\n      </Vocab>\r\n      <Vocab>\r\n        <Question>Tschüss</Question>\r\n        <Answer>Bye</Answer>\r\n        <level>0</level>\r\n        <id>1</id>\r\n      </Vocab>\r\n    </Vokabeln>\r\n    <filePath>Test2.xml</filePath>\r\n  </VocabBox>\r\n</ArrayOfVocabBox>", result);
        }

        [TestMethod]
        public void DeserializeTestVocabBox()
        {
            VokabelCarsten.VocabBox result = xmlDeserialize(ref testBox, "<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n<VocabBox xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\r\n  <id>0</id>\r\n  <name>Test</name>\r\n  <spalte1>Englisch</spalte1>\r\n  <spalte2>Deutsch</spalte2>\r\n  <Vokabeln>\r\n    <Vocab>\r\n      <side1>Hallo</side1>\r\n      <side2>Hello</side2>\r\n      <level>0</level>\r\n      <id>0</id>\r\n    </Vocab>\r\n    <Vocab>\r\n      <side1>Tschüss</side1>\r\n      <side2>Bye</side2>\r\n      <level>0</level>\r\n      <id>1</id>\r\n    </Vocab>\r\n  </Vokabeln>\r\n  <filePath>Test.xml</filePath>\r\n</VocabBox>");
            Assert.AreEqual(testBox, result);
        }

        [TestMethod]
        public void DeserializeTestVocabBoxList()
        {
            List<VokabelCarsten.VocabBox> testList = new List<VokabelCarsten.VocabBox>();
            testList.Add(testBox);
            testList.Add(testBox2);
            List<VokabelCarsten.VocabBox> result = xmlDeserialize(ref testList, "<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n<ArrayOfVocabBox xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\r\n  <VocabBox>\r\n    <id>0</id>\r\n    <name>Test</name>\r\n    <spalte1>Englisch</spalte1>\r\n    <spalte2>Deutsch</spalte2>\r\n    <Vokabeln>\r\n      <Vocab>\r\n        <side1>Hallo</side1>\r\n        <side2>Hello</side2>\r\n        <level>0</level>\r\n        <id>0</id>\r\n      </Vocab>\r\n      <Vocab>\r\n        <side1>Tschüss</side1>\r\n        <side2>Bye</side2>\r\n        <level>0</level>\r\n        <id>1</id>\r\n      </Vocab>\r\n    </Vokabeln>\r\n    <filePath>Test.xml</filePath>\r\n  </VocabBox>\r\n  <VocabBox>\r\n    <id>0</id>\r\n    <name>Test2</name>\r\n    <spalte1>Englisch2</spalte1>\r\n    <spalte2>Deutsch2</spalte2>\r\n    <Vokabeln>\r\n      <Vocab>\r\n        <side1>Hallo</side1>\r\n        <side2>Hello</side2>\r\n        <level>0</level>\r\n        <id>0</id>\r\n      </Vocab>\r\n      <Vocab>\r\n        <side1>Tschüss</side1>\r\n        <side2>Bye</side2>\r\n        <level>0</level>\r\n        <id>1</id>\r\n      </Vocab>\r\n    </Vokabeln>\r\n    <filePath>Test2.xml</filePath>\r\n  </VocabBox>\r\n</ArrayOfVocabBox>");
            Assert.AreEqual(testList, result);
        }


        [TestMethod]
        public void getVocabBoxListTest()
        {
            staticDataManager.removeAllVocabBoxes();
            List<VokabelCarsten.VocabBox> testList = VokabelCarsten.DataManager.staticDataManager.getVocabBoxList();
            List<VokabelCarsten.VocabBox> testList2 = new List<VokabelCarsten.VocabBox>();
            CollectionAssert.AreEqual(testList, testList2);
        }

        [TestMethod]
        public void getVocabBoxListAsArrayTest()
        {
            staticDataManager.removeAllVocabBoxes();
            VokabelCarsten.VocabBox[] testArray = VokabelCarsten.DataManager.staticDataManager.getVocabBoxArray();
            VokabelCarsten.VocabBox[] testArray2 = new VokabelCarsten.VocabBox[0];
            CollectionAssert.AreEqual(testArray2, testArray);
        }

        [TestMethod]
        public void selectVocabBoxTest()
        {
            staticDataManager.removeAllVocabBoxes();
            staticDataManager.CreateVocabBox(testBox);
            staticDataManager.CreateVocabBox(testBox2);
            staticDataManager.selectVocabBox(0, true);
            Assert.AreEqual(testBox.getName(), staticDataManager.getVocabBoxList()[staticDataManager.loadedBox].getName());
            staticDataManager.selectVocabBox(1, true);
            Assert.AreEqual(testBox2.getName(), staticDataManager.getVocabBoxList()[staticDataManager.loadedBox].getName());
        }

        [TestMethod]
        public void removeVocabBoxTest()
        {
            staticDataManager.removeAllVocabBoxes();
            staticDataManager.CreateVocabBox(testBox);
            staticDataManager.CreateVocabBox(testBox2);
            staticDataManager.deleteVocabBox(0);
            staticDataManager.deleteVocabBox(0);
            List<VokabelCarsten.VocabBox> testList2 = new List<VokabelCarsten.VocabBox>();
            CollectionAssert.AreEqual(testList2, staticDataManager.getVocabBoxList());
        }
    }
}