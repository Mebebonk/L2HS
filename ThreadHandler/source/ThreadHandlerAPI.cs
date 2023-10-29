namespace ThreadHandler
{
	public class ThreadHandlerAPI
	{
		private readonly ThreadHandlerBack handler;

		public ThreadHandlerAPI() { handler = new(); }
		public void ExecLocked<T>(Action<T> action, ref T var) { handler.AtomicAction(action, var); }
		public void ExecLocked<T>(Func<T, T> action, ref T var) { handler.AtomicAction(action, ref var); }
		public void ExecLocked(Action action) { handler.AtomicAction(action); }
	}
}