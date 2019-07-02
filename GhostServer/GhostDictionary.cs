using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GhostGameDomain
{

    /// <summary>
    /// This class extends Trie in order to set base information for the game    
    /// </summary>
    public class GhostDictionary: Trie
    {

        public const int MIN_WORD_LENGTH = 4;

        #region Constructor

        /// <summary>
        /// Constructor
        /// It initialize the dictionary only with valid words
        /// </summary>
        public GhostDictionary(string[] words): base(FilterWords(words))
        {
        
        }

        #endregion

        #region Public members

        /// <summary>        
        /// Find the node for a word
        /// </summary>
        public Node findWord(string word)
        {            
            var node = Root;
            for (int len = 1; len <= word.Length; len++)
            {
                var letter = word[len - 1];
                Node next;
                if (!node.Branches.TryGetValue(letter, out next))
                {
                    next = new Node();
                    if (len == word.Length)
                    {
                        next.Word = word;
                    }

                    break;
                }
                node = next;
            }

            return node;

        }

        /// <summary>        
        /// Check if a word is complete
        /// </summary>
        public bool isFullWord(String word)
        {
            bool isFullWord = false;

            Node node = this.findWord(word);
            if ((node != null) && (node.IsTerminal))
                isFullWord = true;

            return isFullWord;
        }


        /// <summary>        
        /// Check if the string is the start of a word in the dictionary
        /// </summary>
        public bool isWordStem(String word)
        {
            bool isWordStem = false;

            Node node = this.findWord(word);
            if (node != null)
                isWordStem = true;

            return isWordStem;
        }

        #endregion

        #region Private members

        // Remove not valid words from de array
        private static string[] FilterWords(string[] words)
        {
            // Words under MIN_WORD_LENGTH are not valid
            return (new List<string>(words)).Where(w => w.Length > MIN_WORD_LENGTH).ToArray();            
        }

        #endregion
        
    }
}
