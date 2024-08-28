using miniscript.InterpreterClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniscript.Features.CoreFeatures
{
    internal class MS_Comment : BaseFeature
    {
        public override void Invoke(FeatureCallArgs args)
        {
            if (_InterpreterChecks.InterpreterRuntimeFlags_DumpComments)
            {
                ConsoleColor prevColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("[comment][ln" + Program.lineNumber + "] " + args.RawLine);
                Console.ForegroundColor = prevColor;
            }
        }
    }
}