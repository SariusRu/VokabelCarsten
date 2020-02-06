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

        private VocabBox[] vocabBoxes;

        private int? loadedBox;
        private string[,,] loadedVocabes;

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
                    //Debug Purpose. Creates a readable file.
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
                    while (reader.Read())
                    {
                        switch (reader.NodeType)
                        {
                            case XmlNodeType.Text:
                                //vocabBoxes[i, 0] = reader.GetAttribute("name");
                                //i += 1;
                                //vocabBoxes[i, 1] = reader.GetAttribute("filePath");
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
            loadedBox = null;
            loadedVocabes = null;
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

        public bool CreateVocabBox(string name)
        {
            foreach (VocabBox item in vocabBoxes)
            {
                if (item.getName() == name)
                {
                    throw new VocabBoxAlreadyExists("A Vocabbox with this name already exists.");
                }
            }

            List<VocabBox> tmpVocabBoxesLsit = vocabBoxes.ToList();
            VocabBox tmp = new VocabBox();
            tmp.setName(name);
            tmp.setFilePath(Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "vocabBox_" + name + ".xml"));
            tmpVocabBoxesLsit.Add(tmp);
            vocabBoxes = tmpVocabBoxesLsit.ToArray();
            return true;
        }


    }
}