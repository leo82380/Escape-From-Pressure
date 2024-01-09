using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    [SerializeField] public float moveSpeed = 5f;
    [SerializeField] private string sceneName;
    [SerializeField] private Animator _dadAnimator;
    [SerializeField] private BoxCollider trigger;
    
    private CharacterController characterController;
    private DialogueManager _dialogueManager;
    private AudioSource _audioSource;
    private KeyCode[] _moveKeys = { KeyCode.W , KeyCode.A, KeyCode.S, KeyCode.D, KeyCode.UpArrow, KeyCode.DownArrow, KeyCode.LeftArrow, KeyCode.RightArrow };
    private bool _isCrouching;
    private bool isWalking;
    private bool isOpen;
    private bool runrun;
    private bool isCrush;
    private float gravity = -5f;
    private float yVelocity = 0f;

    public bool IsOpen
    {
        get => isOpen;
        set => isOpen = value;
    }

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        cameraTransform = Camera.main.transform;
        _dialogueManager = FindObjectOfType<DialogueManager>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (!_dialogueManager.canTyping) return;
        if (IsOpen) return;
        if (runrun) return;

        Move();
        Crouch();
        Run();
        WalkSound();
    }
    // 이동
    private void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(horizontal, 0, vertical);
        
        moveDirection = cameraTransform.TransformDirection(moveDirection);
        moveDirection *= moveSpeed;
        
        yVelocity += gravity * Time.deltaTime;
        moveDirection.y = yVelocity;
        
        characterController.Move(moveDirection * Time.deltaTime);
    }
    
    // 웅크리기
    private void Crouch()
    {
        float move = 5f;
        if (isCrush)
        {
            move = 5f * 0.635f;
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            _isCrouching = true;
        }
        else
        {
            _isCrouching = false;
        }
        
        float targetY = _isCrouching ? 0.2f : 0.5f;
        cameraTransform.localPosition = Vector3.Lerp(cameraTransform.localPosition, new Vector3(0, targetY, 0), 0.2f);
        moveSpeed = _isCrouching ? 1f : move;
    }
    
    // 달리기
    private void Run()
    {
        if (_isCrouching) return;
        if (isCrush) return;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = 7f;
        }
        else
        {
            moveSpeed = 5f;
        }
    }
    
    // 사운드
    private void WalkSound()
    {
        foreach (var keys in _moveKeys)
        {
            if (Input.GetKeyUp(keys))
            {
                isWalking = false;
            }
            if (Input.GetKeyDown(keys))
            {
                isWalking = true;
            }
        }   
        Audio();
    }

    private void Audio()
    {
        if (isWalking)
        {
            _audioSource.Play();
        }
        else
        {
            _audioSource.Stop();
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        print("야양");
        if (other.CompareTag("Door"))
        {
            StartCoroutine(FadeOutAndScene());       
        }

        if (other.CompareTag("Trigger"))
        {
            trigger.isTrigger = true;
            _dadAnimator.SetBool("Run", true);
            if (_dadAnimator.gameObject.GetComponent<AudioSource>().isPlaying) return;
            _dadAnimator.gameObject.GetComponent<AudioSource>().Play();
            _dadAnimator.gameObject.transform.position += Vector3.forward * 2f;
            StartCoroutine(RunRun(other));
        }
    }

    private IEnumerator RunRun(Collider other)
    {
        moveSpeed = 0;
        runrun = true;
        isCrush = true;
        other.gameObject.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(5f);
        moveSpeed = 5f * 0.635f;
        runrun = false;
        other.gameObject.SetActive(false);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Doorend"))
        {
            other.GetComponent<BoxCollider>().isTrigger = false;
        }
    }

    IEnumerator FadeOutAndScene()
    {
        Fade.Instance.FadeIn(1f);
        yield return new WaitUntil(() => Fade.Instance.image.color.a == 1f);
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}
