using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace VokabelCarsten
{
	//noah
	[Serializable]
	public class VocabBox
	{
		//Make attributes private and create extra getter/setter methods, data encapsulation, it should never be possible to directly access attributes from outside the containing class
		public int id { get; set; } //Is ID really required? Control identifies Vocab Box after its name
		//Counts total number of added Vocabs and serves as Vocab-ID for creating a new Vocab; does not include removing Vocabs intentionally
		private int countVocs = 0;
		public string name { get; set; }
		public string column1 { get; set; }
		public string column2 { get; set; }
		public List<Vocab> Vokabeln { get; set; }
		private Random rndGenerator;
		public string filePath { get; set; }
	
		/*Commented empty constructor without parameters (why overload it?)
		public VocabBox()
		{

		}*/

		public VocabBox(string Na, string S1, string S2, string file)
        {
			name = Na;
			column1 = S1;
			column2 = S2;
			this.filePath = filePath;
			Vokabeln = new List<Vocab>();
			rndGenerator = new Random();
			filePath = file;

		}

        //Do we need this method? Already have getter/setter method for name
		public string GetName()
		{
			return name;
		}

        /// <summary>
        /// Create new Vocab with given parameters.
        /// Return on error to be done.
        /// </summary>
        /// <param name="pSide1"<>/param>
        /// <param name="pSide2"></param>
		public void AddVokabel(string pSide1, string pSide2)
        {
			//How to handle if Vocab already exists with both or one of the sides?
			Vokabeln.Add(new Vocab(pSide1, pSide2, countVocs));
			countVocs++;
		}

        /// <summary>
        /// Delete Vocab identified by given ID.
        /// Return on error to be done.
        /// </summary>
        /// <param name="pID"></param>
		public void RemoveVokabel(int id)
        {
            int index = Vokabeln.IndexOf(Vokabeln.Find(item => item.id == id));
            if (index == -1)
            {
                //theGUI.appendTB_outputText("Vocab Box " + pName + " not found.");
                return;
            }
			Vokabeln.RemoveAt(index);
		}

        /// <summary>
        /// Change attributes of Vocab identified by ID.
        /// Return on error to be done.
        /// </summary>
        /// <param name="pID"></param>
        /// <param name="pSide1"></param>
        /// <param name="pSide2"></param>
		public void ChangeVokabel(int pID, string pSide1, string pSide2)
        {
            int index = Vokabeln.IndexOf(Vokabeln.Find(item => item.id == id));
            if (index == -1)
            {
                //theGUI.appendTB_outputText("Vocab Box " + pName + " not found.");
                return;
            }
			Vokabeln[index].EditVocab(pSide1, pSide2);
		}

        /// <summary>
        /// Return the Vokabel given by the ID
        /// </summary>
        /// <param name="id">The Vokabel ID</param>
        /// <returns>Vokabel</returns>
		public Vocab GetVokabel(int id)
        {
			return Vokabeln[id];
        }

        /// <summary>
        /// Returns a Random Vokabel from the List
        /// </summary>
        /// <returns>Vokabel</returns>
		public Vocab GetRandomVok()
        {
			return Vokabeln[rndGenerator.Next(Vokabeln.Count)];
        }

        /// <summary>
        /// Return a Vokabel from an Compartment
        /// </summary>
        /// <param name="Compartment">Compartment Number</param>
        /// <returns>Vocable List from Compartment</returns>
		public List<Vocab> GetVokFromFach(int Compartment)
        {
			List<Vocab> retVocs = new List<Vocab>();
			for(int i = 0; i < Vokabeln.Count; i++)
            {
				if (Vokabeln[i].GetLevel() == Compartment)
					retVocs.Add(Vokabeln[i]);
            }
			return retVocs;
        }

        /// <summary>
        /// Set File Path for the Box to Save it to
        /// </summary>
        /// <param name="FilePath">Filepath</param>
		public void SetFilePath(string FilePath)
		{
			filePath = FilePath;
		}

        /// <summary>
        /// Get the File Path for the Box
        /// </summary>
        /// <returns>String Filepath</returns>
		public string GetFilePath()
		{
			return filePath;
		}

        //Remove all Vocabeln
		public void UnloadVocabs()
		{
			Vokabeln.Clear();
		}
	}
}
