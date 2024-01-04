using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

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
    [SerializeField] private List<GameObject> cockroaches;

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
                cockroaches.ForEach(x =>
                {
                    x.SetActive(true);
                    x.transform.DOMove(new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f), 0f), 1f).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo).SetDelay(Random.Range(0f, 1f));
                });
                StartCoroutine(CloseDrawer());
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
