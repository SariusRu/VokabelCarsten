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
        
        #endregion

        public Control(string pGUI) 
        {
            theGUI = pGUI;
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

        public void exit(Activity ActivityContext)
        {
            //What is the proper way to close this application?
            //
            storeData();
            ActivityContext.FinishAffinity(); // (On Android)
        }
    }
}