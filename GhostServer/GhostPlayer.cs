using System;
using System.Collections.Generic;
using System.Text;

namespace GhostGameDomain
{

    /// <summary>
    /// This abstract class defines the requirements needed for any kind of player
    /// </summary>
    public abstract class GhostPlayer
    {
        protected GhostDictionary dictionary;

        public GhostPlayer(GhostDictionary dictionary)
        {
            this.dictionary = dictionary;
        }

        /// <summary>
        /// Player's name
        /// </summary>
        public abstract string Name();
        
        /// <summary>
        /// Return current word
        /// </summary>
        public abstract string WordInPLay();

        /// <summary>
        /// Add new letter to the current word for the player
        /// </summary>
        /// <param name="letter">
        /// new letter
        /// </param>
        public abstract void AddNextLetter(char letter);

        /// <summary>
        /// Try get a new letter from the new word from the current one
        /// or a default value
        /// </summary>
        /// <param name="wordInPlay">
        /// new word in play
        /// </param>
        public virtual char play(string wordInPlay) {
            Console.WriteLine(string.Format("%1 is the current word in play", wordInPlay));
            return char.MinValue;
        }
    }   
}
