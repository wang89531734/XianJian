using Newtonsoft.Json;
using System;
using System.Text.RegularExpressions;

public class SwdJsonCovertor : IConverter
{
	private const string END_STR = "\n\0";

	public string serializeObject(object data)
	{
		return JsonConvert.SerializeObject(data) + "\n\0";
	}

	public string serializeObject<T>(T data)
	{
		return JsonConvert.SerializeObject(data);
	}

	public T deserializeObject<T>(string value)
	{
		string value2 = this.handleJsonString(value);
		return JsonConvert.DeserializeObject<T>(value2);
	}

	public object deserializeObject(string value, Type type)
	{
		string value2 = this.handleJsonString(value);
		return JsonConvert.DeserializeObject(value2, type);
	}

	private string handleJsonString(string value)
	{
		string input = value.Replace("\n\0", string.Empty);
		string pattern = "\"[a-zA-Z]{1,}\\.[a-zA-Z\\.]{1,}\":";
		return Regex.Replace(input, pattern, new MatchEvaluator(this.replaceDotText));
	}

	private string replaceDotText(Match m)
	{
		string text = m.ToString();
		return text.Replace(".", string.Empty);
	}
}
