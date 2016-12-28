using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Cabel
{
    class Program
    {
        static void Main(string[] args)
        {
            var version = Assembly.GetEntryAssembly().GetName().Version;
            var lg = new LanguageGenerator(version, seed: new Random().Next());

            lg.AddLanguage(ReferenceLanguage.BuildFrom("lang/hebrew.txt"));
            lg.AddLanguage(ReferenceLanguage.BuildFrom("lang/chinese.txt"));
            lg.SetDictionary(WordDictionary.BuildFrom("wordsEn.txt"));

            var ol = lg.Generate();

            ol.WriteToFile(lg);
        }
    }
}
