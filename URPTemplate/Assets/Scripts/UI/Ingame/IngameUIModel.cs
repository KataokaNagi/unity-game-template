/// <summary>
/// @file     IngameUIModel.cs
/// @brief    Model for mvp model.
/// @auther   Kataoka
/// @date     2022-05-10 06:07:08
/// @version  1.0
/// @history  add
/// @see      [UnityにおけるMVPパターンについて](https://virtualcast.jp/blog/2019/11/mvp_pattern_on_unity/)
/// @see      [Unityでの複数シーンを使ったゲームの実装方法とメモリリークについて](https://madnesslabo.net/utage/?page_id=11109)
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class IngameUIModel : MonoBehaviour
{
    # region Fields.
    // TODO: Music.
    // [Header("Music")]
    // [Space(10)]

    // TODO: Textures.
    // [Header("Textures")]
    // [Space(10)]

    [Header("Events")]
    public FloatEvent OnTimerUiChanged = new FloatEvent();
    public IntEvent OnHpUiChanged = new IntEvent();
    public LeftBottomTutorialEvent OnLeftBottomTutorialUiChanged = new LeftBottomTutorialEvent();
    public CentorTutorialUiEvent OnCentorTutorialUiChanged = new CentorTutorialUiEvent();
    public IntEvent OnCentorTutorialCloseButtonChanged = new IntEvent();
    public IntEvent OnKunaiUiChanged = new IntEvent();
    public IntEvent OnEnergyUiChanged = new IntEvent();
    // [Space(10)]


    // UI parts' states.
    [Header("UI parts' states init")]
    [SerializeField] float _timerSecs = 300.0f;
    [SerializeField] int _hp = 5;
    [SerializeField] LeftBottomTutorialTags _leftBottomTutorial = LeftBottomTutorialTags.NoView;
    [SerializeField] CentorTutorialTags _centorTutorial = CentorTutorialTags.NoView;
    [SerializeField] int _kunai = 0;
    [SerializeField] int _energy = 0;
    #endregion

    private ButtonUiState _centorTutorialCloseButtonState = ButtonUiState.Unhover;

    #region Unhover buttons.
    public void UnhoverCentorTutorialCloseButton()
    {
        InvokeButtonEvent(ButtonUiState.Unhover, IngameButtonType.CentorTutorialClose);
    }
    # endregion

    # region Hover buttons.
    public void HoverCentorTutorialCloseButton()
    {
        InvokeButtonEvent(ButtonUiState.Hover, IngameButtonType.CentorTutorialClose);
    }
    # endregion

    # region Down buttons.
    public void DownCentorTutorialCloseButton()
    {
        InvokeButtonEvent(ButtonUiState.Down, IngameButtonType.CentorTutorialClose);
    }
    #endregion

    #region Up buttons.
    public void UpCentorTutorialCloseButton()
    {
        InvokeButtonEvent(ButtonUiState.Up, IngameButtonType.CentorTutorialClose);
        // TODO: Wait Time?
        // StartCoroutine(scenesManager.AsyncLoadScenes(SceneManager.IngameScenes));
    }
    #endregion

    public void SetTimerSecs(float timerSecs)
    {
    }
    public void SetHp(int hp)
    {
    }
    public void SetLeftBottomTutorialUiTag(LeftBottomTutorialTags leftBottomTutorialTags)
    {
    }
    public void SetCentorTutorialUiTag(CentorTutorialTags centorTutorialTags)
    {
    }
    public void SetNumOfKunai(int numOfKunai)
    {
    }
    public void SetNumOfEnergy(int numOfEnergy)
    {
    }

    private void InvokeButtonEvent(ButtonUiState buttonState, IngameButtonType buttonType)
    {
        switch (buttonType)
        {
            case IngameButtonType.CentorTutorialClose:
                _centorTutorialCloseButtonState = buttonState;
                OnCentorTutorialCloseButtonChanged.Invoke((int)buttonState | (int)buttonType);
                break;
            default:
                Debug.LogError("Unknown button type");
                break;
        }
    }
}

public enum IngameButtonType
{
    CentorTutorialClose = (1 << 0),
    Range = 0b10000
}
