using Android.App;
using System;
using System.Collections.Generic;

namespace VokabelCarsten
{
    class Control
    {
        #region Global Variables

        private static List<VocabBox> vocabboxList = new List<VocabBox>();
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
        /// Handle Level, display next vocab and increase vocab index.
        /// </summary>
        /// <param name="known"></param>
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
        /// Display Vocabel Question
        /// </summary>
        /// <returns>returns the Question</returns>
        public static string DisplayVocabQuestion()
        {
            //Does Control know class Vocab? Might be better to directly extract side1 without storing a complete object
            Vocab vocab = vocabboxList[selectedVocabBoxIdx].GetVokabel(selectedVocabIdx);
            return vocab.Question;
        }

        /// <summary>
        /// Display Vocabel Answer Side
        /// </summary>
        public static string DisplayVocabAnswer()
        {
            //Does Control know class Vocab? Might be better to directly extract side2 without storing a complete object
            Vocab vocab = vocabboxList[selectedVocabBoxIdx].GetVokabel(selectedVocabIdx);
            return vocab.Answer;
        }

        #endregion

        #region VocabBox

        /// <summary>
        /// Adds new Vocab Box to the list, handing over params to Vocab Box class constructor to create new Vocab Box.
        /// </summary>
        /// <param name="Name">Name of the Box</param>
        /// <param name="Native">Name of the Native Column</param>
        /// <param name="Foreign">Name of the Foreign Column</param>
        public static void CreateVocabelKasten(string Name, string Native, string Foreign)
        {
            string filepath = ""; //ToDo: Need to generate safe location of JSON file
            vocabboxList.Add(new VocabBox(Name, Native, Foreign, filepath));  
        }
        
        /// <summary>
        /// Returns the VocabBox List
        /// </summary>
        /// <returns>Vocab Box List</returns>
        public static List<VocabBox> GetVocabBoxes()
        {
            return vocabboxList;
        }

        /// <summary>
        /// Returns the Current selected Vocab Box
        /// </summary>
        /// <returns>Selected Vocab Box</returns>
        public static VocabBox GetCurrentVocabBox()
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

        /// <summary>
        /// Edit/Update the Current selected Vocab Box
        /// </summary>
        /// <param name="Name">Name of the Box</param>
        /// <param name="Column1">Native Column</param>
        /// <param name="Column2">Foreign Column</param>
        public static void EditVocabBox(string Name, string Column1, string Column2)
        {
            vocabboxList[selectedVocabBoxIdx].name = Name;
            vocabboxList[selectedVocabBoxIdx].column1 = Column1;      
            vocabboxList[selectedVocabBoxIdx].column2 = Column2;      
        }

        /// <summary>
        /// Delete the Current selected Vocab Box
        /// </summary>
        public static void DeleteCurrentVocabBox()
        {
            vocabboxList.RemoveAt(selectedVocabBoxIdx);
        }
        #endregion

        #region Vocab

        /// <summary>
        /// Set the current Selected Vocable ID
        /// </summary>
        /// <param name="SelectedVokabelIdx">Vocable ID</param>
        public static void SetSelectedVocabel(int SelectedVokabelIdx)
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
                    return GetCurrentVocabBox().Vokabeln[selectedVocabIdx];
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
            if (GetCurrentVocabBox() == null)
                throw new NullReferenceException();

            GetCurrentVocabBox().AddVokabel(Native, Foreign);
        }

        /// <summary>
        /// Delete the Selected Vocable
        /// </summary>
        public static void DeleteVocab()
        {
            if (GetCurrentVocabBox() == null)
                throw new NullReferenceException();

            GetCurrentVocabBox().RemoveVokabel(selectedVocabIdx);
        }

        /// <summary>
        /// Edit the selected Vocable
        /// </summary>
        /// <param name="Native">Native Translation</param>
        /// <param name="Foreign">Foreign Translation</param>
        public static void EditVokab(string Native, string Foreign)
        {
            if (GetCurrentVocabBox() == null)
                throw new NullReferenceException();

            GetCurrentVocabBox().ChangeVokabel(selectedVocabIdx, Native, Foreign);
        }

        /// <summary>
        /// Get the Current List of Vocables
        /// </summary>
        /// <returns>Vocable List of the Selected Box</returns>
        public static List<Vocab> GetCurrentVokabelList()
        {
            if (GetCurrentVocabBox() == null)
                throw new NullReferenceException();

            return GetCurrentVocabBox().Vokabeln;
        }

        /// <summary>
        /// Set the Selected Vocable Box
        /// </summary>
        /// <param name="vocabBoxListIdx">Id of the Box</param>
        public static void SetSelectedVocabBox(int vocabBoxListIdx)
        {
            selectedVocabBoxIdx = vocabBoxListIdx;
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

        #region DataManager

        /// <summary>
        /// ToDo: To be done.
        /// </summary>
        public void LoadData()
        { 
        
        }

        /// <summary>
        /// ToDo: To be done.
        /// </summary>
        public void StoreData()
        { 
        
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
