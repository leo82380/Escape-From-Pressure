using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeMove : MonoBehaviour
{
    [SerializeField] private Transform target;
    private Vector3 lookDir;

    private void LateUpdate()
    {
        lookDir = (target.position - transform.position).normalized;

        Quaternion from = transform.rotation;
        Quaternion to = Quaternion.LookRotation(lookDir);

        transform.rotation = Quaternion.Lerp(from, to, Time.deltaTime);
    }
}
