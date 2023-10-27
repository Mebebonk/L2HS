using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncapsulatedObjects
{
	public class Field : Validatable
	{
		public Coordinate[] Walls { get; private set; }
		public Coordinate[] SafeCoordinates { get; private set; }

		public bool AllowTP { get; private set; }

		public Field(Coordinate[] walls, Coordinate[] spawnableAreas, bool allowTP = true)
		{
			Walls = walls;
			SafeCoordinates = spawnableAreas;
			AllowTP = allowTP;
		}

		public Field(Coordinate[] walls, bool allowTP = true)
		{
			List<Coordinate> spawnableCoordinates = new();
			List<Coordinate> walledCoordinates = new();

			foreach (Coordinate c in walls)
			{
				c.ActionOnValid(() => walledCoordinates.Add(c));
				foreach (Coordinate coor in c.GetAdjesant())
				{
					coor.ActionOnValid(() => spawnableCoordinates.Add(coor));
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
