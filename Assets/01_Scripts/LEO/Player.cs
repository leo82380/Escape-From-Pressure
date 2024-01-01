using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 500f;
    
    
    private Rigidbody _rigidbody;
    private Camera _mainCamera;
    private bool _isCrouching;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _mainCamera = Camera.main;
    }
    
    private void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X");
        float mouseY = Input.GetAxisRaw("Mouse Y");
        transform.Rotate(Vector3.up * mouseX);
        _mainCamera.transform.Rotate(Vector3.left * mouseY);
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        #region Crouching
        if (_isCrouching && Input.GetKeyDown(KeyCode.LeftControl))
        {
            _isCrouching = false;
        }
        else if (!_isCrouching && Input.GetKeyDown(KeyCode.LeftControl))
        {
            _isCrouching = true;
        }
        #endregion

        #region Crouching speed
        if (_isCrouching)
        {
            _speed = 300f;
        }
        else
        {
            _speed = 500f;
        }
        #endregion
        Vector3 direction = new Vector3(horizontal, 0, vertical);
        _rigidbody.velocity = direction * _speed * Time.deltaTime;
    }
}
