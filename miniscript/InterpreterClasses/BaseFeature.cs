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

        public Dictionary<string, BaseFeature> SubFeatures = new Dictionary<string, BaseFeature>();

        public virtual object? Invoke(FeatureCallArgs args)
        {
            return null;
        }

        public virtual void DebugInvoke(FeatureCallArgs args)
        {

        }
    }
}
