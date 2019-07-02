using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GhostGameDomain
{
    /// <summary>
    /// This class implements each node of a Trie (https://en.wikipedia.org/wiki/Trie)
    /// Read DesignNotes.mkd for more information.
    /// </summary>
    public class Node
    {

        #region Constructor

        public Node(string word)
        {
            
            if (word.Length > 0)
            {
                this.Letter = word[0];
            }

            if (word.Length > 1)
            {
                // Recursive creation of nodes for the word
                Branches.Add(word[1], new Node(word.Substring(1)));

            }

        }

        #endregion

        #region Public members

        
        public Dictionary<Char, Node> Branches = new Dictionary<Char, Node>();

        public char Letter { get; set; }

        /// <summary>        
        /// Return if a node is terminal
        /// </summary>
        public bool IsTerminal {
            get
            {
                return (Branches == null || Branches.Count<=0);
            }
        }

        /// <summary>        
        /// Return the node childs of a node
        /// </summary>
        public List<Node> Children
        {
            get
            {
                return Branches.Values.ToList();                
            }
        }

        /// <summary>        
        /// Add a word to the node in base a this rules:
        ///  - If this node has no child nodes, the passed word begins with
        ///    this word and must not be added.
        ///  - If the passed word has a length of zero, this is the end of the
        ///    word and all child nodes must be deleted.
        /// </summary>
        public void addWord(String word)
        {
            if (word != null && word[0].Equals(Letter))
            {
                if (this.Branches.Count>0)
                {
                    if (word.Length == 1)
                    {
                        Branches.Clear();                        
                    }
                    else
                    {
                        Node nextNode = getChild(word[1]);

                        if (nextNode == null)
                        {
                            Branches.Add(word[1], new Node(word.Substring(1)));                            
                        }
                        else
                        {
                            nextNode.addWord(word.Substring(1));
                        }
                    }
                }
            }
        
        }

        /// <summary>        
        /// Get the maximum length from the childs
        /// </summary>
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

        /// <summary>        
        /// Get a child from his letter
        /// </summary>
        public Node getChild(char letter)
        {
            Node selectedChild = null;

            foreach (var child in Children)
            {
                if (child.Letter.Equals(letter))
                {
                    selectedChild = child;
                    break;
                }
            }

            return selectedChild;
        }


        #endregion
    }
}
