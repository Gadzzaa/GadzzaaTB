using System;
using System.Windows;
using System.Windows.Controls;

namespace GadzzaaTB
{
    /// <summary>
    ///     Interaction logic for TwitchPage.xaml
    /// </summary>
    public partial class TwitchPage : Page
    {
        public TwitchPage()
        {
            InitializeComponent();
            if (Main.main.autoStartBot)
            {
                AutoStartBot.IsChecked = true;
            }
            else
            {
                if (!Main.main.autoStartBot) AutoStartBot.IsChecked = false;
            }

            /*      if (Settings1.Default.BotName != null)
                      BotNameY.Text = Main.main.BotNameMain;
                  if (Settings1.Default.BotOAuth != null)
                  {
                      BotOAuthY.Text = Main.main.BotOAuthMain;
                      HideOAuth();
                  } */
            if (Settings1.Default.ChannelName != null)
                ChannelNameY.Text = Main.main.ChannelNameMain;
        }

        /*   public void HideOAuth()
           {
               BotOAuthY.Text = "";
               if (Settings1.Default.BotOAuth.Length >= 1)
               {
                   for (int i = 1; i <= Settings1.Default.BotOAuth.Length; i++)
                   {
                       BotOAuthY.Text = BotOAuthY.Text + "*";
                   }
               }
           } */

        private void HideTwitch(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Main.main.MainA.MainW);
            Console.WriteLine("Navigation to Main Tab Request Sent!");
        }

        /*   private void BotName_GetFocus(object sender, RoutedEventArgs e)
           {
               if (BotNameY.Text == "Bot_Username")
                   BotNameY.Text = "";
           }
   
           private void BotName_LostFocus(object sender, RoutedEventArgs e)
           {
               if (BotNameY.Text == null || BotNameY.Text == "")
               {
   
                   BotNameY.Text = "Bot_Username";
               }
               if (BotNameY.Text.Contains(" "))
               {
                   MessageBox.Show("Bot's username contains unresolvable characters", "Error");
                   BotNameY.Text = "Bot_Username";
               }
               else
                   Settings1.Default.BotName = BotNameY.Text;
           }
   
          private void BotOAuth_Button(object sender, RoutedEventArgs e)
           {
               BotOAuthY.Text = Settings1.Default.BotOAuth;
               ShowButton.Visibility = Visibility.Hidden;
               ShowButton_Copy.Visibility = Visibility.Visible;
           } 
   
          private void BotOAuth2_Button(object sender, RoutedEventArgs e)
           {
               ShowButton_Copy.Visibility = Visibility.Hidden;
               ShowButton.Visibility = Visibility.Visible;
               BotOAuthY.Text = "";
               HideOAuth();
           } 
           private void BotOAuth_GetFocus(object sender, RoutedEventArgs e)
           {
               if (BotOAuthY.Text == "Bot_oAuth")
                   BotOAuthY.Text = "";
           }
   
           private void BotOAuth_LostFocus(object sender, RoutedEventArgs e)
           {
               if (BotOAuthY.Text == null || BotOAuthY.Text == "")
               {
                   BotOAuthY.Text = "Bot_oAuth";
               }
               else
               {
                   if (BotOAuthY.Text.Contains("*"))
                   {
                       OAuthContains = true;
                   }
                   else
                   {
                       OAuthContains = false;
                   }
   
                   if (OAuthContains == false)
                   {
                       Settings1.Default.BotOAuth = BotOAuthY.Text;
                   }
                   HideOAuth();
                   ShowButton.Visibility = Visibility.Visible;
                   ShowButton_Copy.Visibility = Visibility.Hidden;
               }
           } */
        private void ChannelNameY_GetFocus(object sender, RoutedEventArgs e)
        {
            if (ChannelNameY.Text == "Channel_Name")
                ChannelNameY.Text = "";
            Console.WriteLine("Got Focus for channel name");
        }

        private void ChannelNameY_LostFocus(object sender, RoutedEventArgs e)
        {
            if (ChannelNameY.Text == null || ChannelNameY.Text == "") ChannelNameY.Text = "Channel_Name";
            if (ChannelNameY.Text.Contains(" "))
            {
                MessageBox.Show("Channel's Name contains unresolvable characters", "Error");
                ChannelNameY.Text = "Channel_Name";
            }
            else
            {
                Settings1.Default.ChannelName = ChannelNameY.Text;
            }

            Console.WriteLine("Lost focus for channel name");
        }

        private void CheckBox1_Unchecked(object sender, RoutedEventArgs e)
        {
            Settings1.Default.AutoStartB = false;
            Console.WriteLine("Unchecked Bot Auto Start");
        }

        private void CheckBox1_Checked(object sender, RoutedEventArgs e)
        {
            Settings1.Default.AutoStartB = true;
            Console.WriteLine("Checked Bot Auto Start");
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            DisconnectB.IsEnabled = false;
            ConnectB.IsEnabled = true;
            Main.client.Disconnect();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            if (Settings1.Default.isLinked)
            {
                DisconnectB.IsEnabled = true;
                ConnectB.IsEnabled = false;
            }

            Main.ActivateBot();
        }

        private void DaPula(object sender, RoutedEventArgs e)
        {
            Main.main.bugReportp.Show();
        }
    }
}