using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindBGM : MonoBehaviour
{
    public AudioSource audioSource;
    public float pitch = 1f;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    
    private void Update()
    {
        audioSource.pitch = pitch;
    }
}
