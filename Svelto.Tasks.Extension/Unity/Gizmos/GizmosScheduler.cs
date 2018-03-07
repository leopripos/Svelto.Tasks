#if UNITY_EDITOR

namespace Svelto.Tasks
{
    static class GizmosScheduler
    {
        public static IRunner gizmosScheduler { get; private set; }

        static GizmosScheduler()
        {
            gizmosScheduler = new GizmosMonoRunner("CustomGizmosRunner");
        }
    }
}
#endif

