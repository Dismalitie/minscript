using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

namespace miniscript.InterpreterClasses
{
    internal class Funcs
    {
        #region FeatureLog

        public static void FeatureLog(string msg)
        {
            if (!_InterpreterChecks.InterpreterRuntimeFlags_FeatureDebug) { return; }

            ConsoleColor prevCol = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("[f_dbg][ln" + Program.lineNumber + "] " + msg);
            Console.ForegroundColor = prevCol;
        }

        #endregion

        #region Error

        public enum ErrorType
        {
            Generic,
            FeatureError,
            InvalidFeature,
            ArgumentError,
            InterpreterInitError,
        }

        public static void Error(string msg, ErrorType errorType, bool stopInterpreter, List<string> potentialFixes)
        {
            ConsoleColor prevCol = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("[ln:" + Program.lineNumber.ToString() + "][errType:" + errorType.ToString() + "] " + msg);
            if (potentialFixes.Count != 0)
            {
                Console.WriteLine("Potential Fixes: ");
                foreach (string fix in potentialFixes) { Console.WriteLine("    - " + fix); }
            }
            Console.WriteLine("");
            Console.ForegroundColor = prevCol;
            if (stopInterpreter) { _InterpreterChecks.ErrorThrown = true; }
        }

        #endregion

        #region ExtractBrackets

        public static List<string> ExtractBrackets(string input)
        {
            List<string> results = new List<string>();
            string pattern = @"\(([^)]*)\)";
            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(input);

            foreach (Match match in matches)
            {
                results.Add(match.Groups[1].Value);
            }

            return results;
        }

        #endregion

        #region CheckAlphanumeric

        public static bool CheckAlphanumeric(string input)
        {
            string pattern = @"^[a-zA-Z0-9]+$";
            Regex regex = new Regex(pattern);

            return regex.IsMatch(input);
        }

        #endregion

        #region ExtractString

        public static List<string> ExtractStrings(string input)
        {
            List<string> results = new List<string>();
            string pattern = "\"([^\"]*)\"";
            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(input);

            foreach (Match match in matches)
            {
                results.Add(match.Groups[1].Value);
            };
            return results;
        }

        #endregion

        #region Interpret

        public static Value? Interpret(string ln)
        {
            if (ln == "") // if line empty, dont bother
            {
                return null;
            }

            if (_InterpreterChecks.ErrorThrown) { return null; } // checks whether an error has been thrown yet

            void Log(string msg)
            {
                if (!_InterpreterChecks.InterpreterRuntimeFlags_InterpreterDebug) { return; }

                ConsoleColor prevCol = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("[i_dbg][ln" + Program.lineNumber + "]" + msg);
                Console.ForegroundColor = prevCol;
            } // i_dbg log

            if (!_Config.FeatureRegistry.ContainsKey(ln.Split(' ')[0])) // if the feature registry doesnt have the feature, throw error
            {
                List<string> fixes = new List<string>
                {
                    "Check whether the feature is registered",
                    "Check that the call is spelled correctly"
                };
                Error("\"" + ln.Split(' ')[0] + "\" is not a valid feature.", Funcs.ErrorType.InvalidFeature, true, fixes);
            }
            else
            {
                #region i_dbg stuff
                Log("[fcall] " + ln.Split(' ')[0]);
                Log("[f_dbg][status] " + _InterpreterChecks.InterpreterRuntimeFlags_FeatureDebug.ToString());
                Log("[dmp_c][status] " + _InterpreterChecks.InterpreterRuntimeFlags_DumpComments.ToString());
                Console.WriteLine(""); // new line to sep logs
                #endregion

                if (_InterpreterChecks.InterpreterRuntimeFlags_FeatureDebug) { _Config.FeatureRegistry[ln.Split(' ')[0]].DebugInvoke(new FeatureCallArgs(ln)); }
                return _Config.FeatureRegistry[ln.Split(' ')[0]].Invoke(new FeatureCallArgs(ln));
            }

            return null;
        }

        #endregion

        #region CastToType

        public static object CastToType(string input)
        {
            // check for null or empty input
            if (string.IsNullOrWhiteSpace(input))
                return input;

            // check for bool
            if (bool.TryParse(input, out bool boolResult))
                return boolResult;

            // check for int
            if (int.TryParse(input, out int intResult))
                return intResult;

            // check for decimal
            if (float.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out float floatResult))
                return floatResult;

            // check for string with quotes
            if (input.StartsWith("\"") && input.EndsWith("\""))
            {
                return input.Trim('"');
            }

            // return as string if none of the above conditions matched
            return input;
        }

        #endregion

        #region GetTypeFromString

        public static Type GetTypeFromString(string input)
        {
            // Check for null or empty input
            if (string.IsNullOrWhiteSpace(input))
                return typeof(string); // Consider null/empty input as a string type

            // Check for boolean
            if (bool.TryParse(input, out _))
                return typeof(bool);

            // Check for integer
            if (int.TryParse(input, out _))
                return typeof(int);

            // Check for float (double)
            if (double.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out _))
                return typeof(double);

            // Check for string with quotes
            if (input.StartsWith("\"") && input.EndsWith("\""))
                return typeof(string);

            // If none of the above conditions match, return as object
            return typeof(object);
        }


        #endregion
    }
}