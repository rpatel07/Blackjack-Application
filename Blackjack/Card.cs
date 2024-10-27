using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Blackjack_Starter.Blackjack
{
    public class Card
    {
        public int Rank;
        public string Suit;

        public Card(int rank, string suit)
        {
            Rank = rank;
            Suit = suit;
        }

        public int GetBlackjackValue()
        {
            if(Rank >= 10)
            {
                return 10;
            }
            return Rank;
        }

        public string GetImageFilename()
        {
            string rankString;
            if (Rank == 1)
            {
                rankString = "A";
            }
            else if(Rank == 11)
            {
                rankString = "J";
            }
            else if (Rank == 12)
            {

                rankString = "Q";
            }
            else if (Rank == 13)
            {
                rankString = "K";
            }
            else
            {
                rankString = Rank.ToString();
            }

            return rankString + Suit + ".jpg";
            
        }

    }
}
