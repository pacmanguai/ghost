using System;
using System.Collections.Generic;
using System.Text;

namespace GhostGameDomain
{
    public class HumanGhostPlayer : GhostPlayer
    {
        private string name;
        private string currentWord;


        public HumanGhostPlayer(string name, GhostDictionary dictionary) : base(dictionary)
        {
            this.name = name;
        }
        

        public override void AddNextLetter(char letter)
        {
            currentWord = string.Concat(currentWord, letter);
        }

        public override string Name()
        {
            return name;
        }


        public override string WordInPLay()
        {
            return currentWord;
        }
    }
}
