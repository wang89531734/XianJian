using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
//using SoftStar.BuffDebuff;
using SoftStar.Item;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SoftStar.Pal6
{
    public class PalNPC : PalAnimatorObject, ISaveInterface
    {
        //		public delegate void void_fun_TF(PalNPC npc);

        //		public PalNPC()
        //		{
        //			this.m_SkillIDs = new List<PalNPC.SkillInfo>();
        //			this.ExpRate = 1f;
        //			base..ctor();
        //		}

        //		// Token: 0x06001CE5 RID: 7397 RVA: 0x00101A08 File Offset: 0x000FFC08
        //		// Note: this type is marked as 'beforefieldinit'.
        //		static PalNPC()
        //		{
        //			PalNPC.mAdvanceSkillIDs = new int[]
        //			{
        //				101,
        //				3088,
        //				104,
        //				2078,
        //				107,
        //				2084,
        //				114,
        //				3090,
        //				2102,
        //				116,
        //				3097,
        //				3096
        //			};
        //		}

        //		// Token: 0x06001CE6 RID: 7398 RVA: 0x00101A3C File Offset: 0x000FFC3C
        //		public bool CanLookAt()
        //		{
        //			return this.Data != null && this.Data.SocialNPC != null && this.Data.SocialNPC.LookAt;
        //		}

        //		// Token: 0x06001CE7 RID: 7399 RVA: 0x00101A6C File Offset: 0x000FFC6C
        //		public bool CanBeLooked()
        //		{
        //			return this.Data != null && this.Data.SocialNPC != null && this.Data.SocialNPC.BeLooked;
        //		}

        //		// Token: 0x17000296 RID: 662
        //		// (get) Token: 0x06001CE8 RID: 7400 RVA: 0x00101A9C File Offset: 0x000FFC9C
        //		public string ShowName
        //		{
        //			get
        //			{
        //				string result = string.Empty;
        //				if (this.Data != null)
        //				{
        //					if (this.Data.CharacterCommon == null)
        //					{
        //						this.Data.Reset();
        //					}
        //					CharacterProperty characterCommon = this.Data.CharacterCommon;
        //					if (characterCommon != null)
        //					{
        //						if (characterCommon.ShowName != null)
        //						{
        //							result = characterCommon.ShowName.get_string();
        //						}
        //						else
        //						{
        //							Debug.LogError("Error : PalNPC.Data ShowName  Data.CharacterCommon.ShowName == null");
        //						}
        //					}
        //					else
        //					{
        //						Debug.LogError("Error : PalNPC.Data ShowName  Data.CharacterCommon == null");
        //					}
        //				}
        //				else
        //				{
        //					Debug.LogError("Error : PalNPC.Data ShowName  Data == null");
        //				}
        //				return result;
        //			}
        //		}

        //		// Token: 0x06001CE9 RID: 7401 RVA: 0x00101B2C File Offset: 0x000FFD2C
        //		public float ChangeHP(PalNPC Source, ElementPhase curPhase, float add, float scale, bool IsCrit, bool IsDodge, bool IsBlock)
        //		{
        //			BuffDebuffManager.BuffDebuffOwner.ActionContainer actionContainer = new BuffDebuffManager.BuffDebuffOwner.ActionContainer(Source, this);
        //			actionContainer.IsCrit = IsCrit;
        //			actionContainer.IsDodge = IsDodge;
        //			actionContainer.IsBlock = IsBlock;
        //			DynamicFloat orCreateHPChange = actionContainer.GetOrCreateHPChange(curPhase);
        //			if (add >= 0f)
        //			{
        //				orCreateHPChange.MinValue = 0f;
        //				orCreateHPChange.MaxValue = float.MaxValue;
        //			}
        //			else
        //			{
        //				orCreateHPChange.MinValue = float.MinValue;
        //				orCreateHPChange.MaxValue = 0f;
        //			}
        //			orCreateHPChange.SetAdd(add);
        //			orCreateHPChange.SetScale(scale);
        //			BuffDebuffManager.BuffDebuffOwner.BuffDebuffAction(actionContainer);
        //			actionContainer.UseChange();
        //			return actionContainer.GetHPChangeSum();
        //		}

        //		// Token: 0x06001CEA RID: 7402 RVA: 0x00101BC0 File Offset: 0x000FFDC0
        //		public void AddSkillNoRepeat(PalNPC.SkillInfo newSkill)
        //		{
        //			int num = 0;
        //			MonsterSkillDataManager.SkillData data = PalBattleManager.Instance().GetMonsterSkillDataManager().GetData(newSkill.m_ID);
        //			if (data != null)
        //			{
        //				num = data.mID;
        //			}
        //			foreach (PalNPC.SkillInfo skillInfo in this.m_SkillIDs)
        //			{
        //				if (skillInfo.m_ID == newSkill.m_ID)
        //				{
        //					return;
        //				}
        //			}
        //			int index = 0;
        //			bool flag = false;
        //			for (int i = 0; i < this.m_SkillIDs.Count; i++)
        //			{
        //				index = i;
        //				MonsterSkillDataManager.SkillData data2 = PalBattleManager.Instance().GetMonsterSkillDataManager().GetData(this.m_SkillIDs[i].m_ID);
        //				if (data2 != null && data2.mID >= num)
        //				{
        //					flag = true;
        //					break;
        //				}
        //			}
        //			if (flag)
        //			{
        //				this.m_SkillIDs.Insert(index, newSkill);
        //			}
        //			else
        //			{
        //				this.m_SkillIDs.Add(newSkill);
        //			}
        //			if (Array.Exists<int>(PalNPC.mAdvanceSkillIDs, (int Cur) => Cur == newSkill.m_ID))
        //			{
        //				ulong idx = 32002UL;
        //				FlagManager.SetBoolFlag(idx, true);
        //				try
        //				{
        //					if (UIInformation_Help_Item.Items != null && 1 < UIInformation_Help_Item.Items.Length && 2 < UIInformation_Help_Item.Items[1].SubItems.Length && 0 < UIInformation_Help_Item.Items[1].SubItems[2].Text.Length)
        //					{
        //						UIDialogManager.SetOpen(UIInformation_Help_Item.Items[1].SubItems[2].Text[0]);
        //					}
        //				}
        //				catch (Exception exception)
        //				{
        //					Debug.LogException(exception);
        //				}
        //			}
        //		}

        //		// Token: 0x06001CEB RID: 7403 RVA: 0x00101DC8 File Offset: 0x000FFFC8
        //		public void ResetOrnament()
        //		{
        //			UtilFun.BindOrnamentToProp(this.model.transform, this.ornament.transform, false);
        //		}

        //		// Token: 0x17000297 RID: 663
        //		// (get) Token: 0x06001CEC RID: 7404 RVA: 0x00101DE8 File Offset: 0x000FFFE8
        //		// (set) Token: 0x06001CED RID: 7405 RVA: 0x00101DF0 File Offset: 0x000FFFF0
        //		public Material oriAssortMat
        //		{
        //			get
        //			{
        //				return this.m_oriAssortMat;
        //			}
        //			set
        //			{
        //				this.m_oriAssortMat = value;
        //			}
        //		}

        //		// Token: 0x06001CEE RID: 7406 RVA: 0x00101DFC File Offset: 0x000FFFFC
        //		public void GetOriRes()
        //		{
        //			this.model.GetOriTex(out this.oriMainTex, out this.oriSpecTex);
        //			this.oriAssortMat = this.WeaponAssortObj.GetMat();
        //		}

        //		// Token: 0x06001CEF RID: 7407 RVA: 0x00101E34 File Offset: 0x00100034
        //		public void RestoreAssortMat()
        //		{
        //			if (this.oriAssortMat != null)
        //			{
        //				this.WeaponAssortObj.SetMat(this.oriAssortMat);
        //			}
        //		}

        //		// Token: 0x06001CF0 RID: 7408 RVA: 0x00101E64 File Offset: 0x00100064
        //		public void RestoreTex()
        //		{
        //			if (this.model == null)
        //			{
        //				UtilFun.ConsoleLog("Log : model=null RestoreTex 返回", false);
        //				return;
        //			}
        //			if (!this.model.name.Contains("LuoWenRen"))
        //			{
        //				this.model.SetColorTexDecal(this.oriMainTex, this.oriSpecTex, null, Color.white);
        //			}
        //			else
        //			{
        //				ModelChangeScript component = base.gameObject.GetComponent<ModelChangeScript>();
        //				if (component == null || component.curMode == ModelChangeScript.Mode.Original)
        //				{
        //					this.model.SetColorTexDecal(this.oriMainTex, this.oriSpecTex, null, Color.white);
        //				}
        //				else
        //				{
        //					GameObject gameObject = PlayersManager.FindMainChar(7, true);
        //					PalNPC component2 = gameObject.GetComponent<PalNPC>();
        //					component2.RestoreTex();
        //				}
        //			}
        //		}

        //		// Token: 0x17000298 RID: 664
        //		// (get) Token: 0x06001CF1 RID: 7409 RVA: 0x00101F24 File Offset: 0x00100124
        //		public GameObject WeaponAssortObj
        //		{
        //			get
        //			{
        //				if (base.name == "2")
        //				{
        //					return base.gameObject.GetWeaponAssortObj(false, -1);
        //				}
        //				if (this.weaponAssortObj == null)
        //				{
        //					this.weaponAssortObj = base.gameObject.GetWeaponAssortObj(false, -1);
        //				}
        //				return this.weaponAssortObj;
        //			}
        //		}

        //		// Token: 0x06001CF2 RID: 7410 RVA: 0x00101F80 File Offset: 0x00100180
        //		public IItem GetSlot(EquipSlotEnum position)
        //		{
        //			ItemWatcher itemWatcher;
        //			if (this.mEquipSlots.TryGetValue(position, out itemWatcher))
        //			{
        //				return itemWatcher.Target;
        //			}
        //			return null;
        //		}

        //		// Token: 0x06001CF3 RID: 7411 RVA: 0x00101FA8 File Offset: 0x001001A8
        //		public void PutOnEquip(IItemAssemble<PalNPC> curEquip)
        //		{
        //			IItem item = curEquip as IItem;
        //			if (item == null)
        //			{
        //				return;
        //			}
        //			foreach (KeyValuePair<EquipSlotEnum, ItemWatcher> keyValuePair in this.mEquipSlots)
        //			{
        //				if (keyValuePair.Value.Target == item)
        //				{
        //					return;
        //				}
        //			}
        //			PalNPC.PutOffEquip_Internal(this, item);
        //			IItemMerger itemMerger = item as IItemMerger;
        //			if (itemMerger != null && itemMerger.Count > 1)
        //			{
        //				itemMerger.SetCountWithoutEvent(itemMerger.Count - 1);
        //				List<IItem> list = new List<IItem>();
        //				list.Add(item);
        //				item = item.ItemType.CloneWithoutEvent(item);
        //				itemMerger = (item as IItemMerger);
        //				curEquip = (item as IItemAssemble<PalNPC>);
        //				itemMerger.SetCountWithoutEvent(1);
        //				ItemManager.GetInstance().DoAfterCountChange(list.ToArray());
        //				ItemManager.GetInstance().DoOnAfterAddItem(item);
        //				if (item.OwnerPackage != null)
        //				{
        //					item.OwnerPackage.DoOnItemAdded(item);
        //				}
        //			}
        //			EquipSlotEnum equipSlotEnum = (EquipSlotEnum)(item.ItemType.TypeID >> 24);
        //			if (!Enum.IsDefined(typeof(EquipSlotEnum), equipSlotEnum))
        //			{
        //				ItemPackage ownerPackage = item.OwnerPackage;
        //				if (ownerPackage == null)
        //				{
        //					return;
        //				}
        //				ownerPackage.MergerItemType(item.ItemType.TypeID);
        //				return;
        //			}
        //			else
        //			{
        //				ItemWatcher itemWatcher;
        //				if (!this.mEquipSlots.TryGetValue(equipSlotEnum, out itemWatcher))
        //				{
        //					itemWatcher = new ItemWatcher();
        //					this.mEquipSlots.Add(equipSlotEnum, itemWatcher);
        //				}
        //				uint typeID = 0u;
        //				ItemPackage itemPackage = null;
        //				try
        //				{
        //					if (itemWatcher != null && itemWatcher.Target != null && itemWatcher.Target.ItemType != null)
        //					{
        //						typeID = itemWatcher.Target.ItemType.TypeID;
        //						itemPackage = itemWatcher.Target.OwnerPackage;
        //					}
        //				}
        //				catch (Exception exception)
        //				{
        //					Debug.LogException(exception);
        //				}
        //				PalNPC.PutOffEquip_Internal(this, itemWatcher.Target);
        //				curEquip.Link(this);
        //				itemWatcher.SetTarget(item);
        //				if (itemPackage != null)
        //				{
        //					itemPackage.MergerItemType(typeID);
        //				}
        //				if (item.OwnerPackage != null)
        //				{
        //					item.OwnerPackage.MergerItemType(item.ItemType.TypeID);
        //				}
        //			}
        //		}

        //		// Token: 0x06001CF4 RID: 7412 RVA: 0x001021FC File Offset: 0x001003FC
        //		private void LoadLink(IItemAssemble<PalNPC> curEquip)
        //		{
        //			IItem item = curEquip as IItem;
        //			if (item == null)
        //			{
        //				return;
        //			}
        //			EquipSlotEnum equipSlotEnum = (EquipSlotEnum)(item.ItemType.TypeID >> 24);
        //			if (!Enum.IsDefined(typeof(EquipSlotEnum), equipSlotEnum))
        //			{
        //				return;
        //			}
        //			ItemWatcher itemWatcher = new ItemWatcher();
        //			if (!this.mEquipSlots.ContainsKey(equipSlotEnum))
        //			{
        //				this.mEquipSlots.Add(equipSlotEnum, itemWatcher);
        //			}
        //			else
        //			{
        //				this.mEquipSlots[equipSlotEnum] = itemWatcher;
        //			}
        //			curEquip.Link(this);
        //			itemWatcher.SetTarget(item);
        //		}

        //		// Token: 0x06001CF5 RID: 7413 RVA: 0x00102288 File Offset: 0x00100488
        //		public static void PutOffEquip_Internal(PalNPC OldPalNPC, IItem SlotItem)
        //		{
        //			IItemAssemble<PalNPC> itemAssemble = SlotItem as IItemAssemble<PalNPC>;
        //			if (itemAssemble == null || itemAssemble.GetOwner() == null)
        //			{
        //				foreach (KeyValuePair<EquipSlotEnum, ItemWatcher> keyValuePair in OldPalNPC.mEquipSlots)
        //				{
        //					if (keyValuePair.Value.Target == SlotItem)
        //					{
        //						keyValuePair.Value.SetTarget(null);
        //					}
        //				}
        //				return;
        //			}
        //			if (itemAssemble.GetOwner() != OldPalNPC)
        //			{
        //				foreach (KeyValuePair<EquipSlotEnum, ItemWatcher> keyValuePair2 in OldPalNPC.mEquipSlots)
        //				{
        //					if (keyValuePair2.Value.Target == SlotItem)
        //					{
        //						keyValuePair2.Value.SetTarget(null);
        //					}
        //				}
        //				PalNPC.PutOffEquip_Internal(itemAssemble.GetOwner(), SlotItem);
        //				return;
        //			}
        //			foreach (KeyValuePair<EquipSlotEnum, ItemWatcher> keyValuePair3 in OldPalNPC.mEquipSlots)
        //			{
        //				if (keyValuePair3.Value.Target == SlotItem)
        //				{
        //					keyValuePair3.Value.SetTarget(null);
        //				}
        //			}
        //			itemAssemble.UnLink();
        //		}

        //		// Token: 0x06001CF6 RID: 7414 RVA: 0x00102428 File Offset: 0x00100628
        //		public void PutOffEquip(EquipSlotEnum SlotPosition)
        //		{
        //			ItemWatcher itemWatcher;
        //			if (!this.mEquipSlots.TryGetValue(SlotPosition, out itemWatcher))
        //			{
        //				return;
        //			}
        //			this.PutOffEquip(itemWatcher.Target);
        //		}

        //		// Token: 0x06001CF7 RID: 7415 RVA: 0x00102458 File Offset: 0x00100658
        //		public void PutOffEquip(IItem SlotItem)
        //		{
        //			if (SlotItem == null)
        //			{
        //				return;
        //			}
        //			PalNPC.PutOffEquip_Internal(this, SlotItem);
        //			ItemPackage ownerPackage = SlotItem.OwnerPackage;
        //			if (ownerPackage == null)
        //			{
        //				return;
        //			}
        //			ownerPackage.MergerItemType(SlotItem.ItemType.TypeID);
        //		}

        //		// Token: 0x06001CF8 RID: 7416 RVA: 0x00102494 File Offset: 0x00100694
        //		public void RePutOnEquip(EquipSlotEnum SlotPosition)
        //		{
        //			ItemWatcher itemWatcher;
        //			if (!this.mEquipSlots.TryGetValue(SlotPosition, out itemWatcher))
        //			{
        //				return;
        //			}
        //			IItem target = itemWatcher.Target;
        //			if (target == null)
        //			{
        //				return;
        //			}
        //			PalNPC.PutOffEquip_Internal(this, target);
        //			this.PutOnEquip(target as IItemAssemble<PalNPC>);
        //		}

        //		// Token: 0x17000299 RID: 665
        //		// (get) Token: 0x06001CF9 RID: 7417 RVA: 0x001024D8 File Offset: 0x001006D8
        //		// (set) Token: 0x06001CFA RID: 7418 RVA: 0x001024E0 File Offset: 0x001006E0
        //		public AchievementManager.ACHIEVEMENT_INDEX CurrentAchievement
        //		{
        //			get
        //			{
        //				return this.mCurrentAchievement;
        //			}
        //			set
        //			{
        //				if (this.mCurrentAchievement == value)
        //				{
        //					return;
        //				}
        //				NicknameBuffDebuffType data = NicknameBuffDebuffTypeCache.GetData((uint)this.mCurrentAchievement);
        //				if (data != null)
        //				{
        //					this.BuffDebuffData.RemoveOneBuffDebuffByType(data.TypeID);
        //				}
        //				this.mCurrentAchievement = value;
        //				NicknameBuffDebuffType data2 = NicknameBuffDebuffTypeCache.GetData((uint)this.mCurrentAchievement);
        //				if (data2 != null)
        //				{
        //					this.BuffDebuffData.AddBuffDebuffByType(data2.TypeID);
        //				}
        //			}
        //		}

        //		// Token: 0x06001CFB RID: 7419 RVA: 0x00102548 File Offset: 0x00100748
        //		public void ReBattleItemFun(int oldv)
        //		{
        //			if (this.Data.HPMPDP.HP > 0 || GameStateManager.CurGameState != GameState.Battle)
        //			{
        //				return;
        //			}
        //			SymbolPanelItem symbolPanelItem = this.GetSlot(EquipSlotEnum.SymbolPanel) as SymbolPanelItem;
        //			if (symbolPanelItem == null)
        //			{
        //				return;
        //			}
        //			SymbolNodeItem nodeByType = symbolPanelItem.GetNodeByType(ItemManager.GetID(32u, 58u));
        //			if (nodeByType == null)
        //			{
        //				return;
        //			}
        //			ItemManager.GetInstance().RemoveItem(nodeByType.ID);
        //			this.Data.HPMPDP.HP = this.Data.HPMPDP.HPRange;
        //			BattleScriptInterface.RevivePlayer(this.Data.CharacterID);
        //		}

        //		// Token: 0x06001CFC RID: 7420 RVA: 0x001025E8 File Offset: 0x001007E8
        //		public bool IsCanEquipThisItem_ForLuoZhaoYan(IItem curOb)
        //		{
        //			FashionClothItem fashionClothItem = curOb as FashionClothItem;
        //			if (fashionClothItem == null)
        //			{
        //				return true;
        //			}
        //			uint characterMark = (fashionClothItem.ItemType as FashionClothItemType).CharacterMark;
        //			int num = 3;
        //			if (FlagManager.GetFlag(3) != 0)
        //			{
        //				num = 7;
        //			}
        //			int num2 = 1 << num;
        //			long num3 = (long)((ulong)characterMark & (ulong)((long)num2));
        //			return num3 != 0L;
        //		}

        //		// Token: 0x1700029A RID: 666
        //		// (get) Token: 0x06001CFD RID: 7421 RVA: 0x0010263C File Offset: 0x0010083C
        //		// (set) Token: 0x06001CFE RID: 7422 RVA: 0x00102644 File Offset: 0x00100844
        //		public PalNPC.NPCState State
        //		{
        //			get
        //			{
        //				return this.state;
        //			}
        //			set
        //			{
        //				if (value != this.state)
        //				{
        //					if (value != PalNPC.NPCState.Default)
        //					{
        //						if (value == PalNPC.NPCState.Patrol)
        //						{
        //							this.patrol.enabled = true;
        //						}
        //					}
        //					else
        //					{
        //						this.patrol.enabled = false;
        //					}
        //				}
        //			}
        //		}

        //		// Token: 0x1700029B RID: 667
        //		// (get) Token: 0x06001CFF RID: 7423 RVA: 0x00102694 File Offset: 0x00100894
        //		public Animator animator
        //		{
        //			get
        //			{
        //				if (this.m_animator == null && this.model != null)
        //				{
        //					this.m_animator = this.model.GetComponent<Animator>();
        //				}
        //				return this.m_animator;
        //			}
        //		}

        //		// Token: 0x1700029C RID: 668
        //		// (get) Token: 0x06001D00 RID: 7424 RVA: 0x001026D0 File Offset: 0x001008D0
        //		// (set) Token: 0x06001D01 RID: 7425 RVA: 0x001026D8 File Offset: 0x001008D8
        //		public Footmark footMark
        //		{
        //			get
        //			{
        //				return this.m_FootMark;
        //			}
        //			set
        //			{
        //				this.m_FootMark = value;
        //			}
        //		}

        //		// Token: 0x06001D02 RID: 7426 RVA: 0x001026E4 File Offset: 0x001008E4
        //		public override void Awake()
        //		{
        //			if (this.m_bDontLoadModel)
        //			{
        //				return;
        //			}
        //			base.Awake();
        //			if (base.gameObject.IsMonster())
        //			{
        //				CharactersManager.AddMonster(this);
        //			}
        //		}

        //		// Token: 0x06001D03 RID: 7427 RVA: 0x0010271C File Offset: 0x0010091C
        //		public override void Start()
        //		{
        //			if (this.IsMainCharAndExist())
        //			{
        //				UnityEngine.Object.DestroyImmediate(base.gameObject);
        //				return;
        //			}
        //			if (this.IsDataInit)
        //			{
        //				return;
        //			}
        //			base.Start();
        //			if (this.Data != null)
        //			{
        //				this.Data.Owner = base.gameObject;
        //				this.Data.Reset();
        //			}
        //			if (this.model == null)
        //			{
        //				this.LoadModel();
        //			}
        //			this.BuffDebuffData = new BuffDebuffManager.BuffDebuffOwner();
        //			this.BuffDebuffData.Owner = this;
        //			this.patrol = base.GetComponent<Patrol>();
        //			this.IsDataInit = true;
        //		}

        //		// Token: 0x06001D04 RID: 7428 RVA: 0x001027BC File Offset: 0x001009BC
        //		private bool IsMainCharAndExist()
        //		{
        //			if (StartInit.IsFirstStart)
        //			{
        //				return false;
        //			}
        //			int num = 0;
        //			if (int.TryParse(base.name, out num) && num >= 0 && num <= 7)
        //			{
        //				for (int i = 0; i < PlayersManager.AllPlayers.Count; i++)
        //				{
        //					GameObject gameObject = PlayersManager.AllPlayers[i];
        //					if (!(gameObject == null))
        //					{
        //						if (gameObject.name == base.name && gameObject != base.gameObject)
        //						{
        //							return true;
        //						}
        //					}
        //				}
        //				if (num == 6 && SceneManager.GetActiveScene().buildIndex == 0)
        //				{
        //					Debug.LogError(string.Format("[Error] : Try to load JiGuanXiong again in Title, don't load and exist.", new object[0]));
        //					return true;
        //				}
        //			}
        //			return false;
        //		}

        //		// Token: 0x06001D05 RID: 7429 RVA: 0x0010288C File Offset: 0x00100A8C
        //		private void AddColliderForGoToBattle()
        //		{
        //			SphereCollider sphereCollider = this.model.GetComponent<SphereCollider>();
        //			if (sphereCollider == null)
        //			{
        //				sphereCollider = this.model.AddComponent<SphereCollider>();
        //				CharacterController component = this.model.GetComponent<CharacterController>();
        //				if (component != null)
        //				{
        //					sphereCollider.radius = component.radius * this.BattleColR;
        //				}
        //				else
        //				{
        //					sphereCollider.radius = 1f;
        //				}
        //				sphereCollider.center += new Vector3(0f, sphereCollider.radius + this.BattleColH, 0f);
        //			}
        //			sphereCollider.isTrigger = true;
        //		}

        //		// Token: 0x06001D06 RID: 7430 RVA: 0x0010292C File Offset: 0x00100B2C
        //		public override void LoadModelEnd(UnityEngine.Object obj)
        //		{
        //			base.LoadModelEnd(obj);
        //			if (this.MonsterGroups.Length == 0 && this.model != null && base.gameObject.GetComponent<Interact>() != null && this.model.GetComponent<MouseEnterCursor>() == null)
        //			{
        //				MouseEnterCursor mouseEnterCursor = this.model.AddComponent<MouseEnterCursor>();
        //				mouseEnterCursor.curState = CursorTextureState.Talk;
        //			}
        //			if (this.model != null)
        //			{
        //				this.model.layer = SmoothFollow2.IgnoreLayer;
        //				this.model.ExcludeCloneName();
        //				Agent component = this.model.GetComponent<Agent>();
        //				if (component != null)
        //				{
        //					component.palNPC = this;
        //					if (component.agent != null && this.MonsterGroups.Length < 1)
        //					{
        //						component.agent.baseOffset = -0.1f;
        //						if (!NPCHeight.Instance.SetHeight(component.agent))
        //						{
        //							component.gameObject.AddComponent<AdjustNavAgentOffset>();
        //						}
        //					}
        //				}
        //				if (Application.isPlaying && this.Data.CharacterID > -1 && this.Data.CharacterID < 8)
        //				{
        //					this.GetOriRes();
        //				}
        //				this.Weapons.Clear();
        //				foreach (Transform transform in GameObjectPath.GetProps(this.model.transform))
        //				{
        //					if (!(transform == null))
        //					{
        //						if (transform.childCount < 1)
        //						{
        //							this.Weapons.Add(null);
        //						}
        //						else
        //						{
        //							this.Weapons.Add(transform.GetChild(0).gameObject);
        //						}
        //					}
        //				}
        //				if (this.Weapons.Count < 1 || (this.Weapons[0] == null && this.Weapons.Count > 1 && this.Weapons[1] == null))
        //				{
        //					this.Weapons.Clear();
        //					foreach (Transform transform2 in GameObjectPath.GetBoneProps(this.model.transform))
        //					{
        //						if (!(transform2 == null))
        //						{
        //							if (transform2.childCount < 1)
        //							{
        //								this.Weapons.Add(null);
        //							}
        //							else
        //							{
        //								this.Weapons.Add(transform2.GetChild(0).gameObject);
        //							}
        //						}
        //					}
        //				}
        //				if (this.Data != null && this.Data.CharacterID < 8 && this.Data.CharacterID > -1)
        //				{
        //					this.SetActiveWeaponInNormal(true);
        //				}
        //				else if (base.GetComponent<SaveTarget>() == null)
        //				{
        //					this.InitDisCull();
        //				}
        //				AnimCtrlScript component2 = this.model.GetComponent<AnimCtrlScript>();
        //				if (component2 != null)
        //				{
        //					component2.Start();
        //				}
        //				if (!OptionConfig.NeedOpt || (!string.IsNullOrEmpty(this.modelResourcePath) && this.modelResourcePath.Contains("NpcP6")))
        //				{
        //					ShroudInstance.Init(this.model);
        //				}
        //				else
        //				{
        //					ShroudInstance component3 = this.model.GetComponent<ShroudInstance>();
        //					UnityEngine.Object.Destroy(component3);
        //				}
        //				UtilFun.SetActive(this.model, this.bEnableOnLoadModelEnd);
        //				Vector3 position = this.model.transform.position;
        //				position.y += 0.5f;
        //				RaycastHit raycastHit;
        //				if (Physics.Raycast(position, Vector3.down, out raycastHit, 200f, SmoothFollow2.MaskValue))
        //				{
        //					UtilFun.SetPosition(this.model.transform, raycastHit.point);
        //				}
        //				int characterID = this.Data.CharacterID;
        //				if (characterID > -1 && characterID < 8 && characterID != 6)
        //				{
        //					this.footMark = this.model.AddComponent<Footmark>();
        //					string text = this.model.name;
        //					int num = text.IndexOf(' ');
        //					if (num > -1)
        //					{
        //						text = text.Substring(0, num + 1);
        //						this.model.name = text;
        //					}
        //				}
        //				if (((characterID < 8 && characterID != 6) || (characterID > 3999 && characterID < 4020) || this.MonsterGroups.Length > 0) && (characterID != 0 || this.modelResourcePath.Contains("YueJinChao")))
        //				{
        //					Perception.ActivePerception(this);
        //				}
        //				if (characterID < 8 && characterID != 6 && SceneManager.GetActiveScene().buildIndex == 0)
        //				{
        //					PlayersManager.AddPlayerPerceptionRange(this);
        //				}
        //				if (this.MonsterGroups.Length > 0 && this.model != null)
        //				{
        //					this.AddColliderForGoToBattle();
        //					MonsterStateScript.SetState(this.model, MonsterStateScript.MonsterState.None);
        //				}
        //				if (this.OnLoadModelEnd != null)
        //				{
        //					this.OnLoadModelEnd(this);
        //				}
        //			}
        //		}

        //		// Token: 0x06001D07 RID: 7431 RVA: 0x00102E2C File Offset: 0x0010102C
        //		public override void LoadModel()
        //		{
        //			if (SkillSEPreloader.s_preloadEnable && ScenesManager.IsChanging && SkillSEPreloader.Instance != null)
        //			{
        //				if (this.Data != null)
        //				{
        //					this.Data.Owner = base.gameObject;
        //					this.Data.Reset();
        //				}
        //				FightProperty fight = this.Data.Fight;
        //				if (fight != null)
        //				{
        //					int num = -1;
        //					int.TryParse(fight.BattleAIScript, out num);
        //					if (SkillSEPreloader.s_battleAISkillDic.ContainsKey(num))
        //					{
        //						List<int> list = SkillSEPreloader.s_battleAISkillDic[num];
        //						for (int i = 0; i < list.Count; i++)
        //						{
        //							Console.WriteLine(string.Format("[PreLoad Skill] : npc={0}, scriptID={1}, skillID={2}", base.gameObject.ToString(), num, list[i]));
        //							SkillSEPreloader.Instance.loadSkillSE(list[i]);
        //						}
        //					}
        //					SkillSEPreloader.Instance.m_preloadThisScene = true;
        //				}
        //				else if (this.MonsterGroups.Length != 0)
        //				{
        //					PalBattleManager palBattleManager = PalBattleManager.Instance();
        //					if (palBattleManager == null)
        //					{
        //						return;
        //					}
        //					MonsterGroupDataManager monsterGroupDataManager = palBattleManager.GetMonsterGroupDataManager();
        //					if (monsterGroupDataManager == null)
        //					{
        //						return;
        //					}
        //					foreach (int id in this.MonsterGroups)
        //					{
        //						MonsterGroupDataManager.MonsterGroupData data = monsterGroupDataManager.GetData(id);
        //						foreach (int num2 in data.mMonsters)
        //						{
        //							if (SkillSEPreloader.s_battleAISkillDic.ContainsKey(num2))
        //							{
        //								List<int> list2 = SkillSEPreloader.s_battleAISkillDic[num2];
        //								for (int k = 0; k < list2.Count; k++)
        //								{
        //									Console.WriteLine(string.Format("[PreLoad Skill] : npc={0}, scriptID={1}, skillID={2}", base.gameObject.ToString(), num2, list2[k]));
        //									SkillSEPreloader.Instance.loadSkillSE(list2[k]);
        //								}
        //							}
        //						}
        //						SkillSEPreloader.Instance.m_preloadThisScene = true;
        //					}
        //				}
        //			}
        //			if (this.m_bDontLoadModel)
        //			{
        //				this.LoadModelEnd(this);
        //				return;
        //			}
        //			Animator componentInChildren = base.GetComponentInChildren<Animator>();
        //			if (componentInChildren != null)
        //			{
        //				this.model = componentInChildren.gameObject;
        //			}
        //			if (this.model == null)
        //			{
        //				base.LoadModel();
        //			}
        //			else
        //			{
        //				this.LoadModelEnd(this);
        //			}
        //		}

        //		// Token: 0x06001D08 RID: 7432 RVA: 0x001030B8 File Offset: 0x001012B8
        //		private void OnDrawGizmos()
        //		{
        //			if (this.model != null)
        //			{
        //				Gizmos.DrawIcon(this.model.transform.position, "npcicon", true);
        //			}
        //			else if (base.GetComponentInChildren<Animator>() != null)
        //			{
        //				Gizmos.DrawIcon(base.GetComponentInChildren<Animator>().transform.position, "npcicon", true);
        //			}
        //			else
        //			{
        //				Gizmos.DrawIcon(base.transform.position, "npcicon", true);
        //			}
        //		}

        //		// Token: 0x1700029D RID: 669
        //		// (get) Token: 0x06001D09 RID: 7433 RVA: 0x00103140 File Offset: 0x00101340
        //		public override string[] AvailableComponentNames
        //		{
        //			get
        //			{
        //				return new string[]
        //				{
        //					"Patrol",
        //					"MoveByPalCurve"
        //				};
        //			}
        //		}

        //		// Token: 0x06001D0A RID: 7434 RVA: 0x00103158 File Offset: 0x00101358
        //		public static Type GetComponentTypeByName(string name)
        //		{
        //			if (string.IsNullOrEmpty(name))
        //			{
        //				return null;
        //			}
        //			Type typeFromHandle = typeof(Component);
        //			foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
        //			{
        //				foreach (Type type in assembly.GetTypes())
        //				{
        //					if (typeFromHandle.IsAssignableFrom(type) && type.Name == name)
        //					{
        //						return type;
        //					}
        //				}
        //			}
        //			return null;
        //		}

        //		// Token: 0x06001D0B RID: 7435 RVA: 0x001031EC File Offset: 0x001013EC
        //		public override void AddComponentByName(string componentName)
        //		{
        //			if (base.GetComponent(componentName) != null)
        //			{
        //				Debug.LogWarning("AddComponentByName Exception, component " + componentName + " already exist.");
        //			}
        //			if (componentName != null)
        //			{
        //				if (PalNPC.<>f__switch$map17 == null)
        //				{
        //					PalNPC.<>f__switch$map17 = new Dictionary<string, int>(1)
        //					{
        //						{
        //							"Patrol",
        //							0
        //						}
        //					};
        //				}
        //				int num;
        //				if (PalNPC.<>f__switch$map17.TryGetValue(componentName, out num))
        //				{
        //					if (num != 0)
        //					{
        //					}
        //				}
        //			}
        //			Component x = base.gameObject.AddComponent(PalNPC.GetComponentTypeByName(componentName));
        //			if (x == null)
        //			{
        //				Debug.LogWarning("AddComponentByName Exception, create " + componentName + " failed.");
        //			}
        //			if (componentName != null)
        //			{
        //				if (PalNPC.<>f__switch$map18 == null)
        //				{
        //					PalNPC.<>f__switch$map18 = new Dictionary<string, int>(1)
        //					{
        //						{
        //							"Patrol",
        //							0
        //						}
        //					};
        //				}
        //				int num;
        //				if (PalNPC.<>f__switch$map18.TryGetValue(componentName, out num))
        //				{
        //					if (num != 0)
        //					{
        //					}
        //				}
        //			}
        //		}

        //		// Token: 0x06001D0C RID: 7436 RVA: 0x001032F0 File Offset: 0x001014F0
        //		public override void RemoveComponentByName(string componentName)
        //		{
        //			Component component = base.GetComponent(componentName);
        //			if (component == null)
        //			{
        //				Debug.LogWarning("RemoveComponentByName Exception, cant find " + componentName + ".");
        //			}
        //			if (componentName != null)
        //			{
        //				if (PalNPC.<>f__switch$map19 == null)
        //				{
        //					PalNPC.<>f__switch$map19 = new Dictionary<string, int>(1)
        //					{
        //						{
        //							"Patrol",
        //							0
        //						}
        //					};
        //				}
        //				int num;
        //				if (PalNPC.<>f__switch$map19.TryGetValue(componentName, out num))
        //				{
        //					if (num != 0)
        //					{
        //					}
        //				}
        //			}
        //			UnityEngine.Object.DestroyImmediate(component);
        //			if (componentName != null)
        //			{
        //				if (PalNPC.<>f__switch$map1A == null)
        //				{
        //					PalNPC.<>f__switch$map1A = new Dictionary<string, int>(1)
        //					{
        //						{
        //							"Patrol",
        //							0
        //						}
        //					};
        //				}
        //				int num;
        //				if (PalNPC.<>f__switch$map1A.TryGetValue(componentName, out num))
        //				{
        //					if (num != 0)
        //					{
        //					}
        //				}
        //			}
        //		}

        //		// Token: 0x06001D0D RID: 7437 RVA: 0x001033C8 File Offset: 0x001015C8
        //		public static PalNPC FindTheNPC(Transform transform)
        //		{
        //			Transform transform2 = transform;
        //			while (transform2 != null)
        //			{
        //				PalNPC component = transform2.GetComponent<PalNPC>();
        //				if (component != null)
        //				{
        //					return component;
        //				}
        //				transform2 = transform2.parent;
        //			}
        //			return null;
        //		}

        //		// Token: 0x06001D0E RID: 7438 RVA: 0x00103408 File Offset: 0x00101608
        //		public static float GetRadius(GameObject npcObj)
        //		{
        //			float result = 3f;
        //			NavMeshAgent component = npcObj.GetComponent<NavMeshAgent>();
        //			if (component != null)
        //			{
        //				result = component.radius;
        //			}
        //			else
        //			{
        //				CharacterController component2 = npcObj.GetComponent<CharacterController>();
        //				if (component2 != null)
        //				{
        //					result = component2.radius;
        //				}
        //				else if (npcObj.GetComponent<Collider>() != null)
        //				{
        //					SphereCollider component3 = npcObj.GetComponent<SphereCollider>();
        //					if (component3 != null)
        //					{
        //						result = component3.radius;
        //					}
        //					else
        //					{
        //						CapsuleCollider component4 = npcObj.GetComponent<CapsuleCollider>();
        //						if (component4 != null)
        //						{
        //							result = component4.radius;
        //						}
        //						else
        //						{
        //							result = npcObj.GetComponent<Collider>().bounds.extents.magnitude;
        //						}
        //					}
        //				}
        //			}
        //			return result;
        //		}

        //		// Token: 0x06001D0F RID: 7439 RVA: 0x001034CC File Offset: 0x001016CC
        //		public Vector3 GetAimPos(GameObject npcObj)
        //		{
        //			float radius = PalNPC.GetRadius(npcObj);
        //			Vector3 vector = base.transform.position - npcObj.transform.position;
        //			vector.Normalize();
        //			switch (this.personalityType)
        //			{
        //			case NPCPersonalityType.subtle:
        //				vector = npcObj.transform.rotation * Vector3.back;
        //				break;
        //			}
        //			NavMeshAgent component = base.GetComponent<NavMeshAgent>();
        //			if (component == null)
        //			{
        //				Debug.LogWarning(base.name + "没有NavMeshAgent");
        //				return base.transform.position;
        //			}
        //			vector *= radius + component.radius + this.CurFightDistance;
        //			return npcObj.transform.position + vector;
        //		}

        public void Save(BinaryWriter writer)
        {
            //this.Data.Save(writer);
            //this.BuffDebuffData.Save(writer);
            //List<uint> list = new List<uint>();
            //int count = this.mEquipSlots.Values.Count;
            //if (count < 1 && this.Data != null && this.Data.CharacterID > -1 && this.Data.CharacterID < 6)
            //{
            //    Debug.LogError("警告：" + base.name + " 的 mEquipSlots.Values.Count==0");
            //}
            //UtilFun.ConsoleLog("Log : " + base.name + "  PalNPC.Save  mEquipSlots.Values.Count ==" + count.ToString(), false);
            //foreach (KeyValuePair<EquipSlotEnum, ItemWatcher> keyValuePair in this.mEquipSlots)
            //{
            //    if (keyValuePair.Value == null || keyValuePair.Value.Target == null)
            //    {
            //        if (this.Data != null && this.Data.CharacterID > -1 && this.Data.CharacterID < 6)
            //        {
            //            Debug.LogError(string.Concat(new string[]
            //            {
            //                        "警告：",
            //                        base.name,
            //                        " 的 ",
            //                        keyValuePair.Key.ToString(),
            //                        " 的 ",
            //                        (keyValuePair.Value != null) ? "cur.Value.Target == null" : "cur.Value == null"
            //            }));
            //        }
            //    }
            //    else
            //    {
            //        list.Add(keyValuePair.Value.Target.ID);
            //    }
            //}
            //UtilFun.ConsoleLog("Log : " + base.name + " PalNPC.Save 装备链接数=" + list.Count.ToString(), false);
            //if (list.Count < 1 && this.Data != null && this.Data.CharacterID > -1 && this.Data.CharacterID < 6)
            //{
            //    Debug.LogError("警告：" + base.name + " 的 装备链接数 = 0 ！！！！！！！！！！！！！！！！！！！！");
            //}
            //writer.Write(list.Count);
            //using (List<uint>.Enumerator enumerator2 = list.GetEnumerator())
            //{
            //    while (enumerator2.MoveNext())
            //    {
            //        int value = (int)enumerator2.Current;
            //        writer.Write(value);
            //    }
            //}
            //writer.Write((int)this.mCurrentAchievement);
            //int count2 = this.m_SkillIDs.Count;
            //writer.Write(count2);
            //for (int i = 0; i < count2; i++)
            //{
            //    writer.Write(this.m_SkillIDs[i].m_ID);
            //    writer.Write(this.m_SkillIDs[i].m_bOpen);
            //    writer.Write(this.m_SkillIDs[i].m_CurrentExp);
            //}
            //writer.Write((int)this.m_curObjType);
        }

        public void Load(BinaryReader reader)
        {
            //this.Data.Load(reader);
            //this.ExpRate = 1f;
            //this.ImmunityAllBadBattleStates = 0;
            //this.FengYinAddRate = 0f;
            //this.MiaoShouAddRate = 0f;
            //this.BreakAddRate = 0f;
            //this.BuffDebuffData = new BuffDebuffManager.BuffDebuffOwner();
            //this.BuffDebuffData.Owner = this;
            //this.BuffDebuffData.Load(reader);
            //int num = reader.ReadInt32();
            //UtilFun.ConsoleLog("Log : " + base.name + " PalNPC.Load 装备链接数=" + num.ToString(), false);
            //if (!SaveManager.IsErZhouMu || SaveManager.inheritStruct.Item)
            //{
            //    this.mLoadEquipSlots = new uint[num];
            //    for (int i = 0; i < this.mLoadEquipSlots.Length; i++)
            //    {
            //        this.mLoadEquipSlots[i] = reader.ReadUInt32();
            //    }
            //}
            //else
            //{
            //    this.mLoadEquipSlots = new uint[0];
            //    for (int j = 0; j < num; j++)
            //    {
            //        reader.ReadUInt32();
            //    }
            //}
            //int num2 = reader.ReadInt32();
            //try
            //{
            //    if (num2 >= 0)
            //    {
            //        if (num2 < PalBattleManager.Instance().m_Achievement.m_Achievements.Length && PalBattleManager.Instance().m_Achievement.m_Achievements[num2] == null)
            //        {
            //            num2 = -1;
            //        }
            //    }
            //    else
            //    {
            //        num2 = -1;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    num2 = -1;
            //    Debug.LogError(ex.ToString());
            //}
            //this.mCurrentAchievement = (AchievementManager.ACHIEVEMENT_INDEX)num2;
            //if (SaveManager.VersionNum >= 9u)
            //{
            //    int num3 = reader.ReadInt32();
            //    this.m_SkillIDs.Clear();
            //    for (int k = 0; k < num3; k++)
            //    {
            //        this.AddSkillNoRepeat(new PalNPC.SkillInfo
            //        {
            //            m_ID = reader.ReadInt32(),
            //            m_bOpen = reader.ReadBoolean(),
            //            m_CurrentExp = reader.ReadInt32()
            //        });
            //    }
            //}
            //this.m_curObjType = (ObjType)reader.ReadInt32();
            //if (this.Data.HPMPDP != null)
            //{
            //    this.Data.HPMPDP.SetWithoutEvents(this.Data.LoadHP, this.Data.LoadMP, this.Data.LoadDP);
            //}
        }

        //		// Token: 0x06001D12 RID: 7442 RVA: 0x00103B1C File Offset: 0x00101D1C
        //		public IEnumerator Prepare()
        //		{
        //			if (this.model == null)
        //			{
        //				this.LoadModel();
        //			}
        //			IEnumerator result = this.BuffDebuffData.Prepare();
        //			while (result.MoveNext())
        //			{
        //				yield return null;
        //			}
        //			if (!SaveManager.IsErZhouMu || SaveManager.inheritStruct.Item)
        //			{
        //				this.mEquipSlots.Clear();
        //				if (this.mLoadEquipSlots != null)
        //				{
        //					foreach (uint cur in this.mLoadEquipSlots)
        //					{
        //						IItem curItem;
        //						for (curItem = ItemManager.GetInstance().GetItem(cur); curItem == null; curItem = ItemManager.GetInstance().GetItem(cur))
        //						{
        //							yield return null;
        //						}
        //						while (!curItem.IsInitialized)
        //						{
        //							yield return null;
        //						}
        //						if (this.Data != null && this.Data.CharacterID == 3)
        //						{
        //							if (this.IsCanEquipThisItem_ForLuoZhaoYan(curItem))
        //							{
        //								this.LoadLink(curItem as IItemAssemble<PalNPC>);
        //							}
        //						}
        //						else
        //						{
        //							this.LoadLink(curItem as IItemAssemble<PalNPC>);
        //						}
        //					}
        //					this.mLoadEquipSlots = null;
        //				}
        //				else
        //				{
        //					Debug.LogError(base.gameObject.name + "本来mLoadEquipSlots==null");
        //				}
        //			}
        //			AchievementManager.ACHIEVEMENT_INDEX TempCurrentAchievement = this.mCurrentAchievement;
        //			this.mCurrentAchievement = (AchievementManager.ACHIEVEMENT_INDEX)(-1);
        //			this.CurrentAchievement = TempCurrentAchievement;
        //			yield break;
        //		}

        //		// Token: 0x06001D13 RID: 7443 RVA: 0x00103B38 File Offset: 0x00101D38
        //		public int GetSkillGroup()
        //		{
        //			return this.m_SkillGroup;
        //		}

        //		// Token: 0x06001D14 RID: 7444 RVA: 0x00103B40 File Offset: 0x00101D40
        //		public void SetSkillGroup(int sg)
        //		{
        //			this.m_SkillGroup = sg;
        //		}

        //		// Token: 0x06001D15 RID: 7445 RVA: 0x00103B4C File Offset: 0x00101D4C
        //		public void SetDontLoadModel(bool b)
        //		{
        //			this.m_bDontLoadModel = b;
        //		}

        //		// Token: 0x06001D16 RID: 7446 RVA: 0x00103B58 File Offset: 0x00101D58
        //		private void Update()
        //		{
        //			if (this.ProcessCore != null)
        //			{
        //				this.ProcessCore();
        //			}
        //		}

        //		// Token: 0x06001D17 RID: 7447 RVA: 0x00103B70 File Offset: 0x00101D70
        //		private void InitDisCull()
        //		{
        //			this.modelTF = this.model.transform;
        //			this.ProcessCore = new Action(this.DisCull);
        //			this.curTime = UnityEngine.Random.Range(3f, 3f + PalNPC.interval);
        //			if (this.MonsterGroups.Length > 0)
        //			{
        //				this.isMonster = true;
        //			}
        //			else
        //			{
        //				this.isMonster = false;
        //			}
        //		}

        //		// Token: 0x06001D18 RID: 7448 RVA: 0x00103BDC File Offset: 0x00101DDC
        //		public void RemoveDisCull()
        //		{
        //			this.ProcessCore = null;
        //		}

        //		// Token: 0x06001D19 RID: 7449 RVA: 0x00103BE8 File Offset: 0x00101DE8
        //		private void DisCull()
        //		{
        //			this.curTime -= Time.deltaTime;
        //			if (this.curTime > 0f)
        //			{
        //				return;
        //			}
        //			this.curTime = PalNPC.interval;
        //			if (GameStateManager.CurGameState != GameState.Normal)
        //			{
        //				return;
        //			}
        //			if (PalBattleManager.Instance() != null && !PalBattleManager.Instance().IsLoadingFinished)
        //			{
        //				Debug.Log("Wait for battle loading");
        //				return;
        //			}
        //			if (this.modelTF == null)
        //			{
        //				return;
        //			}
        //			Vector3 position = this.modelTF.position;
        //			Vector3 vector = PalMain.MainCameraTF.position;
        //			float num = 0f;
        //			float num2 = DistanceCullManager.Instance.GetCameraDistanceValue();
        //			if (PalNPC.SevereCull)
        //			{
        //				num = num2 * PalNPC.CullCamOffsetRatio;
        //			}
        //			num2 = num2 + 2f - num;
        //			if (PalNPC.SevereCull)
        //			{
        //				Vector3 forward = PalMain.MainCameraTF.forward;
        //				forward.y = 0f;
        //				vector += forward.normalized * num;
        //			}
        //			Vector3 vector2 = position - vector;
        //			float magnitude = vector2.magnitude;
        //			if (magnitude > num2 || vector2.y < -20f || vector2.y > 20f)
        //			{
        //				if (this.model.activeSelf)
        //				{
        //					this.SetActiveModel(false);
        //				}
        //			}
        //			else if (!this.model.activeSelf)
        //			{
        //				this.SetActiveModel(true);
        //			}
        //		}

        //		// Token: 0x06001D1A RID: 7450 RVA: 0x00103D50 File Offset: 0x00101F50
        //		private void SetActiveModel(bool bValue)
        //		{
        //			if (!bValue)
        //			{
        //				this.uScriptsName.Clear();
        //				Animator animator = this.animator;
        //				if (animator != null)
        //				{
        //					float @float = animator.GetFloat("Speed");
        //					bool @bool = animator.GetBool("Move");
        //					if (!@bool || @float <= 0f)
        //					{
        //						AnimatorClipInfo[] currentAnimatorClipInfo = animator.GetCurrentAnimatorClipInfo(0);
        //						if (currentAnimatorClipInfo.Length > 0)
        //						{
        //							AnimatorClipInfo animatorClipInfo = currentAnimatorClipInfo[0];
        //							this.curAnimName = animatorClipInfo.clip.name;
        //						}
        //					}
        //					else
        //					{
        //						this.curAnimName = null;
        //					}
        //				}
        //				this.model.SetActive(bValue);
        //			}
        //			else
        //			{
        //				if (this.isMonster)
        //				{
        //					ReSpawnMonster component = base.GetComponent<ReSpawnMonster>();
        //					if (component != null)
        //					{
        //						return;
        //					}
        //				}
        //				this.model.SetActive(bValue);
        //				if (!string.IsNullOrEmpty(this.curAnimName))
        //				{
        //					AnimCtrlScript component2 = this.model.GetComponent<AnimCtrlScript>();
        //					if (component2 != null)
        //					{
        //						component2.ActiveAnimCrossFade(this.curAnimName, false, 0f, true);
        //					}
        //					this.curAnimName = null;
        //				}
        //			}
        //			foreach (uScriptCode uScriptCode in base.GetComponents<uScriptCode>())
        //			{
        //				string name = uScriptCode.GetType().Name;
        //				if (bValue)
        //				{
        //					if (this.uScriptsName.Contains(name))
        //					{
        //						uScriptCode.enabled = true;
        //					}
        //				}
        //				else if (uScriptCode.enabled)
        //				{
        //					this.uScriptsName.Add(name);
        //					uScriptCode.enabled = false;
        //				}
        //			}
        //			FollowTarget component3 = base.GetComponent<FollowTarget>();
        //			if (component3 != null)
        //			{
        //				component3.enabled = bValue;
        //			}
        //		}

        [SerializeField]
        [HideInInspector]
        public PalNPC.CharacterData Data;

        //		// Token: 0x040020C6 RID: 8390
        //		[NonSerialized]
        //		public BuffDebuffManager.BuffDebuffOwner BuffDebuffData;

        //		// Token: 0x040020C7 RID: 8391
        //		public int[] MonsterGroups;

        //		// Token: 0x040020C8 RID: 8392
        //		public int mBattleFieldID;

        //		// Token: 0x040020C9 RID: 8393
        //		public AudioClip m_BeHitSound;

        //		// Token: 0x040020CA RID: 8394
        //		private static int[] mAdvanceSkillIDs;

        //		// Token: 0x040020CB RID: 8395
        //		public List<PalNPC.SkillInfo> m_SkillIDs;

        //		// Token: 0x040020CC RID: 8396
        //		[NonSerialized]
        //		public float ExpRate;

        //		// Token: 0x040020CD RID: 8397
        //		[NonSerialized]
        //		public int ImmunityAllBadBattleStates;

        //		// Token: 0x040020CE RID: 8398
        //		[NonSerialized]
        //		public float FengYinAddRate;

        //		// Token: 0x040020CF RID: 8399
        //		[NonSerialized]
        //		public float MiaoShouAddRate;

        //		// Token: 0x040020D0 RID: 8400
        //		[NonSerialized]
        //		public float BreakAddRate;

        //		// Token: 0x040020D1 RID: 8401
        //		[NonSerialized]
        //		public List<GameObject> Weapons = new List<GameObject>(2);

        //		// Token: 0x040020D2 RID: 8402
        //		[NonSerialized]
        //		public GameObject ornament;

        //		// Token: 0x040020D3 RID: 8403
        //		[NonSerialized]
        //		public Texture oriMainTex;

        //		// Token: 0x040020D4 RID: 8404
        //		[NonSerialized]
        //		public Texture oriSpecTex;

        //		// Token: 0x040020D5 RID: 8405
        //		private Material m_oriAssortMat;

        //		// Token: 0x040020D6 RID: 8406
        //		private GameObject weaponAssortObj;

        //		// Token: 0x040020D7 RID: 8407
        //		[NonSerialized]
        //		private uint[] mLoadEquipSlots;

        //		// Token: 0x040020D8 RID: 8408
        //		[NonSerialized]
        //		private Dictionary<EquipSlotEnum, ItemWatcher> mEquipSlots = new Dictionary<EquipSlotEnum, ItemWatcher>();

        //		// Token: 0x040020D9 RID: 8409
        //		private AchievementManager.ACHIEVEMENT_INDEX mCurrentAchievement = (AchievementManager.ACHIEVEMENT_INDEX)(-1);

        //		// Token: 0x040020DA RID: 8410
        //		protected PalNPC.NPCState state;

        //		// Token: 0x040020DB RID: 8411
        //		public PalNPC.void_fun_TF OnLoadModelEnd;

        //		// Token: 0x040020DC RID: 8412
        //		public bool bEnableOnLoadModelEnd = true;

        //		// Token: 0x040020DD RID: 8413
        //		private Animator m_animator;

        //		// Token: 0x040020DE RID: 8414
        //		public Patrol patrol;

        //		// Token: 0x040020DF RID: 8415
        //		public NPCMode curNPCMode = NPCMode.fight;

        //		// Token: 0x040020E0 RID: 8416
        //		public NPCPersonalityType personalityType;

        //		// Token: 0x040020E1 RID: 8417
        //		public Perception perception;

        //		// Token: 0x040020E2 RID: 8418
        //		public float hatred = 50f;

        //		// Token: 0x040020E3 RID: 8419
        //		public float CurFightDistance = 0.5f;

        //		// Token: 0x040020E4 RID: 8420
        //		public string PrefabID = string.Empty;

        //		// Token: 0x040020E5 RID: 8421
        //		private bool IsDataInit;

        //		// Token: 0x040020E6 RID: 8422
        //		private Footmark m_FootMark;

        //		// Token: 0x040020E7 RID: 8423
        //		public float BattleColR = 1.67f;

        //		// Token: 0x040020E8 RID: 8424
        //		public float BattleColH = 0.1f;

        //		// Token: 0x040020E9 RID: 8425
        //		public List<Interact> interActs = new List<Interact>();

        //		// Token: 0x040020EA RID: 8426
        //		private int m_SkillGroup;

        //		// Token: 0x040020EB RID: 8427
        //		private bool m_bDontLoadModel;

        //		// Token: 0x040020EC RID: 8428
        //		private Action ProcessCore;

        //		// Token: 0x040020ED RID: 8429
        //		public static float interval = 1f;

        //		// Token: 0x040020EE RID: 8430
        //		private float curTime = 0.23f;

        //		// Token: 0x040020EF RID: 8431
        //		private Transform modelTF;

        //		// Token: 0x040020F0 RID: 8432
        //		private bool isMonster;

        //		// Token: 0x040020F1 RID: 8433
        //		public static bool SevereCull = true;

        //		// Token: 0x040020F2 RID: 8434
        //		public static float CullCamOffsetRatio = 0.35f;

        //		// Token: 0x040020F3 RID: 8435
        //		private List<string> uScriptsName = new List<string>();

        //		// Token: 0x040020F4 RID: 8436
        //		private string curAnimName;

        [Serializable]
        public class CharacterData : ISaveInterface
        {
            [NonSerialized]
            private GameObject mOwner;

            //[NonSerialized]
            //private PlayerBaseProperty mPlayerBase;

            [NonSerialized]
            private HPMPDPProperty mHPMPDP;

            [NonSerialized]
            private FightProperty mFight;

            //[NonSerialized]
            //private CharacterProperty mCharacter;

            //[NonSerialized]
            //private PlayerProperty mPlayer;

            //[NonSerialized]
            //private SocialNPCProperty mSocialNPC;

            //[NonSerialized]
            //private MonsterProperty mMonster;

            [SerializeField]
            private int mCharacterID;

            [SerializeField]
            private int mLevel;

            [NonSerialized]
            private int mExp;

            [NonSerialized]
            private int mSoul;

            [NonSerialized]
            public int LoadHP;

            [NonSerialized]
            public int LoadMP;

            [NonSerialized]
            public int LoadDP;
            public GameObject Owner
            {
                get
                {
                    return this.mOwner;
                }
                set
                {
                    this.mOwner = value;
                }
            }

            //public PlayerBaseProperty PlayerBase
            //{
            //    get
            //    {
            //        return this.mPlayerBase;
            //    }
            //}

            public HPMPDPProperty HPMPDP
            {
                get
                {
                    return this.mHPMPDP;
                }
            }

            public FightProperty Fight
            {
                get
                {
                    return this.mFight;
                }
            }

            //public CharacterProperty CharacterCommon
            //{
            //    get
            //    {
            //        return this.mCharacter;
            //    }
            //}

            //public PlayerProperty Player
            //{
            //    get
            //    {
            //        return this.mPlayer;
            //    }
            //}

            //public SocialNPCProperty SocialNPC
            //{
            //    get
            //    {
            //        if (this.mSocialNPC == null)
            //        {
            //            string message = "Error : 严重错误！！！ npc[" + ((!(this.Owner != null)) ? this.CharacterID.ToString() : this.Owner.name) + "] SocialNPC==null";
            //            Debug.LogError(message);
            //        }
            //        return this.mSocialNPC;
            //    }
            //}

            //public MonsterProperty Monster
            //{
            //    get
            //    {
            //        return this.mMonster;
            //    }
            //}

            public int CharacterID
            {
                get
                {
                    return this.mCharacterID;
                }
            }

            public int Level
            {
                get
                {
                    return this.mLevel;
                }
                private set
                {
                    if (this.mLevel != value)
                    {
                        //if (this.mPlayerBase != null)
                        //{
                        //    uint characterID = (uint)this.mCharacterID;
                        //    int oldLevel = this.mLevel;
                        //    this.mLevel = value;
                        //    this.mPlayerBase.ChangeLevel(characterID, this.mLevel);
                        //    ChangeLevelScript.OnChangeLevel(characterID, oldLevel, this.mLevel, this.mOwner);
                        //}
                        //else
                        //{
                        //    this.mLevel = value;
                        //}
                        //if (this.mHPMPDP != null)
                        //{
                        //    this.mHPMPDP.HP = this.mHPMPDP.HPRange;
                        //    this.mHPMPDP.MP = this.mHPMPDP.MPRange;
                        //}
                    }
                }
            }

            public int Exp
            {
                get
                {
                    return this.mExp;
                }
                set
                {
                    if (this.mExp != value)
                    {
                        try
                        {
                            this.mExp = value;
                            //this.Level = PlayerBaseProperty.LevelData.FindLevel(this.mExp);
                        }
                        catch (Exception ex)
                        {
                            Debug.LogException(ex);
                           // UIDialogManager.Instance.ShowNoForceInfoDialog(ex.ToString(), 60f);
                        }
                    }
                }
            }

            //public int NeedExp
            //{
            //    get
            //    {
            //        return PlayerBaseProperty.LevelData.GetLevelExp(this.mLevel) - this.mExp;
            //    }
            //}

            public int Soul
            {
                get
                {
                    return this.mSoul;
                }
                set
                {
                    this.mSoul = value;
                }
            }

            public void initialization(GameObject inOwner, int inCharacterID, int inLevel)
            {
                this.mOwner = inOwner;
                this.mCharacterID = inCharacterID;
                this.Reset();
                this.Level = inLevel;
            }

            public void initialization(GameObject inOwner, uint inCharacterID, int inLevel)
            {
                this.initialization(inOwner, (int)inCharacterID, inLevel);
            }

            public void Reset()
            {
                uint num = (uint)this.mCharacterID;
                //if (this.mPlayerBase != null)
                //{
                //    this.mPlayerBase = null;
                //}
                //PlayerBaseProperty.PlayerBaseData data = PlayerBaseProperty.GetData(num, this.Level);
                //if (data != null)
                //{
                //    this.mPlayerBase = new PlayerBaseProperty(data);
                //}
                //if (this.mHPMPDP != null)
                //{
                //    this.mHPMPDP.UnLink();
                //    this.mHPMPDP = null;
                //}
                HPMPDPProperty.StaticData data2 = HPMPDPProperty.StaticData.GetData(num);
                if (data2 != null)
                {
                   // this.mHPMPDP = new HPMPDPProperty(data2);
                }
                if (this.mFight != null)
                {
                   // this.mFight.UnLink();
                    this.mFight = null;
                }
                FightProperty.StaticData data3 = FightProperty.StaticData.GetData(num);
                if (data3 != null)
                {
                    //this.mFight = new FightProperty(data3);
                }
                if (this.mHPMPDP != null)
                {
                   // this.mHPMPDP.LinkPlayerBase = this.mPlayerBase;
                   // this.mHPMPDP.SetWithoutEvents(this.mHPMPDP.HPRange, 0, 0);
                }
                if (this.mFight != null)
                {
                    //this.mFight.LinkPlayerBase = this.mPlayerBase;
                }
                //CharacterProperty.StaticData data4 = CharacterProperty.StaticData.GetData(num);
                //if (data4 != null)
                //{
                //    //this.mCharacter = new CharacterProperty(data4);
                //}
                //else
                //{
                //    this.mCharacter = null;
                //}
                //PlayerProperty.StaticData data5 = PlayerProperty.StaticData.GetData(num);
                //if (data5 != null)
                //{
                //    this.mPlayer = new PlayerProperty(data5);
                //}
                //else
                //{
                //    this.mPlayer = null;
                //}
                //SocialNPCProperty.StaticData data6 = SocialNPCProperty.StaticData.GetData(num);
                //if (data6 != null)
                //{
                //    this.mSocialNPC = new SocialNPCProperty(data6);
                //}
                //else
                //{
                //    this.mSocialNPC = null;
                //}
                //MonsterProperty.StaticData data7 = MonsterProperty.StaticData.GetData(num);
                //if (data7 != null)
                //{
                //    this.mMonster = new MonsterProperty(data7);
                //}
                //else
                //{
                //    this.mMonster = null;
                //}
            }

            public void Save(BinaryWriter writer)
            {
                writer.Write(this.mCharacterID);
                if (this.mHPMPDP != null)
                {
                    //writer.Write(this.mHPMPDP.HP);
                    //writer.Write(this.mHPMPDP.MP);
                    //writer.Write(this.mHPMPDP.DP);
                }
                else
                {
                    writer.Write(0);
                    writer.Write(0);
                    writer.Write(0);
                }
                writer.Write(this.mExp);
                writer.Write(this.mSoul);
            }

            public void Load(BinaryReader reader)
            {
                this.mCharacterID = reader.ReadInt32();
                this.LoadHP = reader.ReadInt32();
                this.LoadMP = reader.ReadInt32();
                this.LoadDP = reader.ReadInt32();
                //if (SaveManager.VersionNum < 21u)
                //{
                //    this.mLevel = reader.ReadInt32();
                //}
                this.mExp = reader.ReadInt32();
                //this.mLevel = PlayerBaseProperty.LevelData.FindLevel(this.mExp);
                this.mSoul = reader.ReadInt32();
                this.Reset();
            }
        }

        [Serializable]
        public class SkillInfo
        {
            public int m_ID;

            public bool m_bOpen = true;

            public int m_CurrentExp;
        }

        public enum NPCState
        {
            Default,
            Patrol,
            Guard,
            Die
        }
    }
}
