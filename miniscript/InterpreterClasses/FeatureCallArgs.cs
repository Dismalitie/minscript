using System.Collections.Generic;

namespace miniscript.InterpreterClasses
{
    public class FeatureCallArgs
    {
        public string FeatureKeyword;
        public List<string> ConstructorTokens;
        public List<List<Value>> Arguments;
        public string RawLine;

        public FeatureCallArgs(string line)
        {
            RawLine = line;
            FeatureKeyword = line.Split(' ')[0];

            List<string> constructorTokens = new List<string>();
            foreach (string word in line.Split(' ')) // add words until brackets (Arguments)
            {
                if (word.Contains("(") || word.Contains(")")) { break; }
                else
                {
                    constructorTokens.Add(word);
                }
            }
            constructorTokens.Remove(FeatureKeyword); // remove FeatureKeyword
            ConstructorTokens = constructorTokens;
            
            List<List<Value>> brackets = new List<List<Value>>();
            foreach (string bracketSet in Funcs.ExtractBrackets(line)) // can have multiple sets of brackets
            {
                List<Value> args = new List<Value>();
                foreach (string arg in bracketSet.Split(','))
                {
                    if (arg.Trim().StartsWith('"') && arg.Trim().EndsWith('"'))
                    {
                        args.Add(new Value(typeof(string), arg.Trim().Remove(0, 1).Remove(arg.Length - 2, 1), null));
                    }
                    else if (_Config.FeatureRegistry.ContainsKey(arg))
                    {
                        args.Add(new Value(typeof(Value), Funcs.Interpret(arg), null));
                    }
                    else
                    {
                        args.Add(new Value(typeof(string), arg.Trim(), null));
                    }
                }
                brackets.Add(args);
            }
            Arguments = brackets;
        }
    }
}
