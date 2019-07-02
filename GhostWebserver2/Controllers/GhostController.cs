using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using GhostGameEntities;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Web;
using System.Web.Http;
using GhostGameDomain;

namespace GhostWebserver.Controllers
{

    /// <summary>
    /// This class implemnents the API for the ghost game
    /// </summary>
    /// 
    public class GhostController : System.Web.Http.ApiController
    {

        private const string DICTIONARY_RESOURCE_FILE = "DictionaryResourceFile";
        private const string GAME_STATUS = "GameStatus";
        private const string DICTIONARY = "Dictionary";
        
        private GhostDictionary dictionary;

        #region Constructor

        /// <summary>
        /// Constructor        
        /// </summary>  
        public GhostController()
        {            

            dictionary = (GhostDictionary)HttpContext.Current.Cache[DICTIONARY];

            // If it is null, it create the instance of the dictionary
            if (dictionary == null)
            {
                // Get name from dictorinary resource
                var dictionaryName = ConfigurationManager.AppSettings[DICTIONARY_RESOURCE_FILE];
                var dictionaryFile = getDictionary(dictionaryName);
                dictionary = new GhostDictionary(getDictionary(dictionaryName).ToArray());
                // The dictionary is share through cache for any instance of the game
                HttpContext.Current.Cache[DICTIONARY] = dictionary;
            }
            //FIXME Should save only the base clase GameStatus
            // If it is null, it create the instance
            if (GameInSession == null)
            {                
                // Create game controller
                GameInSession = new GhostGame(dictionary);
            }           
            else
            {
                //Update dictionary
                GameInSession.GhostDictionary = dictionary;
            }

        }

        #endregion

        #region API

        /// <summary>
        /// Get Current status of the game    
        /// </summary>  
        // GET: api/ghost/Status
        [Route("api/ghost/status")]
        [HttpGet]
        public IEnumerable<string> GetStatus()
        {
            //Get current status in json
            string[] status = { GameInSession.CurrentWordInPlay };

            return status;
        }

        /// <summary>
        /// Try to add the parameter, the computer add a new one and get the winner if exists
        /// </summary>  
        /// <param name="letter">The new letter for the human player.</param>
        // GET: api/ghost/a
        [Route("api/ghost")]
        [HttpGet]
        public string Get(string letter)
        {
            // Try to add a new letter from the human and get a new one from the computer
            // It gets the winner if exists
            GhostPlayer winner = GameInSession.play(letter[0]);
            if (winner!=null)
            {
                return winner.Name;
            }
            else
            {
                return "";
            }
                        
        }

        /// <summary>
        /// Initialize the game with the human player's name
        /// </summary>  
        /// <param name="letter">The name of the human player.</param>
        // POST: api/ghost
        [Route("api/ghost")]
        [HttpPost]
        public void Post([FromBody]string name)
        {
            //Add a new human player to the game
            GameInSession.addHumanPlayer(name);
        }

        /// <summary>
        /// Reset the current game
        /// </summary>  
        // DELETE: api/ghost
        [Route("api/ghost")]
        [HttpDelete]
        public void Delete()
        {
            // Reset current game
            GameInSession = new GhostGame(dictionary);
        }

        #endregion

        #region Private members

        /// <summary>
        /// Initilize dictionary from embeded resource
        /// </summary>
        /// 
        private DictionaryFile getDictionary(string resourceName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            Stream stream = assembly.GetManifestResourceStream(resourceName);
            return new DictionaryFile(new StreamReader(stream));
        }

        // Current game in session
        private GhostGame GameInSession
        {
            get
            {
                return  (GhostGame)HttpContext.Current.Session[GAME_STATUS];                
            }
            set
            {
                HttpContext.Current.Session[GAME_STATUS] = value;

            }
        }

        #endregion
    }
}
