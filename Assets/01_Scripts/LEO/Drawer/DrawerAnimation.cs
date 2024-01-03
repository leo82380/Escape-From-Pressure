using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerAnimation : MonoBehaviour
{
    private Animator _animator;
    
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
                StartCoroutine(CloseDrawer());
                break;
            case DrawerType.Middle:
                _animator.SetBool("IsMiddle", true);
                StartCoroutine(CloseDrawer());
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
