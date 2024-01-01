using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private GameObject _optionPanel;
    [SerializeField] private Ease ease;

    private bool isPanel;
    public void Option_Button()
    {
        if (!isPanel)
        {
            isPanel = true;
            _optionPanel.transform.DOMoveX(0, 0.5f).SetEase(ease);
        }
        else
        {
            Continue_Button();
        }
    }

    public void Continue_Button()
    {
        _optionPanel.transform.DOMoveX(-800, 0.5f).SetEase(ease);
        isPanel = false;
    }

    public void ExitScene_Button()
    {
        SceneManager.LoadScene("StartScene");
    }
}
