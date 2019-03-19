﻿// Decompiled with JetBrains decompiler
// Type: UnityEditor.Editor
// Assembly: UnityEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9CAE0D0B-DF8C-4E5E-A587-2403CEF1446A
// Assembly location: D:\Unity\Editor\Data\Managed\UnityEditor.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEditor.Experimental.AssetImporters;
using UnityEngine;
using UnityEngine.Internal;
using UnityEngine.Scripting;

namespace UnityEditor
{
  /// <summary>
  ///   <para>Base class to derive custom Editors from. Use this to create your own custom inspectors and editors for your objects.</para>
  /// </summary>
  [RequiredByNativeCode]
  [StructLayout(LayoutKind.Sequential)]
  public class Editor : ScriptableObject, IPreviewable, IToolModeOwner
  {
    internal static bool m_AllowMultiObjectAccess = true;
    internal static Editor.OnEditorGUIDelegate OnPostIconGUI = (Editor.OnEditorGUIDelegate) null;
    private int m_ReferenceTargetIndex = 0;
    private PropertyHandlerCache m_PropertyHandlerCache = new PropertyHandlerCache();
    internal SerializedObject m_SerializedObject = (SerializedObject) null;
    internal InspectorMode m_InspectorMode = InspectorMode.Normal;
    internal bool hideInspector = false;
    private UnityEngine.Object[] m_Targets;
    private UnityEngine.Object m_Context;
    private int m_IsDirty;
    private IPreviewable m_DummyPreview;
    private OptimizedGUIBlock m_OptimizedBlock;
    internal const float kLineHeight = 16f;
    private static Editor.Styles s_Styles;
    private const float kImageSectionWidth = 44f;

    internal bool canEditMultipleObjects
    {
      get
      {
        return this.GetType().GetCustomAttributes(typeof (CanEditMultipleObjects), false).Length > 0;
      }
    }

    /// <summary>
    ///   <para>Make a custom editor for targetObject or targetObjects with a context object.</para>
    /// </summary>
    /// <param name="targetObjects"></param>
    /// <param name="context"></param>
    /// <param name="editorType"></param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern Editor CreateEditorWithContext(UnityEngine.Object[] targetObjects, UnityEngine.Object context, [DefaultValue("null")] System.Type editorType);

    [ExcludeFromDocs]
    public static Editor CreateEditorWithContext(UnityEngine.Object[] targetObjects, UnityEngine.Object context)
    {
      System.Type editorType = (System.Type) null;
      return Editor.CreateEditorWithContext(targetObjects, context, editorType);
    }

    public static void CreateCachedEditorWithContext(UnityEngine.Object targetObject, UnityEngine.Object context, System.Type editorType, ref Editor previousEditor)
    {
      Editor.CreateCachedEditorWithContext(new UnityEngine.Object[1]
      {
        targetObject
      }, context, editorType, ref previousEditor);
    }

    public static void CreateCachedEditorWithContext(UnityEngine.Object[] targetObjects, UnityEngine.Object context, System.Type editorType, ref Editor previousEditor)
    {
      if ((UnityEngine.Object) previousEditor != (UnityEngine.Object) null && ArrayUtility.ArrayEquals<UnityEngine.Object>(previousEditor.m_Targets, targetObjects) && previousEditor.m_Context == context)
        return;
      if ((UnityEngine.Object) previousEditor != (UnityEngine.Object) null)
        UnityEngine.Object.DestroyImmediate((UnityEngine.Object) previousEditor);
      previousEditor = Editor.CreateEditorWithContext(targetObjects, context, editorType);
    }

    public static void CreateCachedEditor(UnityEngine.Object targetObject, System.Type editorType, ref Editor previousEditor)
    {
      Editor.CreateCachedEditorWithContext(new UnityEngine.Object[1]
      {
        targetObject
      }, (UnityEngine.Object) null, editorType, ref previousEditor);
    }

    public static void CreateCachedEditor(UnityEngine.Object[] targetObjects, System.Type editorType, ref Editor previousEditor)
    {
      Editor.CreateCachedEditorWithContext(targetObjects, (UnityEngine.Object) null, editorType, ref previousEditor);
    }

    /// <summary>
    ///   <para>Make a custom editor for targetObject or targetObjects.</para>
    /// </summary>
    /// <param name="objects">All objects must be of same exact type.</param>
    /// <param name="targetObject"></param>
    /// <param name="editorType"></param>
    /// <param name="targetObjects"></param>
    [ExcludeFromDocs]
    public static Editor CreateEditor(UnityEngine.Object targetObject)
    {
      System.Type editorType = (System.Type) null;
      return Editor.CreateEditor(targetObject, editorType);
    }

    /// <summary>
    ///   <para>Make a custom editor for targetObject or targetObjects.</para>
    /// </summary>
    /// <param name="objects">All objects must be of same exact type.</param>
    /// <param name="targetObject"></param>
    /// <param name="editorType"></param>
    /// <param name="targetObjects"></param>
    public static Editor CreateEditor(UnityEngine.Object targetObject, [DefaultValue("null")] System.Type editorType)
    {
      return Editor.CreateEditorWithContext(new UnityEngine.Object[1]
      {
        targetObject
      }, (UnityEngine.Object) null, editorType);
    }

    /// <summary>
    ///   <para>Make a custom editor for targetObject or targetObjects.</para>
    /// </summary>
    /// <param name="objects">All objects must be of same exact type.</param>
    /// <param name="targetObject"></param>
    /// <param name="editorType"></param>
    /// <param name="targetObjects"></param>
    [ExcludeFromDocs]
    public static Editor CreateEditor(UnityEngine.Object[] targetObjects)
    {
      System.Type editorType = (System.Type) null;
      return Editor.CreateEditor(targetObjects, editorType);
    }

    /// <summary>
    ///   <para>Make a custom editor for targetObject or targetObjects.</para>
    /// </summary>
    /// <param name="objects">All objects must be of same exact type.</param>
    /// <param name="targetObject"></param>
    /// <param name="editorType"></param>
    /// <param name="targetObjects"></param>
    public static Editor CreateEditor(UnityEngine.Object[] targetObjects, [DefaultValue("null")] System.Type editorType)
    {
      return Editor.CreateEditorWithContext(targetObjects, (UnityEngine.Object) null, editorType);
    }

    /// <summary>
    ///   <para>The object being inspected.</para>
    /// </summary>
    public UnityEngine.Object target
    {
      get
      {
        return this.m_Targets[this.referenceTargetIndex];
      }
      set
      {
        throw new InvalidOperationException("You can't set the target on an editor.");
      }
    }

    /// <summary>
    ///   <para>An array of all the object being inspected.</para>
    /// </summary>
    public UnityEngine.Object[] targets
    {
      get
      {
        if (!Editor.m_AllowMultiObjectAccess)
          Debug.LogError((object) "The targets array should not be used inside OnSceneGUI or OnPreviewGUI. Use the single target property instead.");
        return this.m_Targets;
      }
    }

    internal virtual int referenceTargetIndex
    {
      get
      {
        return Mathf.Clamp(this.m_ReferenceTargetIndex, 0, this.m_Targets.Length - 1);
      }
      set
      {
        this.m_ReferenceTargetIndex = (Math.Abs(value * this.m_Targets.Length) + value) % this.m_Targets.Length;
      }
    }

    internal virtual string targetTitle
    {
      get
      {
        if (this.m_Targets.Length == 1 || !Editor.m_AllowMultiObjectAccess)
          return this.target.name;
        return this.m_Targets.Length.ToString() + " " + ObjectNames.NicifyVariableName(ObjectNames.GetTypeName(this.target)) + "s";
      }
    }

    /// <summary>
    ///   <para>A SerializedObject representing the object or objects being inspected.</para>
    /// </summary>
    public SerializedObject serializedObject
    {
      get
      {
        if (!Editor.m_AllowMultiObjectAccess)
          Debug.LogError((object) "The serializedObject should not be used inside OnSceneGUI or OnPreviewGUI. Use the target property directly instead.");
        return this.GetSerializedObjectInternal();
      }
    }

    internal virtual SerializedObject GetSerializedObjectInternal()
    {
      if (this.m_SerializedObject == null)
        this.m_SerializedObject = new SerializedObject(this.targets, this.m_Context);
      return this.m_SerializedObject;
    }

    private void CleanupPropertyEditor()
    {
      if (this.m_OptimizedBlock != null)
      {
        this.m_OptimizedBlock.Dispose();
        this.m_OptimizedBlock = (OptimizedGUIBlock) null;
      }
      if (this.m_SerializedObject == null)
        return;
      this.m_SerializedObject.Dispose();
      this.m_SerializedObject = (SerializedObject) null;
    }

    private void OnDisableINTERNAL()
    {
      this.CleanupPropertyEditor();
    }

    internal virtual void OnForceReloadInspector()
    {
      if (this.m_SerializedObject == null)
        return;
      this.m_SerializedObject.SetIsDifferentCacheDirty();
    }

    internal bool GetOptimizedGUIBlockImplementation(bool isDirty, bool isVisible, out OptimizedGUIBlock block, out float height)
    {
      if (isDirty && this.m_OptimizedBlock != null)
      {
        this.m_OptimizedBlock.Dispose();
        this.m_OptimizedBlock = (OptimizedGUIBlock) null;
      }
      if (!isVisible)
      {
        if (this.m_OptimizedBlock == null)
          this.m_OptimizedBlock = new OptimizedGUIBlock();
        block = this.m_OptimizedBlock;
        height = 0.0f;
        return true;
      }
      if (this.m_SerializedObject == null)
        this.m_SerializedObject = new SerializedObject(this.targets, this.m_Context);
      else
        this.m_SerializedObject.Update();
      this.m_SerializedObject.inspectorMode = this.m_InspectorMode;
      SerializedProperty iterator = this.m_SerializedObject.GetIterator();
      height = 2f;
      for (bool enterChildren = true; iterator.NextVisible(enterChildren); enterChildren = false)
      {
        if (!EditorGUI.CanCacheInspectorGUI(iterator))
        {
          if (this.m_OptimizedBlock != null)
            this.m_OptimizedBlock.Dispose();
          block = this.m_OptimizedBlock = (OptimizedGUIBlock) null;
          return false;
        }
        height += EditorGUI.GetPropertyHeight(iterator, (GUIContent) null, true) + 2f;
      }
      if ((double) height == 2.0)
        height = 0.0f;
      if (this.m_OptimizedBlock == null)
        this.m_OptimizedBlock = new OptimizedGUIBlock();
      block = this.m_OptimizedBlock;
      return true;
    }

    internal bool OptimizedInspectorGUIImplementation(Rect contentRect)
    {
      SerializedProperty iterator = this.m_SerializedObject.GetIterator();
      bool enterChildren = true;
      bool enabled = GUI.enabled;
      contentRect.xMin += 14f;
      contentRect.xMax -= 4f;
      contentRect.y += 2f;
      while (iterator.NextVisible(enterChildren))
      {
        contentRect.height = EditorGUI.GetPropertyHeight(iterator, (GUIContent) null, false);
        EditorGUI.indentLevel = iterator.depth;
        using (new EditorGUI.DisabledScope(this.m_InspectorMode == InspectorMode.Normal && "m_Script" == iterator.propertyPath))
          enterChildren = EditorGUI.PropertyField(contentRect, iterator);
        contentRect.y += contentRect.height + 2f;
      }
      GUI.enabled = enabled;
      return this.m_SerializedObject.ApplyModifiedProperties();
    }

    protected internal static void DrawPropertiesExcluding(SerializedObject obj, params string[] propertyToExclude)
    {
      SerializedProperty iterator = obj.GetIterator();
      bool enterChildren = true;
      while (iterator.NextVisible(enterChildren))
      {
        enterChildren = false;
        if (!((IEnumerable<string>) propertyToExclude).Contains<string>(iterator.name))
          EditorGUILayout.PropertyField(iterator, true, new GUILayoutOption[0]);
      }
    }

    /// <summary>
    ///   <para>Draw the built-in inspector.</para>
    /// </summary>
    public bool DrawDefaultInspector()
    {
      return this.DoDrawDefaultInspector();
    }

    /// <summary>
    ///   <para>Implement this function to make a custom inspector.</para>
    /// </summary>
    public virtual void OnInspectorGUI()
    {
      this.DrawDefaultInspector();
    }

    /// <summary>
    ///   <para>Does this edit require to be repainted constantly in its current state?</para>
    /// </summary>
    public virtual bool RequiresConstantRepaint()
    {
      return false;
    }

    internal void InternalSetTargets(UnityEngine.Object[] t)
    {
      this.m_Targets = t;
    }

    internal void InternalSetHidden(bool hidden)
    {
      this.hideInspector = hidden;
    }

    internal void InternalSetContextObject(UnityEngine.Object context)
    {
      this.m_Context = context;
    }

    internal virtual bool GetOptimizedGUIBlock(bool isDirty, bool isVisible, out OptimizedGUIBlock block, out float height)
    {
      block = (OptimizedGUIBlock) null;
      height = -1f;
      return false;
    }

    internal virtual bool OnOptimizedInspectorGUI(Rect contentRect)
    {
      Debug.LogError((object) "Not supported");
      return false;
    }

    internal bool isInspectorDirty
    {
      get
      {
        return this.m_IsDirty != 0;
      }
      set
      {
        this.m_IsDirty = !value ? 0 : 1;
      }
    }

    /// <summary>
    ///   <para>Repaint any inspectors that shows this editor.</para>
    /// </summary>
    public void Repaint()
    {
      InspectorWindow.RepaintAllInspectors();
    }

    /// <summary>
    ///   <para>Override this method in subclasses if you implement OnPreviewGUI.</para>
    /// </summary>
    /// <returns>
    ///   <para>True if this component can be Previewed in its current state.</para>
    /// </returns>
    public virtual bool HasPreviewGUI()
    {
      return this.preview.HasPreviewGUI();
    }

    /// <summary>
    ///   <para>Override this method if you want to change the label of the Preview area.</para>
    /// </summary>
    public virtual GUIContent GetPreviewTitle()
    {
      return this.preview.GetPreviewTitle();
    }

    /// <summary>
    ///   <para>Override this method if you want to render a static preview that shows.</para>
    /// </summary>
    /// <param name="assetPath"></param>
    /// <param name="subAssets"></param>
    /// <param name="width"></param>
    /// <param name="height"></param>
    public virtual Texture2D RenderStaticPreview(string assetPath, UnityEngine.Object[] subAssets, int width, int height)
    {
      return (Texture2D) null;
    }

    /// <summary>
    ///   <para>Implement to create your own custom preview for the preview area of the inspector, primary editor headers and the object selector.</para>
    /// </summary>
    /// <param name="r">Rectangle in which to draw the preview.</param>
    /// <param name="background">Background image.</param>
    public virtual void OnPreviewGUI(Rect r, GUIStyle background)
    {
      this.preview.OnPreviewGUI(r, background);
    }

    /// <summary>
    ///   <para>Implement to create your own interactive custom preview. Interactive custom previews are used in the preview area of the inspector and the object selector.</para>
    /// </summary>
    /// <param name="r">Rectangle in which to draw the preview.</param>
    /// <param name="background">Background image.</param>
    public virtual void OnInteractivePreviewGUI(Rect r, GUIStyle background)
    {
      this.OnPreviewGUI(r, background);
    }

    /// <summary>
    ///   <para>Override this method if you want to show custom controls in the preview header.</para>
    /// </summary>
    public virtual void OnPreviewSettings()
    {
      this.preview.OnPreviewSettings();
    }

    /// <summary>
    ///   <para>Implement this method to show asset information on top of the asset preview.</para>
    /// </summary>
    public virtual string GetInfoString()
    {
      return this.preview.GetInfoString();
    }

    internal virtual void OnAssetStoreInspectorGUI()
    {
    }

    public virtual void ReloadPreviewInstances()
    {
      this.preview.ReloadPreviewInstances();
    }

    internal virtual IPreviewable preview
    {
      get
      {
        if (this.m_DummyPreview == null)
        {
          this.m_DummyPreview = (IPreviewable) new ObjectPreview();
          this.m_DummyPreview.Initialize(this.targets);
        }
        return this.m_DummyPreview;
      }
    }

    internal PropertyHandlerCache propertyHandlerCache
    {
      get
      {
        return this.m_PropertyHandlerCache;
      }
    }

    bool IToolModeOwner.areToolModesAvailable
    {
      get
      {
        return !EditorUtility.IsPersistent(this.target);
      }
    }

    Bounds IToolModeOwner.GetWorldBoundsOfTargets()
    {
      Bounds bounds = new Bounds();
      bool flag = false;
      foreach (UnityEngine.Object target in this.targets)
      {
        if (!(target == (UnityEngine.Object) null))
        {
          Bounds worldBoundsOfTarget = this.GetWorldBoundsOfTarget(target);
          if (!flag)
            bounds = worldBoundsOfTarget;
          bounds.Encapsulate(worldBoundsOfTarget);
          flag = true;
        }
      }
      return bounds;
    }

    internal virtual Bounds GetWorldBoundsOfTarget(UnityEngine.Object targetObject)
    {
      return !(targetObject is Component) ? new Bounds() : ((Component) targetObject).gameObject.CalculateBounds();
    }

    bool IToolModeOwner.ModeSurvivesSelectionChange(int toolMode)
    {
      return false;
    }

    internal static bool DoDrawDefaultInspector(SerializedObject obj)
    {
      EditorGUI.BeginChangeCheck();
      obj.Update();
      SerializedProperty iterator = obj.GetIterator();
      for (bool enterChildren = true; iterator.NextVisible(enterChildren); enterChildren = false)
      {
        using (new EditorGUI.DisabledScope("m_Script" == iterator.propertyPath))
          EditorGUILayout.PropertyField(iterator, true, new GUILayoutOption[0]);
      }
      obj.ApplyModifiedProperties();
      return EditorGUI.EndChangeCheck();
    }

    internal bool DoDrawDefaultInspector()
    {
      return Editor.DoDrawDefaultInspector(this.serializedObject);
    }

    /// <summary>
    ///   <para>Call this function to draw the header of the editor.</para>
    /// </summary>
    public void DrawHeader()
    {
      if (EditorGUIUtility.hierarchyMode)
        this.DrawHeaderFromInsideHierarchy();
      else
        this.OnHeaderGUI();
    }

    protected virtual void OnHeaderGUI()
    {
      Editor.DrawHeaderGUI(this, this.targetTitle);
    }

    internal virtual void OnHeaderControlsGUI()
    {
      GUILayoutUtility.GetRect(10f, 10f, 16f, 16f, EditorStyles.layerMaskField);
      GUILayout.FlexibleSpace();
      bool flag = true;
      if (!(this is AssetImporterEditor))
      {
        string assetPath = AssetDatabase.GetAssetPath(this.targets[0]);
        if (!AssetDatabase.IsMainAsset(this.targets[0]))
          flag = false;
        AssetImporter atPath = AssetImporter.GetAtPath(assetPath);
        if ((bool) ((UnityEngine.Object) atPath) && atPath.GetType() != typeof (AssetImporter))
          flag = false;
      }
      if (!flag || this.ShouldHideOpenButton() || !GUILayout.Button("Open", EditorStyles.miniButton, new GUILayoutOption[0]))
        return;
      if (this is AssetImporterEditor)
        AssetDatabase.OpenAsset((this as AssetImporterEditor).assetEditor.targets);
      else
        AssetDatabase.OpenAsset(this.targets);
      GUIUtility.ExitGUI();
    }

    /// <summary>
    ///   <para>Returns the visibility setting of the "open" button in the Inspector.</para>
    /// </summary>
    /// <returns>
    ///   <para>Return true if the button should be hidden.</para>
    /// </returns>
    protected virtual bool ShouldHideOpenButton()
    {
      return false;
    }

    internal virtual void OnHeaderIconGUI(Rect iconRect)
    {
      if (Editor.s_Styles == null)
        Editor.s_Styles = new Editor.Styles();
      Texture2D texture2D = (Texture2D) null;
      if (!this.HasPreviewGUI())
      {
        bool flag = AssetPreview.IsLoadingAssetPreview(this.target.GetInstanceID());
        texture2D = AssetPreview.GetAssetPreview(this.target);
        if (!(bool) ((UnityEngine.Object) texture2D))
        {
          if (flag)
            this.Repaint();
          texture2D = AssetPreview.GetMiniThumbnail(this.target);
        }
      }
      if (this.HasPreviewGUI())
      {
        this.OnPreviewGUI(iconRect, Editor.s_Styles.inspectorBigInner);
      }
      else
      {
        if (!(bool) ((UnityEngine.Object) texture2D))
          return;
        GUI.Label(iconRect, (Texture) texture2D, Editor.s_Styles.centerStyle);
      }
    }

    internal virtual void OnHeaderTitleGUI(Rect titleRect, string header)
    {
      titleRect.yMin -= 2f;
      titleRect.yMax += 2f;
      GUI.Label(titleRect, header, EditorStyles.largeLabel);
    }

    internal virtual void DrawHeaderHelpAndSettingsGUI(Rect r)
    {
      Vector2 vector2 = EditorStyles.iconButton.CalcSize(EditorGUI.GUIContents.titleSettingsIcon);
      float x = vector2.x;
      Rect position = new Rect(r.xMax - x, r.y + 5f, vector2.x, vector2.y);
      if (EditorGUI.DropdownButton(position, EditorGUI.GUIContents.titleSettingsIcon, FocusType.Passive, EditorStyles.iconButton))
        EditorUtility.DisplayObjectContextMenu(position, this.targets, 0);
      float num = x + vector2.x;
      EditorGUIUtility.DrawEditorHeaderItems(new Rect(r.xMax - num, r.y + 5f, vector2.x, vector2.y), this.targets);
    }

    private void DrawHeaderFromInsideHierarchy()
    {
      GUIStyle style = GUILayoutUtility.topLevel.style;
      EditorGUILayout.EndVertical();
      this.OnHeaderGUI();
      EditorGUILayout.BeginVertical(style, new GUILayoutOption[0]);
    }

    internal static Rect DrawHeaderGUI(Editor editor, string header)
    {
      return Editor.DrawHeaderGUI(editor, header, 0.0f);
    }

    internal static Rect DrawHeaderGUI(Editor editor, string header, float leftMargin)
    {
      if (Editor.s_Styles == null)
        Editor.s_Styles = new Editor.Styles();
      GUILayout.BeginHorizontal(Editor.s_Styles.inspectorBig, new GUILayoutOption[0]);
      GUILayout.Space(38f);
      GUILayout.BeginVertical();
      GUILayout.Space(19f);
      GUILayout.BeginHorizontal();
      if ((double) leftMargin > 0.0)
        GUILayout.Space(leftMargin);
      if ((bool) ((UnityEngine.Object) editor))
        editor.OnHeaderControlsGUI();
      else
        EditorGUILayout.GetControlRect();
      GUILayout.EndHorizontal();
      GUILayout.EndVertical();
      GUILayout.EndHorizontal();
      Rect lastRect = GUILayoutUtility.GetLastRect();
      Rect r = new Rect(lastRect.x + leftMargin, lastRect.y, lastRect.width - leftMargin, lastRect.height);
      Rect rect1 = new Rect(r.x + 6f, r.y + 6f, 32f, 32f);
      if ((bool) ((UnityEngine.Object) editor))
        editor.OnHeaderIconGUI(rect1);
      else
        GUI.Label(rect1, (Texture) AssetPreview.GetMiniTypeThumbnail(typeof (UnityEngine.Object)), Editor.s_Styles.centerStyle);
      if ((bool) ((UnityEngine.Object) editor))
        editor.DrawPostIconContent(rect1);
      Rect rect2 = new Rect(r.x + 44f, r.y + 6f, (float) ((double) r.width - 44.0 - 38.0 - 4.0), 16f);
      if ((bool) ((UnityEngine.Object) editor))
        editor.OnHeaderTitleGUI(rect2, header);
      else
        GUI.Label(rect2, header, EditorStyles.largeLabel);
      if ((bool) ((UnityEngine.Object) editor))
        editor.DrawHeaderHelpAndSettingsGUI(r);
      Event current = Event.current;
      if ((UnityEngine.Object) editor != (UnityEngine.Object) null && current.type == EventType.MouseDown && (current.button == 1 && r.Contains(current.mousePosition)))
      {
        EditorUtility.DisplayObjectContextMenu(new Rect(current.mousePosition.x, current.mousePosition.y, 0.0f, 0.0f), editor.targets, 0);
        current.Use();
      }
      return lastRect;
    }

    internal void DrawPostIconContent(Rect iconRect)
    {
      if (Editor.OnPostIconGUI == null)
        return;
      Rect drawRect = iconRect;
      drawRect.x = (float) ((double) drawRect.xMax - 16.0 + 4.0);
      drawRect.y = (float) ((double) drawRect.yMax - 16.0 + 1.0);
      drawRect.width = 16f;
      drawRect.height = 16f;
      Editor.OnPostIconGUI(this, drawRect);
    }

    internal void DrawPostIconContent()
    {
      if (Event.current.type != EventType.Repaint)
        return;
      this.DrawPostIconContent(GUILayoutUtility.GetLastRect());
    }

    /// <summary>
    ///   <para>The first entry point for Preview Drawing.</para>
    /// </summary>
    /// <param name="previewPosition">The available area to draw the preview.</param>
    /// <param name="previewArea"></param>
    public virtual void DrawPreview(Rect previewArea)
    {
      ObjectPreview.DrawPreview((IPreviewable) this, previewArea, this.targets);
    }

    internal bool CanBeExpandedViaAFoldout()
    {
      if (this.m_SerializedObject == null)
        this.m_SerializedObject = new SerializedObject(this.targets, this.m_Context);
      else
        this.m_SerializedObject.Update();
      this.m_SerializedObject.inspectorMode = this.m_InspectorMode;
      SerializedProperty iterator = this.m_SerializedObject.GetIterator();
      for (bool enterChildren = true; iterator.NextVisible(enterChildren); enterChildren = false)
      {
        if ((double) EditorGUI.GetPropertyHeight(iterator, (GUIContent) null, true) > 0.0)
          return true;
      }
      return false;
    }

    internal static bool IsAppropriateFileOpenForEdit(UnityEngine.Object assetObject)
    {
      string message;
      return Editor.IsAppropriateFileOpenForEdit(assetObject, out message);
    }

    internal static bool IsAppropriateFileOpenForEdit(UnityEngine.Object assetObject, out string message)
    {
      message = string.Empty;
      if (assetObject == (UnityEngine.Object) null)
        return false;
      StatusQueryOptions statusOptions = !EditorUserSettings.allowAsyncStatusUpdate ? StatusQueryOptions.UseCachedIfPossible : StatusQueryOptions.UseCachedAsync;
      if (AssetDatabase.IsNativeAsset(assetObject))
      {
        if (!AssetDatabase.IsOpenForEdit(assetObject, out message, statusOptions))
          return false;
      }
      else if (AssetDatabase.IsForeignAsset(assetObject) && !AssetDatabase.IsMetaFileOpenForEdit(assetObject, out message, statusOptions))
        return false;
      return true;
    }

    internal virtual bool IsEnabled()
    {
      foreach (UnityEngine.Object target in this.targets)
      {
        if ((target.hideFlags & HideFlags.NotEditable) != HideFlags.None || EditorUtility.IsPersistent(target) && !Editor.IsAppropriateFileOpenForEdit(target))
          return false;
      }
      return true;
    }

    internal bool IsOpenForEdit()
    {
      string message;
      return this.IsOpenForEdit(out message);
    }

    internal bool IsOpenForEdit(out string message)
    {
      message = "";
      foreach (UnityEngine.Object target in this.targets)
      {
        if (EditorUtility.IsPersistent(target) && !Editor.IsAppropriateFileOpenForEdit(target))
          return false;
      }
      return true;
    }

    /// <summary>
    ///   <para>Override this method in subclasses to return false if you don't want default margins.</para>
    /// </summary>
    public virtual bool UseDefaultMargins()
    {
      return true;
    }

    public void Initialize(UnityEngine.Object[] targets)
    {
      throw new InvalidOperationException("You shouldn't call Initialize for Editors");
    }

    public bool MoveNextTarget()
    {
      ++this.referenceTargetIndex;
      return this.referenceTargetIndex < this.targets.Length;
    }

    public void ResetTarget()
    {
      this.referenceTargetIndex = 0;
    }

    int IToolModeOwner.GetInstanceID()
    {
      return this.GetInstanceID();
    }

    internal delegate void OnEditorGUIDelegate(Editor editor, Rect drawRect);

    private class Styles
    {
      public GUIStyle inspectorBig = new GUIStyle(EditorStyles.inspectorBig);
      public GUIStyle inspectorBigInner = new GUIStyle((GUIStyle) "IN BigTitle inner");
      public GUIStyle centerStyle = new GUIStyle();

      public Styles()
      {
        this.centerStyle.alignment = TextAnchor.MiddleCenter;
        --this.inspectorBig.padding.bottom;
      }
    }
  }
}
