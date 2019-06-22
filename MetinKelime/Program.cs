using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
namespace MetinKelime
{
    class Program
    {
        static void Main(string[] args)
        {
            string Word;


            Word = System.IO.File.ReadAllText(@"C:\Users\Gökhan\Downloads\15-text\moby-006.txt");
            var Value = Word.Split(' ');
            Dictionary<string, int> RepeatedWordCount = new Dictionary<string, int>();
            for (int i = 0; i < Value.Length; i++)
            {
                if (RepeatedWordCount.ContainsKey(Value[i]))
                {
                    int value = RepeatedWordCount[Value[i]];
                    RepeatedWordCount[Value[i]] = value + 1;
                }
                else
                {
                    RepeatedWordCount.Add(Value[i], 1);
                }
            }


            Console.WriteLine();
            Console.WriteLine("------------------------------------");
            Console.WriteLine("Tekrar Eden Kelime ve Sayıları");

            XDocument XMLDoc = new XDocument(

                    new XDeclaration("1.0", "utf-8", "yes")



                    );




            XMLDoc = new XDocument(
                    new XElement("Kelimeler",
                    new XElement("metin", from rep in RepeatedWordCount select new XElement("Kelime", rep)))
                    );

            XMLDoc.Save("D:/Tekraredenkelimelerciktisi112.xml");
            Console.ReadKey();
        }
    }
}
