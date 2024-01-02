using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Fade : MonoSingleton<Fade>
{
    private Image image;
    public override void Awake()
    {
        base.Awake();   
        image = GetComponent<Image>();
    }
    
    public void FadeIn(float duration)
    {
        gameObject.SetActive(true);
        image.DOFade(1f, duration);
    }
    
    public void FadeOut(float duration)
    {
        image.DOFade(0f, duration).OnComplete(() => gameObject.SetActive(false));
    }
}
