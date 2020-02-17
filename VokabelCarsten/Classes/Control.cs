using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VokabelCarsten
{
    class Control
    {
        #region Global Variables

        private string theGUI; //change back to GUI type
        private List<VocabBox> vocabboxList = new List<VocabBox>();

        #endregion

        public Control(string pGUI)
        {
            theGUI = pGUI;
            /*vocabboxList.Add(new VocabBox("Eng-De", "englisch", "deutsch", "EngDe.xml"));
            vocabboxList.Add(new VocabBox("Ft-De", "französisch", "deutsch", "FtDe.xml"));
            vocabboxList.Add(new VocabBox("Sp-De", "spansich", "deutsch", "SpDe.xml"));
            Dummy data for testing purposes*/
        }

        #region From GUI

        public void selectedBox(string pName)
        {

        }

        public void selectedMode(string pName)
        {

        }

        #endregion

        #region To GUI

        #endregion

        #region VocabBox

        //How to identify Kasten? By Name, ID, something different?

        public void printAllBoxes()
        {
            /*theGUI.appendTB_outputText("List of saved Vocab Boxes
            for (int i = 0; i < vocabboxList.Count; i)
            {
                theGUI.appendTB_outputText(vocabboxList[i].name);
            }*/
        }

        public void createBox(string pName, string pColumn1, string pColumn2)
        {
            vocabboxList.Add(new VocabBox(pName, pColumn1, pColumn2, "test.xml"));
            //theGUI.appendTB_outputText("New Vocab Box " + pName + " added.");
            vocabboxList.Add(new VocabBox("test", "to find items", "in between beginning and end", "test.xml"));
        }

        public void deleteBox(string pName)
        {
            int index = vocabboxList.IndexOf(vocabboxList.Find(item => item.name == pName));
            if (index == -1)
            {
                //theGUI.appendTB_outputText("Vocab Box " + pName + " not found.");
                return;
            }
            vocabboxList.RemoveAt(index); //If we choose to identify by ID and ID is the list index 
            //IF ID is equal to the index, the IDs of all items have to be adjusted
            //theGUI.appendTB_outputText("Vocab Box " + pName + " deleted.");
        }

        public void renameBoxName(string pName, string pNameNew)
        {
            int index = vocabboxList.IndexOf(vocabboxList.Find(item => item.name == pName));
            if (index == -1)
            {
                //theGUI.appendTB_outputText("Vocab Box " + pName + " not found.");
                return;
            }
            vocabboxList[index].name = pNameNew;
          
            //theGUI.appendTB_outputText("Vocab Box name " + pName + " changed into " + pNameNew + ".");       
        }

        public void renameBoxColumns(string pName, string pColumn1, string pColumn2)
        {
            int index = vocabboxList.IndexOf(vocabboxList.Find(item => item.name == pName));
            if (index == -1)
            {
                //theGUI.appendTB_outputText("Vocab Box " + pName + " not found.");
                return;
            }
            vocabboxList[index].spalte1 = pColumn1;
            vocabboxList[index].spalte2 = pColumn2;
            //theGUI.appendTB_outputText("Vocab Box " + pName + ": columns changed into " + pColumn1 + " and " + pColumn2 + ".");        
        }

        #endregion

        #region Vocab

        //How to identify Vokabel? By Name, ID, something different?

        public void createVocab(string pSide1, string pSide2, int pBox)
        {
            /*How to proceed with Vocabs?
             Where/how are Vocabs generated? (VocabBox takes an existing Vocab and adds it to its list of Vocabularies,
             but giving VocabBox parameters and letting VocabBox generate the Vocab might be easier(?))
             If that is decided: How to find a specific Vocab inside the Vocab lsit?
             Searching bei Side 1 and Side 2 or by ID/name/whatever?*/
        }

        public void rmVocab(int pID)
        {

        }

        public void changeVokabel(string pSide1, string pSide2, string pBox, int pLevel)
        {
            /*vokabel.setSide1(pSide1);
            vokabel.setSide2(pSide2);
            vokabel.setLevel(pLevel);*/
        }

        #endregion

        #region Learning

        public void startLearning(string pBox, string pMode)
        {

        }

        #endregion

        #region DataManager

        public void loadData()
        {

        }

        public void storeData()
        {

        }

        #endregion

        public void exit()
        {
            //What is the proper way to close this application?
        }
    }
}
