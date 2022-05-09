/// <summary>
/// @file     Easing.cs
/// @brief    return 
/// @auther   Kataoka
/// @date     2022-05-10 03:57:13
/// @version  1.0
/// @history  add
/// @see      [Unityに自前でイージング関数を用意する(C#)](https://qiita.com/pixelflag/items/e5ddf0160781170b671b)
/// </summary>
using UnityEngine;

public class Easing
{
    public static float SineInOut(float t, float totaltime, float min, float max)
    {
        max -= min;
        return -max / 2 * (Mathf.Cos(t * Mathf.PI / totaltime) - 1) + min;
    }
}
