using Android.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

//
//Diese Klasse wird das bereitstellen, laden und verwalten von Tabellen übernehmen.
//Der Konstructor wird beim Start eine Datei mit allen möglichen öffnen
//

namespace VokabelCarsten
{
    class DataManager
    {
        public static readonly DataManager _obj = new DataManager();

        private string vocabFileList = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "vocabBoxes.xml");

        private List<VocabBox> vocabBoxes;

        private VocabBox loadedBox;
        private List<VocabBox> loadedVocabes = new List<VocabBox>();

        public string status = null;

        public DataManager()
        {
            if (!readVocabList())
            {
                throw new FileNotReadException("File wasn't read properly");
            }
        }

        private bool readVocabList()
        {
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
                Log.Debug("Exception:", ex.InnerException.ToString());
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
            vocabBoxes.Remove(loadedBox);
            return loadedBox;
        }

        private void restoreLoadedBox()
        {
            SaveVocabBoxXML(loadedBox);
            loadedBox.unloadVocabs();
            vocabBoxes.Add(loadedBox);
            loadedBox = null;
        }

        private void SaveVocabBoxXML(VocabBox loadedBox)
        {
            string vocabBoxPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), loadedBox.getFilePath());
            File.Delete(vocabBoxPath);
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(VocabBox));
                using (Stream writer = new FileStream(vocabBoxPath, FileMode.Create))
                {
                    ser.Serialize(writer, loadedBox);
                }
            }
            catch (Exception ex)
            {
                Log.Debug("Exception", ex.InnerException.ToString());
            }
        }

        public bool refreshVocabBoxes()
        {
            restoreLoadedBox();
            return readVocabList();
        }

        public bool CreateVocabBox(VocabBox newBox)
        {
            if(CheckExistenceVocabBox(newBox.getName(), newBox.getFilePath()))
            vocabBoxes.Add(newBox);
            selectVocabBox(vocabBoxes.Count - 1);
            return true;
        }

        public bool SaveVocabBoxesXML(VocabBox newBox)
        {
            refreshVocabBoxes();
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
                Log.Debug("Exception", ex.InnerException.ToString());
            }
            return true;
        }

        public bool CheckExistenceVocabBox(string name, string filePath)
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
            return true;
        }
    }
}