#if UNITY_EDITOR

using System;

namespace Svelto.Tasks
{
    public static class GizmosTaskRunnerExtensions
    {
        public static void RunOnGizmosSchedule(this TaskRunner taskRunner, Action action)
        {
            TaskRunner.Instance.RunOnSchedule(GizmosScheduler.gizmosScheduler, new GizmosLoopActionEnumerator(action));
        }
    }
}

#endif

