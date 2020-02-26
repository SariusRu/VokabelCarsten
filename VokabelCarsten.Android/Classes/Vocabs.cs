using System;

// von betti

namespace VokabelCarsten
{
    [Serializable]
    public class Vocab
    {
        //Make attributes private and create extra getter/setter methods, data encapsulation, it should never be possible to directly access attributes from outside the containing class
        public string side1 { get; set; }       //Vocab on side 1 e.g. "to walk2
        public string side2 { get; set; }       // Vocab on side 2 e.g."laufen"
        public int level { get; set; } = 0;
        public int id { get; set; }

        /*Commented empty constructor without parameters (why overload it?)
        public Vocab()
        {

        }*/

        /// <summary>
        /// Konstructor for Vocab Element
        /// </summary>
        /// <param name="si1"></param>
        /// <param name="si2"></param>
        /// <param name="ID"></param>
        /// <returns>List Index or -1 if not found</returns>
        public Vocab(string si1, string si2, int ID)   //Konstruktor
        {
            side1 = si1;
            side2 = si2;
            id = ID;
        }

        /// <summary>
        /// Function to edit a vocab element
        /// </summary>
        /// <param name="si1"></param>
        /// <param name="si2"></param>
        /// <param name="lev"></param>
        /// <returns>List Index or -1 if not found</returns>
        public void EditVocab(string si1, string si2, int lev)
        {
            side1 = si1;
            side2 = si2;
            level = lev;
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
        /// Increases the level of a vocab
        /// </summary>
        public void increaseLevel()
        {
            if (level == 0)
            { }
            else { level--; }
        }

        /// <summary>
        /// Decreases the level of a vocab
        /// </summary>
        public void decreaseLevel()
        {
            if (level == 6) { }
            else { level++; }

        }
    }
}