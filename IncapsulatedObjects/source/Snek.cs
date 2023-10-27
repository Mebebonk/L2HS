using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncapsulatedObjects
{
	public class Snek : Validatable
	{
		public List<Coordinate> SnekBody { get; private set; }
		public Snek(Coordinate start)
		{
			var rnd = new Random();
			SnekBody = new(2)
			{
				start.GetAdjesant()[rnd.Next(start.GetAdjesant().Length)],
				start
			};
		}

		public override bool IsValid()
		{
			return SnekBody.Count > 1;
		}
	}
}
