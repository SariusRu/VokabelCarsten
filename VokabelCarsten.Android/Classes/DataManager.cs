using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using VokabelCarsten.Exceptions;

namespace VokabelCarsten
{
    public class DataManager
    {

        #region Global Variables
        /// <summary>
        /// Prevents multiple Datamanagers
        /// </summary>
        public static readonly DataManager staticDataManager = new DataManager();

        private string vocabFileList = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData), "vocabBoxes.xml");

        private List<VocabBox> vocabBoxes = new List<VocabBox>();

        public VocabBox loadedBox { get; set; }
        private List<VocabBox> loadedVocabes = new List<VocabBox>();

        #endregion Global Variables

        #region Constructor
        /// <summary>
        /// DataManager-Constructor
        /// </summary>
        /// This Constructor creates a new object of the type DataManager. After Creation the object contains a list of "unloaded" VocabBoxes.
        /// Unloaded Vocabboxes don't contain Vocabs, but a reference to the file where to find them. An Error is thrown if a reading-Error occurs.
        public DataManager()
        {
            if (!readVocabBoxList())
            {
                //throw new FileNotReadException("File wasn't read properly");
            }
        }

        #endregion Constructor

        /// <summary>
        /// Reads a list of Vocabs from a File
        /// </summary>
        /// This methos is using the vocabFileList from the members to check if the file exists. If no File exists a file is created.
        /// After that the methos tries to read from the file using a FileStrean and a XML-Serializer.
        /// The results are cated to a list of VocabBoxes and then saved in vocabBoxes
        /// \return False if there wasn't any text to read
        protected bool readVocabBoxList()
        {
            try
            {
                if (!File.Exists(vocabFileList) || vocabFileList == null)
                {
                    File.Create(vocabFileList);
                    return false;
                }
                else
                {
                    string stringToDeserialize = File.ReadAllText(vocabFileList);
                    if (stringToDeserialize != "")
                    {
                        List<VocabBox> List = new List<VocabBox>();
                        vocabBoxes = xmlDeserialize(ref List, stringToDeserialize);
                        //XmlSerializer ser = new XmlSerializer(typeof(List<VocabBox>));
                        //using (Stream reader = new FileStream(vocabFileList, FileMode.Open))
                        //{
                        // Call the Deserialize method to restore the object's state.
                        //    vocabBoxes = (List<VocabBox>)ser.Deserialize(reader);
                        //}
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
            }
            catch (Exception ex)
            {
                throw new VokabelCarsten.Exceptions.FileNotReadException("There was a error while reading the file!", ex);
            }
        }

        protected string xmlSerializer<T>(ref T objectToSerialize)
        {
            XmlSerializer ser = new XmlSerializer(objectToSerialize.GetType());
            using (StringWriter textWriter = new StringWriter())
            {
                ser.Serialize(textWriter, objectToSerialize);
                return textWriter.ToString();
            }
        }

        protected T xmlDeserialize<T>(ref T objectToWriteTo, string stringToDeserialize)
        {
            XmlSerializer ser = new XmlSerializer(objectToWriteTo.GetType());
            using (StringReader reader = new StringReader(stringToDeserialize))
            {
                // Call the Deserialize method to restore the object's state.
                objectToWriteTo = (T)ser.Deserialize(reader);
            }
            return objectToWriteTo;
        }

        public List<VocabBox> getVocabBoxList()
        {
            return vocabBoxes;
        }

        /// <summary>
        /// Returns the list of VocabBoxes as an array
        /// </summary>
        /// Converts the vocabBoxes-Member into an Array and returns it.
        /// Used to select the Array.
        /// \return  The converted list
        public VocabBox[] getVocabBoxArray()
        {
            return vocabBoxes.ToArray();
        }

        /// <summary>
        /// Selects, loads and returns a VocabBox
        /// </summary>
        /// A vocabBox is selected from the vocabBoxes-list using an index.
        /// The selected vocabBox is then saved into the loadedBox, loaded and returned.
        /// <param name="select">The index of the wanted vocabBox.</param>
        /// <returns VocabBox>The selected VocabBox</returns>
        public VocabBox selectVocabBox(int select)
        {
            loadedBox = vocabBoxes[select];
            readVocabBox();
            return loadedBox;
        }

        /// <summary>
        /// Unloads a selected VocabBox
        /// </summary>
        /// The selected box is saved using SaveVocabBoxesXML.
        /// All Vocabs are deleted from the selected VocabBox and the loadedBox-member is nulled.
        public void restoreLoadedBox()
        {
            if (loadedBox != null)
            {
                SaveVocabBoxXML();
                loadedBox.unloadVocabs();
                loadedBox = null;
            }
            //refreshVocabBoxes();
        }

        /// <summary>
        /// Reads the Vocabs of a VocabBox
        /// </summary>
        /// The methos is using the filepath saved in every VocabBox to open a filestream to the file.
        /// This fileStream is used by the XMLSerializer. The result are casted to a VocabBox and saved in the loadedBox-member
        private bool readVocabBox()
        {
            string vocabBoxPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData), loadedBox.getFilePath());
            try
            {
                if (!File.Exists(vocabBoxPath) || vocabBoxPath == null)
                {
                    var myFile = File.Create(vocabBoxPath);
                    myFile.Close();
                    return false;
                }
                else
                {
                    String test = File.ReadAllText(vocabBoxPath);
                    if (test != "")
                    {
                        XmlSerializer ser = new XmlSerializer(typeof(VocabBox));
                        using (Stream reader = new FileStream(vocabBoxPath, FileMode.Open))
                        {
                            loadedBox = (VocabBox)ser.Deserialize(reader);
                        }
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
            }
            catch (Exception ex)
            {
                throw new VokabelCarsten.Exceptions.FileNotReadException("There was a error while reading the file!", ex);
            }
        }


        /// <summary>
        /// Saves the currently selected VocabBox
        /// </summary>
        /// The methos is using the filepath saved in every VocabBox to open a filestream to the file.
        /// This fileStream is used by the XMLSerializer. The serializer is saving the data into the file.
        private void SaveVocabBoxXML()
        {
            string vocabBoxPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData), loadedBox.getFilePath());
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
                throw new VokabelCarsten.Exceptions.FileSaveException("There was a error while reading the file!", ex);
            }
        }

        /// <summary>
        /// Refreshes the VocabBox-List
        /// </summary>
        /// The currently selected box is restored and the list is reread.
        /// <returns>Returns if the read-methos was successfull</returns>
        public bool refreshVocabBoxes()
        {
            //restoreLoadedBox();
            return readVocabBoxList();
        }

        /// <summary>
        /// Adds a empty Vocabbox into the list
        /// </summary>
        /// Checks if a vocabBox with this name already exists, if not the vocabBox is added into the list and is then selected.
        /// <returns>Returns if the operation was successfull</returns>
        /// <param name="newBox">The vocabBox to add into the list</param>
        public bool CreateVocabBox(VocabBox newBox)
        {
            if (CheckExistenceVocabBox(newBox.getName(), newBox.getFilePath()))
            {
                vocabBoxes.Add(newBox);
                SaveVocabBoxesXML();
                selectVocabBox(vocabBoxes.Count - 1);
            }


            return true;
        }

        /// <summary>
        /// Saves the vocabBox-List into a file
        /// </summary>
        /// a XML-Serializer in combination wuth a a filestream is used to save the list into a xml-file.
        /// <returns>If the operation was successfull</returns>
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
                throw new VokabelCarsten.Exceptions.FileSaveException("There was a error while reading the file!", ex);
            }
            return true;
        }

        /// <summary>
        /// Checks if there are possible duplicates
        /// </summary>
        /// get's the name and filepath of every file to check if they are the same as the given name and filepath. If they are an exception is thrown.
        /// <param name="filePath">the proposed filepath</param>
        /// <param name="name">the proposed name</param>
        /// <returns>If the operation was successfull</returns>
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

        public void deleteVocabBox(int id)
        {
            vocabBoxes.RemoveAt(id);
        }

        public void removeAllVocabBoxes()
        {
            vocabBoxes.Clear();
        }
    }
}