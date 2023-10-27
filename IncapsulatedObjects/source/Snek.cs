using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncapsulatedObjects
{
	internal class Snek : Validatable
	{
		public List<Coordinate> SnekBody { get; private set; }
		public Snek(Coordinate start, Field field)
		{
			var rnd = new Random();
			SnekBody[1] = field.SafeCoordinates[rnd.Next(field.SafeCoordinates.Length)];

		}

		public override bool IsValid()
		{
			return SnekBody.Count > 2;
		}
	}
}
