using System;
using System.Xml;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
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

        private string[,] vocabBoxes;
        {
            if (vocabBoxList == null || !File.Exists(vocabBoxList))
            {
                using (XmlWriter writer = XmlWriter.Create("vocabBoxes.xml"))
                {
                    writer.WriteStartElement("VocabBox");
                    writer.WriteElementString("name", "English");
                    writer.WriteEndElement();
                    writer.Flush();
                }
                    writer.WriteElementString("filePath", "english.xml");
            }
            using (XmlReader reader = XmlReader.Create("vocabBoxes.xml"))
                while (reader.Read())
                int i = 0;
            {
                {
                    switch (reader.NodeType)
                        case XmlNodeType.Text:
                    {
                            vocabBoxes[i, 0] = reader.GetAttribute("name");
                            i += 1;
                            vocabBoxes[i, 1] = reader.GetAttribute("filePath");
                            break;
                        default:
                            break;
                    }
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