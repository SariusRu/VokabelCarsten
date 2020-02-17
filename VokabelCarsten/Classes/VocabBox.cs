using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace VokabelCarsten
{
	//noah
	[Serializable]
	public class VocabBox
	{
	private int idcounter { get; set; }
	public int id { get; set; }
	public string name { get; set; }
	public string spalte1 { get; set; }
	public string spalte2 { get; set; }
	public List<Vocab> Vokabeln { get; set; }
	private Random rndGenerator;
	public string filePath { get; set; }
	

		public VocabBox()
		{

		}


		public VocabBox(string Na, string S1, string S2, string file)
        {
			idcounter = 0;
			name = Na;
			spalte1 = S1;
			spalte2 = S2;
			this.filePath = filePath;
			Vokabeln = new List<Vocab>();
			rndGenerator = new Random();
			filePath = file;

		}

		public string getName()
		{
			return name;
		}
		public void addVokabel(string si1, string si2)
        {
			idcounter++;
			Vocab voc = new Vocab(si1, si2, idcounter);
			Vokabeln.Add(voc);
		}
		public void removeVokabel(int id)
        {
			Vokabeln.RemoveAt(id);
		}
		public Vocab getVokabel(int id)
        {
			return Vokabeln[id];
        }
		public Vocab getRandomVok()
        {
			return Vokabeln[rndGenerator.Next(Vokabeln.Count)];
        }
		public int getAnzVok()
        {
			return Vokabeln.Count;
        }
		public List<Vocab> getVokFromFach(int Fachnummer)
        {
			List<Vocab> retVocs = new List<Vocab>();
			for(int i = 0; i < Vokabeln.Count; i++)
            {
				if (Vokabeln[i].GetLevel() == Fachnummer)
					retVocs.Add(Vokabeln[i]);
            }
			return retVocs;
        }
		public int getId()
        {
			return id;
        }
		public void sortVokabeln(int id)
        {
			//????
        }
		public void setFilePath(string file)
		{
			filePath = file;
		}

		public string getFilePath()
		{
			return filePath;
		}

		public void unloadVocabs()
		{
			Vokabeln.Clear();
		}
	}
}
