// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace YouYou.DataTable
{

using global::System;
using global::FlatBuffers;

public struct Sprite : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static Sprite GetRootAsSprite(ByteBuffer _bb) { return GetRootAsSprite(_bb, new Sprite()); }
  public static Sprite GetRootAsSprite(ByteBuffer _bb, Sprite obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p.bb_pos = _i; __p.bb = _bb; }
  public Sprite __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public int Id { get { int o = __p.__offset(4); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public int SpriteType { get { int o = __p.__offset(6); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public string Name { get { int o = __p.__offset(8); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetNameBytes() { return __p.__vector_as_span(8); }
#else
  public ArraySegment<byte>? GetNameBytes() { return __p.__vector_as_arraysegment(8); }
#endif
  public byte[] GetNameArray() { return __p.__vector_as_array<byte>(8); }
  public int Level { get { int o = __p.__offset(10); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public int IsBoss { get { int o = __p.__offset(12); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public string PrefabName { get { int o = __p.__offset(14); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetPrefabNameBytes() { return __p.__vector_as_span(14); }
#else
  public ArraySegment<byte>? GetPrefabNameBytes() { return __p.__vector_as_arraysegment(14); }
#endif
  public byte[] GetPrefabNameArray() { return __p.__vector_as_array<byte>(14); }
  public string TextureName { get { int o = __p.__offset(16); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetTextureNameBytes() { return __p.__vector_as_span(16); }
#else
  public ArraySegment<byte>? GetTextureNameBytes() { return __p.__vector_as_arraysegment(16); }
#endif
  public byte[] GetTextureNameArray() { return __p.__vector_as_array<byte>(16); }
  public string HeadPic { get { int o = __p.__offset(18); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetHeadPicBytes() { return __p.__vector_as_span(18); }
#else
  public ArraySegment<byte>? GetHeadPicBytes() { return __p.__vector_as_arraysegment(18); }
#endif
  public byte[] GetHeadPicArray() { return __p.__vector_as_array<byte>(18); }
  public float MoveSpeed { get { int o = __p.__offset(20); return o != 0 ? __p.bb.GetFloat(o + __p.bb_pos) : (float)0.0f; } }
  public int HP { get { int o = __p.__offset(22); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public int MP { get { int o = __p.__offset(24); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public int Attack { get { int o = __p.__offset(26); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public int Defense { get { int o = __p.__offset(28); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public int Hit { get { int o = __p.__offset(30); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public int Dodge { get { int o = __p.__offset(32); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public int Cri { get { int o = __p.__offset(34); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public int Res { get { int o = __p.__offset(36); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public int Fighting { get { int o = __p.__offset(38); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public int ShowBloodBar { get { int o = __p.__offset(40); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public int BloodBarLayerCount { get { int o = __p.__offset(42); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public string UsedPhyAttack { get { int o = __p.__offset(44); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetUsedPhyAttackBytes() { return __p.__vector_as_span(44); }
#else
  public ArraySegment<byte>? GetUsedPhyAttackBytes() { return __p.__vector_as_arraysegment(44); }
#endif
  public byte[] GetUsedPhyAttackArray() { return __p.__vector_as_array<byte>(44); }
  public string UsedSkillList { get { int o = __p.__offset(46); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetUsedSkillListBytes() { return __p.__vector_as_span(46); }
#else
  public ArraySegment<byte>? GetUsedSkillListBytes() { return __p.__vector_as_arraysegment(46); }
#endif
  public byte[] GetUsedSkillListArray() { return __p.__vector_as_array<byte>(46); }
  public int CanArmor { get { int o = __p.__offset(48); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public int ArmorHPPercentage { get { int o = __p.__offset(50); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public int RangeView { get { int o = __p.__offset(52); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public float AttackInterval { get { int o = __p.__offset(54); return o != 0 ? __p.bb.GetFloat(o + __p.bb_pos) : (float)0.0f; } }
  public int PhysicalAttackRate { get { int o = __p.__offset(56); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public float DelaySecAttack { get { int o = __p.__offset(58); return o != 0 ? __p.bb.GetFloat(o + __p.bb_pos) : (float)0.0f; } }
  public int RewardExp { get { int o = __p.__offset(60); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }

  public static Offset<Sprite> CreateSprite(FlatBufferBuilder builder,
      int Id = 0,
      int SpriteType = 0,
      StringOffset NameOffset = default(StringOffset),
      int Level = 0,
      int IsBoss = 0,
      StringOffset PrefabNameOffset = default(StringOffset),
      StringOffset TextureNameOffset = default(StringOffset),
      StringOffset HeadPicOffset = default(StringOffset),
      float MoveSpeed = 0.0f,
      int HP = 0,
      int MP = 0,
      int Attack = 0,
      int Defense = 0,
      int Hit = 0,
      int Dodge = 0,
      int Cri = 0,
      int Res = 0,
      int Fighting = 0,
      int ShowBloodBar = 0,
      int BloodBarLayerCount = 0,
      StringOffset UsedPhyAttackOffset = default(StringOffset),
      StringOffset UsedSkillListOffset = default(StringOffset),
      int CanArmor = 0,
      int Armor_HP_Percentage = 0,
      int Range_View = 0,
      float Attack_Interval = 0.0f,
      int PhysicalAttackRate = 0,
      float DelaySec_Attack = 0.0f,
      int RewardExp = 0) {
    builder.StartObject(29);
    Sprite.AddRewardExp(builder, RewardExp);
    Sprite.AddDelaySecAttack(builder, DelaySec_Attack);
    Sprite.AddPhysicalAttackRate(builder, PhysicalAttackRate);
    Sprite.AddAttackInterval(builder, Attack_Interval);
    Sprite.AddRangeView(builder, Range_View);
    Sprite.AddArmorHPPercentage(builder, Armor_HP_Percentage);
    Sprite.AddCanArmor(builder, CanArmor);
    Sprite.AddUsedSkillList(builder, UsedSkillListOffset);
    Sprite.AddUsedPhyAttack(builder, UsedPhyAttackOffset);
    Sprite.AddBloodBarLayerCount(builder, BloodBarLayerCount);
    Sprite.AddShowBloodBar(builder, ShowBloodBar);
    Sprite.AddFighting(builder, Fighting);
    Sprite.AddRes(builder, Res);
    Sprite.AddCri(builder, Cri);
    Sprite.AddDodge(builder, Dodge);
    Sprite.AddHit(builder, Hit);
    Sprite.AddDefense(builder, Defense);
    Sprite.AddAttack(builder, Attack);
    Sprite.AddMP(builder, MP);
    Sprite.AddHP(builder, HP);
    Sprite.AddMoveSpeed(builder, MoveSpeed);
    Sprite.AddHeadPic(builder, HeadPicOffset);
    Sprite.AddTextureName(builder, TextureNameOffset);
    Sprite.AddPrefabName(builder, PrefabNameOffset);
    Sprite.AddIsBoss(builder, IsBoss);
    Sprite.AddLevel(builder, Level);
    Sprite.AddName(builder, NameOffset);
    Sprite.AddSpriteType(builder, SpriteType);
    Sprite.AddId(builder, Id);
    return Sprite.EndSprite(builder);
  }

  public static void StartSprite(FlatBufferBuilder builder) { builder.StartObject(29); }
  public static void AddId(FlatBufferBuilder builder, int Id) { builder.AddInt(0, Id, 0); }
  public static void AddSpriteType(FlatBufferBuilder builder, int SpriteType) { builder.AddInt(1, SpriteType, 0); }
  public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset) { builder.AddOffset(2, NameOffset.Value, 0); }
  public static void AddLevel(FlatBufferBuilder builder, int Level) { builder.AddInt(3, Level, 0); }
  public static void AddIsBoss(FlatBufferBuilder builder, int IsBoss) { builder.AddInt(4, IsBoss, 0); }
  public static void AddPrefabName(FlatBufferBuilder builder, StringOffset PrefabNameOffset) { builder.AddOffset(5, PrefabNameOffset.Value, 0); }
  public static void AddTextureName(FlatBufferBuilder builder, StringOffset TextureNameOffset) { builder.AddOffset(6, TextureNameOffset.Value, 0); }
  public static void AddHeadPic(FlatBufferBuilder builder, StringOffset HeadPicOffset) { builder.AddOffset(7, HeadPicOffset.Value, 0); }
  public static void AddMoveSpeed(FlatBufferBuilder builder, float MoveSpeed) { builder.AddFloat(8, MoveSpeed, 0.0f); }
  public static void AddHP(FlatBufferBuilder builder, int HP) { builder.AddInt(9, HP, 0); }
  public static void AddMP(FlatBufferBuilder builder, int MP) { builder.AddInt(10, MP, 0); }
  public static void AddAttack(FlatBufferBuilder builder, int Attack) { builder.AddInt(11, Attack, 0); }
  public static void AddDefense(FlatBufferBuilder builder, int Defense) { builder.AddInt(12, Defense, 0); }
  public static void AddHit(FlatBufferBuilder builder, int Hit) { builder.AddInt(13, Hit, 0); }
  public static void AddDodge(FlatBufferBuilder builder, int Dodge) { builder.AddInt(14, Dodge, 0); }
  public static void AddCri(FlatBufferBuilder builder, int Cri) { builder.AddInt(15, Cri, 0); }
  public static void AddRes(FlatBufferBuilder builder, int Res) { builder.AddInt(16, Res, 0); }
  public static void AddFighting(FlatBufferBuilder builder, int Fighting) { builder.AddInt(17, Fighting, 0); }
  public static void AddShowBloodBar(FlatBufferBuilder builder, int ShowBloodBar) { builder.AddInt(18, ShowBloodBar, 0); }
  public static void AddBloodBarLayerCount(FlatBufferBuilder builder, int BloodBarLayerCount) { builder.AddInt(19, BloodBarLayerCount, 0); }
  public static void AddUsedPhyAttack(FlatBufferBuilder builder, StringOffset UsedPhyAttackOffset) { builder.AddOffset(20, UsedPhyAttackOffset.Value, 0); }
  public static void AddUsedSkillList(FlatBufferBuilder builder, StringOffset UsedSkillListOffset) { builder.AddOffset(21, UsedSkillListOffset.Value, 0); }
  public static void AddCanArmor(FlatBufferBuilder builder, int CanArmor) { builder.AddInt(22, CanArmor, 0); }
  public static void AddArmorHPPercentage(FlatBufferBuilder builder, int ArmorHPPercentage) { builder.AddInt(23, ArmorHPPercentage, 0); }
  public static void AddRangeView(FlatBufferBuilder builder, int RangeView) { builder.AddInt(24, RangeView, 0); }
  public static void AddAttackInterval(FlatBufferBuilder builder, float AttackInterval) { builder.AddFloat(25, AttackInterval, 0.0f); }
  public static void AddPhysicalAttackRate(FlatBufferBuilder builder, int PhysicalAttackRate) { builder.AddInt(26, PhysicalAttackRate, 0); }
  public static void AddDelaySecAttack(FlatBufferBuilder builder, float DelaySecAttack) { builder.AddFloat(27, DelaySecAttack, 0.0f); }
  public static void AddRewardExp(FlatBufferBuilder builder, int RewardExp) { builder.AddInt(28, RewardExp, 0); }
  public static Offset<Sprite> EndSprite(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<Sprite>(o);
  }
};


}
