using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jumpscare : MonoBehaviour
{
    private AudioSource audio;
    public GameObject UIParent;

    private void Awake()
    {
        audio = FindObjectOfType<AudioSource>();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        UITurnOff();
        StartCoroutine(FadeSetter());
    }

    IEnumerator FadeSetter()
    {
        yield return new WaitForSeconds(1.5f);
        audio.volume = Mathf.Lerp(0.65f, 0, 1);
        yield return new WaitForSeconds(2f);
        
        Fade.Instance.FadeIn(1f);
        yield return new WaitForSeconds(4.5f);
        UITurnOn();
    }

    public void GoTitle() => SceneManager.LoadScene("StartScene");

    private void UITurnOn() => UIParent.SetActive(true);
    private void UITurnOff() => UIParent.SetActive(false);  
}
