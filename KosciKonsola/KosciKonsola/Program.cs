using System;

public class Kosc
{
    public static int LiczbaInstancji = 0;
    public static string[] NazwyPlikow = { "kosc0.png", "kosc1.png", "kosc2.png", "kosc3.png", "kosc4.png", "kosc5.png", "kosc6.png" };
    private static Random random = new Random();

    public int LiczbaOczek;
    public int IdentyfikatorPliku;
    public bool JestDostepna;

    public Kosc(int wartosc)
    {
        if (wartosc >= 1 && wartosc <= 6)
        {
            LiczbaOczek = wartosc;
            IdentyfikatorPliku = wartosc;
        }
        else
        {
            LiczbaOczek = 0;
            IdentyfikatorPliku = 0;
        }
        JestDostepna = true;
        LiczbaInstancji++;
    }

    public Kosc()
    {
        int wylosowana = random.Next(1, 7);
        LiczbaOczek = wylosowana;
        IdentyfikatorPliku = wylosowana;
        JestDostepna = true;
        LiczbaInstancji++;
    }

    public void Rzuc()
    {
        if (JestDostepna)
        {
            int wylosowana = random.Next(1, 7);
            LiczbaOczek = wylosowana;
            IdentyfikatorPliku = wylosowana;
        }
    }

    public void Blokuj()
    {
        JestDostepna = false;
    }

    public string PobierzTekstowo()
    {
        return LiczbaOczek switch
        {
            1 => "jeden",
            2 => "dwa",
            3 => "trzy",
            4 => "cztery",
            5 => "pięć",
            6 => "sześć",
            _ => "zero"
        };
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Console.Write("Podaj wartość dla pierwszej kości (1-6): ");
        int.TryParse(Console.ReadLine(), out int wprowadzona);

        Kosc kosc1 = new Kosc(wprowadzona);
        PokazInformacje(kosc1);

        Kosc kosc2 = new Kosc();
        PokazInformacje(kosc2);
    }

    private static void PokazInformacje(Kosc k)
    {
        Console.WriteLine($"Liczba instancji: {Kosc.LiczbaInstancji}");
        Console.WriteLine($"Oczka: {k.LiczbaOczek} ({k.PobierzTekstowo()})");
        Console.WriteLine($"Plik: {Kosc.NazwyPlikow[k.IdentyfikatorPliku]}\n");
    }
}