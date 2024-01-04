using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DadPush : MonoBehaviour
{
    private Animator _animator;
    
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Doorend"))
        {
            _animator.SetBool("Run", false);
            _animator.SetBool("Push", true);
            FinalDoorEvent.Instance.StartCoroutine(FinalDoorEvent.Instance.DoorEvent());
        }
    }
}
