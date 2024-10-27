using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Blackjack_Starter.Blackjack
{
  public class BlackjackEngine
    {
        public List<Card> Deck = new List<Card>();
        public  List<Card> PlayerHand = new List<Card>();
        public  List<Card> DealerHand = new List<Card>();

        // String wholeDeck = "";
        string[] suits = { "H", "D", "C", "S" };

        internal void Init()
        {
            ResetHandAndDeck();

            foreach (var suit in suits)
            {
                for (int rank = 1; rank <= 13; rank++)
                {
                    Card card = new Card(rank, suit);
                    Deck.Add(card);
                }
            }

            ShuffleDeck();
            DealToDealer();
            
            DealToPlayer();
            DealToPlayer();
        }

        // Deck Shuffle
        public void ShuffleDeck()
        {
            Random random = new Random();
            for (int i = Deck.Count - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                Card temp = Deck[i];
                Deck[i] = Deck[j];
                Deck[j] = temp;
            }
        }

       // Delaing card to player
        public void DealToPlayer()
        {
            if (Deck.Count > 0)
            {
                Card c = Deck[0];
                Deck.RemoveAt(0);
                PlayerHand.Add(c);
            }
        }

        // dealing card to dealer 
        public void DealToDealer()
        {
            if (Deck.Count > 0)
            {
                Card c = Deck[0];
                Deck.RemoveAt(0);
                DealerHand.Add(c);
            }
        }

        // Counting player's hand value
        public int PlayerHandValue()
        {
            int sumOfPH = 0;
            int aceCount = 0;
            foreach (var card in PlayerHand)
            {
                sumOfPH += card.GetBlackjackValue();
                if (card.Rank == 1) aceCount++;
            }
            while(sumOfPH <= 11 && aceCount > 0)
            {
                sumOfPH += 10;
                aceCount--;
            }
            return sumOfPH;
        }

        // Checking if dealer busted or not
        public bool IsPlayerBusted()
        {
            int PHV = PlayerHandValue();
            return PHV > 21;
        }

        //Counting Dealer's Hand Value
        public int DealerHandValue()
        {
            int sumofDH = 0;
            int aceCount = 0;
            foreach(var card in DealerHand)
            {
                sumofDH += card.GetBlackjackValue();
                if(card.Rank == 1)aceCount++;
            }
            while( sumofDH <= 11 && aceCount > 0)
            {
                sumofDH += 10;
                aceCount--;
            }
            return sumofDH;
        }

        // Checking if dealer should hit or not
        public bool ShouldDealerGetCard()
        {
            int DHV = DealerHandValue();
            return DHV < 17;
        }

        //Checking if dealer busted or not
        public bool IsDealerBusted()
        {
            int DHV = DealerHandValue();
            return DHV > 21;
        }
        
        //Reset the hands and deck
        public void ResetHandAndDeck()
        {
            Deck.Clear();
            PlayerHand.Clear();
            DealerHand.Clear();
        }
    }
}
