using miniscript.InterpreterClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniscript.Features.CoreFeatures.MS_Console
{
    internal class MS_Console_BackgroundColor : BaseFeature
    {
        public override Value? Invoke(FeatureCallArgs args)
        {
            {
                if (args.ConstructorTokens.Count == 0 || args.ConstructorTokens[0] == "set")
                {
                    if (((string)args.Arguments[0][0].Val).Split('.')[0] != "ConsoleColor")
                    {
                        List<string> fixes = new List<string>
                        {
                            "Must be one of:",
                            "ConsoleColor.Black",
                            "ConsoleColor.DarkGreen",
                            "ConsoleColor.DarkBlue",
                            "ConsoleColor.DarkCyan",
                            "ConsoleColor.DarkRed",
                            "ConsoleColor.DarkMagenta",
                            "ConsoleColor.DarkYellow",
                            "ConsoleColor.Gray",
                            "ConsoleColor.DarkGrey",
                            "ConsoleColor.Blue",
                            "ConsoleColor.Green",
                            "ConsoleColor.Cyan",
                            "ConsoleColor.Red",
                            "ConsoleColor.Magenta",
                            "ConsoleColor.Yellow",
                            "ConsoleColor.White",
                        };
                        Funcs.Error("Expected ConsoleColor.", Funcs.ErrorType.ArgumentError, false, fixes);
                        return null;
                    }

                    object? color = null;
                    if (Enum.TryParse(typeof(ConsoleColor), ((string)args.Arguments[0][0].Val).Split('.')[1], false, out color))
                    {
                        Console.BackgroundColor = (ConsoleColor)color;
                    }
                    else
                    {
                        List<string> fixes = new List<string>
                        {
                            "Must be one of:",
                            "ConsoleColor.Black",
                            "ConsoleColor.DarkGreen",
                            "ConsoleColor.DarkBlue",
                            "ConsoleColor.DarkCyan",
                            "ConsoleColor.DarkRed",
                            "ConsoleColor.DarkMagenta",
                            "ConsoleColor.DarkYellow",
                            "ConsoleColor.Gray",
                            "ConsoleColor.DarkGrey",
                            "ConsoleColor.Blue",
                            "ConsoleColor.Green",
                            "ConsoleColor.Cyan",
                            "ConsoleColor.Red",
                            "ConsoleColor.Magenta",
                            "ConsoleColor.Yellow",
                            "ConsoleColor.White",
                        };
                        Funcs.Error(args.Arguments[0][0] + " is not a valid ConsoleColor.", Funcs.ErrorType.ArgumentError, false, fixes);
                        return null;
                    }
                }
                else if (args.ConstructorTokens[0] == "get")
                {
                    return new Value(typeof(ConsoleColor), Console.ForegroundColor, this);
                }
                else
                {
                    List<string> fixes = new List<string>
                    {
                        "Valid operation tokens:",
                        "get",
                        "set (default)",
                    };
                    Funcs.Error("Invalid operation token.", Funcs.ErrorType.ArgumentError, true, fixes);
                    return null;
                }
                return null;
            }
        }
    }
}
