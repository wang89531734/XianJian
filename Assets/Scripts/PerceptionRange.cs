using System;
using System.Collections.Generic;
using UnityEngine;

public class PerceptionRange : MonoBehaviour
{
    //	public Perception perception
    //	{
    //		get
    //		{
    //			if (this.m_perception == null && base.transform.parent != null)
    //			{
    //				this.m_perception = base.transform.parent.GetComponent<Perception>();
    //			}
    //			return this.m_perception;
    //		}
    //		set
    //		{
    //			this.m_perception = value;
    //		}
    //	}

    //	// Token: 0x06001AFF RID: 6911 RVA: 0x000F2DB4 File Offset: 0x000F0FB4
    //	private void Start()
    //	{
    //		Rigidbody orAddComponent = base.gameObject.GetOrAddComponent<Rigidbody>();
    //		orAddComponent.isKinematic = true;
    //		base.gameObject.layer = 2;
    //	}

    //	// Token: 0x06001B00 RID: 6912 RVA: 0x000F2DE0 File Offset: 0x000F0FE0
    //	private void OnTriggerEnter(Collider other)
    //	{
    //		PerceptionTarget component = other.GetComponent<PerceptionTarget>();
    //		if (component == null || this.perception == null)
    //		{
    //			return;
    //		}
    //		Transform host = component.host;
    //		if (!this.perception.targetsCanBePercept.ContainsKey(host))
    //		{
    //			List<PerceptionTarget> list = new List<PerceptionTarget>();
    //			list.Add(component);
    //			this.perception.targetsCanBePercept.Add(host, list);
    //		}
    //		else
    //		{
    //			this.perception.targetsCanBePercept[component.host].Add(component);
    //		}
    //	}

    //	// Token: 0x06001B01 RID: 6913 RVA: 0x000F2E70 File Offset: 0x000F1070
    //	private void OnTriggerExit(Collider other)
    //	{
    //		PerceptionTarget component = other.GetComponent<PerceptionTarget>();
    //		if (component == null || this.perception == null)
    //		{
    //			return;
    //		}
    //		Transform host = component.host;
    //		if (this.perception.targetsCanBePercept.ContainsKey(host))
    //		{
    //			this.perception.targetsCanBePercept[host].Remove(component);
    //			if (this.perception.targetsCanBePercept[host].Count < 1)
    //			{
    //				this.perception.hostsCanBeListened.Remove(host);
    //				this.perception.hostsCanBeSeen.Remove(host);
    //				this.perception.targetsCanBePercept.Remove(host);
    //				if (this.perception.OnBeNotSeenEvent != null)
    //				{
    //					this.perception.OnBeNotSeenEvent(host);
    //				}
    //				this.perception.SendMessageToUScript(host, false);
    //			}
    //		}
    //	}

    //	// Token: 0x04001E7F RID: 7807
    //	private Perception m_perception;
}
