using SoftStar.Pal6;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YouYou;

public class RoleDataManager:IDisposable
{
    public void CreatePlayerByJobId(int jobId,BaseAction<PalNPC> onComplete=null)
    {
        GameEntry.Pool.GameObjectSpawn(1, (Transform trans) => 
        {
            PalNPC roleCtrl = trans.GetComponent<PalNPC>();

            onComplete?.Invoke(roleCtrl);
        });
    }

    public void Dispose()
    {

    }
}
