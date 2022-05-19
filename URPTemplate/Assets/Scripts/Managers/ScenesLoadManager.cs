using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScenesLoadManager : MonoBehaviour
{
    /// <summary>
    /// Parameter = ScenesLoader.TitleScenesNames
    /// </summary>
    public static StrListEvent TitleScenesLoadEvent;
    public static StrListEvent TitleScenesLoadFinishEvent;

    /// <summary>
    /// Parameter = ScenesLoader.Stage1ScenesNames
    /// </summary>
    public static StrListEvent Stage1ScenesLoadEvent;
    public static StrListEvent Stage1ScenesLoadFinishEvent;

    /// <summary>
    /// Parameter = ScenesLoader.Stage2ScenesNames
    /// </summary>
    public static StrListEvent Stage2ScenesLoadEvent;
    public static StrListEvent Stage2ScenesLoadFinishEvent;

    /// <summary>
    /// Parameter = ScenesLoader.Stage3ScenesNames
    /// </summary>
    public static StrListEvent Stage3ScenesLoadEvent;
    public static StrListEvent Stage3ScenesLoadFinishEvent;

    /// <summary>
    /// Parameter = ScenesLoader.CreditScenesNames
    /// </summary>
    public static StrListEvent CreditScenesLoadEvent;
    public static StrListEvent CreditScenesLoadFinishEvent;

    private ScenesLoader _scenesLoader;

    private void Start()
    {
        AddListenerOnLoading();
        AddListenerOnLoadFinished();
    }

    private void AddListenerOnLoading()
    {
        TitleScenesLoadEvent.AddListener(scenes => _scenesLoader.LoadAndUnloadScenes(scenes));
        Stage1ScenesLoadEvent.AddListener(scenes => _scenesLoader.LoadAndUnloadScenes(scenes));
        Stage2ScenesLoadEvent.AddListener(scenes => _scenesLoader.LoadAndUnloadScenes(scenes));
        Stage3ScenesLoadEvent.AddListener(scenes => _scenesLoader.LoadAndUnloadScenes(scenes));
        CreditScenesLoadEvent.AddListener(scenes => _scenesLoader.LoadAndUnloadScenes(scenes));
    }

    private void AddListenerOnLoadFinished()
    {
        // TODO
    }
}
