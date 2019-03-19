﻿// Decompiled with JetBrains decompiler
// Type: UnityEngine.GameObject
// Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAF87D7C-AD7E-4FF1-9AEC-E2E17FC1223B
// Assembly location: D:\Unity\Editor\Data\Managed\UnityEngine\UnityEngine.CoreModule.dll

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security;
using UnityEngine.Internal;
using UnityEngine.SceneManagement;
using UnityEngine.Scripting;
using UnityEngineInternal;

namespace UnityEngine
{
  /// <summary>
  ///   <para>Base class for all entities in Unity scenes.</para>
  /// </summary>
  public sealed class GameObject : Object
  {
    /// <summary>
    ///   <para>Creates a new game object, named name.</para>
    /// </summary>
    /// <param name="name">The name that the GameObject is created with.</param>
    /// <param name="components">A list of Components to add to the GameObject on creation.</param>
    public GameObject(string name)
    {
      GameObject.Internal_CreateGameObject(this, name);
    }

    /// <summary>
    ///   <para>Creates a new game object, named name.</para>
    /// </summary>
    /// <param name="name">The name that the GameObject is created with.</param>
    /// <param name="components">A list of Components to add to the GameObject on creation.</param>
    public GameObject()
    {
      GameObject.Internal_CreateGameObject(this, (string) null);
    }

    /// <summary>
    ///   <para>Creates a new game object, named name.</para>
    /// </summary>
    /// <param name="name">The name that the GameObject is created with.</param>
    /// <param name="components">A list of Components to add to the GameObject on creation.</param>
    public GameObject(string name, params System.Type[] components)
    {
      GameObject.Internal_CreateGameObject(this, name);
      foreach (System.Type component in components)
        this.AddComponent(component);
    }

    /// <summary>
    ///   <para>Creates a game object with a primitive mesh renderer and appropriate collider.</para>
    /// </summary>
    /// <param name="type">The type of primitive object to create.</param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern GameObject CreatePrimitive(PrimitiveType type);

    /// <summary>
    ///   <para>Returns the component of Type type if the game object has one attached, null if it doesn't.</para>
    /// </summary>
    /// <param name="type">The type of Component to retrieve.</param>
    [TypeInferenceRule(TypeInferenceRules.TypeReferencedByFirstArgument)]
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern Component GetComponent(System.Type type);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal extern void GetComponentFastPath(System.Type type, IntPtr oneFurtherThanResultValue);

    [SecuritySafeCritical]
    public unsafe T GetComponent<T>()
    {
      CastHelper<T> castHelper = new CastHelper<T>();
      this.GetComponentFastPath(typeof (T), new IntPtr((void*) &castHelper.onePointerFurtherThanT));
      return castHelper.t;
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal extern Component GetComponentByName(string type);

    /// <summary>
    ///   <para>Returns the component with name type if the game object has one attached, null if it doesn't.</para>
    /// </summary>
    /// <param name="type">The type of Component to retrieve.</param>
    public Component GetComponent(string type)
    {
      return this.GetComponentByName(type);
    }

    /// <summary>
    ///   <para>Returns the component of Type type in the GameObject or any of its children using depth first search.</para>
    /// </summary>
    /// <param name="type">The type of Component to retrieve.</param>
    /// <param name="includeInactive"></param>
    /// <returns>
    ///   <para>A component of the matching type, if found.</para>
    /// </returns>
    [TypeInferenceRule(TypeInferenceRules.TypeReferencedByFirstArgument)]
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern Component GetComponentInChildren(System.Type type, bool includeInactive);

    /// <summary>
    ///   <para>Returns the component of Type type in the GameObject or any of its children using depth first search.</para>
    /// </summary>
    /// <param name="type">The type of Component to retrieve.</param>
    /// <param name="includeInactive"></param>
    /// <returns>
    ///   <para>A component of the matching type, if found.</para>
    /// </returns>
    [TypeInferenceRule(TypeInferenceRules.TypeReferencedByFirstArgument)]
    public Component GetComponentInChildren(System.Type type)
    {
      return this.GetComponentInChildren(type, false);
    }

    [ExcludeFromDocs]
    public T GetComponentInChildren<T>()
    {
      return this.GetComponentInChildren<T>(false);
    }

    public T GetComponentInChildren<T>([DefaultValue("false")] bool includeInactive)
    {
      return (T) this.GetComponentInChildren(typeof (T), includeInactive);
    }

    /// <summary>
    ///   <para>Returns the component of Type type in the GameObject or any of its parents.</para>
    /// </summary>
    /// <param name="type">Type of component to find.</param>
    [TypeInferenceRule(TypeInferenceRules.TypeReferencedByFirstArgument)]
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern Component GetComponentInParent(System.Type type);

    public T GetComponentInParent<T>()
    {
      return (T) this.GetComponentInParent(typeof (T));
    }

    /// <summary>
    ///   <para>Returns all components of Type type in the GameObject.</para>
    /// </summary>
    /// <param name="type">The type of Component to retrieve.</param>
    public Component[] GetComponents(System.Type type)
    {
      return (Component[]) this.GetComponentsInternal(type, false, false, true, false, (object) null);
    }

    public T[] GetComponents<T>()
    {
      return (T[]) this.GetComponentsInternal(typeof (T), true, false, true, false, (object) null);
    }

    public void GetComponents(System.Type type, List<Component> results)
    {
      this.GetComponentsInternal(type, false, false, true, false, (object) results);
    }

    public void GetComponents<T>(List<T> results)
    {
      this.GetComponentsInternal(typeof (T), false, false, true, false, (object) results);
    }

    /// <summary>
    ///   <para>Returns all components of Type type in the GameObject or any of its children.</para>
    /// </summary>
    /// <param name="type">The type of Component to retrieve.</param>
    /// <param name="includeInactive">Should Components on inactive GameObjects be included in the found set?</param>
    [ExcludeFromDocs]
    public Component[] GetComponentsInChildren(System.Type type)
    {
      bool includeInactive = false;
      return this.GetComponentsInChildren(type, includeInactive);
    }

    /// <summary>
    ///   <para>Returns all components of Type type in the GameObject or any of its children.</para>
    /// </summary>
    /// <param name="type">The type of Component to retrieve.</param>
    /// <param name="includeInactive">Should Components on inactive GameObjects be included in the found set?</param>
    public Component[] GetComponentsInChildren(System.Type type, [DefaultValue("false")] bool includeInactive)
    {
      return (Component[]) this.GetComponentsInternal(type, false, true, includeInactive, false, (object) null);
    }

    public T[] GetComponentsInChildren<T>(bool includeInactive)
    {
      return (T[]) this.GetComponentsInternal(typeof (T), true, true, includeInactive, false, (object) null);
    }

    public void GetComponentsInChildren<T>(bool includeInactive, List<T> results)
    {
      this.GetComponentsInternal(typeof (T), true, true, includeInactive, false, (object) results);
    }

    public T[] GetComponentsInChildren<T>()
    {
      return this.GetComponentsInChildren<T>(false);
    }

    public void GetComponentsInChildren<T>(List<T> results)
    {
      this.GetComponentsInChildren<T>(false, results);
    }

    [ExcludeFromDocs]
    public Component[] GetComponentsInParent(System.Type type)
    {
      bool includeInactive = false;
      return this.GetComponentsInParent(type, includeInactive);
    }

    /// <summary>
    ///   <para>Returns all components of Type type in the GameObject or any of its parents.</para>
    /// </summary>
    /// <param name="type">The type of Component to retrieve.</param>
    /// <param name="includeInactive">Should inactive Components be included in the found set?</param>
    public Component[] GetComponentsInParent(System.Type type, [DefaultValue("false")] bool includeInactive)
    {
      return (Component[]) this.GetComponentsInternal(type, false, true, includeInactive, true, (object) null);
    }

    public void GetComponentsInParent<T>(bool includeInactive, List<T> results)
    {
      this.GetComponentsInternal(typeof (T), true, true, includeInactive, true, (object) results);
    }

    public T[] GetComponentsInParent<T>(bool includeInactive)
    {
      return (T[]) this.GetComponentsInternal(typeof (T), true, true, includeInactive, true, (object) null);
    }

    public T[] GetComponentsInParent<T>()
    {
      return this.GetComponentsInParent<T>(false);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern Array GetComponentsInternal(System.Type type, bool useSearchTypeAsArrayReturnType, bool recursive, bool includeInactive, bool reverse, object resultList);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal extern Component AddComponentInternal(string className);

    /// <summary>
    ///   <para>The Transform attached to this GameObject.</para>
    /// </summary>
    public extern Transform transform { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>The layer the game object is in. A layer is in the range [0...31].</para>
    /// </summary>
    public extern int layer { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    [Obsolete("GameObject.active is obsolete. Use GameObject.SetActive(), GameObject.activeSelf or GameObject.activeInHierarchy.")]
    public extern bool active { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Activates/Deactivates the GameObject.</para>
    /// </summary>
    /// <param name="value">Activate or deactivation the  object.</param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern void SetActive(bool value);

    /// <summary>
    ///   <para>The local active state of this GameObject. (Read Only)</para>
    /// </summary>
    public extern bool activeSelf { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>Is the GameObject active in the scene?</para>
    /// </summary>
    public extern bool activeInHierarchy { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    [Obsolete("gameObject.SetActiveRecursively() is obsolete. Use GameObject.SetActive(), which is now inherited by children.")]
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern void SetActiveRecursively(bool state);

    /// <summary>
    ///   <para>Editor only API that specifies if a game object is static.</para>
    /// </summary>
    public extern bool isStatic { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    internal extern bool isStaticBatchable { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>The tag of this game object.</para>
    /// </summary>
    public extern string tag { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Is this game object tagged with tag ?</para>
    /// </summary>
    /// <param name="tag">The tag to compare.</param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern bool CompareTag(string tag);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern GameObject FindGameObjectWithTag(string tag);

    /// <summary>
    ///   <para>Returns one active GameObject tagged tag. Returns null if no GameObject was found.</para>
    /// </summary>
    /// <param name="tag">The tag to search for.</param>
    public static GameObject FindWithTag(string tag)
    {
      return GameObject.FindGameObjectWithTag(tag);
    }

    /// <summary>
    ///   <para>Returns a list of active GameObjects tagged tag. Returns empty array if no GameObject was found.</para>
    /// </summary>
    /// <param name="tag">The name of the tag to search GameObjects for.</param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern GameObject[] FindGameObjectsWithTag(string tag);

    /// <summary>
    ///   <para>Calls the method named methodName on every MonoBehaviour in this game object and on every ancestor of the behaviour.</para>
    /// </summary>
    /// <param name="methodName">The name of the method to call.</param>
    /// <param name="value">An optional parameter value to pass to the called method.</param>
    /// <param name="options">Should an error be raised if the method doesn't exist on the target object?</param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern void SendMessageUpwards(string methodName, [DefaultValue("null")] object value, [DefaultValue("SendMessageOptions.RequireReceiver")] SendMessageOptions options);

    /// <summary>
    ///   <para>Calls the method named methodName on every MonoBehaviour in this game object and on every ancestor of the behaviour.</para>
    /// </summary>
    /// <param name="methodName">The name of the method to call.</param>
    /// <param name="value">An optional parameter value to pass to the called method.</param>
    /// <param name="options">Should an error be raised if the method doesn't exist on the target object?</param>
    [ExcludeFromDocs]
    public void SendMessageUpwards(string methodName, object value)
    {
      SendMessageOptions options = SendMessageOptions.RequireReceiver;
      this.SendMessageUpwards(methodName, value, options);
    }

    /// <summary>
    ///   <para>Calls the method named methodName on every MonoBehaviour in this game object and on every ancestor of the behaviour.</para>
    /// </summary>
    /// <param name="methodName">The name of the method to call.</param>
    /// <param name="value">An optional parameter value to pass to the called method.</param>
    /// <param name="options">Should an error be raised if the method doesn't exist on the target object?</param>
    [ExcludeFromDocs]
    public void SendMessageUpwards(string methodName)
    {
      SendMessageOptions options = SendMessageOptions.RequireReceiver;
      object obj = (object) null;
      this.SendMessageUpwards(methodName, obj, options);
    }

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <param name="methodName"></param>
    /// <param name="options"></param>
    public void SendMessageUpwards(string methodName, SendMessageOptions options)
    {
      this.SendMessageUpwards(methodName, (object) null, options);
    }

    /// <summary>
    ///   <para>Calls the method named methodName on every MonoBehaviour in this game object.</para>
    /// </summary>
    /// <param name="methodName">The name of the method to call.</param>
    /// <param name="value">An optional parameter value to pass to the called method.</param>
    /// <param name="options">Should an error be raised if the method doesn't exist on the target object?</param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern void SendMessage(string methodName, [DefaultValue("null")] object value, [DefaultValue("SendMessageOptions.RequireReceiver")] SendMessageOptions options);

    /// <summary>
    ///   <para>Calls the method named methodName on every MonoBehaviour in this game object.</para>
    /// </summary>
    /// <param name="methodName">The name of the method to call.</param>
    /// <param name="value">An optional parameter value to pass to the called method.</param>
    /// <param name="options">Should an error be raised if the method doesn't exist on the target object?</param>
    [ExcludeFromDocs]
    public void SendMessage(string methodName, object value)
    {
      SendMessageOptions options = SendMessageOptions.RequireReceiver;
      this.SendMessage(methodName, value, options);
    }

    /// <summary>
    ///   <para>Calls the method named methodName on every MonoBehaviour in this game object.</para>
    /// </summary>
    /// <param name="methodName">The name of the method to call.</param>
    /// <param name="value">An optional parameter value to pass to the called method.</param>
    /// <param name="options">Should an error be raised if the method doesn't exist on the target object?</param>
    [ExcludeFromDocs]
    public void SendMessage(string methodName)
    {
      SendMessageOptions options = SendMessageOptions.RequireReceiver;
      object obj = (object) null;
      this.SendMessage(methodName, obj, options);
    }

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <param name="methodName"></param>
    /// <param name="options"></param>
    public void SendMessage(string methodName, SendMessageOptions options)
    {
      this.SendMessage(methodName, (object) null, options);
    }

    /// <summary>
    ///   <para>Calls the method named methodName on every MonoBehaviour in this game object or any of its children.</para>
    /// </summary>
    /// <param name="methodName"></param>
    /// <param name="parameter"></param>
    /// <param name="options"></param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern void BroadcastMessage(string methodName, [DefaultValue("null")] object parameter, [DefaultValue("SendMessageOptions.RequireReceiver")] SendMessageOptions options);

    /// <summary>
    ///   <para>Calls the method named methodName on every MonoBehaviour in this game object or any of its children.</para>
    /// </summary>
    /// <param name="methodName"></param>
    /// <param name="parameter"></param>
    /// <param name="options"></param>
    [ExcludeFromDocs]
    public void BroadcastMessage(string methodName, object parameter)
    {
      SendMessageOptions options = SendMessageOptions.RequireReceiver;
      this.BroadcastMessage(methodName, parameter, options);
    }

    /// <summary>
    ///   <para>Calls the method named methodName on every MonoBehaviour in this game object or any of its children.</para>
    /// </summary>
    /// <param name="methodName"></param>
    /// <param name="parameter"></param>
    /// <param name="options"></param>
    [ExcludeFromDocs]
    public void BroadcastMessage(string methodName)
    {
      SendMessageOptions options = SendMessageOptions.RequireReceiver;
      object parameter = (object) null;
      this.BroadcastMessage(methodName, parameter, options);
    }

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <param name="methodName"></param>
    /// <param name="options"></param>
    public void BroadcastMessage(string methodName, SendMessageOptions options)
    {
      this.BroadcastMessage(methodName, (object) null, options);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern Component Internal_AddComponentWithType(System.Type componentType);

    /// <summary>
    ///   <para>Adds a component class of type componentType to the game object. C# Users can use a generic version.</para>
    /// </summary>
    /// <param name="componentType"></param>
    [TypeInferenceRule(TypeInferenceRules.TypeReferencedByFirstArgument)]
    public Component AddComponent(System.Type componentType)
    {
      return this.Internal_AddComponentWithType(componentType);
    }

    public T AddComponent<T>() where T : Component
    {
      return this.AddComponent(typeof (T)) as T;
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void Internal_CreateGameObject([Writable] GameObject mono, string name);

    /// <summary>
    ///   <para>Finds a GameObject by name and returns it.</para>
    /// </summary>
    /// <param name="name"></param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern GameObject Find(string name);

    internal Bounds CalculateBounds()
    {
      Bounds bounds;
      GameObject.INTERNAL_CALL_CalculateBounds(this, out bounds);
      return bounds;
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void INTERNAL_CALL_CalculateBounds(GameObject self, out Bounds value);

    /// <summary>
    ///   <para>Scene that the GameObject is part of.</para>
    /// </summary>
    public Scene scene
    {
      get
      {
        Scene scene;
        this.INTERNAL_get_scene(out scene);
        return scene;
      }
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void INTERNAL_get_scene(out Scene value);

    public GameObject gameObject
    {
      get
      {
        return this;
      }
    }

    [Obsolete("GameObject.SampleAnimation(AnimationClip, float) has been deprecated. Use AnimationClip.SampleAnimation(GameObject, float) instead (UnityUpgradable).", true)]
    public void SampleAnimation(Object clip, float time)
    {
      throw new NotSupportedException("GameObject.SampleAnimation is deprecated");
    }

    /// <summary>
    ///   <para>Adds a component class named className to the game object.</para>
    /// </summary>
    /// <param name="className"></param>
    [Obsolete("GameObject.AddComponent with string argument has been deprecated. Use GameObject.AddComponent<T>() instead. (UnityUpgradable).", true)]
    public Component AddComponent(string className)
    {
      throw new NotSupportedException("AddComponent(string) is deprecated");
    }

    /// <summary>
    ///   <para>The Rigidbody attached to this GameObject (Read Only). (Null if there is none attached).</para>
    /// </summary>
    [Obsolete("Property rigidbody has been deprecated. Use GetComponent<Rigidbody>() instead. (UnityUpgradable)", true)]
    public Component rigidbody
    {
      get
      {
        throw new NotSupportedException("rigidbody property has been deprecated");
      }
    }

    /// <summary>
    ///   <para>The Rigidbody2D component attached to this GameObject. (Read Only)</para>
    /// </summary>
    [Obsolete("Property rigidbody2D has been deprecated. Use GetComponent<Rigidbody2D>() instead. (UnityUpgradable)", true)]
    public Component rigidbody2D
    {
      get
      {
        throw new NotSupportedException("rigidbody2D property has been deprecated");
      }
    }

    /// <summary>
    ///   <para>The Camera attached to this GameObject (Read Only). (Null if there is none attached).</para>
    /// </summary>
    [Obsolete("Property camera has been deprecated. Use GetComponent<Camera>() instead. (UnityUpgradable)", true)]
    public Component camera
    {
      get
      {
        throw new NotSupportedException("camera property has been deprecated");
      }
    }

    /// <summary>
    ///   <para>The Light attached to this GameObject (Read Only). (Null if there is none attached).</para>
    /// </summary>
    [Obsolete("Property light has been deprecated. Use GetComponent<Light>() instead. (UnityUpgradable)", true)]
    public Component light
    {
      get
      {
        throw new NotSupportedException("light property has been deprecated");
      }
    }

    /// <summary>
    ///   <para>The Animation attached to this GameObject (Read Only). (Null if there is none attached).</para>
    /// </summary>
    [Obsolete("Property animation has been deprecated. Use GetComponent<Animation>() instead. (UnityUpgradable)", true)]
    public Component animation
    {
      get
      {
        throw new NotSupportedException("animation property has been deprecated");
      }
    }

    /// <summary>
    ///   <para>The ConstantForce attached to this GameObject (Read Only). (Null if there is none attached).</para>
    /// </summary>
    [Obsolete("Property constantForce has been deprecated. Use GetComponent<ConstantForce>() instead. (UnityUpgradable)", true)]
    public Component constantForce
    {
      get
      {
        throw new NotSupportedException("constantForce property has been deprecated");
      }
    }

    /// <summary>
    ///   <para>The Renderer attached to this GameObject (Read Only). (Null if there is none attached).</para>
    /// </summary>
    [Obsolete("Property renderer has been deprecated. Use GetComponent<Renderer>() instead. (UnityUpgradable)", true)]
    public Component renderer
    {
      get
      {
        throw new NotSupportedException("renderer property has been deprecated");
      }
    }

    /// <summary>
    ///   <para>The AudioSource attached to this GameObject (Read Only). (Null if there is none attached).</para>
    /// </summary>
    [Obsolete("Property audio has been deprecated. Use GetComponent<AudioSource>() instead. (UnityUpgradable)", true)]
    public Component audio
    {
      get
      {
        throw new NotSupportedException("audio property has been deprecated");
      }
    }

    /// <summary>
    ///   <para>The GUIText attached to this GameObject (Read Only). (Null if there is none attached).</para>
    /// </summary>
    [Obsolete("Property guiText has been deprecated. Use GetComponent<GUIText>() instead. (UnityUpgradable)", true)]
    public Component guiText
    {
      get
      {
        throw new NotSupportedException("guiText property has been deprecated");
      }
    }

    /// <summary>
    ///   <para>The NetworkView attached to this GameObject (Read Only). (Null if there is none attached).</para>
    /// </summary>
    [Obsolete("Property networkView has been deprecated. Use GetComponent<NetworkView>() instead. (UnityUpgradable)", true)]
    public Component networkView
    {
      get
      {
        throw new NotSupportedException("networkView property has been deprecated");
      }
    }

    [Obsolete("Property guiElement has been deprecated. Use GetComponent<GUIElement>() instead. (UnityUpgradable)", true)]
    public Component guiElement
    {
      get
      {
        throw new NotSupportedException("guiElement property has been deprecated");
      }
    }

    /// <summary>
    ///   <para>The GUITexture attached to this GameObject (Read Only). (Null if there is none attached).</para>
    /// </summary>
    [Obsolete("Property guiTexture has been deprecated. Use GetComponent<GUITexture>() instead. (UnityUpgradable)", true)]
    public Component guiTexture
    {
      get
      {
        throw new NotSupportedException("guiTexture property has been deprecated");
      }
    }

    /// <summary>
    ///   <para>The Collider attached to this GameObject (Read Only). (Null if there is none attached).</para>
    /// </summary>
    [Obsolete("Property collider has been deprecated. Use GetComponent<Collider>() instead. (UnityUpgradable)", true)]
    public Component collider
    {
      get
      {
        throw new NotSupportedException("collider property has been deprecated");
      }
    }

    /// <summary>
    ///   <para>The Collider2D component attached to this object.</para>
    /// </summary>
    [Obsolete("Property collider2D has been deprecated. Use GetComponent<Collider2D>() instead. (UnityUpgradable)", true)]
    public Component collider2D
    {
      get
      {
        throw new NotSupportedException("collider2D property has been deprecated");
      }
    }

    /// <summary>
    ///   <para>The HingeJoint attached to this GameObject (Read Only). (Null if there is none attached).</para>
    /// </summary>
    [Obsolete("Property hingeJoint has been deprecated. Use GetComponent<HingeJoint>() instead. (UnityUpgradable)", true)]
    public Component hingeJoint
    {
      get
      {
        throw new NotSupportedException("hingeJoint property has been deprecated");
      }
    }

    /// <summary>
    ///   <para>The ParticleEmitter attached to this GameObject (Read Only). (Null if there is none attached).</para>
    /// </summary>
    [Obsolete("Property particleEmitter has been deprecated. Use GetComponent<ParticleEmitter>() instead. (UnityUpgradable)", true)]
    public Component particleEmitter
    {
      get
      {
        throw new NotSupportedException("particleEmitter property has been deprecated");
      }
    }

    /// <summary>
    ///   <para>The ParticleSystem attached to this GameObject (Read Only). (Null if there is none attached).</para>
    /// </summary>
    [Obsolete("Property particleSystem has been deprecated. Use GetComponent<ParticleSystem>() instead. (UnityUpgradable)", true)]
    public Component particleSystem
    {
      get
      {
        throw new NotSupportedException("particleSystem property has been deprecated");
      }
    }

    [Obsolete("gameObject.PlayAnimation is not supported anymore. Use animation.Play()", true)]
    public void PlayAnimation(Object animation)
    {
      throw new NotSupportedException("gameObject.PlayAnimation is not supported anymore. Use animation.Play();");
    }

    [Obsolete("gameObject.StopAnimation is not supported anymore. Use animation.Stop()", true)]
    public void StopAnimation()
    {
      throw new NotSupportedException("gameObject.StopAnimation(); is not supported anymore. Use animation.Stop();");
    }
  }
}
