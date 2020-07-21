using System;
using System.Text;

[Serializable]
public struct S_EffectSetting
{
	public string EffectName;

	public int EffectTime;

	public string SoundName;

	public bool SoundLoop;

	public bool RefPoint;

	public string RefPointName;

	public bool FollowRefPoint;

	public bool ScaleChange;

	public bool ScaleX;

	public bool ScaleY;

	public bool ScaleZ;

	public bool ScaleXYZ;

	public float ScaleStart;

	public float ScaleEnd;

	public float ScaleTime;

	public bool ScaleLoop;

	public bool RotateChange;

	public float RotateX;

	public float RotateY;

	public float RotateZ;

	public bool ColorChange;

	public string ColorName;

	public float ColorStartR;

	public float ColorStartG;

	public float ColorStartB;

	public float ColorStartA;

	public float ColorEndR;

	public float ColorEndG;

	public float ColorEndB;

	public float ColorEndA;

	public int ColorTime;

	public bool ColorLoop;

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder("法術特效:" + this.EffectName);
		stringBuilder.Append("\n SoundName:" + this.SoundName);
		stringBuilder.Append("\n EffectTime:" + this.EffectTime);
		stringBuilder.Append("\n RefPoint:" + this.RefPoint);
		stringBuilder.Append("\n RefPointName:" + this.RefPointName);
		stringBuilder.Append("\n FollowRefPoint:" + this.FollowRefPoint);
		stringBuilder.Append("\n ScaleChange:" + this.ScaleChange);
		stringBuilder.Append(string.Concat(new object[]
		{
			"\n Scale XYZ[",
			this.ScaleXYZ,
			"] X[",
			this.ScaleX,
			"] Y[",
			this.ScaleY,
			"] Z[",
			this.ScaleZ,
			"]"
		}));
		stringBuilder.Append(string.Concat(new object[]
		{
			"\n Scale Start[",
			this.ScaleStart,
			"] End[",
			this.ScaleEnd,
			"]"
		}));
		stringBuilder.Append("\n ScaleTime:" + this.ScaleTime);
		stringBuilder.Append("\n ScaleLoop:" + this.ScaleLoop);
		stringBuilder.Append("\n RotateChange:" + this.RotateChange);
		stringBuilder.Append(string.Concat(new object[]
		{
			"\n Rotate X[",
			this.RotateX,
			"] Y[",
			this.RotateY,
			"] Z[",
			this.RotateZ,
			"]"
		}));
		stringBuilder.Append("\n ColorChange:" + this.ColorChange);
		stringBuilder.Append("\n ColorName:" + this.ColorName);
		stringBuilder.Append(string.Concat(new object[]
		{
			"\n ColorStart R[",
			this.ColorStartR,
			"] G[",
			this.ColorStartG,
			"] B[",
			this.ColorStartB,
			"] A[",
			this.ColorStartA,
			"]"
		}));
		stringBuilder.Append(string.Concat(new object[]
		{
			"\n ColorEnd   R[",
			this.ColorEndR,
			"] G[",
			this.ColorEndG,
			"] B[",
			this.ColorEndB,
			"] A[",
			this.ColorEndA,
			"]"
		}));
		stringBuilder.Append("\n ColorTime:" + this.ColorTime);
		stringBuilder.Append("\n ColorLoop:" + this.ColorLoop);
		return stringBuilder.ToString();
	}
}
