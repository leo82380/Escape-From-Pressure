using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;

public class DrawerAnimation : MonoBehaviour
{
    public Animator _animator;
    private bool _isDrawerOpen = false;
    [SerializeField] public GameObject passwordPanel;
    
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
        Scene scene = SceneManager.GetActiveScene();
        Debug.Log(scene.name);
        switch (drawerType)
        {
            case DrawerType.Top:
                _animator.SetBool("IsTop", true);
                StartCoroutine(CloseDrawer());
                if (_isDrawerOpen) return;
                _isDrawerOpen = true;
                StartCoroutine(FindObjectOfType<Cockroach>().Rotate());
                break;
            case DrawerType.Middle:
                _animator.SetBool("IsMiddle", true);
                if (scene.name is "Stage-2" or "Stage-4")
                {
                    StartCoroutine(CloseDrawer());
                }
                break;
            case DrawerType.Bottom:
                if (scene.name is "Stage-3" or "Stage-4")
                {
                    _animator.SetTrigger("IsBottom");
                    if (_animator.GetBool("ISBottom")) return;
                    passwordPanel.SetActive(true);
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                }
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
