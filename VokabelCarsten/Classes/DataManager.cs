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
using System.Threading.Tasks;
using System.Xml.Linq;

//
//Diese Klasse wird das bereitstellen, laden und verwalten von Tabellen übernehmen.
//Der Konstructor wird beim Start eine Datei mit allen möglichen öffnen
//

namespace VokabelCarsten
{
    class DataManager
    {
        public static readonly DataManager _obj = new DataManager();

        private static readonly string vocabFileList = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "vocabBoxes.xml");

        private VocabBox[] vocabBoxes;

        private int loadedBox;
        private string[,,] loadedVocabes;

        public string status = null;

        public DataManager()
        {
            //if (!readVocabList())
            //{
            //    throw new FileNotReadException("File wasn't read properly");
            //}
            readVocabListAsync();
        }


        async Task TestWriter()
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Async = true;

            using (XmlWriter writer = XmlWriter.Create(vocabFileList, settings))
            {
                await writer.WriteStartElementAsync("pf", "root", "http://ns");
                await writer.WriteStartElementAsync(null, "sub", null);
                await writer.WriteAttributeStringAsync(null, "att", null, "val");
                await writer.WriteStringAsync("text");
                await writer.WriteEndElementAsync();
                await writer.WriteProcessingInstructionAsync("pName", "pValue");
                await writer.WriteCommentAsync("cValue");
                await writer.WriteCDataAsync("cdata value");
                await writer.WriteEndElementAsync();
                await writer.FlushAsync();
            }
        }

        private void readVocabListAsync()
        {
            if (vocabFileList == null || !File.Exists(vocabFileList))
            {
                var task = Task.Run(async () =>
                {
                    await TestWriter();
                });
            }
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
                            break;
                        default:
                            break;
                    }

                }

            }

        }


        public bool refreshVocabBoxes()
        {
            //if (readVocabList())
            //{
            //    throw new FileNotReadException("File wasn't read properly");
            //}
            //loadedBox = 0;
            //loadedVocabes = null;
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