using System.Collections;
using UnityEngine;

public class DoorAnimationController : MonoSingleton<DoorAnimationController>
{
    [SerializeField] private GameObject dad;
    private Animator _animator;
    private AudioSource _audioSource;

    protected override void Awake()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }
    
    public void DoorOpen(bool isOpen)
    {
        print("ªﬂ¿Õ");
        _animator.SetBool("Open", isOpen);
        StartCoroutine(Door());
        if (_audioSource.isPlaying) return;
        _audioSource.Play();
    }
    
    public void StageTwoDoorOpen(bool isOpen)
    {
        StartCoroutine(Cooltimeeeeee(isOpen));
    }

    private IEnumerator Cooltimeeeeee(bool isOpen)
    {
        _animator.SetBool("Stage2", isOpen);
        yield return new WaitForSeconds(1f);
        _animator.SetBool("Stage2", false);
        yield return new WaitForSeconds(3f);
        dad.SetActive(false);
    }

    private IEnumerator Door()
    {
        var player = FindObjectOfType<PlayerController>();
        player.IsOpen = true;
        yield return new WaitForSeconds(1f);
        player.IsOpen = false;
    }
}
