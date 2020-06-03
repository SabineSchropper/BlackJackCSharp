using System;

namespace BlackJack
{
    class Program
    {
        static void Main(string[] args)
        {
            Croupier croupier = new Croupier();
            bool wantsToPlay = true;
            string input = "";
            string result = "";
            Console.WriteLine("Viel Glück beim Black Jack.");

            while (wantsToPlay)
            {
                Console.WriteLine("Karte ziehen oder aufhören? (j/n)");
                input = Console.ReadLine();
                if (input.Equals("j"))
                {
                    croupier.HandOutCard();
                    result = croupier.CheckValue();
                    if (result.Equals("verloren"))
                    {
                        wantsToPlay = false;
                        Console.WriteLine("Du hast verloren.");
                        croupier.ShowCards();
                    }
                    else if (result.Equals("gewonnen"))
                    {
                        wantsToPlay = false;
                        Console.WriteLine("Du hast gewonnen.");
                        croupier.ShowCards();
                    }
                    else if (result.Equals("weiter"))
                    {
                        croupier.ShowPlayerCards();
                    }
                }
                else if (input.Equals("n"))
                {
                    wantsToPlay = false;
                    result = croupier.MakeEndCheck();
                    if (result.Equals("verloren"))
                    {
                        Console.WriteLine("Du hast verloren.");
                    }
                    else if (result.Equals("gewonnen"))
                    {
                        Console.WriteLine("Du hast gewonnen.");
                    }
                    else if (result.Equals("unentschieden"))
                    {
                        Console.WriteLine("Das Spiel endet unentschieden.");
                    }
                    croupier.ShowCards();

                }
                else
                {
                    Console.WriteLine("Geben Sie bitte \"j\" oder \"n\" ein.");
                }
            }
        }
    }
}
