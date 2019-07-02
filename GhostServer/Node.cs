using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GhostGameDomain
{
    /// <summary>
    /// This class implements each node of a Trie (https://en.wikipedia.org/wiki/Trie)
    /// Read DesignNotes.txt for more information.
    /// </summary>
    public class Node
    {

        
        #region Public members

        public string Word;

        public bool IsTerminal { get { return (Branches != null && Children.Count > 0); } }
        
        public Letter Letter{ get {return Word[Word.Length - 1]; } }

        public Dictionary<Letter, Node> Branches = new Dictionary<Letter, Node>();

        public List<Node> Children
        {
            get
            {
                return Branches.Values.ToList();                
            }
        }

        // Get the maximum length from the childs
        public int MaximumLength
        {
            get
            {
                int length = 0;
                int maximumLength = 0;

                foreach (var child in Children)
                {
                    length = child.MaximumLength;
                    if (length > maximumLength)
                        maximumLength = length;
                }

                return maximumLength + 1;
            }
        }
        

        public Node getChild(char letter)
        {
            return Branches.GetValueOrDefault(letter);
        }


        #endregion
    }
}
