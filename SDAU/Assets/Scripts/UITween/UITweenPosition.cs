using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;
using System;
using System.Reflection;

public class UITweenPosition : UITween {

    public Vector3 from;
    public Vector3 to;

    public override void Begin()
    {
        base.Begin();

        if (is2D)
        {
            tween = rectTransform.DOAnchorPos(to, duration).SetAutoKill(false);
        }
        else
        {
            tween = tr.DOBlendableMoveBy(to, duration).SetAutoKill(false);
        }

        SetTween(tween);
    }
}
