using System;
using System.Configuration;
using System.IO;
using System.Reflection;
using GhostGameDomain;


namespace GhostGameEntities
{

    /// <summary>
    /// This class represents an instance of a Ghost game and controls the flow   
    /// </summary>

    [Serializable()]
    public class GhostGame: GameStatus
    {
        
        [NonSerialized()] public GhostDictionary GhostDictionary;

        #region Constructor

        /// <summary>
        /// Constructor
        /// It expects a file name with the dictionary for the game
        /// </summary>        
        public GhostGame(GhostDictionary dictionary): base()
        {
            
            //FIXME If dictionary is not valid we should throw an error            
            GhostDictionary = dictionary;
          
            // Create computer player
            addComputerPlayer();

        }

        #endregion

        #region Public members
        
     
        /// <summary>
        /// Create a new human player
        /// </summary>
        public void addHumanPlayer(string name)
        {
            players[HUMAN] = new HumanGhostPlayer(name, GhostDictionary);
        }

           
        /// <summary>
        /// Try a new iteration for the game. The letter is always from the human player
        /// Return the winner or null if the game can continue
        /// </summary>
        public GhostPlayer play(char letter)
        {            
            // Add new letter for human player
            addNewLetter(letter);

            //Check result
            checkResult();

            if (winner == null)
            {
                //Switch player
                 currentPlayer = switchPlayer();

                //Add new letter for computer player
                addNewLetter(players[COMPUTER].play(CurrentWordInPlay));

                //Check result
                checkResult();
            }

            return winner;
        }

        #endregion

        #region Private members

        /// <summary>
        /// Create a new computer player
        /// </summary>
        private void addComputerPlayer()
        {
            players[COMPUTER] = new ComputerGhostPlayer(GhostDictionary);
        }

        // <summary>
        /// Verify whether it's possible add a new letter
        /// </summary>
        private void checkResult()
        {
            if (GhostDictionary.isFullWord(CurrentWordInPlay) || !GhostDictionary.isWordStem(CurrentWordInPlay))
            {                
                winner = players[switchPlayer()];
            }
                
        }

        /// Add a new letter to the corrent word
        private string addNewLetter(char letter)
        {
            //Add new letter for player
            CurrentWordInPlay += letter;
            return CurrentWordInPlay;
            
        }
        
        // Switch the current active player        
        private int switchPlayer()
        {
            return  (currentPlayer = ++currentPlayer % 2);
        }
       
        #endregion
    }
}
