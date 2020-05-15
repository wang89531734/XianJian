using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

namespace SoftStar.Pal6
{
    public class HPMPDPProperty
    {
        //private HPMPDPProperty.DynamicValue mHPRange;

        //private HPMPDPProperty.DynamicValue mMPRange;

        //private HPMPDPProperty.DynamicValue mDPRange;

        private int mHP;

        private int mMP;

        private int mDP;

        //private PlayerBaseProperty mLinkPlayerBase;

        //        public enum FieldEnum
        //        {
        //            // Token: 0x04002B4F RID: 11087
        //            mHPRange = 1,
        //            // Token: 0x04002B50 RID: 11088
        //            mMPRange,
        //            // Token: 0x04002B51 RID: 11089
        //            mDPRange
        //        }

        //public HPMPDPProperty(HPMPDPProperty.StaticData SourceData)
        //{
        //    this.mHPRange = new HPMPDPProperty.DynamicValue(1, 999999);
        //    this.mHPRange.Base = SourceData.HPRange;
        //    this.mMPRange = new HPMPDPProperty.DynamicValue(1, 9999);
        //    this.mMPRange.Base = SourceData.MPRange;
        //    this.mDPRange = new HPMPDPProperty.DynamicValue(1, 9999);
        //    this.mDPRange.Base = SourceData.DPRange;
        //}

        //		public event Action<int> OnChangeHP;

        //		// Token: 0x14000017 RID: 23
        //		// (add) Token: 0x06002F69 RID: 12137 RVA: 0x0015C524 File Offset: 0x0015A724
        //		// (remove) Token: 0x06002F6A RID: 12138 RVA: 0x0015C540 File Offset: 0x0015A740
        //		public event Action<int> OnChangeMP;

        //		// Token: 0x14000018 RID: 24
        //		// (add) Token: 0x06002F6B RID: 12139 RVA: 0x0015C55C File Offset: 0x0015A75C
        //		// (remove) Token: 0x06002F6C RID: 12140 RVA: 0x0015C578 File Offset: 0x0015A778
        //		public event Action<int> OnChangeDP;

        //		// Token: 0x14000019 RID: 25
        //		// (add) Token: 0x06002F6D RID: 12141 RVA: 0x0015C594 File Offset: 0x0015A794
        //		// (remove) Token: 0x06002F6E RID: 12142 RVA: 0x0015C5B0 File Offset: 0x0015A7B0
        //		public event Action OnUnLink;

        //public HPMPDPProperty.DynamicValue HPRange
        //{
        //    get
        //    {
        //        return this.mHPRange;
        //    }
        //}

        //		// Token: 0x17000311 RID: 785
        //		// (get) Token: 0x06002F70 RID: 12144 RVA: 0x0015C5D4 File Offset: 0x0015A7D4
        //		public HPMPDPProperty.DynamicValue MPRange
        //		{
        //			get
        //			{
        //				return this.mMPRange;
        //			}
        //		}

        //		// Token: 0x17000312 RID: 786
        //		// (get) Token: 0x06002F71 RID: 12145 RVA: 0x0015C5DC File Offset: 0x0015A7DC
        //		public HPMPDPProperty.DynamicValue DPRange
        //		{
        //			get
        //			{
        //				return this.mDPRange;
        //			}
        //		}

        //		// Token: 0x06002F72 RID: 12146 RVA: 0x0015C5E4 File Offset: 0x0015A7E4
        //		private void ReCalculateBase_HPRange(int oldValue)
        //		{
        //			this.ReCalculateBase_HPRange((float)oldValue);
        //		}

        //		// Token: 0x06002F73 RID: 12147 RVA: 0x0015C5F0 File Offset: 0x0015A7F0
        //		private void ReCalculateBase_HPRange(float oldValue)
        //		{
        //			if (this.mLinkPlayerBase != null)
        //			{
        //				this.mHPRange.ByCalculate = (int)(this.mLinkPlayerBase.Stamina * 1830f / 193f + 170f);
        //			}
        //			else
        //			{
        //				this.mHPRange.ByCalculate = 0;
        //			}
        //			if (this.mHPRange < this.mHP)
        //			{
        //				int obj = this.mHP;
        //				this.mHP = this.mHPRange;
        //				if (this.OnChangeHP != null)
        //				{
        //					this.OnChangeHP(obj);
        //				}
        //			}
        //		}

        //		// Token: 0x17000313 RID: 787
        //		// (set) Token: 0x06002F74 RID: 12148 RVA: 0x0015C68C File Offset: 0x0015A88C
        //		public PlayerBaseProperty LinkPlayerBase
        //		{
        //			set
        //			{
        //				if (this.mLinkPlayerBase == value)
        //				{
        //					return;
        //				}
        //				if (this.mLinkPlayerBase != null)
        //				{
        //					this.mLinkPlayerBase.Stamina.OnChangeValue -= this.ReCalculateBase_HPRange;
        //				}
        //				this.mLinkPlayerBase = value;
        //				if (this.mLinkPlayerBase != null)
        //				{
        //					this.mLinkPlayerBase.Stamina.OnChangeValue += this.ReCalculateBase_HPRange;
        //				}
        //				this.ReCalculateBase_HPRange(this.mHPRange);
        //			}
        //		}

        //		// Token: 0x17000314 RID: 788
        //		// (get) Token: 0x06002F75 RID: 12149 RVA: 0x0015C70C File Offset: 0x0015A90C
        //		// (set) Token: 0x06002F76 RID: 12150 RVA: 0x0015C714 File Offset: 0x0015A914
        //		public int HP
        //		{
        //			get
        //			{
        //				return this.mHP;
        //			}
        //			set
        //			{
        //				if (value == this.mHP)
        //				{
        //					return;
        //				}
        //				int obj = this.mHP;
        //				if (value < 0)
        //				{
        //					this.mHP = 0;
        //				}
        //				else if (value > this.mHPRange)
        //				{
        //					this.mHP = this.mHPRange;
        //				}
        //				else
        //				{
        //					this.mHP = value;
        //				}
        //				if (this.OnChangeHP != null)
        //				{
        //					this.OnChangeHP(obj);
        //				}
        //			}
        //		}

        //		// Token: 0x17000315 RID: 789
        //		// (get) Token: 0x06002F77 RID: 12151 RVA: 0x0015C790 File Offset: 0x0015A990
        //		// (set) Token: 0x06002F78 RID: 12152 RVA: 0x0015C798 File Offset: 0x0015A998
        //		public int MP
        //		{
        //			get
        //			{
        //				return this.mMP;
        //			}
        //			set
        //			{
        //				if (value == this.mMP)
        //				{
        //					return;
        //				}
        //				int obj = this.mMP;
        //				if (value < 0)
        //				{
        //					this.mMP = 0;
        //				}
        //				else if (value > this.mMPRange)
        //				{
        //					this.mMP = this.mMPRange;
        //				}
        //				else
        //				{
        //					this.mMP = value;
        //				}
        //				if (this.OnChangeMP != null)
        //				{
        //					this.OnChangeMP(obj);
        //				}
        //			}
        //		}

        //		// Token: 0x17000316 RID: 790
        //		// (get) Token: 0x06002F79 RID: 12153 RVA: 0x0015C814 File Offset: 0x0015AA14
        //		// (set) Token: 0x06002F7A RID: 12154 RVA: 0x0015C81C File Offset: 0x0015AA1C
        //		public int DP
        //		{
        //			get
        //			{
        //				return this.mDP;
        //			}
        //			set
        //			{
        //				if (value == this.mDP)
        //				{
        //					return;
        //				}
        //				int obj = this.mDP;
        //				if (value < 0)
        //				{
        //					this.mDP = 0;
        //				}
        //				else if (value > this.mDPRange)
        //				{
        //					this.mDP = this.mDPRange;
        //				}
        //				else
        //				{
        //					this.mDP = value;
        //				}
        //				if (this.OnChangeDP != null)
        //				{
        //					this.OnChangeDP(obj);
        //				}
        //			}
        //		}

        //		// Token: 0x06002F7B RID: 12155 RVA: 0x0015C898 File Offset: 0x0015AA98
        //		public void SetWithoutEvents(int newHP, int newMP, int newDP)
        //		{
        //			this.mHP = newHP;
        //			this.mMP = newMP;
        //			this.mDP = newDP;
        //		}

        //		// Token: 0x06002F7C RID: 12156 RVA: 0x0015C8B0 File Offset: 0x0015AAB0
        //		public void UnLink()
        //		{
        //			this.LinkPlayerBase = null;
        //			if (this.OnUnLink != null)
        //			{
        //				this.OnUnLink();
        //			}
        //		}

        //		// Token: 0x06002F7D RID: 12157 RVA: 0x0015C8D0 File Offset: 0x0015AAD0
        //		~HPMPDPProperty()
        //		{
        //			this.UnLink();
        //		}

        //public class DynamicValue : DynamicInt32
        //{
        //    private int mBase;

        //    private int mByCalculate;

        //    public DynamicValue(int inMinValue, int inMaxValue) : base(inMinValue, inMaxValue)
        //    {
        //    }

        //    public int Base
        //    {
        //        get
        //        {
        //            return this.mBase;
        //        }
        //        set
        //        {
        //            this.mBase = value;
        //            this.Calculate();
        //        }
        //    }

        //    public int ByCalculate
        //    {
        //        get
        //        {
        //            return this.mByCalculate;
        //        }
        //        set
        //        {
        //            this.mByCalculate = value;
        //            this.Calculate();
        //        }
        //    }

        //    public override void Calculate()
        //    {
        //        int result = this.result;
        //        this.result = (int)((float)(this.mBase + this.mByCalculate + this.mAdd) * this.mScale);
        //        if (this.result < this.mMinValue)
        //        {
        //            this.mIsOverdraw = true;
        //            this.result = this.mMinValue;
        //        }
        //        else if (this.result > this.mMaxValue)
        //        {
        //            this.result = this.mMaxValue;
        //        }
        //        if (result != this.result)
        //        {
        //            base.ChangeValue(result);
        //        }
        //    }
        //}

        public class StaticData
        {
            public static readonly string DefaultDataPath = Path.Combine(Application.dataPath, "Data/Property/HPMPDP.dat");

            private int mHPRange;

            private int mMPRange;

            private int mDPRange;

            private static string[] mDataPaths = null;

            private static Dictionary<uint, HPMPDPProperty.StaticData> Datas = null;

            public StaticData(out uint Key, BinaryReader DataReader)
            {
                Key = DataReader.ReadUInt32();
                this.mHPRange = DataReader.ReadInt32();
                this.mMPRange = DataReader.ReadInt32();
                this.mDPRange = DataReader.ReadInt32();
            }

            //			// Token: 0x17000319 RID: 793
            //			// (get) Token: 0x06002F86 RID: 12166 RVA: 0x0015CA48 File Offset: 0x0015AC48
            //			public int HPRange
            //			{
            //				get
            //				{
            //					return this.mHPRange;
            //				}
            //			}

            //			// Token: 0x1700031A RID: 794
            //			// (get) Token: 0x06002F87 RID: 12167 RVA: 0x0015CA50 File Offset: 0x0015AC50
            //			public int MPRange
            //			{
            //				get
            //				{
            //					return this.mMPRange;
            //				}
            //			}

            //			// Token: 0x1700031B RID: 795
            //			// (get) Token: 0x06002F88 RID: 12168 RVA: 0x0015CA58 File Offset: 0x0015AC58
            //			public int DPRange
            //			{
            //				get
            //				{
            //					return this.mDPRange;
            //				}
            //			}

            //			// Token: 0x1700031C RID: 796
            //			// (get) Token: 0x06002F89 RID: 12169 RVA: 0x0015CA60 File Offset: 0x0015AC60
            //			public static string[] DataPaths
            //			{
            //				get
            //				{
            //					if (HPMPDPProperty.StaticData.mDataPaths == null)
            //					{
            //						string str = "." + PalMain.GameDifficulty.ToString();
            //						List<string> list = new List<string>();
            //						list.Add(HPMPDPProperty.StaticData.DefaultDataPath + str);
            //						string path = HPMPDPProperty.StaticData.DefaultDataPath + ".list";
            //						if (File.Exists(path))
            //						{
            //							using (StreamReader streamReader = new StreamReader(path, Encoding.UTF8, true))
            //							{
            //								do
            //								{
            //									string text = streamReader.ReadLine() + str;
            //									if (File.Exists(text))
            //									{
            //										list.Add(text);
            //									}
            //								}
            //								while (streamReader.EndOfStream);
            //							}
            //						}
            //						HPMPDPProperty.StaticData.mDataPaths = list.ToArray();
            //					}
            //					return HPMPDPProperty.StaticData.mDataPaths;
            //				}
            //			}

            //			// Token: 0x06002F8A RID: 12170 RVA: 0x0015CB38 File Offset: 0x0015AD38
            //			public static Dictionary<uint, HPMPDPProperty.StaticData> GetDatasFromFile()
            //			{
            //				if (HPMPDPProperty.StaticData.Datas == null)
            //				{
            //					Dictionary<uint, HPMPDPProperty.StaticData> dictionary = new Dictionary<uint, HPMPDPProperty.StaticData>(65536);
            //					foreach (string text in HPMPDPProperty.StaticData.DataPaths)
            //					{
            //						if (text.ExistFile())
            //						{
            //							using (FileStream fileStream = new FileStream(text, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            //							{
            //								BinaryReader dataReader = new BinaryReader(fileStream);
            //								while (fileStream.Position < fileStream.Length)
            //								{
            //									uint key;
            //									HPMPDPProperty.StaticData value = new HPMPDPProperty.StaticData(ref key, dataReader);
            //									if (!dictionary.ContainsKey(key))
            //									{
            //										dictionary.Add(key, value);
            //									}
            //									else
            //									{
            //										Debug.Log(text + " id conflict : " + key.ToString());
            //									}
            //								}
            //							}
            //						}
            //					}
            //					HPMPDPProperty.StaticData.Datas = dictionary;
            //					return HPMPDPProperty.StaticData.Datas;
            //				}
            //				return HPMPDPProperty.StaticData.Datas;
            //			}

            //			// Token: 0x06002F8B RID: 12171 RVA: 0x0015CC34 File Offset: 0x0015AE34
            //			public static HPMPDPProperty.StaticData GetData(uint id)
            //			{
            //				Dictionary<uint, HPMPDPProperty.StaticData> datasFromFile = HPMPDPProperty.StaticData.GetDatasFromFile();
            //				HPMPDPProperty.StaticData result = null;
            //				datasFromFile.TryGetValue(id, out result);
            //				return result;
            //			}

            public static void Reset()
            {
                HPMPDPProperty.StaticData.mDataPaths = null;
                HPMPDPProperty.StaticData.Datas = null;
            }
        }
    }
}
