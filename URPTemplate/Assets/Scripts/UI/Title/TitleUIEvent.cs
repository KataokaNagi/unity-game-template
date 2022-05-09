/// <summary>
/// @file     TitleUIEvent.cs
/// @brief    Define events type that need a parameter.
/// @auther   Kataoka
/// @date     2022-05-05 22:22:11
/// @version  1.0
/// @history  add
/// @see      [UnityにおけるMVPパターンについて](https://virtualcast.jp/blog/2019/11/mvp_pattern_on_unity/)
/// </summary>

using UnityEngine.Events;

public sealed class IntEvent : UnityEvent<int>
{
}

public sealed class BoolEvent : UnityEvent<bool>
{
}
