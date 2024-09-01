using miniscript.InterpreterClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniscript.Features.CoreFeatures.MS_Console
{
    internal class MS_Console_Write : BaseFeature
    {
        public override object? Invoke(FeatureCallArgs args)
        {
            foreach (string arg in args.Arguments[0])
            {
                Console.Write(arg);
            }
            return null;
        }
    }
}
