using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TwitchLib.Client;
using TwitchLib.Client.Events;
using TwitchLib.Client.Models;
using TwitchLib.Communication.Clients;
using TwitchLib.Communication.Events;
using TwitchLib.Communication.Models;
using WebSocketSharp;

// ReSharper disable StringLiteralTypo


// Optional, exposes types-related classes, useful for storing result in variables.

namespace GadzzaaTB.Windows
{
    /// <summary>
    ///     Interaction logic for Page2.xaml
    /// </summary>
    public partial class Main
    {
        internal static Main main;

        //             CLASSES

        public static TwitchClient client;

        public static JObject cache2 = new JObject();
        public static JObject cache3 = new JObject();

        public static bool firstMessageLoaded;

        public string[] accessNames =
        {
            "gadzzaa",
            "howl_osu",
            "akakikn"
        };

        public BugReport bugReport;
        public string channelJoined;
        public bool firstTime;
        public bool gosumemoryStatus;

        public MainWindow mainA =
            Window.GetWindow(Application.Current.MainWindow ?? throw new InvalidOperationException()) as MainWindow;

        public bool streamCompanionStatus;

        public WebSocket ws = new WebSocket("ws://localhost:20727/tokens");
        public WebSocket ws2 = new WebSocket("ws://localhost:24050/ws");


        public Main()
        {
            main = this;
            InitializeComponent();

            ChannelName.Text = Settings1.Default.ChannelName;
            TwitchStatus.Foreground = Brushes.Yellow;
            if (Settings1.Default.isLinked) TwitchStatus.Foreground = Brushes.IndianRed;
            NpTextBox.Text = Settings1.Default.Command1.TrimStart('!');
            NpppTextBox.Text = Settings1.Default.Command2.TrimStart('!');
            firstTime = false;
            ActivateBot();
            Thread.Sleep(2000);
            bugReport = new BugReport();
            bugReport.Close();

            ws.OnMessage += Ws_OnMessage;
            ws.OnOpen += Ws_OnOpen;
            ws.OnClose += Ws_OnClose;
            ws.OnError += Ws_OnError;

            ws2.OnMessage += Ws2_OnMessage;
            ws2.OnOpen += Ws2_OnOpen;
            ws2.OnClose += Ws2_OnClose;
            ws2.OnError += Ws2_OnError;
            GotResponse();
        }

        private void StreamCompanionStatus_OnClick(object sender, RoutedEventArgs e)
        {
            WaitingForResponse();
            if (streamCompanionStatus)
            {
                ws.Close();
                foreach (var process in Process.GetProcessesByName("osu!StreamCompanion")) process.Kill();
            }
            else
            {
                foreach (var process in Process.GetProcessesByName("osu!StreamCompanion")) process.Kill();
                Process.Start(AppDomain.CurrentDomain.BaseDirectory + @"\StreamCompanion\osu!StreamCompanion.exe");
                Thread.Sleep(1000);
                ws.ConnectAsync();
            }
        }

        private void GosumemoryStatus_Click(object sender, RoutedEventArgs e)
        {
            WaitingForResponse();

            if (gosumemoryStatus)
            {
                ws2.Close();
                foreach (var process in Process.GetProcessesByName("WindowsTerminal")) process.Kill();
            }
            else
            {
                foreach (var process in Process.GetProcessesByName("WindowsTerminal")) process.Kill();
                Process.Start(AppDomain.CurrentDomain.BaseDirectory + @"\gosumemory\gosumemory.exe");
                Thread.Sleep(1000);
                ws2.ConnectAsync();
            }
        }


        private void NpTextBox_OnGotFocus(object sender, RoutedEventArgs e)
        {
            NpTextBox.Clear();
        }

        private void NpppTextBox_OnGotFocus(object sender, RoutedEventArgs e)
        {
            NpppTextBox.Clear();
        }


        private void NpTextBox_OnLostFocus(object sender, RoutedEventArgs e)
        {
            if (NpTextBox.Text == "") NpTextBox.Undo();
            else Settings1.Default.Command1 = "!" + NpTextBox.Text;
        }

        private void NpppTextBox_OnLostFocus(object sender, RoutedEventArgs e)
        {
            if (NpppTextBox.Text == "") NpppTextBox.Undo();
            else Settings1.Default.Command2 = "!" + NpppTextBox.Text;
        }

        private void TwitchStatus_OnClick(object sender, RoutedEventArgs e)
        {
            if (channelJoined != null)
                client.LeaveChannel(Settings1.Default.ChannelName);
            else client.JoinChannel(Settings1.Default.ChannelName);
        }

        private void ChannelName_OnGotFocus(object sender, RoutedEventArgs e)
        {
            ChannelName.Clear();
        }

        private void ChannelName_OnLostFocus(object sender, RoutedEventArgs e)
        {
            if (ChannelName.Text == "") ChannelName.Undo();
            else Settings1.Default.ChannelName = ChannelName.Text;
        }

        private void channelName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (firstTime) return;
            if (channelJoined != null) client.LeaveChannel(channelJoined);
            Settings1.Default.isLinked = false;
        }

        public static void ActivateBot()
        {
            var unused = new Bot();
            Console.ReadLine();
        }

        private void Ws2_OnError(object sender, ErrorEventArgs e)
        {
            Console.WriteLine(@"ERROR ON WS2: " + e.Exception);
        }

        private void Ws2_OnClose(object sender, CloseEventArgs e)
        {
            main.GotResponse();

            Console.Write(@"WS2 Closed!");
            Task.Factory.StartNew(() =>
            {
                var _ = main.Dispatcher.BeginInvoke((Action) (() =>
                {
                    {
                        GosumemoryStatus.Foreground = Brushes.IndianRed;
                    }
                }));
            });
            gosumemoryStatus = false;
        }

        private void Ws2_OnOpen(object sender, EventArgs e)
        {
            main.GotResponse();

            Console.WriteLine(@"Connected to gosumemory Websocket!");
            Task.Factory.StartNew(() =>
            {
                var _ = main.Dispatcher.BeginInvoke((Action) (() =>
                {
                    {
                        GosumemoryStatus.Foreground = Brushes.LimeGreen;
                    }
                }));
            });
            gosumemoryStatus = true;
        }

        private void Ws2_OnMessage(object sender, MessageEventArgs e)
        {
            if (!cache3.HasValues)
            {
                cache3.Add("mStars", JObject.Parse(e.Data).SelectToken("menu.bm.stats.fullSR"));
                cache3.Add("artist", JObject.Parse(e.Data).SelectToken("menu.bm.metadata.artist"));
                cache3.Add("title", JObject.Parse(e.Data).SelectToken("menu.bm.metadata.title"));
                cache3.Add("mapper", JObject.Parse(e.Data).SelectToken("menu.bm.metadata.mapper"));
                cache3.Add("mapDiff", JObject.Parse(e.Data).SelectToken("menu.bm.metadata.difficulty"));
                cache3.Add("mods", JObject.Parse(e.Data).SelectToken("menu.mods.str"));
                cache3.Add("dl", JObject.Parse(e.Data).SelectToken("menu.bm.id"));
                cache3.Add("osu_mSSPP", JObject.Parse(e.Data).SelectToken("menu.pp.100"));
                cache3.Add("osu_m99PP", JObject.Parse(e.Data).SelectToken("menu.pp.99"));
                cache3.Add("osu_m98PP", JObject.Parse(e.Data).SelectToken("menu.pp.98"));
                cache3.Add("osu_m97PP", JObject.Parse(e.Data).SelectToken("menu.pp.97"));
                cache3.Add("osu_m96PP", JObject.Parse(e.Data).SelectToken("menu.pp.96"));
                cache3.Add("osu_m95PP", JObject.Parse(e.Data).SelectToken("menu.pp.95"));
            }
            else
            {
                if (cache3.GetValue("mStars") != JObject.Parse(e.Data).SelectToken("menu.bm.stats.fullSR"))
                {
                    cache3.Remove("mStars");
                    cache3.Add("mStars", JObject.Parse(e.Data).SelectToken("menu.bm.stats.fullSR"));
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

                if (cache3.GetValue("mapDiff") != JObject.Parse(e.Data).SelectToken("menu.bm.metadata.difficulty"))
                {
                    cache3.Remove("mapDiff");
                    cache3.Add("mapDiff", JObject.Parse(e.Data).SelectToken("menu.bm.metadata.difficulty"));
                }

                if (cache3.GetValue("mods") != JObject.Parse(e.Data).SelectToken("menu.mods.str"))
                {
                    cache3.Remove("mods");
                    cache3.Add("mods", JObject.Parse(e.Data).SelectToken("menu.mods.str"));
                }

                if (cache3.GetValue("dl") != JObject.Parse(e.Data).SelectToken("menu.bm.id"))
                {
                    cache3.Remove("dl");
                    cache3.Add("dl", JObject.Parse(e.Data).SelectToken("menu.bm.id"));
                }

                if (cache3.GetValue("osu_mSSPP") != JObject.Parse(e.Data).SelectToken("menu.pp.100"))
                {
                    cache3.Remove("osu_mSSPP");
                    cache3.Add("osu_mSSPP", JObject.Parse(e.Data).SelectToken("menu.pp.100"));
                }

                if (cache3.GetValue("osu_m99PP") != JObject.Parse(e.Data).SelectToken("menu.pp.99"))
                {
                    cache3.Remove("osu_m99PP");
                    cache3.Add("osu_m99PP", JObject.Parse(e.Data).SelectToken("menu.pp.99"));
                }

                if (cache3.GetValue("osu_m98PP") != JObject.Parse(e.Data).SelectToken("menu.pp.98"))
                {
                    cache3.Remove("osu_m98PP");
                    cache3.Add("osu_m98PP", JObject.Parse(e.Data).SelectToken("menu.pp.98"));
                }

                if (cache3.GetValue("osu_m97PP") != JObject.Parse(e.Data).SelectToken("menu.pp.97"))
                {
                    cache3.Remove("osu_m97PP");
                    cache3.Add("osu_m97PP", JObject.Parse(e.Data).SelectToken("menu.pp.97"));
                }

                if (cache3.GetValue("osu_m96PP") != JObject.Parse(e.Data).SelectToken("menu.pp.96"))
                {
                    cache3.Remove("osu_m96PP");
                    cache3.Add("osu_m96PP", JObject.Parse(e.Data).SelectToken("menu.pp.96"));
                }

                if (cache3.GetValue("osu_m95PP") != JObject.Parse(e.Data).SelectToken("menu.pp.95"))
                {
                    cache3.Remove("osu_m95PP");
                    cache3.Add("osu_m95PP", JObject.Parse(e.Data).SelectToken("menu.pp.95"));
                }
            }

            //Console.WriteLine(cache3);
        }

        private void Ws_OnError(object sender, ErrorEventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                var _ = main.Dispatcher.BeginInvoke((Action) (() =>
                {
                    {
                        StreamCompanionStatus.Foreground = Brushes.DarkRed;
                    }
                }));
            });
            Console.WriteLine(@"ERROR ON WEBSOCKET: " + e.Exception);
        }

        private void Ws_OnClose(object sender, CloseEventArgs e)
        {
            main.GotResponse();

            Console.Write(@"Websocket Closed!");
            Task.Factory.StartNew(() =>
            {
                var _ = main.Dispatcher.BeginInvoke((Action) (() =>
                {
                    {
                        StreamCompanionStatus.Foreground = Brushes.IndianRed;
                    }
                }));
            });
            streamCompanionStatus = false;
        }

        private void Ws_OnOpen(object sender, EventArgs e)
        {
            main.GotResponse();

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
            Console.WriteLine(@"Data sent to StreamCompanion: " + JsonConvert.SerializeObject(data));
            Console.WriteLine(@"Connected to StreamCompanion websocket!");
            Task.Factory.StartNew(() =>
            {
                var _ = main.Dispatcher.BeginInvoke((Action) (() =>
                {
                    {
                        StreamCompanionStatus.Foreground = Brushes.LimeGreen;
                    }
                }));
            });
            streamCompanionStatus = true;
        }

        private void Ws_OnMessage(object sender, MessageEventArgs e)
        {
            Console.WriteLine(@"Data Recieved from StreamCompanion: " + e.Data);
            cache2.Merge(JObject.Parse(e.Data));
            Console.WriteLine(@"Data Merged from StreamCompanion: " + cache2);
            firstMessageLoaded = true;
            Console.WriteLine(@"First Data Recieved: " + firstMessageLoaded);
            //   Console.WriteLine(cache2);
            //   Console.WriteLine("TEST: " + cache2.GetValue("osuIsRunning"));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bugReport.Show();
        }

        private void WaitingForResponse()
        {
            Task.Factory.StartNew(() =>
            {
                var _ = main.Dispatcher.BeginInvoke((Action) (() =>
                {
                    {
                        TransparentNegru.Visibility = Visibility.Visible;
                        PleaseWait.Visibility = Visibility.Visible;
                        MainGrid.IsEnabled = false;
                    }
                }));
            });
        }

        private void GotResponse()
        {
            Task.Factory.StartNew(() =>
            {
                var _ = main.Dispatcher.BeginInvoke((Action) (() =>
                {
                    {
                        TransparentNegru.Visibility = Visibility.Hidden;
                        PleaseWait.Visibility = Visibility.Hidden;
                        MainGrid.IsEnabled = true;
                    }
                }));
            });
        }

        public class Bot
        {
            public int i;
            public int i2;
            public int i3;
            public string npppText;
            public string npText;

            public int x;
            public int y;

            public Bot()
            {
                var credentials = new ConnectionCredentials(Passwords.TwitchBotName,
                    "oauth:bt8bcegge9bbt2r1b2izez56k6ll5q");
                var clientOptions = new ClientOptions
                {
                    MessagesAllowedInPeriod = 750,
                    ThrottlingPeriod = TimeSpan.FromSeconds(30)
                };
                var customClient = new WebSocketClient(clientOptions);
                client = new TwitchClient(customClient);
                client.Initialize(credentials);

                client.OnMessageReceived += Client_OnMessageReceived;
                client.OnConnected += Client_OnConnected;
                client.OnDisconnected += ClientMain_OnDisconnected;
                client.OnLog += Client_OnLog;
                client.OnIncorrectLogin += Client_IncorrectLogin;
                client.OnJoinedChannel += Client_OnJoinedChannel;
                client.OnLeftChannel += Client_OnLeftChannel;

                client.Connect();
            }

            private void Client_OnLeftChannel(object sender, OnLeftChannelArgs e)
            {
                main.channelJoined = null;
                Console.WriteLine(@"Left channel: " + e.Channel);
                if (Settings1.Default.isLinked)
                    Task.Factory.StartNew(() =>
                    {
                        var unused = main.Dispatcher.BeginInvoke((Action) (() =>
                        {
                            {
                                main.TwitchStatus.Foreground = Brushes.IndianRed;
                            }
                        }));
                    });
                else
                    Task.Factory.StartNew(() =>
                    {
                        var unused = main.Dispatcher.BeginInvoke((Action) (() =>
                        {
                            {
                                main.TwitchStatus.Foreground = Brushes.Yellow;
                            }
                        }));
                    });
            }

            private void Client_IncorrectLogin(object sender, OnIncorrectLoginArgs e)
            {
                MessageBox.Show("Incorrect Login Details! Make sure you entered your channel name correctly!\n" +
                                "In case your channel name is correctly written, CONTACT gadzzaa ASAP!\n" +
                                "Either through discord either through a bug report", "Twitch ERROR!");
            }

            private void Client_OnLog(object sender, OnLogArgs e)
            {
                Console.WriteLine(@"TwitchClient :  " + e.Data);
            }

            private void Client_OnConnected(object sender, OnConnectedArgs e)
            {
                Console.WriteLine(@"GadzzaaTB online!");
            }

            private void Client_OnJoinedChannel(object sender, OnJoinedChannelArgs e)
            {
                main.channelJoined = e.Channel;
                if (Settings1.Default.isLinked)
                {
                    Console.WriteLine(@"Connected to " + e.Channel);
                    client.SendMessage(e.Channel, "GadzzaaTB online!");
                    Task.Factory.StartNew(() =>
                    {
                        var unused = main.Dispatcher.BeginInvoke((Action) (() =>
                        {
                            {
                                main.TwitchStatus.Foreground = Brushes.LimeGreen;
                            }
                        }));
                    });
                }
                else
                {
                    client.SendMessage(e.Channel,
                        "Verification Required! Type '!verify' to verify that your are the owner of the account");
                }
            }

            private void ClientMain_OnDisconnected(object sender,
                OnDisconnectedEventArgs e)
            {
                Console.WriteLine(@"Disconnected from Twitch");
            }


            private void Client_OnMessageReceived(object sender, OnMessageReceivedArgs e)
            {
                if (Settings1.Default.isLinked)
                {
                    if (e.ChatMessage.Message.Equals(Settings1.Default.Command1))
                    {
                        i = 0;
                        i2 = 0;
                        i3 = 0;
                        npText = "";
                        foreach (var unused in Process.GetProcessesByName("osu!StreamCompanion")) i = 1;

                        foreach (var unused in Process.GetProcessesByName("osu!")) i2 = 1;

                        foreach (var unused in Process.GetProcessesByName("gosumemory")) i3 = 1;
                        npText = "osu! is not running! Please open the game before using the command!";
                        if (i2 == 1)
                            npText =
                                "No integration is now running! Please start it manually from the integrations tab!";
                        if (i3 == 1)
                        {
                            if (cache3 != null && cache3.HasValues)
                            {
                                npText =
                                    "Now Playing | " + decimal.Round((decimal) cache3.GetValue("mStars"), 2) +
                                    "⭐ | " +
                                    cache3.GetValue("artist") + " - " + cache3.GetValue("title") + " [" +
                                    cache3.GetValue("mapDiff") + "] | Mods: " +
                                    cache3.GetValue("mods") + " | Download: https://osu.ppy.sh/b/" +
                                    cache3.GetValue("dl");
                            }
                            else
                            {
                                npText =
                                    "Error on websocket! Submit a bug report if this keeps repeating";
                                Console.WriteLine(@"Cache3 Values?: " + (cache3 != null && cache3.HasValues));
                            }
                        }
                        else if (i == 1)
                        {
                            if (cache2 != null && cache2.HasValues && firstMessageLoaded)
                            {
                                npText =
                                    "Now Playing | " + decimal.Round((decimal) cache2.GetValue("mStars"), 2) +
                                    "⭐ | " +
                                    cache2.GetValue("mapArtistTitle") + " " + cache2.GetValue("mapDiff") +
                                    " | Mods: " +
                                    cache2.GetValue("mods") + " | Download: " + cache2.GetValue("dl");
                            }
                            else
                            {
                                npText =
                                    "Error on websocket! Submit a bug report if this keeps repeating";
                                Console.WriteLine(@"Cache2 Values?: " + (cache2 != null && cache2.HasValues));
                                Console.WriteLine(@"Cache2 FirstMessage?: " + firstMessageLoaded);
                            }
                        }

                        client.SendMessage(e.ChatMessage.Channel, npText);

                        x = x + 1;
                        Console.WriteLine(@"i value for command1: " + i);
                        Console.WriteLine(@"i2 value for command1: " + i2);
                        Console.WriteLine(@"i3 value for command1: " + i3);
                        Console.WriteLine(@"Command 1 text: " + npText);
                        Console.WriteLine(@"X Value: " + x);
                    }
                    else if (e.ChatMessage.Message.Equals(Settings1.Default.Command2))
                    {
                        i = 0;
                        i2 = 0;
                        i3 = 0;
                        npppText = "";
                        foreach (var _ in Process.GetProcessesByName("osu!StreamCompanion")) i = 1;

                        foreach (var _ in Process.GetProcessesByName("osu!")) i2 = 1;

                        foreach (var _ in Process.GetProcessesByName("gosumemory")) i3 = 1;
                        npppText = "osu! is not running! Please open the game before using the command!";
                        if (i2 == 1)
                            npppText =
                                "No integration is now running! Please start it manually from the integrations tab!";
                        if (i3 == 1)
                        {
                            if (cache3 != null && cache3.HasValues)
                            {
                                npppText =
                                    "PP Values | 100 % : " +
                                    decimal.Round((decimal) cache3.GetValue("osu_mSSPP"), 2) +
                                    " pp | 99 % : " +
                                    decimal.Round((decimal) cache3.GetValue("osu_m99PP"), 2) + " pp | 98 % : " +
                                    decimal.Round((decimal) cache3.GetValue("osu_m98PP"), 2) +
                                    " pp | 97 % : " + decimal.Round((decimal) cache3.GetValue("osu_m97PP"), 2) +
                                    " pp | 96 % : " +
                                    decimal.Round((decimal) cache3.GetValue("osu_m96PP"), 2) + " pp | 95 % : " +
                                    decimal.Round((decimal) cache3.GetValue("osu_m95PP"), 2) +
                                    " pp | Download: https://osu.ppy.sh/b/" + cache3.GetValue("dl");
                            }
                            else
                            {
                                npppText =
                                    "Error on websocket! Submit a bug report if this keeps repeating";
                                Console.WriteLine(@"Cache3: " + cache3);
                                Console.WriteLine(@"Cache3 Values?: " + (cache3 != null && cache3.HasValues));
                            }
                        }
                        else if (i == 1)
                        {
                            if (cache2 != null && cache2.HasValues && firstMessageLoaded)
                            {
                                npppText =
                                    "PP Values | 100 % : " +
                                    decimal.Round((decimal) cache2.GetValue("osu_mSSPP"), 2) +
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
                                npppText =
                                    "Error on websocket! Submit a bug report if this keeps repeating";
                                Console.WriteLine(@"Cache2 Values?: " + (cache2 != null && cache2.HasValues));
                                Console.WriteLine(@"Cache2 FirstMessage?: " + firstMessageLoaded);
                            }
                        }


                        client.SendMessage(e.ChatMessage.Channel, npppText);
                        y = y + 1;
                        Console.WriteLine(@"i value for command2: " + i);
                        Console.WriteLine(@"i2 value for command2: " + i2);
                        Console.WriteLine(@"i3 value for command2: " + i3);
                        Console.WriteLine(@"Command 2 text: " + npppText);
                        Console.WriteLine(@"Y Value: " + y);
                    }
                    else if (e.ChatMessage.Message.Equals("!commands"))
                    {
                        client.SendMessage(e.ChatMessage.Channel,
                            "!" + Settings1.Default.Command1 + ", !" + Settings1.Default.Command2 +
                            ", !commands");
                    }
                }
                else if (e.ChatMessage.Message.Equals("!verify"))
                {
                    if (e.ChatMessage.Channel == e.ChatMessage.Username)
                    {
                        var text = "Channel not whitelisted!";
                        foreach (var t in main.accessNames)
                            if (e.ChatMessage.Channel.ToLower() == t.ToLower())
                            {
                                text = "Verification Process Completed!";
                                Settings1.Default.isLinked = true;
                                Console.WriteLine(@"Twitch Verified!");
                                Task.Factory.StartNew(() =>
                                {
                                    var _ = main.Dispatcher.BeginInvoke((Action) (() =>
                                    {
                                        {
                                            main.TwitchStatus.Foreground = Brushes.LimeGreen;
                                        }
                                    }));
                                });
                                break;
                            }

                        client.SendMessage(e.ChatMessage.Channel, text);
                    }
                    else
                    {
                        client.SendMessage(e.ChatMessage.Channel, "You are not eligible to use this command!");
                        Console.WriteLine(@"Verification command acces denied");
                    }
                }
            }
        }
    }
}