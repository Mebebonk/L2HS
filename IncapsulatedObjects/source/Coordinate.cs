using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncapsulatedObjects
{
	public class Coordinate : Validatable, IEquatable<Coordinate>
	{

		public int X { get; private set; }
		public int Y { get; private set; }
		public Coordinate(int x, int y)
		{
			X = x;
			Y = y;
		}
		public Coordinate[] GetAdjesant(bool full = false)
		{
			List<Coordinate> adj = new();

			Coordinate[] shortArray = new Coordinate[]
			{
					new Coordinate(X - 1, Y),
					new Coordinate(X, Y + 1),
					new Coordinate(X + 1, Y),
					new Coordinate(X, Y - 1)
			};

			foreach (Coordinate coord in shortArray)
			{
				coord.ActionOnValid(() => adj.Add(coord));
			}

			if (full)
			{
				Coordinate[] longArray = new Coordinate[]
				{
				new Coordinate(X - 1, Y + 1),
				new Coordinate(X + 1, Y + 1),
				new Coordinate(X + 1, Y - 1),
				new Coordinate(X + 1, Y - 1)
				};

				foreach (Coordinate coord in longArray)
				{
					coord.ActionOnValid(() => adj.Add(coord));
				}
			}

			return adj.ToArray();

		}

		public override bool Equals(object? obj) => this.Equals(obj as Coordinate);
		public override int GetHashCode() => (X, Y).GetHashCode();

		public bool Equals(Coordinate? other)
		{
			if (other is null) return false;
			if (ReferenceEquals(this, other)) return true;
			if (this.GetType() != other.GetType()) return false;
			return (X == other.X && Y == other.Y);
		}

		public override bool IsValid() { return X > 0 && X < RuleSet.RuleSet.maxWidth && Y > 0 && Y < RuleSet.RuleSet.maxHight; }

		public static bool operator ==(Coordinate a, Coordinate b) { return a.X == b.X && a.Y == b.Y; }

		public static bool operator !=(Coordinate a, Coordinate b) { return !(a == b); }

		public static Coordinate operator +(Coordinate a, Coordinate b) { return new Coordinate(a.X + b.X, a.Y + b.Y); }

		public static Coordinate operator -(Coordinate a, Coordinate b) { return new Coordinate(a.X - b.X, a.Y - b.Y); }

		public static Coordinate operator *(Coordinate a, int b) { return new Coordinate(a.X * b, a.Y * b); }


	}
}
