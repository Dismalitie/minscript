using miniscript.InterpreterClasses;

namespace miniscript.Features.CoreFeatures
{
    internal class MS_Comment : BaseFeature
    {
        private FeatureCallArgs args;

        public override Value? Invoke(FeatureCallArgs args)
        {
            this.args = args;
            if (_InterpreterChecks.InterpreterRuntimeFlags_DumpComments)
            {
                ConsoleColor prevColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("[comment][ln" + Program.lineNumber + "] " + args.RawLine);
                Console.ForegroundColor = prevColor;
            }
            return null;
        }
    }
}