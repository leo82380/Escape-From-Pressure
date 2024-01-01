using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    public float mouseSensitivity = 500f;
    public float rotationX = 0f;
    public float rotationY = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        float mouseMoveX = Input.GetAxis("Mouse X");
        float mouseMoveY = Input.GetAxis("Mouse Y");
        
        rotationX += mouseMoveY * mouseSensitivity * Time.deltaTime;
        rotationY += mouseMoveX * mouseSensitivity * Time.deltaTime;

        if (rotationX > 35f)
        {
            rotationX = 35f;
        }
        if (rotationX < -35f)
        {
            rotationX = -35f;
        }
        
        transform.eulerAngles = new Vector3(-rotationX, rotationY, 0f);
    }
}
