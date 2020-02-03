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

        public static readonly string vocabBoxList = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "vocabBoxes.csv");
        public void Display()
        {
            Console.WriteLine(true);
        }
        DataManager() {
            
        }


        public bool ReadVocabXML()
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



    }
}