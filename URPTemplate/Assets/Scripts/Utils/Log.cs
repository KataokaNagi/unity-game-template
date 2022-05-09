/// <summary>
/// @file     TitleUIPresenter.cs
/// @brief    Android-like logging helper
/// @auther   Kataoka
/// @date     2022-05-07 18:00:11
/// @version  1.0
/// @history  add
/// /// </summary>

using UnityEngine;

public class Log
{

    private static bool ENABLE_DEBUG = true;
    private static bool ENABLE_VERBOSE = true;

    /// <summary>
    /// Debug comment (important)
    /// e.g. "[tag] comment."
    /// </summary>
    /// <param name="tag">Class or function tag. (e.g. this.gameObject)</param>
    /// <param name="comment">Your log comment.</param>
    public static void d(string comment, GameObject gameObject)
    {
        if (ENABLE_DEBUG)
        {
            Debug.Log($"[{gameObject.ToString()}] {comment}.", gameObject);
        }
    }
    public static void d(string comment, string tag)
    {
        if (ENABLE_DEBUG)
        {
            Debug.Log($"[{tag}] {comment}.");
        }
    }
    public static void d(string comment)
    {
        if (ENABLE_DEBUG)
        {
            Debug.Log($"{comment}.");
        }
    }

    /// <summary>
    /// Verbose debug comment (not important)
    /// e.g. "[tag] comment."
    /// </summary>
    /// <param name="tag">Class or function tag. (e.g. this.gameObject)</param>
    /// <param name="comment">Your log comment.</param>
    public static void v(string comment, GameObject gameObject)
    {
        if (ENABLE_VERBOSE)
        {
            Debug.Log($"[{gameObject.ToString()}] {comment}.", gameObject);
        }
    }
    public static void v(string comment, string tag)
    {
        if (ENABLE_VERBOSE)
        {
            Debug.Log($"[{tag}] {comment}.");
        }
    }
    public static void v(string comment)
    {
        if (ENABLE_VERBOSE)
        {
            Debug.Log($"{comment}.");
        }
    }

    /// <summary>
    /// Error debug comment (red)
    /// e.g. "[tag] comment."
    /// </summary>
    /// <param name="tag">Class or function tag. (e.g. this.gameObject)</param>
    /// <param name="comment">Your log comment.</param>
    public static void e(string comment, GameObject gameObject)
    {
        Debug.LogError($"[{gameObject.ToString()}] {comment}.", gameObject);
    }
    public static void e(string comment, string tag)
    {
        Debug.LogError($"[{tag}] {comment}.");
    }
    public static void e(string comment)
    {
        Debug.LogError($"{comment}.");
    }

    /// <summary>
    /// Warning debug comment (yerrow)
    /// e.g. "[tag] comment."
    /// </summary>
    /// <param name="tag">Class or function tag. (e.g. this.gameObject)</param>
    /// <param name="comment">Your log comment.</param>
    public static void w(string comment, GameObject gameObject)
    {
        Debug.LogWarning($"[{gameObject.ToString()}] {comment}.", gameObject);
    }
    public static void w(string comment, string tag)
    {
        Debug.LogWarning($"[{tag}] {comment}.");
    }
    public static void w(string comment)
    {
        Debug.LogWarning($"{comment}.");
    }

}