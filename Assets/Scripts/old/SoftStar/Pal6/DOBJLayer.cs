using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SoftStar.Pal6
{
    public class DOBJLayer : MonoBehaviour
    {
        //        // Token: 0x040011A4 RID: 4516
        //        [NonSerialized]
        //        public int LayerIndex;

        //        // Token: 0x040011A5 RID: 4517
        //        public int orderIndex;

        //        // Token: 0x040011A6 RID: 4518
        //        public string layerName = string.Empty;

        //        // Token: 0x040011A7 RID: 4519
        //        public string prefabName = string.Empty;

        //        // Token: 0x040011A8 RID: 4520
        //        public List<int> enableNecessaryFlgs = new List<int>();

        //        // Token: 0x040011A9 RID: 4521
        //        public List<ConditionalJudgment> enableNecessaryConditions = new List<ConditionalJudgment>();

        //        // Token: 0x040011AA RID: 4522
        //        public List<int> disableSufficientFlags = new List<int>();

        //        // Token: 0x040011AB RID: 4523
        //        public List<ConditionalJudgment> disableSufficientConditions = new List<ConditionalJudgment>();

        //        // Token: 0x040011AC RID: 4524
        //        public bool childActive = true;

        //        // Token: 0x040011AD RID: 4525
        //        public List<PalGameObjectBase> palObjects = new List<PalGameObjectBase>();

        //        // Token: 0x040011AE RID: 4526
        //        public string Remark;

        //        // Token: 0x040011AF RID: 4527
        //        private TimeSpan loadTime;

        //        // Token: 0x040011B0 RID: 4528
        //        private List<PalGameObjectBase> palObjs = new List<PalGameObjectBase>();

        //        // Token: 0x040011B1 RID: 4529
        //        private bool isLoadOver;

        //        public static bool Judgment(GameFileStream stream)
        //		{
        //			bool flag = false;
        //			int num = stream.ReadInt();
        //			if (num > 0)
        //			{
        //				flag = true;
        //			}
        //			for (int i = 0; i < num; i++)
        //			{
        //				ConditionalJudgment.enum_JudgmentType type = (ConditionalJudgment.enum_JudgmentType)stream.ReadInt();
        //				int value = stream.ReadInt();
        //				int idx = stream.ReadInt();
        //				int flag2 = FlagManager.GetFlag(idx);
        //				string text = null;
        //				if (!new ConditionalJudgment(type, value).Judgment(flag2, out text))
        //				{
        //					flag = false;
        //				}
        //			}
        //			num = stream.ReadInt();
        //			bool flag3 = true;
        //			for (int j = 0; j < num; j++)
        //			{
        //				ConditionalJudgment.enum_JudgmentType type2 = (ConditionalJudgment.enum_JudgmentType)stream.ReadInt();
        //				int value2 = stream.ReadInt();
        //				int idx2 = stream.ReadInt();
        //				int flag4 = FlagManager.GetFlag(idx2);
        //				string text2 = null;
        //				if (!new ConditionalJudgment(type2, value2).Judgment(flag4, out text2))
        //				{
        //					flag3 = false;
        //				}
        //			}
        //			return !flag && flag3;
        //		}

        //		public void WriteCondition(GameFileStream stream)
        //		{
        //			stream.WriteInt(this.disableSufficientFlags.Count);
        //			for (int i = 0; i < this.disableSufficientFlags.Count; i++)
        //			{
        //				stream.WriteInt((int)this.disableSufficientConditions[i].type);
        //				stream.WriteInt(this.disableSufficientConditions[i].value);
        //				stream.WriteInt(this.disableSufficientFlags[i]);
        //			}
        //			stream.WriteInt(this.enableNecessaryFlgs.Count);
        //			for (int j = 0; j < this.enableNecessaryFlgs.Count; j++)
        //			{
        //				stream.WriteInt((int)this.enableNecessaryConditions[j].type);
        //				stream.WriteInt(this.enableNecessaryConditions[j].value);
        //				stream.WriteInt(this.enableNecessaryFlgs[j]);
        //			}
        //		}

        //		// Token: 0x0600103E RID: 4158 RVA: 0x0009BA00 File Offset: 0x00099C00
        //		public void SetActiveAllModels(bool bActive)
        //		{
        //			for (int i = 0; i < this.palObjects.Count; i++)
        //			{
        //				PalGameObjectBase palGameObjectBase = this.palObjects[i];
        //				if (!(palGameObjectBase == null))
        //				{
        //					UtilFun.SetActive(palGameObjectBase.gameObject, bActive);
        //				}
        //			}
        //		}

        //		// Token: 0x0600103F RID: 4159 RVA: 0x0009BA54 File Offset: 0x00099C54
        //		public void UnLoadAllModels()
        //		{
        //			foreach (PalGameObjectBase palGameObjectBase in this.palObjects)
        //			{
        //				if (palGameObjectBase.model != null)
        //				{
        //					UnityEngine.Object.DestroyImmediate(palGameObjectBase.model);
        //				}
        //			}
        //		}

        //		// Token: 0x06001040 RID: 4160 RVA: 0x0009BAD0 File Offset: 0x00099CD0
        //		public void LoadAllModels()
        //		{
        //			if (Application.isPlaying && PalMain.IsLow)
        //			{
        //				bool flag = true;
        //				int palMapLevel = UtilFun.GetPalMapLevel(SceneManager.GetActiveScene().buildIndex);
        //				string name = base.gameObject.name;
        //				if (palMapLevel == 1)
        //				{
        //					if (name.Contains("local_01") || name.Contains("AfterFly") || name.Contains("nonlocal_01") || name.Contains("guest") || name.Contains("animal") || name.Contains("LuRenNPC"))
        //					{
        //						flag = false;
        //					}
        //				}
        //				else if (palMapLevel == 13 && (name.Contains("JNnpcA09") || name.Contains("JNanimal") || name.Contains("afterqihun") || name.Contains("afterlangyin")))
        //				{
        //					flag = false;
        //				}
        //				if (!flag)
        //				{
        //					this.palObjs.Clear();
        //					this.palObjects.Clear();
        //					this.isLoadOver = true;
        //					foreach (PalGameObjectBase palGameObjectBase in base.GetComponentsInChildren<PalGameObjectBase>(true))
        //					{
        //						UnityEngine.Object.Destroy(palGameObjectBase.gameObject);
        //					}
        //					EntityManager.JudgeLoadOver(this);
        //					return;
        //				}
        //			}
        //			this.loadTime = DateTime.Now.TimeOfDay;
        //			DynamicObjsDataManager.Instance.AddLayer(this);
        //			this.palObjs.Clear();
        //			PalGameObjectBase[] componentsInChildren2 = base.GetComponentsInChildren<PalGameObjectBase>(true);
        //			this.palObjects.Clear();
        //			this.palObjects.AddRange(componentsInChildren2);
        //			if (this.palObjects.Count < 1)
        //			{
        //				Debug.LogWarning(base.name + "里面没有东西");
        //				this.LoadOver();
        //				return;
        //			}
        //			this.palObjs.AddRange(this.palObjects);
        //			if (this.palObjects.Count < 1)
        //			{
        //				Debug.LogWarning(base.name + "里面没有东西");
        //				this.LoadOver();
        //			}
        //			if (!EntityManager.LoadTogether)
        //			{
        //				PalGameObjectBase palGameObjectBase2 = this.palObjs[0];
        //				palGameObjectBase2.dobjLayer = this;
        //				palGameObjectBase2.LoadModel();
        //			}
        //			else
        //			{
        //				for (int j = 0; j < this.palObjects.Count; j++)
        //				{
        //					PalGameObjectBase palGameObjectBase3 = this.palObjects[j];
        //					if (palGameObjectBase3 == null)
        //					{
        //						Debug.LogError(base.name + " palObjects " + j.ToString() + " == null");
        //					}
        //					else
        //					{
        //						palGameObjectBase3.dobjLayer = this;
        //						palGameObjectBase3.LoadModel();
        //					}
        //				}
        //			}
        //		}

        //		// Token: 0x06001041 RID: 4161 RVA: 0x0009BD7C File Offset: 0x00099F7C
        //		public void GetNotLoadContent()
        //		{
        //			foreach (PalGameObjectBase palGameObjectBase in this.palObjs)
        //			{
        //				Debug.Log(palGameObjectBase.name);
        //			}
        //		}

        //		// Token: 0x06001042 RID: 4162 RVA: 0x0009BDE8 File Offset: 0x00099FE8
        //		public void ContinueLoad()
        //		{
        //			if (this.palObjs.Count < 1)
        //			{
        //				return;
        //			}
        //			this.palObjs[0].LoadModelEnd(null);
        //		}

        //		// Token: 0x06001043 RID: 4163 RVA: 0x0009BE1C File Offset: 0x0009A01C
        //		public void ShowLoadingObjs()
        //		{
        //			for (int i = 0; i < this.palObjs.Count; i++)
        //			{
        //				PalGameObjectBase palGameObjectBase = this.palObjs[i];
        //				string text = "\t\t" + palGameObjectBase.name;
        //			}
        //		}

        //		// Token: 0x06001044 RID: 4164 RVA: 0x0009BE64 File Offset: 0x0009A064
        //		public void JudgeLoadOver(PalGameObjectBase obj)
        //		{
        //			if (!EntityManager.LoadTogether)
        //			{
        //				if (this.palObjs.Count < 1)
        //				{
        //					this.LoadOver();
        //					return;
        //				}
        //				this.palObjs.RemoveAt(0);
        //				if (this.palObjs.Count < 1)
        //				{
        //					this.LoadOver();
        //					return;
        //				}
        //				PalGameObjectBase palGameObjectBase = this.palObjs[0];
        //				palGameObjectBase.dobjLayer = this;
        //				palGameObjectBase.LoadModel();
        //			}
        //			else
        //			{
        //				this.palObjs.Remove(obj);
        //				if (this.palObjs.Count < 1)
        //				{
        //					this.LoadOver();
        //					return;
        //				}
        //			}
        //		}

        //		// Token: 0x170001D3 RID: 467
        //		// (get) Token: 0x06001045 RID: 4165 RVA: 0x0009BEFC File Offset: 0x0009A0FC
        //		public bool IsLoadOver
        //		{
        //			get
        //			{
        //				return this.isLoadOver;
        //			}
        //		}

        //		// Token: 0x06001046 RID: 4166 RVA: 0x0009BF04 File Offset: 0x0009A104
        //		public void LoadOver()
        //		{
        //			foreach (object obj in base.transform)
        //			{
        //				Transform transform = (Transform)obj;
        //				UtilFun.SetActive(transform.gameObject, true);
        //			}
        //			foreach (PalGameObjectBase palGameObjectBase in base.GetComponentsInChildren<PalGameObjectBase>(true))
        //			{
        //				if (!(palGameObjectBase == null))
        //				{
        //					GameObject gameObject = palGameObjectBase.gameObject;
        //					if (!gameObject.activeSelf)
        //					{
        //						UtilFun.SetActive(gameObject, true);
        //					}
        //				}
        //			}
        //			UtilFun.SetActive(base.gameObject, true);
        //			if (Application.isPlaying)
        //			{
        //				DistanceCullManager.Instance.SetLayer(base.gameObject);
        //			}
        //			this.loadTime = DateTime.Now.TimeOfDay.Subtract(this.loadTime);
        //			this.isLoadOver = true;
        //			EntityManager.JudgeLoadOver(this);
        //		}

        //		// Token: 0x06001047 RID: 4167 RVA: 0x0009C028 File Offset: 0x0009A228
        //		public static int ComparionUp(DOBJLayer A, DOBJLayer B)
        //		{
        //			return (A.orderIndex < B.orderIndex) ? -1 : 1;
        //		}

        //		// Token: 0x06001048 RID: 4168 RVA: 0x0009C044 File Offset: 0x0009A244
        //		public void Clear()
        //		{
        //			Transform transform = base.transform;
        //			for (int i = 0; i < transform.childCount; i++)
        //			{
        //				Transform child = transform.GetChild(i);
        //				if (!(child == null))
        //				{
        //					PalGameObjectBase component = child.GetComponent<PalGameObjectBase>();
        //					if (!(component == null))
        //					{
        //						component.Clear();
        //					}
        //				}
        //			}
        //		}
    }
}
