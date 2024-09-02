using miniscript.InterpreterClasses;

namespace miniscript.Features.CoreFeatures.MS_Console
{
    internal class MS_Console_WriteLn : BaseFeature
    {
        public override Value? Invoke(FeatureCallArgs args)
        {
            foreach (Value arg in args.Arguments[0])
            {
                Console.WriteLine(arg.Val);
            }
            return null;
        }
    }
}
