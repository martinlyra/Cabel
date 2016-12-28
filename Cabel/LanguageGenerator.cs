using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cabel
{
    class LanguageGenerator
    {
        string version;

        byte minWordLength;
        byte maxWordLength;

        int seed;
        List<ReferenceLanguage> references = new List<ReferenceLanguage>();
        WordDictionary dictionary;

        public LanguageGenerator(Version version, byte minWL = 4, byte maxWL = 8, int seed = -1)
        {
            this.version = version.ToString();
            this.seed = seed;

            minWordLength = minWL;
            maxWordLength = maxWL;
        }

        public void AddLanguage(ReferenceLanguage lang)
        {
            references.Add(lang);
        }

        public void SetDictionary(WordDictionary dict)
        {
            dictionary = dict;
        }

        public OutputLanguage Generate()
        {
            var refWords = references.SelectMany(r => r.Words).Where(s => s != "").ToList();
            var wordStack = new RandomQueue<string>(refWords, new Random(Seed).Next());
            var count = refWords.Count();

            var output = new OutputLanguage("test");

            foreach (var word in dictionary.Words)
            {
                if (word == "") // Fuck off blank spaces
                    continue;

                //Console.WriteLine("Current word: " + word);
                var charSum = word.ToList().Sum(c => c);
                var length = word.Length;

                string newWord = "";
                while (newWord.Length < minWordLength)
                {
                    // some seed algothrim bullshit
                    //var wIndex = new Random(seed % (length * charSum)).Next(count);
                    //var rWord = refWords.ElementAt(wIndex);
                    var rWord = wordStack.Next();

                    var wMax = rWord.Length;
                    var subLen = new Random(seed).Next(1, wMax);
                   // var lower = new Random(seed).Next(wMax - subLen);
                    if ((subLen + newWord.Length) > maxWordLength)
                        subLen = (subLen + newWord.Length - maxWordLength);
                    // end bullshit

                    var rSubStr = rWord.Substring(0, subLen);

                    newWord += rSubStr;
                }

                output.Words.Add(word, newWord);
            }

            return output;
        }

        public int Seed
        {
            get
            {
                return seed;
            }
        }

        public string Version
        {
            get
            {
                return version;
            }
        }

        public byte MaxWordLength
        {
            get
            {
                return maxWordLength;
            }
        }

        public byte MinWordLength
        {
            get
            {
                return minWordLength;
            }
        }

        public IEnumerable<string> GetReferenceNames()
        {
            return references.Select(r => r.Name);    
        }
    }
}
