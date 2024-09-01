using miniscript.InterpreterClasses;
using System;

public class Program
{
    public static int lineNumber = 0;
    public static bool debugMode = false;
    public static string file;

    static void Main(string[] args)
    {
        #region file init

        if (args.Length < 1)
        {
            List<string> fixes = new List<string>()
                {
                    "Valid arguments are:",
                    "-file <filepath>",
                    "-f <filepath>",
                    "-i_dbg",
                    "-interpreter_debug",
                    "-f_dbg",
                    "-feature_debug",
                    "-dmp_c",
                    "-dump_comments"
            };
            Funcs.Error("Supply more args!", Funcs.ErrorType.InterpreterInitError, true, fixes);
            return;
        }
        string filepath = "";

        int argIter = 0;
        foreach (string arg in args)
        {
            if (arg == "-file" || arg == "-f")
            {
                filepath = args[1];
            }
            else if (arg == "-i_dbg" || arg == "-interpreter_debug")
            {
                _InterpreterChecks.InterpreterRuntimeFlags_InterpreterDebug = true; // writes useful stuff to the terminal when calling features
            }
            else if (arg == "-f_dbg" || arg == "-feature_debug")
            {
                _InterpreterChecks.InterpreterRuntimeFlags_FeatureDebug = true; // calls the DebugInvoke function in features
            }
            else if (arg == "-dmp_c" || arg == "-dump_comments")
            {
                _InterpreterChecks.InterpreterRuntimeFlags_DumpComments = true; // write comments to terminal
            }

            argIter++;
        }

        if (filepath == "")
        {
            List<string> fixes = new List<string>()
                {
                    "Check that a file path was supplied",
                    "Check that the path is valid",
                    "Check that if the path has spaces, make sure that it is enclosed in quotation marks"
            };
            Funcs.Error("File path not passed!", Funcs.ErrorType.InterpreterInitError, true, fixes);
            return;
        }

        file = File.ReadAllText(filepath);

        #endregion

        foreach (string ln in file.Split('\n'))
        {
            lineNumber++;

            if (ln == "") // if line empty, dont bother
            {
                return;
            }

            Funcs.Interpret(ln);
        }
    }
}