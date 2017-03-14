using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Reflection;
using DG.Tweening;


[System.Serializable]
public class EventCallBackClass  //事件回调相应的脚本，脚本中的方法名
{
    public MonoBehaviour _monoBehaviour;
    public string eventName = "";
}

public abstract class UITween : MonoBehaviour {

    //显示时播放
    public bool enablePlay = true;

    [HideInInspector]
    public UITweenLoopType loopType = UITweenLoopType.Restart;

    public int loopTimes = -1;

    [HideInInspector]
    public Ease ease = Ease.Unset;

    [HideInInspector]
    public bool ignoreTimeScale = true;

    [HideInInspector]
    public float delay = 0f;

    [HideInInspector]
    public float duration = 1f;

    [HideInInspector]
    public List<TweenCallback> onFinish = new List<TweenCallback>();

    [HideInInspector]
    public List<EventCallBackClass> eventCallBackClassList = new List<EventCallBackClass>();

    public Tween tween;
    public RectTransform rectTransform;
    public Transform tr;
    public bool is2D = false;
    public TweenCallback Complete;

    public virtual void OnEnable()
    {
        StartCoroutine(DelayBegin(delay));
    }

    public virtual void OnDisable()
    {
        if (tween != null)
        {
            tween.Kill();
            tween = null;
        }
    }

    IEnumerator DelayBegin(float time)
    {
        yield return new WaitForSeconds(time);
        TweenEnable();
    }

    public virtual void TweenEnable()
    {
        if (enablePlay)
        {
            Begin();
        }
    }

    public virtual void Begin()
    {
        if (tween != null)
        {
            DOTween.Kill(tween);
        }

        rectTransform = GetComponent<RectTransform>();
        if (rectTransform != null)
        {
            is2D = true;
        }
        else
        {
            is2D = false;
            tr = transform;
        }
    }

    public static T Begin<T>(GameObject go) where T : UITween
    {
        T t = go.GetComponent<T>();

        if (t == null)
        {
            t = go.AddComponent<T>();

            if (t == null)
            {
                UITweenDebugLog.DebugLogWarning("conld't get Component  " + typeof(T));
                return null;
            }
        }

        t.enabled = true;

        return t;
    }

    public void SetTween(Tween _tween)
    {
        if (_tween == null)
        {
            UITweenDebugLog.DebugLogWarning("Tween is null");
            return;
        }

        _tween.SetEase(ease);

        if ((int)loopType < 3)
        {
            _tween.SetLoops( loopTimes, (LoopType)((int)loopType));
        }

        if (ignoreTimeScale)
        {
            _tween.SetUpdate(UpdateType.Normal, true);
        }

        _tween.OnComplete(OnComplete);
    }

    public void OnComplete()
    {
        if (Complete != null)
        {
            Complete();
        }

        if (eventCallBackClassList.Count <= 0)
        {
            return;
        }

        for (int i = 0; i < eventCallBackClassList.Count; i++)
        {
            if (eventCallBackClassList[i]._monoBehaviour == null)
                continue;

            System.Type t = eventCallBackClassList[i]._monoBehaviour.GetType();

            string[] eventNameArr = eventCallBackClassList[i].eventName.Split('/');

            MethodInfo mi = t.GetMethod(eventNameArr[eventNameArr.Length - 1]);

            if (mi != null)
            {
                mi.Invoke(eventCallBackClassList[i]._monoBehaviour, null);
            }
            else
            {
                Debug.LogWarning("null   " + t.Name);
            }
        }
    }
}


