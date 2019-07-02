using System;
using System.Collections.Generic;
using System.Text;

namespace GhostGameDomain
{
    public class HumanGhostPlayer : GhostPlayer
    {
        #region Constructor

        public HumanGhostPlayer(string name, GhostDictionary dictionary) : base(dictionary)
        {
            Name = name;
        }

        #endregion

        #region Public members

        public override void AddNextLetter(char letter)
        {
            WordInPLay = string.Concat(WordInPLay, letter);
        }

        #endregion

    }
}
