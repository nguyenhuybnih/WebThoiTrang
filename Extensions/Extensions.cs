using System.Text.RegularExpressions;

namespace WebThoiTrang.Extensions
{

	public static class Extension
	{
		public static string ToVnd(this double donGia)
		{
			return donGia.ToString("#,##0") + " đ";
		}
		public static string ToTitleCase(string str)
		{
			string result = str;
			if (!string.IsNullOrEmpty(str))
			{
				var words = str.Split(' ');
				for (int index =0 ; index < words.Length; index++)
{
					var s = words[index];
					if (s.Length > 0)
					{
						words[index]=s[0].ToString().ToUpper() + s.Substring(1);
					}
				}
				result = string.Join(" ", words);
			}
			return result;
		}
		public static string ToUrlFriendly(this string url)
		{
			var result = url.ToLower().Trim();
			
result = Regex.Replace(result, "áàààäàãààáǎāāā", "a");
result = Regex.Replace(result, "éèèèèèèèèéë", "e");
			result = Regex.Replace(result, "óò¦õõôôôôõõ¤áðдõõ", "o");
			result = Regex.Replace(result, "úùyüūvýìýửữ", "u");
			result = Regex.Replace(result, "íìjiî", "i");
			result = Regex.Replace(result, "ÿÿÿÿÿ", "y");
			result = Regex.Replace(result, "d", "d");
			result = Regex.Replace(result, "[^a-z0-9-]", "");
			result = Regex.Replace(result, "(-)+", "-");
			return result;
		}
	}
}