using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YouYou;

public class RoleDataManager:IDisposable
{
    public void CreatePlayerByJobId(int jobId,BaseAction<RoleCtrl> onComplete=null)
    {
        GameEntry.Pool.GameObjectSpawn(1, (Transform trans) => 
        {
            RoleCtrl roleCtrl = trans.GetComponent<RoleCtrl>();
            roleCtrl.Init();

            onComplete?.Invoke(roleCtrl);
        });
    }

    public void Dispose()
    {

    }
}
