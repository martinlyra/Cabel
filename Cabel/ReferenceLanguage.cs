using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Cabel
{
    class ReferenceLanguage
    {
        string name;
        List<string> words;

        public ReferenceLanguage(string name, List<string> words)
        {
            this.name = name;
            this.words = words;
        }

        public static ReferenceLanguage BuildFrom(string filePath)
        {
            if (!File.Exists(filePath))
                return null;

            var name = Path.GetFileNameWithoutExtension(filePath);
            var words = new List<string>();

            var buffer = File.ReadAllLines(filePath);

            foreach (string s in buffer)
            {
                var strings = s.Split(' ', '\0', '\n');

                foreach (string S in strings)
                    if (S != null || S != "")
                        words.Add(S);
            }

            return new ReferenceLanguage(name, words);
        }

        public string Name
        {
            get
            {
                return name;
            }
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
