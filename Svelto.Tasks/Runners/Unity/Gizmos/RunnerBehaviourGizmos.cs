#if UNITY_EDITOR

using UnityEngine;
using System.Collections;

namespace Svelto.Tasks
{
    class RunnerBehaviourGizmos : MonoBehaviour
    {
        void OnDrawGizmos()
        {
            if (_mainRoutine != null)
                _mainRoutine.MoveNext();
        }

        public void StartGizmosCoroutine(IEnumerator enumerator)
        {
            _mainRoutine = enumerator;
        }

        IEnumerator _mainRoutine;
    }
}

#endif