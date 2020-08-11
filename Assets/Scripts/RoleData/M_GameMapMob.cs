using Pathfinding;
using System;
using UnityEngine;
using YouYou;

public class M_GameMapMob : M_GameRoleBase
{
	private M_GameEnemyPathAI m_PathAI;

	private new bool m_bUpdateDist;

	protected override void initialize()
	{
        //if (base.DisableRole)
        //{
        //	ExploreMiniMapSystem.Instance.RemoveQuestIcon(base.RoleID);
        //	return;
        //}
        base.gameObject.AddComponent<Seeker>();
        //FunnelModifier funnelModifier = base.gameObject.AddComponent<FunnelModifier>();
        //funnelModifier.priority = 1;
        this.m_PathAI = base.gameObject.AddComponent<M_GameEnemyPathAI>();
        if (this.m_PathAI != null)
        {
            this.m_PathAI.initialize();
        }
        //if (this.HideRole)
        //{
        //	this.m_PathAI.Disable();
        //}
        //if (this.m_NpcData.Ground == 1)
        //{
        //	int layer = base.gameObject.layer;
        //	TransformTool.SetLayerRecursively(base.transform, 2);
        //	GameMath.CastObjectOnTerrain(base.gameObject, 0.5f);
        //	this.m_GameObjData.Pos = base.gameObject.transform.position + new Vector3(0f, 0.05f, 0f);
        //	base.SetPos(this.m_GameObjData.Pos);
        //	TransformTool.SetLayerRecursively(base.gameObject.transform, layer);
        //}
        //SphereCollider component = base.gameObject.GetComponent<SphereCollider>();
        //if (component != null)
        //{
        //	component.enabled = false;
        //}
        CapsuleCollider component2 = base.gameObject.GetComponent<CapsuleCollider>();
        if (component2 != null)
        {
            component2.enabled = true;
            component2.isTrigger = true;
        }
        else
        {
            BoxCollider component3 = base.gameObject.GetComponent<BoxCollider>();
            if (component3 != null)
            {
                component3.enabled = true;
                component3.isTrigger = true;
            }
        }
        //if (this.m_RoleMotion)
        //{
        //	this.m_RoleMotion.SetAlwaysAnimate(false);
        //}
        //TransformTool.SetLayerRecursively(base.gameObject.transform, 9);
        //base.gameObject.layer = 15;
    }

	public override void Update()
	{
	}

	public void UpdateView()
	{
		//GameObject playerObj = Swd6Application.instance.m_GameObjSystem.PlayerObj;
		//if (playerObj == null)
		//{
		//	return;
		//}
		//if (base.DisableRole || base.Invalid)
		//{
		//	return;
		//}
		//M_PlayerController component = playerObj.GetComponent<M_PlayerController>();
		//float num = Vector3.Distance(base.Pos, component.GetPos());
		//if (num >= 60f)
		//{
		//	if (!this.m_bUpdateDist)
		//	{
		//		this.m_bUpdateDist = true;
		//		this.HideRole = true;
		//	}
		//}
		//else if (this.m_bUpdateDist)
		//{
		//	this.m_bUpdateDist = false;
		//	this.HideRole = false;
		//}
	}

	private void OnTriggerEnter(Collider other)
	{
        if (other.tag == "Player")
        {
            GameEntry.Instance.m_ExploreSystem.PlayerController.OnTriggerFight(base.gameObject, false);
        }
        //if (other.tag == "Weapon")
        //{
        //	Swd6Application.instance.m_ExploreSystem.PlayerController.OnTriggerFight(base.gameObject, true);
        //}
    }

	private void OnTriggerExit(Collider other)
	{
	}
}
