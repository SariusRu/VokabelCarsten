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

        public void createBox(string pName, string pColumn1, string pColumn2)
        {
            //kasten.VocabBox(pName, pColumn1, pColumn2);
        }

        public void deleteBox(int pID)
        {

        }

        public void renameBoxName(string pName, string pNameNew)
        {
            //kasten.setName(pNameNew);
        }

        public void renameBoxColumns(string pName, string pColumn1, string pColumn2)
        {
            //kasten.setColumn1(pColumn1);
            //kasten.setColumn2(pColumn2);
        }

        #endregion

        #region Vocab

        //How to identify Vokabel? By Name, ID, something different?

        public void createVocab(string pSide1, string pSide2, int pBox)
        {
            //vokabel.Vokabel(pSide1, pSide2, pBox);
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