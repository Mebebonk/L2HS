using IncapsulatedObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainMenu
{
	internal class FieldListViewItem
	{
		public int WallCount { get; private set; }

		public bool AllowTP { get; private set; }

		public string FieldName { get; private set; }


		public FieldListViewItem(Field field, string fieldName)
		{
			WallCount = field.Walls.Length;
			AllowTP = field.AllowTP;
			FieldName = fieldName.Replace(".json", "");			
		}
	}
}
