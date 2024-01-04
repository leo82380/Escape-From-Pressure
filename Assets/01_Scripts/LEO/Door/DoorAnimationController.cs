using System.Collections;
using UnityEngine;

public class DoorAnimationController : MonoSingleton<DoorAnimationController>
{
    [SerializeField] private GameObject dad;
    private Animator _animator;

    protected override void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    
    public void DoorOpen(bool isOpen)
    {
        _animator.SetBool("Open", isOpen);
    }
    
    public void StageTwoDoorOpen(bool isOpen)
    {
        StartCoroutine(Cooltimeeeeee(isOpen));
    }

    IEnumerator Cooltimeeeeee(bool isOpen)
    {
        _animator.SetBool("Stage2", isOpen);
        yield return new WaitForSeconds(1f);
        _animator.SetBool("Stage2", false);
        yield return new WaitForSeconds(3f);
        dad.SetActive(false);
    }
    
}
