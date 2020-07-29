using System;
using System.Collections.Generic;

public class S_UseEffect
{
	public int EffectID;

	public ENUM_Distance emDistance;

	public ENUM_UseTarget emTarget;

	public ENUM_UsePlace emUsePlace;

	public int UseMapID;

	public ENUM_UseRange emRange;

	public int AddRoleAttrID;

	public ENUM_RefValue emRefValue;

	public ENUM_RefType emRefType;

	public float RefPercent;

	public ENUM_ElementType emElementType;

	public int Damage;

	public int HitTimes;

	public int Count;

	public int SpecialID;

	public int AddHP;

	public int AddRatioHP;

	public int AddMP;

	public int AddRatioMP;

	public int AddAP;

	public int AddRatioAP;

	public int AddActivePoint;

	public int AddRatioActivePoint;

	public int AddWeakValue;

	public int AddRatioWeakValue;

	public List<S_Buffer> Buffer;

	public List<S_Buffer> DeBuffer;

	public S_UseEffect()
	{
		this.Buffer = new List<S_Buffer>();
		this.DeBuffer = new List<S_Buffer>();
	}

	public void ParseData(Dictionary<string, string> values)
	{
		for (int i = 0; i < 5; i++)
		{
			S_Buffer s_Buffer = new S_Buffer();
			string key = string.Format("BufferID_{0}", i);
			if (values.ContainsKey(key))
			{
				string s = values[key];
				int.TryParse(s, out s_Buffer.ID);
			}
			key = string.Format("HitRate_{0}", i);
			if (values.ContainsKey(key))
			{
				string s = values[key];
				int.TryParse(s, out s_Buffer.HitRate);
			}
			if (s_Buffer.ID > 0)
			{
				this.Buffer.Add(s_Buffer);
			}
		}
		for (int j = 0; j < 5; j++)
		{
			S_Buffer s_Buffer2 = new S_Buffer();
			string key2 = string.Format("DeBufferID_{0}", j);
			if (values.ContainsKey(key2))
			{
				string s2 = values[key2];
				int.TryParse(s2, out s_Buffer2.ID);
			}
			key2 = string.Format("DeHitRate_{0}", j);
			if (values.ContainsKey(key2))
			{
				string s2 = values[key2];
				int.TryParse(s2, out s_Buffer2.HitRate);
			}
			if (s_Buffer2.ID > 0)
			{
				this.DeBuffer.Add(s_Buffer2);
			}
		}
	}
}
