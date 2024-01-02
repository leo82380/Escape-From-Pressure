using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Fade : MonoSingleton<Fade>
{
    private Image image;
    private void Awake()
    {
        image = GetComponent<Image>();
        FadeOut(3);
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
