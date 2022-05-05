/// <summary>
/// @file     TitleUIPresenter.cs
/// @brief    Presenter for mvp model.
/// @auther   Kataoka
/// @date     2022-05-05 22:22:11
/// @version  1.0
/// @history  add
/// @see      [UnityにおけるMVPパターンについて](https://virtualcast.jp/blog/2019/11/mvp_pattern_on_unity/)
/// @see      [Unityでの複数シーンを使ったゲームの実装方法とメモリリークについて](https://madnesslabo.net/utage/?page_id=11109)
/// /// </summary>

using UnityEngine;

public sealed class TitleUIPresenter : MonoBehaviour
{
    [Header("Model & View scripts for MVP models")]
    [SerializeField] TitleUIModel _model;
    [SerializeField] TitleUIView _view;

    void Awake()
    {
        #region Init.
        // TODO: Set music from model to view.
        // TODO: Set textures from model to view.
        #endregion

        #region Model 2 View.
        _model.OnStartGameButtonChanged.AddListener(stateORtype => _view.ChangeButtonUI(stateORtype));
        _model.OnSelectStageButtonChanged.AddListener(stateORtype => _view.ChangeButtonUI(stateORtype));
        _model.OnOptionButtonChanged.AddListener(stateORtype => _view.ChangeButtonUI(stateORtype));
        _model.OnExitButtonChanged.AddListener(stateORtype => _view.ChangeButtonUI(stateORtype));
        _model.OnPressEnyButton.AddListener(pressedAnyButton => _view.TogglePressAnyButton(pressedAnyButton));
        #endregion

        #region View 2 Model.
        // Unhover buttons.
        _view.OnStartGameButtonUnhovered.AddListener(() => _model.UnhoverStartGameButton());
        _view.OnSelectStageButtonUnhovered.AddListener(() => _model.UnhoverSelectStageButton());
        _view.OnOptionButtonUnhovered.AddListener(() => _model.UnhoverOptionButton());
        _view.OnExitButtonUnhovered.AddListener(() => _model.UnhoverExitButton());

        // Hover buttons.
        _view.OnStartGameButtonHovered.AddListener(() => _model.HoverStartGameButton());
        _view.OnSelectStageButtonHovered.AddListener(() => _model.HoverSelectStageButton());
        _view.OnOptionButtonHovered.AddListener(() => _model.HoverOptionButton());
        _view.OnExitButtonHovered.AddListener(() => _model.HoverExitButton());

        // Down buttons.
        _view.OnStartGameButtonDown.AddListener(() => _model.DownStartGameButton());
        _view.OnSelectStageButtonDown.AddListener(() => _model.DownSelectStageButton());
        _view.OnOptionButtonDown.AddListener(() => _model.DownOptionButton());
        _view.OnExitButtonDown.AddListener(() => _model.DownExitButton());

        // Up buttons.
        _view.OnStartGameButtonUp.AddListener(() => _model.UpStartGameButton());
        _view.OnSelectStageButtonUp.AddListener(() => _model.UpSelectStageButton());
        _view.OnOptionButtonUp.AddListener(() => _model.UpOptionButton());
        _view.OnExitButtonUp.AddListener(() => _model.UpExitButton());

        // Press any button.
        _view.OnPressAnyButton.AddListener(pressed => _model.SetPressedAnyButton(pressed));
        #endregion
    }
}
