using System.Collections;
using UnityEngine;

public class PetDoorAnimation : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        StartCoroutine(Open());
    }

    private IEnumerator Open()
    {
        yield return new WaitForSeconds(1f);
        OpenDoor();
    }

    private void OpenDoor() => _animator.SetBool("IsOpen", true);
    
    public void CloseDoor() => _animator.SetBool("IsOpen", false);
}
