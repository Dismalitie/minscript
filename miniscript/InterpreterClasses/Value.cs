using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniscript.InterpreterClasses
{
    public class Value
    {
        public Type Type;
        public object Val;
        public BaseFeature? Sender;

        public Value(Type type, object val, BaseFeature sender)
        {
            Type = type;
            Val = val;
            Sender = sender;
        }
    }
}
