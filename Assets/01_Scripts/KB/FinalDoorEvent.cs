using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinalDoorEvent : MonoSingleton<FinalDoorEvent>
{
    [SerializeField] private float inTime = 8;
    [SerializeField] private int flagCount = 75;
    [SerializeField] private Image filledCircle;
    
    private bool isClear = false;
    private int myCount = 0;
    private float time = 0;
    public bool GetIsClear => isClear;

    private void Start()
    {
        filledCircle.gameObject.SetActive(false);
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

                if (filledCircle.fillAmount >= 0.99f && myCount == flagCount) isClear = true;
                else isClear = false; 
            }

            yield return null;
        }
        
        if (filledCircle.fillAmount >= 0.99f && myCount == flagCount) isClear = true;
        else isClear = false;
        SceneManager.LoadScene("");
    }
}
