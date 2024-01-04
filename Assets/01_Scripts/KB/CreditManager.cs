using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreditManager : MonoBehaviour
{
    public GameObject credit;
    public GameObject image;
    public Image background;
    [SerializeField] private float speed;

    private void Awake()
    {
        
    }

    void Update()
    {
        credit.transform.position += Vector3.up * speed * Time.deltaTime;
        image.transform.position += Vector3.up * speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            speed += 2;
            speed = Mathf.Clamp(speed, 80, 160);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            speed -= 2;
            speed = Mathf.Clamp(speed, 40, 160);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            speed = 80;
        }
    }

    public void GoTitle()
    {
        SceneManager.LoadScene("StartScene");
    }
}
