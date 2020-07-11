using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YouYou;

public class RoleManager : ManagerBase, IDisposable
{
    public RoleManager()
    {
 
    }

    public override void Init()
    {
        
    }

    public void CreatePlayer()//int id, Vector3 pos, float dir, BaseAction<RoleCtrl> onComplete
    {
        GameEntry.Pool.GameObjectSpawn(1, (Transform trans) =>
        {
            RoleCtrl roleCtrl = trans.GetComponent<RoleCtrl>();
            //onComplete?.Invoke(roleCtrl);
        });

        //if (this.PlayerObj != null)
        //{
        //    return this.PlayerObj;
        //}
        //string text = "Player" + id;
        //string name = "Player" + id + "_Map";
        //GameObject characterRoot = ResourceManager.Instance.GetCharacterRoot(name);
        //if (characterRoot == null)
        //{
        //    Debug.Log("CreatePlayerGameObj::無法建立Root物件_" + id);
        //    return null;
        //}
        //GameObject gameObject = this.GetPlayerCosCloth(id);
        //if (gameObject == null)
        //{
        //    gameObject = ResourceManager.Instance.GetCharacterModel(text);
        //    if (gameObject == null)
        //    {
        //        Debug.Log("CreatePlayerGameObj::無法建立Model物件_" + id);
        //        return null;
        //    }
        //}
        //RendererTool.ChangeSenceMaterialSetting(text, gameObject);
        //gameObject.transform.parent = characterRoot.transform;
        //Animator component = gameObject.GetComponent<Animator>();
        //if (component == null)
        //{
        //    Debug.Log("CreatePlayerGameObj::找不到Animator_" + id);
        //    return null;
        //}
        //component.enabled = false;
        //Avatar avatar = component.avatar;
        //UnityEngine.Object.Destroy(component);
        //string name2 = "Player" + id + "_Map";
        //component = characterRoot.GetComponent<Animator>();
        //component.runtimeAnimatorController = ResourceManager.Instance.GetAnimatorController(name2);
        //component.avatar = avatar;
        //component.applyRootMotion = false;
        //SphereCollider component2 = gameObject.GetComponent<SphereCollider>();
        //if (component2 != null)
        //{
        //    UnityEngine.Object.Destroy(component2);
        //}
        //CapsuleCollider component3 = gameObject.GetComponent<CapsuleCollider>();
        //if (component3 != null)
        //{
        //    component3.enabled = true;
        //    component3.isTrigger = true;
        //}
        //FaceFXControllerScript component4 = gameObject.GetComponent<FaceFXControllerScript>();
        //if (component4 != null)
        //{
        //    UnityEngine.Object.Destroy(component4);
        //}
        //Animation component5 = gameObject.GetComponent<Animation>();
        //if (component5 != null)
        //{
        //    UnityEngine.Object.Destroy(component5);
        //}
        //this.m_ShroudInstance = gameObject.GetComponent<ShroudInstance>();
        //if (this.m_ShroudInstance != null)
        //{
        //    this.m_ShroudInstance.ReduceBlendWeight_StoryEnable();
        //}
        //CharacterController component6 = gameObject.GetComponent<CharacterController>();
        //UnityEngine.Object.DestroyObject(component6);
        //characterRoot.transform.position = pos;
        //characterRoot.transform.eulerAngles = new Vector3(0f, dir, 0f);
        //characterRoot.name = "Player";
        //component.applyRootMotion = true;
        //TransformTool.SetLayerRecursively(characterRoot.transform, 2);
        //gameObject.tag = "Player";
        //this.PlayerObj = characterRoot;
        //GameObjState state = new GameObjState();
        //S_GameObjData objData = new S_GameObjData(id, 0, pos, dir, 1, state, this.PlayerObj);
        //this.AddGameObjData(objData);
        //if (!this.PlayerObj.GetComponent<AudioListener>())
        //{
        //    this.PlayerObj.AddComponent<AudioListener>();
        //}
        //this.m_PhysicClothList.Clear();
        //this.m_PlayerObjList.Clear();
        //this.m_IsHide = false;
        //return this.PlayerObj;
    }

    public void Dispose()
    {
       
    }
}
