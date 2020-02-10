using System;
using System.Collections.Generic;


namespace VokabelCarsten
{
	//noah
	class VocabBox
	{

	public int id { get; set; }
	public string name { get; set; }
	public string spalte1 { get; set; }
	public string spalte2 { get; set; }
	public List<Vocab> Vokabeln { get; set; }
	private Random rndGenerator;
	


		public VocabBox(string Na, string S1, string S2)
        {
			name = Na;
			spalte1 = S1;
			spalte2 = S2;
			Vokabeln = new List<Vocab>();
			rndGenerator = new Random();
		}
		public void addVokabel(Vocab Vokabel)
        {
			Vokabeln.Add(Vokabel);
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
	}
}