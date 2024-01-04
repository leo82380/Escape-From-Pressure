using UnityEngine;

public class DoorAnimationController : MonoSingleton<DoorAnimationController>
{
    private Animator _animator;

    protected override void Awake()
    {
        base.Awake();
        _animator = GetComponent<Animator>();
    }
    
    public void DoorOpen(bool isOpen)
    {
        _animator.SetBool("Open", isOpen);
    }
    
    public void StageTwoDoorOpen(bool isOpen)
    {
        _animator.SetBool("Stage2", isOpen);
    }
    
}
