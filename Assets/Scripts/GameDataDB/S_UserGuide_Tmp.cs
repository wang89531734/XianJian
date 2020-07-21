using System;
using System.Text;

public class S_UserGuide_Tmp : I_BaseDBF
{
	public int GUID;

	public string Name;

	public string MainImg;

	public string InfoStr;

	public float AnimationPos_x;

	public float AnimationPos_y;

	public float Animation_w;

	public float Animation_h;

	public int NextGuideID;

	public int InfoPos;

	public int GetGUID()
	{
		return this.GUID;
	}

	public void ParseJson(string JsonString, IConverter Converter, I_BaseDBF Record)
	{
		this.Name = GameDataDB.TransStringByLanguageType(this.Name);
		this.InfoStr = GameDataDB.TransStringByLanguageType(this.InfoStr);
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder("教學:");
		stringBuilder.Append("\n GUID:" + this.GUID);
		stringBuilder.Append("\n Name:" + this.Name);
		stringBuilder.Append("\n MainImg:" + this.MainImg);
		stringBuilder.Append("\n InfoStr:" + this.InfoStr);
		stringBuilder.Append("\n AnimationPos_x:" + this.AnimationPos_x);
		stringBuilder.Append("\n AnimationPos_y:" + this.AnimationPos_y);
		stringBuilder.Append("\n Animation_w:" + this.Animation_w);
		stringBuilder.Append("\n Animation_h:" + this.Animation_h);
		stringBuilder.Append("\n NextGuideID:" + this.NextGuideID);
		stringBuilder.Append("\n InfoPos:" + this.InfoPos);
		return stringBuilder.ToString();
	}
}
