using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class DrawerAnimation : MonoBehaviour
{
    private Animator _animator;
    private bool _isDrawerOpen = false;
    
    private enum DrawerType
    {
        Top,
        Middle,
        Bottom
    }
    [SerializeField] private DrawerType drawerType;

    private void Awake()
    {
        _animator = transform.parent.GetComponent<Animator>();
    }
    
    public void OpenDrawer()
    {
        switch (drawerType)
        {
            case DrawerType.Top:
                _animator.SetBool("IsTop", true);
                if (_isDrawerOpen) return;
                _isDrawerOpen = true;
                StartCoroutine(FindObjectOfType<Cockroach>().Rotate());
                break;
            case DrawerType.Middle:
                _animator.SetBool("IsMiddle", true);
                break;
            case DrawerType.Bottom:
                _animator.SetTrigger("IsBottom");
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
    
    public IEnumerator CloseDrawer()
    {
        yield return new WaitForSeconds(1.7f);
        switch (drawerType)
        {
            case DrawerType.Top:
                _animator.SetBool("IsTop", false);
                break;
            case DrawerType.Middle:
                _animator.SetBool("IsMiddle", false);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
    
    
}
