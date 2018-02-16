#if UNITY_EDITOR

using System;
using System.Collections;

namespace Svelto.Tasks
{
    class GizmosLoopActionEnumerator : IEnumerator
    {
        public GizmosLoopActionEnumerator(Action action)
        {
            _needSkip = true;
            _action = action;
        }

        public object Current
        {
            get { return null; }
        }

        public bool MoveNext()
        {
            if (_needSkip)
            {
                _needSkip = false;
                return true;
            }

            _action();

            return true;
        }

        public void Reset()
        {
            _needSkip = true;
        }

        public override string ToString()
        {
            var method = _action.GetMethodInfoEx();

            return method.GetDeclaringType().Name + "." + method.Name;
        }

        bool _needSkip;
        Action _action;
    }
}

#endif