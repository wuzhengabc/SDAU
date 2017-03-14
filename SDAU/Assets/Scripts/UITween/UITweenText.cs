using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;
using System;
using System.Reflection;

public class UITweenText : UITween {

    public string from;
    public string to;
    public float speed;
    public bool useSpeed = false;
    private Text text = null;

    public override void Begin()
    {
        base.Begin();

        if (!is2D)
        {
            return;
        }

        text = GetComponent<Text>();

        if (useSpeed && speed != 0)
        {
            duration = to.Length * 1.0f / speed;
        }

        text.text = from;
        tween = text.DOText(to, duration).SetAutoKill(false);

        SetTween(tween);
    }

    public void SetText(string text)
    {
        to = text;
    }
}
