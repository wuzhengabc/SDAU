using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;
using System;
using System.Reflection;

public class UITweenSlider : UITween {

    public float from;
    public float to;

    public Slider slider;

    public override void Begin()
    {
        base.Begin();

        if (!is2D)
        {
            return;
        }

        slider = GetComponent<Slider>();

        if (slider == null)
        {
            UITweenDebugLog.DebugLogWarning("this gameObject not add the component " + typeof(Slider));
            return;
        }

        slider.value = from;
        tween = slider.DOValue(to, duration).SetAutoKill(false);

        SetTween(tween);
    }
}
