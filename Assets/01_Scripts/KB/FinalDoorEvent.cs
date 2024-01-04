using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinalDoorEvent : MonoSingleton<FinalDoorEvent>
{
    [SerializeField] private AudioSource audio;
    [SerializeField] private AudioSource screamAudio;
    [SerializeField] private Image blackImage;
    
    [SerializeField] private float inTime = 8;
    [SerializeField] private int flagCount = 75;
    [SerializeField] private Image filledCircle;
    
    [SerializeField] private bool isClear = false;
    [SerializeField] private int myCount = 0;
    [SerializeField] private float time = 0;
    public bool GetIsClear => isClear;

    protected override void Awake()
    {
        base.Awake();
    }

    public IEnumerator DoorEvent()
    {
        Debug.Log("DoorEvent");
        filledCircle.gameObject.SetActive(true);
        filledCircle.fillAmount = 0;
        time = 0;
        
        while (time <= inTime)
        {
            time += Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.Space))
            { 
                myCount++;
                filledCircle.fillAmount += (float)1 / flagCount;
            }
            if (filledCircle.fillAmount >= 0.99f && myCount == flagCount) isClear = true;
            else isClear = false; 
            yield return null;
        }
        
        if (filledCircle.fillAmount >= 0.99f && myCount >= flagCount) isClear = true;
        else isClear = false;
        
        StartCoroutine(End());
    }

    private IEnumerator End()
    {
        blackImage.gameObject.SetActive(true);
        if (isClear)
        {
            audio.Play();
        }
        else
        {
            screamAudio.Play();
        }
        
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("Credit");
    }
}
