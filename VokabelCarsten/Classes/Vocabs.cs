using System;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

// von betti
/**
 * @file Vocabs.cs
 * @author Bettina Kimpfler
 * @date 30.01.2020
 * @brief Vocab Class for Vocabulary Elemements
 */



namespace VokabelCarsten
{
    [Serializable]
    public class Vocab
    {
        /** \brief First side of Vocabulary */
        public string side1 { get; set; }       //Vocab on side 1 e.g. "to walk2

        /** \brief Second side of Vocabulary */
        public string side2 { get; set; }       // Vocab on side 2 e.g."laufen"

        /** \brief Level of Vocabulary */
        public int level { get; set; } = 0;

        /** \brief ID of Vocabulary */
        public int id { get; set; }

        public Vocab()
        {

        }
        /**
          * @brief Constructor of Vocab Element
          *
          *
          * @param	si1  Side One of Vocab
          * @param	si2  Side two of Vocab
          * @param  ID   Id of Vocab
          *
          */
        public Vocab(string si1, string si2, int ID)   //Konstruktor
        {
            side1 = si1;
            side2 = si2;
            id = ID;
        }

        /**
          * @brief Function to Edit a Vocabulary
          * @param	si1  New value of side one
          * @param	si2  New value of side two
          * @param  lev  New value of Level
          *
          */
        public void editVocab(string si1, string si2, int lev)
        {
            side1 = si1;
            side2 = si2;
            level = lev;
        }
        /**
         * @brief Function to get the Level of a Vocab
         * @return Level of the vocab
         */
        public int getLevel()
        {
            return level;
        }

        /**
         * @brief Function to set the level of a vocab
         * @param lev  new Level of the vocab
         */
        public void setLevel(int lev)
        {
            level = lev;
        }

        /**
         * @brief Function to increase the Level of the Vocab
         */
        public void increaseLevel()
        {
            if (level == 0)
            { }
            else { level--; }
        }
        /**
         * @brief Function to decrease the Level of the Vocab
         */
        public void decreaseLevel()
        {
            if (level == 6) { }
            else { level++; }

        }
    }
}