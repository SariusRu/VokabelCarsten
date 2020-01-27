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

//
//Diese Klasse wird das bereitstellen, laden und verwalten von Tabellen übernehmen.
//Der Konstructor wird beim Start eine Datei mit allen möglichen öffnen
//

namespace VokabelCarsten.Classes
{
    class DataManager
    {
        public static readonly DataManager _obj = new DataManager();

        public static readonly string vocabBoxList = "/data/data/com.DHBW_SoftEng.vokabelcarsten/vocabBoxes.csv";
        public void Display()
        {
            Console.WriteLine(true);
        }
        DataManager() { }

        //Read File to get list of all VocabBoxes

    }
}