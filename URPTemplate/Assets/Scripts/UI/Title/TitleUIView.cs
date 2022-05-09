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
    [SerializeField] Text _timerSecsText;
    [SerializeField] GameObject _hpsUi;
    [SerializeField] GameObject _leftBottomTutorialUi;
    [SerializeField] GameObject _centorTutorialUi;
    [SerializeField] GameObject _kunaisUi;
    [SerializeField] GameObject _energyGaugeUi;
    [SerializeField] Button _centorTutorialCloseButton;
    void Awake()
    {
        // Set invoking events on click buttons.
        // TODO: AddListener to PointerExit, Enter, Down, Up, Press any button
        // _startGameButton.OnPointerExit.AddListener(() => OnStartGameButtonClicked.Invoke());
        // _selectStageButton.OnPointerExit.AddListener(() => OnSelectStageButtonClicked.Invoke());
        // _optionButton.OnPointerExit.AddListener(() => OnOptionButtonClicked.Invoke());
        // _exitButton.OnPointerExit.AddListener(() => OnExitButtonClicked.Invoke());
    }

    #region Set UI.

    #region Set UI other than button.
    public void SetTimerSecsUi(float timerSecs)
    {
    }
    public void SetHpsUi(int numOfHps)
    {
    }
    public void SetLeftBottomTutorialUi(LeftBottomTutorialTags leftBottomTutorialTags)
    {
    }
    public void SetCentorTutorialUi(CentorTutorialTags centorTutorialTags)
    {
    }
    public void SetKunaisUi(int numOfKunais)
    {
    }
    public void SetEnergyGaugeUi(int numOfEnergy)
    {
    }

    #endregion

    #region Set Button UI.
    public void SetButtonUI(int buttonTypeORState)
    {
        int buttonType = buttonTypeORState & (int)IngameButtonType.Range;
        int buttonState = buttonTypeORState & (int)ButtonUiState.Range;

        switch (buttonState)
        {
            case (int)ButtonUiState.Unhover:
                break;
            case (int)ButtonUiState.Hover:
                break;
            case (int)ButtonUiState.Down:
                break;
            case (int)ButtonUiState.Up:
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
            case (int)IngameButtonType.CentorTutorialClose:
                // TODO
                // _startGameButton.
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
            case (int)IngameButtonType.CentorTutorialClose:
                // TODO
                // _startGameButton.
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
            case (int)IngameButtonType.CentorTutorialClose:
                // TODO
                // _startGameButton.
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
            case (int)IngameButtonType.CentorTutorialClose:
                // TODO
                // _startGameButton.
                break;
            default:
                Debug.LogError("Unknown button type");
                break;
        }
    }
    #endregion

    #endregion

    private void SetActiveChildObject(this GameObject gameObject, string childName, bool isActive)
    {
        gameObject.transform.Find(childName).gameObject.SetActive(isActive);
    }

    // TODO: On press any button, wait time & play SE.
    // TODO: On press esc key, return to "press any button."
    // TODO: Select Game UI (inherit SelectGameUIModel class).
}
