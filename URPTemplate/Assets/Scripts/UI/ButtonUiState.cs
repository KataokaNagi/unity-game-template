/// <summary>
/// @file     ButtonUIState.cs
/// @brief    Common button ui state.
/// @auther   Kataoka
/// @date     2022-05-10 00:10:37
/// @version  1.0
/// @history  add
/// </summary>

public enum ButtonUIState
{
    Unhover = (1 << 0),
    Hover = (1 << 1),
    Down = (1 << 2),
    Up = (1 << 3),
    Range = 0b00001111
}
