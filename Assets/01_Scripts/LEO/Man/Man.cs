using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Man : MonoBehaviour
{
    private Ray _ray;
    private Animator _animator;

    private void Awake()
    {
        _animator = transform.root.GetComponent<Animator>();  
    }

    private void Update()
    {
        _ray = new Ray(Vector3.one, Vector3.left);
        RaycastHit hit;
        if (Physics.Raycast(_ray, out hit, 1f))
        { 
            if (hit.collider.GetComponent<PlayerController>()) 
            { 
                _animator.SetTrigger("Run");
            }
        }
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(_ray.origin, _ray.direction * 1f);
    }
}
