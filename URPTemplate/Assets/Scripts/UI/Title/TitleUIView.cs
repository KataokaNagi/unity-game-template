/// <summary>
/// @file     TitleUIView.cs
/// @brief    Events for mvp model.
/// @auther   Kataoka
/// @date     2022-05-05 22:22:11
/// @version  1.0
/// @history  add
/// @see      [UnityにおけるMVPパターンについて](https://virtualcast.jp/blog/2019/11/mvp_pattern_on_unity/)
/// @see      [Unityでの複数シーンを使ったゲームの実装方法とメモリリークについて](https://madnesslabo.net/utage/?page_id=11109)
/// </summary>

using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public sealed class TitleUIView : MonoBehaviour
{
    [Header("Button Events")]
    public UnityEvent OnStartGameButtonUnhovered = new UnityEvent();
    public UnityEvent OnSelectStageButtonUnhovered = new UnityEvent();
    public UnityEvent OnOptionButtonUnhovered = new UnityEvent();
    public UnityEvent OnExitButtonUnhovered = new UnityEvent();
    public UnityEvent OnStartGameButtonHovered = new UnityEvent();
    [Space(5)]

    public UnityEvent OnSelectStageButtonHovered = new UnityEvent();
    public UnityEvent OnOptionButtonHovered = new UnityEvent();
    public UnityEvent OnExitButtonHovered = new UnityEvent();
    public UnityEvent OnStartGameButtonDown = new UnityEvent();
    [Space(5)]
    public UnityEvent OnSelectStageButtonDown = new UnityEvent();
    public UnityEvent OnOptionButtonDown = new UnityEvent();
    public UnityEvent OnExitButtonDown = new UnityEvent();
    public UnityEvent OnStartGameButtonUp = new UnityEvent();
    [Space(5)]
    public UnityEvent OnSelectStageButtonUp = new UnityEvent();
    public UnityEvent OnOptionButtonUp = new UnityEvent();
    public UnityEvent OnExitButtonUp = new UnityEvent();
    [Space(10)]

    [Header("Press Any button Events")]
    public BoolEvent OnPressAnyButton = new BoolEvent();
    [Space(10)]

    [Header("UI Parts")]
    [SerializeField] Button _startGameButton;
    [SerializeField] Button _selectStageButton;
    [SerializeField] Button _optionButton;
    [SerializeField] Button _exitButton;
    [SerializeField] Text _pressAnyButtonText;
    [SerializeField] GameObject titleUI;

    void Awake()
    {
        // Set invoking events on click buttons.
        // TODO: AddListener to PointerExit, Enter, Down, Up, Press any button
        // _startGameButton.OnPointerExit.AddListener(() => OnStartGameButtonClicked.Invoke());
        // _selectStageButton.OnPointerExit.AddListener(() => OnSelectStageButtonClicked.Invoke());
        // _optionButton.OnPointerExit.AddListener(() => OnOptionButtonClicked.Invoke());
        // _exitButton.OnPointerExit.AddListener(() => OnExitButtonClicked.Invoke());
    }

    # region Change Button UI.
    public void ChangeButtonUI(int buttonTypeORState)
    {
        int buttonType = buttonTypeORState & (int)ButtonType.Range;
        int buttonState = buttonTypeORState & (int)ButtonState.Range;

        switch (buttonState)
        {
            case (int)ButtonState.Unhover:
                break;
            case (int)ButtonState.Hover:
                break;
            case (int)ButtonState.Down:
                break;
            case (int)ButtonState.Up:
                break;
            default:
                Debug.Log("Unknown button type");
                break;
        }
    }

    private void SetUnhoverButtonUI(int buttonType)
    {
        switch (buttonType)
        {
            case (int)ButtonType.StartGame:
                // TODO
                // _startGameButton.
                break;
            case (int)ButtonType.SelectStage:
                // TODO
                // _selectStageButton.
                break;
            case (int)ButtonType.Option:
                // TODO
                // _optionButton.
                break;
            case (int)ButtonType.Exit:
                // TODO
                // _exitButton.
                break;
            default:
                Debug.LogError("Unknown button type");
                break;
        }
    }
    private void SetHoverButtonUI(int buttonType)
    {
        switch (buttonType)
        {
            case (int)ButtonType.StartGame:
                // TODO
                // _startGameButton.
                break;
            case (int)ButtonType.SelectStage:
                // TODO
                // _selectStageButton.
                break;
            case (int)ButtonType.Option:
                // TODO
                // _optionButton.
                break;
            case (int)ButtonType.Exit:
                // TODO
                // _exitButton.
                break;
            default:
                Debug.LogError("Unknown button type");
                break;
        }
    }
    private void SetUpButtonUI(int buttonType)
    {
        switch (buttonType)
        {
            case (int)ButtonType.StartGame:
                // TODO
                // _startGameButton.
                break;
            case (int)ButtonType.SelectStage:
                // TODO
                // _selectStageButton.
                break;
            case (int)ButtonType.Option:
                // TODO
                // _optionButton.
                break;
            case (int)ButtonType.Exit:
                // TODO
                // _exitButton.
                break;
            default:
                Debug.LogError("Unknown button type");
                break;
        }
    }
    private void SetDownButtonUI(int buttonType)
    {
        switch (buttonType)
        {
            case (int)ButtonType.StartGame:
                // TODO
                // _startGameButton.
                break;
            case (int)ButtonType.SelectStage:
                // TODO
                // _selectStageButton.
                break;
            case (int)ButtonType.Option:
                // TODO
                // _optionButton.
                break;
            case (int)ButtonType.Exit:
                // TODO
                // _exitButton.
                break;
            default:
                Debug.LogError("Unknown button type");
                break;
        }
    }
    #endregion

    #region Change UI on pressing any button.
    public void TogglePressAnyButton(bool pressedAnyButton)
    {
        // Press Any button.
        _pressAnyButtonText.gameObject.SetActive(pressedAnyButton);

        // Buttons.
        _startGameButton.gameObject.SetActive(!pressedAnyButton);
        _selectStageButton.gameObject.SetActive(!pressedAnyButton);
        _optionButton.gameObject.SetActive(!pressedAnyButton);
        _exitButton.gameObject.SetActive(!pressedAnyButton);
    }
    #endregion


    // TODO: On press any button, wait time & play SE.
    // TODO: On press esc key, return to "press any button."
    // TODO: Select Game UI (inherit SelectGameUIModel class).
}
