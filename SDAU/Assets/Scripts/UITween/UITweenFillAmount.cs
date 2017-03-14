using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;
using System;
using System.Reflection;

public class UITweenFillAmount : UITween {

    public float from;
    public float to;

    public Image image;

    public override void Begin()
    {
        base.Begin();

        if (!is2D)
        {
            UITweenDebugLog.DebugLogWarning("not is2D" + typeof(Image));
            return;
        }

        image = GetComponent<Image>();

        if (image == null)
        {
            UITweenDebugLog.DebugLogWarning("this gameObject not add the component " + typeof(Image));
            return;
        }

        if (image.type != Image.Type.Filled)
        {
            image.type = Image.Type.Filled;
        }
        image.fillMethod = Image.FillMethod.Radial360;
        image.fillAmount = from;
        tween = image.DOFillAmount(to, duration).SetAutoKill(false);

        SetTween(tween);
    }
}
