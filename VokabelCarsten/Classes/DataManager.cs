using System;
using System.Xml;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

//
//Diese Klasse wird das bereitstellen, laden und verwalten von Tabellen übernehmen.
//Der Konstructor wird beim Start eine Datei mit allen möglichen öffnen
//

namespace VokabelCarsten
{
    class DataManager
    {
        public static readonly DataManager _obj = new DataManager();

        private static readonly string vocabBoxList = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "vocabBoxes.csv");

        private string[,] vocabList = null;

        DataManager() {
            
        }


        private bool ReadVocabBoxesXML()
        {

            if(!File.Exists(vocabBoxList))
            {
                File.Create(vocabBoxList);
                return false;
            }
            else
            {
                using (XmlReader XmlReader = XmlReader.Create(vocabBoxList))
                {
                    return true;
                }
            }
           
        }

        public bool refreshVocabBoxes()
        {
            ReadVocabBoxesXML();
            return true;
        }

        public bool SaveVocabBoxesXML()
        {
            return true;
        }

        public bool ReadVocabsXML(int vocabBoxID)
        {
            return true;
        }

        public bool ReadVocabsXML(string name)
        {
            return true;
        }

        public bool SaveVocabsXML(int vocabBoxID)
        {
            return true;
        }

        public bool SaveVocabsXML(string name)
        {
            return true;
        }


    }
}