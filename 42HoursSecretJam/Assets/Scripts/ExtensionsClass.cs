using System;
using System.Collections;
using UnityEngine;

public static class ExtensionsClass
{

    public static void InvokeDelegate(this MonoBehaviour me, Action theDelegate, float time)
    {
        me.StartCoroutine(ExecuteAfterTime(theDelegate, time));
    }

    private static IEnumerator ExecuteAfterTime(Action theDelegate, float delay)
    {
        yield return new WaitForSeconds(delay);
        theDelegate();
    }

}
