// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace YouYou.DataTable
{

using global::System;
using global::FlatBuffers;

public struct StartRoleDataList : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static StartRoleDataList GetRootAsStartRoleDataList(ByteBuffer _bb) { return GetRootAsStartRoleDataList(_bb, new StartRoleDataList()); }
  public static StartRoleDataList GetRootAsStartRoleDataList(ByteBuffer _bb, StartRoleDataList obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p.bb_pos = _i; __p.bb = _bb; }
  public StartRoleDataList __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public StartRoleData? StartRoleDatas(int j) { int o = __p.__offset(4); return o != 0 ? (StartRoleData?)(new StartRoleData()).__assign(__p.__indirect(__p.__vector(o) + j * 4), __p.bb) : null; }
  public int StartRoleDatasLength { get { int o = __p.__offset(4); return o != 0 ? __p.__vector_len(o) : 0; } }

  public static Offset<StartRoleDataList> CreateStartRoleDataList(FlatBufferBuilder builder,
      VectorOffset StartRoleDatasOffset = default(VectorOffset)) {
    builder.StartObject(1);
    StartRoleDataList.AddStartRoleDatas(builder, StartRoleDatasOffset);
    return StartRoleDataList.EndStartRoleDataList(builder);
  }

  public static void StartStartRoleDataList(FlatBufferBuilder builder) { builder.StartObject(1); }
  public static void AddStartRoleDatas(FlatBufferBuilder builder, VectorOffset StartRoleDatasOffset) { builder.AddOffset(0, StartRoleDatasOffset.Value, 0); }
  public static VectorOffset CreateStartRoleDatasVector(FlatBufferBuilder builder, Offset<StartRoleData>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static VectorOffset CreateStartRoleDatasVectorBlock(FlatBufferBuilder builder, Offset<StartRoleData>[] data) { builder.StartVector(4, data.Length, 4); builder.Add(data); return builder.EndVector(); }
  public static void StartStartRoleDatasVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static Offset<StartRoleDataList> EndStartRoleDataList(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<StartRoleDataList>(o);
  }
};


}
