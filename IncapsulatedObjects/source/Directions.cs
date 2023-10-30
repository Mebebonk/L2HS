using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncapsulatedObjects
{
	public enum Directions
	{
		Left, Top, Right, Bottom
	}

	public static class DirectionConvertor
	{
		public static Coordinate GetCoordinateFromDirection(Directions direction)
		{
			return direction switch
			{
				Directions.Left => new Coordinate(1, 0),
				Directions.Top => new Coordinate(0, 1),
				Directions.Right => new Coordinate(-1, 0),
				Directions.Bottom => new Coordinate(0, -1),
				_ => throw new Exception($"Bad direction: {direction}")
			};
		}

		public static Directions GetDirectionFromCoordinate(Coordinate coordinate)
		{
			return (coordinate.X, coordinate.Y) switch
			{
				(-1, 0) => Directions.Left,
				(0, 1) => Directions.Top,
				(1, 0) => Directions.Right,
				(0, -1) => Directions.Bottom,
				_ => throw new Exception($"Bad coordinate {coordinate}")
			};
		}

	}
}
