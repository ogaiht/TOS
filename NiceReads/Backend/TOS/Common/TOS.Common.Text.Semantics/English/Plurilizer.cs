using System;
using System.Collections.Generic;

namespace TOS.Common.Text.Semantics.English
{
	public class Plurilizer : IPlurilizer
	{
		private static readonly Dictionary<string, string> _exceptions = new Dictionary<string, string>() {
				{ "man", "Men" },
				{ "woman", "Women" },
				{ "child", "Children" },
				{ "tooth", "Teeth" },
				{ "foot", "Feet" },
				{ "mouse", "Mice" },
				{ "belief", "Beliefs" } };


		private static bool CheckExceptions(string text, out string plural)
		{
			string lowerValue = text.ToLowerInvariant();
			if (_exceptions.ContainsKey(lowerValue))
			{
				string result = _exceptions[lowerValue];
				if (char.IsUpper(text[0]))
				{
					result = char.ToUpper(result[0]) + result[1..];
				}
				plural = result;
				return true;
			}
			plural = null;
			return false;
		}

		private static bool CheckYs(string text, out string plural)
		{
			if (text.EndsWith("y", StringComparison.OrdinalIgnoreCase) &&
				!text.EndsWith("ay", StringComparison.OrdinalIgnoreCase) &&
				!text.EndsWith("ey", StringComparison.OrdinalIgnoreCase) &&
				!text.EndsWith("iy", StringComparison.OrdinalIgnoreCase) &&
				!text.EndsWith("oy", StringComparison.OrdinalIgnoreCase) &&
				!text.EndsWith("uy", StringComparison.OrdinalIgnoreCase))
			{
				plural = text[0..^1] + "ies";
				return true;
			}
			plural = null;
			return false;
		}

		public string Plurilize(string text)
		{
			if (CheckExceptions(text, out string plural))
			{
				return plural;
			}
			else if (CheckYs(text, out plural))
			{
				return plural;
			}
			else if (text.EndsWith("s", StringComparison.InvariantCultureIgnoreCase))
			{
				return text;
			}
			else if (text.EndsWith("us", StringComparison.InvariantCultureIgnoreCase) ||
				text.EndsWith("ss", StringComparison.InvariantCultureIgnoreCase) ||
				text.EndsWith("x", StringComparison.InvariantCultureIgnoreCase) ||
				text.EndsWith("ch", StringComparison.InvariantCultureIgnoreCase) ||
				text.EndsWith("sh", StringComparison.InvariantCultureIgnoreCase))
			{
				return text + "es";
			}
			else if (text.EndsWith("f", StringComparison.InvariantCultureIgnoreCase) && text.Length > 1)
			{
				return text[0..^1] + "ves";
			}
			else if (text.EndsWith("fe", StringComparison.InvariantCultureIgnoreCase) && text.Length > 2)
			{
				return text[0..^2] + "ves";
			}
			else
			{
				return text + "s";
			}
		}
	}
}
