using FlatBuffers;
using System.Collections.Generic;
using YouYou;
using YouYou.DataTable;

/// <summary>
/// Create By 悠游课堂 http://www.u3dol.com 王一博 18321883193
/// </summary>
public static partial class StartRoleDataListExt
{
    private static Dictionary<int, StartRoleData?> m_Dic = new Dictionary<int, StartRoleData?>();
    private static List<StartRoleData> m_List = new List<StartRoleData>();

    #region LoadData 加载数据表数据
    /// <summary>
    /// 加载数据表数据
    /// </summary>
    public static void LoadData(this StartRoleDataList startroledataList)
    {
        GameEntry.DataTable.TotalTableCount++;

        //1.拿到这个表格的buffer
        GameEntry.DataTable.GetDataTableBuffer(DataTableDefine.StartRoleDataName, (byte[] buffer) =>
        {
            //2.加载数据 并 把数据初始化到字典
            Init(StartRoleDataList.GetRootAsStartRoleDataList(new ByteBuffer(buffer)));
        });
    }
    #endregion

    /// <summary>
    /// 初始化到字典
    /// </summary>
    public static void Init(StartRoleDataList startroledataList)
    {
        System.Threading.Tasks.Task.Run(() => {
            int len = startroledataList.StartRoleDatasLength;
            for (int j = 0; j < len; j++)
            {
                StartRoleData ? startroledata = startroledataList.StartRoleDatas(j);
                if (startroledata != null)
                {
                    m_List.Add(startroledata.Value);
                    m_Dic[startroledata.Value.Id] = startroledata;
                }
            }

            //3.派发单个表加载完毕事件
            GameEntry.DataTable.AddToAlreadyLoadTable(DataTableDefine.StartRoleDataName, DataTableDefine.StartRoleDataVersion);
            GameEntry.Event.CommonEvent.Dispatch(SysEventId.LoadOneDataTableComplete, DataTableDefine.StartRoleDataName);
        });
    }

    /// <summary>
    /// 获取数据实体
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public static StartRoleData? GetEntity(this StartRoleDataList startroledataList, int id)
    {
        StartRoleData ? startroledata;
        m_Dic.TryGetValue(id, out startroledata);
        return startroledata;
    }

    /// <summary>
    /// 获取数据实体值
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public static StartRoleData GetEntityValue(this StartRoleDataList startroledataList, int id)
    {
        StartRoleData ? startroledata = startroledataList.GetEntity(id);
        if (startroledata != null)
        {
            return startroledata.Value;
        }
        return default;
    }

    /// <summary>
    /// 获取列表
    /// </summary>
    /// <returns></returns>
    public static List<StartRoleData> GetList(this StartRoleDataList startroledataList)
    {
        return m_List;
    }
}