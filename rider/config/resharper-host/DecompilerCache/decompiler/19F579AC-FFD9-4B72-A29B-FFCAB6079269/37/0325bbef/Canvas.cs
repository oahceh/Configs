﻿// Decompiled with JetBrains decompiler
// Type: UnityEngine.Canvas
// Assembly: UnityEngine.UIModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 19F579AC-FFD9-4B72-A29B-FFCAB6079269
// Assembly location: D:\Unity\Editor\Data\Managed\UnityEngine\UnityEngine.UIModule.dll

using System;
using System.Runtime.CompilerServices;
using UnityEngine.Scripting;

namespace UnityEngine
{
  /// <summary>
  ///   <para>Element that can be used for screen rendering.</para>
  /// </summary>
  [RequireComponent(typeof (RectTransform))]
  [NativeClass("UI::Canvas")]
  public sealed class Canvas : Behaviour
  {
    /// <summary>
    ///   <para>Is the Canvas in World or Overlay mode?</para>
    /// </summary>
    public extern RenderMode renderMode { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Is this the root Canvas?</para>
    /// </summary>
    public extern bool isRootCanvas { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>Camera used for sizing the Canvas when in Screen Space - Camera. Also used as the Camera that events will be sent through for a World Space [[Canvas].</para>
    /// </summary>
    public extern Camera worldCamera { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Get the render rect for the Canvas.</para>
    /// </summary>
    public Rect pixelRect
    {
      get
      {
        Rect rect;
        this.INTERNAL_get_pixelRect(out rect);
        return rect;
      }
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void INTERNAL_get_pixelRect(out Rect value);

    /// <summary>
    ///   <para>Used to scale the entire canvas, while still making it fit the screen. Only applies with renderMode is Screen Space.</para>
    /// </summary>
    public extern float scaleFactor { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>The number of pixels per unit that is considered the default.</para>
    /// </summary>
    public extern float referencePixelsPerUnit { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Allows for nested canvases to override pixelPerfect settings inherited from parent canvases.</para>
    /// </summary>
    public extern bool overridePixelPerfect { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Force elements in the canvas to be aligned with pixels. Only applies with renderMode is Screen Space.</para>
    /// </summary>
    public extern bool pixelPerfect { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>How far away from the camera is the Canvas generated.</para>
    /// </summary>
    public extern float planeDistance { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>The render order in which the canvas is being emitted to the scene.</para>
    /// </summary>
    public extern int renderOrder { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>Override the sorting of canvas.</para>
    /// </summary>
    public extern bool overrideSorting { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Canvas' order within a sorting layer.</para>
    /// </summary>
    public extern int sortingOrder { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>For Overlay mode, display index on which the UI canvas will appear.</para>
    /// </summary>
    public extern int targetDisplay { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>The normalized grid size that the canvas will split the renderable area into.</para>
    /// </summary>
    [Obsolete("Setting normalizedSize via a int is not supported. Please use normalizedSortingGridSize")]
    public extern int sortingGridNormalizedSize { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>The normalized grid size that the canvas will split the renderable area into.</para>
    /// </summary>
    public extern float normalizedSortingGridSize { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Unique ID of the Canvas' sorting layer.</para>
    /// </summary>
    public extern int sortingLayerID { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Cached calculated value based upon SortingLayerID.</para>
    /// </summary>
    public extern int cachedSortingLayerValue { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>Get or set the mask of additional shader channels to be used when creating the Canvas mesh.</para>
    /// </summary>
    public extern AdditionalCanvasShaderChannels additionalShaderChannels { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Name of the Canvas' sorting layer.</para>
    /// </summary>
    public extern string sortingLayerName { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Returns the Canvas closest to root, by checking through each parent and returning the last canvas found. If no other canvas is found then the canvas will return itself.</para>
    /// </summary>
    public extern Canvas rootCanvas { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>Returns the default material that can be used for rendering normal elements on the Canvas.</para>
    /// </summary>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern Material GetDefaultCanvasMaterial();

    /// <summary>
    ///   <para>Gets or generates the ETC1 Material.</para>
    /// </summary>
    /// <returns>
    ///   <para>The generated ETC1 Material from the Canvas.</para>
    /// </returns>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern Material GetETC1SupportedCanvasMaterial();

    /// <summary>
    ///   <para>Returns the default material that can be used for rendering text elements on the Canvas.</para>
    /// </summary>
    [Obsolete("Shared default material now used for text and general UI elements, call Canvas.GetDefaultCanvasMaterial()")]
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern Material GetDefaultCanvasTextMaterial();

    public static event Canvas.WillRenderCanvases willRenderCanvases;

    [RequiredByNativeCode]
    private static void SendWillRenderCanvases()
    {
      // ISSUE: reference to a compiler-generated field
      if (Canvas.willRenderCanvases == null)
        return;
      // ISSUE: reference to a compiler-generated field
      Canvas.willRenderCanvases();
    }

    /// <summary>
    ///   <para>Force all canvases to update their content.</para>
    /// </summary>
    public static void ForceUpdateCanvases()
    {
      Canvas.SendWillRenderCanvases();
    }

    public delegate void WillRenderCanvases();
  }
}
