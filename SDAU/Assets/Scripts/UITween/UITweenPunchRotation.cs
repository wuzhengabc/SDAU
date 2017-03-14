using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;
using System;
using System.Reflection;


public class UITweenPunchRotation : UITween {

    public Vector3 from;
    public Vector3 to;

    public override void Begin()
    {
        base.Begin();

        if (is2D)
        {
            tween = rectTransform.DOPunchRotation (to, duration).SetAutoKill(false);
        }
        else
        {
            tween = tr.DOPunchPosition(to, duration).SetAutoKill(false);
        }

        SetTween(tween);
    }
}
