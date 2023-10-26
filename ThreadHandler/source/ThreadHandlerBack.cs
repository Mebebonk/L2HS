using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadHandler
{
	static internal class ThreadHandlerBack
	{
		static readonly object locker = new();

		static public void AtomicAction(Action action)
		{
			lock (locker)
			{
				action();
			}
		}

		static public void AtomicAction<T>(Func<T, T> action, ref T var)
		{
			lock (locker)
			{
				var = action(var);
			}
		}

		static public void AtomicAction<T>(Action<T> action, ref T var)
		{
			lock (locker)
			{
				action(var);
			}
		}
	}
}
