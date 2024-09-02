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
        public override Value? Invoke(FeatureCallArgs args)
        {
            foreach (Value arg in args.Arguments[0])
            {
                Console.Write(arg.Val);
            }
            return null;
        }
    }
}
