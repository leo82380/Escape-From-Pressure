using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Man : MonoBehaviour
{
    private Ray _ray;
    private Animator _animator;
    private float time = 0;

    private void Awake()
    {
        _animator = transform.root.GetComponent<Animator>();  
    }

    private void Update()
    {
        if (!FindObjectOfType<PlayerRay>().isOpen) return;
        _ray = new Ray(transform.position, Vector3.left);
        RaycastHit hit;
        if (Physics.Raycast(_ray, out hit, 4f))
        { 
            if (hit.collider.GetComponent<PlayerController>()) 
            { 
                time += Time.deltaTime;
                if (time >= 0.5f)
                    StartCoroutine(Run());
            }
        }
    }

    private IEnumerator Run()
    {
        _animator.SetTrigger("Run");
        yield return new WaitForSeconds(3f);
        PetDoorAnimation petDoorAnimation = FindObjectOfType<PetDoorAnimation>();
        petDoorAnimation.CloseDoor();
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, Vector3.left * 4f);
    }
}
