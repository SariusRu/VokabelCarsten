using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace VokabelCarsten
{
	//noah
	[Serializable]
	public class VocabBox
	{
		public int id { get; set; } 
		private int countVocs = 0; //Counts total number of added Vocabs and serves as Vocab-ID for creating a new Vocab; does not include removing Vocabs intentionally
        public string name { get; set; }
		public string spalte1 { get; set; }
		public string spalte2 { get; set; }
		public List<Vocab> Vokabeln { get; set; }
		private Random rndGenerator;
		public string filePath { get; set; }

		public VocabBox()
		{

		}

		/// <summary>
		/// Create new VocabBox with given parameters.
		/// </summary>
		/// <param name="Na"></param>
		/// <param name="S1"></param>
		/// <param name="S2"></param>
		/// <param name="file"></param>
		public VocabBox(string Na, string S1, string S2, string file)
		{
			name = Na;
			spalte1 = S1;
			spalte2 = S2;
			Vokabeln = new List<Vocab>();
			rndGenerator = new Random();
			filePath = file;

		}

		/// <summary>
		/// Create new Vocab with given parameters.
		/// We allow vocabs to exist as duplicates.
		/// </summary>
		/// <param name="pSide1"></param>
		/// <param name="pSide2"></param>
		public void addVokabel(string pSide1, string pSide2)
		{
			//Handling of already existing VocabBoxes/Vocabs in future release
			Vocab voc = new Vocab(pSide1, pSide2, countVocs);
			Vokabeln.Add(voc);
			countVocs++;

		}

		/// <summary>
		/// Delete Vocab identified by given ID.
		/// RWe assume that 
		/// </summary>
		/// <param name="pID"></param>
		public void removeVokabel(int pID)
		{
			int index = Vokabeln.IndexOf(Vokabeln.Find(item => item.id == pID));
			if (index == -1)
			{
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
		/// <param name="pLevel"></param>
		public void changeVokabel(int pID, string pSide1, string pSide2, int pLevel)
		{
			int index = Vokabeln.IndexOf(Vokabeln.Find(item => item.id == id));
			if (index == -1)
			{
				return;
			}
			Vokabeln[index].EditVocab(pSide1, pSide2);
		}


		/// <summary>
		/// Get Vocab with certain Id.
		/// Method is not necessary until later versions
		/// </summary>
		/// <param name="id"<>/param>
		public Vocab getVokabel(int id)
		{
			return Vokabeln[id];
		}

		public void increaseVocabLevel(int id)
		{
			Vokabeln[id].increaseLevel();
		}

		public void decreaseVocabLevel(int id)
		{
			Vokabeln[id].decreaseLevel();
		}

		/// <summary>
		/// Get random Vocab.
		/// Method is not necessary until later versions
		/// </summary>
		/*public Vocab getRandomVok()
        {
			return Vokabeln[rndGenerator.Next(Vokabeln.Count)];
        }*/

		/// <summary>
		/// Get Vocab count.
		/// </summary>
		public int getAnzVok()
		{
			return Vokabeln.Count;
		}

		/// <summary>
		/// Get Vocabs from certain Fach.
		/// Method is not necessary until later versions
		/// returns VocabList
		/// </summary>
		/// <param name="Fachnummer"<>/param>
		/*public List<Vocab> getVokFromFach(int Fachnummer)
        {
			List<Vocab> retVocs = new List<Vocab>();
			for(int i = 0; i < Vokabeln.Count; i++)
            {
				if (Vokabeln[i].GetLevel() == Fachnummer)
					retVocs.Add(Vokabeln[i]);
            }
			return retVocs;
        }*/

		/// <summary>
		/// Get VocabBox Id.
		/// returns id
		/// </summary>
		public int getId()
		{
			return id;
		}

		/// <summary>
		/// Set file path
		/// </summary>
		/// <param name="file"<>/param>
		public void setFilePath(string file)
		{
			filePath = file;
		}

		/// <summary>
		/// Get Filepath.
		/// </summary>
		public string getFilePath()
		{
			return filePath;
		}


		/// <summary>
		/// Clear Vocabs.
		/// </summary>
		public void unloadVocabs()
		{
			Vokabeln.Clear();
		}

		public string getName()
		{
			return name;
		}
	}
}
