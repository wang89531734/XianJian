using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine;

namespace SoftStar.Pal6
{
	public class HPMPDPProperty
	{
		public enum FieldEnum
		{
			mHPRange = 1,
			mMPRange,
			mDPRange
		}

		public class DynamicValue : DynamicInt32
		{
			private int mBase;

			private int mByCalculate;

			public int Base
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

			public int ByCalculate
			{
				get
				{
					return this.mByCalculate;
				}
				set
				{
					this.mByCalculate = value;
					this.Calculate();
				}
			}

			public DynamicValue(int inMinValue, int inMaxValue) : base(inMinValue, inMaxValue)
			{
			}

			public override void Calculate()
			{
				int result = this.result;
				this.result = (int)((float)(this.mBase + this.mByCalculate + this.mAdd) * this.mScale);
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
		}

		public class StaticData
		{
			public static readonly string DefaultDataPath = Path.Combine(Application.dataPath, "Data/Property/HPMPDP.dat");

			private int mHPRange;

			private int mMPRange;

			private int mDPRange;

			private static string[] mDataPaths = null;

			private static Dictionary<uint, HPMPDPProperty.StaticData> Datas = null;

			public int HPRange
			{
				get
				{
					return this.mHPRange;
				}
			}

			public int MPRange
			{
				get
				{
					return this.mMPRange;
				}
			}

			public int DPRange
			{
				get
				{
					return this.mDPRange;
				}
			}

			public static string[] DataPaths
			{
				get
				{
					if (HPMPDPProperty.StaticData.mDataPaths == null)
					{
						string str = "." + PalMain.GameDifficulty.ToString();
						List<string> list = new List<string>();
						list.Add(HPMPDPProperty.StaticData.DefaultDataPath + str);
						string path = HPMPDPProperty.StaticData.DefaultDataPath + ".list";
						if (File.Exists(path))
						{
							using (StreamReader streamReader = new StreamReader(path, Encoding.UTF8, true))
							{
								do
								{
									string text = streamReader.ReadLine() + str;
									if (File.Exists(text))
									{
										list.Add(text);
									}
								}
								while (streamReader.EndOfStream);
							}
						}
						HPMPDPProperty.StaticData.mDataPaths = list.ToArray();
					}
					return HPMPDPProperty.StaticData.mDataPaths;
				}
			}

			public StaticData(out uint Key, BinaryReader DataReader)
			{
				Key = DataReader.ReadUInt32();
				this.mHPRange = DataReader.ReadInt32();
				this.mMPRange = DataReader.ReadInt32();
				this.mDPRange = DataReader.ReadInt32();
			}

			public static Dictionary<uint, HPMPDPProperty.StaticData> GetDatasFromFile()
			{
				if (HPMPDPProperty.StaticData.Datas == null)
				{
					Dictionary<uint, HPMPDPProperty.StaticData> dictionary = new Dictionary<uint, HPMPDPProperty.StaticData>(65536);
					string[] dataPaths = HPMPDPProperty.StaticData.DataPaths;
					for (int i = 0; i < dataPaths.Length; i++)
					{
						string text = dataPaths[i];
						if (text.ExistFile())
						{
							using (FileStream fileStream = new FileStream(text, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
							{
								BinaryReader dataReader = new BinaryReader(fileStream);
								while (fileStream.Position < fileStream.Length)
								{
									uint key;
									HPMPDPProperty.StaticData value = new HPMPDPProperty.StaticData(out key, dataReader);
									if (!dictionary.ContainsKey(key))
									{
										dictionary.Add(key, value);
									}
									else
									{
										Debug.Log(text + " id conflict : " + key.ToString());
									}
								}
							}
						}
					}
					HPMPDPProperty.StaticData.Datas = dictionary;
					return HPMPDPProperty.StaticData.Datas;
				}
				return HPMPDPProperty.StaticData.Datas;
			}

			public static HPMPDPProperty.StaticData GetData(uint id)
			{
				Dictionary<uint, HPMPDPProperty.StaticData> datasFromFile = HPMPDPProperty.StaticData.GetDatasFromFile();
				HPMPDPProperty.StaticData result = null;
				datasFromFile.TryGetValue(id, out result);
				return result;
			}

			public static void Reset()
			{
				HPMPDPProperty.StaticData.mDataPaths = null;
				HPMPDPProperty.StaticData.Datas = null;
			}
		}

		private HPMPDPProperty.DynamicValue mHPRange;

		private HPMPDPProperty.DynamicValue mMPRange;

		private HPMPDPProperty.DynamicValue mDPRange;

		private int mHP;

		private int mMP;

		private int mDP;

		private PlayerBaseProperty mLinkPlayerBase;

        public event Action<int> OnChangeHP;

		public event Action<int> OnChangeMP;

        public event Action<int> OnChangeDP;

        public event Action OnUnLink;

		public HPMPDPProperty.DynamicValue HPRange
		{
			get
			{
				return this.mHPRange;
			}
		}

		public HPMPDPProperty.DynamicValue MPRange
		{
			get
			{
				return this.mMPRange;
			}
		}

		public HPMPDPProperty.DynamicValue DPRange
		{
			get
			{
				return this.mDPRange;
			}
		}

		public PlayerBaseProperty LinkPlayerBase
		{
			set
			{
				if (this.mLinkPlayerBase == value)
				{
					return;
				}
				if (this.mLinkPlayerBase != null)
				{
					//this.mLinkPlayerBase.Stamina.OnChangeValue -= new Action<float>(this.ReCalculateBase_HPRange);
				}
				this.mLinkPlayerBase = value;
				if (this.mLinkPlayerBase != null)
				{
					//this.mLinkPlayerBase.Stamina.OnChangeValue += new Action<float>(this.ReCalculateBase_HPRange);
				}
				this.ReCalculateBase_HPRange(this.mHPRange);
			}
		}

		public int HP
		{
			get
			{
				return this.mHP;
			}
			set
			{
				if (value == this.mHP)
				{
					return;
				}
				int obj = this.mHP;
				if (value < 0)
				{
					this.mHP = 0;
				}
				else if (value > this.mHPRange)
				{
					this.mHP = this.mHPRange;
				}
				else
				{
					this.mHP = value;
				}
				if (this.OnChangeHP != null)
				{
					this.OnChangeHP(obj);
				}
			}
		}

		public int MP
		{
			get
			{
				return this.mMP;
			}
			set
			{
				if (value == this.mMP)
				{
					return;
				}
				int obj = this.mMP;
				if (value < 0)
				{
					this.mMP = 0;
				}
				else if (value > this.mMPRange)
				{
					this.mMP = this.mMPRange;
				}
				else
				{
					this.mMP = value;
				}
				if (this.OnChangeMP != null)
				{
					this.OnChangeMP(obj);
				}
			}
		}

		public int DP
		{
			get
			{
				return this.mDP;
			}
			set
			{
				if (value == this.mDP)
				{
					return;
				}
				int obj = this.mDP;
				if (value < 0)
				{
					this.mDP = 0;
				}
				else if (value > this.mDPRange)
				{
					this.mDP = this.mDPRange;
				}
				else
				{
					this.mDP = value;
				}
				if (this.OnChangeDP != null)
				{
					this.OnChangeDP(obj);
				}
			}
		}

		public HPMPDPProperty(HPMPDPProperty.StaticData SourceData)
		{
			this.mHPRange = new HPMPDPProperty.DynamicValue(1, 999999);
			this.mHPRange.Base = SourceData.HPRange;
			this.mMPRange = new HPMPDPProperty.DynamicValue(1, 9999);
			this.mMPRange.Base = SourceData.MPRange;
			this.mDPRange = new HPMPDPProperty.DynamicValue(1, 9999);
			this.mDPRange.Base = SourceData.DPRange;
		}

		private void ReCalculateBase_HPRange(int oldValue)
		{
			this.ReCalculateBase_HPRange((float)oldValue);
		}

		private void ReCalculateBase_HPRange(float oldValue)
		{
			if (this.mLinkPlayerBase != null)
			{
				//this.mHPRange.ByCalculate = (int)(this.mLinkPlayerBase.Stamina * 1830f / 193f + 170f);
			}
			else
			{
				this.mHPRange.ByCalculate = 0;
			}
			if (this.mHPRange < this.mHP)
			{
				int obj = this.mHP;
				this.mHP = this.mHPRange;
				if (this.OnChangeHP != null)
				{
					this.OnChangeHP(obj);
				}
			}
		}

		public void SetWithoutEvents(int newHP, int newMP, int newDP)
		{
			this.mHP = newHP;
			this.mMP = newMP;
			this.mDP = newDP;
		}

		public void UnLink()
		{
			this.LinkPlayerBase = null;
			if (this.OnUnLink != null)
			{
				this.OnUnLink();
			}
		}

		~HPMPDPProperty()
		{
			this.UnLink();
		}
	}
}
