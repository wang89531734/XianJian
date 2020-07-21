using System;
using System.Collections.Generic;
using System.Text;

public class S_Achievement : I_BaseDBF
{
	public int GUID;

	public Enum_AchievementType emType;

	public Enum_AchievementMode emMode;

	public ENUM_AchievementGroup emGroup;

	public ENUM_AchievementSubGroup emSubGroup;

	public int Clear;

	public string Name;

	public string Desc;

	public string Condition;

	public string Icon;

	public int Share;

	public int PreFlag;

	public int Show;

	public int Role;

	public int TargetRole;

	public int Count;

	public int ObjID;

	public int Point;

	public List<float> FinishTime;

	public string MascotArea;

	public string MascotName;

	public string MascotDesc;

	public string MascotIcon;

	public string MascotDesigner;

	public S_Achievement()
	{
		this.FinishTime = new List<float>();
	}

	public int GetGUID()
	{
		return this.GUID;
	}

	public void ParseJson(string JsonString, IConverter Converter, I_BaseDBF Record)
	{
		if (!(Record is S_Achievement))
		{
			return;
		}
		this.Name = GameDataDB.TransStringByLanguageType(this.Name);
		this.Desc = GameDataDB.TransStringByLanguageType(this.Desc);
		this.Condition = GameDataDB.TransStringByLanguageType(this.Condition);
		Dictionary<string, string> dictionary = Converter.deserializeObject<Dictionary<string, string>>(JsonString);
		for (int i = 0; i < 4; i++)
		{
			float num = 0f;
			string key = string.Format("FinishTime_{0}", i);
			if (dictionary.ContainsKey(key))
			{
				string s = dictionary[key];
				float.TryParse(s, out num);
			}
			if (num > 0f)
			{
				this.FinishTime.Add(num);
			}
		}
		this.MascotArea = GameDataDB.TransStringByLanguageType(this.MascotArea);
		this.MascotName = GameDataDB.TransStringByLanguageType(this.MascotName);
		this.MascotDesc = GameDataDB.TransStringByLanguageType(this.MascotDesc);
		this.MascotDesigner = GameDataDB.TransStringByLanguageType(this.MascotDesigner);
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder("成就:");
		stringBuilder.Append("\n GUID:" + this.GUID);
		stringBuilder.Append("\n emType:" + this.emType);
		stringBuilder.Append("\n emMode:" + this.emMode);
		stringBuilder.Append("\n emGroup:" + this.emGroup);
		stringBuilder.Append("\n emSubGroup:" + this.emSubGroup);
		stringBuilder.Append("\n Clear:" + this.Clear);
		stringBuilder.Append("\n Name:" + this.Name);
		stringBuilder.Append("\n Desc:" + this.Desc);
		stringBuilder.Append("\n Condition:" + this.Condition);
		stringBuilder.Append("\n Icon:" + this.Icon);
		stringBuilder.Append("\n PreFlag:" + this.PreFlag);
		stringBuilder.Append("\n Show:" + this.Show);
		stringBuilder.Append("\n Role:" + this.Role);
		stringBuilder.Append("\n TargetRole:" + this.TargetRole);
		stringBuilder.Append("\n Count:" + this.Count);
		stringBuilder.Append("\n ObjID:" + this.ObjID);
		stringBuilder.Append("\n Point:" + this.Point);
		stringBuilder.Append("\n FinishTime Size:" + this.FinishTime.Count);
		for (int i = 0; i < this.FinishTime.Count; i++)
		{
			stringBuilder.Append(string.Concat(new object[]
			{
				"\n FinishTime[",
				i,
				"]:",
				this.FinishTime[i]
			}));
		}
		stringBuilder.Append("\n MascotArea:" + this.MascotArea);
		stringBuilder.Append("\n MascotName:" + this.MascotName);
		stringBuilder.Append("\n MascotDesc:" + this.MascotDesc);
		stringBuilder.Append("\n MascotIcon:" + this.MascotIcon);
		stringBuilder.Append("\n MascotDesigner:" + this.MascotDesigner);
		return stringBuilder.ToString();
	}
}
