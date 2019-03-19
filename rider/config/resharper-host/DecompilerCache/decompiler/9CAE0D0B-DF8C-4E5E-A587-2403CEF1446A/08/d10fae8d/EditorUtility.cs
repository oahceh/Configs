﻿// Decompiled with JetBrains decompiler
// Type: UnityEditor.EditorUtility
// Assembly: UnityEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9CAE0D0B-DF8C-4E5E-A587-2403CEF1446A
// Assembly location: D:\Unity\Editor\Data\Managed\UnityEditor.dll

using System;
using System.Collections;
using System.Runtime.CompilerServices;
using UnityEditor.Scripting.Compilers;
using UnityEngine;
using UnityEngine.Internal;
using UnityEngine.Scripting;

namespace UnityEditor
{
  /// <summary>
  ///   <para>Editor utility functions.</para>
  /// </summary>
  public sealed class EditorUtility
  {
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void RevealInFinder(string path);

    /// <summary>
    ///   <para>Marks target object as dirty. (Only suitable for non-scene objects).</para>
    /// </summary>
    /// <param name="target">The object to mark as dirty.</param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void SetDirty(UnityEngine.Object target);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void LoadPlatformSupportModuleNativeDllInternal(string target);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void LoadPlatformSupportNativeLibrary(string nativeLibrary);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern int GetDirtyIndex(int instanceID);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern bool IsDirty(int instanceID);

    public static bool LoadWindowLayout(string path)
    {
      bool newProjectLayoutWasCreated = false;
      return WindowLayout.LoadWindowLayout(path, newProjectLayoutWasCreated);
    }

    /// <summary>
    ///   <para>Determines if an object is stored on disk.</para>
    /// </summary>
    /// <param name="target"></param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern bool IsPersistent(UnityEngine.Object target);

    /// <summary>
    ///   <para>Displays a modal dialog.</para>
    /// </summary>
    /// <param name="title">The title of the message box.</param>
    /// <param name="message">The text of the message.</param>
    /// <param name="ok">Label displayed on the OK dialog button.</param>
    /// <param name="cancel">Label displayed on the Cancel dialog button.</param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern bool DisplayDialog(string title, string message, string ok, [DefaultValue("\"\"")] string cancel);

    /// <summary>
    ///   <para>Displays a modal dialog.</para>
    /// </summary>
    /// <param name="title">The title of the message box.</param>
    /// <param name="message">The text of the message.</param>
    /// <param name="ok">Label displayed on the OK dialog button.</param>
    /// <param name="cancel">Label displayed on the Cancel dialog button.</param>
    [ExcludeFromDocs]
    public static bool DisplayDialog(string title, string message, string ok)
    {
      string cancel = "";
      return EditorUtility.DisplayDialog(title, message, ok, cancel);
    }

    /// <summary>
    ///   <para>Displays a modal dialog with three buttons.</para>
    /// </summary>
    /// <param name="title">Title for dialog.</param>
    /// <param name="message">Purpose for the dialog.</param>
    /// <param name="ok">Dialog function chosen.</param>
    /// <param name="alt">Choose alternative dialog purpose.</param>
    /// <param name="cancel">Close dialog with no operation.</param>
    /// <returns>
    ///   <para>The id of the chosen button.</para>
    /// </returns>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern int DisplayDialogComplex(string title, string message, string ok, string cancel, string alt);

    /// <summary>
    ///   <para>Displays the "open file" dialog and returns the selected path name.</para>
    /// </summary>
    /// <param name="title"></param>
    /// <param name="directory"></param>
    /// <param name="extension"></param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern string OpenFilePanel(string title, string directory, string extension);

    /// <summary>
    ///   <para>Displays the "open file" dialog and returns the selected path name.</para>
    /// </summary>
    /// <param name="title">Title for dialog.</param>
    /// <param name="directory">Default directory.</param>
    /// <param name="filters">File extensions in form { "Image files", "png,jpg,jpeg", "All files", "*" }.</param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern string OpenFilePanelWithFilters(string title, string directory, string[] filters);

    /// <summary>
    ///   <para>Displays the "save file" dialog and returns the selected path name.</para>
    /// </summary>
    /// <param name="title"></param>
    /// <param name="directory"></param>
    /// <param name="defaultName"></param>
    /// <param name="extension"></param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern string SaveFilePanel(string title, string directory, string defaultName, string extension);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern string SaveBuildPanel(BuildTarget target, string title, string directory, string defaultName, string extension, out bool updateExistingBuild);

    /// <summary>
    ///   <para>Human-like sorting.</para>
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern int NaturalCompare(string a, string b);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern int NaturalCompareObjectNames(UnityEngine.Object a, UnityEngine.Object b);

    /// <summary>
    ///   <para>Displays the "open folder" dialog and returns the selected path name.</para>
    /// </summary>
    /// <param name="title"></param>
    /// <param name="folder"></param>
    /// <param name="defaultName"></param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern string OpenFolderPanel(string title, string folder, string defaultName);

    /// <summary>
    ///   <para>Displays the "save folder" dialog and returns the selected path name.</para>
    /// </summary>
    /// <param name="title"></param>
    /// <param name="folder"></param>
    /// <param name="defaultName"></param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern string SaveFolderPanel(string title, string folder, string defaultName);

    /// <summary>
    ///   <para>Displays the "save file" dialog in the Assets folder of the project and returns the selected path name.</para>
    /// </summary>
    /// <param name="title"></param>
    /// <param name="defaultName"></param>
    /// <param name="extension"></param>
    /// <param name="message"></param>
    public static string SaveFilePanelInProject(string title, string defaultName, string extension, string message)
    {
      return EditorUtility.Internal_SaveFilePanelInProject(title, defaultName, extension, message, "Assets");
    }

    public static string SaveFilePanelInProject(string title, string defaultName, string extension, string message, string path)
    {
      return EditorUtility.Internal_SaveFilePanelInProject(title, defaultName, extension, message, path);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern string Internal_SaveFilePanelInProject(string title, string defaultName, string extension, string message, string path);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern bool WarnPrefab(UnityEngine.Object target, string title, string warning, string okButton);

    [Obsolete("use AssetDatabase.LoadAssetAtPath")]
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern UnityEngine.Object FindAsset(string path, System.Type type);

    /// <summary>
    ///   <para>Translates an instance ID to a reference to an object.</para>
    /// </summary>
    /// <param name="instanceID"></param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern UnityEngine.Object InstanceIDToObject(int instanceID);

    /// <summary>
    ///   <para>Compress a texture.</para>
    /// </summary>
    /// <param name="texture"></param>
    /// <param name="format"></param>
    /// <param name="quality"></param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void CompressTexture(Texture2D texture, TextureFormat format, int quality);

    /// <summary>
    ///   <para>Compress a texture.</para>
    /// </summary>
    /// <param name="texture"></param>
    /// <param name="format"></param>
    /// <param name="quality"></param>
    public static void CompressTexture(Texture2D texture, TextureFormat format, TextureCompressionQuality quality)
    {
      if ((UnityEngine.Object) texture == (UnityEngine.Object) null)
        throw new ArgumentNullException("texture can not be null");
      EditorUtility.CompressTexture(texture, format, (int) quality);
    }

    private static void CompressTexture(Texture2D texture, TextureFormat format)
    {
      if ((UnityEngine.Object) texture == (UnityEngine.Object) null)
        throw new ArgumentNullException("texture can not be null");
      EditorUtility.CompressTexture(texture, format, TextureCompressionQuality.Normal);
    }

    /// <summary>
    ///   <para>Compress a cubemap texture.</para>
    /// </summary>
    /// <param name="texture"></param>
    /// <param name="format"></param>
    /// <param name="quality"></param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void CompressCubemapTexture(Cubemap texture, TextureFormat format, int quality);

    /// <summary>
    ///   <para>Compress a cubemap texture.</para>
    /// </summary>
    /// <param name="texture"></param>
    /// <param name="format"></param>
    /// <param name="quality"></param>
    public static void CompressCubemapTexture(Cubemap texture, TextureFormat format, TextureCompressionQuality quality)
    {
      if ((UnityEngine.Object) texture == (UnityEngine.Object) null)
        throw new ArgumentNullException("texture can not be null");
      EditorUtility.CompressCubemapTexture(texture, format, (int) quality);
    }

    private static void CompressCubemapTexture(Cubemap texture, TextureFormat format)
    {
      if ((UnityEngine.Object) texture == (UnityEngine.Object) null)
        throw new ArgumentNullException("texture can not be null");
      EditorUtility.CompressCubemapTexture(texture, format, TextureCompressionQuality.Normal);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern string InvokeDiffTool(string leftTitle, string leftFile, string rightTitle, string rightFile, string ancestorTitle, string ancestorFile);

    /// <summary>
    ///   <para>Copy all settings of a Unity Object.</para>
    /// </summary>
    /// <param name="source"></param>
    /// <param name="dest"></param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void CopySerialized(UnityEngine.Object source, UnityEngine.Object dest);

    /// <summary>
    ///   <para>Copy all settings of a Unity Object to a second Object if they differ.</para>
    /// </summary>
    /// <param name="source"></param>
    /// <param name="dest"></param>
    public static void CopySerializedIfDifferent(UnityEngine.Object source, UnityEngine.Object dest)
    {
      if (source == (UnityEngine.Object) null)
        throw new ArgumentNullException("Argument 'source' is null");
      if (dest == (UnityEngine.Object) null)
        throw new ArgumentNullException("Argument 'dest' is null");
      EditorUtility.InternalCopySerializedIfDifferent(source, dest);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void InternalCopySerializedIfDifferent(UnityEngine.Object source, UnityEngine.Object dest);

    [Obsolete("Use AssetDatabase.GetAssetPath")]
    public static string GetAssetPath(UnityEngine.Object asset)
    {
      return AssetDatabase.GetAssetPath(asset);
    }

    /// <summary>
    ///   <para>Calculates and returns a list of all assets the assets listed in roots depend on.</para>
    /// </summary>
    /// <param name="roots"></param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern UnityEngine.Object[] CollectDependencies(UnityEngine.Object[] roots);

    /// <summary>
    ///   <para>Collect all objects in the hierarchy rooted at each of the given objects.</para>
    /// </summary>
    /// <param name="roots">Array of objects where the search will start.</param>
    /// <returns>
    ///   <para>Array of objects heirarchically attached to the search array.</para>
    /// </returns>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern UnityEngine.Object[] CollectDeepHierarchy(UnityEngine.Object[] roots);

    internal static void InitInstantiatedPreviewRecursive(GameObject go)
    {
      go.hideFlags = HideFlags.HideAndDontSave;
      go.layer = Camera.PreviewCullingLayer;
      IEnumerator enumerator = go.transform.GetEnumerator();
      try
      {
        while (enumerator.MoveNext())
          EditorUtility.InitInstantiatedPreviewRecursive(((Component) enumerator.Current).gameObject);
      }
      finally
      {
        IDisposable disposable;
        if ((disposable = enumerator as IDisposable) != null)
          disposable.Dispose();
      }
    }

    internal static GameObject InstantiateForAnimatorPreview(UnityEngine.Object original)
    {
      if (original == (UnityEngine.Object) null)
        throw new ArgumentException("The prefab you want to instantiate is null.");
      GameObject go = EditorUtility.InstantiateRemoveAllNonAnimationComponents(original, Vector3.zero, Quaternion.identity) as GameObject;
      go.name += "AnimatorPreview";
      go.tag = "Untagged";
      EditorUtility.InitInstantiatedPreviewRecursive(go);
      Animator[] componentsInChildren = go.GetComponentsInChildren<Animator>();
      for (int index = 0; index < componentsInChildren.Length; ++index)
      {
        Animator animator = componentsInChildren[index];
        animator.enabled = false;
        animator.cullingMode = AnimatorCullingMode.AlwaysAnimate;
        animator.logWarnings = false;
        animator.fireEvents = false;
      }
      if (componentsInChildren.Length == 0)
      {
        Animator animator = go.AddComponent<Animator>();
        animator.enabled = false;
        animator.cullingMode = AnimatorCullingMode.AlwaysAnimate;
        animator.logWarnings = false;
        animator.fireEvents = false;
      }
      return go;
    }

    internal static UnityEngine.Object InstantiateRemoveAllNonAnimationComponents(UnityEngine.Object original, Vector3 position, Quaternion rotation)
    {
      if (original == (UnityEngine.Object) null)
        throw new ArgumentException("The prefab you want to instantiate is null.");
      return EditorUtility.Internal_InstantiateRemoveAllNonAnimationComponentsSingle(original, position, rotation);
    }

    private static UnityEngine.Object Internal_InstantiateRemoveAllNonAnimationComponentsSingle(UnityEngine.Object data, Vector3 pos, Quaternion rot)
    {
      return EditorUtility.INTERNAL_CALL_Internal_InstantiateRemoveAllNonAnimationComponentsSingle(data, ref pos, ref rot);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern UnityEngine.Object INTERNAL_CALL_Internal_InstantiateRemoveAllNonAnimationComponentsSingle(UnityEngine.Object data, ref Vector3 pos, ref Quaternion rot);

    [Obsolete("Use EditorUtility.UnloadUnusedAssetsImmediate instead")]
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void UnloadUnusedAssets();

    [Obsolete("Use EditorUtility.UnloadUnusedAssetsImmediate instead")]
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void UnloadUnusedAssetsIgnoreManagedReferences();

    /// <summary>
    ///   <para>Unloads assets that are not used.</para>
    /// </summary>
    /// <param name="ignoreReferencesFromScript">When true delete assets even if linked in scripts.</param>
    public static void UnloadUnusedAssetsImmediate()
    {
      EditorUtility.UnloadUnusedAssetsImmediateInternal(true);
    }

    public static void UnloadUnusedAssetsImmediate(bool includeMonoReferencesAsRoots)
    {
      EditorUtility.UnloadUnusedAssetsImmediateInternal(includeMonoReferencesAsRoots);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void UnloadUnusedAssetsImmediateInternal(bool includeMonoReferencesAsRoots);

    [Obsolete("Use BuildPipeline.BuildAssetBundle instead", true)]
    public static bool BuildResourceFile(UnityEngine.Object[] selection, string pathName)
    {
      return false;
    }

    internal static void Internal_DisplayPopupMenu(Rect position, string menuItemPath, UnityEngine.Object context, int contextUserData)
    {
      EditorUtility.Private_DisplayPopupMenu(position, menuItemPath, context, contextUserData);
    }

    private static void Private_DisplayPopupMenu(Rect position, string menuItemPath, UnityEngine.Object context, int contextUserData)
    {
      EditorUtility.INTERNAL_CALL_Private_DisplayPopupMenu(ref position, menuItemPath, context, contextUserData);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void INTERNAL_CALL_Private_DisplayPopupMenu(ref Rect position, string menuItemPath, UnityEngine.Object context, int contextUserData);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void Internal_UpdateMenuTitleForLanguage(SystemLanguage newloc);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void Internal_UpdateAllMenus();

    /// <summary>
    ///   <para>Displays a popup menu.</para>
    /// </summary>
    /// <param name="position"></param>
    /// <param name="menuItemPath"></param>
    /// <param name="command"></param>
    public static void DisplayPopupMenu(Rect position, string menuItemPath, MenuCommand command)
    {
      if (menuItemPath == "CONTEXT" || menuItemPath == "CONTEXT/" || menuItemPath == "CONTEXT\\")
      {
        bool flag = false;
        if (command == null)
          flag = true;
        if (command != null && command.context == (UnityEngine.Object) null)
          flag = true;
        if (flag)
        {
          Debug.LogError((object) "DisplayPopupMenu: invalid arguments: using CONTEXT requires a valid MenuCommand object. If you want a custom context menu then try using the GenericMenu.");
          return;
        }
      }
      Vector2 screenPoint = GUIUtility.GUIToScreenPoint(new Vector2(position.x, position.y));
      position.x = screenPoint.x;
      position.y = screenPoint.y;
      EditorUtility.Internal_DisplayPopupMenu(position, menuItemPath, command?.context, command != null ? command.userData : 0);
      EditorUtility.ResetMouseDown();
    }

    internal static void DisplayObjectContextMenu(Rect position, UnityEngine.Object context, int contextUserData)
    {
      EditorUtility.DisplayObjectContextMenu(position, new UnityEngine.Object[1]
      {
        context
      }, contextUserData);
    }

    internal static void DisplayObjectContextMenu(Rect position, UnityEngine.Object[] context, int contextUserData)
    {
      Vector2 screenPoint = GUIUtility.GUIToScreenPoint(new Vector2(position.x, position.y));
      position.x = screenPoint.x;
      position.y = screenPoint.y;
      EditorUtility.Internal_DisplayObjectContextMenu(position, context, contextUserData);
      EditorUtility.ResetMouseDown();
    }

    internal static void Internal_DisplayObjectContextMenu(Rect position, UnityEngine.Object[] context, int contextUserData)
    {
      EditorUtility.INTERNAL_CALL_Internal_DisplayObjectContextMenu(ref position, context, contextUserData);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void INTERNAL_CALL_Internal_DisplayObjectContextMenu(ref Rect position, UnityEngine.Object[] context, int contextUserData);

    public static void DisplayCustomMenu(Rect position, GUIContent[] options, int selected, EditorUtility.SelectMenuItemFunction callback, object userData)
    {
      EditorUtility.DisplayCustomMenu(position, options, selected, callback, userData, false);
    }

    public static void DisplayCustomMenu(Rect position, GUIContent[] options, int selected, EditorUtility.SelectMenuItemFunction callback, object userData, bool showHotkey)
    {
      int[] selected1 = new int[1]{ selected };
      string[] options1 = new string[options.Length];
      for (int index = 0; index < options.Length; ++index)
        options1[index] = options[index].text;
      EditorUtility.DisplayCustomMenu(position, options1, selected1, callback, userData, showHotkey);
    }

    internal static void DisplayCustomMenu(Rect position, string[] options, int[] selected, EditorUtility.SelectMenuItemFunction callback, object userData)
    {
      EditorUtility.DisplayCustomMenu(position, options, selected, callback, userData, false);
    }

    internal static void DisplayCustomMenu(Rect position, string[] options, int[] selected, EditorUtility.SelectMenuItemFunction callback, object userData, bool showHotkey)
    {
      bool[] separator = new bool[options.Length];
      EditorUtility.DisplayCustomMenuWithSeparators(position, options, separator, selected, callback, userData, showHotkey);
    }

    internal static void DisplayCustomMenuWithSeparators(Rect position, string[] options, bool[] separator, int[] selected, EditorUtility.SelectMenuItemFunction callback, object userData)
    {
      EditorUtility.DisplayCustomMenuWithSeparators(position, options, separator, selected, callback, userData, false);
    }

    internal static void DisplayCustomMenuWithSeparators(Rect position, string[] options, bool[] separator, int[] selected, EditorUtility.SelectMenuItemFunction callback, object userData, bool showHotkey)
    {
      Vector2 screenPoint = GUIUtility.GUIToScreenPoint(new Vector2(position.x, position.y));
      position.x = screenPoint.x;
      position.y = screenPoint.y;
      int[] enabled = new int[options.Length];
      int[] separator1 = new int[options.Length];
      for (int index = 0; index < options.Length; ++index)
      {
        enabled[index] = 1;
        separator1[index] = 0;
      }
      EditorUtility.Internal_DisplayCustomMenu(position, options, enabled, separator1, selected, callback, userData, showHotkey);
      EditorUtility.ResetMouseDown();
    }

    internal static void DisplayCustomMenu(Rect position, string[] options, bool[] enabled, int[] selected, EditorUtility.SelectMenuItemFunction callback, object userData)
    {
      EditorUtility.DisplayCustomMenu(position, options, enabled, selected, callback, userData, false);
    }

    internal static void DisplayCustomMenu(Rect position, string[] options, bool[] enabled, int[] selected, EditorUtility.SelectMenuItemFunction callback, object userData, bool showHotkey)
    {
      bool[] separator = new bool[options.Length];
      EditorUtility.DisplayCustomMenuWithSeparators(position, options, enabled, separator, selected, callback, userData, showHotkey);
    }

    internal static void DisplayCustomMenuWithSeparators(Rect position, string[] options, bool[] enabled, bool[] separator, int[] selected, EditorUtility.SelectMenuItemFunction callback, object userData)
    {
      EditorUtility.DisplayCustomMenuWithSeparators(position, options, enabled, separator, selected, callback, userData, false);
    }

    internal static void DisplayCustomMenuWithSeparators(Rect position, string[] options, bool[] enabled, bool[] separator, int[] selected, EditorUtility.SelectMenuItemFunction callback, object userData, bool showHotkey)
    {
      Vector2 screenPoint = GUIUtility.GUIToScreenPoint(new Vector2(position.x, position.y));
      position.x = screenPoint.x;
      position.y = screenPoint.y;
      int[] enabled1 = new int[options.Length];
      int[] separator1 = new int[options.Length];
      for (int index = 0; index < options.Length; ++index)
      {
        enabled1[index] = !enabled[index] ? 0 : 1;
        separator1[index] = !separator[index] ? 0 : 1;
      }
      EditorUtility.Internal_DisplayCustomMenu(position, options, enabled1, separator1, selected, callback, userData, showHotkey);
      EditorUtility.ResetMouseDown();
    }

    private static void Internal_DisplayCustomMenu(Rect screenPosition, string[] options, int[] enabled, int[] separator, int[] selected, EditorUtility.SelectMenuItemFunction callback, object userData, bool showHotkey)
    {
      EditorUtility.Private_DisplayCustomMenu(screenPosition, options, enabled, separator, selected, callback, userData, showHotkey);
    }

    private static void Private_DisplayCustomMenu(Rect screenPosition, string[] options, int[] enabled, int[] separator, int[] selected, EditorUtility.SelectMenuItemFunction callback, object userData, bool showHotkey)
    {
      EditorUtility.INTERNAL_CALL_Private_DisplayCustomMenu(ref screenPosition, options, enabled, separator, selected, callback, userData, showHotkey);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void INTERNAL_CALL_Private_DisplayCustomMenu(ref Rect screenPosition, string[] options, int[] enabled, int[] separator, int[] selected, EditorUtility.SelectMenuItemFunction callback, object userData, bool showHotkey);

    internal static void ResetMouseDown()
    {
      Tools.s_ButtonDown = -1;
      GUIUtility.hotControl = 0;
    }

    /// <summary>
    ///   <para>Brings the project window to the front and focuses it.</para>
    /// </summary>
    [RequiredByNativeCode]
    public static void FocusProjectWindow()
    {
      ProjectBrowser projectBrowser = (ProjectBrowser) null;
      HostView focusedView = GUIView.focusedView as HostView;
      if ((UnityEngine.Object) focusedView != (UnityEngine.Object) null && focusedView.actualView is ProjectBrowser)
        projectBrowser = focusedView.actualView as ProjectBrowser;
      if ((UnityEngine.Object) projectBrowser == (UnityEngine.Object) null)
      {
        UnityEngine.Object[] objectsOfTypeAll = UnityEngine.Resources.FindObjectsOfTypeAll(typeof (ProjectBrowser));
        if (objectsOfTypeAll.Length > 0)
          projectBrowser = objectsOfTypeAll[0] as ProjectBrowser;
      }
      if (!((UnityEngine.Object) projectBrowser != (UnityEngine.Object) null))
        return;
      projectBrowser.Focus();
      Event e = EditorGUIUtility.CommandEvent(nameof (FocusProjectWindow));
      projectBrowser.SendEvent(e);
    }

    /// <summary>
    ///   <para>Returns a text for a number of bytes.</para>
    /// </summary>
    /// <param name="bytes"></param>
    public static string FormatBytes(int bytes)
    {
      return EditorUtility.FormatBytes((long) bytes);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern string FormatBytes(long bytes);

    /// <summary>
    ///   <para>Displays or updates a progress bar.</para>
    /// </summary>
    /// <param name="title"></param>
    /// <param name="info"></param>
    /// <param name="progress"></param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void DisplayProgressBar(string title, string info, float progress);

    /// <summary>
    ///   <para>Displays or updates a progress bar that has a cancel button.</para>
    /// </summary>
    /// <param name="title"></param>
    /// <param name="info"></param>
    /// <param name="progress"></param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern bool DisplayCancelableProgressBar(string title, string info, float progress);

    /// <summary>
    ///   <para>Removes progress bar.</para>
    /// </summary>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void ClearProgressBar();

    /// <summary>
    ///   <para>Is the object enabled (0 disabled, 1 enabled, -1 has no enabled button).</para>
    /// </summary>
    /// <param name="target"></param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern int GetObjectEnabled(UnityEngine.Object target);

    /// <summary>
    ///   <para>Set the enabled state of the object.</para>
    /// </summary>
    /// <param name="target"></param>
    /// <param name="enabled"></param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void SetObjectEnabled(UnityEngine.Object target, bool enabled);

    /// <summary>
    ///   <para>Sets whether the selected Renderer's wireframe will be hidden when the GameObject it is attached to is selected.</para>
    /// </summary>
    /// <param name="renderer"></param>
    /// <param name="enabled"></param>
    [Obsolete("Use EditorUtility.SetSelectedRenderState")]
    public static void SetSelectedWireframeHidden(Renderer renderer, bool enabled)
    {
      EditorUtility.SetSelectedRenderState(renderer, !enabled ? EditorSelectedRenderState.Wireframe | EditorSelectedRenderState.Highlight : EditorSelectedRenderState.Hidden);
    }

    /// <summary>
    ///   <para>Set the Scene View selected display mode for this Renderer.</para>
    /// </summary>
    /// <param name="renderer"></param>
    /// <param name="renderState"></param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void SetSelectedRenderState(Renderer renderer, EditorSelectedRenderState renderState);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void ForceReloadInspectors();

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void ForceRebuildInspectors();

    /// <summary>
    ///   <para>Saves an AudioClip or MovieTexture to a file.</para>
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="path"></param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern bool ExtractOggFile(UnityEngine.Object obj, string path);

    /// <summary>
    ///   <para>Creates a game object with HideFlags and specified components.</para>
    /// </summary>
    /// <param name="name"></param>
    /// <param name="flags"></param>
    /// <param name="components"></param>
    public static GameObject CreateGameObjectWithHideFlags(string name, HideFlags flags, params System.Type[] components)
    {
      GameObject objectWithHideFlags = EditorUtility.Internal_CreateGameObjectWithHideFlags(name, flags);
      objectWithHideFlags.AddComponent(typeof (Transform));
      foreach (System.Type component in components)
        objectWithHideFlags.AddComponent(component);
      return objectWithHideFlags;
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern GameObject Internal_CreateGameObjectWithHideFlags(string name, HideFlags flags);

    public static string[] CompileCSharp(string[] sources, string[] references, string[] defines, string outputFile)
    {
      return MonoCSharpCompiler.Compile(sources, references, defines, outputFile);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void OpenWithDefaultApp(string fileName);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern bool WSACreateTestCertificate(string path, string publisher, string password, bool overwrite);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern bool IsWindows10OrGreater();

    [Obsolete("Use PrefabUtility.InstantiatePrefab")]
    public static UnityEngine.Object InstantiatePrefab(UnityEngine.Object target)
    {
      return PrefabUtility.InstantiatePrefab(target);
    }

    [Obsolete("Use PrefabUtility.ReplacePrefab")]
    public static GameObject ReplacePrefab(GameObject go, UnityEngine.Object targetPrefab, ReplacePrefabOptions options)
    {
      return PrefabUtility.ReplacePrefab(go, targetPrefab, options);
    }

    [Obsolete("Use PrefabUtility.ReplacePrefab")]
    public static GameObject ReplacePrefab(GameObject go, UnityEngine.Object targetPrefab)
    {
      return PrefabUtility.ReplacePrefab(go, targetPrefab, ReplacePrefabOptions.Default);
    }

    [Obsolete("Use PrefabUtility.CreateEmptyPrefab")]
    public static UnityEngine.Object CreateEmptyPrefab(string path)
    {
      return PrefabUtility.CreateEmptyPrefab(path);
    }

    [Obsolete("Use PrefabUtility.CreateEmptyPrefab")]
    public static bool ReconnectToLastPrefab(GameObject go)
    {
      return PrefabUtility.ReconnectToLastPrefab(go);
    }

    [Obsolete("Use PrefabUtility.GetPrefabType")]
    public static PrefabType GetPrefabType(UnityEngine.Object target)
    {
      return PrefabUtility.GetPrefabType(target);
    }

    [Obsolete("Use PrefabUtility.GetPrefabParent")]
    public static UnityEngine.Object GetPrefabParent(UnityEngine.Object source)
    {
      return PrefabUtility.GetPrefabParent(source);
    }

    [Obsolete("Use PrefabUtility.FindPrefabRoot")]
    public static GameObject FindPrefabRoot(GameObject source)
    {
      return PrefabUtility.FindPrefabRoot(source);
    }

    [Obsolete("Use PrefabUtility.ResetToPrefabState")]
    public static bool ResetToPrefabState(UnityEngine.Object source)
    {
      return PrefabUtility.ResetToPrefabState(source);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void SetCameraAnimateMaterials(Camera camera, bool animate);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern string GetInvalidFilenameChars();

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern bool IsAutoRefreshEnabled();

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern string GetActiveNativePlatformSupportModuleName();

    public static extern bool audioMasterMute { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void LaunchBugReporter();

    internal static extern bool audioProfilingEnabled { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>True if there are any compilation error messages in the log.</para>
    /// </summary>
    public static extern bool scriptCompilationFailed { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern bool EventHasDragCopyModifierPressed(Event evt);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern bool EventHasDragMoveModifierPressed(Event evt);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern string GetInternalEditorPath();

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void SaveProjectAsTemplate(string targetPath, string name, string displayName, string description, string version);

    public delegate void SelectMenuItemFunction(object userData, string[] options, int selected);
  }
}
