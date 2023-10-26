namespace ThreadHandler
{
	static public class ThreadHandlerAPI
	{
		static public void ExecLocked<T>(Action<T> action, ref T var) { ThreadHandlerBack.AtomicAction(action, ref var); }
		static public void ExecLocked<T>(Func<T, T> action, ref T var) { ThreadHandlerBack.AtomicAction(action, ref var); }
		static public void ExecLocked(Action action) { ThreadHandlerBack.AtomicAction(action); }
	}
}