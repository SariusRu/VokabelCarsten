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

        #endregion

        public Control(string pGUI)
        {
            theGUI = pGUI;
            /*vocabboxList.Add(new VocabBox("Eng-De", "englisch", "deutsch"));
            vocabboxList.Add(new VocabBox("Ft-De", "französisch", "deutsch"));
            vocabboxList.Add(new VocabBox("Sp-De", "spansich", "deutsch")); 
            Dummy data for testing purposes*/
        }

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

        /// <summary>
        /// Takes Vocab Box List and hands every name of boxes to the GUI to display all Vocab Box names.
        /// </summary>
        public void printAllBoxes()
        {
            /*theGUI.appendTB_outputText("List of saved Vocab Boxes
            for (int i = 0; i < vocabboxList.Count; i)
            {
                theGUI.appendTB_outputText(vocabboxList[i].name);
            }*/
        }

        /// <summary>
        /// Adds new Vocab Box to the list, handing over params to Vocab Box class constructor to create new Vocab Box.
        /// </summary>
        /// <param name="pName"></param>
        /// <param name="pColumn1"></param>
        /// <param name="pColumn2"></param>
        public void createBox(string pName, string pColumn1, string pColumn2)
        {
            string filepath = ""; //Need to generate safe location of JSON file
            //Need to check if pName is already existing
            vocabboxList.Add(new VocabBox(pName, pColumn1, pColumn2, filepath));
            //theGUI.appendTB_outputText("New Vocab Box " + pName + " added.");  
        }

        /// <summary>
        /// Takes name of a Vocab Box given by GUI, searches the Vocab Box List and deletes the object with matching name.
        /// Return on error to be done.
        /// </summary>
        /// <param name="pName"></param>
        public void deleteBox(string pName)
        {
            int index = vocabboxList.IndexOf(vocabboxList.Find(item => item.name == pName));
            if (index == -1)
            {
                //theGUI.appendTB_outputText("Vocab Box " + pName + " not found.");
                return;
            }
            vocabboxList.RemoveAt(index); 
            //theGUI.appendTB_outputText("Vocab Box " + pName + " deleted.");
        }

        /// <summary>
        /// Takes name of a Vocab Box given by GUI, searches the Vocab Box List and renames the object with matching name.
        /// Return on error to be done.
        /// </summary>
        /// <param name="pName"></param>
        /// <param name="pNameNew"></param>
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

        /// <summary>
        /// Takes name of a Vocab Box given by GUI, searches the Vocab Box List and renames columns of the object with matching name.
        /// Return on error to be done.
        /// </summary>
        /// <param name="pName"></param>
        /// <param name="pColumn1"></param>
        /// <param name="pCOlumn2"></param>
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

        /// <summary>
        /// Hands over the params to the given Vocab Box to create a new Vocab.
        /// Return on error to be done.
        /// </summary>
        /// <param name="pID"></param>
        /// <param name="pBox"></param>
        /// <param name="pSide1"<>/param>
        /// <param name="pSide2"></param>
        public void createVocab(int pID, int pBox, string pSide1, string pSide2)
        {
            //Need to check if pID is already existing            
        }

        /// <summary>
        /// Hands over the pID to the given Vocab Box to remave the Vocab identified by pID.
        /// Return on error to be done.
        /// </summary>
        /// <param name="pID"></param>
        /// <param name="pBox"></param>
        public void rmVocab(int pID, int pBox)
        {

        }

        /// <summary>
        /// Hands over the params to the given Vocab Box to cahnge a new Vocab.
        /// Return on error to be done.
        /// </summary>
        /// <param name="pID"></param>
        /// <param name="pBox"></param>
        /// <param name="pSide1"<>/param>
        /// <param name="pSide2"></param>
        /// <param name="pLevel"></param>
        public void changeVokabel(int pID, int pBox, string pSide1, string pSide2, int pLevel)
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

        /// <summary>
        /// To be done.
        /// </summary>
        public void loadData()
        { 
        
        }

        /// <summary>
        /// To be done.
        /// </summary>
        public void storeData()
        { 
        
        }

        #endregion

        /// <summary>
        /// To be done.
        /// </summary>
        public void exit()
        {
            //What is the proper way to close this application?
        }
    }
}