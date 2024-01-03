using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObjectType
{
    getObject,
    notGetObject,
    fakeObject
}
public class PlayerCheck : MonoBehaviour
{
    public ObjectType _objType;
    [SerializeField] private string _objectName;
    [SerializeField] public string _interactionText;
    [SerializeField] private string _explainText;
    [SerializeField] private int getObjectNumber;

    public bool isTyping;
    private DialogueManager _dialogueManager;
    private Inventory _inventory;

    private void Awake()
    {
        _dialogueManager = FindObjectOfType<DialogueManager>();
        _inventory = FindObjectOfType<Inventory>();
    }
    public void Typing()
    {
        if(!isTyping && _dialogueManager.canTyping)
        {
            isTyping = true;
            StartCoroutine(_dialogueManager.TypingRoutine(_objectName, _explainText, this));
        }
    }
    public void GetObject()
    {
        _inventory.InventoryImageSetActive(getObjectNumber);
        Destroy(gameObject);
    }

    public void TrickObject()
    {

    }
}
