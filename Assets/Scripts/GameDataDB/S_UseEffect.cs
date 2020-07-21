using System;
using System.Collections.Generic;

public class S_UseEffect : I_BaseDBF
{
	public int GUID;

	public string ActDataName;

	public ENUM_ItemSubType emItemType;

	public ENUM_Distance emDistance;

	public ENUM_UseTarget emTarget;

	public ENUM_UsePlace emUsePlace;

	public int UseMapID;

	public ENUM_UseRange emRange;

	public int AddRoleAttrID;

	public List<S_RefValue> RefValueList;

	public ENUM_ElementType emElementType;

	public int Damage;

	public int Count;

	public int SpecialID;

	public int AddHP;

	public int AddRatioHP;

	public int AddMP;

	public int AddRatioMP;

	public List<int> Buffer;

	public List<int> DeBuffer;

	public Enum_UseSkillCamera emUseSkillCamera;

	public Enum_ShakeSkillCamera emShakeSkillCamera;

	public S_SkillCameraData SkillCameraData;

	public S_UseEffect()
	{
		this.Buffer = new List<int>();
		this.DeBuffer = new List<int>();
		this.RefValueList = new List<S_RefValue>();
		this.SkillCameraData = new S_SkillCameraData();
	}

	public int GetGUID()
	{
		return this.GUID;
	}

	public void ParseJson(string JsonString, IConverter Converter, I_BaseDBF Record)
	{
		if (!(Record is S_UseEffect))
		{
			return;
		}
		Dictionary<string, string> dictionary = Converter.deserializeObject<Dictionary<string, string>>(JsonString);
		for (int i = 0; i < 2; i++)
		{
			S_RefValue s_RefValue = new S_RefValue();
			string key = string.Format("emRefValue_{0}", i);
			if (dictionary.ContainsKey(key))
			{
				string s = dictionary[key];
				int emRefValue;
				int.TryParse(s, out emRefValue);
				s_RefValue.emRefValue = (ENUM_RefValue)emRefValue;
			}
			key = string.Format("RefPercent_{0}", i);
			if (dictionary.ContainsKey(key))
			{
				string s = dictionary[key];
				float.TryParse(s, out s_RefValue.RefPercent);
			}
			if (s_RefValue.emRefValue != ENUM_RefValue.Null && s_RefValue.emRefValue != ENUM_RefValue.No)
			{
				this.RefValueList.Add(s_RefValue);
			}
		}
		for (int j = 0; j < 5; j++)
		{
			int num = 0;
			string key2 = string.Format("BufferID_{0}", j);
			if (dictionary.ContainsKey(key2))
			{
				string s2 = dictionary[key2];
				int.TryParse(s2, out num);
			}
			if (num > 0)
			{
				this.Buffer.Add(num);
			}
		}
		for (int k = 0; k < 5; k++)
		{
			int num2 = 0;
			string key3 = string.Format("DeBufferID_{0}", k);
			if (dictionary.ContainsKey(key3))
			{
				string s3 = dictionary[key3];
				int.TryParse(s3, out num2);
			}
			if (num2 > 0)
			{
				this.DeBuffer.Add(num2);
			}
		}
		if (this.emUseSkillCamera == Enum_UseSkillCamera.No)
		{
			return;
		}
		this.SkillCameraData = Converter.deserializeObject<S_SkillCameraData>(JsonString);
	}
}
