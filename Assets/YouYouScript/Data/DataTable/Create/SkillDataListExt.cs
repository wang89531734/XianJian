using FlatBuffers;
using System.Collections.Generic;
using YouYou;
using YouYou.DataTable;

/// <summary>
/// Create By 悠游课堂 http://www.u3dol.com 王一博 18321883193
/// </summary>
public static partial class SkillDataListExt
{
    private static Dictionary<int, SkillData?> m_Dic = new Dictionary<int, SkillData?>();
    private static List<SkillData> m_List = new List<SkillData>();

    #region LoadData 加载数据表数据
    /// <summary>
    /// 加载数据表数据
    /// </summary>
    public static void LoadData(this SkillDataList skilldataList)
    {
        GameEntry.DataTable.TotalTableCount++;

        //1.拿到这个表格的buffer
        GameEntry.DataTable.GetDataTableBuffer(DataTableDefine.SkillDataName, (byte[] buffer) =>
        {
            //2.加载数据 并 把数据初始化到字典
            Init(SkillDataList.GetRootAsSkillDataList(new ByteBuffer(buffer)));
        });
    }
    #endregion

    /// <summary>
    /// 初始化到字典
    /// </summary>
    public static void Init(SkillDataList skilldataList)
    {
        System.Threading.Tasks.Task.Run(() => {
            int len = skilldataList.SkillDatasLength;
            for (int j = 0; j < len; j++)
            {
                SkillData ? skilldata = skilldataList.SkillDatas(j);
                if (skilldata != null)
                {
                    m_List.Add(skilldata.Value);
                    m_Dic[skilldata.Value.Id] = skilldata;
                }
            }

            //3.派发单个表加载完毕事件
            GameEntry.DataTable.AddToAlreadyLoadTable(DataTableDefine.SkillDataName, DataTableDefine.SkillDataVersion);
            GameEntry.Event.CommonEvent.Dispatch(SysEventId.LoadOneDataTableComplete, DataTableDefine.SkillDataName);
        });
    }

    /// <summary>
    /// 获取数据实体
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public static SkillData? GetEntity(this SkillDataList skilldataList, int id)
    {
        SkillData ? skilldata;
        m_Dic.TryGetValue(id, out skilldata);
        return skilldata;
    }

    /// <summary>
    /// 获取数据实体值
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public static SkillData GetEntityValue(this SkillDataList skilldataList, int id)
    {
        SkillData ? skilldata = skilldataList.GetEntity(id);
        if (skilldata != null)
        {
            return skilldata.Value;
        }
        return default;
    }

    /// <summary>
    /// 获取列表
    /// </summary>
    /// <returns></returns>
    public static List<SkillData> GetList(this SkillDataList skilldataList)
    {
        return m_List;
    }
}