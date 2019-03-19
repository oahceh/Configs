﻿// Decompiled with JetBrains decompiler
// Type: System.Enum
// Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// MVID: C3E4200C-CDA7-4037-B5FC-8C34C9135930
// Assembly location: C:\Windows\Microsoft.NET\Framework64\v4.0.30319\mscorlib.dll

using System.Globalization;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

namespace System
{
  [ComVisible(true)]
  [__DynamicallyInvokable]
  [Serializable]
  public abstract class Enum : ValueType, IComparable, IFormattable, IConvertible
  {
    private static readonly char[] enumSeperatorCharArray = new char[1]
    {
      ','
    };
    private const string enumSeperator = ", ";

    [SecuritySafeCritical]
    private static Enum.ValuesAndNames GetCachedValuesAndNames(RuntimeType enumType, bool getNames)
    {
      Enum.ValuesAndNames valuesAndNames = enumType.GenericCache as Enum.ValuesAndNames;
      if (valuesAndNames == null || getNames && valuesAndNames.Names == null)
      {
        ulong[] o1 = (ulong[]) null;
        string[] o2 = (string[]) null;
        Enum.GetEnumValuesAndNames(enumType.GetTypeHandleInternal(), JitHelpers.GetObjectHandleOnStack<ulong[]>(ref o1), JitHelpers.GetObjectHandleOnStack<string[]>(ref o2), getNames);
        valuesAndNames = new Enum.ValuesAndNames(o1, o2);
        enumType.GenericCache = (object) valuesAndNames;
      }
      return valuesAndNames;
    }

    private static string InternalFormattedHexString(object value)
    {
      switch (Convert.GetTypeCode(value))
      {
        case TypeCode.Boolean:
          return Convert.ToByte((bool) value).ToString("X2", (IFormatProvider) null);
        case TypeCode.Char:
          return ((ushort) (char) value).ToString("X4", (IFormatProvider) null);
        case TypeCode.SByte:
          return ((byte) (sbyte) value).ToString("X2", (IFormatProvider) null);
        case TypeCode.Byte:
          return ((byte) value).ToString("X2", (IFormatProvider) null);
        case TypeCode.Int16:
          return ((ushort) (short) value).ToString("X4", (IFormatProvider) null);
        case TypeCode.UInt16:
          return ((ushort) value).ToString("X4", (IFormatProvider) null);
        case TypeCode.Int32:
          return ((uint) (int) value).ToString("X8", (IFormatProvider) null);
        case TypeCode.UInt32:
          return ((uint) value).ToString("X8", (IFormatProvider) null);
        case TypeCode.Int64:
          return ((ulong) (long) value).ToString("X16", (IFormatProvider) null);
        case TypeCode.UInt64:
          return ((ulong) value).ToString("X16", (IFormatProvider) null);
        default:
          throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_UnknownEnumType"));
      }
    }

    private static string InternalFormat(RuntimeType eT, object value)
    {
      if (!eT.IsDefined(typeof (FlagsAttribute), false))
        return Enum.GetName((Type) eT, value) ?? value.ToString();
      return Enum.InternalFlagsFormat(eT, value);
    }

    private static string InternalFlagsFormat(RuntimeType eT, object value)
    {
      ulong uint64 = Enum.ToUInt64(value);
      Enum.ValuesAndNames cachedValuesAndNames = Enum.GetCachedValuesAndNames(eT, true);
      string[] names = cachedValuesAndNames.Names;
      ulong[] values = cachedValuesAndNames.Values;
      int index = values.Length - 1;
      StringBuilder stringBuilder = new StringBuilder();
      bool flag = true;
      ulong num = uint64;
      for (; index >= 0 && (index != 0 || values[index] != 0UL); --index)
      {
        if (((long) uint64 & (long) values[index]) == (long) values[index])
        {
          uint64 -= values[index];
          if (!flag)
            stringBuilder.Insert(0, ", ");
          stringBuilder.Insert(0, names[index]);
          flag = false;
        }
      }
      if (uint64 != 0UL)
        return value.ToString();
      if (num != 0UL)
        return stringBuilder.ToString();
      if (values.Length != 0 && values[0] == 0UL)
        return names[0];
      return "0";
    }

    internal static ulong ToUInt64(object value)
    {
      switch (Convert.GetTypeCode(value))
      {
        case TypeCode.Boolean:
        case TypeCode.Char:
        case TypeCode.Byte:
        case TypeCode.UInt16:
        case TypeCode.UInt32:
        case TypeCode.UInt64:
          return Convert.ToUInt64(value, (IFormatProvider) CultureInfo.InvariantCulture);
        case TypeCode.SByte:
        case TypeCode.Int16:
        case TypeCode.Int32:
        case TypeCode.Int64:
          return (ulong) Convert.ToInt64(value, (IFormatProvider) CultureInfo.InvariantCulture);
        default:
          throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_UnknownEnumType"));
      }
    }

    [SecurityCritical]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern int InternalCompareTo(object o1, object o2);

    [SecuritySafeCritical]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern RuntimeType InternalGetUnderlyingType(RuntimeType enumType);

    [SecurityCritical]
    [SuppressUnmanagedCodeSecurity]
    [DllImport("QCall", CharSet = CharSet.Unicode)]
    private static extern void GetEnumValuesAndNames(RuntimeTypeHandle enumType, ObjectHandleOnStack values, ObjectHandleOnStack names, bool getNames);

    [SecurityCritical]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern object InternalBoxEnum(RuntimeType enumType, long value);

    [__DynamicallyInvokable]
    public static bool TryParse<TEnum>(string value, out TEnum result) where TEnum : struct
    {
      return Enum.TryParse<TEnum>(value, false, out result);
    }

    [__DynamicallyInvokable]
    public static bool TryParse<TEnum>(string value, bool ignoreCase, out TEnum result) where TEnum : struct
    {
      result = default (TEnum);
      Enum.EnumResult parseResult = new Enum.EnumResult();
      parseResult.Init(false);
      bool flag;
      if (flag = Enum.TryParseEnum(typeof (TEnum), value, ignoreCase, ref parseResult))
        result = (TEnum) parseResult.parsedEnum;
      return flag;
    }

    [ComVisible(true)]
    [__DynamicallyInvokable]
    public static object Parse(Type enumType, string value)
    {
      return Enum.Parse(enumType, value, false);
    }

    [ComVisible(true)]
    [__DynamicallyInvokable]
    public static object Parse(Type enumType, string value, bool ignoreCase)
    {
      Enum.EnumResult parseResult = new Enum.EnumResult();
      parseResult.Init(true);
      if (Enum.TryParseEnum(enumType, value, ignoreCase, ref parseResult))
        return parseResult.parsedEnum;
      throw parseResult.GetEnumParseException();
    }

    private static bool TryParseEnum(Type enumType, string value, bool ignoreCase, ref Enum.EnumResult parseResult)
    {
      if (enumType == (Type) null)
        throw new ArgumentNullException(nameof (enumType));
      RuntimeType enumType1 = enumType as RuntimeType;
      if (enumType1 == (RuntimeType) null)
        throw new ArgumentException(Environment.GetResourceString("Arg_MustBeType"), nameof (enumType));
      if (!enumType.IsEnum)
        throw new ArgumentException(Environment.GetResourceString("Arg_MustBeEnum"), nameof (enumType));
      if (value == null)
      {
        parseResult.SetFailure(Enum.ParseFailureKind.ArgumentNull, nameof (value));
        return false;
      }
      value = value.Trim();
      if (value.Length == 0)
      {
        parseResult.SetFailure(Enum.ParseFailureKind.Argument, "Arg_MustContainEnumInfo", (object) null);
        return false;
      }
      ulong num1 = 0;
      if (char.IsDigit(value[0]) || value[0] == '-' || value[0] == '+')
      {
        Type underlyingType = Enum.GetUnderlyingType(enumType);
        try
        {
          object obj = Convert.ChangeType((object) value, underlyingType, (IFormatProvider) CultureInfo.InvariantCulture);
          parseResult.parsedEnum = Enum.ToObject(enumType, obj);
          return true;
        }
        catch (FormatException ex)
        {
        }
        catch (Exception ex)
        {
          if (parseResult.canThrow)
          {
            throw;
          }
          else
          {
            parseResult.SetFailure(ex);
            return false;
          }
        }
      }
      string[] strArray = value.Split(Enum.enumSeperatorCharArray);
      Enum.ValuesAndNames cachedValuesAndNames = Enum.GetCachedValuesAndNames(enumType1, true);
      string[] names = cachedValuesAndNames.Names;
      ulong[] values = cachedValuesAndNames.Values;
      for (int index1 = 0; index1 < strArray.Length; ++index1)
      {
        strArray[index1] = strArray[index1].Trim();
        bool flag = false;
        for (int index2 = 0; index2 < names.Length; ++index2)
        {
          if (ignoreCase)
          {
            if (string.Compare(names[index2], strArray[index1], StringComparison.OrdinalIgnoreCase) != 0)
              continue;
          }
          else if (!names[index2].Equals(strArray[index1]))
            continue;
          ulong num2 = values[index2];
          num1 |= num2;
          flag = true;
          break;
        }
        if (!flag)
        {
          parseResult.SetFailure(Enum.ParseFailureKind.ArgumentWithParameter, "Arg_EnumValueNotFound", (object) value);
          return false;
        }
      }
      try
      {
        parseResult.parsedEnum = Enum.ToObject(enumType, num1);
        return true;
      }
      catch (Exception ex)
      {
        if (parseResult.canThrow)
        {
          throw;
        }
        else
        {
          parseResult.SetFailure(ex);
          return false;
        }
      }
    }

    [ComVisible(true)]
    [__DynamicallyInvokable]
    public static Type GetUnderlyingType(Type enumType)
    {
      if (enumType == (Type) null)
        throw new ArgumentNullException(nameof (enumType));
      return enumType.GetEnumUnderlyingType();
    }

    [ComVisible(true)]
    [__DynamicallyInvokable]
    public static Array GetValues(Type enumType)
    {
      if (enumType == (Type) null)
        throw new ArgumentNullException(nameof (enumType));
      return enumType.GetEnumValues();
    }

    internal static ulong[] InternalGetValues(RuntimeType enumType)
    {
      return Enum.GetCachedValuesAndNames(enumType, false).Values;
    }

    [ComVisible(true)]
    [__DynamicallyInvokable]
    public static string GetName(Type enumType, object value)
    {
      if (enumType == (Type) null)
        throw new ArgumentNullException(nameof (enumType));
      return enumType.GetEnumName(value);
    }

    [ComVisible(true)]
    [__DynamicallyInvokable]
    public static string[] GetNames(Type enumType)
    {
      if (enumType == (Type) null)
        throw new ArgumentNullException(nameof (enumType));
      return enumType.GetEnumNames();
    }

    internal static string[] InternalGetNames(RuntimeType enumType)
    {
      return Enum.GetCachedValuesAndNames(enumType, true).Names;
    }

    [ComVisible(true)]
    [__DynamicallyInvokable]
    public static object ToObject(Type enumType, object value)
    {
      if (value == null)
        throw new ArgumentNullException(nameof (value));
      TypeCode typeCode = Convert.GetTypeCode(value);
      if (CompatibilitySwitches.IsAppEarlierThanWindowsPhone8 && (typeCode == TypeCode.Boolean || typeCode == TypeCode.Char))
        throw new ArgumentException(Environment.GetResourceString("Arg_MustBeEnumBaseTypeOrEnum"), nameof (value));
      switch (typeCode)
      {
        case TypeCode.Boolean:
          return Enum.ToObject(enumType, (bool) value);
        case TypeCode.Char:
          return Enum.ToObject(enumType, (char) value);
        case TypeCode.SByte:
          return Enum.ToObject(enumType, (sbyte) value);
        case TypeCode.Byte:
          return Enum.ToObject(enumType, (byte) value);
        case TypeCode.Int16:
          return Enum.ToObject(enumType, (short) value);
        case TypeCode.UInt16:
          return Enum.ToObject(enumType, (ushort) value);
        case TypeCode.Int32:
          return Enum.ToObject(enumType, (int) value);
        case TypeCode.UInt32:
          return Enum.ToObject(enumType, (uint) value);
        case TypeCode.Int64:
          return Enum.ToObject(enumType, (long) value);
        case TypeCode.UInt64:
          return Enum.ToObject(enumType, (ulong) value);
        default:
          throw new ArgumentException(Environment.GetResourceString("Arg_MustBeEnumBaseTypeOrEnum"), nameof (value));
      }
    }

    [ComVisible(true)]
    [__DynamicallyInvokable]
    public static bool IsDefined(Type enumType, object value)
    {
      if (enumType == (Type) null)
        throw new ArgumentNullException(nameof (enumType));
      return enumType.IsEnumDefined(value);
    }

    [ComVisible(true)]
    [__DynamicallyInvokable]
    public static string Format(Type enumType, object value, string format)
    {
      if (enumType == (Type) null)
        throw new ArgumentNullException(nameof (enumType));
      if (!enumType.IsEnum)
        throw new ArgumentException(Environment.GetResourceString("Arg_MustBeEnum"), nameof (enumType));
      if (value == null)
        throw new ArgumentNullException(nameof (value));
      if (format == null)
        throw new ArgumentNullException(nameof (format));
      RuntimeType eT = enumType as RuntimeType;
      if (eT == (RuntimeType) null)
        throw new ArgumentException(Environment.GetResourceString("Arg_MustBeType"), nameof (enumType));
      Type type = value.GetType();
      Type underlyingType = Enum.GetUnderlyingType(enumType);
      if (type.IsEnum)
      {
        Enum.GetUnderlyingType(type);
        if (!type.IsEquivalentTo(enumType))
          throw new ArgumentException(Environment.GetResourceString("Arg_EnumAndObjectMustBeSameType", (object) type.ToString(), (object) enumType.ToString()));
        value = ((Enum) value).GetValue();
      }
      else if (type != underlyingType)
        throw new ArgumentException(Environment.GetResourceString("Arg_EnumFormatUnderlyingTypeAndObjectMustBeSameType", (object) type.ToString(), (object) underlyingType.ToString()));
      if (format.Length != 1)
        throw new FormatException(Environment.GetResourceString("Format_InvalidEnumFormatSpecification"));
      switch (format[0])
      {
        case 'D':
        case 'd':
          return value.ToString();
        case 'F':
        case 'f':
          return Enum.InternalFlagsFormat(eT, value);
        case 'G':
        case 'g':
          return Enum.InternalFormat(eT, value);
        case 'X':
        case 'x':
          return Enum.InternalFormattedHexString(value);
        default:
          throw new FormatException(Environment.GetResourceString("Format_InvalidEnumFormatSpecification"));
      }
    }

    [SecuritySafeCritical]
    internal unsafe object GetValue()
    {
      fixed (byte* numPtr = &JitHelpers.GetPinningHelper((object) this).m_data)
      {
        switch (this.InternalGetCorElementType())
        {
          case CorElementType.Boolean:
            return (object) (bool) *numPtr;
          case CorElementType.Char:
            return (object) (char) *(ushort*) numPtr;
          case CorElementType.I1:
            return (object) *(sbyte*) numPtr;
          case CorElementType.U1:
            return (object) *numPtr;
          case CorElementType.I2:
            return (object) *(short*) numPtr;
          case CorElementType.U2:
            return (object) *(ushort*) numPtr;
          case CorElementType.I4:
            return (object) *(int*) numPtr;
          case CorElementType.U4:
            return (object) *(uint*) numPtr;
          case CorElementType.I8:
            return (object) *(long*) numPtr;
          case CorElementType.U8:
            return (object) (ulong) *(long*) numPtr;
          case CorElementType.R4:
            return (object) *(float*) numPtr;
          case CorElementType.R8:
            return (object) *(double*) numPtr;
          case CorElementType.I:
            return (object) *(IntPtr*) numPtr;
          case CorElementType.U:
            return (object) (UIntPtr) *(IntPtr*) numPtr;
          default:
            return (object) null;
        }
      }
    }

    [SecurityCritical]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern bool InternalHasFlag(Enum flags);

    [SecuritySafeCritical]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern CorElementType InternalGetCorElementType();

    [SecuritySafeCritical]
    [__DynamicallyInvokable]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public override extern bool Equals(object obj);

    [SecuritySafeCritical]
    [__DynamicallyInvokable]
    public override unsafe int GetHashCode()
    {
      fixed (byte* numPtr = &JitHelpers.GetPinningHelper((object) this).m_data)
      {
        switch (this.InternalGetCorElementType())
        {
          case CorElementType.Boolean:
            return ((bool*) numPtr)->GetHashCode();
          case CorElementType.Char:
            return ((char*) numPtr)->GetHashCode();
          case CorElementType.I1:
            return ((sbyte*) numPtr)->GetHashCode();
          case CorElementType.U1:
            return numPtr->GetHashCode();
          case CorElementType.I2:
            return ((short*) numPtr)->GetHashCode();
          case CorElementType.U2:
            return ((ushort*) numPtr)->GetHashCode();
          case CorElementType.I4:
            return ((int*) numPtr)->GetHashCode();
          case CorElementType.U4:
            return ((uint*) numPtr)->GetHashCode();
          case CorElementType.I8:
            return ((long*) numPtr)->GetHashCode();
          case CorElementType.U8:
            return ((ulong*) numPtr)->GetHashCode();
          case CorElementType.R4:
            return ((float*) numPtr)->GetHashCode();
          case CorElementType.R8:
            return ((double*) numPtr)->GetHashCode();
          case CorElementType.I:
            return numPtr->GetHashCode();
          case CorElementType.U:
            return numPtr->GetHashCode();
          default:
            return 0;
        }
      }
    }

    [__DynamicallyInvokable]
    public override string ToString()
    {
      return Enum.InternalFormat((RuntimeType) this.GetType(), this.GetValue());
    }

    [Obsolete("The provider argument is not used. Please use ToString(String).")]
    public string ToString(string format, IFormatProvider provider)
    {
      return this.ToString(format);
    }

    [SecuritySafeCritical]
    [__DynamicallyInvokable]
    public int CompareTo(object target)
    {
      if (this == null)
        throw new NullReferenceException();
      int num = Enum.InternalCompareTo((object) this, target);
      if (num < 2)
        return num;
      if (num == 2)
      {
        Type type = this.GetType();
        throw new ArgumentException(Environment.GetResourceString("Arg_EnumAndObjectMustBeSameType", (object) target.GetType().ToString(), (object) type.ToString()));
      }
      throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_UnknownEnumType"));
    }

    [__DynamicallyInvokable]
    public string ToString(string format)
    {
      if (format == null || format.Length == 0)
        format = "G";
      if (string.Compare(format, "G", StringComparison.OrdinalIgnoreCase) == 0)
        return this.ToString();
      if (string.Compare(format, "D", StringComparison.OrdinalIgnoreCase) == 0)
        return this.GetValue().ToString();
      if (string.Compare(format, "X", StringComparison.OrdinalIgnoreCase) == 0)
        return Enum.InternalFormattedHexString(this.GetValue());
      if (string.Compare(format, "F", StringComparison.OrdinalIgnoreCase) == 0)
        return Enum.InternalFlagsFormat((RuntimeType) this.GetType(), this.GetValue());
      throw new FormatException(Environment.GetResourceString("Format_InvalidEnumFormatSpecification"));
    }

    [Obsolete("The provider argument is not used. Please use ToString().")]
    public string ToString(IFormatProvider provider)
    {
      return this.ToString();
    }

    [SecuritySafeCritical]
    [__DynamicallyInvokable]
    public bool HasFlag(Enum flag)
    {
      if (flag == null)
        throw new ArgumentNullException(nameof (flag));
      if (!this.GetType().IsEquivalentTo(flag.GetType()))
        throw new ArgumentException(Environment.GetResourceString("Argument_EnumTypeDoesNotMatch", (object) flag.GetType(), (object) this.GetType()));
      return this.InternalHasFlag(flag);
    }

    public TypeCode GetTypeCode()
    {
      Type underlyingType = Enum.GetUnderlyingType(this.GetType());
      if (underlyingType == typeof (int))
        return TypeCode.Int32;
      if (underlyingType == typeof (sbyte))
        return TypeCode.SByte;
      if (underlyingType == typeof (short))
        return TypeCode.Int16;
      if (underlyingType == typeof (long))
        return TypeCode.Int64;
      if (underlyingType == typeof (uint))
        return TypeCode.UInt32;
      if (underlyingType == typeof (byte))
        return TypeCode.Byte;
      if (underlyingType == typeof (ushort))
        return TypeCode.UInt16;
      if (underlyingType == typeof (ulong))
        return TypeCode.UInt64;
      if (underlyingType == typeof (bool))
        return TypeCode.Boolean;
      if (underlyingType == typeof (char))
        return TypeCode.Char;
      throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_UnknownEnumType"));
    }

    [__DynamicallyInvokable]
    bool IConvertible.ToBoolean(IFormatProvider provider)
    {
      return Convert.ToBoolean(this.GetValue(), (IFormatProvider) CultureInfo.CurrentCulture);
    }

    [__DynamicallyInvokable]
    char IConvertible.ToChar(IFormatProvider provider)
    {
      return Convert.ToChar(this.GetValue(), (IFormatProvider) CultureInfo.CurrentCulture);
    }

    [__DynamicallyInvokable]
    sbyte IConvertible.ToSByte(IFormatProvider provider)
    {
      return Convert.ToSByte(this.GetValue(), (IFormatProvider) CultureInfo.CurrentCulture);
    }

    [__DynamicallyInvokable]
    byte IConvertible.ToByte(IFormatProvider provider)
    {
      return Convert.ToByte(this.GetValue(), (IFormatProvider) CultureInfo.CurrentCulture);
    }

    [__DynamicallyInvokable]
    short IConvertible.ToInt16(IFormatProvider provider)
    {
      return Convert.ToInt16(this.GetValue(), (IFormatProvider) CultureInfo.CurrentCulture);
    }

    [__DynamicallyInvokable]
    ushort IConvertible.ToUInt16(IFormatProvider provider)
    {
      return Convert.ToUInt16(this.GetValue(), (IFormatProvider) CultureInfo.CurrentCulture);
    }

    [__DynamicallyInvokable]
    int IConvertible.ToInt32(IFormatProvider provider)
    {
      return Convert.ToInt32(this.GetValue(), (IFormatProvider) CultureInfo.CurrentCulture);
    }

    [__DynamicallyInvokable]
    uint IConvertible.ToUInt32(IFormatProvider provider)
    {
      return Convert.ToUInt32(this.GetValue(), (IFormatProvider) CultureInfo.CurrentCulture);
    }

    [__DynamicallyInvokable]
    long IConvertible.ToInt64(IFormatProvider provider)
    {
      return Convert.ToInt64(this.GetValue(), (IFormatProvider) CultureInfo.CurrentCulture);
    }

    [__DynamicallyInvokable]
    ulong IConvertible.ToUInt64(IFormatProvider provider)
    {
      return Convert.ToUInt64(this.GetValue(), (IFormatProvider) CultureInfo.CurrentCulture);
    }

    [__DynamicallyInvokable]
    float IConvertible.ToSingle(IFormatProvider provider)
    {
      return Convert.ToSingle(this.GetValue(), (IFormatProvider) CultureInfo.CurrentCulture);
    }

    [__DynamicallyInvokable]
    double IConvertible.ToDouble(IFormatProvider provider)
    {
      return Convert.ToDouble(this.GetValue(), (IFormatProvider) CultureInfo.CurrentCulture);
    }

    [__DynamicallyInvokable]
    Decimal IConvertible.ToDecimal(IFormatProvider provider)
    {
      return Convert.ToDecimal(this.GetValue(), (IFormatProvider) CultureInfo.CurrentCulture);
    }

    [__DynamicallyInvokable]
    DateTime IConvertible.ToDateTime(IFormatProvider provider)
    {
      throw new InvalidCastException(Environment.GetResourceString("InvalidCast_FromTo", (object) nameof (Enum), (object) "DateTime"));
    }

    [__DynamicallyInvokable]
    object IConvertible.ToType(Type type, IFormatProvider provider)
    {
      return Convert.DefaultToType((IConvertible) this, type, provider);
    }

    [SecuritySafeCritical]
    [CLSCompliant(false)]
    [ComVisible(true)]
    public static object ToObject(Type enumType, sbyte value)
    {
      if (enumType == (Type) null)
        throw new ArgumentNullException(nameof (enumType));
      if (!enumType.IsEnum)
        throw new ArgumentException(Environment.GetResourceString("Arg_MustBeEnum"), nameof (enumType));
      RuntimeType enumType1 = enumType as RuntimeType;
      if (enumType1 == (RuntimeType) null)
        throw new ArgumentException(Environment.GetResourceString("Arg_MustBeType"), nameof (enumType));
      return Enum.InternalBoxEnum(enumType1, (long) value);
    }

    [SecuritySafeCritical]
    [ComVisible(true)]
    public static object ToObject(Type enumType, short value)
    {
      if (enumType == (Type) null)
        throw new ArgumentNullException(nameof (enumType));
      if (!enumType.IsEnum)
        throw new ArgumentException(Environment.GetResourceString("Arg_MustBeEnum"), nameof (enumType));
      RuntimeType enumType1 = enumType as RuntimeType;
      if (enumType1 == (RuntimeType) null)
        throw new ArgumentException(Environment.GetResourceString("Arg_MustBeType"), nameof (enumType));
      return Enum.InternalBoxEnum(enumType1, (long) value);
    }

    [SecuritySafeCritical]
    [ComVisible(true)]
    public static object ToObject(Type enumType, int value)
    {
      if (enumType == (Type) null)
        throw new ArgumentNullException(nameof (enumType));
      if (!enumType.IsEnum)
        throw new ArgumentException(Environment.GetResourceString("Arg_MustBeEnum"), nameof (enumType));
      RuntimeType enumType1 = enumType as RuntimeType;
      if (enumType1 == (RuntimeType) null)
        throw new ArgumentException(Environment.GetResourceString("Arg_MustBeType"), nameof (enumType));
      return Enum.InternalBoxEnum(enumType1, (long) value);
    }

    [SecuritySafeCritical]
    [ComVisible(true)]
    public static object ToObject(Type enumType, byte value)
    {
      if (enumType == (Type) null)
        throw new ArgumentNullException(nameof (enumType));
      if (!enumType.IsEnum)
        throw new ArgumentException(Environment.GetResourceString("Arg_MustBeEnum"), nameof (enumType));
      RuntimeType enumType1 = enumType as RuntimeType;
      if (enumType1 == (RuntimeType) null)
        throw new ArgumentException(Environment.GetResourceString("Arg_MustBeType"), nameof (enumType));
      return Enum.InternalBoxEnum(enumType1, (long) value);
    }

    [SecuritySafeCritical]
    [CLSCompliant(false)]
    [ComVisible(true)]
    public static object ToObject(Type enumType, ushort value)
    {
      if (enumType == (Type) null)
        throw new ArgumentNullException(nameof (enumType));
      if (!enumType.IsEnum)
        throw new ArgumentException(Environment.GetResourceString("Arg_MustBeEnum"), nameof (enumType));
      RuntimeType enumType1 = enumType as RuntimeType;
      if (enumType1 == (RuntimeType) null)
        throw new ArgumentException(Environment.GetResourceString("Arg_MustBeType"), nameof (enumType));
      return Enum.InternalBoxEnum(enumType1, (long) value);
    }

    [SecuritySafeCritical]
    [CLSCompliant(false)]
    [ComVisible(true)]
    public static object ToObject(Type enumType, uint value)
    {
      if (enumType == (Type) null)
        throw new ArgumentNullException(nameof (enumType));
      if (!enumType.IsEnum)
        throw new ArgumentException(Environment.GetResourceString("Arg_MustBeEnum"), nameof (enumType));
      RuntimeType enumType1 = enumType as RuntimeType;
      if (enumType1 == (RuntimeType) null)
        throw new ArgumentException(Environment.GetResourceString("Arg_MustBeType"), nameof (enumType));
      return Enum.InternalBoxEnum(enumType1, (long) value);
    }

    [SecuritySafeCritical]
    [ComVisible(true)]
    public static object ToObject(Type enumType, long value)
    {
      if (enumType == (Type) null)
        throw new ArgumentNullException(nameof (enumType));
      if (!enumType.IsEnum)
        throw new ArgumentException(Environment.GetResourceString("Arg_MustBeEnum"), nameof (enumType));
      RuntimeType enumType1 = enumType as RuntimeType;
      if (enumType1 == (RuntimeType) null)
        throw new ArgumentException(Environment.GetResourceString("Arg_MustBeType"), nameof (enumType));
      return Enum.InternalBoxEnum(enumType1, value);
    }

    [SecuritySafeCritical]
    [CLSCompliant(false)]
    [ComVisible(true)]
    public static object ToObject(Type enumType, ulong value)
    {
      if (enumType == (Type) null)
        throw new ArgumentNullException(nameof (enumType));
      if (!enumType.IsEnum)
        throw new ArgumentException(Environment.GetResourceString("Arg_MustBeEnum"), nameof (enumType));
      RuntimeType enumType1 = enumType as RuntimeType;
      if (enumType1 == (RuntimeType) null)
        throw new ArgumentException(Environment.GetResourceString("Arg_MustBeType"), nameof (enumType));
      return Enum.InternalBoxEnum(enumType1, (long) value);
    }

    [SecuritySafeCritical]
    private static object ToObject(Type enumType, char value)
    {
      if (enumType == (Type) null)
        throw new ArgumentNullException(nameof (enumType));
      if (!enumType.IsEnum)
        throw new ArgumentException(Environment.GetResourceString("Arg_MustBeEnum"), nameof (enumType));
      RuntimeType enumType1 = enumType as RuntimeType;
      if (enumType1 == (RuntimeType) null)
        throw new ArgumentException(Environment.GetResourceString("Arg_MustBeType"), nameof (enumType));
      return Enum.InternalBoxEnum(enumType1, (long) value);
    }

    [SecuritySafeCritical]
    private static object ToObject(Type enumType, bool value)
    {
      if (enumType == (Type) null)
        throw new ArgumentNullException(nameof (enumType));
      if (!enumType.IsEnum)
        throw new ArgumentException(Environment.GetResourceString("Arg_MustBeEnum"), nameof (enumType));
      RuntimeType enumType1 = enumType as RuntimeType;
      if (enumType1 == (RuntimeType) null)
        throw new ArgumentException(Environment.GetResourceString("Arg_MustBeType"), nameof (enumType));
      return Enum.InternalBoxEnum(enumType1, value ? 1L : 0L);
    }

    [__DynamicallyInvokable]
    protected Enum()
    {
    }

    private enum ParseFailureKind
    {
      None,
      Argument,
      ArgumentNull,
      ArgumentWithParameter,
      UnhandledException,
    }

    private struct EnumResult
    {
      internal object parsedEnum;
      internal bool canThrow;
      internal Enum.ParseFailureKind m_failure;
      internal string m_failureMessageID;
      internal string m_failureParameter;
      internal object m_failureMessageFormatArgument;
      internal Exception m_innerException;

      internal void Init(bool canMethodThrow)
      {
        this.parsedEnum = (object) 0;
        this.canThrow = canMethodThrow;
      }

      internal void SetFailure(Exception unhandledException)
      {
        this.m_failure = Enum.ParseFailureKind.UnhandledException;
        this.m_innerException = unhandledException;
      }

      internal void SetFailure(Enum.ParseFailureKind failure, string failureParameter)
      {
        this.m_failure = failure;
        this.m_failureParameter = failureParameter;
        if (this.canThrow)
          throw this.GetEnumParseException();
      }

      internal void SetFailure(Enum.ParseFailureKind failure, string failureMessageID, object failureMessageFormatArgument)
      {
        this.m_failure = failure;
        this.m_failureMessageID = failureMessageID;
        this.m_failureMessageFormatArgument = failureMessageFormatArgument;
        if (this.canThrow)
          throw this.GetEnumParseException();
      }

      internal Exception GetEnumParseException()
      {
        switch (this.m_failure)
        {
          case Enum.ParseFailureKind.Argument:
            return (Exception) new ArgumentException(Environment.GetResourceString(this.m_failureMessageID));
          case Enum.ParseFailureKind.ArgumentNull:
            return (Exception) new ArgumentNullException(this.m_failureParameter);
          case Enum.ParseFailureKind.ArgumentWithParameter:
            return (Exception) new ArgumentException(Environment.GetResourceString(this.m_failureMessageID, this.m_failureMessageFormatArgument));
          case Enum.ParseFailureKind.UnhandledException:
            return this.m_innerException;
          default:
            return (Exception) new ArgumentException(Environment.GetResourceString("Arg_EnumValueNotFound"));
        }
      }
    }

    private class ValuesAndNames
    {
      public ulong[] Values;
      public string[] Names;

      public ValuesAndNames(ulong[] values, string[] names)
      {
        this.Values = values;
        this.Names = names;
      }
    }
  }
}
