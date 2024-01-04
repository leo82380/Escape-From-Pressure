using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TV_MaterialController : MonoBehaviour
{
    private Animator animator;
    private bool isNoiseOn = false;
    [SerializeField]

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        animator.SetBool("isNoise", isNoiseOn);
       
    }

    public IEnumerator WhileAnime()
    {
        isNoiseOn = true;
        yield return new WaitForSeconds(4.2f);
        isNoiseOn = false;
    }


    public void PlayNoize()
    {
        isNoiseOn = !isNoiseOn;

    }

}
