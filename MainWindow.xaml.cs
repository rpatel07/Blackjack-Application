using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Blackjack_Starter.Blackjack;

namespace Blackjack_Starter
{
    public partial class MainWindow : Window
    {
        private readonly BlackjackEngine game;

        public MainWindow()
        {
            InitializeComponent();
            game = new BlackjackEngine();
            game.Init();
            RefreshScreen();
            RefreshDealerScreen();
        }

        private void Hit_Click(object sender, RoutedEventArgs e)
        {
            game.DealToPlayer();
            RefreshScreen();
            if (game.IsPlayerBusted())
            {    
                MessageBox.Show("Player Busted!! Dealer Won");
                game.ResetHandAndDeck();
               
                ResetGame();
            }
        }

        private void Stand_Click(object sender, RoutedEventArgs e)
        {
            while(game.ShouldDealerGetCard())
            {
                game.DealToDealer();
                RefreshDealerScreen();
            }
            if (game.IsDealerBusted())
            {
                MessageBox.Show("Dealer Busted !! Player Won");
                game.ResetHandAndDeck();
                ResetGame();
            }
            else
            {
                int playerValue = game.PlayerHandValue();
                int dealerValue = game.DealerHandValue();
                if(playerValue > dealerValue)
                {
                    MessageBox.Show("Player Won");
                   
                }
                else if(dealerValue > playerValue) 
                {
                    MessageBox.Show("Dealer Won");
                    
                }
                else
                {
                    MessageBox.Show("Match Draw");
                }
                game.ResetHandAndDeck();
                ResetGame();
            }
        }

        private void RefreshScreen()
        {
            PlayerPanel.Children.Clear();
            foreach (Card c in game.PlayerHand)
            {
                ShowCard(c, PlayerPanel);
            }
        }

        private void RefreshDealerScreen()
        {
            DealerPanel.Children.Clear();
            foreach (Card c in game.DealerHand)
            {
                ShowCard(c, DealerPanel);
            }
        }

        private void ShowCard(Card c, WrapPanel panel)
        {
            string fileName = @"E:\Sem-4\net\Blackjack-Starter\JPEG\" + c.GetImageFilename();
            Image image = new Image();
            image.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri(fileName));
            panel.Children.Add(image);
        }

        private void ResetGame()
        {
            game.Init();
            RefreshScreen() ;
            RefreshDealerScreen();
        }
    }
}
