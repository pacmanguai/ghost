using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static GhostGameDomain.Trie;

namespace GhostGameDomain
{

    /// <summary>
    /// This class implements the computer player  
    /// </summary>
    public class ComputerGhostPlayer : GhostPlayer
    {
        #region Const and definitions

        private const string NAME = "Computer";
        private string currentWord;

        #endregion

        #region Constructor

        public ComputerGhostPlayer(GhostDictionary dictionary) : base(dictionary)
        {            
        }

        #endregion

        #region Public members

        public override void AddNextLetter(char letter)
        {
            currentWord = string.Concat(currentWord, letter);
        }

        public override string Name()
        {
            return NAME;
        }

        public override string WordInPLay()
        {
            return currentWord;
        }
        public override char play(string wordInPlay)
        {
            currentWord = wordInPlay;

            //FIXME set a control char
            char nextLetter = 'x';
            
            Node node = dictionary.findWord(wordInPlay);
            if (node != null)
            {
                Node forcedWin = getForcedWin(node);
                if (forcedWin != null)
                    nextLetter = forcedWin.Letter.ToChar();
                else
                    nextLetter = getLongestWord(node).Letter.ToChar();
            }

            return nextLetter;
        }

        #endregion

        #region Private members
            
        
        // Try to find a forced win. That's possible when all the children of a child are either terminals o forced wins         
        private Node getForcedWin(Node node)
        {
            Node bestChild = null;
            
            foreach(var child in node.Children) {
                if (!child.IsTerminal)
                {
                    bestChild = child;
                    foreach (var grandChild in child.Children)
                    {
                        if (!(grandChild.IsTerminal || (getForcedWin(grandChild) != null)))
                        {
                            bestChild = null;
                            break;
                        }
                    }
                }

                if (bestChild!=null)
                {
                    break;
                }
                
            }

            return bestChild;
        }


        // Try to find the longest word reachable from the node        
        private Node getLongestWord(Node node)
        {
            Node longestChild = null;

            foreach (var child in node.Children)
            {
                if ((longestChild == null) || (child.MaximumLength > longestChild.MaximumLength))
                {
                    longestChild = child;
                }

            }
            return longestChild;

        }

        #endregion


        }
}
