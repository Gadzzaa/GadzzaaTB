﻿using System;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using GadzzaaTB.Windows;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TwitchLib.Client;
using TwitchLib.Client.Events;
using TwitchLib.Client.Models;
using TwitchLib.Communication.Clients;
using TwitchLib.Communication.Events;
using TwitchLib.Communication.Models;
using WebSocketSharp;


// Optional, exposes types-related classes, useful for storing result in variables.

namespace GadzzaaTB
{
    /// <summary>
    ///     Interaction logic for Page2.xaml
    /// </summary>
    public partial class Main
    {
        internal static Main main;
        public static bool ConnectedB;

        //             CLASSES

        public static TwitchClient client;

        public static JObject cache2 = new JObject();
        public static JObject cache3 = new JObject();
        public static bool firstMessageLoaded;
        public static bool firstMessageLoaded2;
        public bool autoStartBot = Settings1.Default.AutoStartB;
        public BugReport bugReportp;

        public string ChannelNameMain;
        public bool firsttime;
        public Integrations IntegP;
        public int iz = 0;
        public MainWindow MainA = Window.GetWindow(Application.Current.MainWindow) as MainWindow;
        public Osu_Page osup;
        public StreamCompanion StreamCP;
        public TwitchPage twitchp;
        public GosumemoryPage gosup;
        public WebSocket ws = new WebSocket("ws://localhost:20727/tokens");
        public WebSocket ws2 = new WebSocket("ws://localhost:24050/ws");


        public Main()
        {
            //   INITIALIZING
            main = this;
            InitializeComponent();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("|| SETTINGS ||");
            Console.WriteLine("Command 1: " + Settings1.Default.Command1);
            Console.WriteLine("Command 2: " + Settings1.Default.Command2);
            Console.WriteLine("Auto Start SC: " + Settings1.Default.AutoStart);
            Console.WriteLine("Twitch Bot Auto Start: " + Settings1.Default.AutoStartB);
            Console.WriteLine("Channel Name: " + Settings1.Default.ChannelName);
            Console.WriteLine("Location Folder SC: " + Settings1.Default.LocationFolder);
            Console.WriteLine("Account linked : " + Settings1.Default.isLinked);
            Console.WriteLine("||||||||||||||");
            Console.WriteLine();
            Console.WriteLine();
            if (autoStartBot) ActivateBot();
            //   GRAB SETTINGS
            ChannelNameMain = Settings1.Default.ChannelName;
            //   EVENT HANDLERS
            twitchp = new TwitchPage();
            osup = new Osu_Page();
            IntegP = new Integrations();
            StreamCP = new StreamCompanion(); 
            gosup = new GosumemoryPage();
            bugReportp = new BugReport();
            ws.OnMessage += Ws_OnMessage;
            ws.OnOpen += Ws_OnOpen;
            ws.OnClose += Ws_OnClose;
            ws.OnError += Ws_OnError;
            ws2.OnMessage += Ws2_OnMessage;
            ws2.OnOpen += Ws2_OnOpen;
            ws2.OnClose += Ws2_OnClose;
            ws2.OnError += Ws2_OnError;
            
        }

        private void Ws2_OnError(object sender, ErrorEventArgs e)
        {
            Console.WriteLine("ERROR ON WEBSOCKET2: " + e.Exception);
            Console.WriteLine("ERROR ON WEBSOCKET2: " + e.Exception);
            Console.WriteLine("ERROR ON WEBSOCKET2: " + e.Exception);
            Console.WriteLine("ERROR ON WEBSOCKET2: " + e.Exception);
            Console.WriteLine("ERROR ON WEBSOCKET2: " + e.Exception);
            Console.WriteLine("ERROR ON WEBSOCKET2: " + e.Exception);
            Console.WriteLine("ERROR ON WEBSOCKET2: " + e.Exception);
            Console.WriteLine("ERROR ON WEBSOCKET2: " + e.Exception);
        }

        private void Ws2_OnClose(object sender, CloseEventArgs e)
        {
            Console.Write("Websocket2 Closed!");

        }

        private void Ws2_OnOpen(object sender, EventArgs e)
        {
            Console.WriteLine("Connected to gosumemory Websocket!");
        }

        private void Ws2_OnMessage(object sender, MessageEventArgs e)
        {
            if (!cache3.HasValues)
            {
                cache3.Add("SR", JObject.Parse(e.Data).SelectToken("menu.bm.stats.fullSR"));
                cache3.Add("artist", JObject.Parse(e.Data).SelectToken("menu.bm.metadata.artist"));
                cache3.Add("title", JObject.Parse(e.Data).SelectToken("menu.bm.metadata.title")); 
                cache3.Add("mapper", JObject.Parse(e.Data).SelectToken("menu.bm.metadata.mapper"));
                cache3.Add("difficulty", JObject.Parse(e.Data).SelectToken("menu.bm.metadata.difficulty"));
                cache3.Add("str", JObject.Parse(e.Data).SelectToken("menu.mods.str"));
                cache3.Add("id", JObject.Parse(e.Data).SelectToken("menu.bm.id"));
                cache3.Add("ssPP", JObject.Parse(e.Data).SelectToken("menu.pp.100"));
                cache3.Add("99pp", JObject.Parse(e.Data).SelectToken("menu.pp.99"));
                cache3.Add("98pp", JObject.Parse(e.Data).SelectToken("menu.pp.98"));
                cache3.Add("97pp", JObject.Parse(e.Data).SelectToken("menu.pp.97"));
                cache3.Add("96pp", JObject.Parse(e.Data).SelectToken("menu.pp.96"));
                cache3.Add("95pp", JObject.Parse(e.Data).SelectToken("menu.pp.95"));
            }
            else
            {
                if (cache3.GetValue("SR") != JObject.Parse(e.Data).SelectToken("menu.bm.stats.fullSR"))
                {
                    cache3.Remove("SR");
                    cache3.Add("SR", JObject.Parse(e.Data).SelectToken("menu.bm.stats.fullSR"));
                }
                if (cache3.GetValue("artist") != JObject.Parse(e.Data).SelectToken("menu.bm.metadata.artist"))
                {
                    cache3.Remove("artist");
                    cache3.Add("artist", JObject.Parse(e.Data).SelectToken("menu.bm.metadata.artist"));
                }
                if (cache3.GetValue("title") != JObject.Parse(e.Data).SelectToken("menu.bm.metadata.title"))
                {
                    cache3.Remove("title");
                    cache3.Add("title", JObject.Parse(e.Data).SelectToken("menu.bm.metadata.title"));
                }
                if (cache3.GetValue("mapper") != JObject.Parse(e.Data).SelectToken("menu.bm.metadata.mapper"))
                {
                    cache3.Remove("mapper");
                    cache3.Add("mapper", JObject.Parse(e.Data).SelectToken("menu.bm.metadata.mapper"));
                }
                if (cache3.GetValue("difficulty") != JObject.Parse(e.Data).SelectToken("menu.bm.metadata.difficulty"))
                {
                    cache3.Remove("difficulty");
                    cache3.Add("difficulty", JObject.Parse(e.Data).SelectToken("menu.bm.metadata.difficulty"));
                }
                if (cache3.GetValue("str") != JObject.Parse(e.Data).SelectToken("menu.mods.str"))
                {
                    cache3.Remove("str");
                    cache3.Add("str", JObject.Parse(e.Data).SelectToken("menu.mods.str"));
                }
                if (cache3.GetValue("id") != JObject.Parse(e.Data).SelectToken("menu.bm.id"))
                {
                    cache3.Remove("id");
                    cache3.Add("id", JObject.Parse(e.Data).SelectToken("menu.bm.id"));
                }
                if (cache3.GetValue("ssPP") != JObject.Parse(e.Data).SelectToken("menu.pp.100"))
                {
                    cache3.Remove("ssPP");
                    cache3.Add("ssPP", JObject.Parse(e.Data).SelectToken("menu.pp.100"));
                }
                if (cache3.GetValue("99pp") != JObject.Parse(e.Data).SelectToken("menu.pp.99"))
                {
                    cache3.Remove("99pp");
                    cache3.Add("99pp", JObject.Parse(e.Data).SelectToken("menu.pp.99"));
                }
                if (cache3.GetValue("98pp") != JObject.Parse(e.Data).SelectToken("menu.pp.98"))
                {
                    cache3.Remove("98pp");
                    cache3.Add("98pp", JObject.Parse(e.Data).SelectToken("menu.pp.98"));
                }
                if (cache3.GetValue("97pp") != JObject.Parse(e.Data).SelectToken("menu.pp.97"))
                {
                    cache3.Remove("97pp");
                    cache3.Add("97pp", JObject.Parse(e.Data).SelectToken("menu.pp.97"));
                }
                if (cache3.GetValue("96pp") != JObject.Parse(e.Data).SelectToken("menu.pp.96"))
                {
                    cache3.Remove("96pp");
                    cache3.Add("96pp", JObject.Parse(e.Data).SelectToken("menu.pp.96"));
                }
                if (cache3.GetValue("95pp") != JObject.Parse(e.Data).SelectToken("menu.pp.95"))
                {
                    cache3.Remove("95pp");
                    cache3.Add("95pp", JObject.Parse(e.Data).SelectToken("menu.pp.95"));
                }
            }

            //Console.WriteLine(cache3);

        }

        private void Ws_OnError(object sender, ErrorEventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                var op = main.Dispatcher.BeginInvoke((Action) (() =>
                {
                    {
                        StreamCP.Status.Content = "Status: Error";
                        StreamCP.Status.Foreground = Brushes.Red;
                        StreamCP.StartWebSocket.Visibility = Visibility.Visible;
                        StreamCP.DisconnectSCWebsocket.Visibility = Visibility.Hidden;
                    }
                }));
            });
            Console.WriteLine("ERROR ON WEBSOCKET: " + e.Exception);
            Console.WriteLine("ERROR ON WEBSOCKET: " + e.Exception);
            Console.WriteLine("ERROR ON WEBSOCKET: " + e.Exception);
            Console.WriteLine("ERROR ON WEBSOCKET: " + e.Exception);
            Console.WriteLine("ERROR ON WEBSOCKET: " + e.Exception);
            Console.WriteLine("ERROR ON WEBSOCKET: " + e.Exception);
            Console.WriteLine("ERROR ON WEBSOCKET: " + e.Exception);
            Console.WriteLine("ERROR ON WEBSOCKET: " + e.Exception);
        }

        private void Ws_OnClose(object sender, CloseEventArgs e)
        {
            Console.Write("Websocket Closed!");
            Task.Factory.StartNew(() =>
            {
                var op = main.Dispatcher.BeginInvoke((Action) (() =>
                {
                    {
                        StreamCP.Status.Content = "Status: Offline";
                        StreamCP.Status.Foreground = Brushes.Red;
                        StreamCP.StartWebSocket.Visibility = Visibility.Visible;
                        StreamCP.DisconnectSCWebsocket.Visibility = Visibility.Hidden;
                    }
                }));
            });
        }

        private void Ws_OnOpen(object sender, EventArgs e)
        {
            var data = new[]
            {
                "mStars",
                "mapArtistTitle",
                "mapDiff",
                "mods",
                "dl",
                "osu_mSSPP",
                "osu_m99PP",
                "osu_m98PP",
                "osu_m97PP",
                "osu_m96PP",
                "osu_m95PP"
            };
            ws.Send(JsonConvert.SerializeObject(data));
            Console.WriteLine("Data sent to StreamCompanion: " + JsonConvert.SerializeObject(data));
            Console.WriteLine("Connected to StreamCompanion websocket!");
            Task.Factory.StartNew(() =>
            {
                var op = main.Dispatcher.BeginInvoke((Action) (() =>
                {
                    {
                        StreamCP.Status.Content = "Status: Online";
                        StreamCP.Status.Foreground = Brushes.Green;
                        StreamCP.StartWebSocket.Visibility = Visibility.Hidden;
                        StreamCP.DisconnectSCWebsocket.Visibility = Visibility.Visible;
                    }
                }));
            });
        }

        private void Ws_OnMessage(object sender, MessageEventArgs e)
        {
            Console.WriteLine("Data Recieved from StreamCompanion: " + e.Data);
            cache2.Merge(JObject.Parse(e.Data));
            Console.WriteLine("Data Merged from StreamCompanion: " + cache2);
            firstMessageLoaded = true;
            Console.WriteLine("First Data Recieved: " + firstMessageLoaded);
            //   Console.WriteLine(cache2);
            //   Console.WriteLine("TEST: " + cache2.GetValue("osuIsRunning"));
        }

        public static void ActivateBot()
        {
            Console.WriteLine("Activate Bot Request Sent !");
            var bot = new Bot();
            Console.ReadLine();
        }

        // BUTTONS

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(IntegP);
            Console.WriteLine("Navigation to Integrations Tab Request Sent!");
        }

        private void ShowTwitch(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(twitchp);
            if (ConnectedB)
            {
                if (!main.firsttime)
                {
                    main.twitchp.ConnectB.Visibility = Visibility.Hidden;
                    main.twitchp.DisconnectB.Visibility = Visibility.Visible;
                }

                main.twitchp.StatusB.Content = "Status: Online";
                main.twitchp.StatusB.Foreground = Brushes.Green;
                main.twitchp.AutoStartBot.IsEnabled = true;
                main.twitchp.ChannelNameY.IsEnabled = false;
            }
            else if (!Settings1.Default.isLinked)
            {
                if (!main.firsttime)
                {
                    main.twitchp.ConnectB.Visibility = Visibility.Visible;
                    main.twitchp.DisconnectB.Visibility = Visibility.Hidden;
                }

                main.twitchp.StatusB.Content = "Status: Unlinked";
                main.twitchp.StatusB.Foreground = Brushes.Yellow;
                Settings1.Default.AutoStartB = false;
                main.twitchp.AutoStartBot.IsEnabled = false;
                main.twitchp.ChannelNameY.IsEnabled = true;
            }
            else if (!ConnectedB)
            {
                if (!main.firsttime)
                {
                    main.twitchp.ConnectB.Visibility = Visibility.Visible;
                    main.twitchp.DisconnectB.Visibility = Visibility.Hidden;
                }

                main.twitchp.StatusB.Content = "Status: Offline";
                main.twitchp.StatusB.Foreground = Brushes.Red;
                main.twitchp.AutoStartBot.IsEnabled = true;
                main.twitchp.ChannelNameY.IsEnabled = false;
            }

            Console.WriteLine("Navigation to Twitch Tab Request Sent!");
        }

        private void ShowOsuBot(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(osup);
            Console.WriteLine("Navigation to osu! Tab Request Sent!");
        }

        public string DecodeFrom64(string encodedData)
        {
            var encoder = new UTF8Encoding();
            var utf8Decode = encoder.GetDecoder();
            var todecode_byte = Convert.FromBase64String(encodedData);
            var charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            var decoded_char = new char[charCount];
            utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            var result = new string(decoded_char);
            return result;
        }

        public void DaPula(object sender, RoutedEventArgs e)
        {
            bugReportp.Show();
        }

        public class Bot
        {
            public int i;
            public int i2;
            public string npppText;
            public string npText;

            public int x;
            public int y;

            public Bot()
            {
                var credentials = new ConnectionCredentials(Passwords.TwitchBotName,
                    main.DecodeFrom64(Passwords.TwitchBotOAuth));
                var clientOptions = new ClientOptions
                {
                    MessagesAllowedInPeriod = 750,
                    ThrottlingPeriod = TimeSpan.FromSeconds(30)
                };
                var customClient = new WebSocketClient(clientOptions);
                client = new TwitchClient(customClient);
                client.Initialize(credentials, Settings1.Default.ChannelName);

                client.OnMessageReceived += Client_OnMessageReceived;
                client.OnConnected += Client_OnConnected;
                client.OnDisconnected += ClientMain_OnDisconnected;
                client.OnLog += Client_OnLog;
                client.OnIncorrectLogin += Client_IncorrectLogin;

                client.Connect();
                Console.WriteLine("Client Request 2 Sent");
            }

            private void Client_IncorrectLogin(object sender, OnIncorrectLoginArgs e)
            {
                MessageBox.Show("Incorrect Login Details! Make sure you entered your channel name correctly!\n" +
                                "In case your channel name is correctly written, CONTACT gadzzaa ASAP!\n" +
                                "Either through discord either through a bug report", "Twitch ERROR!");
            }

            private void Client_OnLog(object sender, OnLogArgs e)
            {
                Console.WriteLine("TwitchClient :  " + e.Data);
            }

            private void Client_OnConnected(object sender, OnConnectedArgs e)
            {
                if (Settings1.Default.isLinked)
                {
                    Console.WriteLine("Connected to " + Settings1.Default.ChannelName);
                    Console.WriteLine("GadzzaaTB online!");
                    client.SendMessage(Settings1.Default.ChannelName, "GadzzaaTB online!");
                    ConnectedB = true;
                    Task.Factory.StartNew(() =>
                    {
                        var op = main.Dispatcher.BeginInvoke((Action) (() =>
                        {
                            {
                                if (!main.firsttime)
                                {
                                    main.twitchp.ConnectB.Visibility = Visibility.Hidden;
                                    main.twitchp.DisconnectB.Visibility = Visibility.Visible;
                                    main.twitchp.ConnectB.IsEnabled = false;
                                    main.twitchp.DisconnectB.IsEnabled = true;
                                }

                                main.twitchp.StatusB.Content = "Status : ONLINE";
                                main.twitchp.StatusB.Foreground = Brushes.GreenYellow;
                                main.firsttime = false;
                            }
                        }));
                    });
                }
                else
                {
                    client.SendMessage(Settings1.Default.ChannelName,
                        "Verification Required! Type '!verify' to verify that your are the owner of the account");
                }
            }

            private void ClientMain_OnDisconnected(object sender,
                OnDisconnectedEventArgs e)
            {
                Console.WriteLine("Disconnected from Twitch");
                ConnectedB = false;
                client.LeaveChannel(Settings1.Default.ChannelName);
                Task.Factory.StartNew(() =>
                {
                    var op = main.Dispatcher.BeginInvoke((Action) (() =>
                    {
                        {
                            if (!main.firsttime)
                            {
                                main.twitchp.ConnectB.Visibility = Visibility.Visible;
                                main.twitchp.DisconnectB.Visibility = Visibility.Hidden;
                                main.twitchp.ConnectB.IsEnabled = true;
                                main.twitchp.DisconnectB.IsEnabled = false;
                            }

                            main.twitchp.StatusB.Content = "Status : OFFLINE";
                            main.twitchp.StatusB.Foreground = Brushes.Red;
                            main.firsttime = false;
                        }
                    }));
                });
            }

            private void Client_OnMessageReceived(object sender, OnMessageReceivedArgs e)
            {
                if (Settings1.Default.isLinked)
                {
                    if (e.ChatMessage.Message.Equals(Settings1.Default.Command1))
                    {
                        i = 0;
                        i2 = 0;
                        npText = "";
                        foreach (var process in Process.GetProcessesByName("osu!StreamCompanion")) i = 1;

                        foreach (var process in Process.GetProcessesByName("osu!")) i2 = 1;
                        if (i == 0)
                            npText =
                                "StreamCompanion is not running! Please start it manually from the integrations tab!";
                        else if (i2 == 0)
                            npText = "osu! is not running! Please open the game before using the command!";
                        else if (i == 1 && i2 == 1)
                            if (cache2 != null && cache2.HasValues && firstMessageLoaded)
                            {
                                npText =
                                    "Now Playing | " + decimal.Round((decimal) cache2.GetValue("mStars"), 2) + "⭐ | " +
                                    cache2.GetValue("mapArtistTitle") + cache2.GetValue("mapDiff!") + " | Mods: " +
                                    cache2.GetValue("mods") + " | Download: " + cache2.GetValue("dl");
                            }
                            else
                            {
                                npText =
                                    "Error on websocket, please try again | If you are still getting this error, please make sure StreamCompanion is online and ready to use!";
                                Console.WriteLine(cache2);
                                Console.WriteLine(cache2.HasValues);
                                Console.WriteLine(firstMessageLoaded);
                                main.ws.Close();
                                main.ws.Connect();
                            }

                        client.SendMessage(e.ChatMessage.Channel, npText);

                        x = x + 1;
                        Task.Factory.StartNew(() =>
                        {
                            var op = main.Dispatcher.BeginInvoke((Action) (() =>
                            {
                                {
                                    Osu_Page.AddNpValue(x);
                                }
                            }));
                        });
                        Console.WriteLine("i value for command1: " + i);
                        Console.WriteLine("i2 value for command1: " + i2);
                        Console.WriteLine("Command 1 text: " + npText);
                        Console.WriteLine("X Value: " + x);
                    }
                    else if (e.ChatMessage.Message.Equals(Settings1.Default.Command2))
                    {
                        i = 0;
                        i2 = 0;
                        npppText = "";
                        foreach (var process in Process.GetProcessesByName("osu!StreamCompanion")) i = 1;

                        foreach (var process in Process.GetProcessesByName("osu!")) i2 = 1;

                        if (i == 0)
                            npppText =
                                "StreamCompanion is not running! Please start it manually from the integrations tab!";
                        else if (i2 == 0)
                            npppText = "osu! is not running! Please open the game before using the command!";
                        else if (i == 1 && i2 == 1)
                            if (cache2 != null && cache2.HasValues && firstMessageLoaded)
                            {
                                npppText =
                                    "PP Values | 100 % : " + decimal.Round((decimal) cache2.GetValue("osu_mSSPP"), 2) +
                                    " pp | 99 % : " +
                                    decimal.Round((decimal) cache2.GetValue("osu_m99PP"), 2) + " pp | 98 % : " +
                                    decimal.Round((decimal) cache2.GetValue("osu_m98PP"), 2) +
                                    " pp | 97 % : " + decimal.Round((decimal) cache2.GetValue("osu_m97PP"), 2) +
                                    " pp | 96 % : " +
                                    decimal.Round((decimal) cache2.GetValue("osu_m96PP"), 2) + " pp | 95 % : " +
                                    decimal.Round((decimal) cache2.GetValue("osu_m95PP"), 2) +
                                    " pp | Download: " + cache2.GetValue("dl");
                            }
                            else
                            {
                                npppText = "Error on websocket";
                                Console.WriteLine(cache2);
                                Console.WriteLine(cache2.HasValues);
                                Console.WriteLine(firstMessageLoaded);
                            }

                        client.SendMessage(e.ChatMessage.Channel, npppText);
                        y = y + 1;
                        Task.Factory.StartNew(() =>
                        {
                            var op = main.Dispatcher.BeginInvoke((Action) (() =>
                            {
                                {
                                    Osu_Page.AddNpppValue(y);
                                }
                            }));
                        });
                        Console.WriteLine("i value for command2: " + i);
                        Console.WriteLine("i2 value for command2: " + i2);
                        Console.WriteLine("Command 2 text: " + npppText);
                        Console.WriteLine("Y Value: " + y);
                    }
                    else if (e.ChatMessage.Message.Equals("!unverify"))
                    {
                        if (e.ChatMessage.Username == e.ChatMessage.Channel)
                        {
                            client.SendMessage(e.ChatMessage.Channel, "Account unlinked!");
                            Console.WriteLine("Account Unlinked!");
                            Task.Factory.StartNew(() =>
                            {
                                var op = main.Dispatcher.BeginInvoke((Action) (() =>
                                {
                                    {
                                        Settings1.Default.isLinked = false;
                                        Settings1.Default.AutoStartB = false;
                                        main.twitchp.AutoStartBot.IsChecked = false;
                                        main.twitchp.AutoStartBot.IsEnabled = false;
                                        main.twitchp.ChannelNameY.IsEnabled = true;
                                        main.twitchp.ConnectB.IsEnabled = true;
                                        main.twitchp.ConnectB.Visibility = Visibility.Visible;
                                        main.twitchp.DisconnectB.Visibility = Visibility.Hidden;
                                        main.twitchp.StatusB.Content = "Status : UNLINKED";
                                        main.twitchp.StatusB.Foreground = Brushes.Yellow;
                                    }
                                }));
                            });
                            client.Disconnect();
                        }
                    }
                    else if (e.ChatMessage.Message.Equals("!commands"))
                    {
                        client.SendMessage(e.ChatMessage.Channel,
                            "!" + Settings1.Default.Command1 + ", !" + Settings1.Default.Command2 +
                            ", !verify, !unverify, !commands");
                        Console.WriteLine("!commands sent");
                    }
                }
                else if (e.ChatMessage.Message.Equals("!verify"))
                {
                    if (e.ChatMessage.Channel == "gadzzaa".ToLower() || e.ChatMessage.Channel == "howl_osu".ToLower())
                    {
                        if (e.ChatMessage.Channel == e.ChatMessage.Username)
                        {
                            client.SendMessage(e.ChatMessage.Channel, "Verification Process Completed!");
                            Settings1.Default.isLinked = true;
                            Console.WriteLine("Twitch Verified!");
                            client.SendMessage(e.ChatMessage.Channel, "If you wish to unlink, type '!unverify' !");
                            Task.Factory.StartNew(() =>
                            {
                                var op = main.Dispatcher.BeginInvoke((Action) (() =>
                                {
                                    {
                                        main.twitchp.AutoStartBot.IsEnabled = true;
                                        main.twitchp.ChannelNameY.IsEnabled = false;
                                        main.twitchp.ConnectB.IsEnabled = true;
                                        main.twitchp.StatusB.Content = "Status : OFFLINE";
                                        main.twitchp.StatusB.Foreground = Brushes.Red;
                                    }
                                }));
                            });
                            client.Disconnect();
                        }
                        else
                        {
                            client.SendMessage(e.ChatMessage.Channel, "You are not eligible to use this command!");
                            Console.WriteLine("Verification command acces denied");
                        }
                    }
                    else
                    {
                        client.SendMessage(e.ChatMessage.Channel, "Channel not whitelisted!");
                        Console.WriteLine("Verification command acces denied");
                        Task.Factory.StartNew(() =>
                        {
                            var op = main.Dispatcher.BeginInvoke((Action) (() =>
                            {
                                {
                                    main.twitchp.ConnectB.IsEnabled = true;
                                }
                            }));
                        });
                    }
                }
            }
        }
    }
}