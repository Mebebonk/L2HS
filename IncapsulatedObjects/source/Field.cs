using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncapsulatedObjects
{
	public class Field
	{
		public Coordinate[] Walls { get; private set; }
		public Coordinate[] SpawnableAreas { get; private set; }

		public Field(Coordinate[] walls)
		{
			Walls = walls;
			List<Coordinate> list = new();

			foreach (Coordinate c in Walls)
			{
				AppendOnValid(new Coordinate(c.X - 1, c.Y), ref list);
				AppendOnValid(new Coordinate(c.X, c.Y + 1), ref list);
				AppendOnValid(new Coordinate(c.X + 1, c.Y), ref list);
				AppendOnValid(new Coordinate(c.X, c.Y - 1), ref list);				
			}

			SpawnableAreas = list.ToArray();
		}

		static private void AppendOnValid(Coordinate c, ref List<Coordinate> coordinates)
		{
			if (Validator.ValidationTest(c)) coordinates.Add(c);
		}
	}
}
