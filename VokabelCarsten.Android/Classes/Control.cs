using Android.App;
using System;
using System.Collections.Generic;

namespace VokabelCarsten
{
    class Control
    {
        #region Global Variables

        private string theGUI; //Change type to GUI-class name
        private static List<VocabBox> vocabboxList = new List<VocabBox>();
        public enum Mode_t
        {
            Linear = 0,
            LinearLvl = 1,
            EndMode = 2

        }
        private static Mode_t selectedLearningMode = Mode_t.Linear;
        private static int selectedVocabBoxIdx = 0 ;
        private static int selectedVocabIdx = 0;

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
        /// Handle Level, display next vocab and increase vocab index.
        /// </summary>
        /// <param name="known"></param>
        public static void selectVocabCheck(bool known)
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
            displayVocabQuestion();
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

        /// <summary>
        /// Display next vocab side 1
        /// </summary>
        public static string displayVocabQuestion()
        {
            //Does Control know class Vocab? Might be better to directly extract side1 without storing a complete object
            Vocab vocab = vocabboxList[selectedVocabBoxIdx].getVokabel(selectedVocabIdx);
            return vocab.side1;
        }

        /// <summary>
        /// Display next vocab side 2
        /// </summary>
        public static string displayVocabAnswer()
        {
            //Does Control know class Vocab? Might be better to directly extract side2 without storing a complete object
            Vocab vocab = vocabboxList[selectedVocabBoxIdx].getVokabel(selectedVocabIdx);
            return vocab.side2;
        }

        #endregion

        #region VocabBox

        /// <summary>
        /// Adds new Vocab Box to the list, handing over params to Vocab Box class constructor to create new Vocab Box.
        /// </summary>
        /// <param name="pName"></param>
        /// <param name="pColumn1"></param>
        /// <param name="pColumn2"></param>
        public static void createVocabelKasten(string pName, string pColumn1, string pColumn2)
        {
            string filepath = ""; //Need to generate safe location of JSON file
            //Need to check if pName is already existing
            vocabboxList.Add(new VocabBox(pName, pColumn1, pColumn2, filepath));
            //theGUI.appendTB_outputText("New Vocab Box " + pName + " added.");  
        }
        
        public static List<VocabBox> GetVocabBoxes()
        {
            return vocabboxList;
        }

        public static VocabBox getCurrentVocabBox()
        {
            if (selectedVocabBoxIdx >= 0 && selectedVocabBoxIdx < vocabboxList.Count)
            {
                return vocabboxList[selectedVocabBoxIdx];
            }
            else
            {
                return null;
            }
        }

        public static void editVocabBox(string Name, string Column1, string Column2)
        {
            vocabboxList[selectedVocabBoxIdx].name = Name;      
            vocabboxList[selectedVocabBoxIdx].column1 = Name;      
            vocabboxList[selectedVocabBoxIdx].column2 = Name;      
        }


        public static void deleteCurrentVocabBox()
        {
            vocabboxList.RemoveAt(selectedVocabBoxIdx);
        }
        #endregion

        #region Vocab
        public static void setSelectedVocabel(int SelectedVokabelIdx)
        {
            selectedVocabIdx = SelectedVokabelIdx;
        }

        public static Vocab getVocab()
        {
            if(getCurrentVocabBox() != null & selectedVocabIdx >= 0)
            {               
                if (selectedVocabIdx < getCurrentVocabBox().Vokabeln.Count)
                {
                    return getCurrentVocabBox().Vokabeln[selectedVocabIdx];
                }
            }
            return null;
        }

        public static void createVocab(string Side1, string Side2)
        {
            vocabboxList[selectedVocabBoxIdx].addVokabel(Side1, Side2);
        }

        public static void deleteVocab()
        {
            vocabboxList[selectedVocabBoxIdx].removeVokabel(selectedVocabIdx);
        }

        public static void editVokab(string pSide1, string pSide2)
        {
            vocabboxList[selectedVocabBoxIdx].changeVokabel(selectedVocabIdx, pSide1, pSide2);
        }

        public static List<Vocab> getCurrentVokabelList()
        {
            return vocabboxList[selectedVocabBoxIdx].Vokabeln;
        }

        #endregion

        #region Learning
        
        /// <summary>
        /// Call if a vocabBox is selected for learning.
        /// </summary>
        /// <param name="vocabBoxListIdx"></param>
        public static void setSelectedVocabBox(int vocabBoxListIdx)
        {
            selectedVocabBoxIdx = vocabBoxListIdx;
        }    
        
        /// <summary>
        /// Call if lerning mode is selected.
        /// </summary>
        /// <param name="mode"></param>
        public static void setLearnMode(Mode_t mode)
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
        private static void increaseVocabIdx()
        {
            selectedVocabIdx++;
        }

        //Moved display-methods to region "To GUI" as they are directly communicating from Control to GUI

        /// <summary>
        /// increase vocab level.
        /// </summary>
        public static void increaseVocabLvl()
        {
            //Does Control know class Vocab? Might be better to directly increase level without storing a complete object
            Vocab vocab = vocabboxList[selectedVocabBoxIdx].getVokabel(selectedVocabIdx);
            vocab.increaseLevel();
        }

        /// <summary>
        /// decrease vocab level.
        /// </summary>
        public static void decreaseVocabLvl()
        {
            //Does Control know class Vocab? Might be better to directly decrease without storing a complete object
            Vocab vocab = vocabboxList[selectedVocabBoxIdx].getVokabel(selectedVocabIdx);
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
        public void exit(Activity contextActivity)
        {
            //What is the proper way to close this application?
            contextActivity.FinishAffinity();
        }
    }
}
