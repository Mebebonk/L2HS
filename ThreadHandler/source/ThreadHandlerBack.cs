using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadHandler
{
	internal class ThreadHandlerBack
	{
		readonly object locker;

		public ThreadHandlerBack() 
		{
			locker = new();
		}

		public void AtomicAction(Action action)
		{
			lock (locker)
			{
				action();
			}
		}

		public void AtomicAction<T>(Func<T, T> action, ref T var)
		{
			lock (locker)
			{
				var = action(var);
			}
		}

		public void AtomicAction<T>(Action<T> action, T var)
		{
			lock (locker)
			{
				action(var);
			}
		}
	}
}
