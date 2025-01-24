
namespace Kolcsonzo
{
    
    internal class Program
    {

        static void Main(string[] args)
        {
            List<Kolcsonzes> kolcsonzesek = new();
            foreach (var item in File.ReadAllLines(@"..\..\..\src\kolcsonzes.txt").Skip(1))
            {
                kolcsonzesek.Add(new Kolcsonzes(item));
            }

            Console.WriteLine("4. feladat:");
            Console.WriteLine($"{kolcsonzesek.Count()} kölcsönzés adatai találhatók.");

            Console.WriteLine("5. feladat:");
            Console.Write("Írd be a nevet: ");

            string bekertNev = Console.ReadLine();

            if (kolcsonzesek.Exists(k => k.Nev == bekertNev))
            {
                var emberKolcsonzesei = kolcsonzesek.Where(k => k.Nev == bekertNev);

                Console.WriteLine($"{bekertNev} Ettől eddig bérelt hajót/hajókat:");
                foreach (var item in emberKolcsonzesei)
                {
                    Console.WriteLine($"{item.ElvitelOraja}:{item.ElvitelPerce} - {item.VisszahozatalOraja}:{item.VisszahozatalPerce}");
                }
            }
            else
            {
                Console.WriteLine("Nem volt ilyen nevű kölcsönző!");
            }

            int kulfoldiek = kolcsonzesek.Count(k => k.Nev.Contains(","));

            Console.WriteLine($"{kolcsonzesek.Count - kulfoldiek} magyar, {kulfoldiek} külföldi volt aznap.");

            Console.ReadKey();
        }
    }
}
