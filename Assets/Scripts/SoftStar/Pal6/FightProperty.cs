using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

namespace SoftStar.Pal6
{
    /// <summary>
    /// ’Ω∂∑ Ù–‘
    /// </summary>
    public class FightProperty
    {

        //        // Token: 0x04002A57 RID: 10839
        //        private FightProperty.DynamicValue mPhysicsAttack;

        //        // Token: 0x04002A58 RID: 10840
        //        private FightProperty.DynamicValue mElementAttack;

        //        // Token: 0x04002A59 RID: 10841
        //        private FightProperty.DynamicValue mPhysicsDefend;

        //        // Token: 0x04002A5A RID: 10842
        //        private FightProperty.DynamicValue mElementDefend;

        //        // Token: 0x04002A5B RID: 10843
        //        private FightProperty.DynamicValue mHitValue;

        //        // Token: 0x04002A5C RID: 10844
        //        private FightProperty.DynamicValue mDodgeValue;

        //        // Token: 0x04002A5D RID: 10845
        //        private FightProperty.DynamicValue mBlockRate;

        //        // Token: 0x04002A5E RID: 10846
        //        private FightProperty.DynamicValue mCritRate;

        //        // Token: 0x04002A5F RID: 10847
        //        private FightProperty.DynamicValue mAgility;

        //        // Token: 0x04002A60 RID: 10848
        //        private FightProperty.DynamicValue mLuckValue;

        //        // Token: 0x04002A61 RID: 10849
        //        private FightProperty.DynamicValue mBlockValue;

        //        // Token: 0x04002A62 RID: 10850
        //        private FightProperty.DynamicValue mCritValue;

        //        // Token: 0x04002A63 RID: 10851
        //        private DynamicFloat[] mElementsAttack;

        //        // Token: 0x04002A64 RID: 10852
        //        private DynamicFloat[] mElementsDefend;

        //        // Token: 0x04002A65 RID: 10853
        //        public readonly float ATBValue;

        //        // Token: 0x04002A66 RID: 10854
        //        public readonly float ATBAddSpeedValue;

        //        // Token: 0x04002A67 RID: 10855
        //        public readonly float SafeRange;

        //        // Token: 0x04002A68 RID: 10856
        //        public readonly float AttackRange;

        //        // Token: 0x04002A69 RID: 10857
        //        public readonly float BeAttackRange;

        //        // Token: 0x04002A6A RID: 10858
        //        public readonly float ChainValue;

        //        // Token: 0x04002A6B RID: 10859
        //        public readonly float BreakValue;

        //        // Token: 0x04002A6C RID: 10860
        //        public readonly float BreakKeepTime;

        //        // Token: 0x04002A6D RID: 10861
        //        private DynamicFloat[] mElementsBreakRate;

        //        // Token: 0x04002A6E RID: 10862
        //        public readonly float DamageRate;

        //        // Token: 0x04002A6F RID: 10863
        //        public readonly ElementPhase ElementWeak;

        //        // Token: 0x04002A70 RID: 10864
        //        public readonly float BreakHeight;

        //        // Token: 0x04002A71 RID: 10865
        //        public readonly float AddATKTime;

        //        // Token: 0x04002A72 RID: 10866
        //        public readonly float BattleCapsuleRadius;

        //        // Token: 0x04002A73 RID: 10867
        //        public readonly float BattleCapsuleHeight;

        //        // Token: 0x04002A74 RID: 10868
        //        public readonly float BattleCapsuleCenterHeight;

        //        // Token: 0x04002A75 RID: 10869
        //        public readonly float BattleCapsuleCenterX;

        //        // Token: 0x04002A76 RID: 10870
        //        public readonly float RotateSpeed;

        //        // Token: 0x04002A77 RID: 10871
        //        public readonly float ShowY;

        //        // Token: 0x04002A78 RID: 10872
        //        public readonly float ShowRadius;

        //        // Token: 0x04002A79 RID: 10873
        //        public readonly uint BreakMask;

        //        // Token: 0x04002A7A RID: 10874
        //        public readonly float BreakStateTime;

        //        // Token: 0x04002A7B RID: 10875
        //        public string BattleAIScript;

        //        // Token: 0x04002A7C RID: 10876
        //        public string BeHitSound;

        //        // Token: 0x04002A7D RID: 10877
        //        private DynamicInt32[] mDeBuffDefends;

        //        // Token: 0x04002A7E RID: 10878
        //        public float BeHitEffectDistance;

        //        // Token: 0x04002A7F RID: 10879
        //        public readonly float ShowPhysicsDefend;

        //        // Token: 0x04002A80 RID: 10880
        //        public readonly float ShowElementDefend;

        //        // Token: 0x04002A81 RID: 10881
        //        private PlayerBaseProperty mLinkPlayerBase;


        //        public FightProperty(FightProperty.StaticData SourceData)
        //		{
        //			this.mPhysicsAttack = new FightProperty.DynamicValue(0f, 9999f);
        //			this.mPhysicsAttack.Base = SourceData.PhysicsAttack;
        //			this.mElementAttack = new FightProperty.DynamicValue(0f, 9999f);
        //			this.mElementAttack.Base = SourceData.ElementAttack;
        //			this.mPhysicsDefend = new FightProperty.DynamicValue(0f, 9999f);
        //			this.mPhysicsDefend.Base = SourceData.PhysicsDefend;
        //			this.mElementDefend = new FightProperty.DynamicValue(0f, 9999f);
        //			this.mElementDefend.Base = SourceData.ElementDefend;
        //			this.mHitValue = new FightProperty.DynamicValue(0f, 999f);
        //			this.mHitValue.Base = SourceData.HitValue;
        //			this.mDodgeValue = new FightProperty.DynamicValue(0f, 999f);
        //			this.mDodgeValue.Base = SourceData.DodgeValue;
        //			this.mBlockRate = new FightProperty.DynamicValue(0f, 1f);
        //			this.mBlockRate.Base = SourceData.BlockRate;
        //			this.mCritRate = new FightProperty.DynamicValue(0f, 1f);
        //			this.mCritRate.Base = SourceData.CritRate;
        //			this.mAgility = new FightProperty.DynamicValue(0f, 3370.171f);
        //			this.mAgility.Base = SourceData.Agility;
        //			this.mLuckValue = new FightProperty.DynamicValue(0f, 9999f);
        //			this.mLuckValue.Base = SourceData.LuckValue;
        //			this.mBlockValue = new FightProperty.DynamicValue(0f, 999f);
        //			this.mBlockValue.Base = SourceData.BlockValue;
        //			this.mCritValue = new FightProperty.DynamicValue(0f, 999f);
        //			this.mCritValue.Base = SourceData.CritValue;
        //			this.mElementsAttack = new DynamicFloat[SourceData.ElementsAttack.Length];
        //			for (int i = 0; i < this.mElementsAttack.Length; i++)
        //			{
        //				this.mElementsAttack[i] = new DynamicFloat(0f, 99999f);
        //				this.mElementsAttack[i].SetAdd(SourceData.ElementsAttack[i]);
        //			}
        //			this.mElementsDefend = new DynamicFloat[SourceData.ElementsDefend.Length];
        //			for (int j = 0; j < this.mElementsDefend.Length; j++)
        //			{
        //				this.mElementsDefend[j] = new DynamicFloat(0f, 99999f);
        //				this.mElementsDefend[j].SetAdd(SourceData.ElementsDefend[j]);
        //			}
        //			this.ATBValue = SourceData.ATBValue;
        //			this.ATBAddSpeedValue = SourceData.ATBAddSpeedValue;
        //			this.SafeRange = SourceData.SafeRange;
        //			this.AttackRange = SourceData.AttackRange;
        //			this.BeAttackRange = SourceData.BeAttackRange;
        //			this.ChainValue = SourceData.ChainValue;
        //			this.BreakValue = SourceData.BreakValue;
        //			this.BreakKeepTime = SourceData.BreakKeepTime;
        //			this.mElementsBreakRate = new DynamicFloat[SourceData.ElementsBreakRate.Length];
        //			for (int k = 0; k < this.mElementsBreakRate.Length; k++)
        //			{
        //				this.mElementsBreakRate[k] = new DynamicFloat(0f, 99999f);
        //				this.mElementsBreakRate[k].SetAdd(SourceData.ElementsBreakRate[k]);
        //			}
        //			this.DamageRate = SourceData.DamageRate;
        //			this.ElementWeak = SourceData.ElementWeak;
        //			this.BreakHeight = SourceData.BreakHeight;
        //			this.AddATKTime = SourceData.AddATKTime;
        //			this.BattleCapsuleRadius = SourceData.BattleCapsuleRadius;
        //			this.BattleCapsuleHeight = SourceData.BattleCapsuleHeight;
        //			this.BattleCapsuleCenterHeight = SourceData.BattleCapsuleCenterHeight;
        //			this.BattleCapsuleCenterX = SourceData.BattleCapsuleCenterX;
        //			this.RotateSpeed = SourceData.RotateSpeed;
        //			this.ShowY = SourceData.ShowY;
        //			this.ShowRadius = SourceData.ShowRadius;
        //			this.BreakMask = SourceData.BreakMask;
        //			this.BreakStateTime = SourceData.BreakStateTime;
        //			this.BattleAIScript = SourceData.BattleAIScript;
        //			this.BeHitSound = SourceData.BeHitSound;
        //			this.mDeBuffDefends = new DynamicInt32[SourceData.DeBuffDefends.Length];
        //			for (int l = 0; l < this.mDeBuffDefends.Length; l++)
        //			{
        //				this.mDeBuffDefends[l] = new DynamicInt32(0, 100);
        //				this.mDeBuffDefends[l].SetAdd(SourceData.DeBuffDefends[l]);
        //			}
        //			this.BeHitEffectDistance = SourceData.BeHitEffectDistance;
        //			this.ShowPhysicsDefend = SourceData.ShowPhysicsDefend;
        //			this.ShowElementDefend = SourceData.ShowElementDefend;
        //			this.LuckValue.OnChangeValue -= this.CritValue_ByCalculate;
        //			this.LuckValue.OnChangeValue += this.CritValue_ByCalculate;
        //			this.LuckValue.OnChangeValue -= this.DodgeValue_ByCalculate;
        //			this.LuckValue.OnChangeValue += this.DodgeValue_ByCalculate;
        //			this.Agility.OnChangeValue -= this.HitValue_ByCalculate;
        //			this.Agility.OnChangeValue += this.HitValue_ByCalculate;
        //			this.BlockValue.OnChangeValue -= this.BlockRate_ByCalculate;
        //			this.BlockValue.OnChangeValue += this.BlockRate_ByCalculate;
        //			this.CritValue.OnChangeValue -= this.CritRate_ByCalculate;
        //			this.CritValue.OnChangeValue += this.CritRate_ByCalculate;
        //		}

        //		// Token: 0x14000015 RID: 21
        //		// (add) Token: 0x06002EF3 RID: 12019 RVA: 0x001593E0 File Offset: 0x001575E0
        //		// (remove) Token: 0x06002EF4 RID: 12020 RVA: 0x001593FC File Offset: 0x001575FC
        //		public event Action OnUnLink;

        //		// Token: 0x170002EC RID: 748
        //		// (get) Token: 0x06002EF5 RID: 12021 RVA: 0x00159418 File Offset: 0x00157618
        //		public FightProperty.DynamicValue PhysicsAttack
        //		{
        //			get
        //			{
        //				return this.mPhysicsAttack;
        //			}
        //		}

        //		// Token: 0x170002ED RID: 749
        //		// (get) Token: 0x06002EF6 RID: 12022 RVA: 0x00159420 File Offset: 0x00157620
        //		public FightProperty.DynamicValue ElementAttack
        //		{
        //			get
        //			{
        //				return this.mElementAttack;
        //			}
        //		}

        //		// Token: 0x170002EE RID: 750
        //		// (get) Token: 0x06002EF7 RID: 12023 RVA: 0x00159428 File Offset: 0x00157628
        //		public FightProperty.DynamicValue PhysicsDefend
        //		{
        //			get
        //			{
        //				return this.mPhysicsDefend;
        //			}
        //		}

        //		// Token: 0x170002EF RID: 751
        //		// (get) Token: 0x06002EF8 RID: 12024 RVA: 0x00159430 File Offset: 0x00157630
        //		public FightProperty.DynamicValue ElementDefend
        //		{
        //			get
        //			{
        //				return this.mElementDefend;
        //			}
        //		}

        //		// Token: 0x170002F0 RID: 752
        //		// (get) Token: 0x06002EF9 RID: 12025 RVA: 0x00159438 File Offset: 0x00157638
        //		public FightProperty.DynamicValue HitValue
        //		{
        //			get
        //			{
        //				return this.mHitValue;
        //			}
        //		}

        //		// Token: 0x170002F1 RID: 753
        //		// (get) Token: 0x06002EFA RID: 12026 RVA: 0x00159440 File Offset: 0x00157640
        //		public FightProperty.DynamicValue DodgeValue
        //		{
        //			get
        //			{
        //				return this.mDodgeValue;
        //			}
        //		}

        //		// Token: 0x170002F2 RID: 754
        //		// (get) Token: 0x06002EFB RID: 12027 RVA: 0x00159448 File Offset: 0x00157648
        //		public FightProperty.DynamicValue BlockRate
        //		{
        //			get
        //			{
        //				return this.mBlockRate;
        //			}
        //		}

        //		// Token: 0x170002F3 RID: 755
        //		// (get) Token: 0x06002EFC RID: 12028 RVA: 0x00159450 File Offset: 0x00157650
        //		public FightProperty.DynamicValue CritRate
        //		{
        //			get
        //			{
        //				return this.mCritRate;
        //			}
        //		}

        //		// Token: 0x170002F4 RID: 756
        //		// (get) Token: 0x06002EFD RID: 12029 RVA: 0x00159458 File Offset: 0x00157658
        //		public FightProperty.DynamicValue Agility
        //		{
        //			get
        //			{
        //				return this.mAgility;
        //			}
        //		}

        //		// Token: 0x170002F5 RID: 757
        //		// (get) Token: 0x06002EFE RID: 12030 RVA: 0x00159460 File Offset: 0x00157660
        //		public FightProperty.DynamicValue LuckValue
        //		{
        //			get
        //			{
        //				return this.mLuckValue;
        //			}
        //		}

        //		// Token: 0x170002F6 RID: 758
        //		// (get) Token: 0x06002EFF RID: 12031 RVA: 0x00159468 File Offset: 0x00157668
        //		public FightProperty.DynamicValue BlockValue
        //		{
        //			get
        //			{
        //				return this.mBlockValue;
        //			}
        //		}

        //		// Token: 0x170002F7 RID: 759
        //		// (get) Token: 0x06002F00 RID: 12032 RVA: 0x00159470 File Offset: 0x00157670
        //		public FightProperty.DynamicValue CritValue
        //		{
        //			get
        //			{
        //				return this.mCritValue;
        //			}
        //		}

        //		// Token: 0x170002F8 RID: 760
        //		// (get) Token: 0x06002F01 RID: 12033 RVA: 0x00159478 File Offset: 0x00157678
        //		public DynamicFloat[] ElementsAttack
        //		{
        //			get
        //			{
        //				return this.mElementsAttack;
        //			}
        //		}

        //		// Token: 0x170002F9 RID: 761
        //		// (get) Token: 0x06002F02 RID: 12034 RVA: 0x00159480 File Offset: 0x00157680
        //		public DynamicFloat[] ElementsDefend
        //		{
        //			get
        //			{
        //				return this.mElementsDefend;
        //			}
        //		}

        //		// Token: 0x170002FA RID: 762
        //		// (get) Token: 0x06002F03 RID: 12035 RVA: 0x00159488 File Offset: 0x00157688
        //		public DynamicFloat[] ElementsBreakRate
        //		{
        //			get
        //			{
        //				return this.mElementsBreakRate;
        //			}
        //		}

        //		// Token: 0x170002FB RID: 763
        //		// (get) Token: 0x06002F04 RID: 12036 RVA: 0x00159490 File Offset: 0x00157690
        //		public DynamicInt32[] DeBuffDefends
        //		{
        //			get
        //			{
        //				return this.mDeBuffDefends;
        //			}
        //		}

        //		// Token: 0x170002FC RID: 764
        //		// (set) Token: 0x06002F05 RID: 12037 RVA: 0x00159498 File Offset: 0x00157698
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
        //					this.mLinkPlayerBase.Strength.OnChangeValue -= this.PhysicsAttack_ByCalculate;
        //					this.mLinkPlayerBase.Strength.OnChangeValue -= this.PhysicsDefend_ByCalculate;
        //					this.mLinkPlayerBase.Strength.OnChangeValue -= this.BlockValue_ByCalculate;
        //					this.mLinkPlayerBase.Stamina.OnChangeValue -= this.PhysicsDefend_ByCalculate;
        //					this.mLinkPlayerBase.Stamina.OnChangeValue -= this.ElementDefend_ByCalculate;
        //					this.mLinkPlayerBase.Speed.OnChangeValue -= this.Agility_ByCalculate;
        //					this.mLinkPlayerBase.Luck.OnChangeValue -= this.LuckValue_ByCalculate;
        //					this.mLinkPlayerBase.Magic.OnChangeValue -= this.ElementAttack_ByCalculate;
        //					this.mLinkPlayerBase.Magic.OnChangeValue -= this.ElementDefend_ByCalculate;
        //				}
        //				this.mLinkPlayerBase = value;
        //				if (this.mLinkPlayerBase != null)
        //				{
        //					this.mLinkPlayerBase.Strength.OnChangeValue += this.PhysicsAttack_ByCalculate;
        //					this.mLinkPlayerBase.Strength.OnChangeValue += this.PhysicsDefend_ByCalculate;
        //					this.mLinkPlayerBase.Strength.OnChangeValue += this.BlockValue_ByCalculate;
        //					this.mLinkPlayerBase.Stamina.OnChangeValue += this.PhysicsDefend_ByCalculate;
        //					this.mLinkPlayerBase.Stamina.OnChangeValue += this.ElementDefend_ByCalculate;
        //					this.mLinkPlayerBase.Speed.OnChangeValue += this.Agility_ByCalculate;
        //					this.mLinkPlayerBase.Luck.OnChangeValue += this.LuckValue_ByCalculate;
        //					this.mLinkPlayerBase.Magic.OnChangeValue += this.ElementAttack_ByCalculate;
        //					this.mLinkPlayerBase.Magic.OnChangeValue += this.ElementDefend_ByCalculate;
        //				}
        //				this.ReCalculateAll();
        //			}
        //		}

        //		// Token: 0x06002F06 RID: 12038 RVA: 0x001596D0 File Offset: 0x001578D0
        //		public void PhysicsAttack_ByCalculate(float oldValue)
        //		{
        //			if (this.mLinkPlayerBase != null)
        //			{
        //				this.mPhysicsAttack.ByCalculate = this.mLinkPlayerBase.Strength * 90f / 19f;
        //			}
        //			else
        //			{
        //				this.mPhysicsAttack.ByCalculate = 0f;
        //			}
        //		}

        //		// Token: 0x06002F07 RID: 12039 RVA: 0x00159724 File Offset: 0x00157924
        //		public void ElementAttack_ByCalculate(float oldValue)
        //		{
        //			if (this.mLinkPlayerBase != null)
        //			{
        //				this.mElementAttack.ByCalculate = this.mLinkPlayerBase.Magic * 90f / 19f;
        //			}
        //			else
        //			{
        //				this.mElementAttack.ByCalculate = 0f;
        //			}
        //		}

        //		// Token: 0x06002F08 RID: 12040 RVA: 0x00159778 File Offset: 0x00157978
        //		public void PhysicsDefend_ByCalculate(float oldValue)
        //		{
        //			if (this.mLinkPlayerBase != null)
        //			{
        //				this.mPhysicsDefend.ByCalculate = 3.3157895f * this.mLinkPlayerBase.Strength + 1.4210526f * this.mLinkPlayerBase.Stamina;
        //			}
        //			else
        //			{
        //				this.mPhysicsDefend.ByCalculate = 0f;
        //			}
        //		}

        //		// Token: 0x06002F09 RID: 12041 RVA: 0x001597E0 File Offset: 0x001579E0
        //		public void ElementDefend_ByCalculate(float oldValue)
        //		{
        //			if (this.mLinkPlayerBase != null)
        //			{
        //				this.mElementDefend.ByCalculate = 3.3157895f * this.mLinkPlayerBase.Magic + 1.4210526f * this.mLinkPlayerBase.Stamina;
        //			}
        //			else
        //			{
        //				this.mElementDefend.ByCalculate = 0f;
        //			}
        //		}

        //		// Token: 0x06002F0A RID: 12042 RVA: 0x00159848 File Offset: 0x00157A48
        //		public void HitValue_ByCalculate(float oldValue)
        //		{
        //			this.mHitValue.ByCalculate = this.mAgility * 90f / 900f + 9f;
        //		}

        //		// Token: 0x06002F0B RID: 12043 RVA: 0x00159880 File Offset: 0x00157A80
        //		public void DodgeValue_ByCalculate(float oldValue)
        //		{
        //			this.mDodgeValue.ByCalculate = this.mLuckValue * 90f / 900f + 8f;
        //		}

        //		// Token: 0x06002F0C RID: 12044 RVA: 0x001598B8 File Offset: 0x00157AB8
        //		public void BlockRate_ByCalculate(float oldValue)
        //		{
        //			this.mBlockRate.ByCalculate = (this.mBlockValue * 11f * 0.01f + 9f) * 0.01f;
        //		}

        //		// Token: 0x06002F0D RID: 12045 RVA: 0x001598F4 File Offset: 0x00157AF4
        //		public void CritRate_ByCalculate(float oldValue)
        //		{
        //			this.mCritRate.ByCalculate = (this.mCritValue * 33f * 0.01f + 7f) * 0.01f;
        //		}

        //		// Token: 0x06002F0E RID: 12046 RVA: 0x00159930 File Offset: 0x00157B30
        //		public void Agility_ByCalculate(float oldValue)
        //		{
        //			if (this.mLinkPlayerBase != null)
        //			{
        //				this.mAgility.ByCalculate = this.mLinkPlayerBase.Speed * 90f / 19f;
        //			}
        //			else
        //			{
        //				this.mAgility.ByCalculate = 0f;
        //			}
        //		}

        //		// Token: 0x06002F0F RID: 12047 RVA: 0x00159984 File Offset: 0x00157B84
        //		public void LuckValue_ByCalculate(float oldValue)
        //		{
        //			if (this.mLinkPlayerBase != null)
        //			{
        //				this.mLuckValue.ByCalculate = this.mLinkPlayerBase.Luck * 90f / 19f + 7f;
        //			}
        //			else
        //			{
        //				this.mLuckValue.ByCalculate = 0f;
        //			}
        //		}

        //		// Token: 0x06002F10 RID: 12048 RVA: 0x001599E0 File Offset: 0x00157BE0
        //		public void BlockValue_ByCalculate(float oldValue)
        //		{
        //			if (this.mLinkPlayerBase != null)
        //			{
        //				this.mBlockValue.ByCalculate = this.mLinkPlayerBase.Strength * 90f / 190f + 9f;
        //			}
        //			else
        //			{
        //				this.mBlockValue.ByCalculate = 0f;
        //			}
        //		}

        //		// Token: 0x06002F11 RID: 12049 RVA: 0x00159A3C File Offset: 0x00157C3C
        //		public void CritValue_ByCalculate(float oldValue)
        //		{
        //			this.mCritValue.ByCalculate = this.mLuckValue * 90f / 900f + 9.5f;
        //		}

        //		// Token: 0x06002F12 RID: 12050 RVA: 0x00159A74 File Offset: 0x00157C74
        //		public void ReCalculateAll()
        //		{
        //			this.Agility_ByCalculate(this.mAgility);
        //			this.LuckValue_ByCalculate(this.mLuckValue);
        //			this.PhysicsAttack_ByCalculate(this.mPhysicsAttack);
        //			this.ElementAttack_ByCalculate(this.mElementAttack);
        //			this.PhysicsDefend_ByCalculate(this.mPhysicsDefend);
        //			this.ElementDefend_ByCalculate(this.mElementDefend);
        //			this.HitValue_ByCalculate(this.mHitValue);
        //			this.DodgeValue_ByCalculate(this.mDodgeValue);
        //			this.BlockRate_ByCalculate(this.mBlockRate);
        //			this.CritRate_ByCalculate(this.mCritRate);
        //			this.BlockValue_ByCalculate(this.mBlockValue);
        //			this.CritValue_ByCalculate(this.mCritValue);
        //		}

        //		// Token: 0x06002F13 RID: 12051 RVA: 0x00159B50 File Offset: 0x00157D50
        //		public void UnLink()
        //		{
        //			this.LinkPlayerBase = null;
        //			if (this.OnUnLink != null)
        //			{
        //				this.OnUnLink();
        //			}
        //		}

        //		// Token: 0x06002F14 RID: 12052 RVA: 0x00159B70 File Offset: 0x00157D70
        //		public int GetDeBuffDefendValue(StatusDataManager.STATUS_TYPE_ENUM epos)
        //		{
        //			if (epos < StatusDataManager.STATUS_TYPE_ENUM.TYPE_NULL || epos >= (StatusDataManager.STATUS_TYPE_ENUM)this.DeBuffDefends.Length || this.DeBuffDefends[(int)epos] == null)
        //			{
        //				return 0;
        //			}
        //			return this.DeBuffDefends[(int)epos];
        //		}

        //		// Token: 0x06002F15 RID: 12053 RVA: 0x00159BB0 File Offset: 0x00157DB0
        //		public static int GetDeBuffDefendValue(int[] source, StatusDataManager.STATUS_TYPE_ENUM epos)
        //		{
        //			if (epos < StatusDataManager.STATUS_TYPE_ENUM.TYPE_NULL || epos >= (StatusDataManager.STATUS_TYPE_ENUM)source.Length)
        //			{
        //				return 0;
        //			}
        //			return source[(int)epos];
        //		}

        //		// Token: 0x06002F16 RID: 12054 RVA: 0x00159BD4 File Offset: 0x00157DD4
        //		public void AddDeBuffDefendValue(int[] v)
        //		{
        //			if (v == null)
        //			{
        //				return;
        //			}
        //			if (this.DeBuffDefends.Length < v.Length)
        //			{
        //				DynamicInt32[] array = this.mDeBuffDefends;
        //				this.mDeBuffDefends = new DynamicInt32[v.Length];
        //				Array.Copy(array, 0, this.mDeBuffDefends, 0, array.Length);
        //				for (int i = 0; i < this.mDeBuffDefends.Length; i++)
        //				{
        //					if (this.mDeBuffDefends[i] == null)
        //					{
        //						this.mDeBuffDefends[i] = new DynamicInt32(0, 100);
        //					}
        //				}
        //			}
        //			for (int j = 0; j < v.Length; j++)
        //			{
        //				this.DeBuffDefends[j].ChangeAdd(v[j]);
        //			}
        //		}

        //		// Token: 0x06002F17 RID: 12055 RVA: 0x00159C78 File Offset: 0x00157E78
        //		public void ReduceDeBuffDefendValue(int[] v)
        //		{
        //			if (v == null)
        //			{
        //				return;
        //			}
        //			if (this.DeBuffDefends.Length < v.Length)
        //			{
        //				DynamicInt32[] array = this.mDeBuffDefends;
        //				this.mDeBuffDefends = new DynamicInt32[v.Length];
        //				Array.Copy(array, 0, this.mDeBuffDefends, 0, array.Length);
        //				for (int i = 0; i < this.mDeBuffDefends.Length; i++)
        //				{
        //					if (this.mDeBuffDefends[i] == null)
        //					{
        //						this.mDeBuffDefends[i] = new DynamicInt32(0, 100);
        //					}
        //				}
        //			}
        //			for (int j = 0; j < v.Length; j++)
        //			{
        //				this.DeBuffDefends[j].ChangeAdd(-v[j]);
        //			}
        //		}

        //		// Token: 0x06002F18 RID: 12056 RVA: 0x00159D20 File Offset: 0x00157F20
        //		~FightProperty()
        //		{
        //			this.UnLink();
        //		}

        //		// Token: 0x020006B6 RID: 1718
        //		public class DynamicValue : DynamicFloat
        //		{
        //			// Token: 0x06002F19 RID: 12057 RVA: 0x00159D5C File Offset: 0x00157F5C
        //			public DynamicValue(float inMinValue, float inMaxValue) : base(inMinValue, inMaxValue)
        //			{
        //			}

        //			// Token: 0x170002FD RID: 765
        //			// (get) Token: 0x06002F1A RID: 12058 RVA: 0x00159D68 File Offset: 0x00157F68
        //			// (set) Token: 0x06002F1B RID: 12059 RVA: 0x00159D70 File Offset: 0x00157F70
        //			public float Base
        //			{
        //				get
        //				{
        //					return this.mBase;
        //				}
        //				set
        //				{
        //					this.mBase = value;
        //					this.Calculate();
        //				}
        //			}

        //			// Token: 0x170002FE RID: 766
        //			// (get) Token: 0x06002F1C RID: 12060 RVA: 0x00159D80 File Offset: 0x00157F80
        //			// (set) Token: 0x06002F1D RID: 12061 RVA: 0x00159D88 File Offset: 0x00157F88
        //			public float ByCalculate
        //			{
        //				get
        //				{
        //					return this.mByCalculate;
        //				}
        //				set
        //				{
        //					this.mByCalculate = value;
        //					this.Calculate();
        //				}
        //			}

        //			// Token: 0x06002F1E RID: 12062 RVA: 0x00159D98 File Offset: 0x00157F98
        //			public override void Calculate()
        //			{
        //				float result = this.result;
        //				this.result = (this.mBase + this.mByCalculate + this.mAdd) * this.mScale;
        //				if (this.result < this.mMinValue)
        //				{
        //					this.mIsOverdraw = true;
        //					this.result = this.mMinValue;
        //				}
        //				else if (this.result > this.mMaxValue)
        //				{
        //					this.result = this.mMaxValue;
        //				}
        //				if (result != this.result)
        //				{
        //					base.ChangeValue(result);
        //				}
        //			}

        //			// Token: 0x06002F1F RID: 12063 RVA: 0x00159E28 File Offset: 0x00158028
        //			public override string ToString()
        //			{
        //				return this.ToString();
        //			}

        //			// Token: 0x04002A83 RID: 10883
        //			private float mBase;

        //			// Token: 0x04002A84 RID: 10884
        //			private float mByCalculate;
        //		}

        //		// Token: 0x020006B7 RID: 1719
        //		public enum FieldEnum
        //		{
        //			// Token: 0x04002A86 RID: 10886
        //			mPhysicsAttack = 1,
        //			// Token: 0x04002A87 RID: 10887
        //			mElementAttack,
        //			// Token: 0x04002A88 RID: 10888
        //			mPhysicsDefend,
        //			// Token: 0x04002A89 RID: 10889
        //			mElementDefend,
        //			// Token: 0x04002A8A RID: 10890
        //			mHitValue,
        //			// Token: 0x04002A8B RID: 10891
        //			mDodgeValue,
        //			// Token: 0x04002A8C RID: 10892
        //			mBlockRate,
        //			// Token: 0x04002A8D RID: 10893
        //			mCritRate,
        //			// Token: 0x04002A8E RID: 10894
        //			mAgility,
        //			// Token: 0x04002A8F RID: 10895
        //			mLuckValue,
        //			// Token: 0x04002A90 RID: 10896
        //			mBlockValue,
        //			// Token: 0x04002A91 RID: 10897
        //			mCritValue,
        //			// Token: 0x04002A92 RID: 10898
        //			mElementsAttack,
        //			// Token: 0x04002A93 RID: 10899
        //			mElementsDefend,
        //			// Token: 0x04002A94 RID: 10900
        //			ATBValue,
        //			// Token: 0x04002A95 RID: 10901
        //			ATBAddSpeedValue,
        //			// Token: 0x04002A96 RID: 10902
        //			SafeRange,
        //			// Token: 0x04002A97 RID: 10903
        //			AttackRange,
        //			// Token: 0x04002A98 RID: 10904
        //			BeAttackRange,
        //			// Token: 0x04002A99 RID: 10905
        //			ChainValue,
        //			// Token: 0x04002A9A RID: 10906
        //			BreakValue,
        //			// Token: 0x04002A9B RID: 10907
        //			BreakKeepTime,
        //			// Token: 0x04002A9C RID: 10908
        //			mElementsBreakRate,
        //			// Token: 0x04002A9D RID: 10909
        //			DamageRate,
        //			// Token: 0x04002A9E RID: 10910
        //			ElementWeak,
        //			// Token: 0x04002A9F RID: 10911
        //			BreakHeight,
        //			// Token: 0x04002AA0 RID: 10912
        //			AddATKTime,
        //			// Token: 0x04002AA1 RID: 10913
        //			BattleCapsuleRadius,
        //			// Token: 0x04002AA2 RID: 10914
        //			BattleCapsuleHeight,
        //			// Token: 0x04002AA3 RID: 10915
        //			BattleCapsuleCenterHeight,
        //			// Token: 0x04002AA4 RID: 10916
        //			BattleCapsuleCenterX,
        //			// Token: 0x04002AA5 RID: 10917
        //			RotateSpeed,
        //			// Token: 0x04002AA6 RID: 10918
        //			ShowY,
        //			// Token: 0x04002AA7 RID: 10919
        //			ShowRadius,
        //			// Token: 0x04002AA8 RID: 10920
        //			BreakMask,
        //			// Token: 0x04002AA9 RID: 10921
        //			BreakStateTime,
        //			// Token: 0x04002AAA RID: 10922
        //			BattleAIScript,
        //			// Token: 0x04002AAB RID: 10923
        //			BeHitSound,
        //			// Token: 0x04002AAC RID: 10924
        //			mDeBuffDefends,
        //			// Token: 0x04002AAD RID: 10925
        //			BeHitEffectDistance,
        //			// Token: 0x04002AAE RID: 10926
        //			ShowPhysicsDefend,
        //			// Token: 0x04002AAF RID: 10927
        //			ShowElementDefend
        //		}

        public class StaticData
        {

            //            // Token: 0x04002AB0 RID: 10928
            //            public static readonly string DefaultDataPath = Path.Combine(Application.dataPath, "Data/Property/Fight.dat");

            //            // Token: 0x04002AB1 RID: 10929
            //            private float mPhysicsAttack;

            //            // Token: 0x04002AB2 RID: 10930
            //            private float mElementAttack;

            //            // Token: 0x04002AB3 RID: 10931
            //            private float mPhysicsDefend;

            //            // Token: 0x04002AB4 RID: 10932
            //            private float mElementDefend;

            //            // Token: 0x04002AB5 RID: 10933
            //            private float mHitValue;

            //            // Token: 0x04002AB6 RID: 10934
            //            private float mDodgeValue;

            //            // Token: 0x04002AB7 RID: 10935
            //            private float mBlockRate;

            //            // Token: 0x04002AB8 RID: 10936
            //            private float mCritRate;

            //            // Token: 0x04002AB9 RID: 10937
            //            private float mAgility;

            //            // Token: 0x04002ABA RID: 10938
            //            private float mLuckValue;

            //            // Token: 0x04002ABB RID: 10939
            //            private float mBlockValue;

            //            // Token: 0x04002ABC RID: 10940
            //            private float mCritValue;

            //            // Token: 0x04002ABD RID: 10941
            //            private float[] mElementsAttack;

            //            // Token: 0x04002ABE RID: 10942
            //            private float[] mElementsDefend;

            //            // Token: 0x04002ABF RID: 10943
            //            public readonly float ATBValue;

            //            // Token: 0x04002AC0 RID: 10944
            //            public readonly float ATBAddSpeedValue;

            //            // Token: 0x04002AC1 RID: 10945
            //            public readonly float SafeRange;

            //            // Token: 0x04002AC2 RID: 10946
            //            public readonly float AttackRange;

            //            // Token: 0x04002AC3 RID: 10947
            //            public readonly float BeAttackRange;

            //            // Token: 0x04002AC4 RID: 10948
            //            public readonly float ChainValue;

            //            // Token: 0x04002AC5 RID: 10949
            //            public readonly float BreakValue;

            //            // Token: 0x04002AC6 RID: 10950
            //            public readonly float BreakKeepTime;

            //            // Token: 0x04002AC7 RID: 10951
            //            private float[] mElementsBreakRate;

            //            // Token: 0x04002AC8 RID: 10952
            //            public readonly float DamageRate;

            //            // Token: 0x04002AC9 RID: 10953
            //            public readonly ElementPhase ElementWeak;

            //            // Token: 0x04002ACA RID: 10954
            //            public readonly float BreakHeight;

            //            // Token: 0x04002ACB RID: 10955
            //            public readonly float AddATKTime;

            //            // Token: 0x04002ACC RID: 10956
            //            public readonly float BattleCapsuleRadius;

            //            // Token: 0x04002ACD RID: 10957
            //            public readonly float BattleCapsuleHeight;

            //            // Token: 0x04002ACE RID: 10958
            //            public readonly float BattleCapsuleCenterHeight;

            //            // Token: 0x04002ACF RID: 10959
            //            public readonly float BattleCapsuleCenterX;

            //            // Token: 0x04002AD0 RID: 10960
            //            public readonly float RotateSpeed;

            //            // Token: 0x04002AD1 RID: 10961
            //            public readonly float ShowY;

            //            // Token: 0x04002AD2 RID: 10962
            //            public readonly float ShowRadius;

            //            // Token: 0x04002AD3 RID: 10963
            //            public readonly uint BreakMask;

            //            // Token: 0x04002AD4 RID: 10964
            //            public readonly float BreakStateTime;

            //            // Token: 0x04002AD5 RID: 10965
            //            public string BattleAIScript;

            //            // Token: 0x04002AD6 RID: 10966
            //            public string BeHitSound;

            //            // Token: 0x04002AD7 RID: 10967
            //            private int[] mDeBuffDefends;

            //            // Token: 0x04002AD8 RID: 10968
            //            public float BeHitEffectDistance;

            //            // Token: 0x04002AD9 RID: 10969
            //            public readonly float ShowPhysicsDefend;

            //            // Token: 0x04002ADA RID: 10970
            //            public readonly float ShowElementDefend;

            private static string[] mDataPaths = null;

            private static Dictionary<uint, FightProperty.StaticData> Datas = null;

            //            public StaticData(out uint Key, BinaryReader DataReader)
            //			{
            //				Key = DataReader.ReadUInt32();
            //				this.mPhysicsAttack = DataReader.ReadSingle();
            //				this.mElementAttack = DataReader.ReadSingle();
            //				this.mPhysicsDefend = DataReader.ReadSingle();
            //				this.mElementDefend = DataReader.ReadSingle();
            //				this.mHitValue = DataReader.ReadSingle();
            //				this.mDodgeValue = DataReader.ReadSingle();
            //				this.mBlockRate = DataReader.ReadSingle();
            //				this.mCritRate = DataReader.ReadSingle();
            //				this.mAgility = DataReader.ReadSingle();
            //				this.mLuckValue = DataReader.ReadSingle();
            //				this.mBlockValue = DataReader.ReadSingle();
            //				this.mCritValue = DataReader.ReadSingle();
            //				this.mElementsAttack = new float[8];
            //				for (int i = 0; i < this.mElementsAttack.Length; i++)
            //				{
            //					this.mElementsAttack[i] = DataReader.ReadSingle();
            //				}
            //				this.mElementsDefend = new float[8];
            //				for (int j = 0; j < this.mElementsDefend.Length; j++)
            //				{
            //					this.mElementsDefend[j] = DataReader.ReadSingle();
            //				}
            //				this.ATBValue = DataReader.ReadSingle();
            //				this.ATBAddSpeedValue = DataReader.ReadSingle();
            //				this.SafeRange = DataReader.ReadSingle();
            //				this.AttackRange = DataReader.ReadSingle();
            //				this.BeAttackRange = DataReader.ReadSingle();
            //				this.ChainValue = DataReader.ReadSingle();
            //				this.BreakValue = DataReader.ReadSingle();
            //				this.BreakKeepTime = DataReader.ReadSingle();
            //				this.mElementsBreakRate = new float[8];
            //				for (int k = 0; k < this.mElementsBreakRate.Length; k++)
            //				{
            //					this.mElementsBreakRate[k] = DataReader.ReadSingle();
            //				}
            //				this.DamageRate = DataReader.ReadSingle();
            //				this.ElementWeak = (ElementPhase)DataReader.ReadByte();
            //				this.BreakHeight = DataReader.ReadSingle();
            //				this.AddATKTime = DataReader.ReadSingle();
            //				this.BattleCapsuleRadius = DataReader.ReadSingle();
            //				this.BattleCapsuleHeight = DataReader.ReadSingle();
            //				this.BattleCapsuleCenterHeight = DataReader.ReadSingle();
            //				this.BattleCapsuleCenterX = DataReader.ReadSingle();
            //				this.RotateSpeed = DataReader.ReadSingle();
            //				this.ShowY = DataReader.ReadSingle();
            //				this.ShowRadius = DataReader.ReadSingle();
            //				this.BreakMask = DataReader.ReadUInt32();
            //				this.BreakStateTime = DataReader.ReadSingle();
            //				this.BattleAIScript = DataReader.ReadString();
            //				this.BeHitSound = DataReader.ReadString();
            //				this.mDeBuffDefends = new int[DataReader.ReadInt32()];
            //				for (int l = 0; l < this.mDeBuffDefends.Length; l++)
            //				{
            //					this.mDeBuffDefends[l] = DataReader.ReadInt32();
            //				}
            //				this.BeHitEffectDistance = DataReader.ReadSingle();
            //				this.ShowPhysicsDefend = DataReader.ReadSingle();
            //				this.ShowElementDefend = DataReader.ReadSingle();
            //			}

            //			// Token: 0x170002FF RID: 767
            //			// (get) Token: 0x06002F22 RID: 12066 RVA: 0x0015A128 File Offset: 0x00158328
            //			public float PhysicsAttack
            //			{
            //				get
            //				{
            //					return this.mPhysicsAttack;
            //				}
            //			}

            //			// Token: 0x17000300 RID: 768
            //			// (get) Token: 0x06002F23 RID: 12067 RVA: 0x0015A130 File Offset: 0x00158330
            //			public float ElementAttack
            //			{
            //				get
            //				{
            //					return this.mElementAttack;
            //				}
            //			}

            //			// Token: 0x17000301 RID: 769
            //			// (get) Token: 0x06002F24 RID: 12068 RVA: 0x0015A138 File Offset: 0x00158338
            //			public float PhysicsDefend
            //			{
            //				get
            //				{
            //					return this.mPhysicsDefend;
            //				}
            //			}

            //			// Token: 0x17000302 RID: 770
            //			// (get) Token: 0x06002F25 RID: 12069 RVA: 0x0015A140 File Offset: 0x00158340
            //			public float ElementDefend
            //			{
            //				get
            //				{
            //					return this.mElementDefend;
            //				}
            //			}

            //			// Token: 0x17000303 RID: 771
            //			// (get) Token: 0x06002F26 RID: 12070 RVA: 0x0015A148 File Offset: 0x00158348
            //			public float HitValue
            //			{
            //				get
            //				{
            //					return this.mHitValue;
            //				}
            //			}

            //			// Token: 0x17000304 RID: 772
            //			// (get) Token: 0x06002F27 RID: 12071 RVA: 0x0015A150 File Offset: 0x00158350
            //			public float DodgeValue
            //			{
            //				get
            //				{
            //					return this.mDodgeValue;
            //				}
            //			}

            //			// Token: 0x17000305 RID: 773
            //			// (get) Token: 0x06002F28 RID: 12072 RVA: 0x0015A158 File Offset: 0x00158358
            //			public float BlockRate
            //			{
            //				get
            //				{
            //					return this.mBlockRate;
            //				}
            //			}

            //			// Token: 0x17000306 RID: 774
            //			// (get) Token: 0x06002F29 RID: 12073 RVA: 0x0015A160 File Offset: 0x00158360
            //			public float CritRate
            //			{
            //				get
            //				{
            //					return this.mCritRate;
            //				}
            //			}

            //			// Token: 0x17000307 RID: 775
            //			// (get) Token: 0x06002F2A RID: 12074 RVA: 0x0015A168 File Offset: 0x00158368
            //			public float Agility
            //			{
            //				get
            //				{
            //					return this.mAgility;
            //				}
            //			}

            //			// Token: 0x17000308 RID: 776
            //			// (get) Token: 0x06002F2B RID: 12075 RVA: 0x0015A170 File Offset: 0x00158370
            //			public float LuckValue
            //			{
            //				get
            //				{
            //					return this.mLuckValue;
            //				}
            //			}

            //			// Token: 0x17000309 RID: 777
            //			// (get) Token: 0x06002F2C RID: 12076 RVA: 0x0015A178 File Offset: 0x00158378
            //			public float BlockValue
            //			{
            //				get
            //				{
            //					return this.mBlockValue;
            //				}
            //			}

            //			// Token: 0x1700030A RID: 778
            //			// (get) Token: 0x06002F2D RID: 12077 RVA: 0x0015A180 File Offset: 0x00158380
            //			public float CritValue
            //			{
            //				get
            //				{
            //					return this.mCritValue;
            //				}
            //			}

            //			// Token: 0x1700030B RID: 779
            //			// (get) Token: 0x06002F2E RID: 12078 RVA: 0x0015A188 File Offset: 0x00158388
            //			public float[] ElementsAttack
            //			{
            //				get
            //				{
            //					return this.mElementsAttack;
            //				}
            //			}

            //			// Token: 0x1700030C RID: 780
            //			// (get) Token: 0x06002F2F RID: 12079 RVA: 0x0015A190 File Offset: 0x00158390
            //			public float[] ElementsDefend
            //			{
            //				get
            //				{
            //					return this.mElementsDefend;
            //				}
            //			}

            //			// Token: 0x1700030D RID: 781
            //			// (get) Token: 0x06002F30 RID: 12080 RVA: 0x0015A198 File Offset: 0x00158398
            //			public float[] ElementsBreakRate
            //			{
            //				get
            //				{
            //					return this.mElementsBreakRate;
            //				}
            //			}

            //			// Token: 0x1700030E RID: 782
            //			// (get) Token: 0x06002F31 RID: 12081 RVA: 0x0015A1A0 File Offset: 0x001583A0
            //			public int[] DeBuffDefends
            //			{
            //				get
            //				{
            //					return this.mDeBuffDefends;
            //				}
            //			}

            //			// Token: 0x1700030F RID: 783
            //			// (get) Token: 0x06002F32 RID: 12082 RVA: 0x0015A1A8 File Offset: 0x001583A8
            //			public static string[] DataPaths
            //			{
            //				get
            //				{
            //					if (FightProperty.StaticData.mDataPaths == null)
            //					{
            //						string str = "." + PalMain.GameDifficulty.ToString();
            //						List<string> list = new List<string>();
            //						list.Add(FightProperty.StaticData.DefaultDataPath + str);
            //						string path = FightProperty.StaticData.DefaultDataPath + ".list";
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
            //						FightProperty.StaticData.mDataPaths = list.ToArray();
            //					}
            //					return FightProperty.StaticData.mDataPaths;
            //				}
            //			}

            //			// Token: 0x06002F33 RID: 12083 RVA: 0x0015A280 File Offset: 0x00158480
            //			public static Dictionary<uint, FightProperty.StaticData> GetDatasFromFile()
            //			{
            //				if (FightProperty.StaticData.Datas == null)
            //				{
            //					Dictionary<uint, FightProperty.StaticData> dictionary = new Dictionary<uint, FightProperty.StaticData>(65536);
            //					foreach (string text in FightProperty.StaticData.DataPaths)
            //					{
            //						if (text.ExistFile())
            //						{
            //							using (FileStream fileStream = new FileStream(text, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            //							{
            //								BinaryReader dataReader = new BinaryReader(fileStream);
            //								while (fileStream.Position < fileStream.Length)
            //								{
            //									uint key;
            //									FightProperty.StaticData value = new FightProperty.StaticData(ref key, dataReader);
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
            //					FightProperty.StaticData.Datas = dictionary;
            //					return FightProperty.StaticData.Datas;
            //				}
            //				return FightProperty.StaticData.Datas;
            //			}

            //			// Token: 0x06002F34 RID: 12084 RVA: 0x0015A37C File Offset: 0x0015857C
            //			public static FightProperty.StaticData GetData(uint id)
            //			{
            //				Dictionary<uint, FightProperty.StaticData> datasFromFile = FightProperty.StaticData.GetDatasFromFile();
            //				FightProperty.StaticData result = null;
            //				datasFromFile.TryGetValue(id, out result);
            //				return result;
            //			}

            public static void Reset()
            {
                FightProperty.StaticData.mDataPaths = null;
                FightProperty.StaticData.Datas = null;
            }
        }
    }
}
