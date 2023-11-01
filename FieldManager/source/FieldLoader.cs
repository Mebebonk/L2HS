using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace IncapsulatedObjects
{
	static public class FieldLoader
	{
		static public Field? LoadField(string fileName)
		{					
			using FileStream file = File.OpenRead($"{fileName}");
			using StreamReader reader = new(file);

			return JsonSerializer.Deserialize<Field>(file);
		}
	}
}
