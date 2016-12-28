using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cabel
{
    class WordDictionary
    {
        List<string> words;

        public WordDictionary(List<string> words)
        {
            this.words = words;
        }

        public static WordDictionary BuildFrom(string filePath)
        {
            if (!File.Exists(filePath))
                return null;

            var words = new List<string>();

            var buffer = File.ReadAllLines(filePath);

            foreach (string s in buffer)
            {
                words.Add(s.Trim());
            }

            return new WordDictionary(words);
        }

        public List<string> Words
        {
            get
            {
                return words;
            }
        }
    }
}
