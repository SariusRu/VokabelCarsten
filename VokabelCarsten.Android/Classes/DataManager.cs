using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

//
//Diese Klasse wird das bereitstellen, laden und verwalten von Tabellen übernehmen.
//Der Konstructor wird beim Start eine Datei mit allen möglichen öffnen
//

/**
* @file DataManager.cs
* @author Samuel Rundel
* @date 16.02.2020
* @brief This file contains the datamanager.
*
* The DataManager will take care of the entire file and data interaction between Android file system and the App.
*/

namespace VokabelCarsten
{
    class DataManager
    {
        public static readonly DataManager _obj = new DataManager();

        private string vocabFileList = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "vocabBoxes.xml");

        private List<VocabBox> vocabBoxes = new List<VocabBox>();

        public VocabBox loadedBox { get; set; }
        private List<VocabBox> loadedVocabes = new List<VocabBox>();

        public string status = null;

        /**
* @file DataManager.cs
* @author Samuel Rundel
* @date 16.02.2020
* @brief This file contains the datamanager.
*
* The DataManager will take care of the entire file and data interaction between Android file system and the App.
*/
        public DataManager()
        {
            if (!readVocabBoxList())
            {
                throw new FileNotReadException("File wasn't read properly");
            }
        }

        private bool readVocabBoxList()
        {
            if(!File.Exists(vocabFileList) || vocabFileList == null)
            {
                File.Create(vocabFileList);
            }
            try
            {
                string test = File.ReadAllText(vocabFileList);
                XmlSerializer ser = new XmlSerializer(typeof(List<VocabBox>));
                using (Stream reader = new FileStream(vocabFileList, FileMode.Open))
                {
                    // Call the Deserialize method to restore the object's state.
                    vocabBoxes = (List<VocabBox>)ser.Deserialize(reader);
                }
            }                
            catch(Exception ex)
            {
                
            }
            return true;
        }

        public VocabBox[] getVocabBoxList()
        {
            return vocabBoxes.ToArray();
        }

        public VocabBox selectVocabBox(int select)
        {
            loadedBox = vocabBoxes[select];
            readVocabBox(loadedBox);
            return loadedBox;
        }

        public void restoreLoadedBox()
        {
            SaveVocabBoxXML(loadedBox);
            loadedBox.unloadVocabs();
            loadedBox = null;
        }

        private void readVocabBox(VocabBox loadedBox)
        {
            string vocabBoxPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), loadedBox.getFilePath());
            String test = File.ReadAllText(vocabBoxPath);
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(VocabBox));
                using(Stream reader = new FileStream(vocabBoxPath, FileMode.Open))
                {
                    this.loadedBox = (VocabBox)ser.Deserialize(reader);
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        private void SaveVocabBoxXML(VocabBox loadedBox)
        {
            string vocabBoxPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), loadedBox.getFilePath());
            try
            {
                File.Delete(vocabBoxPath);
                XmlSerializer ser = new XmlSerializer(typeof(VocabBox));
                using (Stream writer = new FileStream(vocabBoxPath, FileMode.Create))
                {
                    ser.Serialize(writer, loadedBox);
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        public bool refreshVocabBoxes()
        {
            restoreLoadedBox();
            return readVocabBoxList();
        }

        public bool CreateVocabBox(VocabBox newBox)
        {
            if (CheckExistenceVocabBox(newBox.getName(), newBox.getFilePath()))
            {
                vocabBoxes.Add(newBox);
                selectVocabBox(vocabBoxes.Count - 1);
            }                  
                
            
            return true;
        }

        public bool SaveVocabBoxesXML()
        {
            restoreLoadedBox();

            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(List<VocabBox>));
                File.Delete(vocabFileList);
                using (Stream writer = new FileStream(vocabFileList, FileMode.Create))
                {
                    ser.Serialize(writer, vocabBoxes);
                }
            }
            catch (Exception ex)
            {
                
            }
            return true;
        }

        public bool CheckExistenceVocabBox(string name, string filePath)
        {
            if (vocabBoxes != null)
            {
                foreach (VocabBox item in vocabBoxes)
                {
                    if (item.getName() == name)
                    {
                        throw new VocabBoxAlreadyExists("A Vocabbox with this name already exists.");
                    }
                }
                foreach (VocabBox item in vocabBoxes)
                {
                    if (item.getName() == filePath)
                    {
                        throw new VocabBoxAlreadyExists("A Vocabbox with this Filepath already exists.");
                    }
                }
            }
            return true;
        }
    }
}