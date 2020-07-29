using System;
using System.Collections.Generic;

public class S_StartRoleData : I_BaseDBF
{
	public int GUID;

	public int Level;

	public string Desc;

	public int HP;

	public int MP;

	public int AP;

	public float AttackRang;

	public float MoveSpeed;

	public float DashSpeed;

	public float JumpHeight;

	public int StartExp;

	public List<int> Skill;

	public int[] Equip;

	public List<S_Favorability> Favorability;

	public S_StartRoleData()
	{
		this.Skill = new List<int>();
		this.Equip = new int[10];
		this.Favorability = new List<S_Favorability>();
	}

	public int GetGUID()
	{
		return this.GUID;
	}

	public void ParseJson(string JsonString, IConverter Converter, I_BaseDBF Record)
	{
		if (!(Record is S_StartRoleData))
		{
			return;
		}
		this.Desc = GameDataDB.TransStringByLanguageType(this.Desc);
		Dictionary<string, string> dictionary = Converter.deserializeObject<Dictionary<string, string>>(JsonString);
		for (int i = 0; i < 10; i++)
		{
			int num = 0;
			string key = string.Format("Skill_{0}", i);
			if (dictionary.ContainsKey(key))
			{
				string s = dictionary[key];
				int.TryParse(s, out num);
			}
			if (num > 0)
			{
				this.Skill.Add(num);
			}
		}
		for (int j = 0; j < 9; j++)
		{
			int num2 = 0;
			string key2 = string.Format("Equip_{0}", j);
			if (dictionary.ContainsKey(key2))
			{
				string s2 = dictionary[key2];
				int.TryParse(s2, out num2);
			}
			this.Equip[j] = num2;
		}
		for (int k = 0; k < 7; k++)
		{
			int num3 = 0;
			string key3 = string.Format("Favorability_{0}", k);
			if (dictionary.ContainsKey(key3))
			{
				string s3 = dictionary[key3];
				int.TryParse(s3, out num3);
			}
			if (num3 > 0)
			{
				S_Favorability s_Favorability = new S_Favorability();
				s_Favorability.ID = k + 1;
				s_Favorability.Value = num3;
				this.Favorability.Add(s_Favorability);
			}
		}
	}
}
