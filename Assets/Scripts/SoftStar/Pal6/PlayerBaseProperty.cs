using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

namespace SoftStar.Pal6
{
	// Token: 0x02000719 RID: 1817
	public class PlayerBaseProperty
	{
		// Token: 0x06003216 RID: 12822 RVA: 0x0016B96C File Offset: 0x00169B6C
		public PlayerBaseProperty(PlayerBaseProperty.PlayerBaseData SourceData)
		{
			this.mStrength = new PlayerBaseProperty.DynamicValue(0f, 999f);
			this.mStrength.Base = SourceData.Strength;
			this.mStamina = new PlayerBaseProperty.DynamicValue(0f, 999f);
			this.mStamina.Base = SourceData.Stamina;
			this.mSpeed = new PlayerBaseProperty.DynamicValue(0f, 999f);
			this.mSpeed.Base = SourceData.Speed;
			this.mLuck = new PlayerBaseProperty.DynamicValue(0f, 999f);
			this.mLuck.Base = SourceData.Luck;
			this.mMagic = new PlayerBaseProperty.DynamicValue(0f, 999f);
			this.mMagic.Base = SourceData.Magic;
		}

		// Token: 0x170003E1 RID: 993
		// (get) Token: 0x06003217 RID: 12823 RVA: 0x0016BA40 File Offset: 0x00169C40
		public PlayerBaseProperty.DynamicValue Strength
		{
			get
			{
				return this.mStrength;
			}
		}

		// Token: 0x170003E2 RID: 994
		// (get) Token: 0x06003218 RID: 12824 RVA: 0x0016BA48 File Offset: 0x00169C48
		public PlayerBaseProperty.DynamicValue Stamina
		{
			get
			{
				return this.mStamina;
			}
		}

		// Token: 0x170003E3 RID: 995
		// (get) Token: 0x06003219 RID: 12825 RVA: 0x0016BA50 File Offset: 0x00169C50
		public PlayerBaseProperty.DynamicValue Speed
		{
			get
			{
				return this.mSpeed;
			}
		}

		// Token: 0x170003E4 RID: 996
		// (get) Token: 0x0600321A RID: 12826 RVA: 0x0016BA58 File Offset: 0x00169C58
		public PlayerBaseProperty.DynamicValue Luck
		{
			get
			{
				return this.mLuck;
			}
		}

		// Token: 0x170003E5 RID: 997
		// (get) Token: 0x0600321B RID: 12827 RVA: 0x0016BA60 File Offset: 0x00169C60
		public PlayerBaseProperty.DynamicValue Magic
		{
			get
			{
				return this.mMagic;
			}
		}

		// Token: 0x0600321C RID: 12828 RVA: 0x0016BA68 File Offset: 0x00169C68
		private void Change(PlayerBaseProperty.PlayerBaseData SourceData)
		{
			this.mStrength.Base = SourceData.Strength;
			this.mStamina.Base = SourceData.Stamina;
			this.mSpeed.Base = SourceData.Speed;
			this.mLuck.Base = SourceData.Luck;
			this.mMagic.Base = SourceData.Magic;
		}

		// Token: 0x0600321D RID: 12829 RVA: 0x0016BACC File Offset: 0x00169CCC
		public static PlayerBaseProperty.PlayerBaseData GetData(uint characterID, int level)
		{
			PlayerBaseProperty.LevelData[] datasFromFile = PlayerBaseProperty.LevelData.GetDatasFromFile();
			if (level <= 0 || level > datasFromFile.Length)
			{
				return null;
			}
			PlayerBaseProperty.LevelData levelData = datasFromFile[level - 1];
			if ((ulong)characterID >= (ulong)((long)levelData.PlayerBase.Length))
			{
				return null;
			}
			return levelData.PlayerBase[(int)((UIntPtr)characterID)];
		}

		// Token: 0x0600321E RID: 12830 RVA: 0x0016BB14 File Offset: 0x00169D14
		public void ChangeLevel(uint characterID, int level)
		{
			PlayerBaseProperty.PlayerBaseData data = PlayerBaseProperty.GetData(characterID, level);
			if (data == null)
			{
				Debug.LogError(characterID.ToString() + " 没有对应升级数据");
				return;
			}
			this.Change(data);
		}

		// Token: 0x04002D81 RID: 11649
		private PlayerBaseProperty.DynamicValue mStrength;

		// Token: 0x04002D82 RID: 11650
		private PlayerBaseProperty.DynamicValue mStamina;

		// Token: 0x04002D83 RID: 11651
		private PlayerBaseProperty.DynamicValue mSpeed;

		// Token: 0x04002D84 RID: 11652
		private PlayerBaseProperty.DynamicValue mLuck;

		// Token: 0x04002D85 RID: 11653
		private PlayerBaseProperty.DynamicValue mMagic;

		// Token: 0x0200071A RID: 1818
		public class DynamicValue : DynamicFloat
		{
			// Token: 0x0600321F RID: 12831 RVA: 0x0016BB50 File Offset: 0x00169D50
			public DynamicValue(float inMinValue, float inMaxValue) : base(inMinValue, inMaxValue)
			{
			}

			// Token: 0x170003E6 RID: 998
			// (get) Token: 0x06003220 RID: 12832 RVA: 0x0016BB5C File Offset: 0x00169D5C
			// (set) Token: 0x06003221 RID: 12833 RVA: 0x0016BB64 File Offset: 0x00169D64
			public float Base
			{
				get
				{
					return this.mBase;
				}
				set
				{
					this.mBase = value;
					this.Calculate();
				}
			}

			// Token: 0x06003222 RID: 12834 RVA: 0x0016BB74 File Offset: 0x00169D74
			public override void Calculate()
			{
				float result = this.result;
				this.result = (this.mBase + this.mAdd) * this.mScale;
				if (this.result < this.mMinValue)
				{
					this.mIsOverdraw = true;
					this.result = this.mMinValue;
				}
				else if (this.result > this.mMaxValue)
				{
					this.result = this.mMaxValue;
				}
				if (result != this.result)
				{
					base.ChangeValue(result);
				}
			}

			// Token: 0x04002D86 RID: 11654
			private float mBase;
		}

		// Token: 0x0200071B RID: 1819
		public enum FieldEnum_PlayerBase
		{
			// Token: 0x04002D88 RID: 11656
			Strength,
			// Token: 0x04002D89 RID: 11657
			Stamina,
			// Token: 0x04002D8A RID: 11658
			Speed,
			// Token: 0x04002D8B RID: 11659
			Luck,
			// Token: 0x04002D8C RID: 11660
			Magic
		}

		// Token: 0x0200071C RID: 1820
		public class PlayerBaseData
		{
			// Token: 0x06003223 RID: 12835 RVA: 0x0016BBFC File Offset: 0x00169DFC
			public PlayerBaseData(BinaryReader DataReader)
			{
				this.Strength = DataReader.ReadSingle();
				this.Stamina = DataReader.ReadSingle();
				this.Speed = DataReader.ReadSingle();
				this.Luck = DataReader.ReadSingle();
				this.Magic = DataReader.ReadSingle();
			}

			// Token: 0x06003224 RID: 12836 RVA: 0x0016BC4C File Offset: 0x00169E4C
			public PlayerBaseData()
			{
			}

			// Token: 0x04002D8D RID: 11661
			public float Strength;

			// Token: 0x04002D8E RID: 11662
			public float Stamina;

			// Token: 0x04002D8F RID: 11663
			public float Speed;

			// Token: 0x04002D90 RID: 11664
			public float Luck;

			// Token: 0x04002D91 RID: 11665
			public float Magic;
		}

		// Token: 0x0200071D RID: 1821
		public class LevelData
		{
			// Token: 0x06003225 RID: 12837 RVA: 0x0016BC54 File Offset: 0x00169E54
			public LevelData(out int Key, BinaryReader DataReader)
			{
				Key = DataReader.ReadInt32();
				this.LevelExp = DataReader.ReadInt32();
				this.PlayerBase = new PlayerBaseProperty.PlayerBaseData[6];
				for (int i = 0; i < this.PlayerBase.Length; i++)
				{
					PlayerBaseProperty.PlayerBaseData playerBaseData = new PlayerBaseProperty.PlayerBaseData();
					playerBaseData = new PlayerBaseProperty.PlayerBaseData();
					playerBaseData.Strength = DataReader.ReadSingle();
					playerBaseData.Stamina = DataReader.ReadSingle();
					playerBaseData.Speed = DataReader.ReadSingle();
					playerBaseData.Luck = DataReader.ReadSingle();
					playerBaseData.Magic = DataReader.ReadSingle();
					this.PlayerBase[i] = playerBaseData;
				}
			}

			// Token: 0x170003E7 RID: 999
			// (get) Token: 0x06003227 RID: 12839 RVA: 0x0016BD24 File Offset: 0x00169F24
			public static string[] DataPaths
			{
				get
				{
					if (PlayerBaseProperty.LevelData.mDataPaths == null)
					{
						List<string> list = new List<string>();
						list.Add(PlayerBaseProperty.LevelData.DefaultDataPath);
						string path = PlayerBaseProperty.LevelData.DefaultDataPath + ".list";
						if (File.Exists(path))
						{
							using (StreamReader streamReader = new StreamReader(path, Encoding.UTF8, true))
							{
								do
								{
									string text = streamReader.ReadLine();
									if (File.Exists(text))
									{
										list.Add(text);
									}
								}
								while (streamReader.EndOfStream);
							}
						}
						PlayerBaseProperty.LevelData.mDataPaths = list.ToArray();
					}
					return PlayerBaseProperty.LevelData.mDataPaths;
				}
			}

			// Token: 0x06003228 RID: 12840 RVA: 0x0016BDD8 File Offset: 0x00169FD8
			public static PlayerBaseProperty.LevelData[] GetDatasFromFile()
			{
				if (PlayerBaseProperty.LevelData.Datas == null)
				{
					List<PlayerBaseProperty.LevelData> list = new List<PlayerBaseProperty.LevelData>(256);
					foreach (string text in PlayerBaseProperty.LevelData.DataPaths)
					{
						if (text.ExistFile())
						{
							using (FileStream fileStream = new FileStream(text, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
							{
								BinaryReader dataReader = new BinaryReader(fileStream);
								while (fileStream.Position < fileStream.Length)
								{
									int num;
									PlayerBaseProperty.LevelData levelData = new PlayerBaseProperty.LevelData(ref num, dataReader);
									if (num >= list.Count)
									{
										if (list.Capacity < num)
										{
											list.Capacity = num;
										}
										while (list.Count < num)
										{
											list.Add(null);
										}
										list.Add(levelData);
									}
									else if (list[num] == null)
									{
										list[num] = levelData;
									}
									else
									{
										Debug.Log(text + " id conflict : " + num.ToString());
									}
								}
							}
						}
					}
					PlayerBaseProperty.LevelData.Datas = list.ToArray();
					return PlayerBaseProperty.LevelData.Datas;
				}
				return PlayerBaseProperty.LevelData.Datas;
			}

			// Token: 0x06003229 RID: 12841 RVA: 0x0016BF20 File Offset: 0x0016A120
			public static PlayerBaseProperty.LevelData GetData(int id)
			{
				PlayerBaseProperty.LevelData[] datasFromFile = PlayerBaseProperty.LevelData.GetDatasFromFile();
				if (id >= 0 && id < datasFromFile.Length)
				{
					return datasFromFile[id];
				}
				return null;
			}

			// Token: 0x0600322A RID: 12842 RVA: 0x0016BF48 File Offset: 0x0016A148
			public static void Reset()
			{
				PlayerBaseProperty.LevelData.Datas = null;
			}

			// Token: 0x170003E8 RID: 1000
			// (get) Token: 0x0600322B RID: 12843 RVA: 0x0016BF50 File Offset: 0x0016A150
			public static int MaxLevel
			{
				get
				{
					return PlayerBaseProperty.LevelData.GetDatasFromFile().Length;
				}
			}

			// Token: 0x0600322C RID: 12844 RVA: 0x0016BF5C File Offset: 0x0016A15C
			public static int GetLevelExp(int level)
			{
				level--;
				if (level < 0)
				{
					return 0;
				}
				if (level < PlayerBaseProperty.LevelData.GetDatasFromFile().Length)
				{
					return PlayerBaseProperty.LevelData.GetDatasFromFile()[level].LevelExp;
				}
				return int.MaxValue;
			}

			// Token: 0x0600322D RID: 12845 RVA: 0x0016BF8C File Offset: 0x0016A18C
			public static int FindLevel(int Exp)
			{
				PlayerBaseProperty.LevelData[] datasFromFile = PlayerBaseProperty.LevelData.GetDatasFromFile();
				for (int i = 0; i < datasFromFile.Length; i++)
				{
					if (Exp < datasFromFile[i].LevelExp)
					{
						return i + 1;
					}
				}
				return 99;
			}

			// Token: 0x04002D92 RID: 11666
			public static readonly string DefaultDataPath = Path.Combine(Application.dataPath, "Data/Property/PlayerBase.dat");

			// Token: 0x04002D93 RID: 11667
			public readonly int LevelExp;

			// Token: 0x04002D94 RID: 11668
			public PlayerBaseProperty.PlayerBaseData[] PlayerBase;

			// Token: 0x04002D95 RID: 11669
			private static string[] mDataPaths = null;

			// Token: 0x04002D96 RID: 11670
			private static PlayerBaseProperty.LevelData[] Datas = null;
		}
	}
}
