/// <summary>
/// @file     IngameUIModel.cs
/// @brief    Model for mvp model.
/// @auther   Kataoka
/// @date     2022-05-05 22:22:11
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

    [Header("Scripts")]
    public ScenesManager scenesManager;
    public OptionSceneManager optionSceneManager;
    [Space(10)]

    [Header("Events")]
    public IntEvent OnCentorTutorialCloseButtonChanged = new IntEvent();
    public IntEvent OnSelectStageButtonChanged = new IntEvent();
    public IntEvent OnOptionButtonChanged = new IntEvent();
    public IntEvent OnExitButtonChanged = new IntEvent();
    public BoolEvent OnPressEnyButton = new BoolEvent();


    // UI parts' states.
    private ButtonState _centorTutorialCloseButtonState = ButtonState.Unhover;
    private ButtonState _selectStageButtonState = ButtonState.Unhover;
    private ButtonState _optionButtonState = ButtonState.Unhover;
    private ButtonState _exitButtonState = ButtonState.Unhover;
    private bool _pressedAnyButton = false;
    # endregion

    # region Unhover buttons.
    public void UnhoverStartGameButton()
    {
        InvokeButtonEvent(ButtonState.Unhover, IngameButtonType.StartGame);
    }
    public void UnhoverSelectStageButton()
    {
        InvokeButtonEvent(ButtonState.Unhover, IngameButtonType.SelectStage);
    }
    public void UnhoverOptionButton()
    {
        InvokeButtonEvent(ButtonState.Unhover, IngameButtonType.Option);
    }
    public void UnhoverExitButton()
    {
        InvokeButtonEvent(ButtonState.Unhover, IngameButtonType.Exit);
    }
    # endregion

    # region Hover buttons.
    public void HoverStartGameButton()
    {
        InvokeButtonEvent(ButtonState.Hover, IngameButtonType.StartGame);
    }
    public void HoverSelectStageButton()
    {
        InvokeButtonEvent(ButtonState.Hover, IngameButtonType.SelectStage);
    }
    public void HoverOptionButton()
    {
        InvokeButtonEvent(ButtonState.Hover, IngameButtonType.Option);
    }
    public void HoverExitButton()
    {
        InvokeButtonEvent(ButtonState.Hover, IngameButtonType.Exit);
    }
    # endregion

    # region Down buttons.
    public void DownStartGameButton()
    {
        InvokeButtonEvent(ButtonState.Down, IngameButtonType.StartGame);
    }
    public void DownSelectStageButton()
    {
        InvokeButtonEvent(ButtonState.Down, IngameButtonType.SelectStage);
    }
    public void DownOptionButton()
    {
        InvokeButtonEvent(ButtonState.Down, IngameButtonType.Option);
    }
    public void DownExitButton()
    {
        InvokeButtonEvent(ButtonState.Down, IngameButtonType.Exit);
    }
    #endregion

    #region Up buttons.
    public void UpStartGameButton()
    {
        InvokeButtonEvent(ButtonState.Up, IngameButtonType.StartGame);
        // TODO: Wait Time?
        // StartCoroutine(scenesManager.AsyncLoadScenes(SceneManager.IngameScenes));

        // Debug.
        SceneManager.LoadSceneAsync("Ingame", LoadSceneMode.Additive);

        scenesManager.UnloadScene("Title");
        scenesManager.UnloadUnusedAssets();
    }

    public void UpSelectStageButton()
    {
        InvokeButtonEvent(ButtonState.Up, IngameButtonType.SelectStage);
        _selectStageButtonState = ButtonState.Unhover;

        // TODO: Wait Time?
        // TODO: Select Game UI (inherit SelectGameUIModel class).
        // _displaySelectGameUI = true;

        // Debug.
        Debug.Log("Invoke ClickSelectStageButton().");
    }

    public void UpOptionButton()
    {
        InvokeButtonEvent(ButtonState.Up, IngameButtonType.Option);
        // TODO: Wait Time?
        // optionUIModel.setIsActiveOptionUI(true);

        // Debug.
        SceneManager.LoadSceneAsync("Option", LoadSceneMode.Additive);
    }

    public void UpExitButton()
    {
        InvokeButtonEvent(ButtonState.Up, IngameButtonType.Exit);
        // TODO: Wait Time?
        // TODO: Swap code bellow
        // gameManager.endGame();

        // Debug: End game.
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
    # endregion

    # region Pressed any buttton
    public void SetPressedAnyButton(bool pressedAnyButton)
    {
        _pressedAnyButton = pressedAnyButton;
        OnPressEnyButton.Invoke(pressedAnyButton);
    }
    #endregion

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
