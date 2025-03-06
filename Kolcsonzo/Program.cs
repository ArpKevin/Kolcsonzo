
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

            // -- dolgozat

            using StreamWriter sw = new StreamWriter(@"..\..\..\src\szemelyenkent.txt");

            foreach (var item in kolcsonzesek)
            {
                sw.WriteLine($"Azonosító: {item.HajoAzonosito}, Személyek száma: {item.SzemelyekSzama}, Egy személyre ennyibe kerül a hajó egyszer fél órára: {item.HajoHasznalatSzemelyenkentFelOrara} Ft.");
            }

            Console.WriteLine("A fájlbeírás megtörtént.\n");

            Console.Write("Add meg a hajó személyszámát: ");
            int bekertSzemelyszam = int.Parse(Console.ReadLine());

            Console.WriteLine(kolcsonzesek.Where(k => k.SzemelyekSzama == bekertSzemelyszam).OrderBy(k => k.ElvitelOraja).ThenBy(k => k.ElvitelPerce).First().HajoAzonosito);
            Console.WriteLine("\n");

            for (int i = 1; i <= 4; i++)
            {
                var ennyiSzemelyesHajok = kolcsonzesek.Where(k => k.SzemelyekSzama == i);
                if (ennyiSzemelyesHajok.Count() == 0) Console.WriteLine($"A(z) {i} személyes hajóból nem történt ma kölcsönzés.");
            }

            Console.ReadKey();
        }
    }
}
