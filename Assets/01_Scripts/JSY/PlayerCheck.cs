using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheck : MonoBehaviour
{
    [SerializeField] private string _objectName;
    [SerializeField] private string _interactionText;
    [SerializeField] private string _explainText;

    private Vector3 playerTransform;
    private bool canPanel;
    public bool isTyping;
    private void Update()
    {
        playerTransform = FindObjectOfType<PlayerController>().transform.position;
        float transformm = Vector3.Distance(transform.position, playerTransform);
        
        if (transformm < 2f)
        {
            FindObjectOfType<PlayerInteraction>().SetActiveInteractionPanel(true, _interactionText);
            canPanel = false;
            if(Input.GetKeyDown(KeyCode.F) && !isTyping)
            {
                isTyping = true;
                StartCoroutine(FindObjectOfType<DialogueManager>().TypingRoutine(_objectName, _explainText, this));
            }
        }
        else
        {
            if (canPanel) return;
            else
            {
                canPanel = true;
            }
            FindObjectOfType<PlayerInteraction>().SetActiveInteractionPanel(false);
        }
    }

    
}