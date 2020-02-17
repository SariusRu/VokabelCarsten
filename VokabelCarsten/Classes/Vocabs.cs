using System;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

// von betti

namespace VokabelCarsten
{
    [Serializable]
    public class Vocab
    {
        public string side1 { get; set; }       //Vocab on side 1 e.g. "to walk2
        public string side2 { get; set; }       // Vocab on side 2 e.g."laufen"
        public int level { get; set; } = 0;
        public int id { get; set; }

        public Vocab()
        {

        }

        public Vocab(string si1, string si2, int ID)   //Konstruktor
        {
            side1 = si1;
            side2 = si2;
            id = ID;
        }


        public void EditVocab(string si1, string si2, int lev)
        {
            side1 = si1;
            side2 = si2;
            level = lev;
        }

        public void SetLevel(int lev)
        {
            level = lev;
        }

        public int GetLevel()
        {
            return level;
        }

        public void increaseLevel()
        {
            if (level == 0)
            { }
            else { level--; }
        }

        public void decreaseLevel()
        {
            if (level == 6) { }
            else { level++; }

        }
    }
}