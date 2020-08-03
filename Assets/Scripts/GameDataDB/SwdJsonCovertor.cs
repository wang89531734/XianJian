using System;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

// Token: 0x02001360 RID: 4960
public class SwdJsonCovertor : IConverter
{
	// Token: 0x06006EB4 RID: 28340 RVA: 0x00414848 File Offset: 0x00412A48
	public string serializeObject(object data)
	{
		return JsonConvert.SerializeObject(data) + "\n\0";
	}

	// Token: 0x06006EB5 RID: 28341 RVA: 0x00414868 File Offset: 0x00412A68
	public string serializeObject<T>(T data)
	{
		return JsonConvert.SerializeObject(data);
	}

	// Token: 0x06006EB6 RID: 28342 RVA: 0x00414884 File Offset: 0x00412A84
	public T deserializeObject<T>(string value)
	{
		string value2 = this.handleJsonString(value);
		return JsonConvert.DeserializeObject<T>(value2);
	}

	// Token: 0x06006EB7 RID: 28343 RVA: 0x004148A4 File Offset: 0x00412AA4
	public object deserializeObject(string value, Type type)
	{
		string value2 = this.handleJsonString(value);
		return JsonConvert.DeserializeObject(value2, type);
	}

	// Token: 0x06006EB8 RID: 28344 RVA: 0x004148C4 File Offset: 0x00412AC4
	private string handleJsonString(string value)
	{
		string input = value.Replace("\n\0", string.Empty);
		string pattern = "\"[a-zA-Z]{1,}\\.[a-zA-Z\\.]{1,}\":";
		return Regex.Replace(input, pattern, new MatchEvaluator(this.replaceDotText));
	}

	// Token: 0x06006EB9 RID: 28345 RVA: 0x00414900 File Offset: 0x00412B00
	private string replaceDotText(Match m)
	{
		string text = m.ToString();
		return text.Replace(".", string.Empty);
	}

	// Token: 0x040046AB RID: 18091
	private const string END_STR = "\n\0";
}
