/// <summary>
/// @file     UiEvent.cs
/// @brief    Define events type that need a parameter.
/// @auther   Kataoka
/// @date     2022-05-10 06:12:44
/// @version  1.0
/// @history  add
/// @see      [UnityにおけるMVPパターンについて](https://virtualcast.jp/blog/2019/11/mvp_pattern_on_unity/)
/// </summary>

using UnityEngine.Events;

public sealed class BoolEvent : UnityEvent<bool>
{
}
public sealed class IntEvent : UnityEvent<int>
{
}
public sealed class FloatEvent : UnityEvent<float>
{
}

