#if UNITY_EDITOR

using System.Collections;

namespace Svelto.Tasks
{
    public static class GizmosTaskRunnerExtensions
    {
        public static void RunOnGizmosSchedule(this IEnumerator enumerator)
        {
            enumerator.ThreadSafeRunOnSchedule(GizmosScheduler.gizmosScheduler);
        }
    }
}

#endif

