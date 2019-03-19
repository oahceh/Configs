﻿// Decompiled with JetBrains decompiler
// Type: UnityEngine.Hash128
// Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAF87D7C-AD7E-4FF1-9AEC-E2E17FC1223B
// Assembly location: D:\Unity\Editor\Data\Managed\UnityEngine\UnityEngine.CoreModule.dll

using System.Runtime.CompilerServices;
using UnityEngine.Scripting;

namespace UnityEngine
{
  /// <summary>
  ///   <para>Represent the hash value.</para>
  /// </summary>
  [UsedByNativeCode]
  public struct Hash128
  {
    private uint m_u32_0;
    private uint m_u32_1;
    private uint m_u32_2;
    private uint m_u32_3;

    /// <summary>
    ///   <para>Construct the Hash128.</para>
    /// </summary>
    /// <param name="u32_0"></param>
    /// <param name="u32_1"></param>
    /// <param name="u32_2"></param>
    /// <param name="u32_3"></param>
    public Hash128(uint u32_0, uint u32_1, uint u32_2, uint u32_3)
    {
      this.m_u32_0 = u32_0;
      this.m_u32_1 = u32_1;
      this.m_u32_2 = u32_2;
      this.m_u32_3 = u32_3;
    }

    /// <summary>
    ///   <para>Get if the hash value is valid or not. (Read Only)</para>
    /// </summary>
    public bool isValid
    {
      get
      {
        return this.m_u32_0 != 0U || this.m_u32_1 != 0U || this.m_u32_2 != 0U || this.m_u32_3 != 0U;
      }
    }

    /// <summary>
    ///   <para>Convert Hash128 to string.</para>
    /// </summary>
    public override string ToString()
    {
      return Hash128.Internal_Hash128ToString(this.m_u32_0, this.m_u32_1, this.m_u32_2, this.m_u32_3);
    }

    /// <summary>
    ///   <para>Convert the input string to Hash128.</para>
    /// </summary>
    /// <param name="hashString"></param>
    public static Hash128 Parse(string hashString)
    {
      Hash128 hash128;
      Hash128.INTERNAL_CALL_Parse(hashString, out hash128);
      return hash128;
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void INTERNAL_CALL_Parse(string hashString, out Hash128 value);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern string Internal_Hash128ToString(uint d0, uint d1, uint d2, uint d3);

    public override bool Equals(object obj)
    {
      return obj is Hash128 && this == (Hash128) obj;
    }

    public override int GetHashCode()
    {
      return this.m_u32_0.GetHashCode() ^ this.m_u32_1.GetHashCode() ^ this.m_u32_2.GetHashCode() ^ this.m_u32_3.GetHashCode();
    }

    public static bool operator ==(Hash128 hash1, Hash128 hash2)
    {
      return (int) hash1.m_u32_0 == (int) hash2.m_u32_0 && (int) hash1.m_u32_1 == (int) hash2.m_u32_1 && (int) hash1.m_u32_2 == (int) hash2.m_u32_2 && (int) hash1.m_u32_3 == (int) hash2.m_u32_3;
    }

    public static bool operator !=(Hash128 hash1, Hash128 hash2)
    {
      return !(hash1 == hash2);
    }
  }
}
