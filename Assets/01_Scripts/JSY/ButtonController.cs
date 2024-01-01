using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private GameObject _optionPanel;

    private bool isPanel;
    public void Option_Button()
    {
        if (!isPanel)
        {
            isPanel = true;
            _optionPanel.SetActive(true);
        }
        else
        {
            Continue_Button();
        }
    }

    public void Continue_Button()
    {
        _optionPanel.SetActive(false);
        isPanel = false;
    }
}
