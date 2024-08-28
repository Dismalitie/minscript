using miniscript.InterpreterClasses;
using System.Collections.Generic;

namespace miniscript.Features.CoreFeatures
{
    internal class MS_Variable : BaseFeature
    {
        public enum MS_Variable_Type
        {
            String,
            Bool,
            Integer,
            Dynamic,
            
            StringCollection,
            BoolCollection,
            IntegerCollection,
            DynamicCollection,
        }

        public MS_Variable_Type Type;
        public string Name;
        public object Value;

        public override void Invoke(FeatureCallArgs args)
        {
            // fmt: #var <type> <name> <val>
            if (args.ConstructorTokens[0] == "str") { Type = MS_Variable_Type.String; }
            else if (args.ConstructorTokens[0] == "bool") { Type = MS_Variable_Type.Bool; }
            else if (args.ConstructorTokens[0] == "int") { Type = MS_Variable_Type.Integer; }
            else if (args.ConstructorTokens[0] == "dyn") { Type = MS_Variable_Type.Dynamic; }
            else if (args.ConstructorTokens[0] == "str[]") { Type = MS_Variable_Type.StringCollection; }
            else if (args.ConstructorTokens[0] == "bool[]") { Type = MS_Variable_Type.BoolCollection; }
            else if (args.ConstructorTokens[0] == "int[]") { Type = MS_Variable_Type.IntegerCollection; }
            else if (args.ConstructorTokens[0] == "dyn[]") { Type = MS_Variable_Type.DynamicCollection; }
            else
            {
                List<string> fixes = new List<string>
                {
                    "Check that variable type is one of:",
                    "str - String",
                    "int - Integer",
                    "bool - Bool",
                    "dyn - Dynamic",
                    "str[] - String Collection",
                    "bool[] - Bool Collection",
                    "int[] - Integer Collection",
                    "dyn[] - Dynamic Collection",
                };
                Funcs.Error("Variable type is not valid.", Funcs.ErrorType.ArgumentError, true, fixes);
            }
        }
    }
}
