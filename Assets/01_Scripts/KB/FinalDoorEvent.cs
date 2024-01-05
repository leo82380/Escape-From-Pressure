using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinalDoorEvent : MonoSingleton<FinalDoorEvent>
{
    
    
    [SerializeField] private float inTime = 8;
    [SerializeField] private int flagCount = 75;
    
    
    [SerializeField] private bool isClear = false;
    [SerializeField] private int myCount = 0;
    [SerializeField] private float time = 0;
    public bool GetIsClear => isClear;

    protected override void Awake()
    {
        base.Awake();
        
    }

    private void Start()
    {
        StartCoroutine(Take());
    }

    IEnumerator Take()
    {
        yield return new WaitForSeconds(1f);
        
    }

    public IEnumerator DoorEvent()
    {
        Debug.Log("DoorEvent");
        SoundEnding soundEnding = FindObjectOfType<SoundEnding>();
        soundEnding.filledCircle.gameObject.SetActive(true);
        soundEnding.filledCircle.fillAmount = 0;
        time = 0;
        
        while (time <= inTime)
        {
            time += Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.Space))
            { 
                myCount++;
                soundEnding.filledCircle.fillAmount += (float)1 / flagCount;
            }
            if (soundEnding.filledCircle.fillAmount >= 0.99f && myCount == flagCount) isClear = true;
            else isClear = false; 
            yield return null;
        }
        
        if (soundEnding.filledCircle.fillAmount >= 0.99f && myCount >= flagCount) isClear = true;
        else isClear = false;
        
        StartCoroutine(End(soundEnding));
    }

    private IEnumerator End(SoundEnding soundEnding)
    {
        soundEnding.blackImage.gameObject.SetActive(true);
        if (isClear)
        {
            soundEnding.audio.Play();
        }
        else
        {
            soundEnding.screamAudio.Play();
        }
        
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("Credit");
    }
}
