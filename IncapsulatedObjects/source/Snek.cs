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
		private Directions direction;

		private bool quedFood = false;
		public Snek(Coordinate start)
		{
			var rnd = new Random();
			SnekBody = new(2)
			{
				start.GetAdjesant()[rnd.Next(start.GetAdjesant().Length)],
				start
			};
			direction = DirectionConvertor.GetDirectionFromCoordinate(SnekBody[^1] - SnekBody[^2]);
		}

		public override bool IsValid()
		{
			return SnekBody.Count > 1;
		}

		public void Move(Directions? direction)
		{
			if (direction is not null)
			{
				Coordinate front = DirectionConvertor.GetCoordinateFromDirection(this.direction);
				Coordinate target = DirectionConvertor.GetCoordinateFromDirection((Directions)direction);
				if (front * -1 != target) { this.direction = (Directions)direction; }
			}

			if (!quedFood) { SnekBody.RemoveAt(0); }
			quedFood = false;
			SnekBody.Add(SnekBody[^1] - DirectionConvertor.GetCoordinateFromDirection(this.direction));
		}

		public void TeleportHead()
		{
			Coordinate tpDir = SnekBody[^1] - SnekBody[^1].GetAdjesant()[0];
			SnekBody[^1] -= tpDir * new Coordinate(RuleSet.RuleSet.maxWidth, RuleSet.RuleSet.maxHeight);
		}

		public void QueFood()
		{
			quedFood = true;
		}
	}
}
