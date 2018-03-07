#if UNITY_EDITOR
using Svelto.DataStructures;
using Svelto.Tasks.Internal;

namespace Svelto.Tasks
{
    class GizmosMonoRunner : MonoRunner
    {
        public GizmosMonoRunner(string name)
        {
            var go = UnityCoroutineRunner.InitializeGameobject(name);

            var coroutines = new FasterList<IPausableTask>(NUMBER_OF_INITIAL_COROUTINE);
            var runnerBehaviour = go.AddComponent<RunnerBehaviourGizmos>();
            var runnerBehaviourForUnityCoroutine = go.AddComponent<RunnerBehaviour>();

            _info = new UnityCoroutineRunner.RunningTasksInfo() { runnerName = name };

            runnerBehaviour.StartGizmosCoroutine(UnityCoroutineRunner.Process
                (_newTaskRoutines, coroutines, _flushingOperation, _info,
                    UnityCoroutineRunner.StandardTasksFlushing,
                    runnerBehaviourForUnityCoroutine, StartCoroutine));
        }

        protected override UnityCoroutineRunner.RunningTasksInfo info
        { get { return _info; } }

        protected override ThreadSafeQueue<IPausableTask> newTaskRoutines
        { get { return _newTaskRoutines; } }

        protected override UnityCoroutineRunner.FlushingOperation flushingOperation
        { get { return _flushingOperation; } }

        readonly ThreadSafeQueue<IPausableTask> _newTaskRoutines = new ThreadSafeQueue<IPausableTask>();
        readonly UnityCoroutineRunner.FlushingOperation _flushingOperation = new UnityCoroutineRunner.FlushingOperation();
        readonly UnityCoroutineRunner.RunningTasksInfo _info;

        const int NUMBER_OF_INITIAL_COROUTINE = 3;
    }
}
#endif