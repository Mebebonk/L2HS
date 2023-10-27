using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncapsulatedObjects
{
	internal class Snek
	{
		public List<Coordinate> SnekBody { get; private set; }
		public Snek(Coordinate start, Field field) 
		{
			var rnd = new Random();
			SnekBody[1] = field.SpawnableAreas[rnd.Next(field.SpawnableAreas.Length)];
				
		}
	}
}
