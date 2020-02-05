using System;
using Vocabs.cs;

namespace VokabelCarsten
{
	class VocabBox
	{

	public int id { get; set; }
	public string name { get; set; }
	public string spalte1 { get; set; }
	public string spalte2 { get; set; }
	public List<Vocabs> Vokabeln { get; set; }
	private Random rndGenerator;
	


		public VocabBox(string Na, string S1, string S2)
        {
			name = Na;
			spalte1 = S1;
			spalte2 = S2;
			Vokabeln = new List<Vocabs>();
			rndGenerator = new Random();
		}
		public void addVokabel(Vocabs Vokabel)
        {
			Vokabeln.Add(Vokabel);
			anzVokabeln++;
		}
		public void removeVokabel(int id)
        {
			Vokabeln.RemoveAt(id);
			anzVokabeln--;
		}
		public Vocabs getVokabel(int id)
        {
			return Vokabeln[id];
        }
		public Vocabs getRandomVok()
        {
			return Vokabeln[rndGenerator.Next(Vokabeln.Count)];
        }
		public int getAnzVok()
        {
			return Vokabeln.Count;
        }
		public Vocabs[] getVokFromFach(int Fachnummer)
        {
			List<Vocabs> retVocs = new List<Vocabs>();
			for(int i = 0; i < Vokabeln.Count; i++)
            {
				if (Vokabeln[i].getFach() == Fachnummer)
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
