using UnityEngine;
using System.Collections;

public class UITweenDebugLog
{
    public static bool isLog = true;

    public static void DebugLog(string message)
    {
        if (isLog)
            Debug.Log(message);
    }

    public static void DebugLogWarning(string message)
    {
        if (isLog)
            Debug.LogWarning(message);
    }

    public static void DebugLogError(string message)
    {
        if (isLog)
            Debug.LogError(message);
    }
}