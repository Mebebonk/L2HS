using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncapsulatedObjects
{
	public abstract class Validatable
	{
		public abstract bool IsValid();

		public void ActionOnValid(Action action)
		{
			if (IsValid()) action();
		}
	}
}
