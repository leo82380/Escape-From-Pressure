using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private float moveSpeed = 10f;
    
    private CharacterController characterController;
    private bool _isCrouching;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        cameraTransform = Camera.main.transform;
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(horizontal, 0, vertical);
        moveDirection = cameraTransform.TransformDirection(moveDirection);

        if (Input.GetKeyDown(KeyCode.LeftControl) && !_isCrouching)
        {
            _isCrouching = true;
        }
        if (Input.GetKeyDown(KeyCode.LeftControl) && _isCrouching)
        {
            _isCrouching = false;
        }
        
        if (_isCrouching)
        {
            moveSpeed = 7f;
        }
        else
        {
            moveSpeed = 10f;
        }
        moveDirection *= moveSpeed;
        
        characterController.Move(moveDirection * Time.deltaTime);
    }
}
