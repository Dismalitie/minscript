using System.Collections.Generic;

namespace miniscript.InterpreterClasses
{
    public class FeatureCallArgs
    {
        public string FeatureKeyword;
        public List<string> ConstructorTokens;
        public List<List<string>> Arguments;
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
            
            List<List<string>> brackets = new List<List<string>>();
            foreach (string bracketSet in Funcs.ExtractBrackets(line)) // can have multiple sets of brackets
            {
                List<string> args = new List<string>();
                foreach (string arg in bracketSet.Split(','))
                {
                    args.Add(arg.Trim().Remove(0, 1).Remove(arg.Length - 2, 1));
                }
                brackets.Add(args);
            }
            Arguments = brackets;
        }
    }
}
