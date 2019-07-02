using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GhostGameDomain
{

    /// <summary>
    /// This class extends Trie in order to set base information for the game    
    /// </summary>
    public class GhostDictionary
    {

        public const int MIN_WORD_LENGTH = 4;

        #region Constructor

        /// <summary>
        /// Constructor
        /// It initialize the dictionary only with valid words
        /// </summary>
        public GhostDictionary(string[] words)
        {
            foreach (string word in FilterWords(words))
            {
                addWord(word);
            }

            //int terminalNodes = this.size();
          
        }

        #endregion

        #region Public members

        // Root node
        public Node Root = new Node("");
        
        /// <summary>        
        /// Find the node for a word
        /// </summary>
        public Node findWord(string word)
        {            
            var node = Root;
            for (int len = 1; len <= word.Length; len++)
            {
                var letter = word[len - 1];

                Node next = node.getChild(letter);

                if (next == null)
                {
                    node = null;
                    break;
                }
                else
                {
                    node = next;
                }

                /*
                //FIXME This code lets append new word to the dictionary
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
                */
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

        // Add a new word to the current node
        private void addWord(String word)
        {
            if (word.Length >= MIN_WORD_LENGTH)
            {
                Node node = Root.getChild(word[0]);

                if (node == null)
                {
                    Root.Branches.Add(word[0], new Node(word));
                }
                else
                {                    
                    node.addWord(word);
                }
                   
            }
        }

        // Get the number of terminal nodes in the structure
        private int size()
        {
            int count = 0;


            foreach (Node child in Root.Children)
            {
                count += countTerminal(child);
            }

            return count;
        }

        private int countTerminal(Node node)
        {
            if (node.IsTerminal)
            {
                return 1;
            }
            else
            {
                int count = 0;

                foreach (Node child in node.Children)
                {
                    count += countTerminal(child);
                }

                return count;
            }
        }

        // Remove not valid words from de array
        private static string[] FilterWords(string[] words)
        {
            // Words under MIN_WORD_LENGTH are not valid
            return (new List<string>(words)).Where(w => w.Length > MIN_WORD_LENGTH).ToArray();            
        }

        #endregion
        
    }
}
