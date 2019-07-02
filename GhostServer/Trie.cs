using System;
using System.Collections.Generic;
using System.Linq;

namespace GhostGameDomain
{

    /// <summary>
    /// This class implements a Trie (https://en.wikipedia.org/wiki/Trie)
    /// It is based in the dessign of Fantius in stackoverflow
    /// Read DesignNotes.txt for more information.
    /// </summary>
    public abstract class Trie
    {

        public Node Root = new Node();

        public Trie(string[] words)
        {
            for (int w = 0; w < words.Length; w++)
            {
                var word = words[w];
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
                        node.Branches.Add(letter, next);
                    }
                    node = next;
                }
            }
        }        

    }
}
