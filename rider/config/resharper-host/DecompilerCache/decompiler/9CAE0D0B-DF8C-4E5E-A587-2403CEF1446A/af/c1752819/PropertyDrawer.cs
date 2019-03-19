﻿// Decompiled with JetBrains decompiler
// Type: UnityEditor.PropertyDrawer
// Assembly: UnityEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9CAE0D0B-DF8C-4E5E-A587-2403CEF1446A
// Assembly location: D:\Unity\Editor\Data\Managed\UnityEditor.dll

using UnityEngine;

namespace UnityEditor
{
  /// <summary>
  ///   <para>Base class to derive custom property drawers from. Use this to create custom drawers for your own Serializable classes or for script variables with custom PropertyAttributes.</para>
  /// </summary>
  public abstract class PropertyDrawer : GUIDrawer
  {
    internal PropertyAttribute m_Attribute;
    internal System.Reflection.FieldInfo m_FieldInfo;

    /// <summary>
    ///   <para>The PropertyAttribute for the property. Not applicable for custom class drawers. (Read Only)</para>
    /// </summary>
    public PropertyAttribute attribute
    {
      get
      {
        return this.m_Attribute;
      }
    }

    /// <summary>
    ///   <para>The reflection FieldInfo for the member this property represents. (Read Only)</para>
    /// </summary>
    public System.Reflection.FieldInfo fieldInfo
    {
      get
      {
        return this.m_FieldInfo;
      }
    }

    internal void OnGUISafe(Rect position, SerializedProperty property, GUIContent label)
    {
      ScriptAttributeUtility.s_DrawerStack.Push(this);
      this.OnGUI(position, property, label);
      ScriptAttributeUtility.s_DrawerStack.Pop();
    }

    /// <summary>
    ///   <para>Override this method to make your own GUI for the property.</para>
    /// </summary>
    /// <param name="position">Rectangle on the screen to use for the property GUI.</param>
    /// <param name="property">The SerializedProperty to make the custom GUI for.</param>
    /// <param name="label">The label of this property.</param>
    public virtual void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
      EditorGUI.DefaultPropertyField(position, property, label);
      EditorGUI.LabelField(position, label, EditorGUIUtility.TempContent("No GUI Implemented"));
    }

    internal float GetPropertyHeightSafe(SerializedProperty property, GUIContent label)
    {
      ScriptAttributeUtility.s_DrawerStack.Push(this);
      float propertyHeight = this.GetPropertyHeight(property, label);
      ScriptAttributeUtility.s_DrawerStack.Pop();
      return propertyHeight;
    }

    /// <summary>
    ///   <para>Override this method to specify how tall the GUI for this field is in pixels.</para>
    /// </summary>
    /// <param name="property">The SerializedProperty to make the custom GUI for.</param>
    /// <param name="label">The label of this property.</param>
    /// <returns>
    ///   <para>The height in pixels.</para>
    /// </returns>
    public virtual float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
      return 16f;
    }

    internal bool CanCacheInspectorGUISafe(SerializedProperty property)
    {
      ScriptAttributeUtility.s_DrawerStack.Push(this);
      bool flag = this.CanCacheInspectorGUI(property);
      ScriptAttributeUtility.s_DrawerStack.Pop();
      return flag;
    }

    /// <summary>
    ///   <para>Override this method to determine whether the inspector GUI for your property can be cached.</para>
    /// </summary>
    /// <param name="property">The SerializedProperty to make the custom GUI for.</param>
    /// <returns>
    ///   <para>Whether the drawer's UI can be cached.</para>
    /// </returns>
    public virtual bool CanCacheInspectorGUI(SerializedProperty property)
    {
      return true;
    }
  }
}
