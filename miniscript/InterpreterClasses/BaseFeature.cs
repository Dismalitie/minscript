using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniscript.InterpreterClasses
{
    public class BaseFeature
    {
        public BaseFeature() { }

        public virtual Value? Invoke(FeatureCallArgs args)
        {
            return null;
        }

        public virtual void DebugInvoke(FeatureCallArgs args)
        {

        }
    }
}
