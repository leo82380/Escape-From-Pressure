using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheck : MonoBehaviour
{
    [SerializeField] private string _objectName;
    [SerializeField] public string _interactionText;
    [SerializeField] private string _explainText;

    public bool isTyping;
    public void Typing()
    {
        if(!isTyping && FindObjectOfType<DialogueManager>().canTyping)
        {
            isTyping = true;
            StartCoroutine(FindObjectOfType<DialogueManager>().TypingRoutine(_objectName, _explainText, this));
        }
    }

    
}
