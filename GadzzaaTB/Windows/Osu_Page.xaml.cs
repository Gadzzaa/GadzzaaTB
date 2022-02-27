using System;
using System.Windows;
using System.Windows.Input;

namespace GadzzaaTB
{
    public partial class Osu_Page
    {
        internal static Osu_Page osupage;
        public static string command1;
        public static string command2;

        public Osu_Page()
        {
            osupage = this;
            InitializeComponent();
        }

        public static void AddNpValue(int x)
        {
            osupage.LabelNp.Content = command1 + " has been called : " + x;
        }

        public static void AddNpppValue(int x)
        {
            osupage.LabelNppp.Content = command2 + " has been called : " + x;
        }


        private void HideOsuBot(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Main.main.MainA.MainW);
            Console.WriteLine("Navigation to Main Tab Request Sent!");
        }

        private void npGetFocus(object sender, RoutedEventArgs e)
        {
            Command1.Text = "";
            Console.WriteLine("Got focus for Command1");
        }

        private void npLoseFocus(object sender, RoutedEventArgs e)
        {
            if (Command1.Text == null || Command1.Text == "") Command1.Text = "!np";
            if (Command1.Text.Contains(" "))
            {
                MessageBox.Show("Command1 contains unresolvable characters", "Error");
                Command1.Text = "!np";
            }
            else if (!Command1.Text.StartsWith("!"))
            {
                Command1.Text = "!" + Command1.Text;
            }
            else
            {
                Settings1.Default.Command1 = Command1.Text;
            }

            Console.WriteLine("Lost focus for Command1");
        }

        private void npppGetFocus(object sender, RoutedEventArgs e)
        {
            Command2.Text = "";
            Console.WriteLine("Got focus for Command2");
        }

        private void npppLoseFocus(object sender, RoutedEventArgs e)
        {
            if (Command2.Text == null || Command2.Text == "") Command2.Text = "!nppp";
            if (Command2.Text.Contains(" "))
            {
                MessageBox.Show("Command2 contains unresolvable characters", "Error");
                Command2.Text = "!nppp";
            }
            else if (!Command2.Text.StartsWith("!"))
            {
                Command2.Text = "!" + Command1.Text;
            }
            else
            {
                Settings1.Default.Command2 = Command2.Text;
            }

            Console.WriteLine("Lost Focus for Command2");
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                // Kill logical focus
                FocusManager.SetFocusedElement(FocusManager.GetFocusScope(Command1), null);
                // Kill keyboard focus
                Keyboard.ClearFocus();
            }
        }

        private void OnKeyDownHandler2(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                // Kill logical focus
                FocusManager.SetFocusedElement(FocusManager.GetFocusScope(Command2), null);
                // Kill keyboard focus
                Keyboard.ClearFocus();
            }
        }

        private void DaPula(object sender, RoutedEventArgs e)
        {
            Main.main.bugReportp.Show();
        }
    }
}