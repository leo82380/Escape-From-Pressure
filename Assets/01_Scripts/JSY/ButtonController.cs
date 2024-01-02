using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private GameObject _optionPanel;
    [SerializeField] private GameObject _inventoryPanel;
    [SerializeField] private TMP_InputField _inputField_PW;
    [SerializeField] private Ease ease;
    [SerializeField] private string _passwordNumber;

    private bool isPanel;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Option_Button();
        }
        if(Input.GetKeyDown(KeyCode.E))
        {
            Inventory();
        }
    }
    private void Inventory()
    {
        if (!isPanel)
        {
            isPanel = true;
            _inventoryPanel.transform.DOMoveY(540, 0.8f).SetEase(ease);
        }
        else
        {
            isPanel = false;
            _inventoryPanel.transform.DOMoveY(540-1100, 0.8f).SetEase(ease);
        }
    }
    public void Option_Button()
    {
        if (!isPanel)
        {
            isPanel = true;
            _optionPanel.transform.DOMoveX(0, 0.5f).SetEase(ease).OnComplete(() =>
            {
                TimeSet(0);
            });
        }
        else
        {
            Continue_Button();
        }
    }

    private void TimeSet(float time) => Time.timeScale = time;

    public void Continue_Button()
    {
        Time.timeScale = 1f;
        _optionPanel.transform.DOMoveX(-800, 0.5f).SetEase(ease).OnComplete(() =>
        {
            TimeSet(1);
        });
        isPanel = false;
    }

    public void ExitScene_Button()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void PasswordCheck_Button()
    {
        if(_inputField_PW.text == _passwordNumber)
        {
            _inputField_PW.text = "";
            print("Á¤´ä!!");
        }
        else
        {
            print("¤´");
        }
    }
}
