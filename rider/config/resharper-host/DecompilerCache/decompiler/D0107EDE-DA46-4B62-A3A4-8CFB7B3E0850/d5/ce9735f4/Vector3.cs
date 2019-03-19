﻿// Decompiled with JetBrains decompiler
// Type: UnityEngine.Vector3
// Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D0107EDE-DA46-4B62-A3A4-8CFB7B3E0850
// Assembly location: C:\Program Files\Unity2018.3.6f1\Editor\Data\Managed\UnityEngine\UnityEngine.CoreModule.dll

using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;
using UnityEngine.Internal;
using UnityEngine.Scripting;

namespace UnityEngine
{
  /// <summary>
  ///   <para>Representation of 3D vectors and points.</para>
  /// </summary>
  [NativeType(Header = "Runtime/Math/Vector3.h")]
  [NativeHeader("Runtime/Math/MathScripting.h")]
  [NativeClass("Vector3f")]
  [RequiredByNativeCode(GenerateProxy = true, Optional = true)]
  [ThreadAndSerializationSafe]
  [NativeHeader("Runtime/Math/Vector3.h")]
  public struct Vector3 : IEquatable<Vector3>
  {
    private static readonly Vector3 zeroVector = new Vector3(0.0f, 0.0f, 0.0f);
    private static readonly Vector3 oneVector = new Vector3(1f, 1f, 1f);
    private static readonly Vector3 upVector = new Vector3(0.0f, 1f, 0.0f);
    private static readonly Vector3 downVector = new Vector3(0.0f, -1f, 0.0f);
    private static readonly Vector3 leftVector = new Vector3(-1f, 0.0f, 0.0f);
    private static readonly Vector3 rightVector = new Vector3(1f, 0.0f, 0.0f);
    private static readonly Vector3 forwardVector = new Vector3(0.0f, 0.0f, 1f);
    private static readonly Vector3 backVector = new Vector3(0.0f, 0.0f, -1f);
    private static readonly Vector3 positiveInfinityVector = new Vector3(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity);
    private static readonly Vector3 negativeInfinityVector = new Vector3(float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity);
    public const float kEpsilon = 1E-05f;
    public const float kEpsilonNormalSqrt = 1E-15f;
    /// <summary>
    ///   <para>X component of the vector.</para>
    /// </summary>
    public float x;
    /// <summary>
    ///   <para>Y component of the vector.</para>
    /// </summary>
    public float y;
    /// <summary>
    ///   <para>Z component of the vector.</para>
    /// </summary>
    public float z;

    /// <summary>
    ///   <para>Creates a new vector with given x, y, z components.</para>
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="z"></param>
    public Vector3(float x, float y, float z)
    {
      this.x = x;
      this.y = y;
      this.z = z;
    }

    /// <summary>
    ///   <para>Creates a new vector with given x, y components and sets z to zero.</para>
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    public Vector3(float x, float y)
    {
      this.x = x;
      this.y = y;
      this.z = 0.0f;
    }

    /// <summary>
    ///   <para>Spherically interpolates between two vectors.</para>
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <param name="t"></param>
    [FreeFunction("VectorScripting::Slerp", IsThreadSafe = true)]
    public static Vector3 Slerp(Vector3 a, Vector3 b, float t)
    {
      Vector3 ret;
      Vector3.Slerp_Injected(ref a, ref b, t, out ret);
      return ret;
    }

    /// <summary>
    ///   <para>Spherically interpolates between two vectors.</para>
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <param name="t"></param>
    [FreeFunction("VectorScripting::SlerpUnclamped", IsThreadSafe = true)]
    public static Vector3 SlerpUnclamped(Vector3 a, Vector3 b, float t)
    {
      Vector3 ret;
      Vector3.SlerpUnclamped_Injected(ref a, ref b, t, out ret);
      return ret;
    }

    [FreeFunction("VectorScripting::OrthoNormalize", IsThreadSafe = true)]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void OrthoNormalize2(ref Vector3 a, ref Vector3 b);

    public static void OrthoNormalize(ref Vector3 normal, ref Vector3 tangent)
    {
      Vector3.OrthoNormalize2(ref normal, ref tangent);
    }

    [FreeFunction("VectorScripting::OrthoNormalize", IsThreadSafe = true)]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void OrthoNormalize3(ref Vector3 a, ref Vector3 b, ref Vector3 c);

    public static void OrthoNormalize(
      ref Vector3 normal,
      ref Vector3 tangent,
      ref Vector3 binormal)
    {
      Vector3.OrthoNormalize3(ref normal, ref tangent, ref binormal);
    }

    /// <summary>
    ///   <para>Rotates a vector current towards target.</para>
    /// </summary>
    /// <param name="current">The vector being managed.</param>
    /// <param name="target">The vector.</param>
    /// <param name="maxRadiansDelta">The distance between the two vectors  in radians.</param>
    /// <param name="maxMagnitudeDelta">The length of the radian.</param>
    /// <returns>
    ///   <para>The location that RotateTowards generates.</para>
    /// </returns>
    [FreeFunction(IsThreadSafe = true)]
    public static Vector3 RotateTowards(
      Vector3 current,
      Vector3 target,
      float maxRadiansDelta,
      float maxMagnitudeDelta)
    {
      Vector3 ret;
      Vector3.RotateTowards_Injected(ref current, ref target, maxRadiansDelta, maxMagnitudeDelta, out ret);
      return ret;
    }

    /// <summary>
    ///   <para>Linearly interpolates between two vectors.</para>
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <param name="t"></param>
    public static Vector3 Lerp(Vector3 a, Vector3 b, float t)
    {
      t = Mathf.Clamp01(t);
      return new Vector3(a.x + (b.x - a.x) * t, a.y + (b.y - a.y) * t, a.z + (b.z - a.z) * t);
    }

    /// <summary>
    ///   <para>Linearly interpolates between two vectors.</para>
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <param name="t"></param>
    public static Vector3 LerpUnclamped(Vector3 a, Vector3 b, float t)
    {
      return new Vector3(a.x + (b.x - a.x) * t, a.y + (b.y - a.y) * t, a.z + (b.z - a.z) * t);
    }

    /// <summary>
    ///   <para>Moves a point current in a straight line towards a target point.</para>
    /// </summary>
    /// <param name="current"></param>
    /// <param name="target"></param>
    /// <param name="maxDistanceDelta"></param>
    public static Vector3 MoveTowards(
      Vector3 current,
      Vector3 target,
      float maxDistanceDelta)
    {
      Vector3 vector3 = target - current;
      float magnitude = vector3.magnitude;
      if ((double) magnitude <= (double) maxDistanceDelta || (double) magnitude < 1.40129846432482E-45)
        return target;
      return current + vector3 / magnitude * maxDistanceDelta;
    }

    [ExcludeFromDocs]
    public static Vector3 SmoothDamp(
      Vector3 current,
      Vector3 target,
      ref Vector3 currentVelocity,
      float smoothTime,
      float maxSpeed)
    {
      float deltaTime = Time.deltaTime;
      return Vector3.SmoothDamp(current, target, ref currentVelocity, smoothTime, maxSpeed, deltaTime);
    }

    [ExcludeFromDocs]
    public static Vector3 SmoothDamp(
      Vector3 current,
      Vector3 target,
      ref Vector3 currentVelocity,
      float smoothTime)
    {
      float deltaTime = Time.deltaTime;
      float maxSpeed = float.PositiveInfinity;
      return Vector3.SmoothDamp(current, target, ref currentVelocity, smoothTime, maxSpeed, deltaTime);
    }

    public static Vector3 SmoothDamp(
      Vector3 current,
      Vector3 target,
      ref Vector3 currentVelocity,
      float smoothTime,
      [DefaultValue("Mathf.Infinity")] float maxSpeed,
      [DefaultValue("Time.deltaTime")] float deltaTime)
    {
      smoothTime = Mathf.Max(0.0001f, smoothTime);
      float num1 = 2f / smoothTime;
      float num2 = num1 * deltaTime;
      float num3 = (float) (1.0 / (1.0 + (double) num2 + 0.479999989271164 * (double) num2 * (double) num2 + 0.234999999403954 * (double) num2 * (double) num2 * (double) num2));
      Vector3 vector = current - target;
      Vector3 vector3_1 = target;
      float maxLength = maxSpeed * smoothTime;
      Vector3 vector3_2 = Vector3.ClampMagnitude(vector, maxLength);
      target = current - vector3_2;
      Vector3 vector3_3 = (currentVelocity + num1 * vector3_2) * deltaTime;
      currentVelocity = (currentVelocity - num1 * vector3_3) * num3;
      Vector3 vector3_4 = target + (vector3_2 + vector3_3) * num3;
      if ((double) Vector3.Dot(vector3_1 - current, vector3_4 - vector3_1) > 0.0)
      {
        vector3_4 = vector3_1;
        currentVelocity = (vector3_4 - vector3_1) / deltaTime;
      }
      return vector3_4;
    }

    public float this[int index]
    {
      get
      {
        switch (index)
        {
          case 0:
            return this.x;
          case 1:
            return this.y;
          case 2:
            return this.z;
          default:
            throw new IndexOutOfRangeException("Invalid Vector3 index!");
        }
      }
      set
      {
        switch (index)
        {
          case 0:
            this.x = value;
            break;
          case 1:
            this.y = value;
            break;
          case 2:
            this.z = value;
            break;
          default:
            throw new IndexOutOfRangeException("Invalid Vector3 index!");
        }
      }
    }

    /// <summary>
    ///   <para>Set x, y and z components of an existing Vector3.</para>
    /// </summary>
    /// <param name="newX"></param>
    /// <param name="newY"></param>
    /// <param name="newZ"></param>
    public void Set(float newX, float newY, float newZ)
    {
      this.x = newX;
      this.y = newY;
      this.z = newZ;
    }

    /// <summary>
    ///   <para>Multiplies two vectors component-wise.</para>
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    public static Vector3 Scale(Vector3 a, Vector3 b)
    {
      return new Vector3(a.x * b.x, a.y * b.y, a.z * b.z);
    }

    /// <summary>
    ///   <para>Multiplies every component of this vector by the same component of scale.</para>
    /// </summary>
    /// <param name="scale"></param>
    public void Scale(Vector3 scale)
    {
      this.x *= scale.x;
      this.y *= scale.y;
      this.z *= scale.z;
    }

    /// <summary>
    ///   <para>Cross Product of two vectors.</para>
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    public static Vector3 Cross(Vector3 lhs, Vector3 rhs)
    {
      return new Vector3((float) ((double) lhs.y * (double) rhs.z - (double) lhs.z * (double) rhs.y), (float) ((double) lhs.z * (double) rhs.x - (double) lhs.x * (double) rhs.z), (float) ((double) lhs.x * (double) rhs.y - (double) lhs.y * (double) rhs.x));
    }

    public override int GetHashCode()
    {
      return this.x.GetHashCode() ^ this.y.GetHashCode() << 2 ^ this.z.GetHashCode() >> 2;
    }

    /// <summary>
    ///   <para>Returns true if the given vector is exactly equal to this vector.</para>
    /// </summary>
    /// <param name="other"></param>
    public override bool Equals(object other)
    {
      if (!(other is Vector3))
        return false;
      return this.Equals((Vector3) other);
    }

    public bool Equals(Vector3 other)
    {
      return this.x.Equals(other.x) && this.y.Equals(other.y) && this.z.Equals(other.z);
    }

    /// <summary>
    ///   <para>Reflects a vector off the plane defined by a normal.</para>
    /// </summary>
    /// <param name="inDirection"></param>
    /// <param name="inNormal"></param>
    public static Vector3 Reflect(Vector3 inDirection, Vector3 inNormal)
    {
      return -2f * Vector3.Dot(inNormal, inDirection) * inNormal + inDirection;
    }

    /// <summary>
    ///   <para>Makes this vector have a magnitude of 1.</para>
    /// </summary>
    /// <param name="value"></param>
    public static Vector3 Normalize(Vector3 value)
    {
      float num = Vector3.Magnitude(value);
      if ((double) num > 9.99999974737875E-06)
        return value / num;
      return Vector3.zero;
    }

    public void Normalize()
    {
      float num = Vector3.Magnitude(this);
      if ((double) num > 9.99999974737875E-06)
        this = this / num;
      else
        this = Vector3.zero;
    }

    /// <summary>
    ///   <para>Returns this vector with a magnitude of 1 (Read Only).</para>
    /// </summary>
    public Vector3 normalized
    {
      get
      {
        return Vector3.Normalize(this);
      }
    }

    /// <summary>
    ///   <para>Dot Product of two vectors.</para>
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    public static float Dot(Vector3 lhs, Vector3 rhs)
    {
      return (float) ((double) lhs.x * (double) rhs.x + (double) lhs.y * (double) rhs.y + (double) lhs.z * (double) rhs.z);
    }

    /// <summary>
    ///   <para>Projects a vector onto another vector.</para>
    /// </summary>
    /// <param name="vector"></param>
    /// <param name="onNormal"></param>
    public static Vector3 Project(Vector3 vector, Vector3 onNormal)
    {
      float num = Vector3.Dot(onNormal, onNormal);
      if ((double) num < (double) Mathf.Epsilon)
        return Vector3.zero;
      return onNormal * Vector3.Dot(vector, onNormal) / num;
    }

    /// <summary>
    ///   <para>Projects a vector onto a plane defined by a normal orthogonal to the plane.</para>
    /// </summary>
    /// <param name="vector"></param>
    /// <param name="planeNormal"></param>
    public static Vector3 ProjectOnPlane(Vector3 vector, Vector3 planeNormal)
    {
      return vector - Vector3.Project(vector, planeNormal);
    }

    /// <summary>
    ///   <para>Returns the angle in degrees between from and to.</para>
    /// </summary>
    /// <param name="from">The vector from which the angular difference is measured.</param>
    /// <param name="to">The vector to which the angular difference is measured.</param>
    /// <returns>
    ///   <para>The angle in degrees between the two vectors.</para>
    /// </returns>
    public static float Angle(Vector3 from, Vector3 to)
    {
      float num = Mathf.Sqrt(from.sqrMagnitude * to.sqrMagnitude);
      if ((double) num < 1.00000000362749E-15)
        return 0.0f;
      return Mathf.Acos(Mathf.Clamp(Vector3.Dot(from, to) / num, -1f, 1f)) * 57.29578f;
    }

    /// <summary>
    ///   <para>Returns the signed angle in degrees between from and to.</para>
    /// </summary>
    /// <param name="from">The vector from which the angular difference is measured.</param>
    /// <param name="to">The vector to which the angular difference is measured.</param>
    /// <param name="axis">A vector around which the other vectors are rotated.</param>
    public static float SignedAngle(Vector3 from, Vector3 to, Vector3 axis)
    {
      return Vector3.Angle(from, to) * Mathf.Sign(Vector3.Dot(axis, Vector3.Cross(from, to)));
    }

    /// <summary>
    ///   <para>Returns the distance between a and b.</para>
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    public static float Distance(Vector3 a, Vector3 b)
    {
      Vector3 vector3 = new Vector3(a.x - b.x, a.y - b.y, a.z - b.z);
      return Mathf.Sqrt((float) ((double) vector3.x * (double) vector3.x + (double) vector3.y * (double) vector3.y + (double) vector3.z * (double) vector3.z));
    }

    /// <summary>
    ///   <para>Returns a copy of vector with its magnitude clamped to maxLength.</para>
    /// </summary>
    /// <param name="vector"></param>
    /// <param name="maxLength"></param>
    public static Vector3 ClampMagnitude(Vector3 vector, float maxLength)
    {
      if ((double) vector.sqrMagnitude > (double) maxLength * (double) maxLength)
        return vector.normalized * maxLength;
      return vector;
    }

    public static float Magnitude(Vector3 vector)
    {
      return Mathf.Sqrt((float) ((double) vector.x * (double) vector.x + (double) vector.y * (double) vector.y + (double) vector.z * (double) vector.z));
    }

    /// <summary>
    ///   <para>Returns the length of this vector (Read Only).</para>
    /// </summary>
    public float magnitude
    {
      get
      {
        return Mathf.Sqrt((float) ((double) this.x * (double) this.x + (double) this.y * (double) this.y + (double) this.z * (double) this.z));
      }
    }

    public static float SqrMagnitude(Vector3 vector)
    {
      return (float) ((double) vector.x * (double) vector.x + (double) vector.y * (double) vector.y + (double) vector.z * (double) vector.z);
    }

    /// <summary>
    ///   <para>Returns the squared length of this vector (Read Only).</para>
    /// </summary>
    public float sqrMagnitude
    {
      get
      {
        return (float) ((double) this.x * (double) this.x + (double) this.y * (double) this.y + (double) this.z * (double) this.z);
      }
    }

    /// <summary>
    ///   <para>Returns a vector that is made from the smallest components of two vectors.</para>
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    public static Vector3 Min(Vector3 lhs, Vector3 rhs)
    {
      return new Vector3(Mathf.Min(lhs.x, rhs.x), Mathf.Min(lhs.y, rhs.y), Mathf.Min(lhs.z, rhs.z));
    }

    /// <summary>
    ///   <para>Returns a vector that is made from the largest components of two vectors.</para>
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    public static Vector3 Max(Vector3 lhs, Vector3 rhs)
    {
      return new Vector3(Mathf.Max(lhs.x, rhs.x), Mathf.Max(lhs.y, rhs.y), Mathf.Max(lhs.z, rhs.z));
    }

    /// <summary>
    ///   <para>Shorthand for writing Vector3(0, 0, 0).</para>
    /// </summary>
    public static Vector3 zero
    {
      get
      {
        return Vector3.zeroVector;
      }
    }

    /// <summary>
    ///   <para>Shorthand for writing Vector3(1, 1, 1).</para>
    /// </summary>
    public static Vector3 one
    {
      get
      {
        return Vector3.oneVector;
      }
    }

    /// <summary>
    ///   <para>Shorthand for writing Vector3(0, 0, 1).</para>
    /// </summary>
    public static Vector3 forward
    {
      get
      {
        return Vector3.forwardVector;
      }
    }

    /// <summary>
    ///   <para>Shorthand for writing Vector3(0, 0, -1).</para>
    /// </summary>
    public static Vector3 back
    {
      get
      {
        return Vector3.backVector;
      }
    }

    /// <summary>
    ///   <para>Shorthand for writing Vector3(0, 1, 0).</para>
    /// </summary>
    public static Vector3 up
    {
      get
      {
        return Vector3.upVector;
      }
    }

    /// <summary>
    ///   <para>Shorthand for writing Vector3(0, -1, 0).</para>
    /// </summary>
    public static Vector3 down
    {
      get
      {
        return Vector3.downVector;
      }
    }

    /// <summary>
    ///   <para>Shorthand for writing Vector3(-1, 0, 0).</para>
    /// </summary>
    public static Vector3 left
    {
      get
      {
        return Vector3.leftVector;
      }
    }

    /// <summary>
    ///   <para>Shorthand for writing Vector3(1, 0, 0).</para>
    /// </summary>
    public static Vector3 right
    {
      get
      {
        return Vector3.rightVector;
      }
    }

    /// <summary>
    ///   <para>Shorthand for writing Vector3(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity).</para>
    /// </summary>
    public static Vector3 positiveInfinity
    {
      get
      {
        return Vector3.positiveInfinityVector;
      }
    }

    /// <summary>
    ///   <para>Shorthand for writing Vector3(float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity).</para>
    /// </summary>
    public static Vector3 negativeInfinity
    {
      get
      {
        return Vector3.negativeInfinityVector;
      }
    }

    public static Vector3 operator +(Vector3 a, Vector3 b)
    {
      return new Vector3(a.x + b.x, a.y + b.y, a.z + b.z);
    }

    public static Vector3 operator -(Vector3 a, Vector3 b)
    {
      return new Vector3(a.x - b.x, a.y - b.y, a.z - b.z);
    }

    public static Vector3 operator -(Vector3 a)
    {
      return new Vector3(-a.x, -a.y, -a.z);
    }

    public static Vector3 operator *(Vector3 a, float d)
    {
      return new Vector3(a.x * d, a.y * d, a.z * d);
    }

    public static Vector3 operator *(float d, Vector3 a)
    {
      return new Vector3(a.x * d, a.y * d, a.z * d);
    }

    public static Vector3 operator /(Vector3 a, float d)
    {
      return new Vector3(a.x / d, a.y / d, a.z / d);
    }

    public static bool operator ==(Vector3 lhs, Vector3 rhs)
    {
      return (double) Vector3.SqrMagnitude(lhs - rhs) < 9.99999943962493E-11;
    }

    public static bool operator !=(Vector3 lhs, Vector3 rhs)
    {
      return !(lhs == rhs);
    }

    /// <summary>
    ///   <para>Returns a nicely formatted string for this vector.</para>
    /// </summary>
    /// <param name="format"></param>
    public override string ToString()
    {
      return UnityString.Format("({0:F1}, {1:F1}, {2:F1})", (object) this.x, (object) this.y, (object) this.z);
    }

    /// <summary>
    ///   <para>Returns a nicely formatted string for this vector.</para>
    /// </summary>
    /// <param name="format"></param>
    public string ToString(string format)
    {
      return UnityString.Format("({0}, {1}, {2})", (object) this.x.ToString(format), (object) this.y.ToString(format), (object) this.z.ToString(format));
    }

    [Obsolete("Use Vector3.forward instead.")]
    public static Vector3 fwd
    {
      get
      {
        return new Vector3(0.0f, 0.0f, 1f);
      }
    }

    [Obsolete("Use Vector3.Angle instead. AngleBetween uses radians instead of degrees and was deprecated for this reason")]
    public static float AngleBetween(Vector3 from, Vector3 to)
    {
      return Mathf.Acos(Mathf.Clamp(Vector3.Dot(from.normalized, to.normalized), -1f, 1f));
    }

    [Obsolete("Use Vector3.ProjectOnPlane instead.")]
    public static Vector3 Exclude(Vector3 excludeThis, Vector3 fromThat)
    {
      return Vector3.ProjectOnPlane(fromThat, excludeThis);
    }

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void Slerp_Injected(
      ref Vector3 a,
      ref Vector3 b,
      float t,
      out Vector3 ret);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void SlerpUnclamped_Injected(
      ref Vector3 a,
      ref Vector3 b,
      float t,
      out Vector3 ret);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void RotateTowards_Injected(
      ref Vector3 current,
      ref Vector3 target,
      float maxRadiansDelta,
      float maxMagnitudeDelta,
      out Vector3 ret);
  }
}
