using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Dij
{
    class Program
    {
        static void Main(string[] args)
        {
            List<nobeldijak> dijak = new List<nobeldijak>();
            StreamReader sr = new StreamReader("nobel.csv");
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                string[] adatok = sr.ReadLine().Split(';');
                if (adatok.Length == 3)
                {
                    dijak.Add(new nobeldijak(int.Parse(adatok[0]), adatok[1], adatok[2], ""));
                }
                else
                {
                    dijak.Add(new nobeldijak(int.Parse(adatok[0]), adatok[1], adatok[2], adatok[3]));
                }
            }
            sr.Close();
            List<nobeldijak> kikapott = dijak.Where(x => x.Evszam == 2017 && x.Tipus == "irodalmi").ToList();
            Console.WriteLine($"4. feladat: {kikapott[0].Keresztnev} {kikapott[0].Vezeteknev}");
            List<nobeldijak> curie = dijak.Where(x => x.Vezeteknev.Contains("Curie")).ToList();
            Console.WriteLine($"6. feladat:");
            foreach (var tag in curie)
            {
                Console.WriteLine($"\t{tag.Evszam}: {tag.Keresztnev} {tag.Vezeteknev}({tag.Tipus})");
            }
            Console.WriteLine($"7. feladat:");
            var valogat = dijak.GroupBy(x => x.Tipus);
            foreach (var valogatind in valogat)
            {
                Console.WriteLine($"\t{valogatind.Key}\t\t\t{valogatind.Count()} db");
            }
            Console.WriteLine($"8. feladat: orvosi.txt");
            StreamWriter sw = new StreamWriter("orvosi.txt");
            List<nobeldijak> orvosi = dijak.Where(x => x.Tipus == "orvosi").ToList();
            foreach (var orvosiind in orvosi)
            {
                sw.WriteLine($"{orvosiind.Evszam};{orvosiind.Keresztnev} {orvosiind.Vezeteknev}");
            }
        }
    }
}
