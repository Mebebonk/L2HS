using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncapsulatedObjects
{
	public class Food
	{
		public Coordinate Location { get; private set; }
		public Food(Coordinate location)
		{	
			Location = location;
		}
	}
}
