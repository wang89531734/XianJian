using FlatBuffers;
using System.Collections.Generic;
using YouYou;
using YouYou.DataTable;

/// <summary>
/// Create By 悠游课堂 http://www.u3dol.com 王一博 18321883193
/// </summary>
public static partial class RoleLevelListExt
{
    private static Dictionary<int, RoleLevel?> m_Dic = new Dictionary<int, RoleLevel?>();
    private static List<RoleLevel> m_List = new List<RoleLevel>();

    #region LoadData 加载数据表数据
    /// <summary>
    /// 加载数据表数据
    /// </summary>
    public static void LoadData(this RoleLevelList rolelevelList)
    {
        GameEntry.DataTable.TotalTableCount++;

        //1.拿到这个表格的buffer
        GameEntry.DataTable.GetDataTableBuffer(DataTableDefine.RoleLevelName, (byte[] buffer) =>
        {
            //2.加载数据 并 把数据初始化到字典
            Init(RoleLevelList.GetRootAsRoleLevelList(new ByteBuffer(buffer)));
        });
    }
    #endregion

    /// <summary>
    /// 初始化到字典
    /// </summary>
    public static void Init(RoleLevelList rolelevelList)
    {
        System.Threading.Tasks.Task.Run(() => {
            int len = rolelevelList.RoleLevelsLength;
            for (int j = 0; j < len; j++)
            {
                RoleLevel ? rolelevel = rolelevelList.RoleLevels(j);
                if (rolelevel != null)
                {
                    m_List.Add(rolelevel.Value);
                    m_Dic[rolelevel.Value.Id] = rolelevel;
                }
            }

            //3.派发单个表加载完毕事件
            GameEntry.DataTable.AddToAlreadyLoadTable(DataTableDefine.RoleLevelName, DataTableDefine.RoleLevelVersion);
            GameEntry.Event.CommonEvent.Dispatch(SysEventId.LoadOneDataTableComplete, DataTableDefine.RoleLevelName);
        });
    }

    /// <summary>
    /// 获取数据实体
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public static RoleLevel? GetEntity(this RoleLevelList rolelevelList, int id)
    {
        RoleLevel ? rolelevel;
        m_Dic.TryGetValue(id, out rolelevel);
        return rolelevel;
    }

    /// <summary>
    /// 获取数据实体值
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public static RoleLevel GetEntityValue(this RoleLevelList rolelevelList, int id)
    {
        RoleLevel ? rolelevel = rolelevelList.GetEntity(id);
        if (rolelevel != null)
        {
            return rolelevel.Value;
        }
        return default;
    }

    /// <summary>
    /// 获取列表
    /// </summary>
    /// <returns></returns>
    public static List<RoleLevel> GetList(this RoleLevelList rolelevelList)
    {
        return m_List;
    }
}