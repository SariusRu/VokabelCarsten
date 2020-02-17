using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace VokabelCarsten.Classes
{
    class Control
    {
        #region Global Variables

        private string theGUI; //Change type to GUI-class name
        private List<VocabBox> vocabboxList = new List<VocabBox>();
        public enum Mode_t
        {
            Linear = 0,
            LinearLvl = 1,

            EndMode = 2

        }
        private Mode_t selectedLearningMode= Mode_t.Linear;
        private int selectedVocabBoxIdx = 0 ;
        private int vocabIdx = 0;



        public Control(string pGUI)
        {
            theGUI = pGUI;
            /*vocabboxList.Add(new VocabBox("Eng-De", "englisch", "deutsch"));
            vocabboxList.Add(new VocabBox("Ft-De", "französisch", "deutsch"));
            vocabboxList.Add(new VocabBox("Sp-De", "spansich", "deutsch")); 
            Dummy data for testing purposes*/
        }
        #endregion


        #region From GUI
        /// <summary>
        /// Handle for GUI to transfare vocab box name when selected.
        /// </summary>
        /// <param name="pName"></param>
        public void selectedBox(string pName)
        {
            int tempBoxIdx = convertBoxNametoBoxIdx(pName);
            if (tempBoxIdx >=0)
            {
                setActualVocabBox(tempBoxIdx);
            }
            else
            {
                //TO DO : show error message "Kasten not found"
            }
        }

        /// <summary>
        /// Handle Level, display next vocab and increase vocab index.
        /// </summary>
        /// <param name="known"></param>
        public void selectVocabCheck(bool known)
        {
            if (known == true) 
            {
                increaseVocabLvl();
            }
            else
            {
                decreaseVocabLvl();
            }

            increaseVocabIdx();
            displayVocabSide1();
 
        }

        /// <summary>
        /// Show vocab side 2
        /// </summary>
        public void selectShowVocabSide2()
        {
            displayVocabSide2();
        }

 
        /// <summary>
        /// Handle for GUI to transfare mode when selected.
        /// </summary>
        /// <param name="mode"></param>
        public void selectedMode(Mode_t mode)
        {
            setLearnMode(mode);
            //GUI Learn mode 1 muss geöffnet werden
            displayVocabSide1();

        }

        #endregion

        #region Convert From GUI
        /// <summary>
        /// Searches for matching string in vocabBoxlist an returns list index.
        /// </summary>
        /// <param name="pName"></param>
        /// <returns>List Index or -1 if not found</returns>
        public int convertBoxNametoBoxIdx(string pName)
        {
            int findListIdx = 0;
            foreach (VocabBox tempVocabBox in vocabboxList)
            {
               if (String.Equals(tempVocabBox.getName(), pName))
                {
                    return findListIdx;
                }
               else
                {
                    findListIdx++;
                }
            }


            return -1; //String does not match listelement
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
            vocabboxList.Add(new VocabBox(pName, pColumn1, pColumn2));
            //theGUI.appendTB_outputText("New Vocab Box " + pName + " added.");
            vocabboxList.Add(new VocabBox("test", "to find items", "in between beginning and end"));     
        }

        public void deleteBox(int pID)
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
        
        /// <summary>
        /// Call if a vocabBox is selected for learning.
        /// </summary>
        /// <param name="vocabBoxListIdx"></param>
        public void setActualVocabBox(int vocabBoxListIdx)
        {
            selectedVocabBoxIdx = vocabBoxListIdx;
        }        
        /// <summary>
        /// Call if lerning mode is selected.
        /// </summary>
        /// <param name="mode"></param>
        public void setLearnMode(Mode_t mode)
        {
            if (mode >= 0 && mode <= Mode_t.EndMode)
            {
                selectedLearningMode = mode;
            }
            else
            {
                selectedLearningMode = Mode_t.Linear; //default mode is linear
            }

        }
        /// <summary>
        /// increase vocab index
        /// </summary>
        private void increaseVocabIdx()
        {
            vocabIdx++;
        }
        /// <summary>
        /// Display next vocab side 1
        /// </summary>
        public void displayVocabSide1()
        {
            Vocab vocab = vocabboxList[selectedVocabBoxIdx].getVokabel(vocabIdx);
            string vocabSide1 = vocab.side1;
            //string anzeigen   
            //TO DO sobald button gedrückt ist  diplay buttons inaktivieren bzw aktivieren
        }
        /// <summary>
        /// Display next vocab side 2
        /// </summary>
        public void displayVocabSide2()
        {
            Vocab vocab = vocabboxList[selectedVocabBoxIdx].getVokabel(vocabIdx);
            string vocabSide2 = vocab.side2;
            //string anzeigen TO DO sobald button gedrückt ist  diplay buttons inaktivieren bzw aktivieren
        }

        /// <summary>
        /// increase vocab level.
        /// </summary>
        public void increaseVocabLvl()
        {
            Vocab vocab = vocabboxList[selectedVocabBoxIdx].getVokabel(vocabIdx);
            vocab.increaseLevel();
        }

        /// <summary>
        /// decrease vocab level.
        /// </summary>
        public void decreaseVocabLvl()
        {
            Vocab vocab = vocabboxList[selectedVocabBoxIdx].getVokabel(vocabIdx);
            vocab.decreaseLevel();
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