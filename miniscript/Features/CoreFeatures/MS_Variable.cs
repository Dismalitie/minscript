using miniscript.InterpreterClasses;

namespace miniscript.Features.CoreFeatures
{
    internal class MS_Variable : BaseFeature
    {
        public static Dictionary<string, MS_Variable> Variables = new Dictionary<string, MS_Variable>();

        public string Name;
        public object Value;

        public override void Invoke(FeatureCallArgs args)
        {
            // fmt: #var <name> <val>

            if (Funcs.CheckAlphanumeric(args.ConstructorTokens[0]))
            {
                Name = args.ConstructorTokens[0];
            }
            else
            {
                List<string> fixes = new List<string>
                {
                    "Check that the variable name only consists of:",
                    "Characters a through z",
                    "Characters A through Z",
                    "Numbers 0 through 9",
                };
                Funcs.Error("Variable name cannot contain special characters.", Funcs.ErrorType.ArgumentError, true, fixes);
            }

            Value = Funcs.CastToType(args.ConstructorTokens[1]);

            Variables.TryGetValue(Name, out MS_Variable v);
            if (v != null)
            {
                Variables[Name] = this; // overwrite it
            }

            Variables.Add(Name, this);
        }

        public override void DebugInvoke(FeatureCallArgs args)
        {
            Funcs.FeatureLog("new var");
            Funcs.FeatureLog("name: " + Name);
            Funcs.FeatureLog("val: " + Value);
            Funcs.FeatureLog("type: " + Value.GetType());
        }

        public override object Returnee()
        {
            return Value;
        }
    }
}
