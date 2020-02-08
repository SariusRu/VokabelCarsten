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

        public void selectedKasten(string pName)
        { 
        
        }

        public void selectedModus(string pName)
        {

        }

        #endregion

        #region To GUI

        #endregion

        #region Vokabelkasten

        //How to identify Kasten? By Name, ID, something different?

        public void createKasten(string pName, string pSpalte1, string pSpalte2)
        {
            //kasten.Vokabelkasten(pName, pSpalte1, pSpalte2);
        }

        public void deleteKasten(int pID)
        {

        }

        public void renameKastenName(string pName, string pNameNew)
        {
            //kasten.setName(pNameNew);
        }

        public void renameKastenSpalten(string pName, string pSpalte1, string pSpalte2)
        {
            //kasten.setSpalte1(pSpalte1);
            //kasten.setSpalrte2(pSpalte2);
        }

        #endregion

        #region Vokabel

        //How to identify Vokabel? By Name, ID, something different?

        public void createVokabel(string pSeite1, string pSeite2, int pKasten)
        {
            //vokabel.Vokabel(pSeite1, pSeite2, pKasten);
        }

        public void rmVokabel(int pID)
        {

        }

        public void changeVokabel(string pSeite1, string pSeite2, string pKasten, int pFach)
        {
            /*vokabel.setSeite1(pSeite1);
            vokabel.setSeite2(pSeite2);
            vokabel.setFach(pFach);*/
        }

        #endregion

        #region Learning

        public void lernen(string pKasten, string pModus)
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