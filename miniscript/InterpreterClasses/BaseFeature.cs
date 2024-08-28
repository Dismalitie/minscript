using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniscript.InterpreterClasses
{
    public class BaseFeature
    {
        public BaseFeature() { }

        public virtual void Invoke(FeatureCallArgs args)
        {

        }

        public virtual void DebugInvoke(FeatureCallArgs args)
        {

        }
    }
}
