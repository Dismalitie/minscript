using miniscript.InterpreterClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniscript
{
    internal class _Config
    {
        public static Dictionary<string, BaseFeature> FeatureRegistry = new Dictionary<string, BaseFeature>() // This is where all custom features will go.
        {
            { "~~", new Features.CoreFeatures.MS_Comment() },
            { "var", new Features.CoreFeatures.MS_Variable() },
            { "Console.WriteLn", new Features.CoreFeatures.MS_Console.MS_Console_WriteLn() },
            { "Console.Write", new Features.CoreFeatures.MS_Console.MS_Console_Write() },
        };
    }
}
