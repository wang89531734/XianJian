using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine;

namespace SoftStar.Pal6
{
	public class FightProperty
	{
		public class DynamicValue : DynamicFloat
		{
			private float mBase;

			private float mByCalculate;

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

			public float ByCalculate
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

			public DynamicValue(float inMinValue, float inMaxValue) : base(inMinValue, inMaxValue)
			{
			}

			public override void Calculate()
			{
				float result = this.result;
				this.result = (this.mBase + this.mByCalculate + this.mAdd) * this.mScale;
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

			public override string ToString()
			{
				return this.ToString();
			}
		}

		public enum FieldEnum
		{
			mPhysicsAttack = 1,
			mElementAttack,
			mPhysicsDefend,
			mElementDefend,
			mHitValue,
			mDodgeValue,
			mBlockRate,
			mCritRate,
			mAgility,
			mLuckValue,
			mBlockValue,
			mCritValue,
			mElementsAttack,
			mElementsDefend,
			ATBValue,
			ATBAddSpeedValue,
			SafeRange,
			AttackRange,
			BeAttackRange,
			ChainValue,
			BreakValue,
			BreakKeepTime,
			mElementsBreakRate,
			DamageRate,
			ElementWeak,
			BreakHeight,
			AddATKTime,
			BattleCapsuleRadius,
			BattleCapsuleHeight,
			BattleCapsuleCenterHeight,
			BattleCapsuleCenterX,
			RotateSpeed,
			ShowY,
			ShowRadius,
			BreakMask,
			BreakStateTime,
			BattleAIScript,
			BeHitSound,
			mDeBuffDefends,
			BeHitEffectDistance,
			ShowPhysicsDefend,
			ShowElementDefend
		}

		public class StaticData
		{
			public static readonly string DefaultDataPath = Path.Combine(Application.dataPath, "Data/Property/Fight.dat");

			private float mPhysicsAttack;

			private float mElementAttack;

			private float mPhysicsDefend;

			private float mElementDefend;

			private float mHitValue;

			private float mDodgeValue;

			private float mBlockRate;

			private float mCritRate;

			private float mAgility;

			private float mLuckValue;

			private float mBlockValue;

			private float mCritValue;

			private float[] mElementsAttack;

			private float[] mElementsDefend;

			public readonly float ATBValue;

			public readonly float ATBAddSpeedValue;

			public readonly float SafeRange;

			public readonly float AttackRange;

			public readonly float BeAttackRange;

			public readonly float ChainValue;

			public readonly float BreakValue;

			public readonly float BreakKeepTime;

			private float[] mElementsBreakRate;

			public readonly float DamageRate;

			public readonly ElementPhase ElementWeak;

			public readonly float BreakHeight;

			public readonly float AddATKTime;

			public readonly float BattleCapsuleRadius;

			public readonly float BattleCapsuleHeight;

			public readonly float BattleCapsuleCenterHeight;

			public readonly float BattleCapsuleCenterX;

			public readonly float RotateSpeed;

			public readonly float ShowY;

			public readonly float ShowRadius;

			public readonly uint BreakMask;

			public readonly float BreakStateTime;

			public string BattleAIScript;

			public string BeHitSound;

			private int[] mDeBuffDefends;

			public float BeHitEffectDistance;

			public readonly float ShowPhysicsDefend;

			public readonly float ShowElementDefend;

			private static string[] mDataPaths = null;

			private static Dictionary<uint, FightProperty.StaticData> Datas = null;

			public float PhysicsAttack
			{
				get
				{
					return this.mPhysicsAttack;
				}
			}

			public float ElementAttack
			{
				get
				{
					return this.mElementAttack;
				}
			}

			public float PhysicsDefend
			{
				get
				{
					return this.mPhysicsDefend;
				}
			}

			public float ElementDefend
			{
				get
				{
					return this.mElementDefend;
				}
			}

			public float HitValue
			{
				get
				{
					return this.mHitValue;
				}
			}

			public float DodgeValue
			{
				get
				{
					return this.mDodgeValue;
				}
			}

			public float BlockRate
			{
				get
				{
					return this.mBlockRate;
				}
			}

			public float CritRate
			{
				get
				{
					return this.mCritRate;
				}
			}

			public float Agility
			{
				get
				{
					return this.mAgility;
				}
			}

			public float LuckValue
			{
				get
				{
					return this.mLuckValue;
				}
			}

			public float BlockValue
			{
				get
				{
					return this.mBlockValue;
				}
			}

			public float CritValue
			{
				get
				{
					return this.mCritValue;
				}
			}

			public float[] ElementsAttack
			{
				get
				{
					return this.mElementsAttack;
				}
			}

			public float[] ElementsDefend
			{
				get
				{
					return this.mElementsDefend;
				}
			}

			public float[] ElementsBreakRate
			{
				get
				{
					return this.mElementsBreakRate;
				}
			}

			public int[] DeBuffDefends
			{
				get
				{
					return this.mDeBuffDefends;
				}
			}

			public static string[] DataPaths
			{
				get
				{
					if (FightProperty.StaticData.mDataPaths == null)
					{
						string str = "." + PalMain.GameDifficulty.ToString();
						List<string> list = new List<string>();
						list.Add(FightProperty.StaticData.DefaultDataPath + str);
						string path = FightProperty.StaticData.DefaultDataPath + ".list";
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
						FightProperty.StaticData.mDataPaths = list.ToArray();
					}
					return FightProperty.StaticData.mDataPaths;
				}
			}

			public StaticData(out uint Key, BinaryReader DataReader)
			{
				Key = DataReader.ReadUInt32();
				this.mPhysicsAttack = DataReader.ReadSingle();
				this.mElementAttack = DataReader.ReadSingle();
				this.mPhysicsDefend = DataReader.ReadSingle();
				this.mElementDefend = DataReader.ReadSingle();
				this.mHitValue = DataReader.ReadSingle();
				this.mDodgeValue = DataReader.ReadSingle();
				this.mBlockRate = DataReader.ReadSingle();
				this.mCritRate = DataReader.ReadSingle();
				this.mAgility = DataReader.ReadSingle();
				this.mLuckValue = DataReader.ReadSingle();
				this.mBlockValue = DataReader.ReadSingle();
				this.mCritValue = DataReader.ReadSingle();
				this.mElementsAttack = new float[8];
				for (int i = 0; i < this.mElementsAttack.Length; i++)
				{
					this.mElementsAttack[i] = DataReader.ReadSingle();
				}
				this.mElementsDefend = new float[8];
				for (int j = 0; j < this.mElementsDefend.Length; j++)
				{
					this.mElementsDefend[j] = DataReader.ReadSingle();
				}
				this.ATBValue = DataReader.ReadSingle();
				this.ATBAddSpeedValue = DataReader.ReadSingle();
				this.SafeRange = DataReader.ReadSingle();
				this.AttackRange = DataReader.ReadSingle();
				this.BeAttackRange = DataReader.ReadSingle();
				this.ChainValue = DataReader.ReadSingle();
				this.BreakValue = DataReader.ReadSingle();
				this.BreakKeepTime = DataReader.ReadSingle();
				this.mElementsBreakRate = new float[8];
				for (int k = 0; k < this.mElementsBreakRate.Length; k++)
				{
					this.mElementsBreakRate[k] = DataReader.ReadSingle();
				}
				this.DamageRate = DataReader.ReadSingle();
				this.ElementWeak = (ElementPhase)DataReader.ReadByte();
				this.BreakHeight = DataReader.ReadSingle();
				this.AddATKTime = DataReader.ReadSingle();
				this.BattleCapsuleRadius = DataReader.ReadSingle();
				this.BattleCapsuleHeight = DataReader.ReadSingle();
				this.BattleCapsuleCenterHeight = DataReader.ReadSingle();
				this.BattleCapsuleCenterX = DataReader.ReadSingle();
				this.RotateSpeed = DataReader.ReadSingle();
				this.ShowY = DataReader.ReadSingle();
				this.ShowRadius = DataReader.ReadSingle();
				this.BreakMask = DataReader.ReadUInt32();
				this.BreakStateTime = DataReader.ReadSingle();
				this.BattleAIScript = DataReader.ReadString();
				this.BeHitSound = DataReader.ReadString();
				this.mDeBuffDefends = new int[DataReader.ReadInt32()];
				for (int l = 0; l < this.mDeBuffDefends.Length; l++)
				{
					this.mDeBuffDefends[l] = DataReader.ReadInt32();
				}
				this.BeHitEffectDistance = DataReader.ReadSingle();
				this.ShowPhysicsDefend = DataReader.ReadSingle();
				this.ShowElementDefend = DataReader.ReadSingle();
			}

			public static Dictionary<uint, FightProperty.StaticData> GetDatasFromFile()
			{
				if (FightProperty.StaticData.Datas == null)
				{
					Dictionary<uint, FightProperty.StaticData> dictionary = new Dictionary<uint, FightProperty.StaticData>(65536);
					string[] dataPaths = FightProperty.StaticData.DataPaths;
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
									FightProperty.StaticData value = new FightProperty.StaticData(out key, dataReader);
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
					FightProperty.StaticData.Datas = dictionary;
					return FightProperty.StaticData.Datas;
				}
				return FightProperty.StaticData.Datas;
			}

			public static FightProperty.StaticData GetData(uint id)
			{
				Dictionary<uint, FightProperty.StaticData> datasFromFile = FightProperty.StaticData.GetDatasFromFile();
				FightProperty.StaticData result = null;
				datasFromFile.TryGetValue(id, out result);
				return result;
			}

			public static void Reset()
			{
				FightProperty.StaticData.mDataPaths = null;
				FightProperty.StaticData.Datas = null;
			}
		}

		private FightProperty.DynamicValue mPhysicsAttack;

		private FightProperty.DynamicValue mElementAttack;

		private FightProperty.DynamicValue mPhysicsDefend;

		private FightProperty.DynamicValue mElementDefend;

		private FightProperty.DynamicValue mHitValue;

		private FightProperty.DynamicValue mDodgeValue;

		private FightProperty.DynamicValue mBlockRate;

		private FightProperty.DynamicValue mCritRate;

		private FightProperty.DynamicValue mAgility;

		private FightProperty.DynamicValue mLuckValue;

		private FightProperty.DynamicValue mBlockValue;

		private FightProperty.DynamicValue mCritValue;

		private DynamicFloat[] mElementsAttack;

		private DynamicFloat[] mElementsDefend;

		public readonly float ATBValue;

		public readonly float ATBAddSpeedValue;

		public readonly float SafeRange;

		public readonly float AttackRange;

		public readonly float BeAttackRange;

		public readonly float ChainValue;

		public readonly float BreakValue;

		public readonly float BreakKeepTime;

		private DynamicFloat[] mElementsBreakRate;

		public readonly float DamageRate;

		public readonly ElementPhase ElementWeak;

		public readonly float BreakHeight;

		public readonly float AddATKTime;

		public readonly float BattleCapsuleRadius;

		public readonly float BattleCapsuleHeight;

		public readonly float BattleCapsuleCenterHeight;

		public readonly float BattleCapsuleCenterX;

		public readonly float RotateSpeed;

		public readonly float ShowY;

		public readonly float ShowRadius;

		public readonly uint BreakMask;

		public readonly float BreakStateTime;

		public string BattleAIScript;

		public string BeHitSound;

		private DynamicInt32[] mDeBuffDefends;

		public float BeHitEffectDistance;

		public readonly float ShowPhysicsDefend;

		public readonly float ShowElementDefend;

		private PlayerBaseProperty mLinkPlayerBase;

        public event Action OnUnLink;

		public FightProperty.DynamicValue PhysicsAttack
		{
			get
			{
				return this.mPhysicsAttack;
			}
		}

		public FightProperty.DynamicValue ElementAttack
		{
			get
			{
				return this.mElementAttack;
			}
		}

		public FightProperty.DynamicValue PhysicsDefend
		{
			get
			{
				return this.mPhysicsDefend;
			}
		}

		public FightProperty.DynamicValue ElementDefend
		{
			get
			{
				return this.mElementDefend;
			}
		}

		public FightProperty.DynamicValue HitValue
		{
			get
			{
				return this.mHitValue;
			}
		}

		public FightProperty.DynamicValue DodgeValue
		{
			get
			{
				return this.mDodgeValue;
			}
		}

		public FightProperty.DynamicValue BlockRate
		{
			get
			{
				return this.mBlockRate;
			}
		}

		public FightProperty.DynamicValue CritRate
		{
			get
			{
				return this.mCritRate;
			}
		}

		public FightProperty.DynamicValue Agility
		{
			get
			{
				return this.mAgility;
			}
		}

		public FightProperty.DynamicValue LuckValue
		{
			get
			{
				return this.mLuckValue;
			}
		}

		public FightProperty.DynamicValue BlockValue
		{
			get
			{
				return this.mBlockValue;
			}
		}

		public FightProperty.DynamicValue CritValue
		{
			get
			{
				return this.mCritValue;
			}
		}

		public DynamicFloat[] ElementsAttack
		{
			get
			{
				return this.mElementsAttack;
			}
		}

		public DynamicFloat[] ElementsDefend
		{
			get
			{
				return this.mElementsDefend;
			}
		}

		public DynamicFloat[] ElementsBreakRate
		{
			get
			{
				return this.mElementsBreakRate;
			}
		}

		public DynamicInt32[] DeBuffDefends
		{
			get
			{
				return this.mDeBuffDefends;
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
					//this.mLinkPlayerBase.Strength.OnChangeValue -= new Action<float>(this.PhysicsAttack_ByCalculate);
					//this.mLinkPlayerBase.Strength.OnChangeValue -= new Action<float>(this.PhysicsDefend_ByCalculate);
					//this.mLinkPlayerBase.Strength.OnChangeValue -= new Action<float>(this.BlockValue_ByCalculate);
					//this.mLinkPlayerBase.Stamina.OnChangeValue -= new Action<float>(this.PhysicsDefend_ByCalculate);
					//this.mLinkPlayerBase.Stamina.OnChangeValue -= new Action<float>(this.ElementDefend_ByCalculate);
					//this.mLinkPlayerBase.Speed.OnChangeValue -= new Action<float>(this.Agility_ByCalculate);
					//this.mLinkPlayerBase.Luck.OnChangeValue -= new Action<float>(this.LuckValue_ByCalculate);
					//this.mLinkPlayerBase.Magic.OnChangeValue -= new Action<float>(this.ElementAttack_ByCalculate);
					//this.mLinkPlayerBase.Magic.OnChangeValue -= new Action<float>(this.ElementDefend_ByCalculate);
				}
				this.mLinkPlayerBase = value;
				if (this.mLinkPlayerBase != null)
				{
					//this.mLinkPlayerBase.Strength.OnChangeValue += new Action<float>(this.PhysicsAttack_ByCalculate);
					//this.mLinkPlayerBase.Strength.OnChangeValue += new Action<float>(this.PhysicsDefend_ByCalculate);
					//this.mLinkPlayerBase.Strength.OnChangeValue += new Action<float>(this.BlockValue_ByCalculate);
					//this.mLinkPlayerBase.Stamina.OnChangeValue += new Action<float>(this.PhysicsDefend_ByCalculate);
					//this.mLinkPlayerBase.Stamina.OnChangeValue += new Action<float>(this.ElementDefend_ByCalculate);
					//this.mLinkPlayerBase.Speed.OnChangeValue += new Action<float>(this.Agility_ByCalculate);
					//this.mLinkPlayerBase.Luck.OnChangeValue += new Action<float>(this.LuckValue_ByCalculate);
					//this.mLinkPlayerBase.Magic.OnChangeValue += new Action<float>(this.ElementAttack_ByCalculate);
					//this.mLinkPlayerBase.Magic.OnChangeValue += new Action<float>(this.ElementDefend_ByCalculate);
				}
				this.ReCalculateAll();
			}
		}

		public FightProperty(FightProperty.StaticData SourceData)
		{
			this.mPhysicsAttack = new FightProperty.DynamicValue(0f, 9999f);
			this.mPhysicsAttack.Base = SourceData.PhysicsAttack;
			this.mElementAttack = new FightProperty.DynamicValue(0f, 9999f);
			this.mElementAttack.Base = SourceData.ElementAttack;
			this.mPhysicsDefend = new FightProperty.DynamicValue(0f, 9999f);
			this.mPhysicsDefend.Base = SourceData.PhysicsDefend;
			this.mElementDefend = new FightProperty.DynamicValue(0f, 9999f);
			this.mElementDefend.Base = SourceData.ElementDefend;
			this.mHitValue = new FightProperty.DynamicValue(0f, 999f);
			this.mHitValue.Base = SourceData.HitValue;
			this.mDodgeValue = new FightProperty.DynamicValue(0f, 999f);
			this.mDodgeValue.Base = SourceData.DodgeValue;
			this.mBlockRate = new FightProperty.DynamicValue(0f, 1f);
			this.mBlockRate.Base = SourceData.BlockRate;
			this.mCritRate = new FightProperty.DynamicValue(0f, 1f);
			this.mCritRate.Base = SourceData.CritRate;
			this.mAgility = new FightProperty.DynamicValue(0f, 3370.171f);
			this.mAgility.Base = SourceData.Agility;
			this.mLuckValue = new FightProperty.DynamicValue(0f, 9999f);
			this.mLuckValue.Base = SourceData.LuckValue;
			this.mBlockValue = new FightProperty.DynamicValue(0f, 999f);
			this.mBlockValue.Base = SourceData.BlockValue;
			this.mCritValue = new FightProperty.DynamicValue(0f, 999f);
			this.mCritValue.Base = SourceData.CritValue;
			this.mElementsAttack = new DynamicFloat[SourceData.ElementsAttack.Length];
			for (int i = 0; i < this.mElementsAttack.Length; i++)
			{
				this.mElementsAttack[i] = new DynamicFloat(0f, 99999f);
				this.mElementsAttack[i].SetAdd(SourceData.ElementsAttack[i]);
			}
			this.mElementsDefend = new DynamicFloat[SourceData.ElementsDefend.Length];
			for (int j = 0; j < this.mElementsDefend.Length; j++)
			{
				this.mElementsDefend[j] = new DynamicFloat(0f, 99999f);
				this.mElementsDefend[j].SetAdd(SourceData.ElementsDefend[j]);
			}
			this.ATBValue = SourceData.ATBValue;
			this.ATBAddSpeedValue = SourceData.ATBAddSpeedValue;
			this.SafeRange = SourceData.SafeRange;
			this.AttackRange = SourceData.AttackRange;
			this.BeAttackRange = SourceData.BeAttackRange;
			this.ChainValue = SourceData.ChainValue;
			this.BreakValue = SourceData.BreakValue;
			this.BreakKeepTime = SourceData.BreakKeepTime;
			this.mElementsBreakRate = new DynamicFloat[SourceData.ElementsBreakRate.Length];
			for (int k = 0; k < this.mElementsBreakRate.Length; k++)
			{
				this.mElementsBreakRate[k] = new DynamicFloat(0f, 99999f);
				this.mElementsBreakRate[k].SetAdd(SourceData.ElementsBreakRate[k]);
			}
			this.DamageRate = SourceData.DamageRate;
			this.ElementWeak = SourceData.ElementWeak;
			this.BreakHeight = SourceData.BreakHeight;
			this.AddATKTime = SourceData.AddATKTime;
			this.BattleCapsuleRadius = SourceData.BattleCapsuleRadius;
			this.BattleCapsuleHeight = SourceData.BattleCapsuleHeight;
			this.BattleCapsuleCenterHeight = SourceData.BattleCapsuleCenterHeight;
			this.BattleCapsuleCenterX = SourceData.BattleCapsuleCenterX;
			this.RotateSpeed = SourceData.RotateSpeed;
			this.ShowY = SourceData.ShowY;
			this.ShowRadius = SourceData.ShowRadius;
			this.BreakMask = SourceData.BreakMask;
			this.BreakStateTime = SourceData.BreakStateTime;
			this.BattleAIScript = SourceData.BattleAIScript;
			this.BeHitSound = SourceData.BeHitSound;
			this.mDeBuffDefends = new DynamicInt32[SourceData.DeBuffDefends.Length];
			for (int l = 0; l < this.mDeBuffDefends.Length; l++)
			{
				this.mDeBuffDefends[l] = new DynamicInt32(0, 100);
				this.mDeBuffDefends[l].SetAdd(SourceData.DeBuffDefends[l]);
			}
			this.BeHitEffectDistance = SourceData.BeHitEffectDistance;
			this.ShowPhysicsDefend = SourceData.ShowPhysicsDefend;
			this.ShowElementDefend = SourceData.ShowElementDefend;
			this.LuckValue.OnChangeValue -= new Action<float>(this.CritValue_ByCalculate);
			this.LuckValue.OnChangeValue += new Action<float>(this.CritValue_ByCalculate);
			this.LuckValue.OnChangeValue -= new Action<float>(this.DodgeValue_ByCalculate);
			this.LuckValue.OnChangeValue += new Action<float>(this.DodgeValue_ByCalculate);
			this.Agility.OnChangeValue -= new Action<float>(this.HitValue_ByCalculate);
			this.Agility.OnChangeValue += new Action<float>(this.HitValue_ByCalculate);
			this.BlockValue.OnChangeValue -= new Action<float>(this.BlockRate_ByCalculate);
			this.BlockValue.OnChangeValue += new Action<float>(this.BlockRate_ByCalculate);
			this.CritValue.OnChangeValue -= new Action<float>(this.CritRate_ByCalculate);
			this.CritValue.OnChangeValue += new Action<float>(this.CritRate_ByCalculate);
		}

		public void PhysicsAttack_ByCalculate(float oldValue)
		{
			if (this.mLinkPlayerBase != null)
			{
				//this.mPhysicsAttack.ByCalculate = this.mLinkPlayerBase.Strength * 90f / 19f;
			}
			else
			{
				this.mPhysicsAttack.ByCalculate = 0f;
			}
		}

		public void ElementAttack_ByCalculate(float oldValue)
		{
			if (this.mLinkPlayerBase != null)
			{
				//this.mElementAttack.ByCalculate = this.mLinkPlayerBase.Magic * 90f / 19f;
			}
			else
			{
				this.mElementAttack.ByCalculate = 0f;
			}
		}

		public void PhysicsDefend_ByCalculate(float oldValue)
		{
			if (this.mLinkPlayerBase != null)
			{
				//this.mPhysicsDefend.ByCalculate = 3.31578946f * this.mLinkPlayerBase.Strength + 1.42105258f * this.mLinkPlayerBase.Stamina;
			}
			else
			{
				this.mPhysicsDefend.ByCalculate = 0f;
			}
		}

		public void ElementDefend_ByCalculate(float oldValue)
		{
			if (this.mLinkPlayerBase != null)
			{
				//this.mElementDefend.ByCalculate = 3.31578946f * this.mLinkPlayerBase.Magic + 1.42105258f * this.mLinkPlayerBase.Stamina;
			}
			else
			{
				this.mElementDefend.ByCalculate = 0f;
			}
		}

		public void HitValue_ByCalculate(float oldValue)
		{
			this.mHitValue.ByCalculate = this.mAgility * 90f / 900f + 9f;
		}

		public void DodgeValue_ByCalculate(float oldValue)
		{
			this.mDodgeValue.ByCalculate = this.mLuckValue * 90f / 900f + 8f;
		}

		public void BlockRate_ByCalculate(float oldValue)
		{
			this.mBlockRate.ByCalculate = (this.mBlockValue * 11f * 0.01f + 9f) * 0.01f;
		}

		public void CritRate_ByCalculate(float oldValue)
		{
			this.mCritRate.ByCalculate = (this.mCritValue * 33f * 0.01f + 7f) * 0.01f;
		}

		public void Agility_ByCalculate(float oldValue)
		{
			if (this.mLinkPlayerBase != null)
			{
				//this.mAgility.ByCalculate = this.mLinkPlayerBase.Speed * 90f / 19f;
			}
			else
			{
				this.mAgility.ByCalculate = 0f;
			}
		}

		public void LuckValue_ByCalculate(float oldValue)
		{
			if (this.mLinkPlayerBase != null)
			{
				//this.mLuckValue.ByCalculate = this.mLinkPlayerBase.Luck * 90f / 19f + 7f;
			}
			else
			{
				this.mLuckValue.ByCalculate = 0f;
			}
		}

		public void BlockValue_ByCalculate(float oldValue)
		{
			if (this.mLinkPlayerBase != null)
			{
				//this.mBlockValue.ByCalculate = this.mLinkPlayerBase.Strength * 90f / 190f + 9f;
			}
			else
			{
				this.mBlockValue.ByCalculate = 0f;
			}
		}

		public void CritValue_ByCalculate(float oldValue)
		{
			this.mCritValue.ByCalculate = this.mLuckValue * 90f / 900f + 9.5f;
		}

		public void ReCalculateAll()
		{
			this.Agility_ByCalculate(this.mAgility);
			this.LuckValue_ByCalculate(this.mLuckValue);
			this.PhysicsAttack_ByCalculate(this.mPhysicsAttack);
			this.ElementAttack_ByCalculate(this.mElementAttack);
			this.PhysicsDefend_ByCalculate(this.mPhysicsDefend);
			this.ElementDefend_ByCalculate(this.mElementDefend);
			this.HitValue_ByCalculate(this.mHitValue);
			this.DodgeValue_ByCalculate(this.mDodgeValue);
			this.BlockRate_ByCalculate(this.mBlockRate);
			this.CritRate_ByCalculate(this.mCritRate);
			this.BlockValue_ByCalculate(this.mBlockValue);
			this.CritValue_ByCalculate(this.mCritValue);
		}

		public void UnLink()
		{
			this.LinkPlayerBase = null;
			if (this.OnUnLink != null)
			{
				this.OnUnLink();
			}
		}

		//public int GetDeBuffDefendValue(StatusDataManager.STATUS_TYPE_ENUM epos)
		//{
		//	if (epos < StatusDataManager.STATUS_TYPE_ENUM.TYPE_NULL || epos >= (StatusDataManager.STATUS_TYPE_ENUM)this.DeBuffDefends.Length || this.DeBuffDefends[(int)epos] == null)
		//	{
		//		return 0;
		//	}
		//	return this.DeBuffDefends[(int)epos];
		//}

		//public static int GetDeBuffDefendValue(int[] source, StatusDataManager.STATUS_TYPE_ENUM epos)
		//{
		//	if (epos < StatusDataManager.STATUS_TYPE_ENUM.TYPE_NULL || epos >= (StatusDataManager.STATUS_TYPE_ENUM)source.Length)
		//	{
		//		return 0;
		//	}
		//	return source[(int)epos];
		//}

		public void AddDeBuffDefendValue(int[] v)
		{
			if (v == null)
			{
				return;
			}
			if (this.DeBuffDefends.Length < v.Length)
			{
				DynamicInt32[] array = this.mDeBuffDefends;
				this.mDeBuffDefends = new DynamicInt32[v.Length];
				Array.Copy(array, 0, this.mDeBuffDefends, 0, array.Length);
				for (int i = 0; i < this.mDeBuffDefends.Length; i++)
				{
					if (this.mDeBuffDefends[i] == null)
					{
						this.mDeBuffDefends[i] = new DynamicInt32(0, 100);
					}
				}
			}
			for (int j = 0; j < v.Length; j++)
			{
				this.DeBuffDefends[j].ChangeAdd(v[j]);
			}
		}

		public void ReduceDeBuffDefendValue(int[] v)
		{
			if (v == null)
			{
				return;
			}
			if (this.DeBuffDefends.Length < v.Length)
			{
				DynamicInt32[] array = this.mDeBuffDefends;
				this.mDeBuffDefends = new DynamicInt32[v.Length];
				Array.Copy(array, 0, this.mDeBuffDefends, 0, array.Length);
				for (int i = 0; i < this.mDeBuffDefends.Length; i++)
				{
					if (this.mDeBuffDefends[i] == null)
					{
						this.mDeBuffDefends[i] = new DynamicInt32(0, 100);
					}
				}
			}
			for (int j = 0; j < v.Length; j++)
			{
				this.DeBuffDefends[j].ChangeAdd(-v[j]);
			}
		}

		~FightProperty()
		{
			this.UnLink();
		}
	}
}
