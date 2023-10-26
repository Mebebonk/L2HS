using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncapsulatedObjects
{
	public class Coordinate : IEquatable<Coordinate>
	{

		public int X { get; private set; }
		public int Y { get; private set; }
		public Coordinate(int x, int y)
		{
			X = x;
			Y = y;
		}
		public override bool Equals(object? obj) => this.Equals(obj as Coordinate);
		public override int GetHashCode() => (X, Y).GetHashCode();

		public bool Equals(Coordinate? other)
		{
			if (other is null) return false;
			if (ReferenceEquals(this, other)) return true;
			if (this.GetType() !=  other.GetType()) return false;
			return (X == other.X && Y == other.Y);
		}

		public static bool operator ==(Coordinate a, Coordinate b)
		{
			return a.X == b.X && a.Y == b.Y;
		}

		public static bool operator !=(Coordinate a, Coordinate b) { return !(a == b); }
		
	}
}
