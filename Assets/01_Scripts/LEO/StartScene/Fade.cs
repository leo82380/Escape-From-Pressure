using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Fade : MonoSingleton<Fade>
{
    public Image image;
    protected override void Awake()
    {
        base.Awake();
        image = GetComponent<Image>();
        FadeOut(1f);
    }
    
    public void FadeIn(float duration)
    {
        image.DOFade(1f, duration);
    }
    
    public void FadeOut(float duration)
    {
        image.DOFade(0f, duration);
    }
}
