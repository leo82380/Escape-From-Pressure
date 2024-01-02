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

    public bool canTyping = true;
    void Start()
    {
        originText = objExplainText.text;
        objExplainText.text = "";
    }
    public IEnumerator TypingRoutine(string objectNameText, string objectExplainText, PlayerCheck playerCheck)
    {
        if(canTyping)
        {
            canTyping = false;
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
            yield return new WaitForSeconds(0.5f);
            playerCheck.isTyping = false;
            _dialoguePanel.SetActive(false);
            if (playerCheck._objType == ObjectType.getObject) playerCheck.GetObject();
            canTyping = true;
        }
    }
}
