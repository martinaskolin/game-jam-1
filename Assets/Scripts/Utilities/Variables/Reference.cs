using System;

namespace Decent
{
    [Serializable]
    public class Reference<TVariable, TValue> where TVariable : Variable<TValue>
    {
        public bool UseConstant = true;
        public TValue ConstantValue;
        public TVariable Variable;

        public TValue Value
        {
            get { return UseConstant ? ConstantValue : Variable.Value; }
        }
    }

    [Serializable] public class FloatReference : Reference<FloatVariable, float> { }
    [Serializable] public class BoolReference : Reference<BoolVariable, bool> { }
    [Serializable] public class IntReference : Reference<IntVariable, int> { }


}
