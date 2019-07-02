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
        public const string COMPUTER_NAME = "Computer";

        protected GhostDictionary dictionary;

        #region Constructor

        public GhostPlayer(GhostDictionary dictionary)
        {
            this.dictionary = dictionary;
            Name = COMPUTER_NAME;
        }

        #endregion

        #region Public members

        /// <summary>
        /// Player's name
        /// </summary>
        public virtual string Name { get; set; }
        
        /// <summary>
        /// Return current word
        /// </summary>
        public virtual string WordInPLay { get; set; }

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

        #endregion
    }
}
