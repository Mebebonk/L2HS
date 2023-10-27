﻿using System;
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

		public void Move(Directions direction)
		{
			Coordinate target = DirectionConvertor.GetCoordinateFromDirection(direction);
			Coordinate actual = SnekBody[^2] - SnekBody[^1];
			if (target != actual * -1)
			{
				SnekBody.RemoveAt(0);
				SnekBody.Add(SnekBody[^1] + target);
			}
		}
	}
}
