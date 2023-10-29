using IncapsulatedObjects;
using System;
using System.Text.Json;

namespace LessTwoHeadSnake
{
	internal class Snek
	{
		static void Main(string[] args)
		{
			Field testField = new(new Coordinate[]{ new Coordinate(1,2), new Coordinate (2,2)});
			string json = JsonSerializer.Serialize(testField);
			using FileStream file = File.Open("test.json", FileMode.Create);
			using StreamWriter writer = new(file);

			writer.WriteLine(json);
		}
	}
}