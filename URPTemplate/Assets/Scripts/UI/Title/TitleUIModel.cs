/// <summary>
/// @file     TitleUIModel.cs
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

public sealed class TitleUIModel : MonoBehaviour
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
    public IntEvent OnStartGameButtonChanged = new IntEvent();
    public IntEvent OnSelectStageButtonChanged = new IntEvent();
    public IntEvent OnOptionButtonChanged = new IntEvent();
    public IntEvent OnExitButtonChanged = new IntEvent();
    public BoolEvent OnPressEnyButton = new BoolEvent();


    // UI parts' states.
    private ButtonState _startGameButtonState = ButtonState.Unhover;
    private ButtonState _selectStageButtonState = ButtonState.Unhover;
    private ButtonState _optionButtonState = ButtonState.Unhover;
    private ButtonState _exitButtonState = ButtonState.Unhover;
    private bool _pressedAnyButton = false;
    # endregion

    # region Unhover buttons.
    public void UnhoverStartGameButton()
    {
        InvokeButtonEvent(ButtonState.Unhover, ButtonType.StartGame);
    }
    public void UnhoverSelectStageButton()
    {
        InvokeButtonEvent(ButtonState.Unhover, ButtonType.SelectStage);
    }
    public void UnhoverOptionButton()
    {
        InvokeButtonEvent(ButtonState.Unhover, ButtonType.Option);
    }
    public void UnhoverExitButton()
    {
        InvokeButtonEvent(ButtonState.Unhover, ButtonType.Exit);
    }
    # endregion

    # region Hover buttons.
    public void HoverStartGameButton()
    {
        InvokeButtonEvent(ButtonState.Hover, ButtonType.StartGame);
    }
    public void HoverSelectStageButton()
    {
        InvokeButtonEvent(ButtonState.Hover, ButtonType.SelectStage);
    }
    public void HoverOptionButton()
    {
        InvokeButtonEvent(ButtonState.Hover, ButtonType.Option);
    }
    public void HoverExitButton()
    {
        InvokeButtonEvent(ButtonState.Hover, ButtonType.Exit);
    }
    # endregion

    # region Down buttons.
    public void DownStartGameButton()
    {
        InvokeButtonEvent(ButtonState.Down, ButtonType.StartGame);
    }
    public void DownSelectStageButton()
    {
        InvokeButtonEvent(ButtonState.Down, ButtonType.SelectStage);
    }
    public void DownOptionButton()
    {
        InvokeButtonEvent(ButtonState.Down, ButtonType.Option);
    }
    public void DownExitButton()
    {
        InvokeButtonEvent(ButtonState.Down, ButtonType.Exit);
    }
    #endregion

    #region Up buttons.
    public void UpStartGameButton()
    {
        InvokeButtonEvent(ButtonState.Up, ButtonType.StartGame);
        // TODO: Wait Time?
        // StartCoroutine(scenesManager.AsyncLoadScenes(SceneManager.IngameScenes));

        // Debug.
        SceneManager.LoadSceneAsync("Ingame", LoadSceneMode.Additive);

        scenesManager.UnloadScene("Title");
        scenesManager.UnloadUnusedAssets();
    }

    public void UpSelectStageButton()
    {
        InvokeButtonEvent(ButtonState.Up, ButtonType.SelectStage);
        _selectStageButtonState = ButtonState.Unhover;

        // TODO: Wait Time?
        // TODO: Select Game UI (inherit SelectGameUIModel class).
        // _displaySelectGameUI = true;

        // Debug.
        Debug.Log("Invoke ClickSelectStageButton().");
    }

    public void UpOptionButton()
    {
        InvokeButtonEvent(ButtonState.Up, ButtonType.Option);
        // TODO: Wait Time?
        // optionUIModel.setIsActiveOptionUI(true);

        // Debug.
        SceneManager.LoadSceneAsync("Option", LoadSceneMode.Additive);
    }

    public void UpExitButton()
    {
        InvokeButtonEvent(ButtonState.Up, ButtonType.Exit);
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

    private void InvokeButtonEvent(ButtonState buttonState, ButtonType buttonType)
    {
        switch (buttonType)
        {
            case ButtonType.StartGame:
                _startGameButtonState = buttonState;
                OnStartGameButtonChanged.Invoke((int)buttonState | (int)buttonType);
                break;
            case ButtonType.SelectStage:
                _selectStageButtonState = buttonState;
                OnSelectStageButtonChanged.Invoke((int)buttonState | (int)buttonType);
                break;
            case ButtonType.Option:
                _optionButtonState = buttonState;
                OnOptionButtonChanged.Invoke((int)buttonState | (int)buttonType);
                break;
            case ButtonType.Exit:
                _exitButtonState = buttonState;
                OnExitButtonChanged.Invoke((int)buttonState | (int)buttonType);
                break;
            default:
                Debug.LogError("Unknown button type");
                break;
        }
    }
}

public enum ButtonType
{
    StartGame = (1 << 0),
    SelectStage = (1 << 1),
    Option = (1 << 2),
    Exit = (1 << 3),
    Range = 0b00001111
}
public enum ButtonState
{
    Unhover = (1 << 4),
    Hover = (1 << 5),
    Down = (1 << 6),
    Up = (1 << 7),
    Range = 0b11110000
}
