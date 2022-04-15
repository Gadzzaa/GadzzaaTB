using System;
using PostSharp.Patterns.Diagnostics;
using PostSharp.Patterns.Diagnostics.Backends.Console;

namespace GadzzaaTB
{
    internal class CustomTheme : ConsoleTheme
    {
        private readonly ConsoleThemeStyle
            _delimiterStyle = new ConsoleThemeStyle("\x1b[38;5;0255m", ConsoleColor.Gray);

        private readonly ConsoleThemeStyle _timeStyle = new ConsoleThemeStyle(" \x1b[38;5;0006m", ConsoleColor.Cyan);

        public CustomTheme() : base(ConsoleThemes.Dark)
        {
        }

        public override ConsoleThemeStyle GetStyle(string role, LogLevel level, LogRecordKind kind,
            ConsoleThemeItem item)
        {
            if (item == ConsoleThemeItem.Time)
                return _timeStyle;
            if (item == ConsoleThemeItem.Delimiter) return _delimiterStyle;

            return base.GetStyle(role, level, kind, item);
        }
    }
}