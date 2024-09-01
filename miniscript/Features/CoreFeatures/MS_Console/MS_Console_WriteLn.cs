using miniscript.InterpreterClasses;

namespace miniscript.Features.CoreFeatures.MS_Console
{
    internal class MS_Console_WriteLn : BaseFeature
    {
        public override object? Invoke(FeatureCallArgs args)
        {
            foreach (string arg in args.Arguments[0])
            {
                Console.WriteLine(arg);
            }
            return null;
        }
    }
}
