using Android.App;
using System;
using System.Collections.Generic;

namespace VokabelCarsten
{
    class Control
    {
        #region Global Variables

        //private static List<VocabBox> vocabboxList = new List<VocabBox>();
        public enum Mode_t
        {
            Linear = 0,
            LinearLvl = 1,
            EndMode = 2

        }
        private static Mode_t selectedLearningMode = Mode_t.Linear;
        private static int selectedVocabBoxIdx = 0 ;
        private static int selectedvocabIdx = -1;

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
            if (selectedvocabIdx != -1)
            {
                if (known == true)
                {
                    increaseVocabLvl();
                }
                else
                {
                    decreaseVocabLvl();
                }
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
            Vocab vocab = DataManager.staticDataManager.getVocabBoxList()[DataManager.staticDataManager.loadedBox].getVokabel(selectedVocabIdx);
            if (vocab != null)
            {
                return vocab.Question;
            }
            else
            {
                return "Keine Vokabeln vorhanden!";
            }

        }

        /// <summary>
        /// Display next vocab side 2
        /// </summary>
        public static string displayVocabAnswer()
        {
            //Does Control know class Vocab? Might be better to directly extract side2 without storing a complete object
            Vocab vocab = DataManager.staticDataManager.getVocabBoxList()[DataManager.staticDataManager.loadedBox].getVokabel(selectedVocabIdx);
            if (vocab != null)
            {
                return vocab.Answer;
            }
            else
            {
                return "No More Vokable Found";
            }
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
            string filepath = pName + ".xml"; //Need to generate safe location of JSON file
            //Need to check if pName is already existing
            DataManager.staticDataManager.CreateVocabBox(new VocabBox(pName, pColumn1, pColumn2, filepath));
            //vocabboxList.Add(new VocabBox(pName, pColumn1, pColumn2, filepath));
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
        /// Takes Vocab Box List and hands every name of boxes to the GUI to display all Vocab Box names.
        /// </summary>
        public void printAllBoxes()
        {
            if (selectedVocabBoxIdx >= 0 && selectedVocabBoxIdx < DataManager.staticDataManager.getVocabBoxList().Count)
            {
                //DataManager.staticDataManager.selectVocabBox(selectedVocabBoxIdx);
                return DataManager.staticDataManager.getVocabBoxList()[DataManager.staticDataManager.loadedBox];
            }
            else
            {
                return null;
            }
        }

        public static List<VocabBox> GetVocabBoxes()
        {
            return DataManager.staticDataManager.getVocabBoxList();
        }

        /// <summary>
        /// Takes name of a Vocab Box given by GUI, searches the Vocab Box List and renames the object with matching name.
        /// Return on error to be done.
        /// </summary>
        /// <param name="pName"></param>
        /// <param name="pNameNew"></param>
        public void renameBoxName(string pName, string pNameNew)
        {
            DataManager.staticDataManager.EditVocabBox(Name, Column1, Column2);      
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
        /// <param name="pBox"></param>
        /// <param name="pSide1"<>/param>
        /// <param name="pSide2"></param>
        public static void createVocab(int pBox, string pSide1, string pSide2)
        {
            vocabboxList[pBox].addVokabel(pSide1, pSide2);           
        }

        public static void createVocab(string pSide1, string pSide2)
        {
            if(GetCurrentVocabBox() != null & selectedVocabIdx >= 0)
            {               
                if (selectedVocabIdx < GetCurrentVocabBox().Vokabeln.Count)
                {
                    return DataManager.staticDataManager.getVocabBoxList()[DataManager.staticDataManager.loadedBox].Vokabeln[selectedVocabIdx];
                }
            }
            return null;
        }

        /// <summary>
        /// Hands over the pID to the given Vocab Box to remave the Vocab identified by pID.
        /// Return on error to be done.
        /// </summary>
        /// <param name="pID"></param>
        /// <param name="pBox"></param>
        public void rmVocab(int pID, int pBox)
        {
            if (DataManager.staticDataManager.getVocabBoxList()[DataManager.staticDataManager.loadedBox] == null)
                throw new NullReferenceException();

            DataManager.staticDataManager.getVocabBoxList()[DataManager.staticDataManager.loadedBox].addVokabel(Native, Foreign);
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
            if (DataManager.staticDataManager.getVocabBoxList()[DataManager.staticDataManager.loadedBox] == null)
                throw new NullReferenceException();

            DataManager.staticDataManager.getVocabBoxList()[DataManager.staticDataManager.loadedBox].removeVokabel(selectedVocabIdx);
        }

        public static List<Vocab> getCurrentVokabelList()
        {
            if (DataManager.staticDataManager.getVocabBoxList()[DataManager.staticDataManager.loadedBox] == null)
                throw new NullReferenceException();

            DataManager.staticDataManager.getVocabBoxList()[DataManager.staticDataManager.loadedBox].changeVokabel(selectedVocabIdx, Native, Foreign, 0);
        }

        /// <summary>
        /// Get the Current List of Vocables
        /// </summary>
        /// <returns>Vocable List of the Selected Box</returns>
        public static List<Vocab> GetCurrentVokabelList()
        {
            if (DataManager.staticDataManager.getVocabBoxList()[DataManager.staticDataManager.loadedBox] == null)
                throw new NullReferenceException();

            return DataManager.staticDataManager.getVocabBoxList()[DataManager.staticDataManager.loadedBox].Vokabeln;
        }

        /// <summary>
        /// Call if a vocabBox is selected for learning.
        /// </summary>
        /// <param name="vocabBoxListIdx"></param>
        /// 
        public static void setSelectedVocabBox(int vocabBoxListIdx)
        {
            if(vocabBoxListIdx != -1)
            {
                DataManager.staticDataManager.selectVocabBox(vocabBoxListIdx);
                selectedVocabBoxIdx = vocabBoxListIdx;
            }
            else
            {
                selectedVocabBoxIdx = vocabBoxListIdx;
            }
           
        }
        
        public static string getVocabBoxTitle()
        {
            return DataManager.staticDataManager.loadedBox.getName();
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
            selectedvocabIdx++;
        }

        //Moved display-methods to region "To GUI" as they are directly communicating from Control to GUI

        /// <summary>
        /// increase vocab level.
        /// </summary>
        public static void increaseVocabLvl()
        {
            //Does Control know class Vocab? Might be better to directly increase level without storing a complete object
            //Vocab vocab = vocabboxList[selectedVocabBoxIdx].getVokabel(selectedvocabIdx);
            //vocab.increaseLevel();
            DataManager.staticDataManager.loadedBox.increaseVocabLevel(selectedvocabIdx);
        }

        /// <summary>
        /// decrease vocab level.
        /// </summary>
        public static void decreaseVocabLvl()
        {
            //Does Control know class Vocab? Might be better to directly decrease without storing a complete object
            //Vocab vocab = vocabboxList[selectedVocabBoxIdx].getVokabel(selectedvocabIdx);
            //vocab.decreaseLevel();
            DataManager.staticDataManager.loadedBox.decreaseVocabLevel(selectedvocabIdx);
        }

        #endregion

        #region DataManager

        /// <summary>
        /// To be done.
        /// </summary>
        public void loadData()
        {
            DataManager.staticDataManager.refreshVocabBoxes();
        }

        /// <summary>
        /// To be done.
        /// </summary>
        public void storeData()
        {
            DataManager.staticDataManager.SaveVocabBoxesXML();
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
