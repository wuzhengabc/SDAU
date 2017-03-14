using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;
using System;
using System.Reflection;

public class UITweenAlpha : UITween {

    public float from;
    public float to;

    public Image image;
    public Text text;

    public override void Begin()
    {
        base.Begin();

        if (!is2D)
        {
            return;
        }

        image = GetComponent<Image>();
        text = GetComponent<Text>();

        if (image != null)
        {
            Color col = image.color;
            col.a = from;

            image.color = col;
            tween = image.DOFade(to, duration).SetAutoKill(false);
        }
        else if (text != null)
        {
            Color col = text.color;
            col.a = from;

            text.color = col;
            tween = text.DOFade(to, duration).SetAutoKill(false);
        }
        else
        {
            UITweenDebugLog.DebugLogWarning("this gameObject not add the component " + typeof(Image) + "    " + typeof(Text));
        }

        SetTween(tween);
    }
}
