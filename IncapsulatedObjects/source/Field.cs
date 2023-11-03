using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IncapsulatedObjects
{
	public class Field : Validatable
	{
		public Coordinate[] Walls { get; private set; }

		[JsonIgnore]
		public Coordinate[] SafeCoordinates { get; private set; }


		public bool AllowTP { get; private set; }

		public Field(Coordinate[] walls, Coordinate[] spawnableAreas, bool allowTP = true)
		{
			Walls = walls;
			SafeCoordinates = spawnableAreas;
			AllowTP = allowTP;
		}

		[JsonConstructor]
		public Field(Coordinate[] walls, bool allowTP = true)
		{
			List<Coordinate> spawnableCoordinates = new();
			for (int x = 0; RuleSet.RuleSet.maxWidth > x; x++)
			{
				for (int y = 0; RuleSet.RuleSet.maxHeight > y; y++)
				{
					spawnableCoordinates.Add(new Coordinate(x, y));
				}
			}

			List<Coordinate> walledCoordinates = new();

			foreach (Coordinate c in walls)
			{
				c.ActionOnValid(() => walledCoordinates.Add(c));
				spawnableCoordinates.Remove(c);

				foreach (Coordinate coor in c.GetAdjesant())
				{
					coor.ActionOnValid(() => spawnableCoordinates.Remove(coor));
				}


			}

			AllowTP = allowTP;
			SafeCoordinates = spawnableCoordinates.ToArray();
			Walls = walledCoordinates.ToArray();
		}

		public override bool IsValid()
		{
			return (SafeCoordinates.Length > 0);
		}
	}
}
