using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cabel
{
    class OutputLanguage
    {
        string name;
        Dictionary<string, string> words = new Dictionary<string, string>();

        public string Name
        {
            get
            {
                return name;
            }
        }

        public Dictionary<string, string> Words
        {
            get
            {
                return words;
            }
        }

        public OutputLanguage(string name)
        {
            this.name = name;
        }

        public void WriteToFile(LanguageGenerator lg)
        {
            var targetFilePath = $"{name}.olang";

            if (File.Exists(targetFilePath))
                File.Move(targetFilePath, targetFilePath + ".old");
            //File.Create(targetFilePath);

            var header =
                $"{targetFilePath}\n" +
                $"Generated using Cabel\n" +
                $"seed:{lg.Seed}\n" +
                $"conf:wlen=[{lg.MinWordLength},{lg.MaxWordLength}]\n" + 
                $"refs:{string.Join(", ",lg.GetReferenceNames())}\n" +
                $"vers:{lg.Version}\n";

            var content = words.Select(kvp => $"{kvp.Key}: {kvp.Value}");

            var buffer = new List<string>();

            buffer.Add(header);
            buffer.Add("\n");
            foreach (var s in content)
                buffer.Add(s);

            File.WriteAllLines(targetFilePath, buffer);  
        }
    }
}
