using GhostGameDomain;
using System;
using System.Collections.Generic;
using System.Text;

namespace GhostGameEntities
{
    /// <summary>
    /// This class let save the current status of a game
    /// </summary>
    /// 
    [Serializable]
    public class GameStatus
    {
        protected const int HUMAN = 0;
        protected const int COMPUTER = 1;

        protected GhostPlayer[] players;
        protected int currentPlayer;
        protected GhostPlayer winner;

        #region Constructor

        /// <summary>
        /// Constructor
        /// It expects a file name with the dictionary for the game
        /// </summary>        
        public GameStatus()
        {
            players = new GhostPlayer[2];

            //Initial player
            currentPlayer = HUMAN;

            winner = null;
           
        }

        #endregion

        #region Public members

        public string CurrentWordInPlay { get; set; }

      
        /// <summary>
        /// Initialize current game
        /// </summary>
        public void resetGame()
        {
            players = new GhostPlayer[2];

            winner = null;

            //Initial player
            currentPlayer = HUMAN;

            CurrentWordInPlay = "";

        }
        
        #endregion
    }

}
