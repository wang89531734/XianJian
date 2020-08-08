using System;
using System.Collections.Generic;


public class S_StartRoleData : I_BaseDBF
{
	public int GUID;

	public int Level;

	public string Desc;

	public int HP;

	public int MP;

	public float AttackRang;

	public float MoveSpeed;

	public float DashSpeed;

	public float JumpHeight;

	public int StartExp;

	public ENUM_ElementType emElemntType;

	public List<int> Skill;

	public int[] Equip;

	public S_StartRoleData()
	{
		this.Skill = new List<int>();
		this.Equip = new int[8];
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
		for (int j = 0; j < 8; j++)
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
	}
}
