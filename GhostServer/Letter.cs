using System;
using System.Collections.Generic;
using System.Text;

namespace GhostGameDomain
{
    /// <summary>
    /// This structure restricts the possible values for a letter in a word    
    /// </summary>
    public struct Letter
    {
        public const string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public static implicit operator Letter(char c)
        {
            return new Letter() { Index = Chars.IndexOf(c) };
        }
        public int Index;
        public char ToChar()
        {
            return Chars[Index];
        }
        public override string ToString()
        {
            return Chars[Index].ToString();
        }
    }
}
