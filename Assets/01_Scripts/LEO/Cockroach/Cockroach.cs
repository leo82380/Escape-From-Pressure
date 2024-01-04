using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Cockroach : MonoBehaviour
{
    private void Start()
    {
        Rotate();
    }

    private void Rotate()
    {
        transform.DORotate(new Vector3(0, 0, 10f), 1f)
            .OnComplete(() =>
            {
                transform.DORotate(new Vector3(0, 0, -10f), 1f);
            });
    }
}
