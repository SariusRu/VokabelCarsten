using System;

// von betti

namespace VokabelCarsten
{
    [Serializable]
    public class Vocab
    {
        public string Question { get; set; }       //Vocab on side 1 e.g. "to walk2
        public string Answer { get; set; }       // Vocab on side 2 e.g."laufen"
        public int level { get; set; } = 0;
        public int id { get; set; }

        public Vocab()
        {

        }

        /// <summary>
        /// Konstructor for Vocab Element
        /// </summary>
        /// <param name="si1"></param>
        /// <param name="si2"></param>
        /// <param name="ID"></param>
        /// <returns>List Index or -1 if not found</returns>
        public Vocab(string si1, string si2, int ID)   //Konstruktor
        {
            Question = si1;
            Answer = si2;
            id = ID;
        }

        /// <summary>
        /// Function to edit a vocab element
        /// </summary>
        /// <param name="si1"></param>
        /// <param name="si2"></param>
        /// <returns>List Index or -1 if not found</returns>
        public void EditVocab(string si1, string si2)
        {
            Question = si1;
            Answer = si2;
        }

        /// <summary>
        /// Function to get the level of a vocab
        /// </summary>
        /// <returns>List Index or -1 if not found</returns>
        public int GetLevel()
        {
            return level;
        }

        /// <summary>
        /// Decreases the level of a vocab
        /// </summary>
        public void decreaseLevel()
        {
            if (level == 0)
            { }
            else { level--; }
        }

        /// <summary>
        /// Increases the level of a vocab
        /// </summary>
        public void increaseLevel()
        {
            if (level == 6) { }
            else { level++; }

        }

        /// <summary>
        /// Returns Question
        /// </summary>
        public string getQuestion()
        {
            return Question;

        }

        /// <summary>
        /// Returns Answer
        /// </summary>
        public string getAnswer()
        {
            return Answer;

        }
    }
}