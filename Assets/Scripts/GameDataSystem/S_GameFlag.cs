using System;

public class S_GameFlag
{
	private readonly byte[] flagMask = new byte[]
	{
		1,
		2,
		4,
		8,
		16,
		32,
		64,
		128
	};

	private byte[] flagState = new byte[4096];

	private bool m_UseTempFlag;

	public void SetTempFlag(bool bTemp)
	{
		this.m_UseTempFlag = bTemp;
	}

	public byte[] GetData()
	{
		return this.flagState;
	}

	public void Clear()
	{
		for (int i = 0; i < this.flagState.Length; i++)
		{
			this.flagState[i] = 0;
		}
	}

	public void SetData(byte[] data)
	{
		Array.Copy(data, this.flagState, data.Length);
		this.flagState = data;
	}

	public bool Get(int flag)
	{
		return (this.flagState[flag >> 3] & this.flagMask[flag & 7]) != 0;
	}

	public void ON(int flag)
	{
		byte[] expr_0E_cp_0 = this.flagState;
		int expr_0E_cp_1 = flag >> 3;
		expr_0E_cp_0[expr_0E_cp_1] |= this.flagMask[flag & 7];
	}

	public void OFF(int flag)
	{
		byte[] expr_0E_cp_0 = this.flagState;
		int expr_0E_cp_1 = flag >> 3;
		expr_0E_cp_0[expr_0E_cp_1] &= (byte)(255 - this.flagMask[flag & 7]);
	}

	public void Set(int flag, bool val)
	{
		if (val)
		{
			this.ON(flag);
			return;
		}
		this.OFF(flag);
	}
}
