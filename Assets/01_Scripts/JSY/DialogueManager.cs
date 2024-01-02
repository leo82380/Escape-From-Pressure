using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using KoreanTyper;

public class DialogueManager : MonoBehaviour
{
    string originText;
    [SerializeField] private TextMeshProUGUI _objNameText;
    [SerializeField] private TextMeshProUGUI objExplainText;
    [SerializeField] private GameObject _dialoguePanel;
    void Start()
    {
        originText = objExplainText.text;
        objExplainText.text = "";
    }
    public IEnumerator TypingRoutine(string objectNameText, string objectExplainText, PlayerCheck playerCheck)
    {
        _dialoguePanel.SetActive(true);
        _objNameText.text = objectNameText;
        originText = objectExplainText;
        int typingLength = originText.GetTypingLength();
        print(typingLength);

        for (int index = 0; index <= typingLength; index++)
        {
            objExplainText.text = originText.Typing(index);

            yield return new WaitForSeconds(0.05f);
        }

        playerCheck.isTyping = false;
        _dialoguePanel.SetActive(false);
    }
}
