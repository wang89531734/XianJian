using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
//using Funfia;
//using Funfia.File;
using SoftStar;
using SoftStar.Item;
using SoftStar.Pal6;
//using SoftStar.Pal6.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class UtilFun
{
    //	// Token: 0x06003EDA RID: 16090 RVA: 0x001C1528 File Offset: 0x001BF728
    //	public static void SetVisible(this GameObject go, bool bVisible)
    //	{
    //		if (go == null)
    //		{
    //			UnityEngine.Debug.LogError("Error : UtilFun.SetVisible go==null");
    //			return;
    //		}
    //		ShroudInstance[] componentsInChildren = go.GetComponentsInChildren<ShroudInstance>(true);
    //		foreach (ShroudInstance shroudInstance in componentsInChildren)
    //		{
    //			shroudInstance.enabled = bVisible;
    //		}
    //		Perception perception = null;
    //		Perception[] componentsInChildren2 = go.GetComponentsInChildren<Perception>(true);
    //		if (componentsInChildren2 != null && componentsInChildren2.Length > 0)
    //		{
    //			perception = componentsInChildren2[0];
    //		}
    //		Renderer[] componentsInChildren3 = go.GetComponentsInChildren<Renderer>(true);
    //		foreach (Renderer renderer in componentsInChildren3)
    //		{
    //			if (perception == null || perception.gameObject != renderer.gameObject)
    //			{
    //				renderer.enabled = bVisible;
    //			}
    //		}
    //	}

    //	// Token: 0x06003EDB RID: 16091 RVA: 0x001C15F4 File Offset: 0x001BF7F4
    //	public static void GetVisible(this GameObject go)
    //	{
    //		string text = "---------- " + go.name + " Visible 信息  --------------";
    //		Renderer[] componentsInChildren = go.GetComponentsInChildren<Renderer>(true);
    //		foreach (Renderer renderer in componentsInChildren)
    //		{
    //			bool enabled = renderer.enabled;
    //			string text2 = text;
    //			text = string.Concat(new string[]
    //			{
    //				text2,
    //				"\n ",
    //				renderer.name,
    //				" ",
    //				enabled.ToString()
    //			});
    //		}
    //		text += "\n----------- over -----------";
    //		UnityEngine.Debug.Log(text);
    //	}

    //	// Token: 0x06003EDC RID: 16092 RVA: 0x001C1690 File Offset: 0x001BF890
    //	public static void SetAllComponentActive(GameObject go, bool bActive, params Type[] exceptTypes)
    //	{
    //		Component[] componentsInChildren = go.GetComponentsInChildren<Component>(true);
    //		foreach (Component component in componentsInChildren)
    //		{
    //			if (!(component == null))
    //			{
    //				bool flag = false;
    //				foreach (Type type in exceptTypes)
    //				{
    //					if (component.GetType() == type)
    //					{
    //						flag = true;
    //						break;
    //					}
    //				}
    //				if (!flag)
    //				{
    //					Type type2 = component.GetType();
    //					if (type2 == typeof(CharacterController))
    //					{
    //						CharacterController characterController = component as CharacterController;
    //						if (characterController != null)
    //						{
    //							characterController.enabled = bActive;
    //						}
    //					}
    //					else if (type2 == typeof(NavMeshAgent))
    //					{
    //						NavMeshAgent navMeshAgent = component as NavMeshAgent;
    //						if (navMeshAgent != null)
    //						{
    //							navMeshAgent.enabled = bActive;
    //						}
    //					}
    //					else if (type2.IsSubclassOf(typeof(Renderer)))
    //					{
    //						Renderer renderer = component as Renderer;
    //						if (renderer != null)
    //						{
    //							renderer.enabled = bActive;
    //						}
    //					}
    //					else if (type2 == typeof(Animator))
    //					{
    //						Animator animator = component as Animator;
    //						if (animator != null && (!animator.name.Contains("weapon") || go.GetCharacterID() != 0))
    //						{
    //							animator.enabled = bActive;
    //						}
    //					}
    //					else if (type2 == typeof(ParticleSystem))
    //					{
    //						ParticleSystem particleSystem = component as ParticleSystem;
    //						if (particleSystem != null)
    //						{
    //							UtilFun.SetActive(particleSystem.gameObject, bActive);
    //						}
    //					}
    //					else
    //					{
    //						MonoBehaviour monoBehaviour = component as MonoBehaviour;
    //						if (monoBehaviour != null)
    //						{
    //							if (monoBehaviour.GetType() != typeof(Perception))
    //							{
    //								monoBehaviour.enabled = bActive;
    //							}
    //						}
    //					}
    //				}
    //			}
    //		}
    //	}

    //	// Token: 0x06003EDD RID: 16093 RVA: 0x001C189C File Offset: 0x001BFA9C
    //	public static void RemoveAllComponent<T>(GameObject obj) where T : Component
    //	{
    //		foreach (T t in obj.GetComponents<T>())
    //		{
    //			UnityEngine.Object.Destroy(t);
    //		}
    //	}

    //	// Token: 0x06003EDE RID: 16094 RVA: 0x001C18D8 File Offset: 0x001BFAD8
    //	public static bool IsBattleState(Transform personTF)
    //	{
    //		bool result = false;
    //		Animator component = personTF.GetComponent<Animator>();
    //		if (component != null)
    //		{
    //			result = UtilFun.IsBattleState(component);
    //		}
    //		return result;
    //	}

    //	// Token: 0x06003EDF RID: 16095 RVA: 0x001C1904 File Offset: 0x001BFB04
    //	public static bool IsBattleState(Animator animator)
    //	{
    //		if (animator.name.ToLower().Contains("jiguanxiong"))
    //		{
    //			return false;
    //		}
    //		bool result = animator.GetLayerWeight(1) > 0.5f;
    //		if (animator.layerCount > 3 && animator.GetLayerWeight(3) > 0.5f)
    //		{
    //			result = true;
    //		}
    //		return result;
    //	}

    //	// Token: 0x06003EE0 RID: 16096 RVA: 0x001C196C File Offset: 0x001BFB6C
    //	public static Transform BindOrnamentToProp(Transform personTF, string prefabPath)
    //	{
    //		if (personTF == null)
    //		{
    //			return null;
    //		}
    //		string resourcePath = GameObjectPath.GetResourcePath(prefabPath);
    //		UnityEngine.Object @object = FileLoader.LoadObjectFromFile<UnityEngine.Object>(resourcePath.ToAssetBundlePath(), true, true);
    //		if (@object == null)
    //		{
    //			UnityEngine.Debug.LogError("Error : " + prefabPath + " 挂件载入失败");
    //			return null;
    //		}
    //		GameObject gameObject = @object as GameObject;
    //		Transform transform = gameObject.transform;
    //		UtilFun.BindOrnamentToProp(personTF, transform, true);
    //		return transform;
    //	}

    //	// Token: 0x06003EE1 RID: 16097 RVA: 0x001C19D8 File Offset: 0x001BFBD8
    //	public static void BindOrnamentToProp(Transform personTF, Transform prefabTF, bool NeedUnBind = true)
    //	{
    //		if (personTF == null)
    //		{
    //			return;
    //		}
    //		if (prefabTF == null)
    //		{
    //			return;
    //		}
    //		if (NeedUnBind)
    //		{
    //			UtilFun.UnBindOrnamentFromBothProp(personTF, prefabTF, true);
    //		}
    //		Transform ornamentProp = GameObjectPath.GetOrnamentProp(personTF);
    //		if (ornamentProp == null)
    //		{
    //			UnityEngine.Debug.LogError("Error : " + personTF.name + " 找不到挂饰绑定点");
    //			return;
    //		}
    //		prefabTF.parent = ornamentProp;
    //		prefabTF.localPosition = Vector3.zero;
    //		prefabTF.localEulerAngles = Vector3.zero;
    //	}

    //	// Token: 0x06003EE2 RID: 16098 RVA: 0x001C1A5C File Offset: 0x001BFC5C
    //	public static Transform UnBindOrnamentFromBothProp(Transform personTF, Transform itemTF, bool needDestroy)
    //	{
    //		if (personTF == null)
    //		{
    //			return null;
    //		}
    //		Transform ornamentProp = GameObjectPath.GetOrnamentProp(personTF);
    //		if (ornamentProp == null)
    //		{
    //			return null;
    //		}
    //		Transform transform = null;
    //		if (ornamentProp.childCount > 0)
    //		{
    //			transform = ornamentProp.GetChild(0);
    //			if (itemTF != transform)
    //			{
    //				if (needDestroy)
    //				{
    //					UnityEngine.Object.Destroy(transform.gameObject);
    //				}
    //				else
    //				{
    //					transform.parent = null;
    //				}
    //			}
    //		}
    //		return transform;
    //	}

    //	// Token: 0x06003EE3 RID: 16099 RVA: 0x001C1ACC File Offset: 0x001BFCCC
    //	public static Transform BindItemToProp(Transform personTF, string prefabPath, int index, UtilFun.BindSlot slot = UtilFun.BindSlot.Default)
    //	{
    //		if (personTF == null)
    //		{
    //			return null;
    //		}
    //		if (string.IsNullOrEmpty(prefabPath))
    //		{
    //			return null;
    //		}
    //		UnityEngine.Object @object = FileLoader.LoadObjectFromFile<UnityEngine.Object>(prefabPath.ToAssetBundlePath(), true, true);
    //		if (@object == null)
    //		{
    //			return null;
    //		}
    //		GameObject gameObject = @object as GameObject;
    //		Transform transform = gameObject.transform;
    //		UtilFun.BindItemToProp(personTF, transform, index, slot);
    //		return transform;
    //	}

    //	// Token: 0x06003EE4 RID: 16100 RVA: 0x001C1B28 File Offset: 0x001BFD28
    //	public static void BindItemToProp(Transform personTF, Transform prefabTF, int index, UtilFun.BindSlot slot = UtilFun.BindSlot.Default)
    //	{
    //		if (personTF == null)
    //		{
    //			return;
    //		}
    //		if (prefabTF == null)
    //		{
    //			return;
    //		}
    //		UtilFun.UnBindItemFromBothProp(personTF, prefabTF, index, true);
    //		if (slot == UtilFun.BindSlot.Default)
    //		{
    //			if (UtilFun.IsBattleState(personTF))
    //			{
    //				slot = UtilFun.BindSlot.Hand;
    //			}
    //			else
    //			{
    //				slot = UtilFun.BindSlot.Back;
    //			}
    //		}
    //		Transform[] array = null;
    //		UtilFun.BindSlot bindSlot = slot;
    //		if (bindSlot != UtilFun.BindSlot.Hand)
    //		{
    //			if (bindSlot == UtilFun.BindSlot.Back)
    //			{
    //				array = GameObjectPath.GetBoneProps(personTF);
    //				UtilFun.YueJinChaoShenSuo(prefabTF, Vector3.zero);
    //			}
    //		}
    //		else
    //		{
    //			array = GameObjectPath.GetProps(personTF);
    //			UtilFun.YueJinChaoShenSuo(prefabTF, Vector3.one);
    //		}
    //		if (array == null)
    //		{
    //			return;
    //		}
    //		if (array.Length < index + 1)
    //		{
    //			index = array.Length - 1;
    //		}
    //		prefabTF.parent = array[index];
    //		prefabTF.localPosition = Vector3.zero;
    //		prefabTF.localEulerAngles = Vector3.zero;
    //	}

    //	// Token: 0x06003EE5 RID: 16101 RVA: 0x001C1BF4 File Offset: 0x001BFDF4
    //	public static void SetActiveWeaponAndAssort(this PalNPC npc, bool bActive, bool bAssort, bool immediately = true)
    //	{
    //		for (int i = 0; i < npc.Weapons.Count; i++)
    //		{
    //			if (!(npc.Weapons[i] == null))
    //			{
    //				UtilFun.SetActiveWeapon(npc.Weapons[i], bActive, immediately);
    //			}
    //		}
    //		GameObject weaponAssortObj = npc.WeaponAssortObj;
    //		if (weaponAssortObj != null)
    //		{
    //			UtilFun.SetActiveWeapon(weaponAssortObj, bAssort, immediately);
    //		}
    //		if (npc.Data.CharacterID == 4 && npc.ornament != null)
    //		{
    //			npc.ResetOrnament();
    //		}
    //	}

    //	// Token: 0x06003EE6 RID: 16102 RVA: 0x001C1C90 File Offset: 0x001BFE90
    //	public static string GetBearName(string path)
    //	{
    //		int num = path.LastIndexOf("/");
    //		return path.Substring(num + 1);
    //	}

    //	// Token: 0x06003EE7 RID: 16103 RVA: 0x001C1CB4 File Offset: 0x001BFEB4
    //	public static void BindWeaponToProp(this PalNPC npc, WeaponItemType wit, UtilFun.BindSlot slot = UtilFun.BindSlot.Default)
    //	{
    //		if (npc == null)
    //		{
    //			string message = "Error : UtilFun.BindWeaponToProp npc == null";
    //			UnityEngine.Debug.LogError(message);
    //			return;
    //		}
    //		if (npc.model == null)
    //		{
    //			string message2 = "Error : UtilFun.BindWeaponToProp " + npc.name + "(PalNPC).model == null";
    //			UnityEngine.Debug.LogError(message2);
    //			return;
    //		}
    //		if (wit == null)
    //		{
    //			string message3 = "Error : UtilFun.BindWeaponToProp wit == null";
    //			UnityEngine.Debug.LogError(message3);
    //			return;
    //		}
    //		Transform transform = npc.model.transform;
    //		for (int i = 0; i < npc.Weapons.Count; i++)
    //		{
    //			if (npc.Weapons[i] != null && npc.Weapons[i].gameObject != null)
    //			{
    //				UnityEngine.Object.Destroy(npc.Weapons[i].gameObject);
    //			}
    //		}
    //		npc.Weapons.Clear();
    //		npc.Weapons.Add(null);
    //		npc.Weapons.Add(null);
    //		if (transform.name.Contains("JiGuanXiong"))
    //		{
    //			string bearName = UtilFun.GetBearName(wit.BearModel);
    //			if (transform.name != bearName)
    //			{
    //				GameObject gameObject = FileLoader.LoadObjectFromFile<GameObject>(wit.BearModel.ToAssetBundlePath(), true, true);
    //				npc.ChangeModelForever(gameObject, false);
    //				transform = gameObject.transform;
    //			}
    //		}
    //		BindItemToPropScript.Init(transform, wit.Model2, 0, slot, new Action<PalNPC, GameObject, int>(UtilFun.OnItemLoadOver));
    //		BindItemToPropScript.Init(transform, wit.Model, 1, slot, new Action<PalNPC, GameObject, int>(UtilFun.OnItemLoadOver));
    //	}

    //	// Token: 0x06003EE8 RID: 16104 RVA: 0x001C1E44 File Offset: 0x001C0044
    //	private static void OnItemLoadOver(PalNPC npc, GameObject go, int idx)
    //	{
    //		if (npc.Weapons.Count - 1 < idx)
    //		{
    //			UnityEngine.Debug.LogError("Error : " + npc.name + "的Weapons 超界  idx为" + idx.ToString());
    //			return;
    //		}
    //		npc.Weapons[idx] = go;
    //	}

    //	// Token: 0x06003EE9 RID: 16105 RVA: 0x001C1E94 File Offset: 0x001C0094
    //	public static void SetAssortObjDisplay(string matPath, GameObject assortObj, int ID)
    //	{
    //		if (string.IsNullOrEmpty(matPath))
    //		{
    //			return;
    //		}
    //		if (assortObj == null)
    //		{
    //			return;
    //		}
    //		switch (ID)
    //		{
    //		case 0:
    //		case 1:
    //		case 2:
    //		case 3:
    //		case 4:
    //		case 5:
    //		case 6:
    //			assortObj.SetMat(matPath);
    //			break;
    //		}
    //	}

    //	// Token: 0x06003EEA RID: 16106 RVA: 0x001C1EF0 File Offset: 0x001C00F0
    //	public static void SetActiveWeaponInNormal(Transform tf)
    //	{
    //		PalNPC npc = tf.GetNPC();
    //		if (npc == null)
    //		{
    //			return;
    //		}
    //		npc.SetActiveWeaponInNormal(true);
    //	}

    //	// Token: 0x06003EEB RID: 16107 RVA: 0x001C1F18 File Offset: 0x001C0118
    //	public static void SetActiveWeaponInCutscene(Transform tf)
    //	{
    //		PalNPC npc = tf.GetNPC();
    //		if (npc == null)
    //		{
    //			return;
    //		}
    //		npc.SetActiveWeaponInCutscene(true);
    //	}

    //	// Token: 0x06003EEC RID: 16108 RVA: 0x001C1F40 File Offset: 0x001C0140
    //	public static void SetActiveWeaponInCutscene(this PalNPC npc, bool immediately = true)
    //	{
    //		int characterID = npc.Data.CharacterID;
    //		int num = characterID;
    //		if (num != 1)
    //		{
    //			npc.SetActiveWeaponAndAssort(false, false, immediately);
    //		}
    //		else
    //		{
    //			npc.SetActiveWeaponAndAssort(false, true, immediately);
    //		}
    //	}

    //	// Token: 0x06003EED RID: 16109 RVA: 0x001C1F84 File Offset: 0x001C0184
    //	public static void SetActiveWeaponInNormal(this PalNPC npc, bool immediately = true)
    //	{
    //		switch (npc.Data.CharacterID)
    //		{
    //		case 0:
    //		case 3:
    //			npc.SetActiveWeaponAndAssort(true, true, immediately);
    //			break;
    //		case 1:
    //			npc.SetActiveWeaponAndAssort(false, true, immediately);
    //			break;
    //		case 2:
    //		case 5:
    //			npc.SetActiveWeaponAndAssort(false, false, immediately);
    //			break;
    //		case 4:
    //			npc.SetActiveWeaponAndAssort(false, true, immediately);
    //			break;
    //		}
    //	}

    //	// Token: 0x06003EEE RID: 16110 RVA: 0x001C1FFC File Offset: 0x001C01FC
    //	public static void SetActiveWeaponInBattle(Transform tf)
    //	{
    //		PalNPC npc = tf.GetNPC();
    //		if (npc == null)
    //		{
    //			return;
    //		}
    //		npc.SetActiveWeaponInBattle();
    //	}

    //	// Token: 0x06003EEF RID: 16111 RVA: 0x001C2024 File Offset: 0x001C0224
    //	public static void SetActiveWeaponInBattle(this PalNPC npc)
    //	{
    //		switch (npc.Data.CharacterID)
    //		{
    //		case 0:
    //		case 1:
    //		case 2:
    //		case 3:
    //		case 5:
    //			npc.SetActiveWeaponAndAssort(true, true, true);
    //			break;
    //		case 4:
    //			npc.SetActiveWeaponAndAssort(true, false, true);
    //			break;
    //		}
    //	}

    //	// Token: 0x06003EF0 RID: 16112 RVA: 0x001C2080 File Offset: 0x001C0280
    //	public static void SetShroudBlendStartEndDis(GameObject go, float startDis, float endDis)
    //	{
    //		ShroudInstance componentInChildren = go.GetComponentInChildren<ShroudInstance>();
    //		if (componentInChildren == null)
    //		{
    //			return;
    //		}
    //		componentInChildren.m_blendStartDistance = startDis;
    //		componentInChildren.m_blendEndDistance = endDis;
    //	}

    //	// Token: 0x06003EF1 RID: 16113 RVA: 0x001C20B0 File Offset: 0x001C02B0
    //	public static void BindWeaponToPropUI(this GameObject go, int ID, WeaponItemType wit, UtilFun.BindSlot slot = UtilFun.BindSlot.Default, bool SetToUILayer = true, bool bAgent = true)
    //	{
    //		if (!bAgent)
    //		{
    //			go = go.GetModelObj(false);
    //		}
    //		Transform transform = go.transform;
    //		Transform transform2 = UtilFun.BindItemToProp(transform, wit.Model, 1, slot);
    //		Transform transform3 = UtilFun.BindItemToProp(transform, wit.Model2, 0, slot);
    //		if (transform2 != null)
    //		{
    //			transform2.SetActive(true);
    //		}
    //		if (transform3 != null)
    //		{
    //			transform3.SetActive(true);
    //		}
    //		if (SetToUILayer)
    //		{
    //			if (transform2 != null)
    //			{
    //				UIManager.SetAllToUILayer(transform2);
    //			}
    //			if (transform3 != null)
    //			{
    //				UIManager.SetAllToUILayer(transform3);
    //			}
    //		}
    //		if (ID != 4)
    //		{
    //			GameObject gameObject;
    //			if (ID != 2)
    //			{
    //				gameObject = go.GetWeaponAssortObj(true, ID);
    //			}
    //			else
    //			{
    //				string name = "MianJu_2";
    //				Transform transform4 = go.transform.FindChild(name);
    //				GameObject gameObject2 = (!(transform4 == null)) ? transform4.gameObject : null;
    //				GameObject weaponAssortObj = go.GetWeaponAssortObj(true, ID);
    //				if (transform3 != null && transform3.name.Contains("weapon_M2_14"))
    //				{
    //					if (weaponAssortObj != null)
    //					{
    //						weaponAssortObj.SetActive(false);
    //					}
    //					gameObject = gameObject2;
    //				}
    //				else
    //				{
    //					if (gameObject2 != null)
    //					{
    //						gameObject2.SetActive(false);
    //					}
    //					gameObject = weaponAssortObj;
    //				}
    //			}
    //			if (gameObject != null)
    //			{
    //				gameObject.SetActive(true);
    //			}
    //			if (!string.IsNullOrEmpty(wit.AssortTex))
    //			{
    //				UtilFun.SetAssortObjDisplay(wit.AssortTex, gameObject, ID);
    //			}
    //			else if (ID > -1)
    //			{
    //				GameObject gameObject3 = PlayersManager.FindMainChar(ID, true);
    //				PalNPC component = gameObject3.GetComponent<PalNPC>();
    //				if (component != null && component.oriAssortMat != null)
    //				{
    //					gameObject.SetMat(component.oriAssortMat);
    //				}
    //			}
    //		}
    //	}

    //	// Token: 0x06003EF2 RID: 16114 RVA: 0x001C2270 File Offset: 0x001C0470
    //	public static GameObject GetWeaponAssortObj(this GameObject go, bool isAgent = true, int ID = -1)
    //	{
    //		Transform transform = null;
    //		if (!isAgent)
    //		{
    //			go = go.GetModelObj(false);
    //		}
    //		Transform transform2 = go.transform;
    //		Agent component = go.GetComponent<Agent>();
    //		PalNPC palNPC = null;
    //		if (component != null)
    //		{
    //			palNPC = component.palNPC;
    //		}
    //		int num = ID;
    //		if (num < 0)
    //		{
    //			if (palNPC != null)
    //			{
    //				num = palNPC.Data.CharacterID;
    //			}
    //			else
    //			{
    //				UnityEngine.Debug.LogError("Error : " + go.name + " 没有对应的NPC component");
    //			}
    //		}
    //		if (num > UtilFun.AssortObjPaths.Length - 1 || num < 0)
    //		{
    //			return null;
    //		}
    //		string text = UtilFun.AssortObjPaths[num];
    //		if (num != 0)
    //		{
    //			if (num == 2 && palNPC != null)
    //			{
    //				if (palNPC.Weapons.Count > 0)
    //				{
    //					GameObject gameObject = palNPC.Weapons[0];
    //					if (gameObject != null && gameObject.name.Contains("weapon_M2_14"))
    //					{
    //						text = "MianJu_2";
    //					}
    //				}
    //				else
    //				{
    //					UnityEngine.Debug.LogError("xianqing没有武器");
    //				}
    //			}
    //			if (!string.IsNullOrEmpty(text))
    //			{
    //				transform = transform2.FindChild(text);
    //			}
    //		}
    //		else
    //		{
    //			transform = null;
    //			foreach (ShroudMesh shroudMesh in go.GetComponentsInChildren<ShroudMesh>())
    //			{
    //				MeshRenderer component2 = shroudMesh.GetComponent<MeshRenderer>();
    //				if (!(component2 == null))
    //				{
    //					for (int j = 0; j < component2.materials.Length; j++)
    //					{
    //						Material material = component2.materials[j];
    //						if (!(material == null))
    //						{
    //							if (material.name.Contains("jianqiao"))
    //							{
    //								transform = component2.transform;
    //								break;
    //							}
    //						}
    //					}
    //					if (transform != null)
    //					{
    //						break;
    //					}
    //				}
    //			}
    //		}
    //		return (!(transform == null)) ? transform.gameObject : null;
    //	}

    //	// Token: 0x06003EF3 RID: 16115 RVA: 0x001C2474 File Offset: 0x001C0674
    //	public static PalNPC GetNPC(this Transform tf)
    //	{
    //		PalNPC palNPC = tf.GetComponent<PalNPC>();
    //		if (palNPC == null)
    //		{
    //			Agent component = tf.GetComponent<Agent>();
    //			if (component != null)
    //			{
    //				palNPC = component.palNPC;
    //			}
    //			else
    //			{
    //				BattlePlayer component2 = tf.GetComponent<BattlePlayer>();
    //				if (component2 != null)
    //				{
    //					palNPC = component2.m_PalNPC;
    //				}
    //			}
    //		}
    //		if (palNPC == null)
    //		{
    //			UnityEngine.Debug.LogError(tf.name + " 没有找到PalNPC");
    //		}
    //		return palNPC;
    //	}

    //	// Token: 0x06003EF4 RID: 16116 RVA: 0x001C24F0 File Offset: 0x001C06F0
    //	public static void BindWeaponToProp(Transform tf, UtilFun.BindSlot slot = UtilFun.BindSlot.Default)
    //	{
    //		PalNPC npc = tf.GetNPC();
    //		if (npc != null)
    //		{
    //			for (int i = 0; i < npc.Weapons.Count; i++)
    //			{
    //				if (npc.Weapons[i] != null)
    //				{
    //					UtilFun.BindItemToProp(tf, npc.Weapons[i].transform, i, slot);
    //				}
    //			}
    //		}
    //	}

    //	// Token: 0x06003EF5 RID: 16117 RVA: 0x001C255C File Offset: 0x001C075C
    //	public static Transform UnBindItemFromBothProp(Transform personTF, Transform itemTF, int index, bool needDestroy = false)
    //	{
    //		PalMain.UnloadUnusedAssets(PalMain.UNLOADPROIR.LONG);
    //		if (personTF == null)
    //		{
    //			return null;
    //		}
    //		Transform[] array = GameObjectPath.GetProps(personTF);
    //		if (array == null || array.Length < index + 1)
    //		{
    //			return null;
    //		}
    //		if (array[index] == null)
    //		{
    //			UnityEngine.Debug.LogError(personTF.name + "没有找到 Props 的" + index.ToString());
    //			return null;
    //		}
    //		Transform transform = null;
    //		if (array[index].childCount > 0)
    //		{
    //			transform = array[index].GetChild(0);
    //			if (itemTF != transform)
    //			{
    //				if (needDestroy)
    //				{
    //					UnityEngine.Object.Destroy(transform.gameObject);
    //				}
    //				else
    //				{
    //					transform.parent = null;
    //				}
    //			}
    //		}
    //		if (transform == null)
    //		{
    //			array = GameObjectPath.GetBoneProps(personTF);
    //			if (array == null || array.Length < index + 1)
    //			{
    //				return null;
    //			}
    //			if (array[index].childCount > 0)
    //			{
    //				transform = array[index].GetChild(0);
    //				if (itemTF != transform)
    //				{
    //					if (needDestroy)
    //					{
    //						UnityEngine.Object.Destroy(transform.gameObject);
    //					}
    //					else
    //					{
    //						UtilFun.YueJinChaoShenSuo(transform, Vector3.one);
    //						transform.parent = null;
    //					}
    //				}
    //			}
    //		}
    //		return transform;
    //	}

    //	// Token: 0x06003EF6 RID: 16118 RVA: 0x001C267C File Offset: 0x001C087C
    //	public static Transform UnBindItemFromProp(Transform personTF, int index, bool needDestroy = false, UtilFun.BindSlot slot = UtilFun.BindSlot.Default)
    //	{
    //		if (personTF == null)
    //		{
    //			return null;
    //		}
    //		Transform[] array = null;
    //		if (slot == UtilFun.BindSlot.Default)
    //		{
    //			if (UtilFun.IsBattleState(personTF))
    //			{
    //				slot = UtilFun.BindSlot.Hand;
    //			}
    //			else
    //			{
    //				slot = UtilFun.BindSlot.Back;
    //			}
    //		}
    //		UtilFun.BindSlot bindSlot = slot;
    //		if (bindSlot != UtilFun.BindSlot.Hand)
    //		{
    //			if (bindSlot == UtilFun.BindSlot.Back)
    //			{
    //				array = GameObjectPath.GetBoneProps(personTF);
    //			}
    //		}
    //		else
    //		{
    //			array = GameObjectPath.GetProps(personTF);
    //		}
    //		if (array == null || array.Length < index + 1)
    //		{
    //			return null;
    //		}
    //		Transform transform = null;
    //		if (array[index].childCount > 0)
    //		{
    //			transform = array[index].GetChild(0);
    //			if (needDestroy)
    //			{
    //				UnityEngine.Object.Destroy(transform.gameObject);
    //			}
    //			else
    //			{
    //				if (slot == UtilFun.BindSlot.Back)
    //				{
    //					UtilFun.YueJinChaoShenSuo(transform, Vector3.one);
    //				}
    //				transform.parent = null;
    //			}
    //		}
    //		return transform;
    //	}

    //	// Token: 0x06003EF7 RID: 16119 RVA: 0x001C2740 File Offset: 0x001C0940
    //	public static void YueJinChaoShenSuo(Transform Weapon, Vector3 vec)
    //	{
    //		Transform transform = Weapon.GetChild(0).FindChild("jianren");
    //		if (transform != null)
    //		{
    //			transform.localScale = vec;
    //		}
    //	}

    //	// Token: 0x06003EF8 RID: 16120 RVA: 0x001C2774 File Offset: 0x001C0974
    //	public static GameObject PalGetModelObj(GameObject go, bool NeedActive = true)
    //	{
    //		return go.GetModelObj(NeedActive);
    //	}

    //	// Token: 0x06003EF9 RID: 16121 RVA: 0x001C2780 File Offset: 0x001C0980
    //	public static GameObject GetNPCObj(this GameObject go)
    //	{
    //		if (go == null)
    //		{
    //			UnityEngine.Debug.LogError("GetNPCObj 参数go为Null");
    //			return null;
    //		}
    //		PalGameObjectBase component = go.GetComponent<PalGameObjectBase>();
    //		if (component != null)
    //		{
    //			return go;
    //		}
    //		Agent component2 = go.GetComponent<Agent>();
    //		if (component2 != null)
    //		{
    //			PalNPC palNPC = component2.palNPC;
    //			if (palNPC != null)
    //			{
    //				return palNPC.gameObject;
    //			}
    //		}
    //		return null;
    //	}

    //	// Token: 0x06003EFA RID: 16122 RVA: 0x001C27E8 File Offset: 0x001C09E8
    //	public static GameObject GetModelObj(this GameObject go, bool NeedActive = false)
    //	{
    //		if (go == null)
    //		{
    //			UnityEngine.Debug.LogError("GetModelObj 参数go为Null");
    //			return null;
    //		}
    //		GameObject gameObject = null;
    //		PalGameObjectBase component = go.GetComponent<PalGameObjectBase>();
    //		if (component != null)
    //		{
    //			if (component.model == null)
    //			{
    //				Animator componentInChildren = component.GetComponentInChildren<Animator>();
    //				if (componentInChildren != null)
    //				{
    //					component.model = componentInChildren.gameObject;
    //				}
    //			}
    //			gameObject = component.model;
    //		}
    //		if (gameObject == null)
    //		{
    //			gameObject = go;
    //		}
    //		if (NeedActive && !gameObject.activeSelf)
    //		{
    //			UtilFun.SetActive(gameObject, true);
    //		}
    //		return gameObject;
    //	}

    //	// Token: 0x06003EFB RID: 16123 RVA: 0x001C2880 File Offset: 0x001C0A80
    //	public static string GetModelResourcePath(string modelResourcePath)
    //	{
    //		string[] separator = new string[]
    //		{
    //			"Resources/"
    //		};
    //		string[] array = modelResourcePath.Split(separator, StringSplitOptions.None);
    //		if (array.Length != 2)
    //		{
    //			return modelResourcePath;
    //		}
    //		return array[1].Split(new char[]
    //		{
    //			'.'
    //		})[0];
    //	}

    //	// Token: 0x06003EFC RID: 16124 RVA: 0x001C28C8 File Offset: 0x001C0AC8
    //	public static Vector3 GetModelMiddle(Transform tf)
    //	{
    //		Transform transform = tf.Find("Bip001");
    //		if (transform == null)
    //		{
    //			transform = tf.Find("Bip01");
    //			if (transform == null)
    //			{
    //				return Vector3.zero;
    //			}
    //		}
    //		return transform.localPosition;
    //	}

    //	// Token: 0x06003EFD RID: 16125 RVA: 0x001C2914 File Offset: 0x001C0B14
    //	public static float GetModelMiddleRadius(Transform tf)
    //	{
    //		Transform transform = tf.Find("Bip001");
    //		if (transform == null)
    //		{
    //			SkinnedMeshRenderer componentInChildren = tf.GetComponentInChildren<SkinnedMeshRenderer>();
    //			if (componentInChildren == null)
    //			{
    //				return 1f;
    //			}
    //			return Mathf.Max(new float[]
    //			{
    //				componentInChildren.bounds.size.x,
    //				componentInChildren.bounds.size.y,
    //				componentInChildren.bounds.size.z
    //			});
    //		}
    //		else
    //		{
    //			Transform transform2 = transform.Find("Bip001 Pelvis/Bip001 Spine/Bip001 Spine1");
    //			if (transform2 == null)
    //			{
    //				transform2 = transform.Find("Bip001 Spine/Bip001 Spine1");
    //			}
    //			if (transform2 != null)
    //			{
    //				Transform transform3 = transform2.Find("Bip001 L Clavicle/Bip001 L UpperArm");
    //				if (transform3 == null)
    //				{
    //					transform3 = transform2.Find("Bip001 Neck/Bip001 L Clavicle/Bip001 L UpperArm");
    //				}
    //				Transform transform4 = transform2.Find("Bip001 R Clavicle/Bip001 R UpperArm");
    //				if (transform4 == null)
    //				{
    //					transform4 = transform2.Find("Bip001 Neck/Bip001 R Clavicle/Bip001 R UpperArm");
    //				}
    //				return Vector3.Distance(transform3.position, transform4.position) / 2f;
    //			}
    //			return 0.23f;
    //		}
    //	}

    //	// Token: 0x06003EFE RID: 16126 RVA: 0x001C2A48 File Offset: 0x001C0C48
    //	public static List<List<string>> GetExcelCells(string path)
    //	{
    //		string text = string.Empty;
    //		List<List<string>> list = new List<List<string>>();
    //		if (path.Length > 0)
    //		{
    //			using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
    //			{
    //				StreamReader streamReader = new StreamReader(fileStream, Encoding.Default);
    //				text = streamReader.ReadToEnd();
    //			}
    //			string[] array = text.Split(new string[]
    //			{
    //				"\r\n"
    //			}, StringSplitOptions.RemoveEmptyEntries);
    //			for (int i = 0; i < array.Length; i++)
    //			{
    //				list.Add(UtilFun.Split(array[i]));
    //			}
    //		}
    //		return list;
    //	}

    //	// Token: 0x06003EFF RID: 16127 RVA: 0x001C2AFC File Offset: 0x001C0CFC
    //	private static List<string> Split(string line)
    //	{
    //		line += ',';
    //		int startIndex = 0;
    //		List<int> list = new List<int>();
    //		List<int> list2 = new List<int>();
    //		int num;
    //		do
    //		{
    //			num = line.IndexOf(',', startIndex);
    //			if (num > -1)
    //			{
    //				startIndex = num + 1;
    //				list.Add(num);
    //			}
    //		}
    //		while (num > -1);
    //		startIndex = 0;
    //		do
    //		{
    //			num = line.IndexOf('"', startIndex);
    //			if (num > -1)
    //			{
    //				startIndex = num + 1;
    //				list2.Add(num);
    //			}
    //		}
    //		while (num > -1);
    //		List<string> list3 = new List<string>();
    //		num = 0;
    //		int num2 = 0;
    //		for (int i = 0; i < list.Count; i++)
    //		{
    //			string item = string.Empty;
    //			if (num < list2.Count && list[i] > list2[num])
    //			{
    //				if (list2[num] > num2)
    //				{
    //					item = line.Substring(num2, list[i] - num2);
    //					num2 = list[i] + 1;
    //					list3.Add(item);
    //					while (list2[num] < num2)
    //					{
    //						num++;
    //					}
    //				}
    //				else
    //				{
    //					int num3 = 0;
    //					while (line[++num2] == '"')
    //					{
    //						num3++;
    //						num2++;
    //					}
    //					if (num2 - 1 == list[i] && num3 > 0)
    //					{
    //						int num4 = list2[num + num3 + 1];
    //						item = line.Substring(num4, num3 - 1);
    //						num += num3 * 2;
    //						list3.Add(item);
    //					}
    //					else
    //					{
    //						int num4 = list2[num + num3] + 1;
    //						num += num3 * 2 + 1;
    //						num2 = list2[num];
    //						bool flag = false;
    //						do
    //						{
    //							num3 = 0;
    //							num2 = list2[num] + 1;
    //							while (line[num2] == '"')
    //							{
    //								num3++;
    //								num2 += 2;
    //							}
    //							if (line[num2 - 1] == '"')
    //							{
    //								num += num3;
    //								int num5 = list2[num];
    //								item = line.Substring(num4, num5 - num4);
    //								list3.Add(item);
    //								num += num3 + 1;
    //								flag = true;
    //							}
    //							else
    //							{
    //								num += num3 * 2;
    //							}
    //						}
    //						while (!flag);
    //						while (list[i] < list2[num - 1])
    //						{
    //							i++;
    //						}
    //						num2 = list[i] + 1;
    //					}
    //				}
    //			}
    //			else
    //			{
    //				item = line.Substring(num2, list[i] - num2);
    //				num2 = list[i] + 1;
    //				list3.Add(item);
    //			}
    //		}
    //		return list3;
    //	}

    //	// Token: 0x06003F00 RID: 16128 RVA: 0x001C2D90 File Offset: 0x001C0F90
    //	public static T GetComponentFromParent<T>(Transform tf) where T : Component
    //	{
    //		T component = tf.GetComponent<T>();
    //		if (component != null || tf.parent == null)
    //		{
    //			return component;
    //		}
    //		return UtilFun.GetComponentFromParent<T>(tf.parent);
    //	}

    //	// Token: 0x06003F01 RID: 16129 RVA: 0x001C2DD4 File Offset: 0x001C0FD4
    //	public static bool IsPlayer(this GameObject go)
    //	{
    //		return go == PlayersManager.Player || (PlayerCtrlManager.agentObj != null && go.GetModelObj(false) == PlayerCtrlManager.agentObj.gameObject);
    //	}

    //	// Token: 0x06003F02 RID: 16130 RVA: 0x001C2E20 File Offset: 0x001C1020
    //	public static string GetCharDetailName(int id)
    //	{
    //		switch (id)
    //		{
    //		case 0:
    //			return id.ToString() + "_" + ((FlagManager.GetFlag(6) == 0) ? "0" : "1");
    //		case 3:
    //			return id.ToString() + "_" + ((FlagManager.GetFlag(3) == 0) ? "0" : "1");
    //		case 5:
    //			return id.ToString() + "_" + ((FlagManager.GetFlag(7) == 0) ? "0" : "1");
    //		}
    //		return id.ToString();
    //	}

    //	// Token: 0x06003F03 RID: 16131 RVA: 0x001C2EE0 File Offset: 0x001C10E0
    //	public static int GetCharacterID(this GameObject go)
    //	{
    //		Agent component = go.GetComponent<Agent>();
    //		PalNPC palNPC = (!(component == null)) ? component.palNPC : go.GetComponent<PalNPC>();
    //		return (!(palNPC == null)) ? palNPC.Data.CharacterID : -1;
    //	}

    //	// Token: 0x06003F04 RID: 16132 RVA: 0x001C2F30 File Offset: 0x001C1130
    //	public static string InsertCurLanguePath(this string path)
    //	{
    //		if (string.IsNullOrEmpty(path))
    //		{
    //			return string.Empty;
    //		}
    //		int num = path.LastIndexOf("AssetBundles");
    //		if (num < 0)
    //		{
    //			return path;
    //		}
    //		return path.Insert(num, "Langue/" + Langue.CurLangue.ToString() + "/");
    //	}

    //	// Token: 0x06003F05 RID: 16133 RVA: 0x001C2F88 File Offset: 0x001C1188
    //	public static void ConsoleLog(string str, bool bError = false)
    //	{
    //		if (!UtilFun.ShowConsoleLog)
    //		{
    //			return;
    //		}
    //		if (bError)
    //		{
    //			UnityEngine.Debug.LogError(str);
    //		}
    //		else
    //		{
    //			UnityEngine.Debug.Log(str);
    //		}
    //		SoftStar.Pal6.Console.Log(str);
    //	}

    //	// Token: 0x06003F06 RID: 16134 RVA: 0x001C2FC0 File Offset: 0x001C11C0
    //	public static string GetRelativePath(this string path)
    //	{
    //		if (string.IsNullOrEmpty(path))
    //		{
    //			UnityEngine.Debug.LogError("Error : UtilFun.GetRelativePath path == null\n\n");
    //			return null;
    //		}
    //		string[] array = new string[]
    //		{
    //			"/Resources/",
    //			"Pal_Resources/Effects/",
    //			"Pal_Resources/Character/PaperDoll",
    //			"Data/AssetBundles/",
    //			"Pal_Resources/"
    //		};
    //		string[] separator = new string[]
    //		{
    //			string.Empty
    //		};
    //		foreach (string text in array)
    //		{
    //			if (path.Contains(text))
    //			{
    //				separator = new string[]
    //				{
    //					text
    //				};
    //				break;
    //			}
    //		}
    //		string[] array2 = path.Split(separator, StringSplitOptions.None);
    //		if (array2.Length != 2)
    //		{
    //			return path.Split(new char[]
    //			{
    //				'.'
    //			})[0];
    //		}
    //		return array2[1].Split(new char[]
    //		{
    //			'.'
    //		})[0];
    //	}

    //	// Token: 0x06003F07 RID: 16135 RVA: 0x001C3098 File Offset: 0x001C1298
    //	public static string GetAssetPathFromPath(this string path)
    //	{
    //		int num = path.IndexOf("ssets/") - 1;
    //		if (num > -1)
    //		{
    //			path = path.Substring(num);
    //		}
    //		return path;
    //	}

    //	// Token: 0x06003F08 RID: 16136 RVA: 0x001C30C4 File Offset: 0x001C12C4
    //	public static string ExcludeResourcePath(this string path)
    //	{
    //		string[] separator = new string[]
    //		{
    //			"Assets/Resources/"
    //		};
    //		string[] array = path.Split(separator, StringSplitOptions.None);
    //		if (array.Length != 2)
    //		{
    //			return path.Split(new char[]
    //			{
    //				'.'
    //			})[0];
    //		}
    //		return array[1].Split(new char[]
    //		{
    //			'.'
    //		})[0];
    //	}

    //	// Token: 0x06003F09 RID: 16137 RVA: 0x001C3120 File Offset: 0x001C1320
    //	public static void PrintGameObject(GameObject go)
    //	{
    //		Component[] components = go.GetComponents<Component>();
    //		string text = "***********************\n";
    //		text = text + "*" + go.name + "\n";
    //		string text2 = text;
    //		text = string.Concat(new object[]
    //		{
    //			text2,
    //			"*",
    //			go.activeSelf,
    //			"\n"
    //		});
    //		for (int i = 0; i < components.Length; i++)
    //		{
    //			text += "~~~~~~~~~~~~~~~~~~~~~\n";
    //			text2 = text;
    //			text = string.Concat(new object[]
    //			{
    //				text2,
    //				string.Empty,
    //				components[i].GetType(),
    //				"\n"
    //			});
    //			if (components[i] is Transform)
    //			{
    //				Transform transform = components[i] as Transform;
    //				text2 = text;
    //				text = string.Concat(new object[]
    //				{
    //					text2,
    //					"*",
    //					transform.position,
    //					"\n"
    //				});
    //				text2 = text;
    //				text = string.Concat(new object[]
    //				{
    //					text2,
    //					"*",
    //					transform.rotation,
    //					"\n"
    //				});
    //				text2 = text;
    //				text = string.Concat(new object[]
    //				{
    //					text2,
    //					"*",
    //					transform.lossyScale,
    //					"\n"
    //				});
    //			}
    //			FieldInfo[] fields = components[i].GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
    //			PropertyInfo[] properties = components[i].GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
    //			foreach (FieldInfo fieldInfo in fields)
    //			{
    //				text2 = text;
    //				text = string.Concat(new object[]
    //				{
    //					text2,
    //					"*",
    //					fieldInfo.Name,
    //					" : ",
    //					fieldInfo.GetValue(components[i]),
    //					"\n"
    //				});
    //			}
    //			foreach (PropertyInfo propertyInfo in properties)
    //			{
    //				if (propertyInfo.CanRead)
    //				{
    //					text2 = text;
    //					text = string.Concat(new object[]
    //					{
    //						text2,
    //						"*",
    //						propertyInfo.Name,
    //						":",
    //						propertyInfo.GetValue(components[i], null),
    //						"\n"
    //					});
    //				}
    //			}
    //		}
    //		text += "***********************\n";
    //		UnityEngine.Debug.Log(text);
    //		SoftStar.Pal6.Console.Print(text);
    //	}

    //	// Token: 0x06003F0A RID: 16138 RVA: 0x001C3394 File Offset: 0x001C1594
    //	public static void GetOriTex(this GameObject go, out Texture mainTex, out Texture specTex)
    //	{
    //		mainTex = null;
    //		specTex = null;
    //		Transform transform = go.transform;
    //		for (int i = 0; i < transform.childCount; i++)
    //		{
    //			Transform child = transform.GetChild(i);
    //			Renderer component = child.GetComponent<Renderer>();
    //			if (!(component == null))
    //			{
    //				foreach (Material material in component.materials)
    //				{
    //					if (!(material == null) && material.name.Contains("_body"))
    //					{
    //						mainTex = material.GetTexture("_MainTex");
    //						specTex = material.GetTexture("_SpecMap");
    //						return;
    //					}
    //				}
    //			}
    //		}
    //	}

    //	// Token: 0x06003F0B RID: 16139 RVA: 0x001C3454 File Offset: 0x001C1654
    //	public static void SynClothTexDecal(GameObject goA, GameObject goB)
    //	{
    //		if (goA == null || goB == null)
    //		{
    //			UnityEngine.Debug.LogError("Error : UtilFun.SynClothTexDecal  goA == null || goB == null");
    //			return;
    //		}
    //		Texture curTex = null;
    //		Texture specularTex = null;
    //		Texture decalTex = null;
    //		Color white = Color.white;
    //		goA.GetClothTexDecal(out curTex, out specularTex, out decalTex, out white);
    //		goB.SetColorTexDecal(curTex, specularTex, decalTex, white);
    //	}

    //	// Token: 0x06003F0C RID: 16140 RVA: 0x001C34A8 File Offset: 0x001C16A8
    //	public static void GetClothTexDecal(this GameObject go, out Texture curTex, out Texture specularTex, out Texture decalTex, out Color decalColor)
    //	{
    //		curTex = null;
    //		specularTex = null;
    //		decalTex = null;
    //		decalColor = Color.white;
    //		Transform transform = go.transform;
    //		for (int i = 0; i < transform.childCount; i++)
    //		{
    //			Transform child = transform.GetChild(i);
    //			Renderer component = child.GetComponent<Renderer>();
    //			if (!(component == null))
    //			{
    //				Material[] materials = component.materials;
    //				if (materials == null)
    //				{
    //					string path = GameObjectPath.GetPath(child);
    //					string message = "UtilFun.SetColorTexDecal  " + path + ".renderer.materials == null";
    //					UnityEngine.Debug.LogError(message);
    //				}
    //				else
    //				{
    //					foreach (Material material in materials)
    //					{
    //						if (!(material == null) && (material.name.Contains("_body") || material.name.Contains("_mao") || material.name.Contains("_metal")))
    //						{
    //							curTex = material.GetTexture(ShaderPropertyIDManager._MainTexID);
    //							if (material.HasProperty(ShaderPropertyIDManager._DecalMapID))
    //							{
    //								decalTex = material.GetTexture(ShaderPropertyIDManager._DecalMapID);
    //							}
    //							if (material.HasProperty(ShaderPropertyIDManager._DecalColorID))
    //							{
    //								decalColor = material.GetColor(ShaderPropertyIDManager._DecalColorID);
    //							}
    //							if (material.HasProperty(ShaderPropertyIDManager._SpecMapID))
    //							{
    //								specularTex = material.GetTexture(ShaderPropertyIDManager._SpecMapID);
    //							}
    //							break;
    //						}
    //					}
    //					if (curTex != null)
    //					{
    //						break;
    //					}
    //				}
    //			}
    //		}
    //	}

    //	// Token: 0x06003F0D RID: 16141 RVA: 0x001C363C File Offset: 0x001C183C
    //	public static void SetColorTexDecal(this GameObject go, Texture curTex, Texture specularTex, Texture decalTex, Color decalColor)
    //	{
    //		if (go == null)
    //		{
    //			UnityEngine.Debug.LogError("UtilFun.SetColorTexDecal go==null");
    //			return;
    //		}
    //		Animator component = go.GetComponent<Animator>();
    //		if (component == null)
    //		{
    //			string path = GameObjectPath.GetPath(go.transform);
    //			string message = "UtilFun.SetColorTexDecal " + path + ".animator == null";
    //			UnityEngine.Debug.LogError(message);
    //		}
    //		Shader shader;
    //		if (!(component != null) || !component.avatar.name.Contains("XianQing"))
    //		{
    //			if (decalTex)
    //			{
    //				shader = Shader.Find("Pal6/2-Sided/Transparent/Cutout/Bumped Specular Decal_GloEmi");
    //			}
    //			else
    //			{
    //				shader = Shader.Find("Pal6/2-Sided/Transparent/Cutout/Bumped Specular_GloEmi");
    //			}
    //		}
    //		else if (decalTex)
    //		{
    //			shader = Shader.Find("Custom/XianQingCloth_Decal_GloEmi");
    //			if (shader == null)
    //			{
    //				shader = Shader.Find("Pal6/2-Sided/Transparent/Cutout/Bumped Specular Decal_GloEmi");
    //			}
    //		}
    //		else
    //		{
    //			shader = Shader.Find("Custom/XianQingCloth_GloEmi");
    //		}
    //		Transform transform = go.transform;
    //		for (int i = 0; i < transform.childCount; i++)
    //		{
    //			Transform child = transform.GetChild(i);
    //			Renderer component2 = child.GetComponent<Renderer>();
    //			if (!(component2 == null))
    //			{
    //				Material[] materials = component2.materials;
    //				if (materials == null)
    //				{
    //					string path2 = GameObjectPath.GetPath(child);
    //					string message2 = "UtilFun.SetColorTexDecal  " + path2 + ".renderer.materials == null";
    //					UnityEngine.Debug.LogError(message2);
    //				}
    //				else
    //				{
    //					foreach (Material material in materials)
    //					{
    //						if (!(material == null) && (material.name.Contains("_body") || material.name.Contains("_mao") || material.name.Contains("_metal")))
    //						{
    //							material.SetTexture("_MainTex", curTex);
    //							material.shader = shader;
    //							if (decalTex != null)
    //							{
    //								material.SetTexture("_DecalMap", decalTex);
    //								material.SetColor("_DecalColor", decalColor);
    //							}
    //							if (specularTex != null)
    //							{
    //								material.SetTexture("_SpecMap", specularTex);
    //							}
    //						}
    //					}
    //					component2.materials = materials;
    //				}
    //			}
    //		}
    //	}

    //	// Token: 0x06003F0E RID: 16142 RVA: 0x001C388C File Offset: 0x001C1A8C
    //	public static void SetColorTexDecal(this GameObject go, string curTexPath, string specularPath, string decalTexPath, Color decalColor)
    //	{
    //		PalMain.UnloadUnusedAssets(PalMain.UNLOADPROIR.LONG);
    //		Texture texture = FileLoader.LoadObjectFromFile<Texture>(curTexPath.ToAssetBundlePath(), false, true);
    //		if (texture == null)
    //		{
    //			return;
    //		}
    //		Texture curTex = texture;
    //		Texture decalTex = null;
    //		Texture specularTex = null;
    //		Texture texture2 = FileLoader.LoadObjectFromFile<Texture>(decalTexPath.ToAssetBundlePath(), false, true);
    //		if (texture2 != null)
    //		{
    //			decalTex = texture2;
    //		}
    //		Texture texture3 = FileLoader.LoadObjectFromFile<Texture>(specularPath.ToAssetBundlePath(), false, true);
    //		if (texture3 != null)
    //		{
    //			specularTex = texture3;
    //		}
    //		go.SetColorTexDecal(curTex, specularTex, decalTex, decalColor);
    //	}

    //	// Token: 0x06003F0F RID: 16143 RVA: 0x001C390C File Offset: 0x001C1B0C
    //	public static Material GetMat(this GameObject go)
    //	{
    //		if (go == null)
    //		{
    //			UnityEngine.Debug.LogError("Error : UtilFun.GetMat go==null");
    //			return null;
    //		}
    //		Material result = null;
    //		Renderer[] componentsInChildren = go.GetComponentsInChildren<Renderer>(true);
    //		if (componentsInChildren != null && componentsInChildren.Length > 0)
    //		{
    //			Renderer renderer = componentsInChildren[0];
    //			if (renderer != null && renderer.material != null)
    //			{
    //				result = renderer.material;
    //			}
    //		}
    //		return result;
    //	}

    //	// Token: 0x06003F10 RID: 16144 RVA: 0x001C3974 File Offset: 0x001C1B74
    //	public static void SetMat(this GameObject go, Material mat)
    //	{
    //		if (go == null)
    //		{
    //			UnityEngine.Debug.LogError("Error : UtilFun.SetMat go==null");
    //			return;
    //		}
    //		Renderer[] componentsInChildren = go.GetComponentsInChildren<Renderer>(true);
    //		if (componentsInChildren != null && componentsInChildren.Length > 0)
    //		{
    //			Renderer renderer = componentsInChildren[0];
    //			renderer.material = mat;
    //		}
    //	}

    //	// Token: 0x06003F11 RID: 16145 RVA: 0x001C39BC File Offset: 0x001C1BBC
    //	public static void SetMat(this GameObject go, string matPath)
    //	{
    //		if (go == null)
    //		{
    //			UnityEngine.Debug.LogError("Error : UtilFun.SetMat go==null");
    //			return;
    //		}
    //		Material material = FileLoader.LoadObjectFromFile<Material>(matPath.ToAssetBundlePath(), true, true);
    //		if (material == null)
    //		{
    //			UnityEngine.Debug.LogError(string.Concat(new string[]
    //			{
    //				"Error : ",
    //				go.name,
    //				" 的相关材质 ",
    //				matPath,
    //				" 没有找到"
    //			}));
    //			return;
    //		}
    //		Material material2 = material;
    //		Renderer[] componentsInChildren = go.GetComponentsInChildren<Renderer>(true);
    //		if (componentsInChildren != null && componentsInChildren.Length > 0)
    //		{
    //			if (!go.name.Contains("XiongXiangZi"))
    //			{
    //				Renderer renderer = componentsInChildren[0];
    //				renderer.material = material2;
    //			}
    //			else
    //			{
    //				foreach (Renderer renderer2 in componentsInChildren)
    //				{
    //					if (renderer2.name.Contains("XiongXiangZi"))
    //					{
    //						renderer2.material = material2;
    //						break;
    //					}
    //				}
    //			}
    //		}
    //	}

    //	// Token: 0x06003F12 RID: 16146 RVA: 0x001C3AB0 File Offset: 0x001C1CB0
    //	public static void SetColorTex(this GameObject go, Color curColor, string curTexture, bool setColor = true)
    //	{
    //		Texture texture = FileLoader.LoadObjectFromFile<Texture>(curTexture.ToAssetBundlePath(), false, true);
    //		if (texture == null)
    //		{
    //			UnityEngine.Debug.LogError(string.Concat(new string[]
    //			{
    //				"Error : ",
    //				go.name,
    //				" 的相关图片 ",
    //				curTexture,
    //				" 没有找到"
    //			}));
    //			return;
    //		}
    //		Texture texture2 = texture;
    //		Transform transform = go.transform;
    //		if (transform.childCount < 1)
    //		{
    //			Renderer component = transform.GetComponent<Renderer>();
    //			if (component == null)
    //			{
    //				UnityEngine.Debug.LogError("Error : " + transform.name + " 上面没有找到 Renderer");
    //				return;
    //			}
    //			foreach (Material material in component.materials)
    //			{
    //				if (material == null)
    //				{
    //					UnityEngine.Debug.LogError("Error : " + component.name + " 材质为空");
    //				}
    //				else
    //				{
    //					material.SetTexture("_MainTex", texture2);
    //					if (setColor)
    //					{
    //						material.SetColor("_Color", curColor);
    //					}
    //				}
    //			}
    //			Material[] materials;
    //			component.materials = materials;
    //		}
    //		else
    //		{
    //			for (int j = 0; j < transform.childCount; j++)
    //			{
    //				Transform child = transform.GetChild(j);
    //				Renderer component2 = child.GetComponent<Renderer>();
    //				if (!(component2 == null))
    //				{
    //					foreach (Material material2 in component2.materials)
    //					{
    //						if (!(material2 == null) && material2.name.Contains("_body"))
    //						{
    //							material2.SetTexture("_MainTex", texture2);
    //							if (setColor)
    //							{
    //								material2.SetColor("_Color", curColor);
    //							}
    //						}
    //					}
    //					Material[] materials2;
    //					component2.materials = materials2;
    //				}
    //			}
    //		}
    //	}

    //	// Token: 0x06003F13 RID: 16147 RVA: 0x001C3C8C File Offset: 0x001C1E8C
    //	public static string GetBundleKeyPath(string bundlePath)
    //	{
    //		if (string.IsNullOrEmpty(bundlePath))
    //		{
    //			UnityEngine.Debug.LogError("Error : GetBundleKeyPath  bundlePath == null");
    //			return null;
    //		}
    //		string text = Application.dataPath.Replace("\\", "/");
    //		if (bundlePath.StartsWith(text))
    //		{
    //			return bundlePath.Substring(text.Length);
    //		}
    //		return bundlePath;
    //	}

    //	// Token: 0x06003F14 RID: 16148 RVA: 0x001C3CE0 File Offset: 0x001C1EE0
    //	public static void SetActiveWeapon(GameObject weapon, bool bActive, bool immediately = true)
    //	{
    //		if (weapon == null)
    //		{
    //			return;
    //		}
    //		HideMaterialChanger[] components = weapon.GetComponents<HideMaterialChanger>();
    //		if (immediately && components != null)
    //		{
    //			for (int i = 0; i < components.Length; i++)
    //			{
    //				if (components[i] != null)
    //				{
    //					components[i].enabled = false;
    //					UnityEngine.Object.DestroyImmediate(components[i]);
    //				}
    //			}
    //		}
    //		UtilFun.SetActive(weapon, true);
    //		if (immediately)
    //		{
    //			UtilFun.SetActive(weapon, bActive);
    //		}
    //		else if (bActive)
    //		{
    //			HideMaterialChanger.Instance(weapon, 100f).ChangeMaterial(0f, 100f);
    //		}
    //		else
    //		{
    //			HideMaterialChanger.Instance(weapon, 100f).ChangeMaterial(100f, 0f);
    //			PalMain.Instance.StartCoroutine(UtilFun.SetActiveWeaponByFade(weapon));
    //		}
    //	}

    //	// Token: 0x06003F15 RID: 16149 RVA: 0x001C3DAC File Offset: 0x001C1FAC
    //	public static void SetActiveWeapon(PalNPC npc, bool bActive, bool immediately = true)
    //	{
    //		if (npc != null && npc.Weapons != null)
    //		{
    //			foreach (GameObject gameObject in npc.Weapons)
    //			{
    //				if (!(gameObject == null))
    //				{
    //					UtilFun.SetActiveWeapon(gameObject, bActive, immediately);
    //				}
    //			}
    //			if (npc.Data.CharacterID == 0)
    //			{
    //				GameObject weaponAssortObj = npc.WeaponAssortObj;
    //				if (weaponAssortObj != null)
    //				{
    //					UtilFun.SetActiveWeapon(weaponAssortObj, bActive, immediately);
    //				}
    //			}
    //			else if (npc.Data.CharacterID == 4)
    //			{
    //				if (bActive)
    //				{
    //					npc.SetActiveWeaponInBattle();
    //				}
    //				else
    //				{
    //					npc.SetActiveWeaponInCutscene(true);
    //				}
    //			}
    //			else if (npc.Data.CharacterID == 2 && npc.WeaponAssortObj != null)
    //			{
    //				UtilFun.SetActiveWeapon(npc.WeaponAssortObj, bActive, immediately);
    //			}
    //		}
    //		if (npc != null && npc.model != null)
    //		{
    //			Transform transform = npc.model.transform.Find("Bip001/Bip001 Pelvis/Bip001 Spine/Wepan_01");
    //			if (transform != null)
    //			{
    //				UtilFun.SetActive(transform.gameObject, bActive);
    //			}
    //		}
    //	}

    //	// Token: 0x06003F16 RID: 16150 RVA: 0x001C3F14 File Offset: 0x001C2114
    //	private static IEnumerator SetActiveWeaponByFade(GameObject weapon)
    //	{
    //		yield return new WaitForSeconds(1f);
    //		HideMaterialChanger[] hm = weapon.GetComponents<HideMaterialChanger>();
    //		if (hm != null)
    //		{
    //			UtilFun.SetActive(weapon, false);
    //			for (int i = 0; i < hm.Length; i++)
    //			{
    //				if (hm[i] != null)
    //				{
    //					hm[i].enabled = false;
    //					UnityEngine.Object.DestroyImmediate(hm[i]);
    //				}
    //			}
    //		}
    //		yield break;
    //	}

    //	// Token: 0x06003F17 RID: 16151 RVA: 0x001C3F38 File Offset: 0x001C2138
    //	public static Component GetComponentUtil(this GameObject go, Type type)
    //	{
    //		Component result = null;
    //		Component[] componentsInChildren = go.GetComponentsInChildren(type, true);
    //		if (componentsInChildren.Length > 0)
    //		{
    //			result = componentsInChildren[0];
    //		}
    //		return result;
    //	}

    //	// Token: 0x06003F18 RID: 16152 RVA: 0x001C3F60 File Offset: 0x001C2160
    //	public static string GetAnimFilePath(string actorName, string animName)
    //	{
    //		return Path.Combine(actorName, animName).ToAnimationPath();
    //	}

    public static void SetActive(GameObject go, bool bActive)
    {
        if (go != null && go.activeSelf != bActive)
        {
            try
            {
                go.SetActive(bActive);
            }
            catch (Exception ex)
            {
                UnityEngine.Debug.Log("Exception catched:\n");
                UnityEngine.Debug.Log(ex.Message + "\n" + ex.StackTrace);
            }
        }
    }

    public static void SetActive(this Transform tf, bool bActive)
    {
        UtilFun.SetActive(tf.gameObject, bActive);
    }

    //	// Token: 0x06003F1B RID: 16155 RVA: 0x001C4004 File Offset: 0x001C2204
    //	public static string RemoveSceneQualityLevel(this string SceneName)
    //	{
    //		if (SceneName.Contains("_Low"))
    //		{
    //			return SceneName.Replace("_Low", string.Empty);
    //		}
    //		return SceneName;
    //	}

    //	// Token: 0x06003F1C RID: 16156 RVA: 0x001C4034 File Offset: 0x001C2234
    //	public static void DestroyAllChild(Transform t)
    //	{
    //		for (int i = t.childCount - 1; i >= 0; i--)
    //		{
    //			NGUITools.Destroy(t.GetChild(i).gameObject);
    //		}
    //	}

    //	// Token: 0x06003F1D RID: 16157 RVA: 0x001C406C File Offset: 0x001C226C
    //	public static IEnumerator LoadLevelAsync(int index)
    //	{
    //		yield return Resources.UnloadUnusedAssets();
    //		yield return new WaitForSeconds(0.5f);
    //		AsyncOperation async = SceneManager.LoadSceneAsync(index);
    //		yield return async;
    //		yield break;
    //	}

    //	// Token: 0x06003F1E RID: 16158 RVA: 0x001C4090 File Offset: 0x001C2290
    //	public static IEnumerator LoadLevelAsync(string levelName)
    //	{
    //		yield return new WaitForSeconds(0.5f);
    //		AsyncOperation async = SceneManager.LoadSceneAsync(levelName);
    //		yield return async;
    //		yield break;
    //	}

    //	// Token: 0x06003F1F RID: 16159 RVA: 0x001C40B4 File Offset: 0x001C22B4
    //	public static bool IsMonster(this GameObject go)
    //	{
    //		if (go == null)
    //		{
    //			UnityEngine.Debug.LogError("go为null");
    //			return false;
    //		}
    //		PalNPC palNPC = go.GetComponent<PalNPC>();
    //		if (palNPC == null)
    //		{
    //			go = go.GetModelObj(false);
    //			Agent component = go.GetComponent<Agent>();
    //			if (component == null)
    //			{
    //				return false;
    //			}
    //			palNPC = component.palNPC;
    //		}
    //		return !(palNPC == null) && palNPC.MonsterGroups.Length >= 1;
    //	}

    //	// Token: 0x06003F20 RID: 16160 RVA: 0x001C4130 File Offset: 0x001C2330
    //	public static GameObject Instantiate(this GameObject go)
    //	{
    //		return UnityEngine.Object.Instantiate<GameObject>(go);
    //	}

    //	// Token: 0x06003F21 RID: 16161 RVA: 0x001C4138 File Offset: 0x001C2338
    //	public static bool IsMonster(this Transform tf)
    //	{
    //		if (tf == null)
    //		{
    //			UnityEngine.Debug.LogError("tf为null");
    //			return false;
    //		}
    //		return tf.gameObject.IsMonster();
    //	}

    //	// Token: 0x06003F22 RID: 16162 RVA: 0x001C4160 File Offset: 0x001C2360
    //	public static bool CanSneak(this Transform tf)
    //	{
    //		if (tf == null)
    //		{
    //			UnityEngine.Debug.LogError("CanSneak 里 tf == null");
    //			return false;
    //		}
    //		if (SneakScript.monsterCanSneaks.Contains(tf))
    //		{
    //			return true;
    //		}
    //		GameObject modelObj = tf.gameObject.GetModelObj(false);
    //		MonsterStateScript component = modelObj.GetComponent<MonsterStateScript>();
    //		return !(component == null) && component.CurState == MonsterStateScript.MonsterState.CanBeSneaked;
    //	}

    //	// Token: 0x06003F23 RID: 16163 RVA: 0x001C41C8 File Offset: 0x001C23C8
    //	public static bool IsSub(Transform A, Transform B)
    //	{
    //		foreach (Transform x in A.GetComponentsInChildren<Transform>(true))
    //		{
    //			if (x == B)
    //			{
    //				return true;
    //			}
    //		}
    //		return false;
    //	}

    //	// Token: 0x06003F24 RID: 16164 RVA: 0x001C4204 File Offset: 0x001C2404
    //	public static PalSE PlaySE_Util(GameObject[] actors, string path, bool bBaseOnSEPos, bool bDisableController = true)
    //	{
    //		if (actors == null || actors.Length < 1)
    //		{
    //			UnityEngine.Debug.LogError("Error : PlaySE actors 错误");
    //			return null;
    //		}
    //		if (string.IsNullOrEmpty(path))
    //		{
    //			UnityEngine.Debug.LogError("Error : PlaySE path 为 空");
    //			return null;
    //		}
    //		int num = path.LastIndexOf('/');
    //		string s = path.Substring(num + 1, 4);
    //		int id = -1;
    //		if (!int.TryParse(s, out id))
    //		{
    //			UnityEngine.Debug.LogWarning("Error : PlaySE path错误");
    //			return null;
    //		}
    //		GameObject gameObject = PalSE.LoadPalSEGameObject(path, id);
    //		UtilFun.SetPosition(gameObject.transform, actors[0].transform.position);
    //		gameObject.transform.rotation = actors[0].transform.rotation;
    //		PalSE component = gameObject.GetComponent<PalSE>();
    //		component.PlayInDrama(actors, bBaseOnSEPos, false, bDisableController);
    //		return component;
    //	}

    //	// Token: 0x06003F25 RID: 16165 RVA: 0x001C42C0 File Offset: 0x001C24C0
    //	public static PalSE PlaySE(this GameObject[] actors, string path, bool bBaseOnSEPos, bool bDisableController = true)
    //	{
    //		return UtilFun.PlaySE_Util(actors, path, bBaseOnSEPos, bDisableController);
    //	}

    //	// Token: 0x06003F26 RID: 16166 RVA: 0x001C42CC File Offset: 0x001C24CC
    //	public static SpecialEffect PlayUnitSE(this GameObject go, int Id)
    //	{
    //		if (go == null)
    //		{
    //			UnityEngine.Debug.LogError("Error : PlayUnitSE go 为null");
    //			return null;
    //		}
    //		GameObject gameObject = SpecialEffect.CreateUnitSE(Id, null, false, true, false);
    //		if (gameObject == null)
    //		{
    //			UnityEngine.Debug.LogError("Error : " + Id.ToString() + "载入失败");
    //			return null;
    //		}
    //		gameObject.transform.parent = go.transform;
    //		gameObject.transform.localPosition = Vector3.zero;
    //		gameObject.transform.localRotation = Quaternion.identity;
    //		SpecialEffect component = gameObject.GetComponent<SpecialEffect>();
    //		if (component == null)
    //		{
    //			UnityEngine.Debug.LogError(Id.ToString() + "载入的对象没有 SpecialEffect");
    //			return null;
    //		}
    //		component.Play(0f, false);
    //		return component;
    //	}

    //	// Token: 0x06003F27 RID: 16167 RVA: 0x001C4390 File Offset: 0x001C2590
    //	public static bool CanShowMiniMap()
    //	{
    //		if (SceneManager.GetActiveScene().buildIndex == 0)
    //		{
    //			return false;
    //		}
    //		MapData data = MapData.GetData(UtilFun.GetPalMapLevel(SceneManager.GetActiveScene().buildIndex));
    //		if (data == null)
    //		{
    //			return false;
    //		}
    //		int flag = PalMain.GetFlag(data.mapFlag);
    //		return (flag & 1) == 1;
    //	}

    //	// Token: 0x06003F28 RID: 16168 RVA: 0x001C43EC File Offset: 0x001C25EC
    //	public static bool CanShowFlyMapBtn()
    //	{
    //		if (PalMain.IsDLC)
    //		{
    //			return false;
    //		}
    //		if (SceneManager.GetActiveScene().buildIndex == 0)
    //		{
    //			return false;
    //		}
    //		if (PalMain.GetFlag(1) < 213050)
    //		{
    //			return false;
    //		}
    //		MapData data = MapData.GetData(UtilFun.GetPalMapLevel(SceneManager.GetActiveScene().buildIndex));
    //		if (data == null)
    //		{
    //			return false;
    //		}
    //		int flag = PalMain.GetFlag(data.mapFlag);
    //		return (flag & 2) == 2;
    //	}

    //	// Token: 0x06003F29 RID: 16169 RVA: 0x001C4464 File Offset: 0x001C2664
    //	public static bool CanClickFlyMapBtn()
    //	{
    //		if (SceneManager.GetActiveScene().buildIndex == 0)
    //		{
    //			return false;
    //		}
    //		if (FlagManager.GetFlag(14800) == 0)
    //		{
    //			return false;
    //		}
    //		MapData data = MapData.GetData(UtilFun.GetPalMapLevel(SceneManager.GetActiveScene().buildIndex));
    //		if (data == null)
    //		{
    //			return false;
    //		}
    //		int flag = PalMain.GetFlag(data.mapFlag);
    //		return (flag & 4) == 4;
    //	}

    //	// Token: 0x06003F2A RID: 16170 RVA: 0x001C44D0 File Offset: 0x001C26D0
    //	public static void SetMiniMapVisible(bool visible)
    //	{
    //		MapData data = MapData.GetData(UtilFun.GetPalMapLevel(SceneManager.GetActiveScene().buildIndex));
    //		if (data == null)
    //		{
    //			return;
    //		}
    //		int num = PalMain.GetFlag(data.mapFlag);
    //		if (visible)
    //		{
    //			MiniMap.Instance.Show();
    //			num |= 1;
    //		}
    //		else
    //		{
    //			MiniMap.Instance.Hide();
    //			if ((num & 1) == 1)
    //			{
    //				num ^= 1;
    //			}
    //		}
    //		PalMain.SetFlag(data.mapFlag, num);
    //	}

    //	// Token: 0x06003F2B RID: 16171 RVA: 0x001C4544 File Offset: 0x001C2744
    //	public static void SetFlyMapBtnVisible(bool visible)
    //	{
    //		MiniMap.Instance.FlyButton.cachedGameObject.SetActive(visible);
    //		MapData data = MapData.GetData(UtilFun.GetPalMapLevel(SceneManager.GetActiveScene().buildIndex));
    //		if (data == null)
    //		{
    //			return;
    //		}
    //		int num = PalMain.GetFlag(data.mapFlag);
    //		if (visible)
    //		{
    //			num |= 2;
    //		}
    //		else if ((num & 2) == 2)
    //		{
    //			num ^= 2;
    //		}
    //		PalMain.SetFlag(data.mapFlag, num);
    //	}

    //	// Token: 0x06003F2C RID: 16172 RVA: 0x001C45BC File Offset: 0x001C27BC
    //	public static void SetFlyMapBtnEnabled(bool enabled)
    //	{
    //		MiniMap.Instance.FlyButton.enabled = enabled;
    //		MapData data = MapData.GetData(UtilFun.GetPalMapLevel(SceneManager.GetActiveScene().buildIndex));
    //		if (data == null)
    //		{
    //			return;
    //		}
    //		int num = PalMain.GetFlag(data.mapFlag);
    //		if (enabled)
    //		{
    //			num |= 4;
    //		}
    //		else if ((num & 4) == 4)
    //		{
    //			num ^= 4;
    //		}
    //		PalMain.SetFlag(data.mapFlag, num);
    //	}

    //	// Token: 0x06003F2D RID: 16173 RVA: 0x001C462C File Offset: 0x001C282C
    //	public static void SetAllFlyMapBtnEnalble(bool allEnabled)
    //	{
    //		MiniMap.Instance.FlyButton.enabled = allEnabled;
    //		FlagManager.SetFlag(14800, (!allEnabled) ? 0 : 1, true);
    //	}

    //	// Token: 0x06003F2E RID: 16174 RVA: 0x001C4664 File Offset: 0x001C2864
    //	public static Color UInt32ToUnityColor(uint v)
    //	{
    //		return new Color((v >> 24) / 255f, (v >> 16 & 255u) / 255f, (v >> 8 & 255u) / 255f, (v & 255u) / 255f);
    //	}

    //	// Token: 0x06003F2F RID: 16175 RVA: 0x001C46B4 File Offset: 0x001C28B4
    //	public static void SetCameraHDRByConfig(bool b)
    //	{
    //		if (Camera.main != null)
    //		{
    //			if (UtilFun.GetPalMapLevel(SceneManager.GetActiveScene().buildIndex) == 19 || SceneManager.GetActiveScene().buildIndex == 0)
    //			{
    //				Camera.main.hdr = false;
    //			}
    //			else
    //			{
    //				Camera.main.hdr = b;
    //			}
    //		}
    //	}

    //	// Token: 0x06003F30 RID: 16176 RVA: 0x001C4718 File Offset: 0x001C2918
    //	public static int GetPalMapLevel(int level)
    //	{
    //		if (UtilFun.maplevelKV.Count == 0)
    //		{
    //			MapData[] datasFromFile = MapData.GetDatasFromFile();
    //			for (int i = 0; i < datasFromFile.Length; i++)
    //			{
    //				if (!UtilFun.maplevelKV.ContainsKey(datasFromFile[i].SceneID))
    //				{
    //					UtilFun.maplevelKV.Add(datasFromFile[i].SceneID, datasFromFile[i].ID);
    //				}
    //				if (!UtilFun.maplevelKV.ContainsKey(datasFromFile[i].LowSceneID))
    //				{
    //					UtilFun.maplevelKV.Add(datasFromFile[i].LowSceneID, datasFromFile[i].ID);
    //				}
    //			}
    //		}
    //		if (UtilFun.maplevelKV.ContainsKey(level))
    //		{
    //			return UtilFun.maplevelKV[level];
    //		}
    //		return -1;
    //	}

    //	// Token: 0x06003F31 RID: 16177 RVA: 0x001C47D0 File Offset: 0x001C29D0
    //	public static void DestroyMats(this MonoBehaviour component)
    //	{
    //		if (component == null)
    //		{
    //			return;
    //		}
    //		ArrayList arrayList = new ArrayList();
    //		ArrayList arrayList2 = new ArrayList();
    //		foreach (Renderer renderer in component.GetComponentsInChildren<Renderer>(true))
    //		{
    //			if (!(renderer == null))
    //			{
    //				for (int j = 0; j < renderer.materials.Length; j++)
    //				{
    //					Material material = renderer.materials[j];
    //					if (!(material == null))
    //					{
    //						Texture textureUtil = material.GetTextureUtil("_MainTex");
    //						Texture textureUtil2 = material.GetTextureUtil("_BumpMap");
    //						Texture textureUtil3 = material.GetTextureUtil("_SpecMap");
    //						if (textureUtil != null && !arrayList.Contains(textureUtil))
    //						{
    //							arrayList.Add(textureUtil);
    //						}
    //						if (textureUtil2 != null && !arrayList.Contains(textureUtil2))
    //						{
    //							arrayList.Add(textureUtil2);
    //						}
    //						if (textureUtil3 != null && !arrayList.Contains(textureUtil3))
    //						{
    //							arrayList.Add(textureUtil3);
    //						}
    //						if (!arrayList2.Contains(material))
    //						{
    //							arrayList2.Add(material);
    //						}
    //					}
    //				}
    //			}
    //		}
    //		for (int k = 0; k < arrayList.Count; k++)
    //		{
    //			UnityEngine.Object obj = arrayList[k] as UnityEngine.Object;
    //			UnityEngine.Object.DestroyImmediate(obj);
    //		}
    //		arrayList.Clear();
    //		for (int l = 0; l < arrayList2.Count; l++)
    //		{
    //			UnityEngine.Object obj2 = arrayList2[l] as UnityEngine.Object;
    //			UnityEngine.Object.DestroyImmediate(obj2);
    //		}
    //		arrayList2.Clear();
    //	}

    //	// Token: 0x06003F32 RID: 16178 RVA: 0x001C497C File Offset: 0x001C2B7C
    //	public static Texture GetTextureUtil(this Material mat, string propertyName)
    //	{
    //		if (mat == null)
    //		{
    //			UnityEngine.Debug.LogError("mat == null");
    //			return null;
    //		}
    //		if (!mat.HasProperty(propertyName))
    //		{
    //			UnityEngine.Debug.LogError(mat.name + " 没有 " + propertyName);
    //			return null;
    //		}
    //		return mat.GetTexture(propertyName);
    //	}

    //	// Token: 0x06003F33 RID: 16179 RVA: 0x001C49D0 File Offset: 0x001C2BD0
    //	public static void SetLastSaveId(int id)
    //	{
    //		string readWritePath = ConfigManager.ReadWritePath;
    //		if (!Directory.Exists(readWritePath))
    //		{
    //			Directory.CreateDirectory(readWritePath);
    //		}
    //		try
    //		{
    //			using (BinaryWriter binaryWriter = new BinaryWriter(File.Open(readWritePath + "/LSI", FileMode.Create)))
    //			{
    //				binaryWriter.Write(id);
    //			}
    //		}
    //		catch (Exception ex)
    //		{
    //			UnityEngine.Debug.LogError(ex.ToString());
    //		}
    //	}

    //	// Token: 0x06003F34 RID: 16180 RVA: 0x001C4A70 File Offset: 0x001C2C70
    //	public static int GetLastSaveId()
    //	{
    //		string path = Path.Combine(ConfigManager.ReadWritePath, "LSI");
    //		if (!Utilities.FileExists(path))
    //		{
    //			return 1;
    //		}
    //		int result;
    //		try
    //		{
    //			using (BinaryReader binaryReader = new BinaryReader(File.OpenRead(path)))
    //			{
    //				result = binaryReader.ReadInt32();
    //			}
    //		}
    //		catch (Exception ex)
    //		{
    //			UnityEngine.Debug.LogError(ex.ToString());
    //			result = 1;
    //		}
    //		return result;
    //	}

    //	// Token: 0x06003F35 RID: 16181 RVA: 0x001C4B18 File Offset: 0x001C2D18
    //	public static bool HasSaveFile()
    //	{
    //		string path = Path.Combine(ConfigManager.ReadWritePath, "LSI");
    //		return Utilities.FileExists(path);
    //	}

    //	// Token: 0x06003F36 RID: 16182 RVA: 0x001C4B44 File Offset: 0x001C2D44
    //	public static void WriteSaveLog(string str)
    //	{
    //	}

    //	// Token: 0x06003F37 RID: 16183 RVA: 0x001C4B48 File Offset: 0x001C2D48
    //	public static void DestroyGhostCamera()
    //	{
    //		GhostCamera[] components = Camera.main.GetComponents<GhostCamera>();
    //		for (int i = 0; i < components.Length; i++)
    //		{
    //			if (components[i] != null)
    //			{
    //				UnityEngine.Object.Destroy(components[i]);
    //			}
    //		}
    //	}

    //	// Token: 0x06003F38 RID: 16184 RVA: 0x001C4B8C File Offset: 0x001C2D8C
    //	public static void SetEnableStroll(this GameObject go, bool bActive)
    //	{
    //		if (go == null)
    //		{
    //			return;
    //		}
    //		foreach (uScriptCode uScriptCode in go.GetComponents<uScriptCode>())
    //		{
    //			string text = uScriptCode.GetType().ToString().ToLower();
    //			if (text.Contains("stroll") || text.Contains("pursue"))
    //			{
    //				uScriptCode.enabled = bActive;
    //			}
    //		}
    //	}

    //	// Token: 0x06003F39 RID: 16185 RVA: 0x001C4C00 File Offset: 0x001C2E00
    //	public static void GetDirLightContent()
    //	{
    //		Light[] array = UnityEngine.Object.FindObjectsOfType<Light>();
    //		foreach (Light light in array)
    //		{
    //			if (light.type == LightType.Directional)
    //			{
    //				SoftStar.Pal6.Console.DebugLog("---" + light.name + "----------");
    //				SoftStar.Pal6.Console.DebugLog("light.enabled == " + light.enabled);
    //				SoftStar.Pal6.Console.DebugLog("light.shadows == " + light.shadows);
    //				SoftStar.Pal6.Console.DebugLog("shadowDistance == " + QualitySettings.shadowDistance);
    //			}
    //		}
    //	}

    //	// Token: 0x06003F3A RID: 16186 RVA: 0x001C4CA8 File Offset: 0x001C2EA8
    //	public static void AdjustNavAgentOffset(this Transform agentTF)
    //	{
    //		if (agentTF == null)
    //		{
    //			return;
    //		}
    //		NavMeshAgent component = agentTF.GetComponent<NavMeshAgent>();
    //		if (component == null)
    //		{
    //			UnityEngine.Debug.LogError("Error : " + agentTF.name + " NavMeshAgent 不存在");
    //			return;
    //		}
    //		Transform transform = null;
    //		Transform[] componentsInChildren = agentTF.GetComponentsInChildren<Transform>();
    //		foreach (Transform transform2 in componentsInChildren)
    //		{
    //			if (transform2.name.Contains("Toe0"))
    //			{
    //				transform = transform2;
    //				break;
    //			}
    //		}
    //		if (transform == null)
    //		{
    //			UnityEngine.Debug.LogError("Error : " + agentTF.name + "没有找到 toe0");
    //			return;
    //		}
    //		Vector3 vector = Vector3.zero;
    //		int layer = agentTF.gameObject.layer;
    //		agentTF.gameObject.layer = PalMain.IgnoreLayer;
    //		Vector3 position = transform.position;
    //		position.y += 0.15f;
    //		RaycastHit raycastHit;
    //		if (Physics.Raycast(position, Vector3.down, out raycastHit))
    //		{
    //			vector = raycastHit.point;
    //		}
    //		agentTF.gameObject.layer = layer;
    //		float num = transform.position.y - vector.y;
    //		float num2 = Mathf.Abs(num);
    //		if (num2 > 0.007f)
    //		{
    //			component.baseOffset -= num;
    //			if (num2 < 0.2f && num < 0f)
    //			{
    //				CharacterController component2 = agentTF.GetComponent<CharacterController>();
    //				if (component2 != null)
    //				{
    //					component2.height -= num;
    //				}
    //			}
    //		}
    //	}

    //	// Token: 0x06003F3B RID: 16187 RVA: 0x001C4E40 File Offset: 0x001C3040
    //	public static void SetHeadLight(this GameObject go, bool bActive)
    //	{
    //		if (go == null)
    //		{
    //			UnityEngine.Debug.LogError("Error : go == null");
    //			return;
    //		}
    //		go = go.GetModelObj(false);
    //		if (bActive)
    //		{
    //			if (UtilFun.HeadLight == null)
    //			{
    //				GameObject gameObject = new GameObject("HeadLight", new Type[]
    //				{
    //					typeof(Light)
    //				});
    //				UtilFun.HeadLight = gameObject.GetComponent<Light>();
    //			}
    //			UtilFun.HeadLight.type = LightType.Point;
    //			UtilFun.HeadLight.range = 12f;
    //			UtilFun.SetActive(UtilFun.HeadLight.gameObject, true);
    //			UtilFun.HeadLight.intensity = 0.43f;
    //			PalLamp orAddComponent = UtilFun.HeadLight.gameObject.GetOrAddComponent<PalLamp>();
    //			orAddComponent.InitData(UtilFun.HeadLight.intensity);
    //			Transform transform = UtilFun.HeadLight.transform;
    //			transform.parent = go.transform;
    //			transform.localRotation = Quaternion.identity;
    //			transform.localPosition = new Vector3(0f, 2f, 0.6f);
    //		}
    //		else if (UtilFun.HeadLight != null)
    //		{
    //			UtilFun.SetActive(UtilFun.HeadLight.gameObject, false);
    //		}
    //	}

    //	// Token: 0x06003F3C RID: 16188 RVA: 0x001C4F68 File Offset: 0x001C3168
    //	public static void SetActivePointLightShadow(bool bActive)
    //	{
    //		Light[] array = UnityEngine.Object.FindObjectsOfType<Light>();
    //		foreach (Light light in array)
    //		{
    //			if (light.type != LightType.Directional)
    //			{
    //				light.shadows = ((!bActive) ? LightShadows.None : LightShadows.Soft);
    //			}
    //		}
    //	}

    //	// Token: 0x06003F3D RID: 16189 RVA: 0x001C4FBC File Offset: 0x001C31BC
    //	public static void CameraFollowModle2To3()
    //	{
    //		if (Camera.main != null)
    //		{
    //			SmoothFollow2 component = Camera.main.GetComponent<SmoothFollow2>();
    //			if (component == null)
    //			{
    //				return;
    //			}
    //			SmoothFollow3 smoothFollow = Camera.main.GetComponent<SmoothFollow3>();
    //			if (smoothFollow == null)
    //			{
    //				smoothFollow = Camera.main.gameObject.AddComponent<SmoothFollow3>();
    //			}
    //			smoothFollow.Init(component.targetRoot.gameObject);
    //			smoothFollow.enabled = true;
    //			component.enabled = false;
    //			smoothFollow.CamDistance = component.CamDistance;
    //			smoothFollow.CamAngleH = component.CamAngleH;
    //			smoothFollow.CamAngleV = component.CamAngleV;
    //			smoothFollow.CamPos = component.CamPos;
    //			smoothFollow.CamRot = component.CamRot;
    //			smoothFollow.lastAngleH = component.lastAngleH;
    //			smoothFollow.TargetCamRot = component.TargetCamRot;
    //			smoothFollow.bNeedReturn = component.bNeedReturn;
    //		}
    //	}

    //	// Token: 0x06003F3E RID: 16190 RVA: 0x001C5098 File Offset: 0x001C3298
    //	public static void CameraFollowModle3To2()
    //	{
    //		if (Camera.main != null)
    //		{
    //			SmoothFollow2 component = Camera.main.GetComponent<SmoothFollow2>();
    //			if (component == null)
    //			{
    //				return;
    //			}
    //			SmoothFollow3 component2 = Camera.main.GetComponent<SmoothFollow3>();
    //			if (component2 == null)
    //			{
    //				return;
    //			}
    //			component2.enabled = false;
    //			component.enabled = true;
    //			component.Init(component2.targetRoot.gameObject);
    //			component.CamDistance = component2.CamDistance;
    //			component.CamAngleH = component2.CamAngleH;
    //			component.CamAngleV = component2.CamAngleV;
    //			component.CamPos = component2.CamPos;
    //			component.CamRot = component2.CamRot;
    //			component.lastAngleH = component2.lastAngleH;
    //			component.TargetCamRot = component2.TargetCamRot;
    //			component.bNeedReturn = component2.bNeedReturn;
    //		}
    //	}

    //	// Token: 0x170004E8 RID: 1256
    //	// (get) Token: 0x06003F3F RID: 16191 RVA: 0x001C5164 File Offset: 0x001C3364
    //	private static int IlluParamID
    //	{
    //		get
    //		{
    //			if (UtilFun.m_IlluParamID < 0)
    //			{
    //				UtilFun.m_IlluParamID = Shader.PropertyToID("_IllumColor");
    //			}
    //			return UtilFun.m_IlluParamID;
    //		}
    //	}

    //	// Token: 0x06003F40 RID: 16192 RVA: 0x001C5188 File Offset: 0x001C3388
    //	public static void ReplaceShader(GameObject assetGo)
    //	{
    //		string str = "_GloEmi";
    //		if (assetGo != null)
    //		{
    //			foreach (Renderer renderer in assetGo.GetComponentsInChildren<Renderer>(true))
    //			{
    //				for (int j = 0; j < renderer.materials.Length; j++)
    //				{
    //					Material material = renderer.materials[j];
    //					if (!(material == null))
    //					{
    //						if (material.HasProperty(UtilFun.IlluParamID))
    //						{
    //							Shader shader = Shader.Find(material.shader.name + str);
    //							if (!(shader == null))
    //							{
    //								material.shader = shader;
    //							}
    //						}
    //					}
    //				}
    //			}
    //		}
    //	}

    //	// Token: 0x06003F41 RID: 16193 RVA: 0x001C5248 File Offset: 0x001C3448
    //	public static void SetPerceptionActive(this GameObject go, bool bActive)
    //	{
    //		if (go == null)
    //		{
    //			return;
    //		}
    //		PalNPC component = go.GetComponent<PalNPC>();
    //		if (component == null)
    //		{
    //			return;
    //		}
    //		component.perception.SetActive(bActive);
    //	}

    //	// Token: 0x06003F42 RID: 16194 RVA: 0x001C5284 File Offset: 0x001C3484
    //	public static void TeamRecoverHPAndMP()
    //	{
    //		List<GameObject> activePlayers = PlayersManager.ActivePlayers;
    //		for (int i = 0; i < activePlayers.Count; i++)
    //		{
    //			PalNPC component = activePlayers[i].GetComponent<PalNPC>();
    //			if (component != null)
    //			{
    //				component.Data.HPMPDP.HP = component.Data.HPMPDP.HPRange;
    //				component.Data.HPMPDP.MP = component.Data.HPMPDP.MPRange;
    //			}
    //		}
    //	}

    //	// Token: 0x06003F43 RID: 16195 RVA: 0x001C5314 File Offset: 0x001C3514
    //	public static uint ChangeOffCloth(GameObject gobj)
    //	{
    //		Agent component = gobj.GetComponent<Agent>();
    //		if (component != null && component.palNPC != null)
    //		{
    //			FashionClothItem fashionClothItem = component.palNPC.GetSlot(EquipSlotEnum.FashionCloth) as FashionClothItem;
    //			if (fashionClothItem != null)
    //			{
    //				uint typeID = fashionClothItem.ItemType.TypeID;
    //				component.palNPC.PutOffEquip(EquipSlotEnum.FashionCloth);
    //				return typeID;
    //			}
    //		}
    //		return 0u;
    //	}

    //	// Token: 0x06003F44 RID: 16196 RVA: 0x001C5378 File Offset: 0x001C3578
    //	public static void ChangeOnCloth(GameObject gobj, uint type)
    //	{
    //		Agent component = gobj.GetComponent<Agent>();
    //		if (component != null && component.palNPC != null)
    //		{
    //			FashionClothItem fashionClothItem = component.palNPC.GetSlot(EquipSlotEnum.FashionCloth) as FashionClothItem;
    //			if (fashionClothItem != null && type != 0u)
    //			{
    //				component.palNPC.PutOnEquip(ItemManager.GetInstance().GetOrCreatePackage(1u).GetItemsByItemType(type)[0].Target as IItemAssemble<PalNPC>);
    //			}
    //		}
    //	}

    //	// Token: 0x06003F45 RID: 16197 RVA: 0x001C53F0 File Offset: 0x001C35F0
    //	public static void SetCloth(this PalNPC npc, uint id)
    //	{
    //		uint id2 = ItemManager.GetID(5u, id);
    //		ItemPackage package = ItemManager.GetInstance().GetPackage(1u);
    //		int countByItemType = package.GetCountByItemType(id2);
    //		if (countByItemType < 1)
    //		{
    //			package.AddNewItem(id2, 1);
    //		}
    //		IItem target = package.GetItemsByItemType(id2)[0].Target;
    //		npc.PutOnEquip(target as IItemAssemble<PalNPC>);
    //	}

    //	// Token: 0x06003F46 RID: 16198 RVA: 0x001C5448 File Offset: 0x001C3648
    //	public static string GetLineNum(this UnityEngine.Object obj)
    //	{
    //		StackTrace stackTrace = new StackTrace(1, true);
    //		return obj.GetType().ToString() + " : " + stackTrace.GetFrame(0).GetFileLineNumber().ToString() + " : ";
    //	}

    //	// Token: 0x06003F47 RID: 16199 RVA: 0x001C548C File Offset: 0x001C368C
    //	public static SkinnedMeshRenderer GetFace(this GameObject model)
    //	{
    //		if (model == null)
    //		{
    //			return null;
    //		}
    //		Transform transform = null;
    //		Transform transform2 = model.transform;
    //		int childCount = transform2.childCount;
    //		for (int i = 0; i < childCount; i++)
    //		{
    //			Transform child = transform2.GetChild(i);
    //			if (child.name.Contains("_Face"))
    //			{
    //				transform = child;
    //				break;
    //			}
    //		}
    //		if (transform == null)
    //		{
    //			return null;
    //		}
    //		return transform.GetComponent<SkinnedMeshRenderer>();
    //	}

    //	// Token: 0x06003F48 RID: 16200 RVA: 0x001C5508 File Offset: 0x001C3708
    //	public static void SetOpenEye(this GameObject model, bool OpenEye)
    //	{
    //		SkinnedMeshRenderer face = model.GetFace();
    //		if (face == null)
    //		{
    //			UnityEngine.Debug.LogError("Error : " + model.name + " 没有找到_Face");
    //			return;
    //		}
    //		float value = (!OpenEye) ? 100f : 0f;
    //		RandomBlink component = face.GetComponent<RandomBlink>();
    //		if (component != null)
    //		{
    //			component.enabled = OpenEye;
    //		}
    //		face.SetBlendShapeWeight(8, value);
    //	}

    //	// Token: 0x06003F49 RID: 16201 RVA: 0x001C557C File Offset: 0x001C377C
    //	public static void SetApplyRootMotion(this Animator animator, bool bActive)
    //	{
    //		if (animator == null)
    //		{
    //			UnityEngine.Debug.LogError("Error : SetApplyRootMotion animator==null");
    //			return;
    //		}
    //		animator.applyRootMotion = bActive;
    //	}

    //	// Token: 0x06003F4A RID: 16202 RVA: 0x001C559C File Offset: 0x001C379C
    //	public static float GetCurMapShadowDis()
    //	{
    //		MapData data = MapData.GetData(ScenesManager.CurLoadedLevel);
    //		return (data != null) ? data.ShadowDistance : 0f;
    //	}

    //	// Token: 0x06003F4B RID: 16203 RVA: 0x001C55CC File Offset: 0x001C37CC
    //	public static void SetPosition(Transform tf, Vector3 pos)
    //	{
    //		if (tf == null)
    //		{
    //			UnityEngine.Debug.LogError("Error : UtilFun.SetPosition  tf==null\n\n");
    //			return;
    //		}
    //		tf.position = pos;
    //	}

    //	// Token: 0x06003F4C RID: 16204 RVA: 0x001C55EC File Offset: 0x001C37EC
    //	public static void SetVolume(AudioSource audioSource, float volume)
    //	{
    //		if (audioSource == null)
    //		{
    //			UnityEngine.Debug.LogError("Set Null AudioSource");
    //		}
    //		else
    //		{
    //			audioSource.volume = volume;
    //		}
    //	}

    //	// Token: 0x06003F4D RID: 16205 RVA: 0x001C561C File Offset: 0x001C381C
    //	public static bool CanSceneSkill(int playerID)
    //	{
    //		switch (playerID)
    //		{
    //		case 0:
    //			return true;
    //		case 1:
    //			return true;
    //		case 2:
    //			return GanYingObjectManager.instance != null && GanYingObjectManager.instance.enabled;
    //		case 3:
    //			return true;
    //		case 4:
    //			return true;
    //		case 5:
    //			return ShotManager.instance != null;
    //		default:
    //			return true;
    //		}
    //	}

    //	// Token: 0x06003F4E RID: 16206 RVA: 0x001C5690 File Offset: 0x001C3890
    //	public static void ChangeHairShader(bool bUseAlpha, string[] paths)
    //	{
    //		if (paths == null || paths.Length < 1)
    //		{
    //			return;
    //		}
    //		List<GameObject> list = new List<GameObject>();
    //		foreach (string text in paths)
    //		{
    //			if (!string.IsNullOrEmpty(text))
    //			{
    //				GameObject gameObject = GameObject.Find(text);
    //				if (gameObject == null)
    //				{
    //					UnityEngine.Debug.LogError("Error : 没有找到" + text);
    //				}
    //				else
    //				{
    //					list.Add(gameObject);
    //				}
    //			}
    //		}
    //		UtilFun.ChangeHairShader(bUseAlpha, list.ToArray());
    //	}

    //	// Token: 0x06003F4F RID: 16207 RVA: 0x001C5718 File Offset: 0x001C3918
    //	public static void ChangeHairShader(bool bUseAlpha, GameObject[] objs)
    //	{
    //		if (objs == null || objs.Length < 1)
    //		{
    //			return;
    //		}
    //		Shader shader;
    //		if (bUseAlpha)
    //		{
    //			shader = Shader.Find("Custom/Kami3_GloEmi_Alpha");
    //		}
    //		else
    //		{
    //			shader = Shader.Find("Custom/Kami3_GloEmi");
    //		}
    //		foreach (GameObject gameObject in objs)
    //		{
    //			if (!(gameObject == null))
    //			{
    //				GameObject modelObj = gameObject.GetModelObj(false);
    //				ShroudInstance component = modelObj.GetComponent<ShroudInstance>();
    //				if (component == null)
    //				{
    //					UnityEngine.Debug.LogError("Error : " + gameObject.name + " 没有找到ShroudInstance");
    //				}
    //				else
    //				{
    //					GameObject hairObj = component.GetHairObj();
    //					if (hairObj != null)
    //					{
    //						MeshRenderer component2 = hairObj.GetComponent<MeshRenderer>();
    //						if (component2 != null && component2.material != null)
    //						{
    //							Material material = component2.material;
    //							material.shader = shader;
    //						}
    //					}
    //				}
    //			}
    //		}
    //	}

    //	// Token: 0x06003F50 RID: 16208 RVA: 0x001C580C File Offset: 0x001C3A0C
    //	public static int GetNPCID(Transform tf)
    //	{
    //		int result = -1;
    //		Agent component = tf.GetComponent<Agent>();
    //		if (component != null && component.palNPC != null)
    //		{
    //			result = component.palNPC.Data.CharacterID;
    //		}
    //		return result;
    //	}

    //	// Token: 0x06003F51 RID: 16209 RVA: 0x001C5854 File Offset: 0x001C3A54
    //	public static Camera GetMainCamera()
    //	{
    //		Camera result = null;
    //		GameObject[] array = GameObject.FindGameObjectsWithTag("MainCamera");
    //		if (array.Length != 0)
    //		{
    //			result = array[0].GetComponent<Camera>();
    //		}
    //		return result;
    //	}

    //	// Token: 0x06003F52 RID: 16210
    //	[DllImport("WinHelper", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
    //	public static extern void WinMessageBox(string text, string caption, int type);

    //	// Token: 0x06003F53 RID: 16211
    //	[DllImport("WinHelper", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
    //	public static extern int CheckSetProcessAffintyMask(IntPtr ProcessPtr);

    //	// Token: 0x040038F3 RID: 14579
    //	private static string[] AssortObjPaths = new string[]
    //	{
    //		"_F_jianqiao",
    //		"nvyi_shoutao",
    //		"MianJu_1",
    //		string.Empty,
    //		"Bip001/Bip001 Pelvis/Bip001 Spine/Bip001 Spine1/[@wuqi1]/XiongXiangZi_bag",
    //		string.Empty,
    //		string.Empty
    //	};

    //	// Token: 0x040038F4 RID: 14580
    //	public static bool ShowConsoleLog = false;

    //	// Token: 0x040038F5 RID: 14581
    //	public static Dictionary<int, int> maplevelKV = new Dictionary<int, int>();

    //	// Token: 0x040038F6 RID: 14582
    //	public static Light HeadLight = null;

    //	// Token: 0x040038F7 RID: 14583
    //	private static int m_IlluParamID = -1;

    //	// Token: 0x020008D9 RID: 2265
    //	public enum BindSlot
    //	{
    //		// Token: 0x040038F9 RID: 14585
    //		Hand,
    //		// Token: 0x040038FA RID: 14586
    //		Back,
    //		// Token: 0x040038FB RID: 14587
    //		Default
    //	}
}
