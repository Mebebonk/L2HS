using IncapsulatedObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FieldManager
{
	static public class FieldSaver
	{
		static public bool SaveField(Field field, string fieldFileName, string filePath)
		{
			try
			{
				using FileStream file = File.Create($"{filePath}{fieldFileName}.json");
				using StreamWriter writer = new(file);
				var json = JsonSerializer.Serialize(field);
				writer.Write(json);

				return true;
			}
			catch
			{
				return false;
			}
		}

		static public bool SaveField(Field field, string fieldFileName)
		{
			return SaveField(field, $"{fieldFileName}", $"..\\Maps\\");
		}
	}
}
