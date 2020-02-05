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

        private static readonly string vocabFileList = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "vocabBoxes.xml");

        private string[,] vocabBoxes;

        public DataManager()
        {
            if (!readVocabList())
            {
                throw new FileNotReadException("File wasn't read properly");
            }
            
        }

        private bool readVocabList()
        {
            if (vocabFileList == null || !File.Exists(vocabFileList))
            {
                using (XmlWriter writer = XmlWriter.Create("vocabBoxes.xml"))
                {
                    writer.WriteStartElement("VocabBox");
                    writer.WriteElementString("name", "English");
                    writer.WriteElementString("filePath", "english.xml");
                    writer.WriteEndElement();
                    writer.Flush();
                    return true;
                }

            }
            else
            {
                using (XmlReader reader = XmlReader.Create("vocabBoxes.xml"))
                {
                    int i = 0;
                    while (reader.Read())
                    {
                        switch (reader.NodeType)
                        {
                            case XmlNodeType.Text:
                                vocabBoxes[i, 0] = reader.GetAttribute("name");
                                i += 1;
                                vocabBoxes[i, 1] = reader.GetAttribute("filePath");
                                return true;
                            default:
                                return false;
                        }

                    }
                    return false;
                }
            }
        }

        public bool refreshVocabBoxes()
        {
            if (!readVocabList())
            {
                throw new FileNotReadException("File wasn't read properly");
            }
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