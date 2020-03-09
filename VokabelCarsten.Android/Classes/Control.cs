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
        private static int selectedVocabBoxIdx = 0;
        private static int selectedVocabIdx = 0;

        #endregion
        
        #region From GUI

        /// <summary>
        /// Handle Level, decrease and increase
        /// </summary>
        /// <param name="known">Select if the Vocable was known</param>
        public static void SelectVocabCheck(bool known)
        {
            if (known == true) 
            {
                IncreaseVocabLvl();
            }
            else
            {
                DecreaseVocabLvl();
            }
            IncreaseVocabIdx();
        }
        #endregion

        #region To GUI

        /// <summary>
        /// Display the Vocabel Question
        /// </summary>
        /// <returns>returns the Question</returns>
        public static string DisplayVocabQuestion()
        {
            //Get Vocab
            Vocab vocab = DataManager.staticDataManager.getVocabBoxList()[DataManager.staticDataManager.loadedBox].getVokabel(selectedVocabIdx);
            if (vocab != null)
            {
                return vocab.Question;
            }
            else
            {
                return "No More Vokable Found";
            }
        }

        /// <summary>
        /// Display Vocabel Answer
        /// </summary>
        public static string DisplayVocabAnswer()
        {
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
        /// <param name="Name">Name of the Box</param>
        /// <param name="Native">Name of the Native Column</param>
        /// <param name="Foreign">Name of the Foreign Column</param>
        public static void CreateVocabBox(string Name, string Native, string Foreign)
        {
            string filepath = Name + ".xml"; //ToDo: Need to generate safe location of JSON file
            DataManager.staticDataManager.CreateVocabBox(new VocabBox(Name, Native, Foreign, filepath));  
        }
        
        /// <summary>
        /// Returns the VocabBox List
        /// </summary>
        /// <returns>Vocab Box List</returns>
        public static List<VocabBox> GetVocabBoxes()
        {
            return DataManager.staticDataManager.getVocabBoxList();
        }

        /// <summary>
        /// Returns the Current selected Vocab Box
        /// </summary>
        /// <returns>Selected Vocab Box</returns>
        public static VocabBox GetCurrentVocabBox()
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

        /// <summary>
        /// Edit/Update the Current selected Vocab Box
        /// </summary>
        /// <param name="Name">Name of the Box</param>
        /// <param name="Column1">Native Column</param>
        /// <param name="Column2">Foreign Column</param>
        public static void EditVocabBox(string Name, string Column1, string Column2)
        {
            DataManager.staticDataManager.EditVocabBox(Name, Column1, Column2);      
        }

        /// <summary>
        /// Delete the Current selected Vocab Box
        /// </summary>
        public static void DeleteCurrentVocabBox()
        {
            DataManager.staticDataManager.deleteVocabBox(selectedVocabBoxIdx);
        }
        #endregion

        #region Vocab

        /// <summary>
        /// Set the current Selected Vocable ID
        /// </summary>
        /// <param name="SelectedVokabelIdx">Vocable ID</param>
        public static void SetSelectedVocab(int SelectedVokabelIdx)
        {
            selectedVocabIdx = SelectedVokabelIdx;
        }

        /// <summary>
        /// Return the Current selected Vocable
        /// </summary>
        /// <returns>the Selected Vocable</returns>
        public static Vocab GetVocab()
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
        /// Creates a Vocable
        /// </summary>
        /// <param name="Native">Native Translation</param>
        /// <param name="Foreign">Foreign Translation</param>
        public static void CreateVocab(string Native, string Foreign)
        {
            if (DataManager.staticDataManager.getVocabBoxList()[DataManager.staticDataManager.loadedBox] == null)
                throw new NullReferenceException();

            DataManager.staticDataManager.getVocabBoxList()[DataManager.staticDataManager.loadedBox].addVokabel(Native, Foreign);
        }

        /// <summary>
        /// Delete the Selected Vocable
        /// </summary>
        public static void DeleteVocab()
        {
            if (DataManager.staticDataManager.getVocabBoxList()[DataManager.staticDataManager.loadedBox] == null)
                throw new NullReferenceException();

            DataManager.staticDataManager.getVocabBoxList()[DataManager.staticDataManager.loadedBox].removeVokabel(selectedVocabIdx);
        }

        /// <summary>
        /// Edit the selected Vocable
        /// </summary>
        /// <param name="Native">Native Translation</param>
        /// <param name="Foreign">Foreign Translation</param>
        public static void EditVocab(string Native, string Foreign)
        {
            if (DataManager.staticDataManager.getVocabBoxList()[DataManager.staticDataManager.loadedBox] == null)
                throw new NullReferenceException();

            DataManager.staticDataManager.getVocabBoxList()[DataManager.staticDataManager.loadedBox].changeVokabel(selectedVocabIdx, Native, Foreign, 0);
        }

        /// <summary>
        /// Get the Current List of Vocables
        /// </summary>
        /// <returns>Vocable List of the Selected Box</returns>
        public static List<Vocab> GetCurrentVokabList()
        {
            if (DataManager.staticDataManager.getVocabBoxList()[DataManager.staticDataManager.loadedBox] == null)
                throw new NullReferenceException();

            return DataManager.staticDataManager.getVocabBoxList()[DataManager.staticDataManager.loadedBox].Vokabeln;
        }

        /// <summary>
        /// Set the Selected Vocable Box
        /// </summary>
        /// <param name="vocabBoxListIdx">Id of the Box</param>
        public static void SetSelectedVocabBox(int vocabBoxListIdx)
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

        #endregion

        #region Learning    

        /// <summary>
        /// Set the Learning Mode
        /// </summary>
        /// <param name="mode">Learnig Mode to be Used</param>
        public static void SetLearnMode(Mode_t mode)
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
        /// Increase the Selected vocab Index
        /// </summary>
        private static void IncreaseVocabIdx()
        {
            selectedVocabIdx++;
        }

        /// <summary>
        /// Increase the Vocab level
        /// </summary>
        public static void IncreaseVocabLvl()
        {
            if (GetVocab() == null)
                return;

            GetVocab().increaseLevel();
        }

        /// <summary>
        /// Decrease vocab level.
        /// </summary>
        public static void DecreaseVocabLvl()
        {
            if (GetVocab() == null)
                return;

            GetVocab().decreaseLevel();
        }

        #endregion

        /// <summary>
        /// To be done.
        /// </summary>
        public void Exit(Activity contextActivity)
        {
            contextActivity.FinishAffinity();
        }
    }
}
