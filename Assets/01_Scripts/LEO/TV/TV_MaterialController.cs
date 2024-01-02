using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TV_MaterialController : MonoBehaviour
{
    private Animator animator;
    private bool isNoiseOn = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        animator.SetBool("isNoise", isNoiseOn);
        if (Input.GetKeyDown(KeyCode.E))
        {
            isNoiseOn = !isNoiseOn;
        }
    }
}
