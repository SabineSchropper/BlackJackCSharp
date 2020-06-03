using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace BlackJack
{
    class Card
    {
        public int Number { get; set; }
        /// <summary>
        /// Constructor provides that every new Card has a random Number
        /// </summary>
        public Card()
        {
          int number = GenerateRandomCard();
          this.Number = number;
        }

        public static int GenerateRandomCard()
        {
            int number = 0;
            Random rand = new Random();
            number = rand.Next(1, 12);
            return number;
        }
    }
}
