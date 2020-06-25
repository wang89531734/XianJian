using SoftStar.Pal6;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YouYou;

public class RoleDataManager:IDisposable
{
    public void CreatePlayerByJobId(int jobId,BaseAction<Transform> onComplete=null)
    {
        GameEntry.Pool.GameObjectSpawn(jobId, (Transform trans) => 
        {
            PalNPC roleCtrl = trans.GetComponent<PalNPC>();

            onComplete?.Invoke(trans);
        });
    }

    public void Dispose()
    {

    }
}
