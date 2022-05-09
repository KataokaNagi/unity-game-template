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
using System.Collections;
using System.Collections.Generic;
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
    [Space(10)]

    [Header("Consts (if BaseName = HpFire, then children's names = HpFire1, 2, ...)")]
    [SerializeField] int _maxNumOfHps = 5;
    [SerializeField] string _hpObjectBaseName = "HpFire";
    [SerializeField] int _maxNumOfKunais = 3;
    [SerializeField] string _kunaiObjectBaseName = "Kunai";
    [SerializeField] int _maxNumOfEnergy = 5;
    [SerializeField] float _energyTransformingSeconds = 0.5f;

    private int _pastNumOfEnergy = 0;

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
        _timerSecsText.text = timerSecs.ToString();
    }
    public void SetHpsUi(int numOfHps)
    {
        // Exception of range.
        if (numOfHps < 0 || _maxNumOfHps < numOfHps)
        {
            Log.e($"Unsuspected num of hps: {numOfHps}", this.gameObject);
            return;
        }

        // Set active.
        for (int hpId = 1; hpId <= numOfHps; ++hpId)
        {
            var isActive = (hpId <= numOfHps) ? true : false;
            var childName = $"{_hpObjectBaseName}{hpId.ToString()}";
            SetActiveChildObject(_hpsUi, childName, isActive);
        }
    }
    public void SetLeftBottomTutorialUi(LeftBottomTutorialTags leftBottomTutorialTags)
    {
        switch (leftBottomTutorialTags)
        {
            case LeftBottomTutorialTags.NoView:
                // TODO
                break;
            // TODO: Add cases.
            default:
                Log.e($"Unexpected leftBottomTutorialTags: {leftBottomTutorialTags}", this.gameObject);
                break;
        }
    }
    public void SetCentorTutorialUi(CentorTutorialTags centorTutorialTags)
    {
        switch (centorTutorialTags)
        {
            case CentorTutorialTags.NoView:
                // TODO
                break;
            // TODO: Add cases.
            default:
                Log.e($"Unexpected centorTutorialTags: {centorTutorialTags}", this.gameObject);
                break;
        }
    }
    public void SetKunaisUi(int numOfKunais)
    {
        // Exception of range.
        if (numOfKunais < 0 || _maxNumOfKunais < numOfKunais)
        {
            Log.e($"Unsuspected num of kunais: {numOfKunais}", this.gameObject);
            return;
        }

        // Set active.
        for (int kunaiId = 1; kunaiId <= numOfKunais; ++kunaiId)
        {
            var isActive = (kunaiId <= numOfKunais) ? true : false;
            var childName = $"{_kunaiObjectBaseName}{kunaiId.ToString()}";
            SetActiveChildObject(ref _hpsUi, childName, isActive);
        }
    }
    public void SetEnergyGaugeUi(int numOfEnergy)
    {
        // Exception of range.
        if (numOfEnergy < 0 || _maxNumOfEnergy < numOfEnergy)
        {
            Log.e($"Unsuspected numOfEnergy: {numOfEnergy}", this.gameObject);
            return;
        }

        // TODO: Make more beauty
        StartCoroutine(CoSetShrinkingTransformX(_pastNumOfEnergy, numOfEnergy));
        _pastNumOfEnergy = numOfEnergy;
    }

    // Need ref?
    private IEnumerator CoSetShrinkingTransformX(int fromNumOfEnergy, int toNumOfEnergy)
    {
        Vector3 energyScale = _energyGaugeUi.transform.localScale;
        float fromScaleX = energyScale.x;
        float toScaleX = fromScaleX * ((float)toNumOfEnergy / fromNumOfEnergy);
        float maxScaleX = Mathf.Max(fromScaleX, toScaleX);
        float minScaleX = Mathf.Min(fromScaleX, toScaleX);

        float dT = Time.deltaTime;
        bool increaceEnergy = (fromNumOfEnergy <= toNumOfEnergy);

        if (increaceEnergy)
        {
            for (float cntTime = 0f; cntTime > _energyTransformingSeconds; cntTime += dT)
            {
                energyScale.x = Easing.SineInOut(t, _energyTransformingSeconds, minScaleX, maxScaleX);
                yield return null;
            }
        }
        else
        {
            for (float cntTime = _energyTransformingSeconds; cntTime < 0; cntTime -= dT)
            {
                energyScale.x = Easing.SineInOut(t, _energyTransformingSeconds, minScaleX, maxScaleX);
                yield return null;
            }
        }
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

    private void SetActiveChildObject(ref GameObject gameObject, string childName, bool isActive)
    {
        gameObject.transform.Find(childName).gameObject.SetActive(isActive);
    }

    // TODO: On press any button, wait time & play SE.
    // TODO: On press esc key, return to "press any button."
    // TODO: Select Game UI (inherit SelectGameUIModel class).
}
