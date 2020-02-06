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
    class VocabBox
    {
        private int ID { get; set; }
        private string name { get; set; }       //Vocab on side 1 e.g. "to walk2
        private string filePath { get; set; }
        private string side1Name { get; set; }
        private string side2Name { get; set; }
        private Vocab[] Vokablen { get; set; }

        public string getName()
        {
            return name;
        }

        public void setName(string newName)
        {
            name = newName;
        }

        public void setFilePath(string newFilepath)
        {
            filePath = newFilepath;
        }
    }
}