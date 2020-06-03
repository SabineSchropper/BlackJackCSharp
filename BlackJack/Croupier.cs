using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack
{
    class Croupier
    {
        List<Card> Cards = new List<Card>();
        List<Card> OpponentCards = new List<Card>();
        public void HandOutCard()
        {
            bool wantsToStop = false;

            Card card = new Card();
            Cards.Add(card);
            wantsToStop = checkIfOpponentStops();
            if (!wantsToStop)
            {
                Card card1 = new Card();
                OpponentCards.Add(card1);
            }
        }
        public bool checkIfOpponentStops()
        {
            int value = 0;
            bool wantsToStop = false;
            for(int i = 0; i < OpponentCards.Count; i++)
            {
                value = value + OpponentCards[i].Number;
            }
            if(value > 15)
            {
                wantsToStop = true;
            }
            return wantsToStop;
        }
        public string CheckValue()
        {
            string result = "";
            int value = 0;
            int opponentValue = 0;
            for (int i = 0; i < Cards.Count; i++)
            {
                value = value + Cards[i].Number;
            }
            for (int i = 0; i < OpponentCards.Count; i++)
            {
                opponentValue = opponentValue + OpponentCards[i].Number;
            }
            if (value > 21 || opponentValue == 21)
            {
                result = "verloren";
            }
            else if (value == 21 || opponentValue > 21) 
            {
                result = "gewonnen";
            }
            else
            {
                result = "weiter";
            }
            return result;
        }
        public void ShowCards()
        {
            ShowPlayerCards();
            Console.Write("Karten des Gegners: ");
            for (int i = 0; i < OpponentCards.Count; i++)
            {
                Console.Write(OpponentCards[i].Number + " ");
            }
        }
        public void ShowPlayerCards()
        {
            Console.Write("Deine Karten: ");
            for (int i = 0; i < Cards.Count; i++)
            {
                Console.Write(Cards[i].Number +" ");
            }
            Console.WriteLine();
        }
        public string MakeEndCheck()
        {
            int value = 0;
            int opponentValue = 0;
            string result = CheckValue();
            if (result.Equals("weiter"))
            {
                for (int i = 0; i < Cards.Count; i++)
                {
                    value = value + Cards[i].Number;
                }
                for (int i = 0; i < OpponentCards.Count; i++)
                {
                    opponentValue = opponentValue + OpponentCards[i].Number;
                }
                opponentValue = OpponentDecision(opponentValue);
                if(value > opponentValue || opponentValue > 21)
                {
                    result = "gewonnen";
                }
                else if ( value == opponentValue)
                {
                    result = "unentschieden";
                }
                else
                {
                    result = "verloren";
                }
            }
            return result;
        }
        public int OpponentDecision(int opponentValue)
        {
            int value = 0;

            if (opponentValue <= 15)
            {
                while (value <= 15)
                {
                    Card card1 = new Card();
                    OpponentCards.Add(card1);

                    for (int i = 0; i < OpponentCards.Count; i++)
                    {
                        value = value + OpponentCards[i].Number;
                    }
                }
                opponentValue = value;
            }

            return opponentValue;
        }
    }
}

