using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace GhostGameEntities
{
    /// <summary>
    /// This class creates a new array of words from a file
    /// </summary>
    /// 
    public class DictionaryFile
    {
        List<string> words = new List<string>();

        #region Constructor

        /// <summary>
        /// Constructor
        /// Initialize dictionary from file
        /// </summary>
        public DictionaryFile(string filename): this(new StreamReader(filename))
        {                                    
            
        }

        /// <summary>
        /// Constructor
        /// Initialize dictionary from streamreader
        /// </summary>
        public DictionaryFile(StreamReader file)
        {
            string line;            

            // Read the file and display it line by line.              
            while ((line = file.ReadLine()) != null)
            {
                words.Add(line.Trim());
            }

            file.Close();

        }

        #endregion

        #region Public members

        /// <summary>
        /// Return dictionary as array of string
        /// </summary>
        public string[] ToArray()
        {
            return words.ToArray();
        }
        #endregion

    }
}
